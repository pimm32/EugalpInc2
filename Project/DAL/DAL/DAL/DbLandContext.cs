using DAL.DalModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DAL
{
    public class DbLandContext: DbContext
    {
        public IEnumerable<DalLand> VraagAlleLandenOpUitDatabase()
        {
            string query = "";
            List<DalLand> resultaat = new List<DalLand>();
            if (this.OpenConnection())
            {
                

                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DalLand land = new DalLand();
                        land.naam = dataReader.GetString(0);
                        land.inwonersaantal = dataReader.GetInt32(1);
                        land.straatbezetting = dataReader.GetDecimal(2);
                        land.doktersbezoeken = dataReader.GetDecimal(3);
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
