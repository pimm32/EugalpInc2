using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Logic.DAL_Interfaces;
using Logic.DAL_Interfaces.Dto_models;

namespace DAL
{
    public class DbLandContext: DbContext, IDbLandContext
    {
        public LandDto VraagLandOp(string naam)
        {
            string query = "_vraagLandOp";
            LandDto resultaat = new LandDto();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.String).Value = naam;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        resultaat.naam = dataReader.GetString(0);
                        resultaat.inwonersaantal = dataReader.GetInt32(1);
                        resultaat.straatbezetting = dataReader.GetDecimal(2);
                        resultaat.doktersbezoeken = dataReader.GetDecimal(3);
                    }

                    dataReader.Close();
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
                this.CloseConnection();
            }
            return resultaat;
        }
        public IEnumerable<LandDto> VraagAlleLandenOpUitDatabase()
        {
            string query = "_AlleLanden";
            List<LandDto> resultaat = new List<LandDto>();
            if (this.OpenConnection())
            {
                

                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        LandDto land = new LandDto(dataReader.GetString(0), dataReader.GetInt32(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3));
                        resultaat.Add(land);
                    }

                    dataReader.Close();
                }
                catch(Exception exception)
                {
                    //TODO handle exception
                    resultaat = null;
                    throw new Exception(exception.ToString());
                }
                
                this.CloseConnection();
            }

            return resultaat;
        }
    }
}
