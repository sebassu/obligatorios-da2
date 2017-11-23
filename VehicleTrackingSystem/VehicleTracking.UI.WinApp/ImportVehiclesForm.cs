using System;
using API.Services;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;

namespace VehicleTracking.UI.WinApp
{
    public partial class ImportVehiclesForm : Form
    {
        IImportingStrategy SelectedStrategy;
        string actualElementName;
        List<Control> AvailableControls;

        public ImportVehiclesForm(IImportingStrategy selectedStrategy)
        {
            InitializeComponent();
            AvailableControls = new List<Control>();
            SelectedStrategy = selectedStrategy;
            LoadWindowDynamic();
        }

        private void LoadWindowDynamic()
        {
            var requiredParameters = SelectedStrategy.RequiredParameters;
            Point origin = new Point(123, 40);
            foreach (var param in requiredParameters)
            {
                AddElement(param, origin);
                origin = ModifyYLocation(origin);
            }
        }

        private void AddElement(KeyValuePair<string, Type> parameter, Point origin)
        {
            actualElementName = parameter.Key.Replace(" ", "");
            int labelWidth = CreateLabel(origin);
            Point elementOrigin = ModifyXLocation(origin, labelWidth);
            var type = parameter.Value;
            switch (type.Name)
            {
                case "Path":
                    CreateNewFileChooser(elementOrigin);
                    break;
                default:
                    CreateNewTextBox(origin);
                    break;
            }
        }

        private int CreateLabel(Point origin)
        {
            Label newLabel = new Label
            {
                Name = actualElementName + "lbl",
                Text = actualElementName + ":",
                AutoSize = true,
                Location = origin,
                Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular),
                ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffcd00")
            };
            ContainerPanel.Controls.Add(newLabel);
            return newLabel.Width;
        }

        private int CreateNewTextBox(Point elementOrigin)
        {
            TextBox newTextBox = new TextBox
            {
                Location = elementOrigin,
                Name = actualElementName + "txt",
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular),
                Width = (ContainerPanel.Width) / 3
            };
            AvailableControls.Add(newTextBox);
            ContainerPanel.Controls.Add(newTextBox);
            return newTextBox.Width;
        }

        private void CreateNewFileChooser(Point elementOrigin)
        {
            int textBoxWidth = CreateNewTextBox(elementOrigin);
            elementOrigin = ModifyXLocation(elementOrigin, textBoxWidth);
            CreateFileChooserButton(elementOrigin);
        }

        private void CreateFileChooserButton(Point elementOrigin)
        {
            var button = new Button
            {
                Name = actualElementName + "btn",
                Text = "Elegir archivo...",
                AutoSize = true,
                FlatStyle = FlatStyle.Flat
            };
            button.FlatAppearance.BorderColor = Color.Silver;
            button.FlatAppearance.BorderSize = 4;
            button.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            button.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffcd00");
            button.Location = CenterButton(elementOrigin);
            button.MouseClick += ChooseFileMouseClicked;
            ContainerPanel.Controls.Add(button);
        }

        private Point CenterButton(Point point)
        {
            point.Y = point.Y - 5;
            return point;
        }

        private void ChooseFileMouseClicked(object sender, MouseEventArgs e)
        {
            string path = "";
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
            }
            Control[] textBox = ContainerPanel.Controls.Find(actualElementName + "txt", true);
            textBox[0].Text = path;
        }

        private Point ModifyYLocation(Point pointToModify)
        {
            pointToModify.Y += 42;
            return pointToModify;
        }

        private Point ModifyXLocation(Point pointToModify, int previousElementWidth)
        {
            int separatorConstant = 3;
            pointToModify.X = pointToModify.X + previousElementWidth + separatorConstant;
            return pointToModify;
        }

        private void ImportVehiclesBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            foreach (Control c in AvailableControls)
            {
                string parameterName = c.Name.Substring(0, c.Name.Length - 3);
                parameters.Add(parameterName, c.Text);
            }
            try
            {
                IEnumerable<Vehicle> vehiclesToImport = SelectedStrategy.GetVehicles(parameters);
                ProcessImportedVehicles(vehiclesToImport);
                MessageBox.Show("Los vehículos han sido importados correctamente.", "Importación de vehículos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (VehicleTrackingException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ProcessImportedVehicles(IEnumerable<Vehicle> vehiclesToImport)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var service = new VehicleServices(unitOfWork);
                foreach (var vehicle in vehiclesToImport)
                {
                    var vehicleData = VehicleDTO.FromVehicle(vehicle);
                    service.AddNewVehicleFromData(vehicleData);
                }
                unitOfWork.LoggingStrategy.RegisterVehicleImport(SessionServices.LoggedUser);
                unitOfWork.SaveChanges();
            }
        }
    }
}