using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CursProject.Properties;

namespace CursProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var db = new TourDbDataContext(Settings.Default.ConnectionString);
            db.Countries.InsertOnSubmit(new Country { Name = "123" });
            db.Countries.InsertOnSubmit(new Country { Name = "123" });
            db.Countries.InsertOnSubmit(new Country { Name = "123" });
            db.Countries.InsertOnSubmit(new Country { Name = "123" });
            db.Countries.InsertOnSubmit(new Country { Name = "123" });
            db.SubmitChanges();

            MessageBox.Show(db.Countries.Count().ToString());
        }
    }
}
