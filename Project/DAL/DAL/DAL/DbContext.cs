using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Logic.DAL_Interfaces;

namespace DAL
{
    public class DbContext: IDbContext
    {
        const string connectionString = "Server = studmysql01.fhict.local; Uid=dbi417025;Database=dbi417025;Pwd=D0tDashDream";
        protected MySqlConnection connection = new MySqlConnection(connectionString);
        public bool OpenConnection()
        {
            return _OpenConnection();
        }
        protected bool _OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch(MySqlException exception)
            {
                //Twee veel voorkomende uitzonderingen zijn:
                //exception 0: Het niet kunnen verbinden met de server en
                //exception 1045: Een foutieve combinatie van gebruikersnaam en wachtwoord

                return false;
                //komtie hier ooit bij????
                throw new Exception(exception.ToString());

                
            }
            return true;
    
        }
        
        public bool CloseConnection()
        {
            return _CloseConnection();
        }

        protected bool _CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch(MySqlException exception)
            {
                //TODO exception afhandeling
                return false;
            }
            return true;
        }
    }
}
