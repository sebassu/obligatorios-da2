﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Domain.ErrorMessages", typeof(ErrorMessages).Assembly);
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
        ///   Looks up a localized string similar to Marca inválida: &quot;{0}&quot;. Solo se permite ingresar caracteres alfabéticos o espacios para este campo requerido..
        /// </summary>
        internal static string BrandIsInvalid {
            get {
                return ResourceManager.GetString("BrandIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} &quot;{1}&quot; inválida. La misma debe ser mayor o igual a 1..
        /// </summary>
        internal static string CapacityIsInvalid {
            get {
                return ResourceManager.GetString("CapacityIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El color &quot;{0}&quot;  no es valido. Solo se permite ingresar caracteres alfabéticos o espacios para este campo requerido..
        /// </summary>
        internal static string ColorIsInvalid {
            get {
                return ResourceManager.GetString("ColorIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fecha inválida. No puede ser mayor a la fecha actual ni menor a 01/01/1900..
        /// </summary>
        internal static string DateIsInvalid {
            get {
                return ResourceManager.GetString("DateIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La descripción no es válida, no puede ser vacia..
        /// </summary>
        internal static string DescriptionIsInvalid {
            get {
                return ResourceManager.GetString("DescriptionIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La imagen recibida no es válida..
        /// </summary>
        internal static string ImageIsInvalid {
            get {
                return ResourceManager.GetString("ImageIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error: la colección de vehículos a agregar al lote no puede ser vacía, ni puede contener vehículos ya asociados a otros lotes..
        /// </summary>
        internal static string InvalidVehicleCollectionForLot {
            get {
                return ResourceManager.GetString("InvalidVehicleCollectionForLot", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La lista no puede ser vacia. Debe contener al menos un objeto..
        /// </summary>
        internal static string ListIsInvalid {
            get {
                return ResourceManager.GetString("ListIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Se debe seleccionar un lugar para poder proceder..
        /// </summary>
        internal static string LocationIsInvalid {
            get {
                return ResourceManager.GetString("LocationIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Es necesario estar registrado como &quot;Operario de Puerto&quot; o &quot;Administrador&quot; para poder registrar Lotes..
        /// </summary>
        internal static string LotUnauthorizedUserType {
            get {
                return ResourceManager.GetString("LotUnauthorizedUserType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Modelo inválido: &quot;{0}&quot;. Solo se permiten ingresar caracteres alfabéticos, numéricos o espacios para este campo..
        /// </summary>
        internal static string ModelIsInvalid {
            get {
                return ResourceManager.GetString("ModelIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} inválido: &quot;{1}&quot;. Solamente se permite ingresar caracteres alfabéticos o espacios para este campo requerido..
        /// </summary>
        internal static string NameIsInvalid {
            get {
                return ResourceManager.GetString("NameIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Es necesario ingresar una contraseña no vacía..
        /// </summary>
        internal static string PasswordIsInvalid {
            get {
                return ResourceManager.GetString("PasswordIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Número telefónico inválido: &quot;{0}&quot;. Se aceptan únicamente teléfonos siguiendo el formato uruguayo..
        /// </summary>
        internal static string PhoneNumberIsInvalid {
            get {
                return ResourceManager.GetString("PhoneNumberIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuario inválido. Los usuarios de tipo &quot;{1}&quot; no pueden realizar la acción deseada..
        /// </summary>
        internal static string ResponsibleUserIsInvalid {
            get {
                return ResourceManager.GetString("ResponsibleUserIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La zona de partida no puede ser nula ni igual a la de llegada..
        /// </summary>
        internal static string SubzoneArrivalIsInvalid {
            get {
                return ResourceManager.GetString("SubzoneArrivalIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La zona de {0}  no puede ser nula..
        /// </summary>
        internal static string SubzoneIsInvalid {
            get {
                return ResourceManager.GetString("SubzoneIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El usuario &quot;{0}&quot; es inválido: se permiten únicamente aquellos no vacíos con letras o números, sin espacios..
        /// </summary>
        internal static string UsernameIsInvalid {
            get {
                return ResourceManager.GetString("UsernameIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La combinación Rol de Usuario-Ubicación recibida no es válida..
        /// </summary>
        internal static string UserRoleLocationTypeInvalid {
            get {
                return ResourceManager.GetString("UserRoleLocationTypeInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El VIN &quot;{0}&quot; es inválido. Sólo se permite ingresar caracteres alfabéticos y numéricos para este campo, y el largo debe ser de exactamente 17 caracteres..
        /// </summary>
        internal static string VINIsInvalid {
            get {
                return ResourceManager.GetString("VINIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Año inválido: &quot;{0}&quot;. El año no puede ser mayor al actual ni menor a 1900..
        /// </summary>
        internal static string YearIsInvalid {
            get {
                return ResourceManager.GetString("YearIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La zona no puede ser nula..
        /// </summary>
        internal static string ZoneIsInvalid {
            get {
                return ResourceManager.GetString("ZoneIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} inválido: &quot;{1}&quot;. Solamente se permite ingresar caracteres alfabéticos con espacios y/o números para este campo..
        /// </summary>
        internal static string ZoneNameIsInvalid {
            get {
                return ResourceManager.GetString("ZoneNameIsInvalid", resourceCulture);
            }
        }
    }
}
