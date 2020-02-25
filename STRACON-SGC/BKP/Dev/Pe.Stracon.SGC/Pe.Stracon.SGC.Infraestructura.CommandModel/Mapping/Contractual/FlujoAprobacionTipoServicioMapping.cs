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
    /// Implementación del mapeo de la entidad Flujo Aprobación Tipo de Servicio
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20151124 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class FlujoAprobacionTipoServicioMapping : BaseEntityMapping<FlujoAprobacionTipoServicioEntity>
    {
        public FlujoAprobacionTipoServicioMapping()
            : base()
        {
            HasKey(x => x.CodigoFlujoAprobacionTipoServicio).ToTable("FLUJO_APROBACION_TIPO_SERVICIO", "CTR");
            Property(u => u.CodigoFlujoAprobacionTipoServicio).HasColumnName("CODIGO_FLUJO_APROBACION_TIPO_SERVICIO");
            Property(u => u.CodigoFlujoAprobacion).HasColumnName("CODIGO_FLUJO_APROBACION");
            Property(u => u.CodigoTipoServicio).HasColumnName("CODIGO_TIPO_SERVICIO");
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
