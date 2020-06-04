using DAL.DalModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DbSymptoomCategorieContext:DbContext
    {
        public List<DalSymptoomCategorie> VraagAlleSymptoomCategorienOpUitDatabase()
        {
            List<DalSymptoomCategorie> resultaat = new List<DalSymptoomCategorie>();
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DalSymptoomCategorie symptoomCategorie = new DalSymptoomCategorie();
                        symptoomCategorie.naam = dataReader.GetString(0);
                        resultaat.Add(symptoomCategorie);
                    }
                }
                catch (Exception exception)
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
