using System;
using System.Linq;
using CursProject.Classes;
using CursProject.Helpers;
using CursProject.Types;

namespace CursProject.Form
{
    public partial class AddTransportForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = DataBase.Context;

        public AddTransportForm(int _Id = 0)
        {
            InitializeComponent();
            FillTransportTypes();

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

        private string[] TransportTypes
        {
            get { return (from TransportType transportType in Enum.GetValues(typeof (TransportType)) select EnumHelper.Huminize(transportType)).ToArray(); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                Transport transport = GetFromControls();
                if (Id <= 0)
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
            Transport transport = db.Transports.SingleOrDefault(t => (t.Id == Id));

            txtName.Text = transport.Name;
            ddlTransportTypes.SelectedIndex = IndexByTransportType(EnumHelper.FromString<TransportType>(transport.Type));
        }

        // Получаем объект из формы
        private Transport GetFromControls()
        {
            Transport transport = db.Transports.SingleOrDefault(t => (t.Id == Id)) ?? new Transport();

            transport.Name = txtName.Text;
            transport.Type = TransportTypeByIndex(ddlTransportTypes.SelectedIndex).ToString();

            return transport;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtName, false);
            isValid &= ValidateControl(ddlTransportTypes);

            return isValid;
        }

        private int IndexByTransportType(TransportType transportType)
        {
            return Enum.GetValues(typeof (TransportType)).Cast<TransportType>().TakeWhile(r => r != transportType).Count();
        }

        private TransportType TransportTypeByIndex(int index)
        {
            Array transportTypes = Enum.GetValues(typeof (TransportType));
            if ((index >= 0) && (index < transportTypes.Length))
            {
                return (TransportType) transportTypes.GetValue(index);
            }

            return TransportType.Air;
        }

        private void FillTransportTypes()
        {
            ddlTransportTypes.Items.Clear();
            ddlTransportTypes.Items.AddRange(TransportTypes);
            ddlTransportTypes.SelectedIndex = 0;
        }
    }
}