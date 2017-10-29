using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using API.Services;

namespace VehicleTracking.UI.WinApp
{
    public partial class ZoneUserControl : UserControl
    {

        Panel CardPnl;
        ZoneDTO SelectedZone;
        IZoneServices Instance;

        public ZoneUserControl(Panel cardPanel)
        {
            InitializeComponent();
            Instance = new ZoneServices();
            CardPnl = cardPanel;
            LoadListBox();
        }

        private void LoadListBox()
        {
            ZoneListBox.Items.Clear();
            IEnumerable<ZoneDTO> allZones = Instance.GetRegisteredZones();
            for (int i = 0; i < allZones.Count(); i++)
            {
                ZoneDTO aux = allZones.ElementAt(i);
                ZoneListBox.Items.Add(aux.Name);
            }
        }

        private void ZoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = ZoneListBox.GetItemText(ZoneListBox.SelectedItem);
            SelectedZone = Instance.GetZoneWithName(name);
            NameLbl.Text = SelectedZone.Name;
            CapacityLbl.Text = "Capacidad: " + SelectedZone.Capacity;
            SubzonesLbl.Text = "Cant. subzonas: " + SelectedZone.SubzoneIds.Count;
        }

        private void DeleteZoneBtn_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (ZoneListBox.SelectedItem != null)
                {
                    Instance.RemoveZoneWithName(SelectedZone.Name);
                    LoadListBox();
                    CleanLabels();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una zona", "Error");
                }
            }
            catch(ServiceException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void CleanLabels()
        {
            NameLbl.Text = "Nombre";
            CapacityLbl.Text = "Capacidad";
            SubzonesLbl.Text = "Subzonas";
        }

        private void AddZoneBtn_MouseClick(object sender, MouseEventArgs e)
        {
            CardPnl.Controls.Clear();
            CardPnl.Controls.Add(new CreateModifyZone(CardPnl,
                "add", null));
        }

        private void ModifyZoneBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (ZoneListBox.SelectedItem != null)
            {
                CardPnl.Controls.Clear();
                CardPnl.Controls.Add(new CreateModifyZone(CardPnl,
                    "modify", SelectedZone));
            }
            else
            {
                MessageBox.Show("Debe seleccionar una zona", "Error");
            }
        }
    }
}
