using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.Adapter.Contractual
{
    /// <summary>
    /// Implementación del Adaptador de Requerimiento Párrafo Variable
    /// </summary>
    public class RequerimientoParrafoVariableAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Requerimiento Párrafo Variable con los datos a registrar</returns>
        public static RequerimientoParrafoVariableEntity RegistrarRequerimientoParrafoVariable(RequerimientoParrafoVariableRequest data)
        {
            var contratoParrafoVariableEntity = new RequerimientoParrafoVariableEntity();
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = ",";

            if (data.CodigoRequerimientoParrafoVariable != null)
            {
                contratoParrafoVariableEntity.CodigoRequerimientoParrafoVariable = new Guid(data.CodigoRequerimientoParrafoVariable.ToString());
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                contratoParrafoVariableEntity.CodigoRequerimientoParrafoVariable = code;
            }

            contratoParrafoVariableEntity.CodigoRequerimientoParrafo = new Guid(data.CodigoRequerimientoParrafo);
            contratoParrafoVariableEntity.CodigoVariable = new Guid(data.CodigoVariable);
            contratoParrafoVariableEntity.ValorTexto = data.ValorTexto;
            if (!string.IsNullOrWhiteSpace(data.ValorNumeroString))
            {
                contratoParrafoVariableEntity.ValorNumero = Decimal.Parse(data.ValorNumeroString, numberFormatInfo);
            }

            if (!string.IsNullOrWhiteSpace(data.ValorFechaString))
            {
                contratoParrafoVariableEntity.ValorFecha = DateTime.ParseExact(data.ValorFechaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
            }

            contratoParrafoVariableEntity.ValorImagen = data.ValorImagen;
            contratoParrafoVariableEntity.ValorTabla = data.ValorTabla;
            contratoParrafoVariableEntity.ValorTablaEditable = data.ValorTablaEditable;
            contratoParrafoVariableEntity.ValorBien = data.ValorBien;
            contratoParrafoVariableEntity.ValorBienEditable = data.ValorBienEditable;
            contratoParrafoVariableEntity.ValorFirmante = data.ValorFirmante;
            contratoParrafoVariableEntity.ValorFirmanteEditable = data.ValorFirmanteEditable;
            contratoParrafoVariableEntity.ValorLista = !string.IsNullOrEmpty(data.ValorLista) ? (Guid?)new Guid(data.ValorLista) : null;
            contratoParrafoVariableEntity.FechaCreacion = DateTime.Now;

            return contratoParrafoVariableEntity;
        }
    }
}
