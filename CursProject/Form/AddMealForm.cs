using System;
using System.Data.Linq;
using System.Linq;
using CursProject.Classes;
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
                Meal meal = GetFromControls();
                if (Id <= 0)
                {
                    db.Meals.InsertOnSubmit(meal);
                }

                db.SubmitChanges();
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            var meal = (from m in db.Meals where (m.Id == Id) select m).SingleOrDefault<Meal>();

            txtName.Text = meal.Name;
            ddlMealTypes.SelectedIndex = IndexByMealType(EnumHelper.FromString<MealType>(meal.Type));
        }

        // Получаем объект из формы
        private Meal GetFromControls()
        {
            var meal = (from m in db.Meals where (m.Id == Id) select m).SingleOrDefault<Meal>() ?? new Meal();

            meal.Name = txtName.Text;
            meal.Type = MealTypeByIndex(ddlMealTypes.SelectedIndex).ToString();

            return meal;
        }

        // Проверяем корректность введенных данных
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