namespace CursProject.Form
{
    partial class AddTripClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labelTourId = new System.Windows.Forms.Label();
            this.labelTransport = new System.Windows.Forms.Label();
            this.labelHotel = new System.Windows.Forms.Label();
            this.labelDateDeparture = new System.Windows.Forms.Label();
            this.labelDateArival = new System.Windows.Forms.Label();
            this.labelNights = new System.Windows.Forms.Label();
            this.txtNights = new System.Windows.Forms.TextBox();
            this.labelMealPrice = new System.Windows.Forms.Label();
            this.txtMealPrice = new System.Windows.Forms.TextBox();
            this.labelTransportPrice = new System.Windows.Forms.Label();
            this.txtTransportPrice = new System.Windows.Forms.TextBox();
            this.labelHotelPrice = new System.Windows.Forms.Label();
            this.txtHotelPrice = new System.Windows.Forms.TextBox();
            this.labelMeal = new System.Windows.Forms.Label();
            this.ddlClients = new System.Windows.Forms.ComboBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFinalPrice = new System.Windows.Forms.TextBox();
            this.txtTour = new System.Windows.Forms.TextBox();
            this.txtMeal = new System.Windows.Forms.TextBox();
            this.txtTransport = new System.Windows.Forms.TextBox();
            this.txtHotel = new System.Windows.Forms.TextBox();
            this.txtDateDeparture = new System.Windows.Forms.TextBox();
            this.txtDateArival = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTripPrice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(292, 484);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(211, 484);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelTourId
            // 
            this.labelTourId.AutoSize = true;
            this.labelTourId.Location = new System.Drawing.Point(117, 22);
            this.labelTourId.Name = "labelTourId";
            this.labelTourId.Size = new System.Drawing.Size(31, 13);
            this.labelTourId.TabIndex = 6;
            this.labelTourId.Text = "Тур: ";
            // 
            // labelTransport
            // 
            this.labelTransport.AutoSize = true;
            this.labelTransport.Location = new System.Drawing.Point(81, 178);
            this.labelTransport.Name = "labelTransport";
            this.labelTransport.Size = new System.Drawing.Size(67, 13);
            this.labelTransport.TabIndex = 6;
            this.labelTransport.Text = "Транспорт: ";
            // 
            // labelHotel
            // 
            this.labelHotel.AutoSize = true;
            this.labelHotel.Location = new System.Drawing.Point(104, 230);
            this.labelHotel.Name = "labelHotel";
            this.labelHotel.Size = new System.Drawing.Size(44, 13);
            this.labelHotel.TabIndex = 6;
            this.labelHotel.Text = "Отель: ";
            // 
            // labelDateDeparture
            // 
            this.labelDateDeparture.AutoSize = true;
            this.labelDateDeparture.Location = new System.Drawing.Point(64, 74);
            this.labelDateDeparture.Name = "labelDateDeparture";
            this.labelDateDeparture.Size = new System.Drawing.Size(84, 13);
            this.labelDateDeparture.TabIndex = 6;
            this.labelDateDeparture.Text = "Дата отбытия: ";
            // 
            // labelDateArival
            // 
            this.labelDateArival.AutoSize = true;
            this.labelDateArival.Location = new System.Drawing.Point(57, 100);
            this.labelDateArival.Name = "labelDateArival";
            this.labelDateArival.Size = new System.Drawing.Size(91, 13);
            this.labelDateArival.TabIndex = 6;
            this.labelDateArival.Text = "Дата прибытия: ";
            // 
            // labelNights
            // 
            this.labelNights.AutoSize = true;
            this.labelNights.Location = new System.Drawing.Point(69, 48);
            this.labelNights.Name = "labelNights";
            this.labelNights.Size = new System.Drawing.Size(79, 13);
            this.labelNights.TabIndex = 6;
            this.labelNights.Text = "Кол-во ночей: ";
            // 
            // txtNights
            // 
            this.txtNights.Location = new System.Drawing.Point(154, 45);
            this.txtNights.MaxLength = 255;
            this.txtNights.Name = "txtNights";
            this.txtNights.Size = new System.Drawing.Size(188, 20);
            this.txtNights.TabIndex = 8;
            // 
            // labelMealPrice
            // 
            this.labelMealPrice.AutoSize = true;
            this.labelMealPrice.Location = new System.Drawing.Point(36, 152);
            this.labelMealPrice.Name = "labelMealPrice";
            this.labelMealPrice.Size = new System.Drawing.Size(112, 13);
            this.labelMealPrice.TabIndex = 6;
            this.labelMealPrice.Text = "Стоимость питания: ";
            // 
            // txtMealPrice
            // 
            this.txtMealPrice.Location = new System.Drawing.Point(154, 149);
            this.txtMealPrice.MaxLength = 255;
            this.txtMealPrice.Name = "txtMealPrice";
            this.txtMealPrice.Size = new System.Drawing.Size(188, 20);
            this.txtMealPrice.TabIndex = 2;
            // 
            // labelTransportPrice
            // 
            this.labelTransportPrice.AutoSize = true;
            this.labelTransportPrice.Location = new System.Drawing.Point(19, 204);
            this.labelTransportPrice.Name = "labelTransportPrice";
            this.labelTransportPrice.Size = new System.Drawing.Size(129, 13);
            this.labelTransportPrice.TabIndex = 6;
            this.labelTransportPrice.Text = "Стоимость транспорта: ";
            // 
            // txtTransportPrice
            // 
            this.txtTransportPrice.Location = new System.Drawing.Point(154, 201);
            this.txtTransportPrice.MaxLength = 255;
            this.txtTransportPrice.Name = "txtTransportPrice";
            this.txtTransportPrice.Size = new System.Drawing.Size(188, 20);
            this.txtTransportPrice.TabIndex = 4;
            // 
            // labelHotelPrice
            // 
            this.labelHotelPrice.AutoSize = true;
            this.labelHotelPrice.Location = new System.Drawing.Point(48, 256);
            this.labelHotelPrice.Name = "labelHotelPrice";
            this.labelHotelPrice.Size = new System.Drawing.Size(100, 13);
            this.labelHotelPrice.TabIndex = 6;
            this.labelHotelPrice.Text = "Стоимость отеля: ";
            // 
            // txtHotelPrice
            // 
            this.txtHotelPrice.Location = new System.Drawing.Point(154, 253);
            this.txtHotelPrice.MaxLength = 255;
            this.txtHotelPrice.Name = "txtHotelPrice";
            this.txtHotelPrice.Size = new System.Drawing.Size(188, 20);
            this.txtHotelPrice.TabIndex = 6;
            // 
            // labelMeal
            // 
            this.labelMeal.AutoSize = true;
            this.labelMeal.Location = new System.Drawing.Point(92, 126);
            this.labelMeal.Name = "labelMeal";
            this.labelMeal.Size = new System.Drawing.Size(56, 13);
            this.labelMeal.TabIndex = 6;
            this.labelMeal.Text = "Питание: ";
            // 
            // ddlClients
            // 
            this.ddlClients.FormattingEnabled = true;
            this.ddlClients.Location = new System.Drawing.Point(154, 19);
            this.ddlClients.Name = "ddlClients";
            this.ddlClients.Size = new System.Drawing.Size(188, 21);
            this.ddlClients.TabIndex = 14;
            this.ddlClients.SelectedIndexChanged += new System.EventHandler(this.ddlClients_SelectedIndexChanged);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(154, 72);
            this.txtDiscount.MaxLength = 255;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(188, 20);
            this.txtDiscount.TabIndex = 15;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(154, 305);
            this.txtTotalPrice.MaxLength = 255;
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(188, 20);
            this.txtTotalPrice.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Клиент: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Сумма: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Скидка: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Итого: ";
            // 
            // txtFinalPrice
            // 
            this.txtFinalPrice.Location = new System.Drawing.Point(154, 98);
            this.txtFinalPrice.MaxLength = 255;
            this.txtFinalPrice.Name = "txtFinalPrice";
            this.txtFinalPrice.Size = new System.Drawing.Size(188, 20);
            this.txtFinalPrice.TabIndex = 20;
            // 
            // txtTour
            // 
            this.txtTour.Location = new System.Drawing.Point(154, 19);
            this.txtTour.MaxLength = 255;
            this.txtTour.Name = "txtTour";
            this.txtTour.Size = new System.Drawing.Size(188, 20);
            this.txtTour.TabIndex = 22;
            // 
            // txtMeal
            // 
            this.txtMeal.Location = new System.Drawing.Point(154, 123);
            this.txtMeal.MaxLength = 255;
            this.txtMeal.Name = "txtMeal";
            this.txtMeal.Size = new System.Drawing.Size(188, 20);
            this.txtMeal.TabIndex = 23;
            // 
            // txtTransport
            // 
            this.txtTransport.Location = new System.Drawing.Point(154, 175);
            this.txtTransport.MaxLength = 255;
            this.txtTransport.Name = "txtTransport";
            this.txtTransport.Size = new System.Drawing.Size(188, 20);
            this.txtTransport.TabIndex = 24;
            // 
            // txtHotel
            // 
            this.txtHotel.Location = new System.Drawing.Point(154, 227);
            this.txtHotel.MaxLength = 255;
            this.txtHotel.Name = "txtHotel";
            this.txtHotel.Size = new System.Drawing.Size(188, 20);
            this.txtHotel.TabIndex = 25;
            // 
            // txtDateDeparture
            // 
            this.txtDateDeparture.Location = new System.Drawing.Point(154, 71);
            this.txtDateDeparture.MaxLength = 255;
            this.txtDateDeparture.Name = "txtDateDeparture";
            this.txtDateDeparture.Size = new System.Drawing.Size(188, 20);
            this.txtDateDeparture.TabIndex = 26;
            // 
            // txtDateArival
            // 
            this.txtDateArival.Location = new System.Drawing.Point(154, 97);
            this.txtDateArival.MaxLength = 255;
            this.txtDateArival.Name = "txtDateArival";
            this.txtDateArival.Size = new System.Drawing.Size(188, 20);
            this.txtDateArival.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = " ФИО: ";
            // 
            // txtFio
            // 
            this.txtFio.Location = new System.Drawing.Point(154, 46);
            this.txtFio.MaxLength = 255;
            this.txtFio.Name = "txtFio";
            this.txtFio.Size = new System.Drawing.Size(188, 20);
            this.txtFio.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Стоимость тура: ";
            // 
            // txtTripPrice
            // 
            this.txtTripPrice.Location = new System.Drawing.Point(154, 279);
            this.txtTripPrice.MaxLength = 255;
            this.txtTripPrice.Name = "txtTripPrice";
            this.txtTripPrice.Size = new System.Drawing.Size(188, 20);
            this.txtTripPrice.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTour);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labelHotelPrice);
            this.groupBox1.Controls.Add(this.txtTripPrice);
            this.groupBox1.Controls.Add(this.txtHotelPrice);
            this.groupBox1.Controls.Add(this.labelTransportPrice);
            this.groupBox1.Controls.Add(this.txtTransportPrice);
            this.groupBox1.Controls.Add(this.txtDateArival);
            this.groupBox1.Controls.Add(this.labelMealPrice);
            this.groupBox1.Controls.Add(this.txtDateDeparture);
            this.groupBox1.Controls.Add(this.txtMealPrice);
            this.groupBox1.Controls.Add(this.txtHotel);
            this.groupBox1.Controls.Add(this.labelNights);
            this.groupBox1.Controls.Add(this.txtTransport);
            this.groupBox1.Controls.Add(this.txtNights);
            this.groupBox1.Controls.Add(this.txtMeal);
            this.groupBox1.Controls.Add(this.labelDateArival);
            this.groupBox1.Controls.Add(this.labelDateDeparture);
            this.groupBox1.Controls.Add(this.labelHotel);
            this.groupBox1.Controls.Add(this.labelTransport);
            this.groupBox1.Controls.Add(this.labelMeal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelTourId);
            this.groupBox1.Controls.Add(this.txtTotalPrice);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 329);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тур";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ddlClients);
            this.groupBox2.Controls.Add(this.txtDiscount);
            this.groupBox2.Controls.Add(this.txtFio);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtFinalPrice);
            this.groupBox2.Location = new System.Drawing.Point(12, 347);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 131);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Клиент";
            // 
            // AddTripClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 516);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddTripClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "путешествие";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelTourId;
        private System.Windows.Forms.Label labelTransport;
        private System.Windows.Forms.Label labelHotel;
        private System.Windows.Forms.Label labelDateDeparture;
        private System.Windows.Forms.Label labelDateArival;
        private System.Windows.Forms.TextBox txtNights;
        private System.Windows.Forms.Label labelNights;
        private System.Windows.Forms.TextBox txtMealPrice;
        private System.Windows.Forms.Label labelMealPrice;
        private System.Windows.Forms.TextBox txtTransportPrice;
        private System.Windows.Forms.Label labelTransportPrice;
        private System.Windows.Forms.TextBox txtHotelPrice;
        private System.Windows.Forms.Label labelHotelPrice;
        private System.Windows.Forms.Label labelMeal;
        private System.Windows.Forms.ComboBox ddlClients;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFinalPrice;
        private System.Windows.Forms.TextBox txtTour;
        private System.Windows.Forms.TextBox txtMeal;
        private System.Windows.Forms.TextBox txtTransport;
        private System.Windows.Forms.TextBox txtHotel;
        private System.Windows.Forms.TextBox txtDateDeparture;
        private System.Windows.Forms.TextBox txtDateArival;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTripPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}