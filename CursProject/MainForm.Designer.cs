using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CursProject
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.toursTab = new System.Windows.Forms.TabPage();
            this.tourGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteTour = new System.Windows.Forms.Button();
            this.btnEditTour = new System.Windows.Forms.Button();
            this.btnAddTour = new System.Windows.Forms.Button();
            this.excursionsTab = new System.Windows.Forms.TabPage();
            this.excursionGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteExcursion = new System.Windows.Forms.Button();
            this.btnEditExcursion = new System.Windows.Forms.Button();
            this.btnAddExcursion = new System.Windows.Forms.Button();
            this.mealsTab = new System.Windows.Forms.TabPage();
            this.mealGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteMeal = new System.Windows.Forms.Button();
            this.btnEditMeal = new System.Windows.Forms.Button();
            this.btnAddMeal = new System.Windows.Forms.Button();
            this.transportsTab = new System.Windows.Forms.TabPage();
            this.transportGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteTransport = new System.Windows.Forms.Button();
            this.btnEditTransport = new System.Windows.Forms.Button();
            this.btnAddTransport = new System.Windows.Forms.Button();
            this.hotelsTab = new System.Windows.Forms.TabPage();
            this.hotelGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteHotel = new System.Windows.Forms.Button();
            this.btnEditHotel = new System.Windows.Forms.Button();
            this.btnAddHotel = new System.Windows.Forms.Button();
            this.discountsTab = new System.Windows.Forms.TabPage();
            this.discountGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteDiscount = new System.Windows.Forms.Button();
            this.btnEditDiscount = new System.Windows.Forms.Button();
            this.btnAddDiscount = new System.Windows.Forms.Button();
            this.clientsTab = new System.Windows.Forms.TabPage();
            this.clientGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.btnEditClient = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.tripsTab = new System.Windows.Forms.TabPage();
            this.tripGrid = new System.Windows.Forms.DataGridView();
            this.btnDeleteTrip = new System.Windows.Forms.Button();
            this.btnEditTrip = new System.Windows.Forms.Button();
            this.btnAddTrip = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.toursTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tourGrid)).BeginInit();
            this.excursionsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.excursionGrid)).BeginInit();
            this.mealsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mealGrid)).BeginInit();
            this.transportsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transportGrid)).BeginInit();
            this.hotelsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hotelGrid)).BeginInit();
            this.discountsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discountGrid)).BeginInit();
            this.clientsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientGrid)).BeginInit();
            this.tripsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tripGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.toursTab);
            this.tabControl.Controls.Add(this.excursionsTab);
            this.tabControl.Controls.Add(this.tripsTab);
            this.tabControl.Controls.Add(this.clientsTab);
            this.tabControl.Controls.Add(this.discountsTab);
            this.tabControl.Controls.Add(this.mealsTab);
            this.tabControl.Controls.Add(this.transportsTab);
            this.tabControl.Controls.Add(this.hotelsTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(792, 573);
            this.tabControl.TabIndex = 0;
            // 
            // toursTab
            // 
            this.toursTab.Controls.Add(this.tourGrid);
            this.toursTab.Controls.Add(this.btnDeleteTour);
            this.toursTab.Controls.Add(this.btnEditTour);
            this.toursTab.Controls.Add(this.btnAddTour);
            this.toursTab.Location = new System.Drawing.Point(4, 22);
            this.toursTab.Name = "toursTab";
            this.toursTab.Padding = new System.Windows.Forms.Padding(3);
            this.toursTab.Size = new System.Drawing.Size(784, 547);
            this.toursTab.TabIndex = 0;
            this.toursTab.Text = "Туры";
            this.toursTab.UseVisualStyleBackColor = true;
            // 
            // tourGrid
            // 
            this.tourGrid.AllowUserToAddRows = false;
            this.tourGrid.AllowUserToDeleteRows = false;
            this.tourGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tourGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tourGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tourGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.tourGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tourGrid.Location = new System.Drawing.Point(8, 6);
            this.tourGrid.Name = "tourGrid";
            this.tourGrid.ReadOnly = true;
            this.tourGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tourGrid.Size = new System.Drawing.Size(768, 504);
            this.tourGrid.TabIndex = 0;
            this.tourGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tourGrid_CellDoubleClick);
            // 
            // btnDeleteTour
            // 
            this.btnDeleteTour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTour.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteTour.Name = "btnDeleteTour";
            this.btnDeleteTour.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTour.TabIndex = 3;
            this.btnDeleteTour.Text = "Удалить";
            this.btnDeleteTour.UseVisualStyleBackColor = true;
            this.btnDeleteTour.Click += new System.EventHandler(this.btnDeleteTour_Click);
            // 
            // btnEditTour
            // 
            this.btnEditTour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTour.Location = new System.Drawing.Point(620, 516);
            this.btnEditTour.Name = "btnEditTour";
            this.btnEditTour.Size = new System.Drawing.Size(75, 23);
            this.btnEditTour.TabIndex = 2;
            this.btnEditTour.Text = "Изменить";
            this.btnEditTour.UseVisualStyleBackColor = true;
            this.btnEditTour.Click += new System.EventHandler(this.btnEditTour_Click);
            // 
            // btnAddTour
            // 
            this.btnAddTour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTour.Location = new System.Drawing.Point(539, 516);
            this.btnAddTour.Name = "btnAddTour";
            this.btnAddTour.Size = new System.Drawing.Size(75, 23);
            this.btnAddTour.TabIndex = 1;
            this.btnAddTour.Text = "Добавить";
            this.btnAddTour.UseVisualStyleBackColor = true;
            this.btnAddTour.Click += new System.EventHandler(this.btnAddTour_Click);
            // 
            // excursionsTab
            // 
            this.excursionsTab.Controls.Add(this.excursionGrid);
            this.excursionsTab.Controls.Add(this.btnDeleteExcursion);
            this.excursionsTab.Controls.Add(this.btnEditExcursion);
            this.excursionsTab.Controls.Add(this.btnAddExcursion);
            this.excursionsTab.Location = new System.Drawing.Point(4, 22);
            this.excursionsTab.Name = "excursionsTab";
            this.excursionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.excursionsTab.Size = new System.Drawing.Size(784, 547);
            this.excursionsTab.TabIndex = 1;
            this.excursionsTab.Text = "Экскурсии";
            this.excursionsTab.UseVisualStyleBackColor = true;
            // 
            // excursionGrid
            // 
            this.excursionGrid.AllowUserToAddRows = false;
            this.excursionGrid.AllowUserToDeleteRows = false;
            this.excursionGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.excursionGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.excursionGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excursionGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.excursionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.excursionGrid.Location = new System.Drawing.Point(8, 6);
            this.excursionGrid.Name = "excursionGrid";
            this.excursionGrid.ReadOnly = true;
            this.excursionGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.excursionGrid.Size = new System.Drawing.Size(768, 504);
            this.excursionGrid.TabIndex = 4;
            // 
            // btnDeleteExcursion
            // 
            this.btnDeleteExcursion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteExcursion.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteExcursion.Name = "btnDeleteExcursion";
            this.btnDeleteExcursion.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteExcursion.TabIndex = 7;
            this.btnDeleteExcursion.Text = "Удалить";
            this.btnDeleteExcursion.UseVisualStyleBackColor = true;
            this.btnDeleteExcursion.Click += new System.EventHandler(this.btnDeleteExcursion_Click);
            // 
            // btnEditExcursion
            // 
            this.btnEditExcursion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditExcursion.Location = new System.Drawing.Point(620, 516);
            this.btnEditExcursion.Name = "btnEditExcursion";
            this.btnEditExcursion.Size = new System.Drawing.Size(75, 23);
            this.btnEditExcursion.TabIndex = 6;
            this.btnEditExcursion.Text = "Изменить";
            this.btnEditExcursion.UseVisualStyleBackColor = true;
            this.btnEditExcursion.Click += new System.EventHandler(this.btnEditExcursion_Click);
            // 
            // btnAddExcursion
            // 
            this.btnAddExcursion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddExcursion.Location = new System.Drawing.Point(539, 516);
            this.btnAddExcursion.Name = "btnAddExcursion";
            this.btnAddExcursion.Size = new System.Drawing.Size(75, 23);
            this.btnAddExcursion.TabIndex = 5;
            this.btnAddExcursion.Text = "Добавить";
            this.btnAddExcursion.UseVisualStyleBackColor = true;
            this.btnAddExcursion.Click += new System.EventHandler(this.btnAddExcursion_Click);
            // 
            // mealsTab
            // 
            this.mealsTab.Controls.Add(this.mealGrid);
            this.mealsTab.Controls.Add(this.btnDeleteMeal);
            this.mealsTab.Controls.Add(this.btnEditMeal);
            this.mealsTab.Controls.Add(this.btnAddMeal);
            this.mealsTab.Location = new System.Drawing.Point(4, 22);
            this.mealsTab.Name = "mealsTab";
            this.mealsTab.Padding = new System.Windows.Forms.Padding(3);
            this.mealsTab.Size = new System.Drawing.Size(784, 547);
            this.mealsTab.TabIndex = 1;
            this.mealsTab.Text = "Питание";
            this.mealsTab.UseVisualStyleBackColor = true;
            // 
            // mealGrid
            // 
            this.mealGrid.AllowUserToAddRows = false;
            this.mealGrid.AllowUserToDeleteRows = false;
            this.mealGrid.AllowUserToOrderColumns = true;
            this.mealGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.mealGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mealGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.mealGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mealGrid.Location = new System.Drawing.Point(8, 6);
            this.mealGrid.Name = "mealGrid";
            this.mealGrid.ReadOnly = true;
            this.mealGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mealGrid.Size = new System.Drawing.Size(768, 504);
            this.mealGrid.TabIndex = 4;
            // 
            // btnDeleteMeal
            // 
            this.btnDeleteMeal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteMeal.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteMeal.Name = "btnDeleteMeal";
            this.btnDeleteMeal.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMeal.TabIndex = 7;
            this.btnDeleteMeal.Text = "Удалить";
            this.btnDeleteMeal.UseVisualStyleBackColor = true;
            this.btnDeleteMeal.Click += new System.EventHandler(this.btnDeleteMeal_Click);
            // 
            // btnEditMeal
            // 
            this.btnEditMeal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditMeal.Location = new System.Drawing.Point(620, 516);
            this.btnEditMeal.Name = "btnEditMeal";
            this.btnEditMeal.Size = new System.Drawing.Size(75, 23);
            this.btnEditMeal.TabIndex = 6;
            this.btnEditMeal.Text = "Изменить";
            this.btnEditMeal.UseVisualStyleBackColor = true;
            this.btnEditMeal.Click += new System.EventHandler(this.btnEditMeal_Click);
            // 
            // btnAddMeal
            // 
            this.btnAddMeal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMeal.Location = new System.Drawing.Point(539, 516);
            this.btnAddMeal.Name = "btnAddMeal";
            this.btnAddMeal.Size = new System.Drawing.Size(75, 23);
            this.btnAddMeal.TabIndex = 5;
            this.btnAddMeal.Text = "Добавить";
            this.btnAddMeal.UseVisualStyleBackColor = true;
            this.btnAddMeal.Click += new System.EventHandler(this.btnAddMeal_Click);
            // 
            // transportsTab
            // 
            this.transportsTab.Controls.Add(this.transportGrid);
            this.transportsTab.Controls.Add(this.btnDeleteTransport);
            this.transportsTab.Controls.Add(this.btnEditTransport);
            this.transportsTab.Controls.Add(this.btnAddTransport);
            this.transportsTab.Location = new System.Drawing.Point(4, 22);
            this.transportsTab.Name = "transportsTab";
            this.transportsTab.Padding = new System.Windows.Forms.Padding(3);
            this.transportsTab.Size = new System.Drawing.Size(784, 547);
            this.transportsTab.TabIndex = 1;
            this.transportsTab.Text = "Транпорт";
            this.transportsTab.UseVisualStyleBackColor = true;
            // 
            // transportGrid
            // 
            this.transportGrid.AllowUserToAddRows = false;
            this.transportGrid.AllowUserToDeleteRows = false;
            this.transportGrid.AllowUserToOrderColumns = true;
            this.transportGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.transportGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.transportGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.transportGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transportGrid.Location = new System.Drawing.Point(8, 6);
            this.transportGrid.Name = "transportGrid";
            this.transportGrid.ReadOnly = true;
            this.transportGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.transportGrid.Size = new System.Drawing.Size(768, 504);
            this.transportGrid.TabIndex = 4;
            // 
            // btnDeleteTransport
            // 
            this.btnDeleteTransport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTransport.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteTransport.Name = "btnDeleteTransport";
            this.btnDeleteTransport.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTransport.TabIndex = 7;
            this.btnDeleteTransport.Text = "Удалить";
            this.btnDeleteTransport.UseVisualStyleBackColor = true;
            this.btnDeleteTransport.Click += new System.EventHandler(this.btnDeleteTransport_Click);
            // 
            // btnEditTransport
            // 
            this.btnEditTransport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTransport.Location = new System.Drawing.Point(620, 516);
            this.btnEditTransport.Name = "btnEditTransport";
            this.btnEditTransport.Size = new System.Drawing.Size(75, 23);
            this.btnEditTransport.TabIndex = 6;
            this.btnEditTransport.Text = "Изменить";
            this.btnEditTransport.UseVisualStyleBackColor = true;
            this.btnEditTransport.Click += new System.EventHandler(this.btnEditTransport_Click);
            // 
            // btnAddTransport
            // 
            this.btnAddTransport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTransport.Location = new System.Drawing.Point(539, 516);
            this.btnAddTransport.Name = "btnAddTransport";
            this.btnAddTransport.Size = new System.Drawing.Size(75, 23);
            this.btnAddTransport.TabIndex = 5;
            this.btnAddTransport.Text = "Добавить";
            this.btnAddTransport.UseVisualStyleBackColor = true;
            this.btnAddTransport.Click += new System.EventHandler(this.btnAddTransport_Click);
            // 
            // hotelsTab
            // 
            this.hotelsTab.Controls.Add(this.hotelGrid);
            this.hotelsTab.Controls.Add(this.btnDeleteHotel);
            this.hotelsTab.Controls.Add(this.btnEditHotel);
            this.hotelsTab.Controls.Add(this.btnAddHotel);
            this.hotelsTab.Location = new System.Drawing.Point(4, 22);
            this.hotelsTab.Name = "hotelsTab";
            this.hotelsTab.Padding = new System.Windows.Forms.Padding(3);
            this.hotelsTab.Size = new System.Drawing.Size(784, 547);
            this.hotelsTab.TabIndex = 1;
            this.hotelsTab.Text = "Отели";
            this.hotelsTab.UseVisualStyleBackColor = true;
            // 
            // hotelGrid
            // 
            this.hotelGrid.AllowUserToAddRows = false;
            this.hotelGrid.AllowUserToDeleteRows = false;
            this.hotelGrid.AllowUserToOrderColumns = true;
            this.hotelGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.hotelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hotelGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.hotelGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hotelGrid.Location = new System.Drawing.Point(8, 6);
            this.hotelGrid.Name = "hotelGrid";
            this.hotelGrid.ReadOnly = true;
            this.hotelGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hotelGrid.Size = new System.Drawing.Size(768, 504);
            this.hotelGrid.TabIndex = 4;
            // 
            // btnDeleteHotel
            // 
            this.btnDeleteHotel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteHotel.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteHotel.Name = "btnDeleteHotel";
            this.btnDeleteHotel.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteHotel.TabIndex = 7;
            this.btnDeleteHotel.Text = "Удалить";
            this.btnDeleteHotel.UseVisualStyleBackColor = true;
            this.btnDeleteHotel.Click += new System.EventHandler(this.btnDeleteHotel_Click);
            // 
            // btnEditHotel
            // 
            this.btnEditHotel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditHotel.Location = new System.Drawing.Point(620, 516);
            this.btnEditHotel.Name = "btnEditHotel";
            this.btnEditHotel.Size = new System.Drawing.Size(75, 23);
            this.btnEditHotel.TabIndex = 6;
            this.btnEditHotel.Text = "Изменить";
            this.btnEditHotel.UseVisualStyleBackColor = true;
            this.btnEditHotel.Click += new System.EventHandler(this.btnEditHotel_Click);
            // 
            // btnAddHotel
            // 
            this.btnAddHotel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddHotel.Location = new System.Drawing.Point(539, 516);
            this.btnAddHotel.Name = "btnAddHotel";
            this.btnAddHotel.Size = new System.Drawing.Size(75, 23);
            this.btnAddHotel.TabIndex = 5;
            this.btnAddHotel.Text = "Добавить";
            this.btnAddHotel.UseVisualStyleBackColor = true;
            this.btnAddHotel.Click += new System.EventHandler(this.btnAddHotel_Click);
            // 
            // discountsTab
            // 
            this.discountsTab.Controls.Add(this.discountGrid);
            this.discountsTab.Controls.Add(this.btnDeleteDiscount);
            this.discountsTab.Controls.Add(this.btnEditDiscount);
            this.discountsTab.Controls.Add(this.btnAddDiscount);
            this.discountsTab.Location = new System.Drawing.Point(4, 22);
            this.discountsTab.Name = "discountsTab";
            this.discountsTab.Padding = new System.Windows.Forms.Padding(3);
            this.discountsTab.Size = new System.Drawing.Size(784, 547);
            this.discountsTab.TabIndex = 1;
            this.discountsTab.Text = "Скидки";
            this.discountsTab.UseVisualStyleBackColor = true;
            // 
            // discountGrid
            // 
            this.discountGrid.AllowUserToAddRows = false;
            this.discountGrid.AllowUserToDeleteRows = false;
            this.discountGrid.AllowUserToOrderColumns = true;
            this.discountGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.discountGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.discountGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.discountGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.discountGrid.Location = new System.Drawing.Point(8, 6);
            this.discountGrid.Name = "discountGrid";
            this.discountGrid.ReadOnly = true;
            this.discountGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.discountGrid.Size = new System.Drawing.Size(768, 504);
            this.discountGrid.TabIndex = 4;
            // 
            // btnDeleteDiscount
            // 
            this.btnDeleteDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDiscount.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteDiscount.Name = "btnDeleteDiscount";
            this.btnDeleteDiscount.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDiscount.TabIndex = 7;
            this.btnDeleteDiscount.Text = "Удалить";
            this.btnDeleteDiscount.UseVisualStyleBackColor = true;
            this.btnDeleteDiscount.Click += new System.EventHandler(this.btnDeleteDiscount_Click);
            // 
            // btnEditDiscount
            // 
            this.btnEditDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditDiscount.Location = new System.Drawing.Point(620, 516);
            this.btnEditDiscount.Name = "btnEditDiscount";
            this.btnEditDiscount.Size = new System.Drawing.Size(75, 23);
            this.btnEditDiscount.TabIndex = 6;
            this.btnEditDiscount.Text = "Изменить";
            this.btnEditDiscount.UseVisualStyleBackColor = true;
            this.btnEditDiscount.Click += new System.EventHandler(this.btnEditDiscount_Click);
            // 
            // btnAddDiscount
            // 
            this.btnAddDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDiscount.Location = new System.Drawing.Point(539, 516);
            this.btnAddDiscount.Name = "btnAddDiscount";
            this.btnAddDiscount.Size = new System.Drawing.Size(75, 23);
            this.btnAddDiscount.TabIndex = 5;
            this.btnAddDiscount.Text = "Добавить";
            this.btnAddDiscount.UseVisualStyleBackColor = true;
            this.btnAddDiscount.Click += new System.EventHandler(this.btnAddDiscount_Click);
            // 
            // clientsTab
            // 
            this.clientsTab.Controls.Add(this.clientGrid);
            this.clientsTab.Controls.Add(this.btnDeleteClient);
            this.clientsTab.Controls.Add(this.btnEditClient);
            this.clientsTab.Controls.Add(this.btnAddClient);
            this.clientsTab.Location = new System.Drawing.Point(4, 22);
            this.clientsTab.Name = "clientsTab";
            this.clientsTab.Padding = new System.Windows.Forms.Padding(3);
            this.clientsTab.Size = new System.Drawing.Size(784, 547);
            this.clientsTab.TabIndex = 1;
            this.clientsTab.Text = "Клиенты";
            this.clientsTab.UseVisualStyleBackColor = true;
            // 
            // clientGrid
            // 
            this.clientGrid.AllowUserToAddRows = false;
            this.clientGrid.AllowUserToDeleteRows = false;
            this.clientGrid.AllowUserToOrderColumns = true;
            this.clientGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.clientGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.clientGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientGrid.Location = new System.Drawing.Point(8, 6);
            this.clientGrid.Name = "clientGrid";
            this.clientGrid.ReadOnly = true;
            this.clientGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientGrid.Size = new System.Drawing.Size(768, 504);
            this.clientGrid.TabIndex = 4;
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteClient.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteClient.TabIndex = 7;
            this.btnDeleteClient.Text = "Удалить";
            this.btnDeleteClient.UseVisualStyleBackColor = true;
            this.btnDeleteClient.Click += new System.EventHandler(this.btnDeleteClient_Click);
            // 
            // btnEditClient
            // 
            this.btnEditClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditClient.Location = new System.Drawing.Point(620, 516);
            this.btnEditClient.Name = "btnEditClient";
            this.btnEditClient.Size = new System.Drawing.Size(75, 23);
            this.btnEditClient.TabIndex = 6;
            this.btnEditClient.Text = "Изменить";
            this.btnEditClient.UseVisualStyleBackColor = true;
            this.btnEditClient.Click += new System.EventHandler(this.btnEditClient_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddClient.Location = new System.Drawing.Point(539, 516);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(75, 23);
            this.btnAddClient.TabIndex = 5;
            this.btnAddClient.Text = "Добавить";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // tripsTab
            // 
            this.tripsTab.Controls.Add(this.tripGrid);
            this.tripsTab.Controls.Add(this.btnDeleteTrip);
            this.tripsTab.Controls.Add(this.btnEditTrip);
            this.tripsTab.Controls.Add(this.btnAddTrip);
            this.tripsTab.Location = new System.Drawing.Point(4, 22);
            this.tripsTab.Name = "tripsTab";
            this.tripsTab.Padding = new System.Windows.Forms.Padding(3);
            this.tripsTab.Size = new System.Drawing.Size(784, 547);
            this.tripsTab.TabIndex = 1;
            this.tripsTab.Text = "Путешествия";
            this.tripsTab.UseVisualStyleBackColor = true;
            // 
            // tripGrid
            // 
            this.tripGrid.AllowUserToAddRows = false;
            this.tripGrid.AllowUserToDeleteRows = false;
            this.tripGrid.AllowUserToOrderColumns = true;
            this.tripGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tripGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tripGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.tripGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tripGrid.Location = new System.Drawing.Point(8, 6);
            this.tripGrid.Name = "tripGrid";
            this.tripGrid.ReadOnly = true;
            this.tripGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tripGrid.Size = new System.Drawing.Size(768, 504);
            this.tripGrid.TabIndex = 4;
            // 
            // btnDeleteTrip
            // 
            this.btnDeleteTrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTrip.Location = new System.Drawing.Point(701, 516);
            this.btnDeleteTrip.Name = "btnDeleteTrip";
            this.btnDeleteTrip.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTrip.TabIndex = 7;
            this.btnDeleteTrip.Text = "Удалить";
            this.btnDeleteTrip.UseVisualStyleBackColor = true;
            this.btnDeleteTrip.Click += new System.EventHandler(this.btnDeleteTrip_Click);
            // 
            // btnEditTrip
            // 
            this.btnEditTrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTrip.Location = new System.Drawing.Point(620, 516);
            this.btnEditTrip.Name = "btnEditTrip";
            this.btnEditTrip.Size = new System.Drawing.Size(75, 23);
            this.btnEditTrip.TabIndex = 6;
            this.btnEditTrip.Text = "Изменить";
            this.btnEditTrip.UseVisualStyleBackColor = true;
            this.btnEditTrip.Click += new System.EventHandler(this.btnEditTrip_Click);
            // 
            // btnAddTrip
            // 
            this.btnAddTrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTrip.Location = new System.Drawing.Point(539, 516);
            this.btnAddTrip.Name = "btnAddTrip";
            this.btnAddTrip.Size = new System.Drawing.Size(75, 23);
            this.btnAddTrip.TabIndex = 5;
            this.btnAddTrip.Text = "Добавить";
            this.btnAddTrip.UseVisualStyleBackColor = true;
            this.btnAddTrip.Click += new System.EventHandler(this.btnAddTrip_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Система учёта клиентов";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl.ResumeLayout(false);
            this.toursTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tourGrid)).EndInit();
            this.excursionsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.excursionGrid)).EndInit();
            this.mealsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mealGrid)).EndInit();
            this.transportsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.transportGrid)).EndInit();
            this.hotelsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hotelGrid)).EndInit();
            this.discountsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.discountGrid)).EndInit();
            this.clientsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientGrid)).EndInit();
            this.tripsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tripGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage toursTab;
        private System.Windows.Forms.DataGridView tourGrid;
        private System.Windows.Forms.Button btnDeleteTour;
        private System.Windows.Forms.Button btnEditTour;
        private System.Windows.Forms.Button btnAddTour;

        private int TourSortColumn = 0;
        private SortOrder TourSortOrder = SortOrder.None;
        private string FilterTourFio = "";

        private TabPage excursionsTab;
        private DataGridView excursionGrid;
        private Button btnDeleteExcursion;
        private Button btnEditExcursion;
        private Button btnAddExcursion;

        private TabPage mealsTab;
        private DataGridView mealGrid;
        private Button btnDeleteMeal;
        private Button btnEditMeal;
        private Button btnAddMeal;

        private TabPage transportsTab;
        private DataGridView transportGrid;
        private Button btnDeleteTransport;
        private Button btnEditTransport;
        private Button btnAddTransport;

        private TabPage hotelsTab;
        private DataGridView hotelGrid;
        private Button btnDeleteHotel;
        private Button btnEditHotel;
        private Button btnAddHotel;

        private TabPage discountsTab;
        private DataGridView discountGrid;
        private Button btnDeleteDiscount;
        private Button btnEditDiscount;
        private Button btnAddDiscount;

        private TabPage clientsTab;
        private DataGridView clientGrid;
        private Button btnDeleteClient;
        private Button btnEditClient;
        private Button btnAddClient;   

        private TabPage tripsTab;
        private DataGridView tripGrid;
        private Button btnDeleteTrip;
        private Button btnEditTrip;
        private Button btnAddTrip;
    }
}

