using System;
using System.Linq;

namespace CursProject.Classes
{
    public partial class Settings
    {
        private static readonly TourDbDataContext Db = new TourDbDataContext(Properties.Settings.Default.ConnectionString);
        public static string Host
        {
            get { return GetValue("Host"); }
            set { SetValue("Host", value); }
        }

        public static string Login
        {
            get { return GetValue("Login"); }
            set { SetValue("Login", value); }
        }

        public static string Password
        {
            get { return GetValue("Password"); }
            set { SetValue("Password", value); }
        }

        public static int Port
        {
            get
            {
                int value = 0;
                Int32.TryParse(GetValue("Port"), out value);
                return value;
            }
            set { SetValue("Port", value.ToString()); }
        }


        
        public static string DirectorsFio
        {
            get { return GetValue("DirectorsFio"); }
            set { SetValue("DirectorsFio", value); }
        }

        public static string Phone
        {
            get { return GetValue("Phone"); }
            set { SetValue("Phone", value); }
        }

        public static string FirmName
        {
            get { return GetValue("FirmName"); }
            set { SetValue("FirmName", value); }
        }

        public static string AccountNumber
        {
            get { return GetValue("AccountNumber"); }
            set { SetValue("AccountNumber", value); }
        }

        public static string Address
        {
            get { return GetValue("Address"); }
            set { SetValue("Address", value); }
        }

        private static string GetValue(string name)
        {
            var setting = Db.Settings.SingleOrDefault(p => p.Name == name);
            return (setting == null) ? "" : setting.Value;
        }

        private static void SetValue(string name, string value)
        {
            var setting = Db.Settings.SingleOrDefault(p => p.Name == name);

            if (setting == null)
            {
                setting = new Settings { Name = name, Value = value };
                Db.Settings.InsertOnSubmit(setting);
            }
            else
            {
                setting.Value = value;
            }

            Db.SubmitChanges();
        }

    }
}
