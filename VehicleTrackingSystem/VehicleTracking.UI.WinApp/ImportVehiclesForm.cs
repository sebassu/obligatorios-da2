using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
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
            var requiredParameters = SelectedStrategy.RequiredParameters;
            Point origin = new Point(123, 40);
            foreach (var param in requiredParameters)
            {
                AddElement(param, origin);
                origin = ModifyLocation(origin);
                AddElement(param, origin);
            }
        }

        private void AddElement(KeyValuePair<string, Type> parameter, Point origin)
        {
            CreateLabel(parameter.Key.Trim(), origin);

            Type s = parameter.Value;
            switch (s.Name)
            {
                case "int":
                    CreateNewNumericUpdown();
                    break;
                case "string":
                    CreateNewTextbox();
                    break;
                case "Path":
                    CreateNewFileChooser();
                    break;
                default:

                    break;
            }
        }

        private void CreateLabel(string name, Point origin)
        {
            Label newLabel = new Label();
            newLabel.Name = name + "lbl";
            newLabel.Text = name + ":";
            newLabel.AutoSize = true;
            newLabel.Location = origin;
            newLabel.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            newLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffcd00");
            ContainerPanel.Controls.Add(newLabel);            
        }

        private void CreateNewNumericUpdown()
        {

        }

        private void CreateNewTextbox()
        {

        }

        private void CreateNewFileChooser()
        {

        }

        private Point ModifyLocation(Point pointToModify)
        {
            pointToModify.Y += 42;
            return pointToModify;
        }
    }
}
