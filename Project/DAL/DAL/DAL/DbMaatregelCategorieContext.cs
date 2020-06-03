using DAL.DalModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    class DbMaatregelCategorieContext: DbContext
    {
        public List<DalMaatregelCategorie> VraagAlleMaatregelCategorienOpUitDatabase()
        {
            List<DalMaatregelCategorie> resultaat = new List<DalMaatregelCategorie>();
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
                        DalMaatregelCategorie maatregelCategorie = new DalMaatregelCategorie();
                        maatregelCategorie.naam = dataReader.GetString(0);
                        resultaat.Add(maatregelCategorie);
                    }
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
