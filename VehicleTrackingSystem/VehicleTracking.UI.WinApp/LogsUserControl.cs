using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using API.Services;
using Persistence;

namespace VehicleTracking.UI.WinApp
{
    public partial class LogsUserControl : UserControl
    {
        Panel CardPanel;
        IUnitOfWork Instance;
        IEnumerable<LoggingRecord> LogsToShow;

        public LogsUserControl(Panel cardPanel)
        {
            InitializeComponent();
            CardPanel = cardPanel;
            Instance = new UnitOfWork();
            InitializeDataGridView();
            LogsToShow = GetFilteredLogs(null, null);
            LoadGridView(LogsToShow);
        }

        private void InitializeDataGridView()
        {
            LogsGridView.ColumnCount = 3;
            LogsGridView.Columns[0].Name = "Usuario responsable";
            LogsGridView.Columns[1].Name = "Accion realizada";
            LogsGridView.Columns[2].Name = "Fecha";
        }

        private IEnumerable<LoggingRecord> GetFilteredLogs(DateTime? dateFrom, DateTime? dateUntil)
        {
            IEnumerable<LoggingRecord> registeredLogs = Instance.LoggingStrategy.Log;
            if (dateFrom == null || dateUntil == null)
            {
                return registeredLogs;
            }
            List<LoggingRecord> filteredLogs = new List<LoggingRecord>();
            foreach (var log in registeredLogs)
            {
                if(ValidDate(log, dateFrom, dateUntil))
                {
                    filteredLogs.Add(log);
                }
            }
            return filteredLogs;
        }

        private bool ValidDate(LoggingRecord log, DateTime? dateFrom, DateTime? dateUntil)
        {
            if(log.DateTime > dateFrom || log.DateTime < dateUntil)
            {
                return false;
            }else
            {
                return true;
            }
        }

        private void LoadGridView(IEnumerable<LoggingRecord> logsToShow)
        {
            LogsGridView.Rows.Clear();
            if (Utilities.IsNull(logsToShow))
            {
                MessageBox.Show("No hay logs para mostrar", "Error");
            }
            else
            {
                foreach (var log in logsToShow)
                {
                    var creatorToShow = log.ResponsiblesUsername;
                    var actionToShow = log.ActionPerformed.ToString();
                    var dateToShow = log.DateTime.ToString();
                    LogsGridView.Rows.Add(creatorToShow, actionToShow, dateToShow);
                }
            }
        }

        private void ApplyBtn_MouseClick(object sender, MouseEventArgs e)
        {
            DateTime? DateFrom = DateFromPicker.Value.Date;
            DateTime? DateUntil = DateUntilPicker.Value.Date;
            if (DateUntil <= DateTime.Now.Date)
            {
                LoadGridView(GetFilteredLogs(DateFrom, DateUntil));
            }else
            {
                MessageBox.Show("La fecha hasta no puede ser mayor a la de hoy", "Error");
            }
        }

        private void DateUntilPicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime? DateUntil = DateUntilPicker.Value.Date;
            if (DateUntil > DateTime.Now.Date) { 
                MessageBox.Show("La fecha hasta no puede ser mayor a la de hoy", "Error");
            }
        }
    }
}
