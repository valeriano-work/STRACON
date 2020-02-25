using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Cross.Core.Util;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.Adapter.Contractual
{
    /// <summary>
    /// Implementación del Adaptador de Requerimiento Documento
    /// </summary>
    public class RequerimientoDocumentoAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Requerimiento Documento con los datos a registrar</returns>
        public static RequerimientoDocumentoEntity RegistrarRequerimientoDocumento(RequerimientoDocumentoRequest data)
        {
            RequerimientoDocumentoEntity contratoDocumentoEntity = new RequerimientoDocumentoEntity();

            if (data.CodigoRequerimientoDocumento != null &&  Guid.Parse(data.CodigoRequerimientoDocumento) != Guid.Empty)
            {
                contratoDocumentoEntity.CodigoRequerimientoDocumento = new Guid(data.CodigoRequerimientoDocumento.ToString());
            }
            else
            {
                contratoDocumentoEntity.CodigoRequerimientoDocumento = Guid.NewGuid();
            }

            contratoDocumentoEntity.CodigoRequerimiento = new Guid(data.CodigoRequerimiento.ToString());
            contratoDocumentoEntity.CodigoArchivo = Convert.ToInt32(data.CodigoArchivo);
            contratoDocumentoEntity.RutaArchivoSharePoint = data.RutaArchivoSharePoint;
            contratoDocumentoEntity.Contenido = data.Contenido;

            if(!string.IsNullOrEmpty(data.Contenido))
            {
                contratoDocumentoEntity.ContenidoBusqueda = Utilitario.HtmlACadena(data.Contenido);
            }
            contratoDocumentoEntity.IndicadorActual = (bool)data.IndicadorActual;
            contratoDocumentoEntity.Version = (byte)data.Version;
            contratoDocumentoEntity.FechaCreacion = DateTime.Now;

            return contratoDocumentoEntity;
        }
    }
}
