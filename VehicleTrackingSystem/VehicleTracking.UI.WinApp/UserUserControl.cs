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
    public partial class UserUserControl : UserControl
    { 
        Panel CardPanel;
        UserDTO SelectedUser;
        IUserServices Instance;
        public UserUserControl(Panel cardPanel)
        {
            InitializeComponent();
            CardPanel = cardPanel;
            Instance = new UserServices();
            LoadListBox();
        }

        private void LoadListBox()
        {
            UserListBox.Items.Clear();
            IEnumerable<UserDTO> allUsers = Instance.GetRegisteredUsers();
            for (int i = 0; i < allUsers.Count(); i++)
            {
                UserDTO aux = allUsers.ElementAt(i);
                UserListBox.Items.Add(aux.Username);
            }
        }

        private void UserListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String username = UserListBox.GetItemText(UserListBox.SelectedItem);
            SelectedUser = Instance.GetUserWithUsername(username);
            RoleLbl.Text = SelectedUser.Role.ToString();
            FirstNameLbl.Text = SelectedUser.FirstName;
            LastNameLbl.Text = SelectedUser.LastName;
            UsernameLbl.Text = SelectedUser.Username;
            PhoneLbl.Text = SelectedUser.PhoneNumber;
        }

        private void AddZoneBtn_MouseClick(object sender, MouseEventArgs e)
        {
            CardPanel.Controls.Clear();
            CardPanel.Controls.Add(new CreateModifyUser(CardPanel,
                "add", null));
        }
    }
}
