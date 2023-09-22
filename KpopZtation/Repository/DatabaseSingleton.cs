using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtation.Models;

namespace KpopZtation.Repository
{
    public class DatabaseSingleton
    {
        private static KzEntities db = null;

        private DatabaseSingleton()
        {

        }

        public static KzEntities GetInstance()
        {
            if (db == null)
            {
                db = new KzEntities();
            }
            return db;
        }
    }
}