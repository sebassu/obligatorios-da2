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
    public partial class MenuButtonsUserControl : UserControl
    {

        Panel CardPanel;

        public MenuButtonsUserControl(Panel cardPanel)
        {
            InitializeComponent();
            CardPanel = cardPanel;
            EnableDisableButtons();
        }

        private void EnableDisableButtons()
        {
            if (SessionServices.LoggedUser != null)
            {
                EnableMenuButtons();
            }else
            {
                DisableMenuButtons();
            }
        }

        private void DisableMenuButtons()
        {
            UserBtn.Enabled = false;
            UserBtn.Visible = false;
            VehicleBtn.Enabled = false;
            VehicleBtn.Visible = false;
            ZoneBtn.Enabled = false;
            ZoneBtn.Visible = false;
            SubzoneBtn.Enabled = false;
            SubzoneBtn.Visible = false;
            FlowBtn.Enabled = false;
            FlowBtn.Visible = false;
            LogsBtn.Enabled = false;
            LogsBtn.Visible = false;
        }

        private void EnableMenuButtons()
        {
            UserBtn.Enabled = true;
            UserBtn.Visible = true;
            VehicleBtn.Enabled = true;
            VehicleBtn.Visible = true;
            ZoneBtn.Enabled = true;
            ZoneBtn.Visible = true;
            SubzoneBtn.Enabled = true;
            SubzoneBtn.Visible = true;
            FlowBtn.Enabled = true;
            FlowBtn.Visible = true;
            LogsBtn.Enabled = true;
            LogsBtn.Visible = true;
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
            CardPanel.Controls.Clear();
            CardPanel.Controls.Add(new UserUserControl(CardPanel));
        }

        private void VehicleBtn_MouseClick(object sender, MouseEventArgs e)
        {
            CardPanel.Controls.Clear();
            CardPanel.Controls.Add(new VehicleUserControl(CardPanel));
        }

        private void ZoneBtn_MouseClick(object sender, MouseEventArgs e)
        {
            CardPanel.Controls.Clear();
            CardPanel.Controls.Add(new ZoneUserControl(CardPanel));
        }

        private void SubzoneBtn_MouseClick(object sender, MouseEventArgs e)
        {
            CardPanel.Controls.Clear();
            CardPanel.Controls.Add(new SubzoneUserControl(CardPanel));
        }

        private void FlowBtn_MouseClick(object sender, MouseEventArgs e)
        {
            CardPanel.Controls.Clear();
            CardPanel.Controls.Add(new SaleFlowUserControl(CardPanel));
        }

        private void LogsBtn_MouseClick(object sender, MouseEventArgs e)
        {
            CardPanel.Controls.Clear();
            CardPanel.Controls.Add(new LogsUserControl());
        }
    }
}
