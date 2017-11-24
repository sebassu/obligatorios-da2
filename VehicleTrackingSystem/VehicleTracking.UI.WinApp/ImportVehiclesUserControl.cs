using System.Windows.Forms;
using VehicleTracking.Reflection;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking.UI.WinApp
{
    public partial class ImportVehiclesUserControl : UserControl
    {

        Panel CardPanel;

        public ImportVehiclesUserControl(Panel cardPanel)
        {
            InitializeComponent();
            CardPanel = cardPanel;
        }

        private void AddStrategiesBtn_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string path = GetFilePath();
                IEnumerable<IImportingStrategy> newStrategies = ImportingStrategiesLoader.FromDllFilePath(path);
                UpdateStrategies(newStrategies);
            }
            catch (ReflectionException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetFilePath()
        {
            string path = "";
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
            }
            return path;
        }

        private void UpdateStrategies(IEnumerable<IImportingStrategy> allNewStrategies)
        {
            foreach (IImportingStrategy strategy in allNewStrategies)
            {
                StrategiesListBox.Items.Add(strategy);
            }
        }

        private void ImportVehiclesBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (StrategiesListBox.SelectedItem != null)
            {
                ImportVehiclesForm window = new ImportVehiclesForm((IImportingStrategy)StrategiesListBox.SelectedItem);
                window.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una estrategia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}