using System;
using System.Windows.Forms;

namespace VehicleTracking.UI.WinApp
{
    public partial class VehicleTrackingUI : Form
    {
        public VehicleTrackingUI()
        {
            InitializeComponent();
            ShowLogin();
            EnableMenuButtons();
        }


        private void EnableMenuButtons() {
            //esto deberia pasar si hay un usuario loggeado, sino no
            UserBtn.Enabled = true;
            VehicleBtn.Enabled = true;
            ZoneBtn.Enabled = true;
            SubzoneBtn.Enabled = true;
            FlowBtn.Enabled = true;
            LogsBtn.Enabled = true; 
        }

        private void ShowLogin()
        {
            cardPanel.Controls.Clear();
            cardPanel.Controls.Add(new Login());
        }

        private void UserBtn_MouseHover(object sender, EventArgs e)
        {
            UserBtn.FlatAppearance.BorderSize = 6;
        }

        private void UserBtn_MouseLeave(object sender, EventArgs e)
        {
            UserBtn.FlatAppearance.BorderSize = 0;
        }

        private void VehicleBtn_MouseHover(object sender, EventArgs e)
        {
            VehicleBtn.FlatAppearance.BorderSize = 6;
        }

        private void VehicleBtn_MouseLeave(object sender, EventArgs e)
        {
            VehicleBtn.FlatAppearance.BorderSize = 0;
        }

        private void ZoneBtn_MouseHover(object sender, EventArgs e)
        {
            ZoneBtn.FlatAppearance.BorderSize = 6;
        }

        private void ZoneBtn_MouseLeave(object sender, EventArgs e)
        {
            ZoneBtn.FlatAppearance.BorderSize = 0;
        }

        private void SubzoneBtn_MouseHover(object sender, EventArgs e)
        {
            SubzoneBtn.FlatAppearance.BorderSize = 6;
        }

        private void SubzoneBtn_MouseLeave(object sender, EventArgs e)
        {
            SubzoneBtn.FlatAppearance.BorderSize = 0;
        }

        private void FlowBtn_MouseHover(object sender, EventArgs e)
        {
            FlowBtn.FlatAppearance.BorderSize = 6;
        }

        private void FlowBtn_MouseLeave(object sender, EventArgs e)
        {
            FlowBtn.FlatAppearance.BorderSize = 0;
        }


        private void LogsBtn_MouseHover(object sender, EventArgs e)
        {
            LogsBtn.FlatAppearance.BorderSize = 6;
        }

        private void LogsBtn_MouseLeave(object sender, EventArgs e)
        {
            LogsBtn.FlatAppearance.BorderSize = 0;
        }

        private void UserBtn_MouseClick(object sender, MouseEventArgs e)
        {
            cardPanel.Controls.Clear();
            cardPanel.Controls.Add(new UserUserControl(cardPanel));
        }

        private void VehicleBtn_MouseClick(object sender, MouseEventArgs e)
        {
            cardPanel.Controls.Clear();
            cardPanel.Controls.Add(new VehicleUserControl(cardPanel));
        }

        private void ZoneBtn_MouseClick(object sender, MouseEventArgs e)
        {
            cardPanel.Controls.Clear();
            cardPanel.Controls.Add(new ZoneUserControl(cardPanel));
        }

        private void SubzoneBtn_MouseClick(object sender, MouseEventArgs e)
        {
            cardPanel.Controls.Clear();
            cardPanel.Controls.Add(new SubzoneUserControl(cardPanel));
        }
    }
}
