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
using Domain;

namespace VehicleTracking.UI.WinApp
{
    public partial class CreateModifyZone : UserControl
    {

        ZoneDTO SelectedZone;
        IZoneServices Instance;
        Panel CardPnl;
        string Origin;

        public CreateModifyZone(Panel cardPnl, string origin, ZoneDTO selectedZone)
        {
            Instance = new ZoneServices();
            CardPnl = cardPnl;
            Origin = origin;
            SelectedZone = selectedZone;
            LoadInfo();
            InitializeComponent();
        }

        private void LoadInfo()
        {
            if (Origin.Equals("modify"))
            {
                NameLbl.Text = SelectedZone.Name;
                CapacityLbl.Text = SelectedZone.Capacity.ToString();
                TitleLbl.Text = "Modificar zona";
                OkBtn.Text = "Modificar";
            }
            else
            {
                TitleLbl.Text = "Agregar zona";
                OkBtn.Text = "Agregar";
            }
        }

        private void NameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            NameTxt.Text = "";
            NameTxt.ForeColor = Color.Black;
        }

        private void CapacityTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            CapacityTxt.Text = "";
            CapacityTxt.ForeColor = Color.Black;
        }

        private void CapacityTxt_Leave(object sender, EventArgs e)
        {
            int cap;
            if(!int.TryParse(CapacityTxt.Text, out cap))
            {
                MessageBox.Show("La capacidad solo puede contener números", "Error");
                if (Origin.Equals("modify"))
                {
                    CapacityTxt.Text = SelectedZone.Capacity.ToString();
                }
                else
                {
                    CapacityTxt.Text = "";
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            CardPnl.Controls.Clear();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            ZoneDTO zone = new ZoneDTO();
            try
            {
                zone.Name = NameTxt.Text;
                zone.Capacity = int.Parse(CapacityTxt.Text);
                if (Origin.Equals("modify"))
                {
                    Instance.ModifyZoneWithName(NameTxt.Text, zone);
                }
                else
                {
                    Instance.AddNewZoneFromData(zone);
                }
            }
            catch (VehicleTrackingException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            CardPnl.Controls.Clear();
            CardPnl.Controls.Add(new ZoneUserControl(CardPnl));
        }
    }
}
