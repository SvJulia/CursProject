using System;
using System.Data.Linq;
using System.Linq;
using CursProject.Properties;

namespace CursProject.Form
{
    public partial class AddMealForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = new TourDbDataContext(Settings.Default.ConnectionString);

        public AddMealForm(int _Id = 0)
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
                Meal meal = GetFromControls();
                if (Id > 0)
                {
                    db.Refresh(RefreshMode.OverwriteCurrentValues, meal);
                }
                else
                {
                    db.Meals.InsertOnSubmit(meal);
                }

                db.SubmitChanges();
                Close();
            }
        }

        // ���������� ������ � ��������
        private void SetToControls()
        {
            var meal = (from m in db.Meals where (m.Id == Id) select m).SingleOrDefault<Meal>();

            txtName.Text = meal.Name;
            txtType.Text = meal.Type;
        }

        // �������� ������ �� �����
        private Meal GetFromControls()
        {
            var meal = (from m in db.Meals where (m.Id == Id) select m).SingleOrDefault<Meal>() ?? new Meal();

            meal.Name = txtName.Text;
            meal.Type = txtType.Text;

            return meal;
        }

        // ��������� ������������ ��������� ������
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtName, false);
            isValid &= ValidateControl(txtType, false);

            return isValid;
        }
    }
}