using System.Collections.Generic;
using System.Windows.Forms;
using VehicleTracking.Reflection;
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
            LoadStrategies();
        }

        private void LoadStrategies()
        {
            StrategiesListBox.Items.Clear();
            try
            {
                string strategiesPath = 
                    @"..\..\..\VehicleTracking.ConcreteImportingStrategies\bin\Debug\VehicleTracking_ConcreteImportingStrategies.dll";
                IEnumerable<IImportingStrategy> strategies = ImportingStrategiesLoader.FromDllFilePath(strategiesPath);
                UpdateStrategies(strategies);
            }catch(ReflectionException ex) {
                MessageBox.Show(ex.Message, "Error");
                
            }

        }

        private void AddStrategiesBtn_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string path = GetFilePath();
                IEnumerable<IImportingStrategy> newStrategies = ImportingStrategiesLoader.FromDllFilePath(path);
                UpdateStrategies(newStrategies);
            }catch (ReflectionException ex)
            {
                MessageBox.Show(ex.Message, "Error");
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
            ImportVehiclesForm window = new ImportVehiclesForm();
            window.Show();
        }
    }
}
