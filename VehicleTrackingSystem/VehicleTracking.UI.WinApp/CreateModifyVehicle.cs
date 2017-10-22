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
    public partial class CreateModifyVehicle : UserControl
    {

        Panel CardPanel;
        VehicleDTO SelectedVehicle;
        string Origin;
        IVehicleServices Instance;

        public CreateModifyVehicle(Panel cardPanel, string origin, VehicleDTO selectedVehicle)
        {
            CardPanel = cardPanel;
            Origin = origin;
            SelectedVehicle = selectedVehicle;
            LoadInfo();
            Instance = new VehicleServices();
            InitializeComponent();
        }

        private void LoadInfo()
        {
            if (Origin.Equals("modify"))
            {
                TitleLbl.Text = "Modificar vehículo";
                VINTxt.Text = SelectedVehicle.VIN;
                BrandTxt.Text = SelectedVehicle.Brand;
                ModelTxt.Text = SelectedVehicle.Model;
                ColorTxt.Text = SelectedVehicle.Color;
                YearTxt.Text =  SelectedVehicle.Year.ToString();
                OkBtn.Text = "Modificar";
            }else
            {
                TitleLbl.Text = "Agregar vehículo";
                OkBtn.Text = "Agregar";
            }
        }

        private void VINTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            VINTxt.Text = "";
            VINTxt.ForeColor = Color.Black;
        }

        private void BrandTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            BrandTxt.Text = "";
            BrandTxt.ForeColor = Color.Black;
        }

        private void ModelTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ModelTxt.Text = "";
            ModelTxt.ForeColor = Color.Black;
        }

        private void ColorTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ColorTxt.Text = "";
            ColorTxt.ForeColor = Color.Black;
        }

        private void YearTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            YearTxt.Text = "";
            YearTxt.ForeColor = Color.Black;
        }

        private void YearTxt_Leave(object sender, EventArgs e)
        {
            short year;
            if (!short.TryParse(YearTxt.Text, out year))
            {
                MessageBox.Show("El año solo puede contener números", "Error");
                if (Origin.Equals("modify"))
                {
                    YearTxt.Text = SelectedVehicle.Year.ToString();
                }
                else
                {
                    YearTxt.Text = "";
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            CardPanel.Controls.Clear();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            VehicleDTO vehicle = new VehicleDTO();
            vehicle.VIN = VINTxt.Text;
            vehicle.Brand = BrandTxt.Text;
            vehicle.Model = ModelTxt.Text;
            vehicle.Color = ColorTxt.Text;
            vehicle.Year = short.Parse(YearTxt.Text);
            if (Origin.Equals("modify"))
            {
                Instance.ModifyVehicleWithVIN(VINTxt.Text, vehicle);
            }
            else
            {
                Instance.AddNewVehicleFromData(vehicle);
            }
            CardPanel.Controls.Clear();
            CardPanel.Controls.Add(new VehicleUserControl(CardPanel));
        }
    }
}
