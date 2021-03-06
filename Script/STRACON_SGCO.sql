USE [master]
GO
/****** Object:  Database [STRACON_SGCO]    Script Date: 25/02/2020 18:03:23 ******/
CREATE DATABASE [STRACON_SGCO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'STRACON_SGT_PROD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\STRACON_SGT.mdf' , SIZE = 15424KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'STRACON_SGT_PROD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\STRACON_SGT_log.ldf' , SIZE = 78080KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [STRACON_SGCO] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [STRACON_SGCO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [STRACON_SGCO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET ARITHABORT OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [STRACON_SGCO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [STRACON_SGCO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [STRACON_SGCO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET  DISABLE_BROKER 
GO
ALTER DATABASE [STRACON_SGCO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [STRACON_SGCO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET RECOVERY FULL 
GO
ALTER DATABASE [STRACON_SGCO] SET  MULTI_USER 
GO
ALTER DATABASE [STRACON_SGCO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [STRACON_SGCO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [STRACON_SGCO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [STRACON_SGCO] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'STRACON_SGCO', N'ON'
GO
USE [STRACON_SGCO]
GO
/****** Object:  User [USR_STRACON_SGT]    Script Date: 25/02/2020 18:03:23 ******/
CREATE USER [USR_STRACON_SGT] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [USR_STRACON_SGCO]    Script Date: 25/02/2020 18:03:23 ******/
CREATE USER [USR_STRACON_SGCO] FOR LOGIN [USR_STRACON_SGCO] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [USR_STRACON_SGT]
GO
ALTER ROLE [db_datareader] ADD MEMBER [USR_STRACON_SGCO]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [USR_STRACON_SGCO]
GO
/****** Object:  Schema [AST]    Script Date: 25/02/2020 18:03:23 ******/
CREATE SCHEMA [AST]
GO
/****** Object:  Schema [MANT]    Script Date: 25/02/2020 18:03:23 ******/
CREATE SCHEMA [MANT]
GO
/****** Object:  Schema [NOTI]    Script Date: 25/02/2020 18:03:23 ******/
CREATE SCHEMA [NOTI]
GO
/****** Object:  Schema [RPT]    Script Date: 25/02/2020 18:03:23 ******/
CREATE SCHEMA [RPT]
GO
/****** Object:  Schema [TRO]    Script Date: 25/02/2020 18:03:23 ******/
CREATE SCHEMA [TRO]
GO
/****** Object:  StoredProcedure [dbo].[Sp_MaePllaCodigoMaterial_Listar]    Script Date: 25/02/2020 18:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Sp_MaePllaCodigoMaterial_Listar]

As
Begin
       Set Nocount On

       Declare @cCodTipMaterial   char(4),
               @cCodCatValoracion char(4),
               @vCodUniMedida     varchar(5)

       Select  @cCodTipMaterial   = 52,
               @cCodCatValoracion = 53,
               @vCodUniMedida     = 54

       Select Mae.iCodPlanilla,Mae.vNumPlanilla,Mae.sdFecPlanilla,Mae.vCodSolicitante,Mae.vDesPlanilla,
              Mae.cCodTipMaterial,dbo.Fn_ParametroDescripcion_Devolver(@cCodTipMaterial,1,2,Mae.cCodTipMaterial) As vDesTipMaterial,
              Mae.cCodCatValoracion,dbo.Fn_ParametroDescripcion_Devolver(@cCodCatValoracion,1,2,Mae.cCodCatValoracion) As vDesCatValoracion,
              Mae.vCodUniMedida,dbo.Fn_ParametroDescripcion_Devolver(@vCodUniMedida,1,2,Mae.vCodUniMedida) As vDesUniMedida,
              Mae.cCodSegmento,Tab.vNomSegmento,Mae.cCodGrupo,Tab.vNomGrupo,Mae.cCodClase,Tab.vNomClase,
              Mae.cCodEstado,Mae.bEstActivo
       From dbo.MaePllaCodigoMaterial Mae With (Nolock) 
       Join dbo.TabClaMaterial Tab With (Nolock) On Mae.cCodSegmento = Tab.cCodSegmento And Mae.cCodGrupo = Tab.cCodGrupo
                                                And Mae.cCodClase    = Tab.cCodClase    And Tab.tiOrden = 1

       Set Nocount Off
End

GO
/****** Object:  StoredProcedure [MANT].[USP_CLASIFICACION_MATERIAL_ATRIBUTO_SEL]    Script Date: 25/02/2020 18:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [MANT].[USP_CLASIFICACION_MATERIAL_ATRIBUTO_SEL]  
(   
 @NOMBRE_PARAMETRO VARCHAR(50)   
)  
AS  
BEGIN  
  
      DECLARE @CODIGO_CLASE NVARCHAR(50)  

      SELECT @CODIGO_CLASE = @NOMBRE_PARAMETRO           
  
      SELECT   
              POSICION As Id,
              --(CASE WHEN OBLIGATORIEDAD = 'OBLIGATORIO' THEN '*' ELSE '' END)+CODIGO_ATRIBUTO As Codigo,
              --(CASE WHEN OBLIGATORIEDAD = 'OBLIGATORIO' THEN '*' ELSE '' END) As Est,
              (CASE WHEN OBLIGATORIEDAD = 'OBLIGATORIO' THEN '*' ELSE '' END)+NOMBRE_ATRIBUTO As Nombre
      FROM MANT.CLASIFICACION_MATERIAL (Nolock) 
      WHERE CODIGO_CLASE = @CODIGO_CLASE
      ORDER BY POSICION

END
GO
/****** Object:  StoredProcedure [MANT].[USP_CLASIFICACION_MATERIAL_CLASE_SEL]    Script Date: 25/02/2020 18:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [MANT].[USP_CLASIFICACION_MATERIAL_CLASE_SEL]  
(   
 @NOMBRE_PARAMETRO VARCHAR(50)   
)  
AS  
BEGIN  
  
    DECLARE @CODIGO_GRUPO NVARCHAR(50),@NOMBRE_CLASE VARCHAR(50),@POS INT      
    --SET @POS = CHARINDEX(';',@NOMBRE_PARAMETRO)  
    --SELECT @CODIGO_GRUPO = SUBSTRING(@NOMBRE_PARAMETRO,1,@POS-1),  
    --       @NOMBRE_CLASE = SUBSTRING(@NOMBRE_PARAMETRO,@POS+1,LEN(@NOMBRE_PARAMETRO))  
    SELECT @CODIGO_GRUPO = @NOMBRE_PARAMETRO            
  
    --SET @NOMBRE_CLASE = '%'+ISNULL(@NOMBRE_CLASE,'')+'%'  
  
 SELECT DISTINCT  
   --CODIGO_GRUPO As IdGrupo,  
   CODIGO_SEGMENTO+' '+CODIGO_GRUPO+' '+CODIGO_CLASE As IdClase,  
   NOMBRE_CLASE As NombreClase   
    FROM MANT.CLASIFICACION_MATERIAL   
 --WHERE NOMBRE_CLASE LIKE @NOMBRE_CLASE   
 -- AND (CODIGO_GRUPO = @CODIGO_GRUPO OR ISNULL(@CODIGO_GRUPO,'') = '')   
 WHERE (CODIGO_GRUPO = @CODIGO_GRUPO OR ISNULL(@CODIGO_GRUPO,'') = '')   
  
END  
  
  
  
  
  
  
  
  
GO
/****** Object:  StoredProcedure [MANT].[USP_CLASIFICACION_MATERIAL_GRUPO_SEL]    Script Date: 25/02/2020 18:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [MANT].[USP_CLASIFICACION_MATERIAL_GRUPO_SEL]
(
	@NUMERO_PAGINA	INT = 1,
	@TAMANIO_PAGINA	INT = -1
)
AS
BEGIN

	DECLARE @lPageNbr	INT,
			@lPageSize	INT,
			@lFirstRec	INT,
			@lLAStRec	INT

	SET @lPageNbr = @NUMERO_PAGINA
	SET @lPageSize = @TAMANIO_PAGINA

	SET @lFirstRec = (@lPageNbr - 1) * @lPageSize
	SET @lLAStRec = (@lPageNbr * @lPageSize + 1);
	 

	WITH	CTE_Results AS (SELECT DISTINCT ROW_NUMBER() OVER (ORDER BY NOMBRE_GRUPO ASC) AS RowNumber,
			COUNT(*) OVER() AS RowsTotal,
			CONVERT(VARCHAR, COUNT(*) OVER())		AS RowId,  
			C.CODIGO_SEGMENTO as IdSegmento,    
			C.CODIGO_GRUPO as IdGrupo,
			C.NOMBRE_GRUPO as NombreGrupo
	FROM	(SELECT DISTINCT CODIGO_SEGMENTO,CODIGO_GRUPO,NOMBRE_GRUPO FROM MANT.CLASIFICACION_MATERIAL ) C)

	SELECT	DISTINCT
	        RowNumber,
			RowsTotal,
			RowId,
			IdSegmento,
			IdGrupo,
			NombreGrupo	
    FROM    CTE_Results
    WHERE   @TAMANIO_PAGINA < 0 OR ( RowNumber > @lFirstRec AND RowNumber < @lLAStRec)          

END









GO
/****** Object:  StoredProcedure [MANT].[USP_CLASIFICACION_MATERIAL_SEGMENTO_SEL]    Script Date: 25/02/2020 18:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [MANT].[USP_CLASIFICACION_MATERIAL_SEGMENTO_SEL]
(
	@NUMERO_PAGINA	INT = 1,
	@TAMANIO_PAGINA	INT = -1
)
AS
BEGIN

	DECLARE @lPageNbr	INT,
			@lPageSize	INT,
			@lFirstRec	INT,
			@lLAStRec	INT

	SET @lPageNbr = @NUMERO_PAGINA
	SET @lPageSize = @TAMANIO_PAGINA

	SET @lFirstRec = (@lPageNbr - 1) * @lPageSize
	SET @lLAStRec = (@lPageNbr * @lPageSize + 1);
	 

	WITH	CTE_Results AS (SELECT DISTINCT ROW_NUMBER() OVER (ORDER BY NOMBRE_SEGMENTO ASC) AS RowNumber,
			COUNT(*) OVER() AS RowsTotal,
			CONVERT(VARCHAR, COUNT(*) OVER())		AS RowId,      
			C.CODIGO_SEGMENTO as IdSegmento,
			C.NOMBRE_SEGMENTO as NombreSegmento
	FROM	(SELECT DISTINCT CODIGO_SEGMENTO,NOMBRE_SEGMENTO FROM MANT.CLASIFICACION_MATERIAL ) C)

	SELECT	DISTINCT
	        RowNumber,
			RowsTotal,
			RowId,
			IdSegmento,
			NombreSegmento	
    FROM    CTE_Results
    WHERE   @TAMANIO_PAGINA < 0 OR ( RowNumber > @lFirstRec AND RowNumber < @lLAStRec)          

END









GO
/****** Object:  UserDefinedFunction [dbo].[Fn_ParametroDescripcion_Devolver]    Script Date: 25/02/2020 18:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Function [dbo].[Fn_ParametroDescripcion_Devolver](
    @iCodParametro  int,
    @iCodSeccion    int,
    @iCodDevSeccion int,
    @vCodValor      varchar(10)) Returns Varchar(200)
As
Begin
       Declare @vDescripcion varchar(200) 

       Select @vDescripcion =(Select B.VALOR 
                             From STRACON_POLITICAS.GRL.PARAMETRO_VALOR B WITH (NOLOCK) 
                             Where B.CODIGO_PARAMETRO = @iCodParametro And B.CODIGO_SECCION = @iCodDevSeccion
                               And B.CODIGO_VALOR = A.CODIGO_VALOR)
       From STRACON_POLITICAS.GRL.PARAMETRO_VALOR A WITH (NOLOCK) 
       Where A.CODIGO_PARAMETRO = @iCodParametro 
         And A.CODIGO_SECCION   = @iCodSeccion
         And A.VALOR            = @vCodValor

      Return @vDescripcion
End




GO
/****** Object:  UserDefinedFunction [TRO].[FN_REUNION_PORCENTAJE_ASISTENCIA_INASISTENCIA]    Script Date: 25/02/2020 18:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [TRO].[FN_REUNION_PORCENTAJE_ASISTENCIA_INASISTENCIA]
(
	@IDENTIFICADOR   INT,
	@ID_REUNION		 UNIQUEIDENTIFIER
)
RETURNS VARCHAR(4)
AS         
BEGIN
	DECLARE @PORCENTAJE VARCHAR(4),
			@ASISTENCIA INT,
			@INASISTENCIA INT

	--select @ASISTENCIA = ((SELECT COUNT(1) FROM TRO.Reunion_Persona P2 WHERE P2.ASISTIO=1 AND P2.ID_REUNION=@ID_REUNION AND ESTADO_REGISTRO='1')*100)/
	--			   (SELECT COUNT(1) FROM TRO.Reunion_Persona P1 WHERE P1.ID_REUNION=@ID_REUNION AND ESTADO_REGISTRO='1')


	declare @Asistio int =(SELECT COUNT(1) FROM TRO.Reunion_Persona P2 WHERE P2.ASISTIO=1 AND P2.ID_REUNION=@ID_REUNION AND ESTADO_REGISTRO='1');
	declare @Registrados int =(SELECT COUNT(1) FROM TRO.Reunion_Persona P1 WHERE P1.ID_REUNION=@ID_REUNION AND ESTADO_REGISTRO='1');

	select @ASISTENCIA = (@Asistio*100)/
				   ( 
				   case when @Registrados<>0
						then @Registrados
					else
						1
						end
					);
	
	select @INASISTENCIA= 100 - @ASISTENCIA

	IF @IDENTIFICADOR = 1   
	BEGIN  
		SELECT @PORCENTAJE = CONVERT(VARCHAR(4), @ASISTENCIA)--+'%'
	END  

	IF @IDENTIFICADOR = 2   
	BEGIN  
		SELECT @PORCENTAJE = CONVERT(VARCHAR(4), @INASISTENCIA)--+'%'
	END    
	
	RETURN @PORCENTAJE
END


GO
/****** Object:  Table [dbo].[Comprobante]    Script Date: 25/02/2020 18:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comprobante](
	[id] [int] NOT NULL,
	[Cliente1] [varchar](50) NULL,
	[Total] [numeric](18, 0) NULL,
	[Creado] [varchar](50) NULL,
 CONSTRAINT [PK_Comprobante] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ComprobanteDetalle]    Script Date: 25/02/2020 18:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComprobanteDetalle](
	[id] [int] NOT NULL,
	[ComprobanteId] [int] NULL,
	[ProductoId] [int] NULL,
	[Cantidad] [int] NULL,
	[PrecioUnitario] [numeric](18, 0) NULL,
	[Monto] [numeric](18, 0) NULL,
 CONSTRAINT [PK_ComprobanteDetalle] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaePllaCodigoMaterial]    Script Date: 25/02/2020 18:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MaePllaCodigoMaterial](
	[iCodPlanilla] [int] IDENTITY(1,1) NOT NULL,
	[vNumPlanilla] [varchar](50) NULL,
	[sdFecPlanilla] [smalldatetime] NOT NULL,
	[vCodSolicitante] [varchar](50) NULL,
	[vDesPlanilla] [varchar](50) NULL,
	[cCodTipMaterial] [char](4) NULL,
	[cCodCatValoracion] [char](4) NULL,
	[vCodUniMedida] [varchar](5) NULL,
	[cCodSegmento] [char](12) NULL,
	[cCodGrupo] [char](12) NULL,
	[cCodClase] [char](12) NULL,
	[cCodAtributo] [char](18) NULL,
	[cCodEstado] [char](1) NULL,
	[bEstActivo] [bit] NOT NULL,
	[vCodUsuCreacion] [varchar](50) NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[vNomTerCreacion] [varchar](100) NOT NULL,
	[vCodUsuModificacion] [varchar](50) NULL,
	[sdFecActModificacion] [smalldatetime] NULL,
	[vNomTerModificacion] [varchar](100) NULL,
 CONSTRAINT [PK_MaePllaCodigoMaterial] PRIMARY KEY CLUSTERED 
(
	[iCodPlanilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 25/02/2020 18:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[id] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Precio] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TabClaMaterial]    Script Date: 25/02/2020 18:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TabClaMaterial](
	[cCodSegmento] [char](12) NULL,
	[vNomSegmento] [varchar](200) NULL,
	[cCodGrupo] [char](12) NULL,
	[vNomGrupo] [varchar](200) NULL,
	[cCodClase] [char](12) NULL,
	[vNomClase] [varchar](200) NULL,
	[cCodAtributo] [char](18) NULL,
	[vNomAtributo] [varchar](200) NULL,
	[tiOrden] [tinyint] NULL,
	[bObligatorio] [bit] NULL,
	[vCodUsuCreacion] [varchar](50) NOT NULL,
	[sdFecCreacion] [smalldatetime] NOT NULL,
	[vNomTerCreacion] [varchar](100) NOT NULL,
	[vCodUsuModificacion] [varchar](50) NULL,
	[sdFecActModificacion] [smalldatetime] NULL,
	[vNomTerModificacion] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [STRACON_SGCO] SET  READ_WRITE 
GO
