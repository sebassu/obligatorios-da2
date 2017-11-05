using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Services;

namespace VehicleTracking.UI.WinApp
{
    public partial class LogOutUserControl : UserControl
    {
        Panel CardPanel;
        Panel ButtonsPanel;
        Panel LogoutPanel;

        public LogOutUserControl(Panel cardPanel, Panel buttonsPanel, Panel logoutPanel)
        {
            InitializeComponent();
            LogOutBtn.Visible = true;
            LogOutBtn.Enabled = true;
            CardPanel = cardPanel;
            ButtonsPanel = buttonsPanel;
            LogoutPanel = logoutPanel;
        }

        private void LogOutBtn_MouseClick(object sender, MouseEventArgs e)
        {
            SessionServices.LoggedUser = null;
            LogOutBtn.Visible = false;
            LogOutBtn.Enabled = false;
            CardPanel.Controls.Clear();
            CardPanel.Controls.Add(new Login(CardPanel, ButtonsPanel, LogoutPanel));     
        }
    }
}
