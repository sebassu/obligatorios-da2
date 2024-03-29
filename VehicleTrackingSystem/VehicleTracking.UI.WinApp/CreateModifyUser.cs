﻿using System;
using API.Services;
using System.Drawing;
using System.Windows.Forms;
using VehicleTracking_Data_Entities;

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
                PhoneNumberTxt.Text = SelectedUser.PhoneNumber;
                UsernameTxt.Text = SelectedUser.Username;
                RoleComboBox.SelectedText = SelectedUser.Role.ToString();
                RoleComboBox.Enabled = false;
                TitleLbl.Text = "Modificar usuario";
                OkBtn.Text = "Modificar";
            }
            else
            {
                RoleComboBox.Enabled = true;
                TitleLbl.Text = "Agregar usuario";
                OkBtn.Text = "Agregar";
            }
        }

        private void LoadComboBox()
        {
            var roles = Enum.GetNames(typeof(UserRoles));
            foreach (string role in roles)
            {
                RoleComboBox.Items.Add(role);
            }
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
            PhoneNumberTxt.Text = "";
            PhoneNumberTxt.ForeColor = Color.Black;
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
                user.FirstName = FirstNameTxt.Text;
                user.LastName = LastNameTxt.Text;
                user.PhoneNumber = PhoneNumberTxt.Text;
                user.Username = UsernameTxt.Text;
                if (Origin.Equals("modify"))
                {
                    if (PasswordTxt.Text.Equals(""))
                    {
                        user.Password = SelectedUser.Password;
                    }
                    else
                    {
                        user.Password = PasswordTxt.Text;
                    }
                    user.Role = SelectedUser.Role;
                    Instance.ModifyUserWithUsername(SelectedUser.Username, user);
                }
                else
                {
                    user.Role = (UserRoles)RoleComboBox.SelectedIndex;
                    user.Password = PasswordTxt.Text;
                    Instance.AddNewUserFromData(user);
                }
                CardPanel.Controls.Clear();
                CardPanel.Controls.Add(new UserUserControl(CardPanel));
            }
            catch (VehicleTrackingException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
