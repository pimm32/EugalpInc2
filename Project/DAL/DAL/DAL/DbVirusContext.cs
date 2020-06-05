using DAL.DalModels;
using Logic;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Logic.DAL_Interfaces;
using Logic.DAL_Interfaces.Dto_models;

namespace DAL
{
    public class DbVirusContext : DbContext, IDbVirusContext
    {
        public void VirusOpslaanInDatabase(VirusDto virus)
        {
            string query = "_VirusOpslaan";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.String).Value = virus.naam;
                    cmd.Parameters.Add("@besmettingsgraad", MySqlDbType.Decimal).Value = virus.besmettingsgraad;
                    cmd.Parameters.Add("@herkenbaarheidsgraad", MySqlDbType.Decimal).Value = virus.herkenbaarheidsgraad;
                    cmd.Parameters.Add("@sterftegraad", MySqlDbType.Decimal).Value = virus.sterftegraad;
                    cmd.Parameters.Add("@aantalDagenSindsEersteUitbraak", MySqlDbType.Int32).Value = virus.aantalDagenSindsEersteUitbraak;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }

                this.CloseConnection();
            }
        }

        public void VirusAanpassenInDatabase(VirusDto virus)
        {
            string query = "_VirusAanpassen";
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.String).Value = virus.naam;
                    cmd.Parameters.Add("@besmettingsgraad", MySqlDbType.Decimal).Value = virus.besmettingsgraad;
                    cmd.Parameters.Add("@herkenbaarheidsgraad", MySqlDbType.Decimal).Value = virus.herkenbaarheidsgraad;
                    cmd.Parameters.Add("@sterftegraad", MySqlDbType.Decimal).Value = virus.sterftegraad;
                    cmd.Parameters.Add("@aantalDagenSindsUitbraak", MySqlDbType.Int32).Value = virus.aantalDagenSindsEersteUitbraak;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                }
                this.CloseConnection();
            }
        }

        public VirusDto VraagVirusOpInDatabase(string naam)
        {
            string query = "_VirusOpvragenNaarNaam";
            VirusDto resultaat = null;
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@naam", MySqlDbType.String).Value = naam;
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        resultaat = new VirusDto(dataReader.GetString(0), dataReader.GetDecimal(1), dataReader.GetDecimal(2), dataReader.GetDecimal(3), dataReader.GetInt32(4));
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

        //Deze functionaliteit is geen must en is voor nu even weggecommend
        //public int VraagHighscoreOpUitDatabase()
        //{
        //    string query = "";
        //    int count = -1;
        //    if (this.OpenConnection())
        //    {
        //        try
        //        {
        //            MySqlCommand cmd = new MySqlCommand(query, connection);
        //            count = (int)cmd.ExecuteScalar();

        //        }
        //        catch(Exception exception)
        //        {
        //            throw new Exception(exception.ToString());
        //        }
        //        this.CloseConnection();
        //    }
        //    return count;
        //}
    }
}
