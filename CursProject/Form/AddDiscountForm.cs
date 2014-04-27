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
                Text = "�������� " + Text;
                btnAdd.Text = "��������";
            }
            else
            {
                Id = 0;
                Text = "�������� " + Text;
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

        // ���������� ������ � ��������
        private void SetToControls()
        {
            Discount discount = db.Discounts.SingleOrDefault(d => d.Id == Id);

            txtName.Text = discount.Name;
            txtDiscount.Text = discount.Value.ToString();
            txtRange.Text = discount.Range.ToString();
        }

        // �������� ������ �� �����
        private Discount GetFromControls()
        {
            Discount discount = db.Discounts.SingleOrDefault(d => d.Id == Id) ?? new Discount();

            discount.Name = txtName.Text;
            discount.Value = int.Parse(txtDiscount.Text);
            discount.Range = int.Parse(txtRange.Text);

            return discount;
        }

        // ��������� ������������ ��������� ������
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