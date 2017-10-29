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
using Domain;

namespace VehicleTracking.UI.WinApp
{
    public partial class CreateModifyUser : UserControl
    {
        Panel CardPanel;
        UserDTO SelectedUser;
        string Origin;
        IUserServices Instance;

        public CreateModifyUser(Panel cardPanel, string origin, UserDTO selectedUser)
        {
            InitializeComponent();
            CardPanel = cardPanel;
            Origin = origin;
            SelectedUser = selectedUser;
            Instance = new UserServices();
            LoadInfo();
        }

        private void LoadInfo()
        {
            LoadComboBox();
            if (Origin.Equals("modify"))
            {
                FirstNameTxt.Text = SelectedUser.FirstName;
                LastNameTxt.Text = SelectedUser.LastName;
                PhoneTxt.Text = SelectedUser.PhoneNumber;
                UsernameTxt.Text = SelectedUser.Username;
                RoleComboBox.SelectedItem = SelectedUser.Role;
                RoleComboBox.Enabled = false;
            }
            else
            {
                RoleComboBox.Enabled = true;
                TitleLbl.Text = "Agregar usuario";
                OkBtn.Text = "Agregar";
            }
        }

        private void LoadComboBox()//se cae aca
        {
            var roles = Enum.GetNames(typeof(UserRoles)).Cast<UserRoles>();
            foreach (UserRoles role in roles)
            {
                RoleComboBox.Items.Add(role);
            }
        }

        private void CreateModifyUser_Load(object sender, EventArgs e)
        {

        }

        private void FirstNameTxt_MouseClick(object sender, MouseEventArgs e)
        {
            FirstNameTxt.Text = "";
            FirstNameTxt.ForeColor = Color.Black;
        }

        private void LastNameTxt_MouseClick(object sender, MouseEventArgs e)
        {
            LastNameTxt.Text = "";
            LastNameTxt.ForeColor = Color.Black;
        }

        private void PhoneTxt_MouseClick(object sender, MouseEventArgs e)
        {
            PhoneTxt.Text = "";
            PhoneTxt.ForeColor = Color.Black;
        }

        private void UsernameTxt_MouseClick(object sender, MouseEventArgs e)
        {
            UsernameTxt.Text = "";
            UsernameTxt.ForeColor = Color.Black;
        }

        private void PasswordTxt_MouseClick(object sender, MouseEventArgs e)
        {
            PasswordTxt.Text = "";
            PasswordTxt.ForeColor = Color.Black;
        }

        private void CancelBtn_MouseClick(object sender, MouseEventArgs e)
        {
            CardPanel.Controls.Clear();
            CardPanel.Controls.Add(new UserUserControl(CardPanel));
        }

        private void OkBtn_MouseClick(object sender, MouseEventArgs e)
        {
            UserDTO user= new UserDTO();
            try
            {
                user.Role = (UserRoles)RoleComboBox.SelectedItem;
                user.FirstName = FirstNameTxt.Text;
                user.LastName = LastNameTxt.Text;
                user.PhoneNumber = PhoneTxt.Text;
                user.Username = UsernameTxt.Text;
                user.Password = PasswordTxt.Text;
                if (Origin.Equals("modify"))
                {
                    Instance.ModifyUserWithUsername(SelectedUser.Username, user);
                }
                else
                {
                    Instance.AddNewUserFromData(user);
                }
                CardPanel.Controls.Clear();
                CardPanel.Controls.Add(new UserUserControl(CardPanel));
            }
            catch (VehicleTrackingException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
