using System;
using System.Linq;
using CursProject.Classes;

namespace CursProject.Form
{
    public partial class AddDiscountForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = DataBase.Context;

        public AddDiscountForm(int _Id = 0)
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
                Discount discount = GetFromControls();
                if (Id <= 0)
                {
                    db.Discounts.InsertOnSubmit(discount);
                }

                db.SubmitChanges();
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            Discount discount = db.Discounts.SingleOrDefault(d => d.Id == Id);

            txtDiscount.Text = discount.Value.ToString();
            txtRange.Text = discount.Range.ToString();
        }

        // Получаем объект из формы
        private Discount GetFromControls()
        {
            Discount discount = db.Discounts.SingleOrDefault(d => d.Id == Id) ?? new Discount();
            
            discount.Name = string.Format("от {0} - {1}%", txtRange.Text, txtDiscount.Text);
            discount.Value = int.Parse(txtDiscount.Text);
            discount.Range = int.Parse(txtRange.Text);

            return discount;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtDiscount, true);
            isValid &= ValidateControl(txtRange, true);

            return isValid;
        }
    }
}