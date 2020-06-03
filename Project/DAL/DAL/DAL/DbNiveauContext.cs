using DAL.DalModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DbNiveauContext: DbContext
    {
        public DalNiveau VraagNiveauOpUitDatabase(string niveau)
        {
            string query = "";
            DalNiveau resultaat = new DalNiveau();
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
                        resultaat.naam = dataReader.GetString(0);
                        resultaat.standaardBesmettingsgraad = dataReader.GetDecimal(1);
                        resultaat.standaardHerkenbaarheidsgraad = dataReader.GetDecimal(2);
                        resultaat.standaardSterftegraad = dataReader.GetDecimal(3);
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
