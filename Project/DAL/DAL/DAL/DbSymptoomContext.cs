using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DbSymptoomContext: DbContext
    {
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

        //naar symptoomcollectie DB context?
        public List<Symptoom> VraagAlleSymptomenOpVanCategorieVanNiveau(Niveau niveau, SymptoomCategorie categorie)
        {
            // beetje logica? foreach (categorie cat in DbSymptoomCategorie.VraagAlleCategorienOp)
            // foreach(Symptoom sym in cat.VraagAlleSymptomenVanCategorieOpVanNiveau(niveau){
            // resultaat.add(sym)))
            
            
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
                        Symptoom symptoom = new Symptoom(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3), dataReader.GetInt32(4), dataReader.GetInt32(5));
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

        public List<Symptoom> VraagAlleSymptomenOpVanVirus(Virus virus)
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
                        Symptoom symptoom = new Symptoom(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3), dataReader.GetInt32(4), dataReader.GetInt32(5));
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
