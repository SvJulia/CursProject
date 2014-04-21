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
            txtType.Text = transport.Type;
        }

        // �������� ������ �� �����
        private Transport GetFromControls()
        {
            var transport = (from t in db.Transports where (t.Id == Id) select t).SingleOrDefault<Transport>() ?? new Transport();

            transport.Name = txtName.Text;
            transport.Type = txtType.Text;

            return transport;
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