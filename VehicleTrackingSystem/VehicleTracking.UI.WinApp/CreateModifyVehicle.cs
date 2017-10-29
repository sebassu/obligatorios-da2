using System;
using System.Drawing;
using System.Windows.Forms;
using API.Services;
using Domain;

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
            InitializeComponent();
            Instance = new VehicleServices();
            CardPanel = cardPanel;
            Origin = origin;
            SelectedVehicle = selectedVehicle;

            LoadInfo();
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
                YearTxt.Text = SelectedVehicle.Year.ToString();
                OkBtn.Text = "Modificar";
            }
            else
            {
                TitleLbl.Text = "Agregar vehículo";
                OkBtn.Text = "Agregar";
            }
        }

        private void VINTxt_MouseClick(object sender, MouseEventArgs e)
        {
            VINTxt.Text = "";
            VINTxt.ForeColor = Color.Black;
        }

        private void BrandTxt_MouseClick(object sender, MouseEventArgs e)
        {
            BrandTxt.Text = "";
            BrandTxt.ForeColor = Color.Black;
        }

        private void ModelTxt_MouseClick(object sender, MouseEventArgs e)
        {
            ModelTxt.Text = "";
            ModelTxt.ForeColor = Color.Black;
        }

        private void ColorTxt_MouseClick(object sender, MouseEventArgs e)
        {
            ColorTxt.Text = "";
            ColorTxt.ForeColor = Color.Black;
        }

        private void YearTxt_MouseClick(object sender, MouseEventArgs e)
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

        private void CancelBtn_MouseClick(object sender, MouseEventArgs e)
        {
            CardPanel.Controls.Clear();
            CardPanel.Controls.Add(new VehicleUserControl(CardPanel));
        }

        private void OkBtn_MouseClick(object sender, MouseEventArgs e)
        {
            VehicleDTO vehicle = new VehicleDTO();
            try
            {
                vehicle.VIN = VINTxt.Text;
                vehicle.Brand = BrandTxt.Text;
                vehicle.Model = ModelTxt.Text;
                vehicle.Color = ColorTxt.Text;
                vehicle.Year = short.Parse(YearTxt.Text);
                if (Origin.Equals("modify"))
                {
                    Instance.ModifyVehicleWithVIN(SelectedVehicle.VIN, vehicle);
                }
                else
                {
                    Instance.AddNewVehicleFromData(vehicle);
                }
                CardPanel.Controls.Clear();
                CardPanel.Controls.Add(new VehicleUserControl(CardPanel));
            }
            catch (VehicleTrackingException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            catch (FormatException)
            {
                MessageBox.Show("El año no puede ser vacio", "Error");
            }
        }
    }
}

