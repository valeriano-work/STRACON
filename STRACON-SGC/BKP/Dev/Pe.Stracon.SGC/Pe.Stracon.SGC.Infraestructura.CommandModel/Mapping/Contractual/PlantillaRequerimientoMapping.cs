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
    /// Implementación del mapeo de la entidad Plantilla
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150519 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PlantillaRequerimientoMapping : BaseEntityMapping<PlantillaRequerimientoEntity>
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public PlantillaRequerimientoMapping()
            :base()
        {
            HasKey(x => x.CodigoPlantilla).ToTable("PLANTILLA_REQUERIMIENTO", "CTR");
            Property(u => u.CodigoPlantilla).HasColumnName("CODIGO_PLANTILLA");
            Property(u => u.Descripcion).HasColumnName("DESCRIPCION");
            Property(u => u.CodigoEstadoVigencia).HasColumnName("CODIGO_ESTADO");
            Property(u => u.IndicadorAdhesion).HasColumnName("INDICADOR_ADHESION");
            Property(u => u.FechaInicioVigencia).HasColumnName("FECHA_INICIO_VIGENCIA");
            Property(u => u.FechaFinVigencia).HasColumnName("FECHA_FIN_VIGENCIA");
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
