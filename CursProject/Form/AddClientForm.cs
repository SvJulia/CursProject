using System;
using System.Data.Linq;
using System.Linq;
using CursProject.Classes;
using CursProject.Properties;

namespace CursProject.Form
{
    public partial class AddClientForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = new TourDbDataContext(Settings.Default.ConnectionString);

        public AddClientForm(int _Id = 0)
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
                Client client = GetFromControls();
                if (Id <= 0)
                {
                    db.Clients.InsertOnSubmit(client);
                }

                db.SubmitChanges();
                Close();
            }
        }

        // ���������� ������ � ��������
        private void SetToControls()
        {
            var client = (from c in db.Clients where c.Id == Id select c).SingleOrDefault<Client>();

            txtFio.Text = client.Fio;
            txtDocType.Text = client.DocType;
            txtDocData.Text = client.DocData;
            txtEmail.Text = client.Email;
        }

        // �������� ������ �� �����
        private Client GetFromControls()
        {
            var client = (from c in db.Clients where c.Id == Id select c).SingleOrDefault<Client>() ?? new Client();

            client.Fio = txtFio.Text;
            client.DocType = txtDocType.Text;
            client.DocData = txtDocData.Text;
            client.Email = txtEmail.Text;

            return client;
        }

        // ��������� ������������ ��������� ������
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtFio, false);
            isValid &= ValidateControl(txtDocType, false);
            isValid &= ValidateControl(txtDocData, false);
            isValid &= ValidateControl(txtEmail, false);

            return isValid;
        }
    }
}