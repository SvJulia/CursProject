using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using CursProject.Classes;
using CursProject.Form;
using CursProject.Helpers;
using CursProject.Properties;
using CursProject.Doc;
using CursProject.Types;
using Settings = CursProject.Classes.Settings;

namespace CursProject
{
    public partial class ShowClient : System.Windows.Forms.Form
    {
        private TourDbDataContext db = DataBase.Context;
        private int Id;

        public ShowClient(int id)
        {
            InitializeComponent();
            Id = id;
            RefreshAllGrids();
        }

        public int PriceTo { get; set; }
        public int PriceFrom { get; set; }

        /*
         *********************************** 
         **********   Refresher   **********
         *********************************** 
         */

        private void RefreshAllGrids()
        {
            RefreshTripClients();
        }

        private void RefreshTripClients()
        {
            tripClientGrid.DataSource = db.TripClients.Where(p => p.ClientId == Id).Select(p => p.ToGrid()).ToList();

            GridHelper.SetHeaders(tripClientGrid, new[] { "ID", "Покупатель", "Тур", "Цена", "Дата продажи", "Оплачено" });
            GridHelper.SetInvisible(tripClientGrid, new[] { 0 });
        }

        private void btnEditTripClient_Click(object sender, EventArgs e)
        {
            if (tripClientGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(tripClientGrid.SelectedRows[0], 0);
            EditTripClient(id);
        }

        private void EditTripClient(int id)
        {
            var form = new AddTripClientForm(id);
            form.ShowDialog();
            RefreshTripClients();
        }

        private void btnDeleteTripClient_Click(object sender, EventArgs e)
        {
            if (tripClientGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(tripClientGrid.SelectedRows[0], 0);

            db.TripClients.DeleteAllOnSubmit(from t in db.TripClients where t.Id == id select t);
            db.SubmitChanges();

            RefreshTripClients();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            if (tripClientGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(tripClientGrid.SelectedRows[0], 0);

            var tripClient = db.TripClients.SingleOrDefault(p => p.Id == id);

            if (tripClient != null)
            {
                tripClient.IsPaid = true;
                RefreshTripClients();
            }
        }
    }
}