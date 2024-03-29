﻿using System;
using System.Drawing;
using System.Windows.Forms;
using API.Services;
using VehicleTracking_Data_Entities;

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
            ShowImport();
        }

        private void LoadInfo()
        {
            LoadComboBox();
            if (Origin.Equals("modify"))
            {
                TitleLbl.Text = "Modificar vehículo";
                VINTxt.Text = SelectedVehicle.VIN;
                BrandTxt.Text = SelectedVehicle.Brand;
                ModelTxt.Text = SelectedVehicle.Model;
                ColorTxt.Text = SelectedVehicle.Color;
                YearTxt.Text = SelectedVehicle.Year.ToString();
                OkBtn.Text = "Modificar";
                TypeComboBox.Enabled = false;
                TypeComboBox.SelectedText = SelectedVehicle.Type.ToString();
            }
            else
            {
                TitleLbl.Text = "Agregar vehículo";
                OkBtn.Text = "Agregar";
                TypeComboBox.Enabled = true;
            }
        }

        private void LoadComboBox()
        {
            var types = Enum.GetNames(typeof(VehicleType));
            foreach (string type in types)
            {
                TypeComboBox.Items.Add(type);
            }
        }

        private void ShowImport()
        {
            if (Origin.Equals("modify"))
            {
                ImportBtn.Enabled = false;
                ImportBtn.Visible = false;
            }
            else
            {
                ImportBtn.Enabled = true;
                ImportBtn.Visible = true;
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
                MessageBox.Show("El año solo puede contener números", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    vehicle.Type = SelectedVehicle.Type;
                    Instance.ModifyVehicleWithVIN(SelectedVehicle.VIN, vehicle);
                }
                else
                {
                    vehicle.Type = (VehicleType)TypeComboBox.SelectedIndex;
                    Instance.AddNewVehicleFromData(vehicle);
                }
                CardPanel.Controls.Clear();
                CardPanel.Controls.Add(new VehicleUserControl(CardPanel));
            }
            catch (VehicleTrackingException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("El año no puede ser vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportBtn_MouseClick(object sender, MouseEventArgs e)
        {
            CardPanel.Controls.Clear();
            CardPanel.Controls.Add(new ImportVehiclesUserControl(CardPanel));

        }
    }
}

