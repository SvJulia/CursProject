using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using CursProject.Classes;
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
            FillCountries();
            FillExcursions();

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

        private List<City> Cities
        {
            get
            {
                if (CurrentCountry == null)
                {
                    return new List<City>();
                }

                return CurrentCountry.Cities.ToList();
            }
        }

        private List<Country> Countries
        {
            get { return db.Countries.ToList(); }
        }

        private List<Excursion> Excursions
        {
            get { return db.Excursions.ToList(); }
        }

        private City CurrentCity
        {
            get
            {
                int index = ddlCities.SelectedIndex;

                if ((index >= 0) && (index < Cities.Count))
                {
                    return Cities[index];
                }

                return null;
            }
        }

        private Country CurrentCountry
        {
            get
            {
                int index = ddlCountries.SelectedIndex;

                if ((index >= 0) && (index < Countries.Count))
                {
                    return Countries[index];
                }

                return null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                Tour tour = GetFromControls();

                if (Id <= 0)
                {
                    db.Tours.InsertOnSubmit(tour);
                }

                db.SubmitChanges();


                foreach (var te in tour.TourExcursions)
                {
                    db.TourExcursions.DeleteOnSubmit(te);
                }
                db.SubmitChanges();

                foreach (var ex in CurrentExcursions)
                {
                    var te = new TourExcursion();
                    te.Tour = tour;
                    te.Excursion = ex;
                    db.TourExcursions.InsertOnSubmit(te);
                }
                db.SubmitChanges();

                Close();
            }
        }

        private City GetCity()
        {
            Country country = GetCountry();

            var city = CurrentCity;

            if (city == null)
            {
                city = new City { Name = ddlCities.Text, Country = country };

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
            var country = CurrentCountry;

            if (country == null)
            {
                country = new Country { Name = ddlCountries.Text };

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
            ddlCities.SelectedIndex = IndexByCity(tour.City);
            ddlCountries.SelectedIndex = IndexByCountry(tour.City.Country);

            foreach (var te in tour.TourExcursions)
            {
                int index = IndexByExcursion(te.Excursion);
                lbExcursions.SelectedIndices.Add(index);
            }    
        }

        // Получаем объект из формы
        private Tour GetFromControls()
        {
            Tour tour = (from t in db.Tours where (t.Id == Id) select t).SingleOrDefault<Tour>() ?? new Tour();

            tour.Name = txtName.Text;
            tour.NameForClients = txtNameForClients.Text;
            tour.City = GetCity();

            return tour;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtName, false);
            isValid &= ValidateControl(txtNameForClients, false);

            return isValid;
        }


        private int IndexByCity(City city)
        {
            return city != null ? Cities.FindIndex(c => c.Id == city.Id) : 0;
        }

        private void FillCities()
        {
            ddlCities.Items.Clear();
            ddlCities.Items.AddRange(Cities.ToArray());
            if (ddlCities.Items.Count > 0)
            {
                ddlCities.SelectedIndex = 0;
            }
            else
            {
                ddlCities.Text = "";
            }
        }

        private int IndexByCountry(Country country)
        {
            return country != null ? Countries.FindIndex(c => c.Id == country.Id) : 0;
        }

        private void FillCountries()
        {
            ddlCountries.Items.Clear();
            ddlCountries.Items.AddRange(Countries.ToArray());
            if (ddlCountries.Items.Count > 0)
            {
                ddlCountries.SelectedIndex = 0;
            }
        }

        private List<Excursion> CurrentExcursions
        {
            get
            {
                var indexes = lbExcursions.SelectedIndices;

                var list = new List<Excursion>();
                for (int i = 0; i < indexes.Count; i++)
                {
                    list.Add(Excursions[indexes[i]]);
                }

                return list;
            }
        }

        private int IndexByExcursion(Excursion excursion)
        {
            return excursion != null ? Excursions.FindIndex(c => c.Id == excursion.Id) : 0;
        }

        private void FillExcursions()
        {
            if (lbExcursions.Items.Count == Excursions.Count) return;

            lbExcursions.Items.Clear();
            lbExcursions.Items.AddRange(Excursions.ToArray());
        }

        private void ddlCountries_TextChanged(object sender, EventArgs e)
        {
            FillCities();
        }
    }
}