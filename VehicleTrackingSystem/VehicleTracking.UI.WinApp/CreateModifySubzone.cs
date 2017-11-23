using API.Services;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;
using System;

namespace VehicleTracking.UI.WinApp
{
    public partial class CreateModifySubzone : UserControl
    {
        private ISubzoneServices subzones;
        private IZoneServices zones;
        private SubzoneDTO subzoneToModify;
        private Panel CardPnl;
        private bool openedForModification;

        public CreateModifySubzone(Panel cardPanel,
            SubzoneDTO selectedSubzone = null)
        {
            InitializeComponent();
            SetServicesObjects();
            CardPnl = cardPanel;
            openedForModification = Utilities.IsNotNull(selectedSubzone);
            subzoneToModify = selectedSubzone;
            LoadComponentInformation();
        }

        private void SetServicesObjects()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            subzones = new SubzoneServices(unitOfWork);
            zones = new ZoneServices(unitOfWork);
        }

        private void LoadComponentInformation()
        {
            LoadComboBox();
            if (openedForModification)
            {
                SetModificationInformation();
            }
            else
            {
                SetAdditionLabels();
            }
        }

        private void SetModificationInformation()
        {
            NameTxt.Text = subzoneToModify.Name;
            CapacityNud.Value = subzoneToModify.Capacity;
            ZoneComboBox.SelectedItem = subzoneToModify.ContainerName;
            TitleLbl.Text = "Modificar subzona";
            OkBtn.Text = "Modificar";
        }

        private void SetAdditionLabels()
        {
            TitleLbl.Text = "Agregar subzona";
            OkBtn.Text = "Agregar";
        }

        private void LoadComboBox()
        {
            IEnumerable<ZoneDTO> registeredZones =
                zones.GetRegisteredZones();
            foreach (ZoneDTO zone in registeredZones)
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

        private void OkBtn_MouseClick(object sender, MouseEventArgs e)
        {
            SubzoneDTO subzone = new SubzoneDTO();
            try
            {
                subzone.Name = NameTxt.Text;
                subzone.Capacity = (int)CapacityNud.Value;
                subzone.ContainerName = ZoneComboBox.SelectedItem.ToString();
                if (openedForModification)
                {
                    subzones.ModifySubzoneWithId(subzoneToModify.Id, subzone);
                }
                else
                {
                    subzones.AddNewSubzoneFromData(subzone.ContainerName, subzone);
                }
            }
            catch (VehicleTrackingException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Debe seleccionar una zona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformAdditionModificationAction()
        {
            SubzoneDTO subzoneData = GetSubzoneDataToSet();
            if (openedForModification)
            {
                subzones.ModifySubzoneWithId(subzoneToModify.Id, subzoneData);
            }
            else
            {
                subzones.AddNewSubzoneFromData(subzoneData.ContainerName, subzoneData);
            }
        }

        private SubzoneDTO GetSubzoneDataToSet()
        {
            return new SubzoneDTO
            {
                Name = NameTxt.Text,
                Capacity = (int)CapacityNud.Value,
                ContainerName = ZoneComboBox.SelectedItem.ToString()
            };
        }
    }
}