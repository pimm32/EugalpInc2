using DAL.DalModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DbUitbraakContext: DbContext
    {
        public void UitbraakOpslaanInDatabase(DalUitbraak uitbraak, DalVirus virus)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@virus", MySqlDbType.String).Value = virus.naam;
                    cmd.Parameters.Add("@land", MySqlDbType.String).Value = uitbraak.land.naam;
                    cmd.Parameters.Add("@aantalBesmettingen", MySqlDbType.Int32).Value = uitbraak.aantalBesmettingen;
                    cmd.Parameters.Add("@aantalGeregistreerdeBesmettingen", MySqlDbType.Int32).Value = uitbraak.aantalGeregistreerdeBesmettingen;
                    cmd.Parameters.Add("@aantalSterfgevallen", MySqlDbType.Int32).Value = uitbraak.aantalSterfgevalen;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }

                this.CloseConnection();
            }
        }

        public void UitbraakAanpassenInDatabase(DalUitbraak uitbraak, DalVirus virus)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@virus", MySqlDbType.String).Value = virus.naam;
                    cmd.Parameters.Add("@land", MySqlDbType.String).Value = uitbraak.land.naam;
                    cmd.Parameters.Add("@aantalBesmettingen", MySqlDbType.Int32).Value = uitbraak.aantalBesmettingen;
                    cmd.Parameters.Add("@aantalGeregistreerdeBesmettingen", MySqlDbType.Int32).Value = uitbraak.aantalGeregistreerdeBesmettingen;
                    cmd.Parameters.Add("@aantalSterfgevallen", MySqlDbType.Int32).Value = uitbraak.aantalSterfgevalen;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }
        public List<DalUitbraak> VraagAlleUitbrakenOpVanVirusUitDatabase(DalVirus virus)
        {
            string query = "";
            List<DalUitbraak> resultaat = new List<DalUitbraak>();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@virus", MySqlDbType.String).Value = virus.naam;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DalUitbraak uitbraak = new DalUitbraak();
                        DalLand land = new DalLand();
                        land.naam = dataReader.GetString(0);
                        uitbraak.land = land;
                        uitbraak.aantalBesmettingen = dataReader.GetInt32(1);
                        uitbraak.aantalGeregistreerdeBesmettingen = dataReader.GetInt32(2);
                        uitbraak.aantalSterfgevalen = dataReader.GetInt32(3);
                        resultaat.Add(uitbraak);
                    }
                    dataReader.Close();
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
