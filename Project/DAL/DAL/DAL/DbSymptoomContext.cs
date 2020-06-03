using DAL.DalModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DbSymptoomContext: DbContext
    {
        public void SymptoomOpslaanInDatabase(DalSymptoom symptoom)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.String).Value = symptoom.naam;
                    cmd.Parameters.Add("@besmettingsgraadFactor", MySqlDbType.Decimal).Value = symptoom.besmettingsgraadFactor;
                    cmd.Parameters.Add("@herkenbaarheidsgraadFactor", MySqlDbType.Decimal).Value = symptoom.herkenbaarheidsgraadFactor;
                    cmd.Parameters.Add("@sterftegraadFactor", MySqlDbType.Decimal).Value = symptoom.sterftegraadFactor;
                    cmd.Parameters.Add("@ernst", MySqlDbType.Int32).Value = symptoom.ernst;
                    cmd.Parameters.Add("@prijs", MySqlDbType.Int32).Value = symptoom.prijs;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = symptoom.niveau.naam;
                    cmd.Parameters.Add("@categorie", MySqlDbType.String).Value = symptoom.categorie.naam;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }

                this.CloseConnection();
            }
        }

        public void SymptoomAanpassenInDatabase(DalSymptoom symptoom)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.String).Value = symptoom.naam;
                    cmd.Parameters.Add("@besmettingsgraadFactor", MySqlDbType.Decimal).Value = symptoom.besmettingsgraadFactor;
                    cmd.Parameters.Add("@herkenbaarheidsgraadFactor", MySqlDbType.Decimal).Value = symptoom.herkenbaarheidsgraadFactor;
                    cmd.Parameters.Add("@sterftegraadFactor", MySqlDbType.Decimal).Value = symptoom.sterftegraadFactor;
                    cmd.Parameters.Add("@ernst", MySqlDbType.Int32).Value = symptoom.ernst;
                    cmd.Parameters.Add("@prijs", MySqlDbType.Int32).Value = symptoom.prijs;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = symptoom.niveau.naam;
                    cmd.Parameters.Add("@categorie", MySqlDbType.String).Value = symptoom.categorie.naam;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }
        public void SymptoomVerwijderenUitDatabase(DalSymptoom symptoom)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.String).Value = symptoom.naam;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = symptoom.niveau.naam;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }

        public void SymptoomAanVirusToevoegenInDatabase(DalSymptoom symptoom, DalVirus virus)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.String).Value = symptoom.naam;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = symptoom.niveau.naam;
                    cmd.Parameters.Add("@virus", MySqlDbType.String).Value = virus.naam;
                    cmd.ExecuteNonQuery();
                }
                catch(Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }
        public List<DalSymptoom> VraagAlleSymptomenOpVanNiveau(DalNiveau niveau)
        {
            string query = "";
            List<DalSymptoom> resultaat = new List<DalSymptoom>();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = niveau.naam;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DalSymptoom symptoom = new DalSymptoom();
                        symptoom.naam = dataReader.GetString(0);
                        symptoom.besmettingsgraadFactor = dataReader.GetDecimal(1);
                        symptoom.herkenbaarheidsgraadFactor = dataReader.GetDecimal(2);
                        symptoom.sterftegraadFactor = dataReader.GetDecimal(3);
                        symptoom.ernst = dataReader.GetInt32(4);
                        symptoom.prijs = dataReader.GetInt32(5);
                        resultaat.Add(symptoom);
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

        public List<DalSymptoom> VraagAlleSymptomenOpVanVirus(DalVirus virus)
        {
            string query = "";
            List<DalSymptoom> resultaat = new List<DalSymptoom>();
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
                        DalSymptoom symptoom = new DalSymptoom();
                        symptoom.naam = dataReader.GetString(0);
                        symptoom.besmettingsgraadFactor = dataReader.GetDecimal(1);
                        symptoom.herkenbaarheidsgraadFactor = dataReader.GetDecimal(2);
                        symptoom.sterftegraadFactor = dataReader.GetDecimal(3);
                        symptoom.ernst = dataReader.GetInt32(4);
                        symptoom.prijs = dataReader.GetInt32(5);
                        resultaat.Add(symptoom);
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
