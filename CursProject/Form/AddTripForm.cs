using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using CursProject.Properties;

namespace CursProject.Form
{
    public partial class AddTripForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = new TourDbDataContext(Settings.Default.ConnectionString);

        public AddTripForm(int _Id = 0)
        {
            InitializeComponent();
            FillHotels();
            FillMeals();
            FillTours();
            FillTransports();

            Id = _Id;

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

        private List<Tour> Tours
        {
            get { return db.Tours.ToList(); }
        }

        private List<Meal> Meals
        {
            get { return db.Meals.ToList(); }
        }

        private List<Transport> Transports
        {
            get { return db.Transports.ToList(); }
        }

        private List<Hotel> Hotels
        {
            get { return db.Hotels.ToList(); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                Trip trip = GetFromControls();
                if (Id > 0)
                {
                    db.Refresh(RefreshMode.OverwriteCurrentValues, trip);
                }
                else
                {
                    db.Trips.InsertOnSubmit(trip);
                }

                db.SubmitChanges();

                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            var trip = (from t in db.Trips where (t.Id == Id) select t).SingleOrDefault<Trip>();

            ddlTours.SelectedIndex = IndexByTour(trip.Tour);
            ddlMeals.SelectedIndex = IndexByMeal(trip.Meal);
            ddlTransports.SelectedIndex = IndexByTransport(trip.Transport);
            ddlHotels.SelectedIndex = IndexByHotel(trip.Hotel);
            dtpDateDeparture.Value = trip.DateDeparture;
            dtpDateArival.Value = trip.DateArival;
            txtNights.Text = trip.Nights.ToString();
            txtAmount.Text = trip.Amount.ToString();
            txtTourPrice.Text = trip.TourPrice.ToString();
            txtMealPrice.Text = trip.MealPrice.ToString();
            txtTransportPrice.Text = trip.TransportPrice.ToString();
            txtHotelPrice.Text = trip.HotelPrice.ToString();
        }

        // Получаем объект из формы
        private Trip GetFromControls()
        {
            Trip trip = (from t in db.Trips where (t.Id == Id) select t).SingleOrDefault<Trip>() ?? new Trip();

            trip.Id = Id;
            trip.TourId = TourByIndex(ddlTours.SelectedIndex).Id;
            trip.MealId = MealByIndex(ddlMeals.SelectedIndex).Id;
            trip.TransportId = TransportByIndex(ddlTransports.SelectedIndex).Id;
            trip.HotelId = HotelByIndex(ddlHotels.SelectedIndex).Id;
            trip.DateDeparture = dtpDateDeparture.Value;
            trip.DateArival = dtpDateArival.Value;
            trip.Nights = int.Parse(txtNights.Text);
            trip.Amount = int.Parse(txtAmount.Text);
            trip.TourPrice = int.Parse(txtTourPrice.Text);
            trip.MealPrice = int.Parse(txtMealPrice.Text);
            trip.TransportPrice = int.Parse(txtTransportPrice.Text);
            trip.HotelPrice = int.Parse(txtHotelPrice.Text);

            return trip;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(ddlTours);
            isValid &= ValidateControl(ddlMeals);
            isValid &= ValidateControl(ddlTransports);
            isValid &= ValidateControl(ddlHotels);
            isValid &= ValidateControl(txtNights, true);
            isValid &= ValidateControl(txtAmount, true);
            isValid &= ValidateControl(txtTourPrice, true);
            isValid &= ValidateControl(txtMealPrice, true);
            isValid &= ValidateControl(txtTransportPrice, true);
            isValid &= ValidateControl(txtHotelPrice, true);

            return isValid;
        }

        private int IndexByTour(Tour tour)
        {
            return tour != null ? Tours.FindIndex(c => c.Id == tour.Id) : 0;
        }

        private Tour TourByIndex(int index)
        {
            if ((index >= 0) && (index < Tours.Count))
            {
                return Tours[index];
            }

            return null;
        }

        private void FillTours()
        {
            ddlTours.Items.Clear();
            ddlTours.Items.AddRange(Tours.ToArray());
            if (ddlTours.Items.Count > 0)
            {
                ddlTours.SelectedIndex = 0;
            }
        }

        private int IndexByMeal(Meal meal)
        {
            return meal != null ? Meals.FindIndex(c => c.Id == meal.Id) : 0;
        }

        private Meal MealByIndex(int index)
        {
            if ((index >= 0) && (index < Meals.Count))
            {
                return Meals[index];
            }

            return null;
        }

        private void FillMeals()
        {
            ddlMeals.Items.Clear();
            ddlMeals.Items.AddRange(Meals.ToArray());
            if (ddlMeals.Items.Count > 0)
            {
                ddlMeals.SelectedIndex = 0;
            }
        }

        private int IndexByTransport(Transport transport)
        {
            return transport != null ? Transports.FindIndex(c => c.Id == transport.Id) : 0;
        }

        private Transport TransportByIndex(int index)
        {
            if ((index >= 0) && (index < Transports.Count))
            {
                return Transports[index];
            }

            return null;
        }

        private void FillTransports()
        {
            ddlTransports.Items.Clear();
            ddlTransports.Items.AddRange(Transports.ToArray());
            if (ddlTransports.Items.Count > 0)
            {
                ddlTransports.SelectedIndex = 0;
            }
        }

        private int IndexByHotel(Hotel hotel)
        {
            return hotel != null ? Hotels.FindIndex(c => c.Id == hotel.Id) : 0;
        }

        private Hotel HotelByIndex(int index)
        {
            if ((index >= 0) && (index < Hotels.Count))
            {
                return Hotels[index];
            }

            return null;
        }

        private void FillHotels()
        {
            ddlHotels.Items.Clear();
            ddlHotels.Items.AddRange(Hotels.ToArray());
            if (ddlHotels.Items.Count > 0)
            {
                ddlHotels.SelectedIndex = 0;
            }
        }
    }
}