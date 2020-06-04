using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class DbMaatregelContext: DbContext
    {
        public void MaatregelOpslaanInDatabase(Maatregel maatregel)
        {
            string query = "MaatregelToevoegen";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.VarChar).Value = maatregel.naam;
                    cmd.Parameters.Add("@straatBezettingFactor", MySqlDbType.Decimal).Value = maatregel.straatbezettingFactor;
                    cmd.Parameters.Add("@doktersBezoekenFactor", MySqlDbType.Decimal).Value = maatregel.doktersbezoekenFactor;
                    cmd.Parameters.Add("@besmettingenGrens", MySqlDbType.Decimal).Value = maatregel.besmettingenGrens;
                    cmd.Parameters.Add("@geregistreerdeBesmettingenGrens", MySqlDbType.Decimal).Value = maatregel.geregistreerdeBesmettingenGrens;
                    cmd.Parameters.Add("@sterfteGrens", MySqlDbType.Decimal).Value = maatregel.sterfteGrens;
                    cmd.Parameters.Add("@ernst", MySqlDbType.Int32).Value = maatregel.ernst;
                    cmd.Parameters.Add("@categorie", MySqlDbType.String).Value = maatregel.categorie.naam;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = maatregel.niveau.naam;
                    cmd.ExecuteNonQuery();
                }
                catch(Exception exception)
                {
                    throw new Exception(exception.ToString());
                }

                this.CloseConnection();
            }
        }

        public void MaatregelAanpassenInDatabase(Maatregel maatregel)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.VarChar).Value = maatregel.naam;
                    cmd.Parameters.Add("@straatBezettingFactor", MySqlDbType.Decimal).Value = maatregel.straatbezettingFactor;
                    cmd.Parameters.Add("@doktersBezoekenFactor", MySqlDbType.Decimal).Value = maatregel.doktersbezoekenFactor;
                    cmd.Parameters.Add("@besmettingenGrens", MySqlDbType.Decimal).Value = maatregel.besmettingenGrens;
                    cmd.Parameters.Add("@geregistreerdeBesmettingenGrens", MySqlDbType.Decimal).Value = maatregel.geregistreerdeBesmettingenGrens;
                    cmd.Parameters.Add("@sterfteGrens", MySqlDbType.Decimal).Value = maatregel.sterfteGrens;
                    cmd.Parameters.Add("@ernst", MySqlDbType.Int32).Value = maatregel.ernst;
                    cmd.Parameters.Add("@categorie", MySqlDbType.String).Value = maatregel.categorie.naam;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = maatregel.niveau.naam;
                    cmd.ExecuteNonQuery();
                }
                catch(Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }

        public void MaatregelVerwijderenUitDatabase(Maatregel maatregel)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.String).Value = maatregel.naam;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = maatregel.niveau.naam;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }

        public void MaatregelActiefInLandIntDatabaseOpslaan(Maatregel maatregel, Land land)
        {

            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@maatregel", MySqlDbType.String).Value = maatregel.naam;
                    cmd.Parameters.Add("@land", MySqlDbType.String).Value = land.naam;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }
        public List<Maatregel> VraagAlleMaatregelsOpVanNiveauUitDatabase(Niveau niveau)
        {
            string query = "";
            List<Maatregel> resultaat = new List<Maatregel>();
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
                        Maatregel maatregel = new Maatregel(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetInt32(3), dataReader.GetDecimal(4), dataReader.GetDecimal(5), dataReader.GetDecimal(6));
                        resultaat.Add(maatregel);
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
