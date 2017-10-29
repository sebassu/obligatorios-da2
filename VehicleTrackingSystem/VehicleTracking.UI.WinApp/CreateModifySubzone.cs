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
using Persistence;
using Domain;

namespace VehicleTracking.UI.WinApp
{
    public partial class CreateModifySubzone : UserControl
    {
        ISubzoneServices SubzoneInstance;
        IZoneServices ZoneIntance;
        SubzoneDTO SelectedSubzone;
        Panel CardPnl;
        string Origin;

        public CreateModifySubzone(Panel cardPanel, string origin, SubzoneDTO selectedSubzone)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            SubzoneInstance = new SubzoneServices(unitOfWork);
            ZoneIntance = new ZoneServices(unitOfWork);
            CardPnl = cardPanel;
            Origin = origin;
            SelectedSubzone = selectedSubzone;
            LoadInfo();
            InitializeComponent();
        }

        private void LoadInfo()
        {
            if (Origin.Equals("modify"))
            {
                NameTxt.Text = SelectedSubzone.Name;
                CapacityTxt.Text = SelectedSubzone.Capacity.ToString();
                TitleLbl.Text = "Modificar subzona";
                OkBtn.Text = "Modificar";
            }
            else
            {
                TitleLbl.Text = "Agregar subzona";
                OkBtn.Text = "Agregar";
            }
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            IEnumerable<ZoneDTO> aux = ZoneIntance.GetRegisteredZones();
            foreach (ZoneDTO zone in aux)
            {
                ZoneComboBox.Items.Add(zone.Name);
            }
        }

        private void CancelBtn_MouseClick(object sender, MouseEventArgs e)
        {
            CardPnl.Controls.Clear();
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

        private void OkBtn_MouseClick(object sender, MouseEventArgs e)
        {
            SubzoneDTO subzone = new SubzoneDTO();
            try
            {
                subzone.Name = NameTxt.Text;
                subzone.Capacity = int.Parse(CapacityTxt.Text);
                subzone.ContainerName = ZoneComboBox.SelectedItem.ToString();
                if (Origin.Equals("modify"))
                {
                    SubzoneInstance.ModifySubzoneWithId(SelectedSubzone.Id, subzone);
                }
                else
                {
                    SubzoneInstance.AddNewSubzoneFromData(subzone.ContainerName, subzone);

                }
            }
            catch (VehicleTrackingException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            CardPnl.Controls.Clear();
            CardPnl.Controls.Add(new SubzoneUserControl(CardPnl));
        }
    }
}
