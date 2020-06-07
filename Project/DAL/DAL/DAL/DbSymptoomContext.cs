using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Logic.DAL_Interfaces;
using Logic.Logic_Interfaces;
using Logic.DAL_Interfaces.Dto_models;

namespace DAL
{
    public class DbSymptoomContext: DbContext, IDbSymptoomContext
    {
        public SymptoomDto SymptoomSelecteren(string naam, string niveau)
        {
            string query = "_SymptoomSelecteren";
            SymptoomDto resultaat = new SymptoomDto();

            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.String).Value = naam;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = niveau;
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            resultaat.naam = dataReader.GetString(0);
                            resultaat.besmettingsgraadFactor = (decimal)dataReader.GetValue(1);
                            resultaat.herkenbaarheidsgraadFactor = (decimal)dataReader.GetValue(2);
                            resultaat.sterftegraadFactor = (decimal)dataReader.GetValue(3);
                            resultaat.ernst = dataReader.GetInt32(4);
                            resultaat.prijs = dataReader.GetInt32(5);
                            resultaat.niveau = dataReader.GetString(6);
                            resultaat.categorie = dataReader.GetString(7);
                            break;

                        }
                        dataReader.Close();
                    }
                }
                catch
                {
                }
                this.CloseConnection();

            }
            return resultaat;
        }
        public void SymptoomOpslaanInDatabase(SymptoomDto symptoom)
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

        public void SymptoomAanpassenInDatabase(SymptoomDto symptoom)
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
        public void SymptoomVerwijderenUitDatabase(SymptoomDto symptoom)
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

        public void SymptoomAanVirusToevoegenInDatabase(SymptoomDto symptoom, VirusDto virus)
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
        public IEnumerable<SymptoomDto> VraagAlleSymptomenOp()
        {
            string query = "_AlleSymptomenOpvragen";
            List<SymptoomDto> resultaat = new List<SymptoomDto>();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        SymptoomDto symptoom = new SymptoomDto(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3), dataReader.GetInt32(4), dataReader.GetInt32(5), dataReader.GetString(6), dataReader.GetString(7));
                        resultaat.Add(symptoom);
                    }
                    dataReader.Close();
                }
                catch
                {
                    resultaat = null;
                }
                this.CloseConnection();
                
            }
            return resultaat;
        }

        public IEnumerable<SymptoomDto> VraagAlleSymptomenOpVanNiveau(string niveau)
        {
            string query = "_AlleSymptomenOpvragenVanNiveau";
            List<SymptoomDto> resultaat = new List<SymptoomDto>();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = niveau;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        SymptoomDto symptoom = new SymptoomDto(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3), dataReader.GetInt32(4), dataReader.GetInt32(5), dataReader.GetString(6), dataReader.GetString(7));
                        resultaat.Add(symptoom);
                    }
                    dataReader.Close();
                }
                catch
                {
                    resultaat = null;
                }
                this.CloseConnection();
            }
            return resultaat;
        }

        //naar symptoomcollectie DB context?
        public IEnumerable<SymptoomDto> VraagAlleSymptomenOpVanCategorieVanNiveau(string niveau, string categorie)
        {
            
            
            string query = "_AlleSymptomenOpvragenVanCategorieVanNiveau";
            List<SymptoomDto> resultaat = new List<SymptoomDto>();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = niveau;
                    cmd.Parameters.Add("@categorie", MySqlDbType.String).Value = categorie;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        SymptoomDto symptoom = new SymptoomDto(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3), dataReader.GetInt32(4), dataReader.GetInt32(5), dataReader.GetString(6), dataReader.GetString(7));
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

        public IEnumerable<SymptoomDto> VraagAlleSymptomenOpVanVirus(VirusDto virus)
        {
            string query = "_AlleSymptomenOpvragenVanVirus";
            List<SymptoomDto> resultaat = new List<SymptoomDto>();
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
                        SymptoomDto symptoom = new SymptoomDto(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3), dataReader.GetInt32(4), dataReader.GetInt32(5), dataReader.GetString(6), dataReader.GetString(7));
                        resultaat.Add(symptoom);
                    }
                    dataReader.Close();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
            return resultaat;
        }
    }
}
