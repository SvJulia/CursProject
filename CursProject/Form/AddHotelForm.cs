using System;
using System.Data.Linq;
using System.Linq;
using CursProject.Properties;

namespace CursProject.Form
{
    public partial class AddHotelForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = new TourDbDataContext(Settings.Default.ConnectionString);

        public AddHotelForm(int _Id = 0)
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
                Hotel hotel = GetFromControls();
                if (Id > 0)
                {
                    db.Refresh(RefreshMode.OverwriteCurrentValues, hotel);
                }
                else
                {
                    db.Hotels.InsertOnSubmit(hotel);
                }

                db.SubmitChanges();
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            var hotel = (from h in db.Hotels where h.Id == Id select h).SingleOrDefault<Hotel>();

            txtName.Text = hotel.Name;
            txtType.Text = hotel.Type;
        }

        // Получаем объект из формы
        private Hotel GetFromControls()
        {
            var hotel = (from h in db.Hotels where h.Id == Id select h).SingleOrDefault<Hotel>() ?? new Hotel();

            hotel.Name = txtName.Text;
            hotel.Type = txtType.Text;

            return hotel;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtName, false);
            isValid &= ValidateControl(txtType, false);

            return isValid;
        }
    }
}