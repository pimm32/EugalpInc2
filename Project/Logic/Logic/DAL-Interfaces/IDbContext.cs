using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DAL_Interfaces
{
    public interface IDbContext
    {
        public bool OpenConnection();
        public bool CloseConnection();

    }
}
