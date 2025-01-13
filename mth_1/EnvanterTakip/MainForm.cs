using System;
using System.Windows.Forms;

namespace EnvanterTakip
{
    public partial class MainForm : Form
    {
        private ProductsForm? currentProductsForm;
        private bool isClosing = false;

        public MainForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            ShowLoginForm();
        }

        private void ShowLoginForm()
        {
            if (isClosing) return;

            var loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) =>
            {
                if (loginForm.DialogResult == DialogResult.OK)
                {
                    ShowProductsForm(loginForm.Username);
                }
                else
                {
                    isClosing = true;
                    Application.Exit();
                }
            };

            loginForm.Show();
        }

        private void ShowProductsForm(string username)
        {
            if (isClosing) return;

            if (currentProductsForm != null && !currentProductsForm.IsDisposed)
            {
                currentProductsForm.Close();
            }

            currentProductsForm = new ProductsForm(username);
            currentProductsForm.FormClosed += (s, args) => 
            {
                currentProductsForm = null;
                if (!isClosing)
                {
                    ShowLoginForm();
                }
            };
            currentProductsForm.Show();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(false);
        }
    }
} 