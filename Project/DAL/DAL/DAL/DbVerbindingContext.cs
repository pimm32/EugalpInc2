using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Logic.DAL_Interfaces;
using Logic.DAL_Interfaces.Dto_models;
using System.Data;

namespace DAL
{
    public class DbVerbindingContext : DbContext, IDbVerbindingContext
    {
        public void VerbindingOpslaanInDatabase(VerbindingDto verbinding)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@inkomendLand", MySqlDbType.String).Value = verbinding.aankomstLand;
                    cmd.Parameters.Add("@uitgaandLand", MySqlDbType.String).Value = verbinding.vertrekLand;
                    cmd.Parameters.Add("@verkeer", MySqlDbType.Int32).Value = verbinding.mensenVerkeer;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }

                this.CloseConnection();
            }
        }

        public void VerbindingAanpassenInDatabase(VerbindingDto verbinding)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@inkomendLand", MySqlDbType.String).Value = verbinding.aankomstLand;
                    cmd.Parameters.Add("@uitgaandLand", MySqlDbType.String).Value = verbinding.vertrekLand;
                    cmd.Parameters.Add("@verkeer", MySqlDbType.Int32).Value = verbinding.mensenVerkeer;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }

        public void VerbindingVerwijderenUitDatabase(VerbindingDto verbinding)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@inkomendLand", MySqlDbType.String).Value = verbinding.aankomstLand;
                    cmd.Parameters.Add("@uitgaandLand", MySqlDbType.String).Value = verbinding.vertrekLand;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }
    

        public IEnumerable<VerbindingDto> VerbindingenVanLandOpvragen(string land)
        {
            string query = "_AlleVerbindingenVanLand";
            List<VerbindingDto> resultaat = new List<VerbindingDto>();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@land", MySqlDbType.String).Value = land;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        VerbindingDto verbinding = new VerbindingDto(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetInt32(2));
                        resultaat.Add(verbinding);
                    }
                    dataReader.Close();
                }
                catch (Exception ex)
                {
                    resultaat = null;
                    throw new Exception(ex.Message);
                }
                this.CloseConnection();
            }
            return resultaat;
        }

        public IEnumerable<VerbindingDto> AlleVerbindingen()
        {
            string query = "_AlleVerbindingen";
            List<VerbindingDto> resultaat = new List<VerbindingDto>();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        VerbindingDto verbinding = new VerbindingDto(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetInt32(2));
                        resultaat.Add(verbinding);
                    }
                    dataReader.Close();
                }
                catch(Exception ex)
                {
                    resultaat = null;
                    throw new Exception(ex.Message);
                }
                this.CloseConnection();
            }
            return resultaat;
        }
    }
}
