﻿using CursProject.Classes;
using CursProject.Properties;

namespace CursProject
{
    internal static class DataBase
    {
        private static readonly TourDbDataContext Db = new TourDbDataContext(Properties.Settings.Default.ConnectionString);

        public static TourDbDataContext Context
        {
            get { return Db; }
        }
    }
}