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
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ComboBoxItem(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public partial class MainForm : System.Windows.Forms.Form
    {
        private TourDbDataContext db = DataBase.Context;

        public MainForm()
        {
            InitializeComponent();

            RefreshAllGrids();
            LoadSettings();

            foreach (var country in Resources.Countries.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                var data = country.Split(';');
                ddlParseCountries.Items.Add(new ComboBoxItem(data[0], data[1]));
            }

            ddlParseCountries.SelectedIndex = 0;
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

            Process.Start(fileName);
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

        private void btnParse_Click(object sender, EventArgs e)
        {
            var item = (ComboBoxItem) ddlParseCountries.SelectedItem;

            var url =
                string.Format(
                              "http://exat.ru/touronline/result-v2.php?&departureId=64&lcc={0}&currencyId=3&maxGenDays=22&limit=20&client_id=3v960f5fd1efdf9fb80ea01fa2fff9bc1fa5b3dca1683c02aae293f64a656a3a133020a5ff7d0f6cdb&transportRequired=1&countryFilter=&placeGroupId[]={0}&placeItemId[]={0}&tourTypeId[]=1,2,4,8,32,64,256,512,1024,2048,4096&maxAmount=0&accommodation=1_0&lastDepartureId=1&holder=aHR0cCUzQS8vZXhhdC5ydS8=",
                    item.Value);

            var html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(GetHtml(url));

            var table = html.DocumentNode.Descendants("table").FirstOrDefault(t => t.Attributes.Contains("class") && t.Attributes["class"].Value.Contains("data"));

            if (table == null) return;

            foreach (var tr in table.ChildNodes[3].Descendants("tr"))
            {
                var countryName = item.Text;
                var cityName = tr.ChildNodes[1].ChildNodes[1].InnerText.Trim();
                var hotelName = tr.ChildNodes[3].ChildNodes[0].InnerText.Trim().Split(new [] {"&nbsp;"}, StringSplitOptions.RemoveEmptyEntries)[0];
                var mealType = tr.ChildNodes[7].InnerText.Trim();
                var date = tr.ChildNodes[9].InnerText.Trim();
                var nightName = tr.ChildNodes[11].InnerText.Trim();
                var priceName = tr.ChildNodes[15].ChildNodes[1].InnerText.Trim();


                var country = db.Countries.FirstOrDefault(p => p.Name == countryName);
                if (country == null)
                {
                    country = new Country { Name = countryName };
                    db.Countries.InsertOnSubmit(country);
                    db.SubmitChanges();
                }

                var city = db.Cities.FirstOrDefault(p => p.Name == cityName);
                if (city == null)
                {
                    city = new City { Name = cityName, Country = country };
                    db.Cities.InsertOnSubmit(city);
                    db.SubmitChanges();
                }

                var transport = db.Transports.FirstOrDefault(t => t.Name == "Самолёт");
                if (transport == null)
                {
                    transport = new Transport { Name = "Самолёт", Type = Types.TransportType.Air.ToString() };
                    db.Transports.InsertOnSubmit(transport);
                    db.SubmitChanges();
                }

                var meal = db.Meals.FirstOrDefault(t => t.Type == mealType);
                if (meal == null)
                {
                    var mt = MealType.No;
                    switch (mealType)
                    {
                        case "BB":
                            mt = MealType.BB;
                            break;
                        case "FB":
                            mt = MealType.FB;
                            break;
                        case "HB":
                            mt = MealType.HB;
                            break;
                    }

                    meal = new Meal { Name = mealType, Type = mt.ToString() };
                    db.Meals.InsertOnSubmit(meal);
                    db.SubmitChanges();
                }

                var hotel = db.Hotels.FirstOrDefault(h => h.Name == hotelName);
                if (hotel == null)
                {
                    hotel = new Hotel { Name = hotelName, Type = HotelType.Stars4.ToString() };
                    db.Hotels.InsertOnSubmit(hotel);
                    db.SubmitChanges();
                }

                var tour = db.Tours.FirstOrDefault(t => t.Name == hotelName && t.NameForClients == hotelName && t.City == city);
                if (tour == null)
                {
                    tour = new Tour { City = city, Name = hotelName, NameForClients = hotelName };
                    db.Tours.InsertOnSubmit(tour);
                    db.SubmitChanges();
                }

                int month = 0;
                int.TryParse(date.Split(".".ToCharArray(), StringSplitOptions.None)[1], out month);

                int day = 0;
                int.TryParse(date.Split(".".ToCharArray(), StringSplitOptions.None)[0], out day);

                int nigths = 0;
                int.TryParse(nightName.Split("/".ToCharArray(), StringSplitOptions.None)[1], out nigths);

                int tourPrice = 0;
                int.TryParse(priceName.Substring(0, priceName.Length - 2), out tourPrice);

                var dateDeparture = new DateTime(DateTime.Now.Year, month, day);

                var trip = new Trip
                {
                    Tour = tour,
                    DateDeparture = dateDeparture,
                    DateArival = dateDeparture.AddDays(nigths),
                    Transport = transport,
                    Meal = meal,
                    Hotel = hotel,
                    Amount = 1,
                    MealPrice = 0,
                    HotelPrice = 0,
                    TransportPrice = 0,
                    TourPrice = tourPrice
                };

                db.Trips.InsertOnSubmit(trip);
                db.SubmitChanges();
            }

            RefreshAllGrids();

            MessageBox.Show("Парсинг завершён", "Парсинг");
        }

        private string GetHtml(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var receiveStream = response.GetResponseStream();
                StreamReader readStream = response.CharacterSet == null ? 
                    new StreamReader(receiveStream) : 
                    new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                string data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();

                return data;
            }

            return "";
        }
    }
}