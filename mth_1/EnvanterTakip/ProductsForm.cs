using System;
using System.Windows.Forms;
using System.Drawing;

namespace EnvanterTakip
{
    public partial class ProductsForm : Form
    {
        private Button btnAddStock = null!;
        private Button btnEditStock = null!;
        private Button btnDeleteStock = null!;
        private Button btnLogout = null!;
        private Label lblUsername = null!;
        private DataGridView dgvProducts = null!;
        private string currentUsername;
        private bool isLoggingOut = false;

        public ProductsForm(string username)
        {
            currentUsername = username;
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Form properties
            this.Font = new Font("Segoe UI", 9F);
            
            // Initialize username label
            lblUsername = new Label
            {
                Text = currentUsername,
                Location = new Point(542, 12),
                Size = new Size(120, 30),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight
            };

            // Initialize Logout button
            btnLogout = new Button
            {
                Text = "Logout",
                Location = new Point(672, 12),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F)
            };
            btnLogout.Click += BtnLogout_Click;

            // Initialize DataGridView
            dgvProducts = new DataGridView
            {
                Location = new Point(12, 50),
                Size = new Size(760, 450),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                Font = new Font("Segoe UI", 9F)
            };
            
            // Add columns to DataGridView
            var skuColumn = new DataGridViewTextBoxColumn
            {
                Name = "SKUName",
                HeaderText = "SKU  Name",
                HeaderCell = new DataGridViewColumnHeaderCell
                {
                    Style = new DataGridViewCellStyle
                    {
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                    }
                }
            };
            
            var productNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Product  Name",
                HeaderCell = new DataGridViewColumnHeaderCell
                {
                    Style = new DataGridViewCellStyle
                    {
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                    }
                }
            };
            
            var categoryColumn = new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Category",
                HeaderCell = new DataGridViewColumnHeaderCell
                {
                    Style = new DataGridViewCellStyle
                    {
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                    }
                }
            };
            
            var priceColumn = new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Price",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                HeaderCell = new DataGridViewColumnHeaderCell
                {
                    Style = new DataGridViewCellStyle
                    {
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                    }
                }
            };
            
            var quantityColumn = new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Available Quantity",
                HeaderCell = new DataGridViewColumnHeaderCell
                {
                    Style = new DataGridViewCellStyle
                    {
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                    }
                }
            };

            dgvProducts.Columns.AddRange(new DataGridViewColumn[] {
                skuColumn,
                productNameColumn,
                categoryColumn,
                priceColumn,
                quantityColumn
            });

            // Add CellFormatting event handler for the price column
            dgvProducts.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == priceColumn.Index && e.Value != null)
                {
                    e.Value = $"{e.Value:N2} TL";
                    e.FormattingApplied = true;
                }
            };

            // Initialize Add Stock button
            btnAddStock = new Button
            {
                Text = "Add Stock",
                Location = new Point(12, 12),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F)
            };
            btnAddStock.Click += BtnAddStock_Click;

            // Initialize Edit Stock button
            btnEditStock = new Button
            {
                Text = "Edit Stock",
                Location = new Point(122, 12),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F)
            };
            btnEditStock.Click += BtnEditStock_Click;

            // Initialize Delete Stock button
            btnDeleteStock = new Button
            {
                Text = "Delete Stock",
                Location = new Point(232, 12),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F)
            };
            btnDeleteStock.Click += BtnDeleteStock_Click;
            
            // Add controls to form
            this.Controls.AddRange(new Control[] { 
                dgvProducts,
                btnAddStock,
                btnEditStock,
                btnDeleteStock,
                btnLogout,
                lblUsername
            });
            
            // Form properties
            this.Size = new Size(800, 600);
            this.Text = "Inventory Management";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Add sample data
            AddSampleData();
        }

        private void AddSampleData()
        {
            dgvProducts.Rows.Add("LAP001", "Gaming Laptop", "Electronics", 1299.99, 5);
            dgvProducts.Rows.Add("MON001", "27\" Monitor", "Electronics", 299.99, 10);
            dgvProducts.Rows.Add("KEY001", "Mechanical Keyboard", "Electronics", 89.99, 15);
        }

        private void BtnAddStock_Click(object sender, EventArgs e)
        {
            using (var addStockForm = new AddStockForm())
            {
                if (addStockForm.ShowDialog() == DialogResult.OK)
                {
                    // Add new row to DataGridView
                    dgvProducts.Rows.Add(
                        addStockForm.SKUName,
                        addStockForm.ProductName,
                        addStockForm.Category,
                        addStockForm.Price,
                        addStockForm.Quantity
                    );

                    MessageBox.Show("Stock added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnEditStock_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to edit.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var addStockForm = new AddStockForm(isEdit: true))
            {
                var row = dgvProducts.SelectedRows[0];
                
                // Pre-fill the form with existing values
                addStockForm.PreFillData(
                    row.Cells["SKUName"].Value?.ToString() ?? "",
                    row.Cells["ProductName"].Value?.ToString() ?? "",
                    row.Cells["Category"].Value?.ToString() ?? "",
                    decimal.Parse(row.Cells["Price"].Value?.ToString()?.Replace(" TL", "") ?? "0"),
                    int.Parse(row.Cells["Quantity"].Value?.ToString() ?? "0")
                );

                if (addStockForm.ShowDialog() == DialogResult.OK)
                {
                    // Update the selected row
                    row.Cells["SKUName"].Value = addStockForm.SKUName;
                    row.Cells["ProductName"].Value = addStockForm.ProductName;
                    row.Cells["Category"].Value = addStockForm.Category;
                    row.Cells["Price"].Value = addStockForm.Price;
                    row.Cells["Quantity"].Value = addStockForm.Quantity;

                    MessageBox.Show("Stock updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnDeleteStock_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this product?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvProducts.Rows.RemoveAt(dgvProducts.SelectedRows[0].Index);
                MessageBox.Show("Stock deleted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isLoggingOut = true;
                this.Hide();
                this.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!isLoggingOut)
            {
                if (MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
