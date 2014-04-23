using System;
using System.Data.Linq;
using System.Linq;
using CursProject.Helpers;
using CursProject.Properties;
using CursProject.Types;

namespace CursProject.Form
{
    public partial class AddTransportForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = new TourDbDataContext(Settings.Default.ConnectionString);  

        private string[] TransportTypes
        {
            get { return (from TransportType transportType in Enum.GetValues(typeof(TransportType)) select EnumHelper.Huminize(transportType)).ToArray(); }
        }

        public AddTransportForm(int _Id = 0)
        {
            InitializeComponent();
            FillTransportTypes();

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

        // ���������� ������ � ��������
        private void SetToControls()
        {
            var transport = (from t in db.Transports where (t.Id == Id) select t).SingleOrDefault<Transport>();

            txtName.Text = transport.Name;
            ddlTransportTypes.SelectedIndex = IndexByTransportType(EnumHelper.FromString<TransportType>(transport.Type));
        }

        // �������� ������ �� �����
        private Transport GetFromControls()
        {
            var transport = (from t in db.Transports where (t.Id == Id) select t).SingleOrDefault<Transport>() ?? new Transport();

            transport.Name = txtName.Text;
            transport.Type = TransportTypeByIndex(ddlTransportTypes.SelectedIndex).ToString();

            return transport;
        }

        // ��������� ������������ ��������� ������
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtName, false);
            isValid &= ValidateControl(ddlTransportTypes);

            return isValid;
        }

        private int IndexByTransportType(TransportType transportType)
        {
            return Enum.GetValues(typeof(TransportType)).Cast<TransportType>().TakeWhile(r => r != transportType).Count();
        }

        private TransportType TransportTypeByIndex(int index)
        {
            var transportTypes = Enum.GetValues(typeof(TransportType));
            if ((index >= 0) && (index < transportTypes.Length))
            {
                return (TransportType)transportTypes.GetValue(index);
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