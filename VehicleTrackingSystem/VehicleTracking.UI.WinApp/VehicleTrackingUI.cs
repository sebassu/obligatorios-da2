using Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleTracking.UI.WinApp
{
    public partial class VehicleTrackingUI : Form
    {
        public VehicleTrackingUI()
        {
            ShowLogin();
            EnableMenuButtons();
            InitializeComponent();
        }


        private void EnableMenuButtons() {
            //esto deberia pasar si hay un usuario loggeado, sino no
            VehicleBtn.Enabled = true;
            VehicleBtn.Visible = true;
            ZoneBtn.Enabled = true;
            ZoneBtn.Visible = true;
            SubzoneBtn.Enabled = true;
            SubzoneBtn.Visible = true;
            FlowBtn.Enabled = true;
            FlowBtn.Visible = true;
        }

        private void ShowLogin()
        {
            cardPanel.Controls.Clear();
            cardPanel.Controls.Add(new Login());
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

        private void VehicleBtn_Click(object sender, EventArgs e)
        {
            cardPanel.Controls.Clear();
            cardPanel.Controls.Add(new VehicleUserControl(cardPanel));
        }
    }
}
