using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking.Reflection
{
    public static class ImportingStrategiesLoader
    {
        public static IEnumerable<IImportingStrategy> FromDllFilePath(
            string dllFilePath)
        {
            try
            {
                return AttemptToLoadStrategiesFromAssembly(dllFilePath);
            }
            catch (IOException exception)
            {
                throw new ReflectionException(exception.Message);
            }
            catch (ArgumentException)
            {
                throw new ReflectionException(ErrorMessages.FileNotFound);
            }
        }

        private static IEnumerable<IImportingStrategy> AttemptToLoadStrategiesFromAssembly(string dllFilePath)
        {
            var result = new List<IImportingStrategy>();
            var strategiesAssembly = Assembly.LoadFrom(dllFilePath);
            LoadStrategiesFromAssembly(result, strategiesAssembly);
            return result;
        }

        private static void LoadStrategiesFromAssembly(List<IImportingStrategy> result,
            Assembly strategiesAssembly)
        {
            foreach (var type in strategiesAssembly.GetExportedTypes())
            {
                if (IsValidStrategyToInstantiate(type))
                {
                    IImportingStrategy strategyToReturn = AttemptToGetInstanceOf(type);
                    result.Add(strategyToReturn);
                }
            }
        }

        private static IImportingStrategy AttemptToGetInstanceOf(Type type)
        {
            try
            {
                return (IImportingStrategy)Activator.CreateInstance(type);
            }
            catch (MemberAccessException)
            {
                throw new ReflectionException(
                    ErrorMessages.ErrorWhenInstantiatingStrategy);
            }
        }

        private static bool IsValidStrategyToInstantiate(Type type)
        {
            return type.IsClass && !type.IsAbstract &&
                typeof(IImportingStrategy).IsAssignableFrom(type);
        }
    }
}