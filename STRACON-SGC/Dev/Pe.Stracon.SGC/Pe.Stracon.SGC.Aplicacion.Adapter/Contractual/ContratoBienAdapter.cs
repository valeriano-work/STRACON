using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.Adapter.Contractual
{
    /// <summary>
    /// Implementación del Adaptador de Listado Contrato
    /// </summary>
    public sealed class ContratoBienAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Contrato Bien con los datos a registrar</returns>
        public static ContratoBienEntity RegistrarContratoBien(ContratoBienRequest data)
        {
            var contratoBienEntity = new ContratoBienEntity();
            

            if (data.CodigoContratoBien != null)
            {
                contratoBienEntity.CodigoContratoBien = new Guid(data.CodigoContratoBien.ToString());
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                contratoBienEntity.CodigoContratoBien = code;
            }

            contratoBienEntity.CodigoContrato = new Guid(data.CodigoContrato);
            contratoBienEntity.CodigoBien = new Guid(data.CodigoBien);
            contratoBienEntity.FechaCreacion = DateTime.Now;
            //INICIO: Agregado por Julio Carrera - Norma Contable
            contratoBienEntity.CodigoTipoTarifa = data.TipoTarifa;
            contratoBienEntity.CodigoTipoPeriodo = data.TipoPeriodo;
            contratoBienEntity.HorasMinimas = data.HorasMinimas;
            contratoBienEntity.Tarifa = data.Tarifa;
            contratoBienEntity.MayorMenor = data.MayorMenor;
            //FIN: Agregado por Julio Carrera - Norma Contable
            return contratoBienEntity;
        }
    }
}
