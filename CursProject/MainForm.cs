using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CursProject.Form;
using CursProject.Helpers;
using CursProject.Properties;

namespace CursProject
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();

            TourSortColumn = 6;
            TourSortOrder = SortOrder.Descending;

            RefreshAllGrids();
        }

        /*
         *********************************** 
         **********   Refresher   **********
         *********************************** 
         */

        private void RefreshAllGrids()
        {
            RefreshTours();
            RefreshClients();
            RefreshDiscounts();
            RefreshHotels();
            RefreshTransports();
            RefreshMeals();
            RefreshExcursions();
            RefreshTrips();
        }

        private void RefreshTours()
        {
            var db = new TourDbDataContext();
            List<Tour> list = db.Tours.ToList();
            tourGrid.DataSource = list;
        }

        private void RefreshExcursions()
        {
            var db = new TourDbDataContext();
            List<Excursion> list = db.Excursions.ToList();
            excursionGrid.DataSource = list;
        }

        private void RefreshMeals()
        {
            var db = new TourDbDataContext();
            List<Meal> list = db.Meals.ToList();
            mealGrid.DataSource = list;
        }

        private void RefreshTransports()
        {
            var db = new TourDbDataContext();
            List<Transport> list = db.Transports.ToList();
            transportGrid.DataSource = list;
        }

        private void RefreshHotels()
        {
            var db = new TourDbDataContext();
            List<Hotel> list = db.Hotels.ToList();
            hotelGrid.DataSource = list;
        }

        private void RefreshDiscounts()
        {
            var db = new TourDbDataContext();
            List<Discount> list = db.Discounts.ToList();
            discountGrid.DataSource = list;
        }

        private void RefreshClients()
        {
            var db = new TourDbDataContext();
            List<Client> list = db.Clients.ToList();
            clientGrid.DataSource = list;
        }

        private void RefreshTrips()
        {
            var db = new TourDbDataContext();
            List<Trip> list = db.Trips.ToList();
            tripGrid.DataSource = list;
        }

        /*
         **********   Tours   **********
         */

        private void tourGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(tourGrid.Rows[e.RowIndex], 0);
            EditTour(id);
        }

        private void btnAddTour_Click(object sender, EventArgs e)
        {
            var form = new AddTourForm();
            form.ShowDialog();
            RefreshTours();
        }

        private void btnEditTour_Click(object sender, EventArgs e)
        {
            if (tourGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(tourGrid.SelectedRows[0], 0);
            EditTour(id);
        }

        private void EditTour(int id)
        {
            var form = new AddTourForm(id);
            form.ShowDialog();
            RefreshTours();
        }

        private void btnDeleteTour_Click(object sender, EventArgs e)
        {
            if (tourGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(tourGrid.SelectedRows[0], 0);

            var db = new TourDbDataContext(Settings.Default.ConnectionString);
            db.Tours.DeleteAllOnSubmit(from t in db.Tours where t.Id == id select t);

            RefreshTours();
        }

        /*
         **********   Excursions   **********
         */

        private void excursionGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(excursionGrid.Rows[e.RowIndex], 0);
            EditExcursion(id);
        }

        private void btnAddExcursion_Click(object sender, EventArgs e)
        {
            var form = new AddExcursionForm();
            form.ShowDialog();
            RefreshExcursions();
        }

        private void btnEditExcursion_Click(object sender, EventArgs e)
        {
            if (excursionGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(excursionGrid.SelectedRows[0], 0);
            EditExcursion(id);
        }

        private void EditExcursion(int id)
        {
            var form = new AddExcursionForm(id);
            form.ShowDialog();
            RefreshExcursions();
        }

        private void btnDeleteExcursion_Click(object sender, EventArgs e)
        {
            if (excursionGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(excursionGrid.SelectedRows[0], 0);

            var db = new TourDbDataContext(Settings.Default.ConnectionString);
            db.Excursions.DeleteAllOnSubmit(from t in db.Excursions where t.Id == id select t);

            RefreshExcursions();
        }


        /*
         **********   Meals   **********
         */

        private void mealGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(mealGrid.Rows[e.RowIndex], 0);
            EditMeal(id);
        }

        private void btnAddMeal_Click(object sender, EventArgs e)
        {
            var form = new AddMealForm();
            form.ShowDialog();
            RefreshMeals();
        }

        private void btnEditMeal_Click(object sender, EventArgs e)
        {
            if (mealGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(mealGrid.SelectedRows[0], 0);
            EditMeal(id);
        }

        private void EditMeal(int id)
        {
            var form = new AddMealForm(id);
            form.ShowDialog();
            RefreshMeals();
        }

        private void btnDeleteMeal_Click(object sender, EventArgs e)
        {
            if (mealGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(mealGrid.SelectedRows[0], 0);

            var db = new TourDbDataContext(Settings.Default.ConnectionString);
            db.Meals.DeleteAllOnSubmit(from t in db.Meals where t.Id == id select t);

            RefreshMeals();
        }


        /*
         **********   Transports   **********
         */

        private void transportGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(transportGrid.Rows[e.RowIndex], 0);
            EditTransport(id);
        }

        private void btnAddTransport_Click(object sender, EventArgs e)
        {
            var form = new AddTransportForm();
            form.ShowDialog();
            RefreshTransports();
        }

        private void btnEditTransport_Click(object sender, EventArgs e)
        {
            if (transportGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(transportGrid.SelectedRows[0], 0);
            EditTransport(id);
        }

        private void EditTransport(int id)
        {
            var form = new AddTransportForm(id);
            form.ShowDialog();
            RefreshTransports();
        }

        private void btnDeleteTransport_Click(object sender, EventArgs e)
        {
            if (transportGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(transportGrid.SelectedRows[0], 0);

            var db = new TourDbDataContext(Settings.Default.ConnectionString);
            db.Transports.DeleteAllOnSubmit(from t in db.Transports where t.Id == id select t);

            RefreshTransports();
        }


        /*
         **********   Hotels   **********
         */

        private void hotelGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(hotelGrid.Rows[e.RowIndex], 0);
            EditHotel(id);
        }

        private void btnAddHotel_Click(object sender, EventArgs e)
        {
            var form = new AddHotelForm();
            form.ShowDialog();
            RefreshHotels();
        }

        private void btnEditHotel_Click(object sender, EventArgs e)
        {
            if (hotelGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(hotelGrid.SelectedRows[0], 0);
            EditHotel(id);
        }

        private void EditHotel(int id)
        {
            var form = new AddHotelForm(id);
            form.ShowDialog();
            RefreshHotels();
        }

        private void btnDeleteHotel_Click(object sender, EventArgs e)
        {
            if (hotelGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(hotelGrid.SelectedRows[0], 0);

            var db = new TourDbDataContext(Settings.Default.ConnectionString);
            db.Hotels.DeleteAllOnSubmit(from t in db.Hotels where t.Id == id select t);

            RefreshHotels();
        }


        /*
         **********   Discounts   **********
         */

        private void discountGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(discountGrid.Rows[e.RowIndex], 0);
            EditDiscount(id);
        }

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            var form = new AddDiscountForm();
            form.ShowDialog();
            RefreshDiscounts();
        }

        private void btnEditDiscount_Click(object sender, EventArgs e)
        {
            if (discountGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(discountGrid.SelectedRows[0], 0);
            EditDiscount(id);
        }

        private void EditDiscount(int id)
        {
            var form = new AddDiscountForm(id);
            form.ShowDialog();
            RefreshDiscounts();
        }

        private void btnDeleteDiscount_Click(object sender, EventArgs e)
        {
            if (discountGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(discountGrid.SelectedRows[0], 0);

            var db = new TourDbDataContext(Settings.Default.ConnectionString);
            db.Discounts.DeleteAllOnSubmit(from t in db.Discounts where t.Id == id select t);

            RefreshDiscounts();
        }        

        /*
         **********   Clients   **********
         */

        private void clientGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(clientGrid.Rows[e.RowIndex], 0);
            EditClient(id);
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            var form = new AddClientForm();
            form.ShowDialog();
            RefreshClients();
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (clientGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(clientGrid.SelectedRows[0], 0);
            EditClient(id);
        }

        private void EditClient(int id)
        {
            var form = new AddClientForm(id);
            form.ShowDialog();
            RefreshClients();
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (clientGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(clientGrid.SelectedRows[0], 0);

            var db = new TourDbDataContext(Settings.Default.ConnectionString);
            db.Clients.DeleteAllOnSubmit(from t in db.Clients where t.Id == id select t);

            RefreshClients();
        }



        /*
         **********   Trips   **********
         */

        private void tripGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(tripGrid.Rows[e.RowIndex], 0);
            EditTrip(id);
        }

        private void btnAddTrip_Click(object sender, EventArgs e)
        {
            var form = new AddTripForm();
            form.ShowDialog();
            RefreshTrips();
        }

        private void btnEditTrip_Click(object sender, EventArgs e)
        {
            if (tripGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(tripGrid.SelectedRows[0], 0);
            EditTrip(id);
        }

        private void EditTrip(int id)
        {
            var form = new AddTripForm(id);
            form.ShowDialog();
            RefreshTrips();
        }

        private void btnDeleteTrip_Click(object sender, EventArgs e)
        {
            if (tripGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(tripGrid.SelectedRows[0], 0);

            var db = new TourDbDataContext(Settings.Default.ConnectionString);
            db.Trips.DeleteAllOnSubmit(from t in db.Trips where t.Id == id select t);

            RefreshTrips();
        }
    }
}