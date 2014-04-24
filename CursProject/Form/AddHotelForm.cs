using System;
using System.Data.Linq;
using System.Linq;
using CursProject.Classes;
using CursProject.Helpers;
using CursProject.Properties;
using CursProject.Types;

namespace CursProject.Form
{
    public partial class AddHotelForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = new TourDbDataContext(Settings.Default.ConnectionString);

        private string[] HotelTypes
        {
            get { return (from HotelType hotelType in Enum.GetValues(typeof(HotelType)) select EnumHelper.Huminize(hotelType)).ToArray(); }
        }

        public AddHotelForm(int _Id = 0)
        {
            InitializeComponent();
            FillHotelTypes();

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
                if (Id <= 0)
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
            ddlHotelTypes.SelectedIndex = IndexByHotelType(EnumHelper.FromString<HotelType>(hotel.Type));
        }

        // Получаем объект из формы
        private Hotel GetFromControls()
        {
            var hotel = (from h in db.Hotels where h.Id == Id select h).SingleOrDefault<Hotel>() ?? new Hotel();

            hotel.Name = txtName.Text;
            hotel.Type = HotelTypeByIndex(ddlHotelTypes.SelectedIndex).ToString();

            return hotel;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtName, false);
            isValid &= ValidateControl(ddlHotelTypes);

            return isValid;
        }

        private int IndexByHotelType(HotelType hotelType)
        {
            return Enum.GetValues(typeof(HotelType)).Cast<HotelType>().TakeWhile(r => r != hotelType).Count();
        }

        private HotelType HotelTypeByIndex(int index)
        {
            var hotelTypes = Enum.GetValues(typeof(HotelType));
            if ((index >= 0) && (index < hotelTypes.Length))
            {
                return (HotelType)hotelTypes.GetValue(index);
            }

            return HotelType.Stars2;
        }

        private void FillHotelTypes()
        {
            ddlHotelTypes.Items.Clear();
            ddlHotelTypes.Items.AddRange(HotelTypes);
            ddlHotelTypes.SelectedIndex = 0;
        }
    }
}