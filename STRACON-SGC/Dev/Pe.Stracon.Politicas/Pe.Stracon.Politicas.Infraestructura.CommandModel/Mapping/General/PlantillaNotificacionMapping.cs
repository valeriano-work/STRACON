using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.Mapping.General
{
    /// <summary>
    /// Implementación del mapeo de la entidad parámetro
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PlantillaNotificacionMapping : BaseEntityMapping<PlantillaNotificacionEntity>
    {
        /// <summary>
        /// Constuctor del Mapping de Parámetro
        /// </summary>
        public PlantillaNotificacionMapping()
            : base()
        {
            HasKey(x => x.CodigoPlantillaNotificacion).ToTable("PLANTILLA_NOTIFICACION", "GRL");
            Property(u => u.CodigoPlantillaNotificacion).HasColumnName("CODIGO_PLANTILLA_NOTIFICACION");
            Property(u => u.CodigoSistema).HasColumnName("CODIGO_SISTEMA");
            Property(u => u.CodigoTipoNotificacion).HasColumnName("CODIGO_TIPO_NOTIFICACION");
            Property(u => u.Asunto).HasColumnName("ASUNTO");
            Property(u => u.IndicadorActiva).HasColumnName("INDICADOR_ACTIVA");
            Property(u => u.Contenido).HasColumnName("CONTENIDO");
            Property(u => u.CodigoTipoDestinatario).HasColumnName("CODIGO_TIPO_DESTINATARIO");
            Property(u => u.Destinatario).HasColumnName("DESTINATARIO");
            Property(u => u.DestinatarioCopia).HasColumnName("DESTINATARIO_COPIA");
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
