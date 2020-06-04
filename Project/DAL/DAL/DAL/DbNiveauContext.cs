using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DbNiveauContext: DbContext
    {
        public Niveau VraagNiveauOpUitDatabase(string niveau)
        {
            string query = "";
            Niveau resultaat = new Niveau();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = niveau;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        resultaat = new Niveau(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3));
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
