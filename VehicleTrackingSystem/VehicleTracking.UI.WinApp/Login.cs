using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistence;
using API.Services;

namespace VehicleTracking.UI.WinApp
{
    public partial class Login : UserControl
    { 
        Panel CardPanel;
        Panel ButtonsPanel;
        Panel LogoutPanel;

        public Login(Panel cardPanel, Panel buttonsPanel, Panel logoutPanel)
        {
            InitializeComponent();
            CardPanel = cardPanel;
            ButtonsPanel = buttonsPanel;
            LogoutPanel = logoutPanel;
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
                }
            }catch(ServiceException ex)
            {
                MessageBox.Show(ex.Message, "Error");
                PasswordTxt.Text = "";

            } catch (RepositoryException ex)
            {
                MessageBox.Show(ex.Message, "Error");
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
