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
    /// Implementación del mapeo de la consulta adjunto
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ConsultaAdjuntoMapping : BaseEntityMapping<ConsultaAdjuntoEntity>
    {
        /// <summary>
        /// Constructo de la clase
        /// </summary>
        public ConsultaAdjuntoMapping()
            :base()
        {
            HasKey(x => x.CodigoConsultaAdjunto).ToTable("CONSULTA_ADJUNTO","CTR");
            Property(u => u.CodigoConsultaAdjunto).HasColumnName("CODIGO_CONSULTA_ADJUNTO");
            Property(u => u.CodigoConsulta).HasColumnName("CODIGO_CONSULTA");
            Property(u => u.CodigoArchivo).HasColumnName("CODIGO_ARCHIVO");
            Property(u => u.NombreArchivo).HasColumnName("NOMBRE_ARCHIVO");
            Property(u => u.RutaArchivoSharePoint).HasColumnName("RUTA_ARCHIVO_SHAREPOINT");
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
