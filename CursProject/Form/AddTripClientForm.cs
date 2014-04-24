using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using CursProject.Classes;
using CursProject.Helpers;
using CursProject.Properties;

namespace CursProject.Form
{
    public partial class AddTripClientForm : ValidateForm
    {
        private readonly int Id;
        private readonly int TripId;
        private readonly TourDbDataContext db = new TourDbDataContext(Settings.Default.ConnectionString);

        public TripClient Tc
        {
            get
            {
                return (from tc in db.TripClients where (tc.Id == Id) select tc).SingleOrDefault<TripClient>() ?? null;
            }
        }

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
                Text = "�������� " + Text;
                btnAdd.Text = "��������";
            }
            else
            {
                Id = 0;
                Text = "�������� " + Text;
            }
        }

        private List<Client> Clients
        {
            get { return db.Clients.ToList(); }
        }

        private Trip CurrentTrip
        {
            get
            {
                return (from t in db.Trips where (t.Id == TripId) select t).SingleOrDefault<Trip>() ?? new Trip();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                TripClient tc = GetFromControls();
                if (Id <= 0)
                {
                    db.TripClients.InsertOnSubmit(tc);
                }

                db.SubmitChanges();

                WordHelper.MakeDogovor(tc);
                Close();
            }
        }

        // ���������� ������ � ��������
        private void SetToControls()
        {
            ddlClients.SelectedIndex = IndexByClient(Tc.Client);
            txtFinalPrice.Text = Tc.TotalPrice.ToString();
        }

        // �������� ������ �� �����
        private TripClient GetFromControls()
        {
            TripClient tripClient = (from t in db.TripClients where (t.Id == Id) select t).SingleOrDefault<TripClient>() ?? new TripClient();

            tripClient.Client = CurrentClient;
            tripClient.Trip = CurrentTrip;
            tripClient.Fio = CurrentClient.Fio;
            tripClient.TotalPrice = int.Parse(txtFinalPrice.Text);

            return tripClient;
        }

        // ��������� ������������ ��������� ������
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
                return;

            txtFio.Text = ddlClients.Text;
            txtDiscount.Text = CurrentClient.Discount.ToString();
            txtFinalPrice.Text = ((CurrentTrip.TotalPrice * (100 - CurrentClient.Discount)) / 100).ToString();
        }
    }
}