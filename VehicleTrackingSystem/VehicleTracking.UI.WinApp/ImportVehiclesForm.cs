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
            Type s = parameter.Value;
            switch (s.Name)
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
            Label newLabel = new Label();
            newLabel.Name = actualElementName + "lbl";
            newLabel.Text = actualElementName + ":";
            newLabel.AutoSize = true;
            newLabel.Location = origin;
            newLabel.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            newLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffcd00");
            ContainerPanel.Controls.Add(newLabel);
            return newLabel.Width;         
        }

        private int CreateNewTextBox(Point elementOrigin)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Location = elementOrigin;
            newTextBox.Name = actualElementName + "txt";
            newTextBox.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            newTextBox.Width = (ContainerPanel.Width) / 3;
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
            Button newButton = new Button();
            newButton.Name = actualElementName + "btn";
            newButton.Text = "Choose file...";
            newButton.AutoSize = true;
            newButton.FlatStyle = FlatStyle.Flat;
            newButton.FlatAppearance.BorderColor = Color.Silver;
            newButton.FlatAppearance.BorderSize = 4;
            newButton.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            newButton.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffcd00");
            newButton.Location = CenterButton(elementOrigin);
            newButton.MouseClick += ChooseFileMouseClicked;
            ContainerPanel.Controls.Add(newButton);
        }

        private Point CenterButton(Point point)
        {
            point.Y = point.Y - 5;
            return point;
        }

        private void ChooseFileMouseClicked (object sender, MouseEventArgs e)
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
            
        }
    }
}