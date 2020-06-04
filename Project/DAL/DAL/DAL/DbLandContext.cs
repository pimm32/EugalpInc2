using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DAL
{
    public class DbLandContext: DbContext
    {
        public IEnumerable<Land> VraagAlleLandenOpUitDatabase()
        {
            string query = "";
            List<Land> resultaat = new List<Land>();
            if (this.OpenConnection())
            {
                

                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Land land = new Land(dataReader.GetString(0), dataReader.GetInt32(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3));
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
