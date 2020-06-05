using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Logic.DAL_Interfaces;
using Logic.Logic_Interfaces;

namespace DAL
{
    public class DbSymptoomContext: DbContext, IDbSymptoomContext
    {
        public Symptoom SymptoomSelecteren(string naam)
        {
            string query = "_SymptoomSelecteren";
            Symptoom resultaat;
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.String).Value = naam;
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            resultaat = new Symptoom(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3), dataReader.GetInt32(4), dataReader.GetInt32(5), dataReader.GetString(6), dataReader.GetString(7));
                            return resultaat;

                        }
                        dataReader.Close();
                    }
                }
                catch
                {
                    resultaat = null;
                }

            }
            return null;
        }
        public void SymptoomOpslaanInDatabase(Symptoom symptoom)
        {
            string query = "_SymptoomOpslaan";
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
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = symptoom.niveau;
                    cmd.Parameters.Add("@categorie", MySqlDbType.String).Value = symptoom.categorie;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }

                this.CloseConnection();
            }
        }

        public void SymptoomAanpassenInDatabase(Symptoom symptoom)
        {
            string query = "_SymptoomAanpassen";
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
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = symptoom.niveau;
                    cmd.Parameters.Add("@categorie", MySqlDbType.String).Value = symptoom.categorie;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }
        public void SymptoomVerwijderenUitDatabase(Symptoom symptoom)
        {
            string query = "_SymptoomVerwijderen";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.String).Value = symptoom.naam;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = symptoom.niveau;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }

        public void SymptoomAanVirusToevoegenInDatabase(Symptoom symptoom, Virus virus)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.String).Value = symptoom.naam;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = symptoom.niveau;
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
        public IEnumerable<Symptoom> VraagAlleSymptomenOp()
        {
            string query = "_AlleSymptomenOpvragen";
            List<Symptoom> resultaat = new List<Symptoom>();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Symptoom symptoom = new Symptoom(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3), dataReader.GetInt32(4), dataReader.GetInt32(5), dataReader.GetString(6), dataReader.GetString(7));
                        resultaat.Add(symptoom);
                    }
                    dataReader.Close();
                }
                catch
                {
                    resultaat = null;
                }
                
            }
            return resultaat;
        }

        public IEnumerable<Symptoom> VraagAlleSymptomenOpVanNiveau(Niveau niveau)
        {
            string query = "_AlleSymptomenOpvragenVanNiveau";
            List<Symptoom> resultaat = new List<Symptoom>();
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
                        Symptoom symptoom = new Symptoom(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3), dataReader.GetInt32(4), dataReader.GetInt32(5), dataReader.GetString(6), dataReader.GetString(7));
                        resultaat.Add(symptoom);
                    }
                    dataReader.Close();
                }
                catch
                {
                    resultaat = null;
                }

            }
            return resultaat;
        }

        //naar symptoomcollectie DB context?
        public IEnumerable<Symptoom> VraagAlleSymptomenOpVanCategorieVanNiveau(Niveau niveau, SymptoomCategorie categorie)
        {
            
            
            string query = "_AlleSymptomenOpvragenVanCategorieVanNiveau";
            List<Symptoom> resultaat = new List<Symptoom>();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = niveau.naam;
                    cmd.Parameters.Add("@categorie", MySqlDbType.String).Value = categorie.naam;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Symptoom symptoom = new Symptoom(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3), dataReader.GetInt32(4), dataReader.GetInt32(5), dataReader.GetString(6), dataReader.GetString(7));
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

        public IEnumerable<Symptoom> VraagAlleSymptomenOpVanVirus(Virus virus)
        {
            string query = "_AlleSymptomenOpvragenVanVirus";
            List<Symptoom> resultaat = new List<Symptoom>();
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
                        Symptoom symptoom = new Symptoom(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3), dataReader.GetInt32(4), dataReader.GetInt32(5), dataReader.GetString(6), dataReader.GetString(7));
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
