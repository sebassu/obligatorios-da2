using System.Windows.Forms;
using VehicleTracking_Data_DataAccess;
using API.Services;
using System;
using VehicleTracking_Data_Entities;

namespace VehicleTracking.UI.WinApp
{
    public partial class Login : UserControl
    {
        Panel CardPanel;
        Panel ButtonsPanel;
        Panel LogoutPanel;
        IUnitOfWork Instance;

        public Login(Panel cardPanel, Panel buttonsPanel, Panel logoutPanel)
        {
            InitializeComponent();
            CardPanel = cardPanel;
            ButtonsPanel = buttonsPanel;
            LogoutPanel = logoutPanel;
            Instance = new UnitOfWork();
        }

        private void LoginBtn_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                bool couldLogIn = SessionServices.LogIn(UsernameTxt.Text, PasswordTxt.Text);
                if (couldLogIn)
                {
                    ShowButtons();
                    ShowLogOut();
                    CardPanel.Controls.Clear();
                    Instance.LoggingStrategy.RegisterUserLogin(SessionServices.LoggedUser);
                    Instance.SaveChanges();
                }
            }
            catch (VehicleTrackingException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTxt.Text = "";
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTxt.Text = "";
            }
        }

        private void ShowButtons()
        {
            ButtonsPanel.Controls.Clear();
            ButtonsPanel.Controls.Add(new MenuButtonsUserControl(CardPanel));
        }

        private void ShowLogOut()
        {
            LogoutPanel.Controls.Clear();
            LogoutPanel.Controls.Add(new LogOutUserControl(CardPanel, ButtonsPanel, LogoutPanel));
        }
    }
}