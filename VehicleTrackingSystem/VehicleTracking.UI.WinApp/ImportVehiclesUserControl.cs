using System.Windows.Forms;
using VehicleTracking.Reflection;

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
            StrategiesListBox.Items.Add("XML");
            StrategiesListBox.Items.Add("JSON");
        }

        private void AddStrategiesBtn_MouseClick(object sender, MouseEventArgs e)
        {
            string path = GetFilePath();
            ImportingStrategiesLoader.FromDllFilePath(path);
               
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
    }
}
