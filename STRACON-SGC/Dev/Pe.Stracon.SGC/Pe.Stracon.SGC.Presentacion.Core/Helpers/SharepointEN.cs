using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pe.Stracon.SGC.Presentacion.Core.Helpers
{
    /// <summary>
    /// Clase para el uso de las propiedades de SharePoint
    /// </summary>
    public class SharepointEN
    {
        /// <summary>
        /// ID de un elemento en SharePoint
        /// </summary>
        public int idItem { get; set; }

        /// <summary>
        /// Nombre de la lista a interacturar
        /// </summary>
        public string listName { get; set; }

        /// <summary>
        /// Contiene el arreglo de bytes de un archivo
        /// </summary>
        public MemoryStream msfile { get; set; }

        /// <summary>
        /// Nombre de Archivo de una biblioteca
        /// </summary>
        public string fileName { get; set; }

        /// <summary>
        /// URL del Sitio que viene de la lista Parámetros
        /// </summary>
        public string siteUrlParam { get; set; }

        /// <summary>
        /// Nombre de la carpeta de una biblioteca
        /// </summary>
        public string folderName { get; set; }

        /// <summary>
        /// URL Relativo de un archivo
        /// </summary>
        public string serverRelativeURLFile { get; set; }
    }
}
