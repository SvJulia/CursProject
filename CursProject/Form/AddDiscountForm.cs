using System;
using System.Data.Linq;
using System.Linq;
using CursProject.Classes;
using CursProject.Properties;

namespace CursProject.Form
{
    public partial class AddDiscountForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = new TourDbDataContext(Settings.Default.ConnectionString);

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
            var discount = (from d in db.Discounts where d.Id == Id select d).SingleOrDefault<Discount>();

            txtName.Text = discount.Name;
            txtDiscount.Text = discount.Value.ToString();
            txtRange.Text = discount.Range.ToString();
        }

        // Получаем объект из формы
        private Discount GetFromControls()
        {
            var discount = (from d in db.Discounts where d.Id == Id select d).SingleOrDefault<Discount>() ?? new Discount();

           discount.Name = txtName.Text;
           discount.Value = int.Parse(txtDiscount.Text);
           discount.Range = int.Parse(txtRange.Text);

           return discount;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtName, false);
            isValid &= ValidateControl(txtDiscount, true);
            isValid &= ValidateControl(txtRange, true);

            return isValid;
        }
    }
}