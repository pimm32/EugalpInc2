using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Logic.DAL_Interfaces;

namespace DAL
{
    public class DbSymptoomCategorieContext:DbContext, IDbSymptoomCategorieContext
    {
        public IEnumerable<SymptoomCategorie> VraagAlleSymptoomCategorienOpUitDatabase()
        {
            List<SymptoomCategorie> resultaat = new List<SymptoomCategorie>();
            using (connection)
            {
                connection.Open();
                string query = "_AlleSymptoomCategorienOpvragen";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new SymptoomCategorie(reader.GetString(0));
                        }
                    }
                }
            }
            
            
            //if (this.OpenConnection())
            //{
            //    try
            //    {
            //        MySqlCommand cmd = new MySqlCommand(query, connection);
            //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //        MySqlDataReader dataReader = cmd.ExecuteReader();
            //        while (dataReader.Read())
            //        {
            //            yield return 
            //            //SymptoomCategorie symptoomCategorie = new SymptoomCategorie(dataReader.GetString(0));
            //            //resultaat.Add(symptoomCategorie);
            //        }
            //    }
            //    catch (Exception exception)
            //    {
            //        resultaat = null;
            //        throw new Exception(exception.ToString());
            //    }
            //    this.CloseConnection();
            //}
            //return resultaat;
        }
    }
}
