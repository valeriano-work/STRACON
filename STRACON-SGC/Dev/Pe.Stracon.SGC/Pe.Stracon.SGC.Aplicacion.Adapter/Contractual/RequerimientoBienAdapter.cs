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
    /// Implementación del Adaptador de Listado Requerimiento
    /// </summary>
    public sealed class RequerimientoBienAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Requerimiento Bien con los datos a registrar</returns>
        public static RequerimientoBienEntity RegistrarRequerimientoBien(RequerimientoBienRequest data)
        {
            var contratoBienEntity = new RequerimientoBienEntity();
            

            if (data.CodigoRequerimientoBien != null)
            {
                contratoBienEntity.CodigoRequerimientoBien = new Guid(data.CodigoRequerimientoBien.ToString());
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                contratoBienEntity.CodigoRequerimientoBien = code;
            }

            contratoBienEntity.CodigoRequerimiento = new Guid(data.CodigoRequerimiento);
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
