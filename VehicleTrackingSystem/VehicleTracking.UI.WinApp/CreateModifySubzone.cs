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
using Persistence;

namespace VehicleTracking.UI.WinApp
{
    public partial class CreateModifySubzone : UserControl
    {
        ISubzoneServices SubzoneInstance;
        IZoneServices ZoneIntance;
        SubzoneDTO SelectedSubzone;
        Panel CardPnl;
        string Origin;

        public CreateModifySubzone(Panel cardPanel, string origin, SubzoneDTO selectedSubzone)
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            SubzoneInstance = new SubzoneServices(unitOfWork);
            ZoneIntance = new ZoneServices(unitOfWork);
            CardPnl = cardPanel;
            Origin = origin;
            SelectedSubzone = selectedSubzone;
            LoadInfo();
            InitializeComponent();
        }

        private void LoadInfo()
        {
            if (Origin.Equals("modify"))
            {
                NameTxt.Text = SelectedSubzone.Name;
                CapacityTxt.Text = SelectedSubzone.Capacity.ToString();
                TitleLbl.Text = "Modificar subzona";
                OkBtn.Text = "Modificar";
            }else
            {
                TitleLbl.Text = "Agregar subzona";
                OkBtn.Text = "Agregar";
            }
        }
    }
}
