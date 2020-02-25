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
    /// Implementación del Adaptador de Contrato Documento
    /// </summary>
    public class ContratoDocumentoAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Contrato Documento con los datos a registrar</returns>
        public static ContratoDocumentoEntity RegistrarContratoDocumento(ContratoDocumentoRequest data)
        {
            ContratoDocumentoEntity contratoDocumentoEntity = new ContratoDocumentoEntity();

            if (data.CodigoContratoDocumento != null &&  Guid.Parse(data.CodigoContratoDocumento) != Guid.Empty)
            {
                contratoDocumentoEntity.CodigoContratoDocumento = new Guid(data.CodigoContratoDocumento.ToString());
            }
            else
            {
                contratoDocumentoEntity.CodigoContratoDocumento = Guid.NewGuid();
            }

            contratoDocumentoEntity.CodigoContrato = new Guid(data.CodigoContrato.ToString());
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
