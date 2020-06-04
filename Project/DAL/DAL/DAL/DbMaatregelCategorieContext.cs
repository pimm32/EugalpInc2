using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    class DbMaatregelCategorieContext: DbContext
    {
        public IEnumerable<MaatregelCategorie> VraagAlleMaatregelCategorienOpUitDatabase()
        {
            List<MaatregelCategorie> resultaat = new List<MaatregelCategorie>();
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
                        MaatregelCategorie maatregelCategorie = new MaatregelCategorie();
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
