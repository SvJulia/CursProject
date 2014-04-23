namespace CursProject.Form
{
    partial class AddTripForm
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
            this.labelMeal = new System.Windows.Forms.Label();
            this.labelTransport = new System.Windows.Forms.Label();
            this.labelHotel = new System.Windows.Forms.Label();
            this.labelDateDeparture = new System.Windows.Forms.Label();
            this.labelDateArival = new System.Windows.Forms.Label();
            this.labelNights = new System.Windows.Forms.Label();
            this.txtNights = new System.Windows.Forms.TextBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.labelTourPrice = new System.Windows.Forms.Label();
            this.txtTourPrice = new System.Windows.Forms.TextBox();
            this.labelMealPrice = new System.Windows.Forms.Label();
            this.txtMealPrice = new System.Windows.Forms.TextBox();
            this.labelTransportPrice = new System.Windows.Forms.Label();
            this.txtTransportPrice = new System.Windows.Forms.TextBox();
            this.labelHotelPrice = new System.Windows.Forms.Label();
            this.txtHotelPrice = new System.Windows.Forms.TextBox();
            this.ddlTours = new System.Windows.Forms.ComboBox();
            this.ddlMeals = new System.Windows.Forms.ComboBox();
            this.ddlTransports = new System.Windows.Forms.ComboBox();
            this.ddlHotels = new System.Windows.Forms.ComboBox();
            this.dtpDateDeparture = new System.Windows.Forms.DateTimePicker();
            this.dtpDateArival = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(260, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(179, 319);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelTourId
            // 
            this.labelTourId.AutoSize = true;
            this.labelTourId.Location = new System.Drawing.Point(110, 7);
            this.labelTourId.Name = "labelTourId";
            this.labelTourId.Size = new System.Drawing.Size(31, 13);
            this.labelTourId.TabIndex = 6;
            this.labelTourId.Text = "Тур: ";
            // 
            // labelMeal
            // 
            this.labelMeal.AutoSize = true;
            this.labelMeal.Location = new System.Drawing.Point(85, 33);
            this.labelMeal.Name = "labelMeal";
            this.labelMeal.Size = new System.Drawing.Size(56, 13);
            this.labelMeal.TabIndex = 6;
            this.labelMeal.Text = "Питание: ";
            // 
            // labelTransport
            // 
            this.labelTransport.AutoSize = true;
            this.labelTransport.Location = new System.Drawing.Point(74, 59);
            this.labelTransport.Name = "labelTransport";
            this.labelTransport.Size = new System.Drawing.Size(67, 13);
            this.labelTransport.TabIndex = 6;
            this.labelTransport.Text = "Транспорт: ";
            // 
            // labelHotel
            // 
            this.labelHotel.AutoSize = true;
            this.labelHotel.Location = new System.Drawing.Point(97, 85);
            this.labelHotel.Name = "labelHotel";
            this.labelHotel.Size = new System.Drawing.Size(44, 13);
            this.labelHotel.TabIndex = 6;
            this.labelHotel.Text = "Отель: ";
            // 
            // labelDateDeparture
            // 
            this.labelDateDeparture.AutoSize = true;
            this.labelDateDeparture.Location = new System.Drawing.Point(57, 111);
            this.labelDateDeparture.Name = "labelDateDeparture";
            this.labelDateDeparture.Size = new System.Drawing.Size(84, 13);
            this.labelDateDeparture.TabIndex = 6;
            this.labelDateDeparture.Text = "Дата отбытия: ";
            // 
            // labelDateArival
            // 
            this.labelDateArival.AutoSize = true;
            this.labelDateArival.Location = new System.Drawing.Point(50, 137);
            this.labelDateArival.Name = "labelDateArival";
            this.labelDateArival.Size = new System.Drawing.Size(91, 13);
            this.labelDateArival.TabIndex = 6;
            this.labelDateArival.Text = "Дата прибытия: ";
            // 
            // labelNights
            // 
            this.labelNights.AutoSize = true;
            this.labelNights.Location = new System.Drawing.Point(62, 163);
            this.labelNights.Name = "labelNights";
            this.labelNights.Size = new System.Drawing.Size(79, 13);
            this.labelNights.TabIndex = 6;
            this.labelNights.Text = "Кол-во ночей: ";
            // 
            // txtNights
            // 
            this.txtNights.Location = new System.Drawing.Point(147, 160);
            this.txtNights.MaxLength = 255;
            this.txtNights.Name = "txtNights";
            this.txtNights.Size = new System.Drawing.Size(188, 20);
            this.txtNights.TabIndex = 7;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(51, 189);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(90, 13);
            this.labelAmount.TabIndex = 6;
            this.labelAmount.Text = "Кол-во путёвок: ";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(147, 186);
            this.txtAmount.MaxLength = 255;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(188, 20);
            this.txtAmount.TabIndex = 8;
            // 
            // labelTourPrice
            // 
            this.labelTourPrice.AutoSize = true;
            this.labelTourPrice.Location = new System.Drawing.Point(48, 215);
            this.labelTourPrice.Name = "labelTourPrice";
            this.labelTourPrice.Size = new System.Drawing.Size(93, 13);
            this.labelTourPrice.TabIndex = 6;
            this.labelTourPrice.Text = "Стоимость тура: ";
            // 
            // txtTourPrice
            // 
            this.txtTourPrice.Location = new System.Drawing.Point(147, 212);
            this.txtTourPrice.MaxLength = 255;
            this.txtTourPrice.Name = "txtTourPrice";
            this.txtTourPrice.Size = new System.Drawing.Size(188, 20);
            this.txtTourPrice.TabIndex = 9;
            // 
            // labelMealPrice
            // 
            this.labelMealPrice.AutoSize = true;
            this.labelMealPrice.Location = new System.Drawing.Point(29, 241);
            this.labelMealPrice.Name = "labelMealPrice";
            this.labelMealPrice.Size = new System.Drawing.Size(112, 13);
            this.labelMealPrice.TabIndex = 6;
            this.labelMealPrice.Text = "Стоимость питания: ";
            // 
            // txtMealPrice
            // 
            this.txtMealPrice.Location = new System.Drawing.Point(147, 238);
            this.txtMealPrice.MaxLength = 255;
            this.txtMealPrice.Name = "txtMealPrice";
            this.txtMealPrice.Size = new System.Drawing.Size(188, 20);
            this.txtMealPrice.TabIndex = 10;
            // 
            // labelTransportPrice
            // 
            this.labelTransportPrice.AutoSize = true;
            this.labelTransportPrice.Location = new System.Drawing.Point(12, 267);
            this.labelTransportPrice.Name = "labelTransportPrice";
            this.labelTransportPrice.Size = new System.Drawing.Size(129, 13);
            this.labelTransportPrice.TabIndex = 6;
            this.labelTransportPrice.Text = "Стоимость транспорта: ";
            // 
            // txtTransportPrice
            // 
            this.txtTransportPrice.Location = new System.Drawing.Point(147, 264);
            this.txtTransportPrice.MaxLength = 255;
            this.txtTransportPrice.Name = "txtTransportPrice";
            this.txtTransportPrice.Size = new System.Drawing.Size(188, 20);
            this.txtTransportPrice.TabIndex = 11;
            // 
            // labelHotelPrice
            // 
            this.labelHotelPrice.AutoSize = true;
            this.labelHotelPrice.Location = new System.Drawing.Point(41, 293);
            this.labelHotelPrice.Name = "labelHotelPrice";
            this.labelHotelPrice.Size = new System.Drawing.Size(100, 13);
            this.labelHotelPrice.TabIndex = 6;
            this.labelHotelPrice.Text = "Стоимость отеля: ";
            // 
            // txtHotelPrice
            // 
            this.txtHotelPrice.Location = new System.Drawing.Point(147, 290);
            this.txtHotelPrice.MaxLength = 255;
            this.txtHotelPrice.Name = "txtHotelPrice";
            this.txtHotelPrice.Size = new System.Drawing.Size(188, 20);
            this.txtHotelPrice.TabIndex = 12;
            // 
            // ddlTours
            // 
            this.ddlTours.FormattingEnabled = true;
            this.ddlTours.Location = new System.Drawing.Point(147, 4);
            this.ddlTours.Name = "ddlTours";
            this.ddlTours.Size = new System.Drawing.Size(188, 21);
            this.ddlTours.TabIndex = 13;
            // 
            // ddlMeals
            // 
            this.ddlMeals.FormattingEnabled = true;
            this.ddlMeals.Location = new System.Drawing.Point(147, 30);
            this.ddlMeals.Name = "ddlMeals";
            this.ddlMeals.Size = new System.Drawing.Size(188, 21);
            this.ddlMeals.TabIndex = 14;
            // 
            // ddlTransports
            // 
            this.ddlTransports.FormattingEnabled = true;
            this.ddlTransports.Location = new System.Drawing.Point(147, 56);
            this.ddlTransports.Name = "ddlTransports";
            this.ddlTransports.Size = new System.Drawing.Size(188, 21);
            this.ddlTransports.TabIndex = 15;
            // 
            // ddlHotels
            // 
            this.ddlHotels.FormattingEnabled = true;
            this.ddlHotels.Location = new System.Drawing.Point(147, 82);
            this.ddlHotels.Name = "ddlHotels";
            this.ddlHotels.Size = new System.Drawing.Size(188, 21);
            this.ddlHotels.TabIndex = 16;
            // 
            // dtpDateDeparture
            // 
            this.dtpDateDeparture.Location = new System.Drawing.Point(147, 108);
            this.dtpDateDeparture.Name = "dtpDateDeparture";
            this.dtpDateDeparture.Size = new System.Drawing.Size(188, 20);
            this.dtpDateDeparture.TabIndex = 17;
            // 
            // dtpDateArival
            // 
            this.dtpDateArival.Location = new System.Drawing.Point(147, 134);
            this.dtpDateArival.Name = "dtpDateArival";
            this.dtpDateArival.Size = new System.Drawing.Size(188, 20);
            this.dtpDateArival.TabIndex = 18;
            // 
            // AddTripForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 348);
            this.Controls.Add(this.dtpDateArival);
            this.Controls.Add(this.dtpDateDeparture);
            this.Controls.Add(this.ddlHotels);
            this.Controls.Add(this.ddlTransports);
            this.Controls.Add(this.ddlMeals);
            this.Controls.Add(this.ddlTours);
            this.Controls.Add(this.labelTourId);
            this.Controls.Add(this.labelMeal);
            this.Controls.Add(this.labelTransport);
            this.Controls.Add(this.labelHotel);
            this.Controls.Add(this.labelDateDeparture);
            this.Controls.Add(this.labelDateArival);
            this.Controls.Add(this.txtNights);
            this.Controls.Add(this.labelNights);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.txtTourPrice);
            this.Controls.Add(this.labelTourPrice);
            this.Controls.Add(this.txtMealPrice);
            this.Controls.Add(this.labelMealPrice);
            this.Controls.Add(this.txtTransportPrice);
            this.Controls.Add(this.labelTransportPrice);
            this.Controls.Add(this.txtHotelPrice);
            this.Controls.Add(this.labelHotelPrice);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddTripForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "путешествие";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelTourId;
        private System.Windows.Forms.Label labelMeal;
        private System.Windows.Forms.Label labelTransport;
        private System.Windows.Forms.Label labelHotel;
        private System.Windows.Forms.Label labelDateDeparture;
        private System.Windows.Forms.Label labelDateArival;
        private System.Windows.Forms.TextBox txtNights;
        private System.Windows.Forms.Label labelNights;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.TextBox txtTourPrice;
        private System.Windows.Forms.Label labelTourPrice;
        private System.Windows.Forms.TextBox txtMealPrice;
        private System.Windows.Forms.Label labelMealPrice;
        private System.Windows.Forms.TextBox txtTransportPrice;
        private System.Windows.Forms.Label labelTransportPrice;
        private System.Windows.Forms.TextBox txtHotelPrice;
        private System.Windows.Forms.Label labelHotelPrice;
        private System.Windows.Forms.ComboBox ddlTours;
        private System.Windows.Forms.ComboBox ddlMeals;
        private System.Windows.Forms.ComboBox ddlTransports;
        private System.Windows.Forms.ComboBox ddlHotels;
        private System.Windows.Forms.DateTimePicker dtpDateDeparture;
        private System.Windows.Forms.DateTimePicker dtpDateArival;

    }
}