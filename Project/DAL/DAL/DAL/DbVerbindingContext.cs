using DAL.DalModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DbVerbindingContext: DbContext
    {
        public void VerbindingOpslaanInDatabase(DalVerbinding verbinding)
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

        public void VerbindingAanpassenInDatabase(DalVerbinding verbinding)
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

        public void VerbindingVerwijderenUitDatabase(DalVerbinding verbinding)
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

        public List<DalVerbinding> VraagInkomendeVerbindingenOpVanLand(DalLand land)
        {
            string query = "";
            List<DalVerbinding> resultaat = new List<DalVerbinding>();
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
                        DalVerbinding verbinding = new DalVerbinding();
                        DalLand landUit = new DalLand();
                        landUit.naam = dataReader.GetString(0);
                        verbinding.aankomstLand = landIn;
                        verbinding.vertrekLand = landUit;
                        verbinding.verkeer = dataReader.GetInt32(1);
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

        public List<DalVerbinding> VraagUitgaandeVerbindingenOpVanLand(DalLand land)
        {
            string query = "";
            List<DalVerbinding> resultaat = new List<DalVerbinding>();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@uitgaandLand", MySqlDbType.String).Value = land.naam;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    DalLand landIn = new DalLand();
                    landIn.naam = land.naam;
                    while (dataReader.Read())
                    {
                        DalVerbinding verbinding = new DalVerbinding();
                        DalLand landUit = new DalLand();
                        landUit.naam = dataReader.GetString(0);
                        verbinding.aankomstLand = landIn;
                        verbinding.vertrekLand = landUit;
                        verbinding.verkeer = dataReader.GetInt32(1);
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
