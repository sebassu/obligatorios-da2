using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using API.Services;
using Domain;

namespace VehicleTracking.UI.WinApp
{
    public partial class SaleFlowUserControl : UserControl
    {
        ISubzoneServices Instance;
        string SelectedSubzoneNameToAdd;
        string SelectedSubzoneNameToRemove;
        Panel CardPanel;
        private List<string> AvailableSubzones;
        private List<string> SubzonesForFlow;
        private IEnumerable<string> SavedSubzones;

        public SaleFlowUserControl(Panel cardPanel)
        {
            InitializeComponent();
            CardPanel = cardPanel;
            Instance = new SubzoneServices();
            SavedSubzones = GetDistinctSubzones();
            AvailableSubzones = SavedSubzones.ToList();
            SubzonesForFlow = new List<string>();
            NewSubzoneTxt.Enabled = false;
            LoadListBoxDynamicAvailableSubzone(AvailableSubzones);
        }

        public IEnumerable<string> GetDistinctSubzones()
        {
            IEnumerable<string> allDistinctSubzones = new List<string>();
            if (SavedSubzones == null)
            {
                allDistinctSubzones = Instance.GetRegisteredSubzones().Select(s => s.Name).Distinct();
            }
            return allDistinctSubzones;
        }

        private void LoadListBoxDynamicAvailableSubzone(List<string> list)
        {
            availableSubzonesListBox.Items.Clear();
            foreach (string aux in list)
            {
                availableSubzonesListBox.Items.Add(aux);
            }
        }

        private void NotExistingSubzoneCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (NotExistingSubzoneCheckBox.Checked)
            {
                NewSubzoneTxt.Enabled = true;
            }
            else
            {
                NewSubzoneTxt.Enabled = false;
            }
        }

        private void AddBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (NotExistingSubzoneCheckBox.Checked)
            {
                AddSubzone(NewSubzoneTxt.Text);
            }
            else
            {
                AttemptToAddSubzone();
            }
        }

        private void RemoveBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (SavedSubzones.Contains(SelectedSubzoneNameToRemove))
            {
                AddRemoveSubzone(SelectedSubzoneNameToRemove, SubzonesForFlow, AvailableSubzones);
            }else
            {
                RemoveSubzone(SelectedSubzoneNameToRemove);
            }
        }

        private void AddSubzone(string name)
        {
            if (ValidateName(name))
            {
                if (!SavedSubzones.Contains(name))
                {
                    SubzonesForFlow.Add(name);
                    LoadListBoxDynamicNewSubzone(SubzonesForFlow);
                }else
                {
                    MessageBox.Show("La subzona '" + NewSubzoneTxt.Text
                    + "' ya se encuentra en el flujo", "Error");                   
                }
                NotExistingSubzoneCheckBox.Checked = false;
                NewSubzoneTxt.Text = "";
            }
        }

        private void RemoveSubzone(string name)
        {
            SubzonesForFlow.Remove(name);
            LoadListBoxDynamicNewSubzone(SubzonesForFlow);
        }

        private bool ValidateName(string name)
        {
            if (name.Trim() != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LoadListBoxDynamicNewSubzone(List<string> list)
        {
            subzonesToSetListBox.Items.Clear();
            foreach (string aux in list)
            {
                subzonesToSetListBox.Items.Add(aux);
            }
        }

        private void AttemptToAddSubzone()
        {
            if (AvailableSubzones.Count() > 0)
            {
                AddRemoveSubzone(SelectedSubzoneNameToAdd, AvailableSubzones, SubzonesForFlow);
            }
            else
            {
                MessageBox.Show("No hay mas subzonas para agregar", "Error");
            }
        }

        private void AddRemoveSubzone(string name,
            List<string> listFrom, List<string> listTo)
        {
            listFrom.Remove(name);
            listTo.Add(name);
            LoadListBoxDynamicNewSubzone(listFrom);
            LoadListBoxDynamicAvailableSubzone(listTo);
        }

        private void availableSubzonesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSubzoneNameToAdd = (string)availableSubzonesListBox.SelectedItem;
        }

        private void subzonesToSetListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSubzoneNameToRemove = (string)subzonesToSetListBox.SelectedItem;
        }

        private void CancelBtn_MouseClick(object sender, MouseEventArgs e)
        {
            CardPanel.Controls.Clear();
        }

        private void SaveBtn_MouseClick(object sender, MouseEventArgs e)
        {
            SetSaleFlow();
            CardPanel.Controls.Clear();
        }

        private void SetSaleFlow()
        {

        }
    }
}
