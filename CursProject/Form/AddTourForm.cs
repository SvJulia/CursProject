using System;
using System.Data.Linq;
using System.Linq;
using CursProject.Properties;

namespace CursProject.Form
{
    public partial class AddTourForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = new TourDbDataContext(Settings.Default.ConnectionString);

        public AddTourForm(int _Id = 0)
        {
            InitializeComponent();

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                Tour tour = GetFromControls();
                tour.City = GetCity();

                if (Id > 0)
                {
                    db.Refresh(RefreshMode.OverwriteCurrentValues, tour);
                }
                else
                {
                    db.Tours.InsertOnSubmit(tour);
                }

                db.SubmitChanges();

                Close();
            }
        }

        private City GetCity()
        {
            Country country = GetCountry();

            var city = (from c in db.Cities where (c.Name == txtCity.Text) select c).SingleOrDefault<City>();

            if (city == null)
            {
                city = new City { Name = txtCity.Text, Country = country };

                db.Cities.InsertOnSubmit(city);
            }
            else
            {
                city.Country = country;
                db.Refresh(RefreshMode.OverwriteCurrentValues, city);
            }

            db.SubmitChanges();

            return city;
        }

        private Country GetCountry()
        {
            var country = (from c in db.Countries where (c.Name == txtCountry.Text) select c).SingleOrDefault<Country>();

            if (country == null)
            {
                country = new Country { Name = txtCountry.Text };

                db.Countries.InsertOnSubmit(country);
                db.SubmitChanges();
            }

            return country;
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            var tour = (from t in db.Tours where (t.Id == Id) select t).SingleOrDefault<Tour>();

            txtName.Text = tour.Name;
            txtNameForClients.Text = tour.NameForClients;
            txtCity.Text = tour.City.Name;
            txtCountry.Text = tour.City.Country.Name;
        }

        // Получаем объект из формы
        private Tour GetFromControls()
        {
            var tour = (from t in db.Tours where (t.Id == Id) select t).SingleOrDefault<Tour>() ?? new Tour();

            tour.Name = txtName.Text;
            tour.NameForClients = txtNameForClients.Text;

            return tour;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtName, false);
            isValid &= ValidateControl(txtNameForClients, false);
            isValid &= ValidateControl(txtCity, false);
            isValid &= ValidateControl(txtCountry, false);

            return isValid;
        }
    }
}