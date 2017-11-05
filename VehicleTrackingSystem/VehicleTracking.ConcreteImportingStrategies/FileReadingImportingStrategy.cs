﻿using System;
using Domain;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

namespace ImportingStrategies
{
    public abstract class FileReadingImportingStrategy : IImportingStrategy
    {
        private const string pathParameterName = "Ubicación del archivo";

        public Dictionary<string, Type> RequiredParameters =>
            new Dictionary<string, Type>() {
                { pathParameterName, typeof(Path) }
            };

        public IEnumerable<Vehicle> GetVehicles(IDictionary<string, object> parameters)
        {
            try
            {
                var pathOfXMLFile = parameters[pathParameterName] as string;
                return GetVehicleEnumerationFromFile(pathOfXMLFile);
            }
            catch (SystemException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.IncompleteParameters, pathParameterName);
                throw new ImportingException(errorMessage);
            }
        }

        protected abstract IEnumerable<Vehicle> GetVehicleEnumerationFromFile(string filePath);
    }
}