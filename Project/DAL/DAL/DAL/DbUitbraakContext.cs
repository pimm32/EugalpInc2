using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Logic.DAL_Interfaces;
using Logic.DAL_Interfaces.Dto_models;

namespace DAL
{
    public class DbUitbraakContext: DbContext, IDbUitbraakContext
    {
        public void UitbraakOpslaanInDatabase(UitbraakDto uitbraak, VirusDto virus)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@virus", MySqlDbType.String).Value = virus.naam;
                    cmd.Parameters.Add("@land", MySqlDbType.String).Value = uitbraak.land;
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

        public void UitbraakAanpassenInDatabase(UitbraakDto uitbraak, VirusDto virus)
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
                    cmd.Parameters.Add("@land", MySqlDbType.String).Value = uitbraak.land;
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
        public IEnumerable<UitbraakDto> VraagAlleUitbrakenOpVanVirusUitDatabase(VirusDto virus)
        {
            string query = "";
            List<UitbraakDto> resultaat = new List<UitbraakDto>();
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
                        //    Uitbraak uitbraak = new Uitbraak();
                        //    Land land = new Land();
                        //    DbLandContext context = new DbLandContext();
                        //    land = context.
                        //    uitbraak.land = land;
                        //    uitbraak.aantalBesmettingen = dataReader.GetInt32(1);
                        //    uitbraak.aantalGeregistreerdeBesmettingen = dataReader.GetInt32(2);
                        //    uitbraak.aantalSterfgevalen = dataReader.GetInt32(3);
                        //    resultaat.Add(uitbraak);
                        return null;
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
