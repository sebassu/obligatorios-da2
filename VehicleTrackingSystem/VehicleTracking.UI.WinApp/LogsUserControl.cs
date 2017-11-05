﻿using System;
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
        IUnitOfWork Instance;
        IEnumerable<LoggingRecord> LogsToShow;

        public LogsUserControl()
        {
            InitializeComponent();
            Instance = new UnitOfWork();
            LogsToShow = GetFilteredLogs(null, null);
            LoadGridView(LogsToShow);
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
            if (Utilities.IsNotNull(logsToShow))
            {
                LogsGridView.Rows.Add("Sin", "datos", "a", " mostrar.");
            }
            else
            {
                foreach (var log in logsToShow)
                {
                    var creatorToShow = log.ResponsiblesUsername;
                    var actionToShow = log.ActionPerformed;
                    var dateToShow = log.DateTime;
                    LogsGridView.Rows.Add(creatorToShow, actionToShow, dateToShow);
                }
            }
        }
    }
}
