using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnvanterTakip
{
    public partial class AddStockForm : Form
    {
        private TextBox txtSKUName = null!;
        private TextBox txtProductName = null!;
        private ComboBox cmbCategory = null!;
        private TextBox txtPrice = null!;
        private TextBox txtQuantity = null!;
        private Button btnConfirm = null!;
        private Button btnCancel = null!;
        private Label label1 = null!;
        private Label label2 = null!;
        private Label label3 = null!;
        private Label label4 = null!;
        private Label label5 = null!;

        public string SKUName => txtSKUName.Text;
        public new string ProductName => txtProductName.Text;
        public string Category => cmbCategory.Text;
        public decimal Price => decimal.Parse(txtPrice.Text);
        public int Quantity => int.Parse(txtQuantity.Text);

        public AddStockForm(bool isEdit = false)
        {
            InitializeComponent();
            this.Text = isEdit ? "Edit Stock" : "Add Stock";
        }

        private void InitializeComponent()
        {
            // Form properties
            this.Text = "Add Stock";
            this.Size = new Size(400, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Initialize controls
            label1 = new Label
            {
                Text = "SKU Name:",
                Location = new Point(30, 30),
                Size = new Size(100, 20)
            };

            txtSKUName = new TextBox
            {
                Location = new Point(30, 50),
                Size = new Size(320, 20)
            };

            label2 = new Label
            {
                Text = "Product Name:",
                Location = new Point(30, 90),
                Size = new Size(100, 20)
            };

            txtProductName = new TextBox
            {
                Location = new Point(30, 110),
                Size = new Size(320, 20)
            };

            label3 = new Label
            {
                Text = "Category:",
                Location = new Point(30, 150),
                Size = new Size(100, 20)
            };

            cmbCategory = new ComboBox
            {
                Location = new Point(30, 170),
                Size = new Size(320, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCategory.Items.AddRange(new string[] {
                "Electronics",
                "Furniture",
                "Office Supplies",
                "Stationery",
                "Paper Products",
                "Desk Accessories",
                "Filing & Storage",
                "Writing Supplies",
                "Printer Supplies",
                "Other"
            });

            label4 = new Label
            {
                Text = "Price:",
                Location = new Point(30, 210),
                Size = new Size(100, 20)
            };

            txtPrice = new TextBox
            {
                Location = new Point(30, 230),
                Size = new Size(320, 20)
            };

            label5 = new Label
            {
                Text = "Quantity:",
                Location = new Point(30, 270),
                Size = new Size(100, 20)
            };

            txtQuantity = new TextBox
            {
                Location = new Point(30, 290),
                Size = new Size(320, 20)
            };

            btnConfirm = new Button
            {
                Text = "Confirm",
                DialogResult = DialogResult.OK,
                Location = new Point(30, 350),
                Size = new Size(150, 30),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White
            };

            btnCancel = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(200, 350),
                Size = new Size(150, 30),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White
            };

            // Add controls to form
            this.Controls.AddRange(new Control[] {
                label1, txtSKUName,
                label2, txtProductName,
                label3, cmbCategory,
                label4, txtPrice,
                label5, txtQuantity,
                btnConfirm, btnCancel
            });

            // Set accept and cancel buttons
            this.AcceptButton = btnConfirm;
            this.CancelButton = btnCancel;
        }

        public void PreFillData(string skuName, string productName, string category, decimal price, int quantity)
        {
            txtSKUName.Text = skuName;
            txtProductName.Text = productName;
            cmbCategory.Text = category;
            txtPrice.Text = price.ToString();
            txtQuantity.Text = quantity.ToString();
        }
    }
} 