using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DbVerbindingContext: DbContext
    {
        public void VerbindingOpslaanInDatabase(Verbinding verbinding)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@inkomendLand", MySqlDbType.String).Value = verbinding.aankomstLand.naam;
                    cmd.Parameters.Add("@uitgaandLand", MySqlDbType.String).Value = verbinding.vertrekLand.naam;
                    cmd.Parameters.Add("@verkeer", MySqlDbType.Int32).Value = verbinding.verkeer;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }

                this.CloseConnection();
            }
        }

        public void VerbindingAanpassenInDatabase(Verbinding verbinding)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@inkomendLand", MySqlDbType.String).Value = verbinding.aankomstLand.naam;
                    cmd.Parameters.Add("@uitgaandLand", MySqlDbType.String).Value = verbinding.vertrekLand.naam;
                    cmd.Parameters.Add("@verkeer", MySqlDbType.Int32).Value = verbinding.verkeer;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }

        public void VerbindingVerwijderenUitDatabase(Verbinding verbinding)
        {
                string query = "";
                if (this.OpenConnection())
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@inkomendLand", MySqlDbType.String).Value = verbinding.aankomstLand.naam;
                        cmd.Parameters.Add("@uitgaandLand", MySqlDbType.String).Value = verbinding.vertrekLand.naam;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(exception.ToString());
                    }
                    this.CloseConnection();
                }
            }

        public List<Verbinding> VraagInkomendeVerbindingenOpVanLand(Land land)
        {
            string query = "";
            List<Verbinding> resultaat = new List<Verbinding>();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    cmd.Parameters.Add("@inkomendLand", MySqlDbType.String).Value = land.naam;
                    DalLand landIn = new DalLand();
                    landIn.naam = land.naam;
                    while (dataReader.Read())
                    {
                        //Verbinding verbinding = new Verbinding();
                        //Land landUit = new Land();
                        //landUit.naam = dataReader.GetString(0);
                        //verbinding.aankomstLand = landIn;
                        //verbinding.vertrekLand = landUit;
                        //verbinding.verkeer = dataReader.GetInt32(1);
                        //resultaat.Add(verbinding);
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

        public List<Verbinding> VraagUitgaandeVerbindingenOpVanLand(Land land)
        {
            string query = "";
            List<Verbinding> resultaat = new List<Verbinding>();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@uitgaandLand", MySqlDbType.String).Value = land.naam;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    Land landIn = new Land();
                    landIn.naam = land.naam;
                    while (dataReader.Read())
                    {
                        Verbinding verbinding = new Verbinding();
                        Land landUit = new Land();
                        landUit.naam = dataReader.GetString(0);
                        verbinding.aankomstLand = landIn;
                        verbinding.vertrekLand = landUit;
                        verbinding.mensenVerkeer = dataReader.GetInt32(1);
                        resultaat.Add(verbinding);
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
