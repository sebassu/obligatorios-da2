using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleTracking_Data_DataAccess;
using API.Services;

namespace VehicleTracking.UI.WinApp
{
    public partial class Login : UserControl
    { 
        Panel CardPanel;
        Panel ButtonsPanel;

        public Login(Panel cardPanel, Panel buttonsPanel)
        {
            CardPanel = cardPanel;
            ButtonsPanel = buttonsPanel;
            InitializeComponent();
        }

        private void LoginBtn_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                bool couldLogIn = SessionServices.LogIn(UsernameTxt.Text, PasswordTxt.Text);
                if (couldLogIn)
                {
                    ShowButtons();   
                }
            }catch(ServiceException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            } catch (RepositoryException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void ShowButtons()
        {
            ButtonsPanel.Controls.Clear();
            ButtonsPanel.Controls.Add(new MenuButtonsUserControl(CardPanel));
            CardPanel.Controls.Clear();
        }
    }
}
