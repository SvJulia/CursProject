using System;
using System.Collections.Generic;
using System.Linq;
using CursProject.Classes;

namespace CursProject.Form
{
    public partial class ShowTripForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = DataBase.Context;

        public ShowTripForm(int _Id = 0)
        {
            InitializeComponent();
            Id = _Id;
            Text = "Просмотр " + Text;
            SetToControls();
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
        
        // Записываем объект в контролы
        private void SetToControls()
        {
            Trip trip = db.Trips.SingleOrDefault(t => (t.Id == Id));

            lblTours.Text = trip.Tour.ToString();
            lblMeals.Text = trip.Meal.ToString();
            lblTransports.Text = trip.Transport.ToString();
            lblHotels.Text = trip.Hotel.ToString();
            lblDateDeparture.Text = trip.DateDeparture.ToShortDateString();
            lblDateArival.Text = trip.DateArival.ToShortDateString();
            lblNights.Text = trip.Nights.ToString();
            lblAmount.Text = trip.Amount.ToString();
            lblTourPrice.Text = trip.TourPrice.ToString();
            lblMealPrice.Text = trip.MealPrice.ToString();
            lblTransportPrice.Text = trip.TransportPrice.ToString();
            lblHotelPrice.Text = trip.HotelPrice.ToString();
        }
    }
}