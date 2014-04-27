using System;
using System.Linq;
using CursProject.Classes;

namespace CursProject.Form
{
    public partial class AddExcursionForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = DataBase.Context;

        public AddExcursionForm(int _Id = 0)
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
                Excursion excursion = GetFromControls();
                if (Id <= 0)
                {
                    db.Excursions.InsertOnSubmit(excursion);
                }

                db.SubmitChanges();
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            Excursion excursion = db.Excursions.SingleOrDefault(e => e.Id == Id);

            txtName.Text = excursion.Name;
            txtDescription.Text = excursion.Description;
            txtRating.Text = excursion.Rating.ToString();
        }

        // Получаем объект из формы
        private Excursion GetFromControls()
        {
            Excursion excursion = db.Excursions.SingleOrDefault(e => e.Id == Id) ?? new Excursion();

            excursion.Name = txtName.Text;
            excursion.Description = txtDescription.Text;
            excursion.Rating = int.Parse(txtRating.Text);

            return excursion;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtName, false);
            isValid &= ValidateControl(txtDescription, false);
            isValid &= ValidateControl(txtRating, true);

            return isValid;
        }
    }
}