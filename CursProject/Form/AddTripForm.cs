using System;

namespace CursProject.Form
{
    public partial class AddTripForm : ValidateForm
    {
        private int Id;

        public AddTripForm(int _Id = 0)
        {
            InitializeComponent();

            Id = _Id;

            if (Id > 0)
            {
                SetToControls();
                this.Text = "Изменить " + this.Text;
                btnAdd.Text = "Изменить";
            }
            else
            {
                Id = 0;
                this.Text = "Добавить " + this.Text;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                var trip = GetFromControls();
                if (Id > 0)
                {
                    //Trip.Update(trip);
                }
                else
                {
                    //Trip.Create(trip);
                }

                this.Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {                          
            /*
            var trip = Trip.Find(Id);
            txtTourId.Text = trip.TourId.ToString();
            txtMeal.Text = trip.Meal.ToString();
            txtTransport.Text = trip.Transport.ToString();
            txtHotel.Text = trip.Hotel.ToString();
            txtDateDeparture.Text = trip.DateDeparture.ToString();
            txtDateArival.Text = trip.DateArival.ToString();
            txtNights.Text = trip.Nights.ToString();
            txtAmount.Text = trip.Amount.ToString();
            txtTourPrice.Text = trip.TourPrice.ToString();
            txtMealPrice.Text = trip.MealPrice.ToString();
            txtTransportPrice.Text = trip.TransportPrice.ToString();
            txtHotelPrice.Text = trip.HotelPrice.ToString();
                                    */

        }

        // Получаем объект из формы
        private Trip GetFromControls()
        {
            return new Trip
            {
                Id = Id,
                TourId = int.Parse(txtTourId.Text),
                /*
                Meal = int.Parse(txtMeal.Text),
                Transport = int.Parse(txtTransport.Text),
                Hotel = int.Parse(txtHotel.Text),
                 */
                DateDeparture = DateTime.Parse(txtDateDeparture.Text),
                DateArival = DateTime.Parse(txtDateArival.Text),
                Nights = int.Parse(txtNights.Text),
                Amount = int.Parse(txtAmount.Text),
                TourPrice = int.Parse(txtTourPrice.Text),
                MealPrice = int.Parse(txtMealPrice.Text),
                TransportPrice = int.Parse(txtTransportPrice.Text),
                HotelPrice = int.Parse(txtHotelPrice.Text)
            };
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtTourId, true);
            isValid &= ValidateControl(txtMeal, true);
            isValid &= ValidateControl(txtTransport, true);
            isValid &= ValidateControl(txtHotel, true);
            isValid &= ValidateControl(txtDateDeparture, true);
            isValid &= ValidateControl(txtDateArival, true);
            isValid &= ValidateControl(txtNights, true);
            isValid &= ValidateControl(txtAmount, true);
            isValid &= ValidateControl(txtTourPrice, true);
            isValid &= ValidateControl(txtMealPrice, true);
            isValid &= ValidateControl(txtTransportPrice, true);
            isValid &= ValidateControl(txtHotelPrice, true);

            return isValid;
        }
    }
}