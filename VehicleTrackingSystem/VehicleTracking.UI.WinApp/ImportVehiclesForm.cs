using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleTracking_Data_Entities;

namespace VehicleTracking.UI.WinApp
{
    public partial class ImportVehiclesForm : Form
    {
        IImportingStrategy SelectedStrategy;

        public ImportVehiclesForm(IImportingStrategy selectedStrategy)
        {
            InitializeComponent();
            SelectedStrategy = selectedStrategy;
            LoadWindowDynamic();
        }

        private void LoadWindowDynamic()
        {
            SelectedStrategy.
        }
    }
}
