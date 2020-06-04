using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DbSymptoomCategorieContext:DbContext
    {
        public List<SymptoomCategorie> VraagAlleSymptoomCategorienOpUitDatabase()
        {
            List<SymptoomCategorie> resultaat = new List<SymptoomCategorie>();
            string query = "_AlleSymptoomCategorienOpvragen";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        SymptoomCategorie symptoomCategorie = new SymptoomCategorie();
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
