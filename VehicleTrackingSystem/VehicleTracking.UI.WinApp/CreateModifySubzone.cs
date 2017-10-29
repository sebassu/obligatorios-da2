using System;
using System.Collections.Generic;
using System.Drawing;
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
            InitializeComponent();
            IUnitOfWork unitOfWork = new UnitOfWork();
            SubzoneInstance = new SubzoneServices(unitOfWork);
            ZoneIntance = new ZoneServices(unitOfWork);
            CardPnl = cardPanel;
            Origin = origin;
            SelectedSubzone = selectedSubzone;
            LoadInfo();
        }

        private void LoadInfo()
        {
            LoadComboBox();
            if (Origin.Equals("modify"))
            {
                NameTxt.Text = SelectedSubzone.Name;
                CapacityTxt.Text = SelectedSubzone.Capacity.ToString();
                ZoneComboBox.SelectedItem = SelectedSubzone.ContainerName;
                TitleLbl.Text = "Modificar subzona";
                OkBtn.Text = "Modificar";
            }
            else
            {
                TitleLbl.Text = "Agregar subzona";
                OkBtn.Text = "Agregar";
            }
            
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
            CardPnl.Controls.Add(new SubzoneUserControl(CardPnl));
        }

        private void NameTxt_MouseClick(object sender, MouseEventArgs e)
        {
            NameTxt.Text = "";
            NameTxt.ForeColor = Color.Black;
        }

        private void CapacityTxt_MouseClick(object sender, MouseEventArgs e)
        {
            CapacityTxt.Text = "";
            CapacityTxt.ForeColor = Color.Black;
        }

        private void CapacityTxt_Leave(object sender, EventArgs e)
        {
            int cap;
            if (!int.TryParse(CapacityTxt.Text, out cap))
            {
                MessageBox.Show("La capacidad solo puede contener números", "Error");
                if (Origin.Equals("modify"))
                {
                    CapacityTxt.Text = SelectedSubzone.Capacity.ToString();
                }
                else
                {
                    CapacityTxt.Text = "";
                }
            }
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
                CardPnl.Controls.Clear();
                CardPnl.Controls.Add(new SubzoneUserControl(CardPnl));
            }
            catch (VehicleTrackingException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Debe seleccionar una zona", "Error");
            }
            catch (FormatException)
            {
                MessageBox.Show("Debe ingresar la capacidad con números", "Error");
            }
        }
    }
}
