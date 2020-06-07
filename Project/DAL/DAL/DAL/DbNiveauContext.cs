using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Logic.DAL_Interfaces;
using Logic.DAL_Interfaces.Dto_models;

namespace DAL
{
    public class DbNiveauContext: DbContext, IDbNiveauContext
    {
        public NiveauDto VraagNiveauOpUitDatabase(string niveau)
        {
            string query = "";
            NiveauDto resultaat = new NiveauDto();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = niveau;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        resultaat = new NiveauDto(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3));
                    }
                    dataReader.Close();
                }
                catch(Exception exception)
                {
                    resultaat = null;
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
            return resultaat;
        }
    }
}
