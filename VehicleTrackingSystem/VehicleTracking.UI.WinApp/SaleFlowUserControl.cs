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
        SubzoneDTO SelectedSubzone;
        Panel CardPanel;

        public SaleFlowUserControl(Panel cardPanel)
        {
            InitializeComponent();
            CardPanel = cardPanel;
            Instance = new SubzoneServices();
            LoadSubzonesListBox();
        }

        public void LoadSubzonesListBox()
        {
            availableSubzonesListBox.Items.Clear();
            IEnumerable<string> allDistinctSubzones = Instance.GetRegisteredSubzones().Select(s=>s.Name).Distinct();
            foreach (string aux in allDistinctSubzones)
            {
                availableSubzonesListBox.Items.Add(aux);
            }
        }
    }
}
