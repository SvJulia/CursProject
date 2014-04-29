﻿using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;
using CursProject.Classes;
using CursProject.Form;
using CursProject.Helpers;
using Tour = CursProject.Grids.GridTour;
using CursProject.Doc;

namespace CursProject
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private TourDbDataContext db = DataBase.Context;

        public MainForm()
        {
            InitializeComponent();

            RefreshAllGrids();
            LoadSettings();
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
            RefreshTours();
            RefreshClients();
            RefreshDiscounts();
            RefreshHotels();
            RefreshTransports();
            RefreshMeals();
            RefreshExcursions();
            RefreshTrips();
            RefreshTripClients();
        }

        private void RefreshTours()
        {
            tourGrid.DataSource = db.Tours.Select(p => p.ToGrid()).ToList();

            tourGrid.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            GridHelper.SetHeaders(tourGrid, new[] { "ID", "Название", "Название для клиентов", "Страна", "Город", "Экскурсии" });
            GridHelper.SetInvisible(tourGrid, new[] { 0 });
        }

        private void RefreshExcursions()
        {
            excursionGrid.DataSource = db.Excursions.Select(p => p.ToGrid()).ToList();

            GridHelper.SetHeaders(excursionGrid, new[] { "ID", "Название", "Описание", "Рейтинг" });
            GridHelper.SetInvisible(excursionGrid, new[] { 0 });
        }

        private void RefreshMeals()
        {
            mealGrid.DataSource = db.Meals.Select(p => p.ToGrid()).ToList();

            GridHelper.SetHeaders(mealGrid, new[] { "ID", "Название", "Тип" });
            GridHelper.SetInvisible(mealGrid, new[] { 0 });
        }

        private void RefreshTransports()
        {
            transportGrid.DataSource = db.Transports.Select(p => p.ToGrid()).ToList();

            GridHelper.SetHeaders(transportGrid, new[] { "ID", "Название", "Тип" });
            GridHelper.SetInvisible(transportGrid, new[] { 0 });
        }

        private void RefreshHotels()
        {
            hotelGrid.DataSource = db.Hotels.Select(p => p.ToGrid()).ToList();

            GridHelper.SetHeaders(hotelGrid, new[] { "ID", "Название", "Тип" });
            GridHelper.SetInvisible(hotelGrid, new[] { 0 });
        }

        private void RefreshDiscounts()
        {
            discountGrid.DataSource = db.Discounts.Select(p => p.ToGrid()).ToList();

            GridHelper.SetHeaders(discountGrid, new[] { "ID", "Потраченная сумма", "Размер скидки" });
            GridHelper.SetInvisible(discountGrid, new[] { 0 });
        }

        private void RefreshClients()
        {
            clientGrid.DataSource = db.Clients.Select(p => p.ToGrid()).ToList();

            GridHelper.SetHeaders(clientGrid,
                new[] { "ID", "Расчётный счёт", "ФИО", "Адрес", "Телефон", "Email", "Документ", "Скидка", "Сумма купленных туров" });
            GridHelper.SetInvisible(clientGrid, new[] { 0 });
        }

        private void RefreshTrips()
        {
            tripGrid.DataSource = Trips.Select(p => p.ToGrid()).ToList();

            GridHelper.SetHeaders(tripGrid, new[] { "ID", "Тур", "Дата отбытия", "Дата возвращения", "Кол-во ночей", "Кол-во туров", "Цена" });
            GridHelper.SetInvisible(tripGrid, new[] { 0 });
        }

        private IQueryable<Trip> Trips
        {
            get
            {
                var trips = db.Trips.Where(p => true);

                if ((PriceFrom != 0) || (PriceTo != 0))
                {
                    if ((PriceTo < PriceFrom) && (PriceFrom != 0) && (PriceTo != 0))
                    {
                        int temp = PriceFrom;
                        PriceFrom = PriceTo;
                        PriceTo = temp;
                    }

                    if (PriceFrom != 0)
                    {
                        trips = trips.Where(p => p.HotelPrice + p.MealPrice + p.TourPrice + p.TransportPrice >= PriceFrom);
                    }

                    if (PriceTo != 0)
                    {
                        trips = trips.Where(p => p.HotelPrice + p.MealPrice + p.TourPrice + p.TransportPrice <= PriceTo);
                    }
                }
                return trips;
            }
        }

        private void RefreshTripClients()
        {
            tripClientGrid.DataSource = db.TripClients.Select(p => p.ToGrid()).ToList();

            GridHelper.SetHeaders(tripClientGrid, new[] { "ID", "Покупатель", "Тур", "Цена" });
            GridHelper.SetInvisible(tripClientGrid, new[] { 0 });
        }

        /*
         **********   Tours   **********
         */

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

            db.Tours.DeleteAllOnSubmit(from t in db.Tours where t.Id == id select t);
            db.SubmitChanges();

            RefreshTours();
        }

        /*
         **********   Excursions   **********
         */

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

            db.Excursions.DeleteAllOnSubmit(from t in db.Excursions where t.Id == id select t);
            db.SubmitChanges();

            RefreshExcursions();
        }


        /*
         **********   Meals   **********
         */

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

            db.Meals.DeleteAllOnSubmit(from t in db.Meals where t.Id == id select t);
            db.SubmitChanges();

            RefreshMeals();
        }


        /*
         **********   Transports   **********
         */

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

            db.Transports.DeleteAllOnSubmit(from t in db.Transports where t.Id == id select t);
            db.SubmitChanges();

            RefreshTransports();
        }


        /*
         **********   Hotels   **********
         */

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

            db.Hotels.DeleteAllOnSubmit(from t in db.Hotels where t.Id == id select t);
            db.SubmitChanges();

            RefreshHotels();
        }


        /*
         **********   Discounts   **********
         */

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

            db.Discounts.DeleteAllOnSubmit(from t in db.Discounts where t.Id == id select t);
            db.SubmitChanges();

            RefreshDiscounts();
        }

        /*
         **********   Clients   **********
         */

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

            db.Clients.DeleteAllOnSubmit(from t in db.Clients where t.Id == id select t);
            db.SubmitChanges();

            RefreshClients();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            var fileName = PdfGenerator.MakeOffer(Trips.ToList());
            foreach (var client in db.Clients)
            { 
                MailSender.SendOffer(client, fileName);
            }

            MessageBox.Show("Рассылка завершена.", "Рассылка");
        }

        private void btnClientBank_Click(object sender, EventArgs e)
        {
            var fileName = "ClientBank.txt";

            var writer = new StreamWriter(fileName);
            foreach (var client in db.Clients)
            {
                writer.WriteLine(client.AccountNumber + " - " + client.TotaPurchases + ".00 руб");
            }

            writer.Close();
        }

        /*
         **********   Trips   **********
         */

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

            db.Trips.DeleteAllOnSubmit(from t in db.Trips where t.Id == id select t);
            db.SubmitChanges();

            RefreshTrips();
        }

        private void btnExportTrips_Click(object sender, EventArgs e)
        {
            CalcGenerator.ExportTrips(Trips.ToList());
        }

        private void btnFilterTrip_Click(object sender, EventArgs e)
        {
            int value = 0;
            int.TryParse(txtTripPriceFrom.Text, out value);
            PriceFrom = value;

            int.TryParse(txtTripPriceTo.Text, out value);
            PriceTo = value;
            RefreshTrips();
        }

        private void btnResetTrip_Click(object sender, EventArgs e)
        {
            txtTripPriceTo.Clear();
            txtTripPriceFrom.Clear();

            PriceFrom = 0;
            PriceTo = 0;
            RefreshTrips();
        }


        /*
         **********   TripClients   **********
         */

        private void btnAddTripClient_Click(object sender, EventArgs e)
        {
            if (tripGrid.SelectedRows.Count == 0)
            {
                return;
            }

            int id = GridHelper.GetIntFromRow(tripGrid.SelectedRows[0], 0);

            var form = new AddTripClientForm(0, id);
            form.ShowDialog();
            RefreshTripClients();
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



        private void btnReport_Click(object sender, EventArgs e)
        {
            ExcelGenerator.ExportTrips(db.TripClients.ToList());
        }


        /*
         **********   Settings   **********
         */

        private void LoadSettings()
        {
            txtHost.Text = Settings.Host;
            txtPort.Text = Settings.Port.ToString();
            txtLogin.Text = Settings.Login;
            txtPassword.Text = Settings.Password;
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            var port = 0;
            Int32.TryParse(txtPort.Text, out port);

            Settings.Host = txtHost.Text;
            Settings.Port = port;
            Settings.Login = txtLogin.Text;
            Settings.Password = txtPassword.Text;
        }
    }
}