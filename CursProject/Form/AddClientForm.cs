using System;
using System.Linq;
using CursProject.Classes;

namespace CursProject.Form
{
    public partial class AddClientForm : ValidateForm
    {
        private readonly int Id;
        private readonly TourDbDataContext db = DataBase.Context;

        public AddClientForm(int id = 0)
        {
            InitializeComponent();

            Id = id;

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
                Client client = GetFromControls();
                if (Id <= 0)
                {
                    db.Clients.InsertOnSubmit(client);
                }

                db.SubmitChanges();
                Close();
            }
        }

        // Записываем объект в контролы
        private void SetToControls()
        {
            Client client = db.Clients.SingleOrDefault(c => c.Id == Id);

            txtFio.Text = client.Fio;
            txtDocType.Text = client.DocType;
            txtDocData.Text = client.DocData;
            txtEmail.Text = client.Email;
            txtPhone.Text = client.Phone;
            txtAddress.Text = client.Address;
            txtAccountNumber.Text = client.AccountNumber;
        }

        // Получаем объект из формы
        private Client GetFromControls()
        {
            Client client = db.Clients.SingleOrDefault(c => c.Id == Id) ?? new Client();

            client.Fio = txtFio.Text;
            client.DocType = txtDocType.Text;
            client.DocData = txtDocData.Text;
            client.Email = txtEmail.Text;
            client.Phone = txtPhone.Text;
            client.Address = txtAddress.Text;
            client.AccountNumber = txtAccountNumber.Text;

            return client;
        }

        // Проверяем корректность введенных данных
        private bool ValidateControls()
        {
            bool isValid = true;

            isValid &= ValidateControl(txtFio, false);
            isValid &= ValidateControl(txtDocType, false);
            isValid &= ValidateControl(txtDocData, false);
            isValid &= ValidateControl(txtEmail, false);
            isValid &= ValidateControl(txtPhone, false);
            isValid &= ValidateControl(txtAddress, false);

            return isValid;
        }
    }
}