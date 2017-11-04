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
        IFlowServices Instance;
        ISubzoneServices Subzones;
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
            Instance = new FlowServices();
            Subzones = new SubzoneServices();
            SavedSubzones = GetDistinctSubzones();
            AvailableSubzones = SavedSubzones.ToList();
            SubzonesForFlow = new List<string>();
            NewSubzoneTxt.Enabled = false;
            LoadListBoxDynamic(AvailableSubzones, availableSubzonesListBox);
        }

        public IEnumerable<string> GetDistinctSubzones()
        {
            IEnumerable<string> allDistinctSubzones = new List<string>();
            if (SavedSubzones == null)
            {
                allDistinctSubzones = Subzones.GetRegisteredSubzones().Select(s => s.Name).Distinct();
            }
            return allDistinctSubzones;
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
                AddRemoveSubzone(SelectedSubzoneNameToRemove, SubzonesForFlow, AvailableSubzones, "remove");
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
                    LoadListBoxDynamic(SubzonesForFlow, subzonesToSetListBox);
                }else
                {
                    MessageBox.Show("La subzona '" + NewSubzoneTxt.Text
                    + "' ya se encuentra registrada.", "Error");                   
                }
                NotExistingSubzoneCheckBox.Checked = false;
                NewSubzoneTxt.Text = "";
            }
        }

        private void RemoveSubzone(string name)
        {
            SubzonesForFlow.Remove(name);
            LoadListBoxDynamic(SubzonesForFlow, subzonesToSetListBox);
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

        private void AttemptToAddSubzone()
        {
            if (AvailableSubzones.Count() > 0)
            {
                AddRemoveSubzone(SelectedSubzoneNameToAdd, AvailableSubzones, SubzonesForFlow, "add");
            }
            else
            {
                MessageBox.Show("No hay mas subzonas para agregar", "Error");
            }
        }

        private void AddRemoveSubzone(string name,
            List<string> listFrom, List<string> listTo, string direction)
        {
            listFrom.Remove(name);
            listTo.Add(name);
            if (direction.Equals("add"))
            {
                LoadListBoxDynamic(listFrom, availableSubzonesListBox);
                LoadListBoxDynamic(listTo, subzonesToSetListBox);
            }else
            {
                LoadListBoxDynamic(listFrom, subzonesToSetListBox);
                LoadListBoxDynamic(listTo, availableSubzonesListBox);
            }
        }

        private void LoadListBoxDynamic (List<string> list, ListBox listBoxToModify)
        {
            listBoxToModify.Items.Clear();
            foreach (string aux in list)
            {
                listBoxToModify.Items.Add(aux);
            }
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
            Instance.AddNewFlowFromData(SubzonesForFlow);
        }
    }
}
