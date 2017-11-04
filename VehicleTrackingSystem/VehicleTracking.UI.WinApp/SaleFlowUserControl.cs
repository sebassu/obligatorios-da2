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

namespace VehicleTracking.UI.WinApp
{
    public partial class SaleFlowUserControl : UserControl
    {
        ISubzoneServices Instance;
        string SelectedSubzoneName;
        Panel CardPanel;
        private List<string> AvailableSubzones;
        private List<string> SubzonesForFlow;

        public SaleFlowUserControl(Panel cardPanel)
        {
            InitializeComponent();
            CardPanel = cardPanel;
            Instance = new SubzoneServices();
            AvailableSubzones = GetDistinctSubzones();
            SubzonesForFlow = new List<string>();
            NewSubzoneTxt.Enabled = false;
            LoadListBoxDynamicAvailableSubzone(AvailableSubzones);
        }

        public List<string> GetDistinctSubzones()
        {
            IEnumerable<string> allDistinctSubzones = 
                Instance.GetRegisteredSubzones().Select(s => s.Name).Distinct();
            return allDistinctSubzones.ToList();
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
                AddRemoveSubzone(SelectedSubzoneName, SubzonesForFlow,AvailableSubzones);
            }
        }

        private void AddSubzone(string name)
        {
            if (ValidateName(name))
            {
                if (!SubzonesForFlow.Contains(name))
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

        private void AddRemoveSubzone(string name,
            List<string> listToAdd, List<string> listToRemove)
        {
            listToRemove.Remove(name);
            listToAdd.Add(name);
            LoadListBoxDynamicNewSubzone(listToAdd);
            LoadListBoxDynamicAvailableSubzone(listToRemove);
        }

        private void availableSubzonesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSubzoneName = (string)availableSubzonesListBox.SelectedItem;
        }
    }
}
