using StokEkstresi.Models.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StokEkstresi.Models.EntityLayer
{
    public class DataAccess
    {
        private static DataAccessLayer dal;
        protected static DataAccessLayer DAL
        {
            get
            {
                if (dal == null)
                    dal = new DataAccessLayer();
                return dal;
            }
        }
    }
}