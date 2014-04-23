using System;
using System.Data.Linq;
using System.Linq;
using CursProject.Helpers;
using CursProject.Properties;
using CursProject.Types;

namespace CursProject.Form
{
    public partial class AddMealForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = new TourDbDataContext(Settings.Default.ConnectionString);

        private string[] MealTypes
        {
            get { return (from MealType mealType in Enum.GetValues(typeof(MealType)) select EnumHelper.Huminize(mealType)).ToArray(); }
        }
                        
        public AddMealForm(int _Id = 0)
        {
            InitializeComponent();
            FillMealTypes();

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
            ddlMealTypes.SelectedIndex = IndexByMealType(EnumHelper.FromString<MealType>(meal.Type));
        }

        // �������� ������ �� �����
        private Meal GetFromControls()
        {
            var meal = (from m in db.Meals where (m.Id == Id) select m).SingleOrDefault<Meal>() ?? new Meal();

            meal.Name = txtName.Text;
            meal.Type = MealTypeByIndex(ddlMealTypes.SelectedIndex).ToString();

            return meal;
        }

        // ��������� ������������ ��������� ������
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtName, false);
            isValid &= ValidateControl(ddlMealTypes);

            return isValid;
        }

        private int IndexByMealType(MealType mealType)
        {
            return Enum.GetValues(typeof(MealType)).Cast<MealType>().TakeWhile(r => r != mealType).Count();
        }

        private MealType MealTypeByIndex(int index)
        {
            var mealTypes = Enum.GetValues(typeof(MealType));
            if ((index >= 0) && (index < mealTypes.Length))
            {
                return (MealType)mealTypes.GetValue(index);
            }

            return MealType.No;
        }

        private void FillMealTypes()
        {
            ddlMealTypes.Items.Clear();
            ddlMealTypes.Items.AddRange(MealTypes);
            ddlMealTypes.SelectedIndex = 0;
        }
    }
}