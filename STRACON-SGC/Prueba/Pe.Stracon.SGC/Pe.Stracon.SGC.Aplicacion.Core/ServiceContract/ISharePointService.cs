using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Microsoft.SharePoint.Client;

namespace Pe.Stracon.SGC.Aplicacion.Core.ServiceContract
{
    public interface ISharePointService : IGenericService
    {
        /// <summary>
        /// Retorna las credenciales de acceso al SharePoint
        /// </summary>
        /// <returns></returns>
        SharePointOnlineCredentials RetornaCredencialesServer();

        /// <summary>
        /// Retorna el arreglo de bytes del documento SharePoint
        /// </summary>
        /// <param name="hayError">Cadena para ver si hay errores al retornar el documento.</param>
        /// <param name="idItem">Código del Archivo en el SharePoint</param>
        /// <param name="siteUrl">URL del Site SharePoint</param>
        /// <param name="listName">Lista de biblioteca.</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> DescargaArchivoPorId(ref string hayError, long idItem, string listName);

        /// <summary>
        /// Retorna el Site del Servidor SharePoint configurado
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        string RetornaSiteUrlSharePoint();

        /// <summary>
        /// Registra un nuevo archivo en el servidor de SharePoint
        /// </summary>        
        /// <param name="hayError">variable que contiene el mensaje de error al registrar</param>
        /// <param name="listName">biblioteca de donde se encontrará el archivo</param>
        /// <param name="folderName">nombre de carpeta del archivo</param>
        /// <param name="fileName">nombre del archivo</param>
        /// <param name="myFile">stream del archivo</param>
        /// <param name="prmSiteURL">URL del servidor SharePoint</param>
        /// <param name="prmCredenciales">Credenciales de acceso al servidor SharePoint</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RegistraArchivoSharePoint(ref string hayError, string listName, string folderName, string fileName, MemoryStream myFile, string prmSiteURL = null, SharePointOnlineCredentials prmCredenciales = null);
        
        /// <summary>
        /// Método para eliminar los archivos del repositorio SharePoint.
        /// </summary>
        /// <param name="lstArchivosSHP">lista que contiene los ID de los archivos</param>
        /// <param name="listName">nombre del directorio dentro del cual se buscan los archivos</param>
        /// <param name="hayError">parámetro para capturar los errores del procedimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> EliminaArchivoSharePoint(List<int> lstArchivosSHP, string listName, ref string hayError);
    }
}
