using System;
using System.Data.Linq;
using System.Linq;
using CursProject.Properties;

namespace CursProject.Form
{
    public partial class AddTransportForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = new TourDbDataContext(Settings.Default.ConnectionString);

        public AddTransportForm(int _Id = 0)
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
                Transport transport = GetFromControls();
                if (Id > 0)
                {
                    db.Refresh(RefreshMode.OverwriteCurrentValues, transport);
                }
                else
                {
                    db.Transports.InsertOnSubmit(transport);
                }

                db.SubmitChanges();
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            var transport = (from t in db.Transports where (t.Id == Id) select t).SingleOrDefault<Transport>();

            txtName.Text = transport.Name;
            txtType.Text = transport.Type;
        }

        // Получаем объект из формы
        private Transport GetFromControls()
        {
            var transport = (from t in db.Transports where (t.Id == Id) select t).SingleOrDefault<Transport>() ?? new Transport();

            transport.Name = txtName.Text;
            transport.Type = txtType.Text;

            return transport;
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