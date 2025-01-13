using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnvanterTakip
{
    public partial class LoginForm : Form
    {
        private TextBox txtUsername = null!;
        private TextBox txtPassword = null!;
        private Button btnLogin = null!;
        private Label lblEmail = null!;
        private Label lblPassword = null!;
        private Label lblTitle = null!;
        private Panel mainPanel = null!;

        public string Username => txtUsername.Text;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Form style
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(500, 600);
            this.Text = "Login";

            // Main Panel
            mainPanel = new Panel
            {
                BackColor = Color.White,
                Size = new Size(400, 450),
                Location = new Point((this.ClientSize.Width - 400) / 2, 20),
                BorderStyle = BorderStyle.None
            };

            // Title
            lblTitle = new Label
            {
                Text = "BITS",
                Font = new Font("Segoe UI", 24, FontStyle.Regular),
                ForeColor = Color.FromArgb(16, 93, 140),
                AutoSize = true,
                Location = new Point((mainPanel.Width - 100) / 2, 50)
            };

            // Username Label
            lblEmail = new Label
            {
                Text = "Username",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(73, 80, 87),
                Location = new Point(50, 120),
                AutoSize = true
            };

            // Username TextBox
            txtUsername = new TextBox
            {
                Location = new Point(50, 150),
                Size = new Size(300, 35),
                Font = new Font("Segoe UI", 12),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Password Label
            lblPassword = new Label
            {
                Text = "Password",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(73, 80, 87),
                Location = new Point(50, 200),
                AutoSize = true
            };

            // Password TextBox
            txtPassword = new TextBox
            {
                Location = new Point(50, 230),
                Size = new Size(300, 35),
                Font = new Font("Segoe UI", 12),
                PasswordChar = '•',
                BorderStyle = BorderStyle.FixedSingle
            };

            // Login Button
            btnLogin = new Button
            {
                Text = "Login",
                Location = new Point(50, 300),
                Size = new Size(300, 45),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(16, 93, 140),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Cursor = Cursors.Hand
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += new EventHandler(btnLogin_Click);

            // Add controls to panel
            mainPanel.Controls.AddRange(new Control[] {
                lblTitle,
                lblEmail,
                txtUsername,
                lblPassword,
                txtPassword,
                btnLogin
            });

            // Add panel to form
            this.Controls.Add(mainPanel);

            // Set accept button
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "1234")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 