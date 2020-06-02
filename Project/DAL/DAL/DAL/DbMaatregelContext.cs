using DAL.DalModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class DbMaatregelContext: DbContext
    {
        public void MaatregelOpslaanInDatabase()
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue();
                    cmd.ExecuteNonQuery();
                }
                catch(Exception exception)
                {
                    throw new Exception(exception.ToString());
                }

                this.CloseConnection();
            }
        }

        public void MaatregelAanpassenInDatabase()
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue();
                    cmd.ExecuteNonQuery();
                }
                catch(Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }

        public void MaatregelVerwijderenUitDatabase()
        {
            string query = "";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }
        public List<DalMaatregel> VraagAlleMaatregelsOpVanNiveauUitDatabase()
        {
            string query = "";
            List<DalMaatregel> resultaat = new List<DalMaatregel>();
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DalMaatregel maatregel = new DalMaatregel();
                        maatregel.naam = dataReader.GetString(0);
                        maatregel.straatbezettingFactor = dataReader.GetDecimal(1);
                        maatregel.doktersbezoekenFactor = dataReader.GetDecimal(2);
                        maatregel.ernst = dataReader.GetInt32(3);
                        maatregel.besmettingenGrens = dataReader.GetDecimal(4);
                        maatregel.geregistreerdeBesmettingenGrens = dataReader.GetDecimal(5);
                        maatregel.sterfteGrens = dataReader.GetDecimal(6);
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
