using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad ContratoFirmante
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ContratoFirmanteMapping : BaseEntityMapping<ContratoFirmanteEntity>
    {
        public ContratoFirmanteMapping()
            :base()
        {
            HasKey(x => x.CodigoContratoFirmante).ToTable("CONTRATO_FIRMANTE", "CTR");
            Property(u => u.CodigoContratoFirmante).HasColumnName("CODIGO_CONTRATO_FIRMANTE");
            Property(u => u.CodigoContratoParrafoVariable).HasColumnName("CODIGO_CONTRATO_PARRAFO_VARIABLE");
            Property(u => u.NombreFirmante).HasColumnName("NOMBRE_FIRMANTE");
            Property(u => u.DatoAdicional).HasColumnName("DATO_ADICIONAL");
            Property(u => u.EstadoRegistro).HasColumnName("ESTADO_REGISTRO");
            Property(u => u.UsuarioCreacion).HasColumnName("USUARIO_CREACION");
            Property(u => u.FechaCreacion).HasColumnName("FECHA_CREACION");
            Property(u => u.TerminalCreacion).HasColumnName("TERMINAL_CREACION");
            Property(u => u.UsuarioModificacion).HasColumnName("USUARIO_MODIFICACION");
            Property(u => u.FechaModificacion).HasColumnName("FECHA_MODIFICACION");
            Property(u => u.TerminalModificacion).HasColumnName("TERMINAL_MODIFICACION");
        }
    }
}
