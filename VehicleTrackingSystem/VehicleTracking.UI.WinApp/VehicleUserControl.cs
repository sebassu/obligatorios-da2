using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using API.Services;

namespace VehicleTracking.UI.WinApp
{
    public partial class VehicleUserControl : UserControl
    {
        IVehicleServices Instance;
        VehicleDTO SelectedVehicle;
        Panel CardPnl;

        public VehicleUserControl(Panel cardPnl)
        {
            InitializeComponent();
            Instance = new VehicleServices();
            CardPnl = cardPnl;
            LoadListBox();
        }

        private void LoadListBox()
        {            
            VehicleListBox.Items.Clear();
            IEnumerable<VehicleDTO> allVehicles = Instance.GetRegisteredVehicles();
            for (int i = 0; i < allVehicles.Count(); i++)
            {
                VehicleDTO aux = allVehicles.ElementAt(i);
                VehicleListBox.Items.Add(aux.VIN);
            }
        }

        private void VehicleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String VIN = VehicleListBox.GetItemText(VehicleListBox.SelectedItem);
            SelectedVehicle = Instance.GetVehicleWithVIN(VIN);
            VINLbl.Text = "VIN: " + SelectedVehicle.VIN;
            BrandLbl.Text = "Marca: " + SelectedVehicle.Brand;
            ModelLbl.Text = "Modelo: " + SelectedVehicle.Model;
            ColorLbl.Text = "Color: " + SelectedVehicle.Color;
            YearLbl.Text = "Año: " + SelectedVehicle.Year;
        }

        private void DeleteVehicleBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (VehicleListBox.SelectedItem != null)
            {
                try
                {
                    Instance.RemoveVehicleWithVIN(SelectedVehicle.VIN);
                    LoadListBox();
                    CleanLabels();
                }
                catch (VehicleTrackingException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un vehículo", "Error");
            }
        }

        private void CleanLabels()
        {
            VINLbl.Text = "VIN";
            BrandLbl.Text = "Marca";
            ModelLbl.Text = "Modelo";
            ColorLbl.Text = "Color";
            YearLbl.Text = "Año";
        }

        private void ModifyBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (VehicleListBox.SelectedItem != null)
            {
                CardPnl.Controls.Clear();
                CardPnl.Controls.Add(new CreateModifyVehicle(CardPnl,
                    "modify", SelectedVehicle));
            }
            else
            {
                MessageBox.Show("Debe seleccionar un vehículo", "Error");
            }
        }

        private void AddVehicleBtn_MouseClick(object sender, MouseEventArgs e)
        {
            CardPnl.Controls.Clear();
            CardPnl.Controls.Add(new CreateModifySubzone(CardPnl,
                "add", null));
        }
    }
}
