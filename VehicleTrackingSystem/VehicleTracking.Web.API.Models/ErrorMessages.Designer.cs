﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Services {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("API.Services.ErrorMessages", typeof(ErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Acción inválida: no es posible eliminar a todos los administradores del sistema..
        /// </summary>
        internal static string CannotRemoveAllAdministrators {
            get {
                return ResourceManager.GetString("CannotRemoveAllAdministrators", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No es posible eliminar a la zona: contiene subzonas..
        /// </summary>
        internal static string CannotRemoveNonEmptyZone {
            get {
                return ResourceManager.GetString("CannotRemoveNonEmptyZone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No es posible eliminar a la subzona: se encuentra asociada a movimientos del histórico..
        /// </summary>
        internal static string CannotRemoveSubzone {
            get {
                return ResourceManager.GetString("CannotRemoveSubzone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se pueden eliminar los lotes que ya fueron transportados..
        /// </summary>
        internal static string CannotRemoveTransportedLots {
            get {
                return ResourceManager.GetString("CannotRemoveTransportedLots", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No es posible completar la acción: el {0} ingresado ya se encuentra registrado en el sistema..
        /// </summary>
        internal static string FieldMustBeUnique {
            get {
                return ResourceManager.GetString("FieldMustBeUnique", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El movimiento realizado no es válido. Solamente es posible mover vehículos entre las subzonas definidas en el flujo de venta..
        /// </summary>
        internal static string InvalidMovementSubzone {
            get {
                return ResourceManager.GetString("InvalidMovementSubzone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El movimiento no es válido. Sólo se puede mover vehículos que se encuentren en subzonas que pertenecen al flujo de venta..
        /// </summary>
        internal static string InvalidMovementVehicle {
            get {
                return ResourceManager.GetString("InvalidMovementVehicle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El lote se encuentra en una etapa en la cual no está permitido editarlo..
        /// </summary>
        internal static string LotWasTransported {
            get {
                return ResourceManager.GetString("LotWasTransported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El usuario y/o contraseña no pueden ser vacíos..
        /// </summary>
        internal static string NotEmptyValues {
            get {
                return ResourceManager.GetString("NotEmptyValues", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Contraseña incorrecta..
        /// </summary>
        internal static string NotMatchingPasswords {
            get {
                return ResourceManager.GetString("NotMatchingPasswords", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El valor ingresado no puede ser nulo..
        /// </summary>
        internal static string NotNullValues {
            get {
                return ResourceManager.GetString("NotNullValues", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se recibieron datos en el formato correcto esperado para acceder a esta funcionalidad..
        /// </summary>
        internal static string NullDTOReference {
            get {
                return ResourceManager.GetString("NullDTOReference", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No es posible realizar la modificación: causaría un nombre de subzona repetido en la zona..
        /// </summary>
        internal static string SubzoneNameMustBeUniqueInZone {
            get {
                return ResourceManager.GetString("SubzoneNameMustBeUniqueInZone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error: un transporte sólo puede ser marcado como finalizado por su usuario transportador creador..
        /// </summary>
        internal static string TransportFinalizerMustBeCreator {
            get {
                return ResourceManager.GetString("TransportFinalizerMustBeCreator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error: Sólo pueden ingresar usuarios que tengan rol de administrador..
        /// </summary>
        internal static string WrongUserRole {
            get {
                return ResourceManager.GetString("WrongUserRole", resourceCulture);
            }
        }
    }
}
