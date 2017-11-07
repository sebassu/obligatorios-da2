using API.Services;
using System;
using System.Windows.Forms;

namespace VehicleTracking.UI.WinApp
{
    public partial class VehicleTrackingForm : Form
    {
        public VehicleTrackingForm()
        {
            InitializeComponent();
            ShowLogin();
            ShowButtons();
        }

        private void ShowLogin()
        {
            cardPanel.Controls.Clear();
            cardPanel.Controls.Add(new Login(cardPanel, buttonsPanel, logoutPanel));
        }

        private void ShowButtons()
        {
            buttonsPanel.Controls.Clear();
            buttonsPanel.Controls.Add(new MenuButtonsUserControl(cardPanel));
        }
    }
}
