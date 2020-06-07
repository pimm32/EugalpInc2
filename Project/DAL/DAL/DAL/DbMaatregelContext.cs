using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Logic.DAL_Interfaces;
using Logic.DAL_Interfaces.Dto_models;
using System.ComponentModel;

namespace DAL
{
    public class DbMaatregelContext: DbContext, IDbMaatregelContext
    {
        public MaatregelDto MaatregelSelecteren(string naam, string niveau)
        {
            string query = "_MaatregelSelecteren";
            MaatregelDto md = new MaatregelDto();
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
                        md = new MaatregelDto(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetInt32(3), dataReader.GetDecimal(4), dataReader.GetDecimal(5), dataReader.GetDecimal(6), dataReader.GetString(7), dataReader.GetString(8)); ;
                        
                    }
                    dataReader.Close();
                }
                catch (Exception exception)
                {
                    md = null;
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
            return md;
        }
        public void MaatregelOpslaanInDatabase(MaatregelDto maatregel)
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
                    cmd.Parameters.Add("@categorie", MySqlDbType.String).Value = maatregel.categorie;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = maatregel.niveau;
                    cmd.ExecuteNonQuery();
                }
                catch(Exception exception)
                {
                    throw new Exception(exception.ToString());
                }

                this.CloseConnection();
            }
        }

        public void MaatregelAanpassenInDatabase(MaatregelDto maatregel)
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
                    cmd.Parameters.Add("@categorie", MySqlDbType.String).Value = maatregel.categorie;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = maatregel.niveau;
                    cmd.ExecuteNonQuery();
                }
                catch(Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }

        public void MaatregelVerwijderenUitDatabase(MaatregelDto maatregel)
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.String).Value = maatregel.naam;
                    cmd.Parameters.Add("@niveau", MySqlDbType.String).Value = maatregel.niveau;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }

        public void MaatregelActiefInLandIntDatabaseOpslaan(MaatregelDto maatregel, LandDto land)
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
        public IEnumerable<MaatregelDto> VraagAlleMaatregelsOp()
        {
            string query = "_AlleMaatregelsOpVragen";
            List<MaatregelDto> resultaat = new List<MaatregelDto>();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        MaatregelDto maatregel = new MaatregelDto(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetInt32(3), dataReader.GetDecimal(4), dataReader.GetDecimal(5), dataReader.GetDecimal(6), dataReader.GetString(7), dataReader.GetString(8));
                        resultaat.Add(maatregel);
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
        public IEnumerable<MaatregelDto> VraagAlleMaatregelsOpVanNiveauUitDatabase(string niveau)
        {
            string query = "";
            List<MaatregelDto> resultaat = new List<MaatregelDto>();
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
                        MaatregelDto maatregel = new MaatregelDto(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetInt32(3), dataReader.GetDecimal(4), dataReader.GetDecimal(5), dataReader.GetDecimal(6), dataReader.GetString(7), niveau);
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
