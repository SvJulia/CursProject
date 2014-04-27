using System;
using System.Linq;
using CursProject.Classes;
using CursProject.Helpers;
using CursProject.Types;

namespace CursProject.Form
{
    public partial class AddHotelForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = DataBase.Context;

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

        private string[] HotelTypes
        {
            get { return (from HotelType hotelType in Enum.GetValues(typeof (HotelType)) select EnumHelper.Huminize(hotelType)).ToArray(); }
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
            Hotel hotel = db.Hotels.SingleOrDefault(h => h.Id == Id);

            txtName.Text = hotel.Name;
            ddlHotelTypes.SelectedIndex = IndexByHotelType(EnumHelper.FromString<HotelType>(hotel.Type));
        }

        // Получаем объект из формы
        private Hotel GetFromControls()
        {
            Hotel hotel = db.Hotels.SingleOrDefault(h => h.Id == Id) ?? new Hotel();

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
            return Enum.GetValues(typeof (HotelType)).Cast<HotelType>().TakeWhile(r => r != hotelType).Count();
        }

        private HotelType HotelTypeByIndex(int index)
        {
            Array hotelTypes = Enum.GetValues(typeof (HotelType));
            if ((index >= 0) && (index < hotelTypes.Length))
            {
                return (HotelType) hotelTypes.GetValue(index);
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