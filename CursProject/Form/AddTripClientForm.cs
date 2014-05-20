using System;
using System.Collections.Generic;
using System.Linq;
using CursProject.Classes;
using CursProject.Doc;
using CursProject.Helpers;

namespace CursProject.Form
{
    public partial class AddTripClientForm : ValidateForm
    {
        private readonly int Id;
        private readonly int TripId;
        private readonly TourDbDataContext db = DataBase.Context;

        public AddTripClientForm(int id = 0, int tripId = 0)
        {
            InitializeComponent();
            Id = id;

            TripId = tripId;
            if (Tc != null)
            {
                TripId = Tc.TripId;
            }

            FillClients();
            FillTrip();

            if (Id > 0)
            {
                SetToControls();
                Text = "Изменить " + Text;
                btnAdd.Text = "Изменить";
            }
            else
            {
                Id = 0;
                Text = "Добавить " + Text;
            }
        }

        public TripClient Tc
        {
            get { return db.TripClients.SingleOrDefault(tc => (tc.Id == Id)); }
        }

        private List<Client> Clients
        {
            get { return db.Clients.ToList(); }
        }

        private Trip CurrentTrip
        {
            get { return db.Trips.SingleOrDefault(t => (t.Id == TripId)) ?? new Trip(); }
        }

        private Client CurrentClient
        {
            get
            {
                int index = ddlClients.SelectedIndex;
                if ((index >= 0) && (index < Clients.Count))
                {
                    return Clients[index];
                }

                return null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                TripClient tc = GetFromControls();
                if (Id <= 0)
                {
                    tc.SaleDate = DateTime.Now;
                    tc.LeftPrice = tc.TotalPrice;
                    db.TripClients.InsertOnSubmit(tc);
                }

                db.SubmitChanges();

                WordGenerator.MakeContract(tc);
                PdfGenerator.MakeInvoice(tc);
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            ddlClients.SelectedIndex = IndexByClient(Tc.Client);
            txtFinalPrice.Text = Tc.TotalPrice.ToString();
        }

        // Получаем объект из формы
        private TripClient GetFromControls()
        {
            TripClient tripClient = db.TripClients.SingleOrDefault(t => (t.Id == Id)) ?? new TripClient();

            tripClient.Client = CurrentClient;
            tripClient.Trip = CurrentTrip;
            tripClient.Fio = CurrentClient.Fio;
            tripClient.TotalPrice = int.Parse(txtFinalPrice.Text);

            return tripClient;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtFio, false);
            isValid &= ValidateControl(txtFinalPrice, true);

            return isValid;
        }

        private int IndexByClient(Client client)
        {
            return client != null ? Clients.FindIndex(c => c.Id == client.Id) : 0;
        }

        private void FillClients()
        {
            ddlClients.Items.Clear();
            ddlClients.Items.AddRange(Clients.ToArray());
            if (ddlClients.Items.Count > 0)
            {
                ddlClients.SelectedIndex = 0;
            }
        }

        private void FillTrip()
        {
            txtTour.Text = CurrentTrip.Tour.ToString();
            txtMeal.Text = CurrentTrip.Meal.ToString();
            txtTransport.Text = CurrentTrip.Transport.ToString();
            txtHotel.Text = CurrentTrip.Hotel.ToString();
            txtDateDeparture.Text = CurrentTrip.DateDeparture.ToString();
            txtDateArival.Text = CurrentTrip.DateArival.ToString();
            txtNights.Text = CurrentTrip.Nights.ToString();
            txtMealPrice.Text = CurrentTrip.MealPrice.ToString();
            txtTransportPrice.Text = CurrentTrip.TransportPrice.ToString();
            txtHotelPrice.Text = CurrentTrip.HotelPrice.ToString();
            txtTripPrice.Text = CurrentTrip.TourPrice.ToString();
            txtTotalPrice.Text = CurrentTrip.TotalPrice.ToString();
        }

        private void ddlClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentClient == null)
            {
                return;
            }

            txtFio.Text = ddlClients.Text;
            txtDiscount.Text = CurrentClient.Discount.ToString();
            txtFinalPrice.Text = ((CurrentTrip.TotalPrice * (100 - CurrentClient.Discount)) / 100).ToString();
        }
    }
}