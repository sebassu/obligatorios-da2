﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using API.Services;
using VehicleTracking_Data_Entities;

namespace VehicleTracking.UI.WinApp
{
    public partial class SubzoneUserControl : UserControl
    {
        ISubzoneServices Instance;
        Panel CardPnl;
        SubzoneDTO SelectedSubzone;

        public SubzoneUserControl(Panel cardPnl)
        {
            InitializeComponent();
            Instance = new SubzoneServices();
            CardPnl = cardPnl;
            LoadListBox();
        }

        private void LoadListBox()
        {
            SubzoneListBox.Items.Clear();
            IEnumerable<SubzoneDTO> allSubzones = Instance.GetRegisteredSubzones();
            for (int i = 0; i < allSubzones.Count(); i++)
            {
                SubzoneDTO aux = allSubzones.ElementAt(i);
                SubzoneListBox.Items.Add(aux.Id + "-" + aux.ContainerName + "/" + aux.Name);
            }
        }

        private void SubzoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] SelectedId =
                SubzoneListBox.GetItemText(SubzoneListBox.SelectedItem).Split('-');
            try
            {
                int id = int.Parse(SelectedId[0]);
                SelectedSubzone = Instance.GetSubzoneWithId(id);
                NameLbl.Text = "Nombre: " + SelectedSubzone.Name;
                CapacityLbl.Text = "Capacidad: " + SelectedSubzone.Capacity;
                ZoneLbl.Text = "Zona: " + SelectedSubzone.ContainerName;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe seleccionar una subzona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddSubzoneBtn_MouseClick(object sender, MouseEventArgs e)
        {
            CardPnl.Controls.Clear();
            CardPnl.Controls.Add(new CreateModifySubzone(CardPnl));
        }

        private void ModifyZoneBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (SubzoneListBox.SelectedItem != null)
            {
                CardPnl.Controls.Clear();
                CardPnl.Controls.Add(new CreateModifySubzone(CardPnl, SelectedSubzone));
            }
            else
            {
                MessageBox.Show("Debe seleccionar una subzona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteZoneBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (SubzoneListBox.SelectedItem != null)
            {
                try
                {
                    Instance.RemoveSubzoneWithId(SelectedSubzone.Id);
                    LoadListBox();
                    CleanLabels();
                }
                catch (VehicleTrackingException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una subzona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CleanLabels()
        {
            NameLbl.Text = "Nombre";
            CapacityLbl.Text = "Capacidad";
            ZoneLbl.Text = "Zona";
        }
    }
}