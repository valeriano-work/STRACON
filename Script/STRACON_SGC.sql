USE [master]
GO
/****** Object:  Database [STRACON_SGC]    Script Date: 25/02/2020 17:59:11 ******/
CREATE DATABASE [STRACON_SGC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'STRACON_SGC', FILENAME = N'E:\DATA\STRACON_SGC.mdf' , SIZE = 17131520KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'STRACON_SGC_log', FILENAME = N'E:\DATA\STRACON_SGC_log.ldf' , SIZE = 16383232KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [STRACON_SGC] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [STRACON_SGC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [STRACON_SGC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [STRACON_SGC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [STRACON_SGC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [STRACON_SGC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [STRACON_SGC] SET ARITHABORT OFF 
GO
ALTER DATABASE [STRACON_SGC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [STRACON_SGC] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [STRACON_SGC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [STRACON_SGC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [STRACON_SGC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [STRACON_SGC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [STRACON_SGC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [STRACON_SGC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [STRACON_SGC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [STRACON_SGC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [STRACON_SGC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [STRACON_SGC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [STRACON_SGC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [STRACON_SGC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [STRACON_SGC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [STRACON_SGC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [STRACON_SGC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [STRACON_SGC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [STRACON_SGC] SET RECOVERY FULL 
GO
ALTER DATABASE [STRACON_SGC] SET  MULTI_USER 
GO
ALTER DATABASE [STRACON_SGC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [STRACON_SGC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [STRACON_SGC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [STRACON_SGC] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'STRACON_SGC', N'ON'
GO
USE [STRACON_SGC]
GO
/****** Object:  User [USR_STRACON_SGC]    Script Date: 25/02/2020 17:59:11 ******/
CREATE USER [USR_STRACON_SGC] FOR LOGIN [USR_STRACON_SGC] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [USR_STRACON_POLITICAS]    Script Date: 25/02/2020 17:59:11 ******/
CREATE USER [USR_STRACON_POLITICAS] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [USR_STRACON_SGC]
GO
ALTER ROLE [db_datareader] ADD MEMBER [USR_STRACON_SGC]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [USR_STRACON_SGC]
GO
ALTER ROLE [db_owner] ADD MEMBER [USR_STRACON_POLITICAS]
GO
ALTER ROLE [db_datareader] ADD MEMBER [USR_STRACON_POLITICAS]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [USR_STRACON_POLITICAS]
GO
/****** Object:  Schema [CTR]    Script Date: 25/02/2020 17:59:11 ******/
CREATE SCHEMA [CTR]
GO
/****** Object:  Schema [GRL]    Script Date: 25/02/2020 17:59:11 ******/
CREATE SCHEMA [GRL]
GO
/****** Object:  Schema [HST]    Script Date: 25/02/2020 17:59:11 ******/
CREATE SCHEMA [HST]
GO
/****** Object:  Schema [TMP]    Script Date: 25/02/2020 17:59:11 ******/
CREATE SCHEMA [TMP]
GO
/****** Object:  FullTextCatalog [FullText]    Script Date: 25/02/2020 17:59:11 ******/
CREATE FULLTEXT CATALOG [FullText]WITH ACCENT_SENSITIVITY = ON

GO
/****** Object:  PartitionFunction [ifts_comp_fragment_partition_function_15941E4D]    Script Date: 25/02/2020 17:59:11 ******/
CREATE PARTITION FUNCTION [ifts_comp_fragment_partition_function_15941E4D](varbinary(128)) AS RANGE LEFT FOR VALUES (0x00680065006C007600650074006900630061)
GO
/****** Object:  PartitionFunction [ifts_comp_fragment_partition_function_6A9A4110]    Script Date: 25/02/2020 17:59:11 ******/
CREATE PARTITION FUNCTION [ifts_comp_fragment_partition_function_6A9A4110](varbinary(128)) AS RANGE LEFT FOR VALUES (0x006A006C0062007A00760033003100360077007700700076006E006F00380061006200750065006600610036006700620036007900720069)
GO
/****** Object:  PartitionScheme [ifts_comp_fragment_data_space_15941E4D]    Script Date: 25/02/2020 17:59:11 ******/
CREATE PARTITION SCHEME [ifts_comp_fragment_data_space_15941E4D] AS PARTITION [ifts_comp_fragment_partition_function_15941E4D] TO ([PRIMARY], [PRIMARY])
GO
/****** Object:  PartitionScheme [ifts_comp_fragment_data_space_6A9A4110]    Script Date: 25/02/2020 17:59:11 ******/
CREATE PARTITION SCHEME [ifts_comp_fragment_data_space_6A9A4110] AS PARTITION [ifts_comp_fragment_partition_function_6A9A4110] TO ([PRIMARY], [PRIMARY])
GO
/****** Object:  UserDefinedTableType [CTR].[LISTA_GUID]    Script Date: 25/02/2020 17:59:11 ******/
CREATE TYPE [CTR].[LISTA_GUID] AS TABLE(
	[CODIGO] [uniqueidentifier] NULL
)
GO
/****** Object:  UserDefinedTableType [CTR].[LISTA_MONTOS_CONTRATO_TYPE]    Script Date: 25/02/2020 17:59:11 ******/
CREATE TYPE [CTR].[LISTA_MONTOS_CONTRATO_TYPE] AS TABLE(
	[CodigoMoneda] [char](3) NULL,
	[MontoContrato] [decimal](18, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [CTR].[LISTA_TIPO_SERVICIO]    Script Date: 25/02/2020 17:59:11 ******/
CREATE TYPE [CTR].[LISTA_TIPO_SERVICIO] AS TABLE(
	[CODIGO_TIPO_SERVICIO] [nvarchar](5) NULL
)
GO
/****** Object:  StoredProcedure [CTR].[INSERTAR_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[INSERTAR_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION]
(@CODIGO_CONTRATO UNIQUEIDENTIFIER,
@CODIGO_ARCHIVO INT,
@NOMBRE_ARCHIVO NVARCHAR(255),
@RUTA_ARCHIVO_SHAREPOINT NVARCHAR(MAX),
@USUARIO_CREACION NVARCHAR(50),
@TERMINAL_CREACION NVARCHAR(50),
@FECHA_RESOLUCION DATETIME)
AS
BEGIN

INSERT INTO CTR.CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION
(CODIGO_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION, CODIGO_CONTRATO, CODIGO_ARCHIVO, NOMBRE_ARCHIVO, RUTA_ARCHIVO_SHAREPOINT, USUARIO_CREACION, FECHA_CREACION, TERMINAL_CREACION, ESTADO_REGISTRO)
SELECT NEWID(), @CODIGO_CONTRATO, @CODIGO_ARCHIVO, @NOMBRE_ARCHIVO, @RUTA_ARCHIVO_SHAREPOINT, @USUARIO_CREACION, GETDATE(), @TERMINAL_CREACION, 1

DECLARE @NUMERO_CONTRATO VARCHAR(100) = (SELECT NUMERO_CONTRATO FROM CTR.CONTRATO WHERE CODIGO_CONTRATO = @CODIGO_CONTRATO)

UPDATE CTR.CONTRATO SET FECHA_RESOLUCION = @FECHA_RESOLUCION, CODIGO_ESTADO = 'RS' WHERE NUMERO_CONTRATO = @NUMERO_CONTRATO

END

GO
/****** Object:  StoredProcedure [CTR].[USP_ACTUALIZA_PROV_ACUMULADO_NOTIFICADO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_ACTUALIZA_PROV_ACUMULADO_NOTIFICADO]
@USER_MODIFICA nvarchar(50),
@TERMINAL_MODIFICA nvarchar(50)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_ACTUALIZA_PROV_ACUMULADO_NOTIFICADO
Propósito:  Actualiza los registros de proveedor acumulado una vez que fueron notificados 
Descripción de Parámetros: 
		@USER_MODIFICA:	Parámetro de entrada de tipo nvarchar, que representa user modifica.
		@TERMINAL_MODIFICA:	Parámetro de entrada de tipo nvarchar, que representa terminal modifica.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/

BEGIN

UPDATE CTR.PROVEEDOR_ACUMULADO SET INDICADOR_NOTIFICADO=1, FECHA_MODIFICACION=GETDATE() , 
			USUARIO_MODIFICACION=@USER_MODIFICA,	TERMINAL_MODIFICACION=@TERMINAL_MODIFICA
WHERE INDICADOR_NOTIFICADO=0 AND INDICADOR_LIMITE_ALCANZADO=1
END

GO
/****** Object:  StoredProcedure [CTR].[USP_ACTUALIZAR_FLUJO_APROBACION_ESTADIO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_ACTUALIZAR_FLUJO_APROBACION_ESTADIO]
@CODIGO_CONTRATO UNIQUEIDENTIFIER,
@CODIGO_FLUJO_APROBACION UNIQUEIDENTIFIER,
@CODIGO_ESTADIO_ACTUAL UNIQUEIDENTIFIER
AS
BEGIN

DECLARE @CODIGO_FLUJO_APROBACION_ESTADIO UNIQUEIDENTIFIER

SELECT @CODIGO_FLUJO_APROBACION_ESTADIO = B.CODIGO_FLUJO_APROBACION_ESTADIO FROM CTR.FLUJO_APROBACION A JOIN CTR.FLUJO_APROBACION_ESTADIO B
ON A.CODIGO_FLUJO_APROBACION = B.CODIGO_FLUJO_APROBACION
WHERE A.ESTADO_REGISTRO = 1 AND B.ESTADO_REGISTRO = 1
AND B.CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION AND B.ORDEN = 1 

IF @CODIGO_ESTADIO_ACTUAL IS NULL --ESTO SIGNIFICA QUE ESTA EN EDICION PARCIAL
BEGIN
	UPDATE CTR.CONTRATO_ESTADIO SET CODIGO_FLUJO_APROBACION_ESTADIO = @CODIGO_FLUJO_APROBACION_ESTADIO WHERE CODIGO_CONTRATO = @CODIGO_CONTRATO
	AND ESTADO_REGISTRO = 1
	
END

END

GO
/****** Object:  StoredProcedure [CTR].[USP_ADENDAS_CONTRATO_VENCIDO_INS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_ADENDAS_CONTRATO_VENCIDO_INS]
@CODIGO_UNIDAD_OPERATIVA uniqueidentifier,
@NUMERO_CONTRATO nvarchar(50),
@DESCRIPCION nvarchar(255),
@NUMERO_ADENDA int,
@NUMERO_ADENDA_CONCATENADO nvarchar(100)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_ADENDAS_CONTRATO_VENCIDO_INS
Propósito: Ingresar adendas a contratos vencidos
Descripción de Parámetros: 		
Creado por: GMD
Fecha. Creación: 2017-07-04
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	INSERT INTO TMP.ADENDAS_CONTRATO_VENCIDO
			(CODIGO_UNIDAD_OPERATIVA,
			NUMERO_CONTRATO,
			DESCRIPCION,
			NUMERO_ADENDA,
			NUMERO_ADENDA_CONCATENADO,
			FECHA_CREACION,
			ESTADO_ENVIO
			) 
	VALUES (@CODIGO_UNIDAD_OPERATIVA,
			@NUMERO_CONTRATO,
			@DESCRIPCION,
			@NUMERO_ADENDA,
			@NUMERO_ADENDA_CONCATENADO,
			GETDATE(),
			0)
END

GO
/****** Object:  StoredProcedure [CTR].[USP_APRUEBA_CONTRATO_ESTADIO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_APRUEBA_CONTRATO_ESTADIO]
--'de21e5e1-1f38-4087-a5bb-24725c1b8884', '003', 'infra.user', '001'
	@CODIGO_CONTRATO_ESTADIO uniqueidentifier,
	@CODIGO_IDENTIFICACION_UO nvarchar(50),
	@USUARIO_CREACION nvarchar(50),
	@TERMINAL_CREACION nvarchar(50),
	@CodigoUsuarioCreacionContrato	UNIQUEIDENTIFIER,
	@motivo_aprobacion NVARCHAR(MAX) = ''

AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_APRUEBA_CONTRATO_ESTADIO
Propósito:  Aprueba los estadios de los contratos. 
Descripción de Parámetros: 
@CODIGO_CONTRATO_ESTADIO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio.
@CODIGO_IDENTIFICACION_UO:	Parámetro de entrada de tipo nvarchar, que representa codigo identificacion uo.
@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/

BEGIN

	DECLARE @CodigoFlujoAprobacion			UNIQUEIDENTIFIER,
			@CodigoFlujoEstadioActual		UNIQUEIDENTIFIER,
			@CodigoContrato					UNIQUEIDENTIFIER,
			@RowMin							INT, 
			@RowMax							INT,
			@IndicadorVersionOficial		BIT, 
			@IndicadorPermiteCarga			BIT, 
			@IndicadorNumeroContrato		BIT,
			@NumeroContrato					NVARCHAR(15), 
			@TotalContratos					INT,
			@PrefijoNumeroContratoAnioMes	VARCHAR(15),
			@UltimoEstadio					TINYINT,
			@OrdenFlujoAprobacionEstadio	TINYINT,
			@OrdenNuevoFAE					TINYINT,
			@CodigoEstadioActual			UNIQUEIDENTIFIER,			
			@CodigoUsuarioEstadioEdicion	UNIQUEIDENTIFIER,
			@NUMERO_DOCUMENTO VARCHAR (20) = NULL,
			@ES_VINCULADA BIT = 0

/*1. Obtenemos Flujo actual de Aprobacion.*/
	SELECT top 1 @CodigoFlujoAprobacion			=	FAE.CODIGO_FLUJO_APROBACION			
	FROM	CTR.CONTRATO_ESTADIO CE (NOLOCK) 
	INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK)
		ON	(CE.CODIGO_FLUJO_APROBACION_ESTADIO	=	FAE.CODIGO_FLUJO_APROBACION_ESTADIO)
	WHERE	CE.CODIGO_CONTRATO_ESTADIO			=	@CODIGO_CONTRATO_ESTADIO	

	/*2. Obtenemos Datos del Contrato*/
	SELECT TOP 1	@CodigoContrato				=	CE.CODIGO_CONTRATO,
					@CodigoFlujoEstadioActual	=	CE.CODIGO_FLUJO_APROBACION_ESTADIO 
	FROM CTR.CONTRATO_ESTADIO CE (NOLOCK)  
	INNER JOIN CTR.CONTRATO CT (NOLOCK)
		ON	(CE.CODIGO_CONTRATO = CT.CODIGO_CONTRATO )
	WHERE	CE.CODIGO_CONTRATO_ESTADIO=@CODIGO_CONTRATO_ESTADIO
	AND		CT.ESTADO_REGISTRO='1'

	DECLARE @CODIGO_ESTADO_CONTRATO_ESTADIO VARCHAR(10) = (
		SELECT CODIGO_ESTADO_CONTRATO_ESTADIO 
		FROM CTR.CONTRATO_ESTADIO 
		WHERE CODIGO_CONTRATO_ESTADIO = @CODIGO_CONTRATO_ESTADIO
	)

	--Verificar si la empresa proveedora del contrato es una empresa vinculada
	SELECT @NUMERO_DOCUMENTO = NUMERO_DOCUMENTO FROM CTR.PROVEEDOR 
	   WHERE CODIGO_PROVEEDOR = (SELECT CODIGO_PROVEEDOR FROM CTR.CONTRATO WHERE CODIGO_CONTRATO = @CodigoContrato)
	   	   
	IF (@NUMERO_DOCUMENTO IS NOT NULL)
	BEGIN
	
		IF EXISTS(SELECT 1 FROM CTR.EMPRESA_VINCULADA EM 
			WHERE EM.NUMERO_RUC = @NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND EM.ESTADO_REGISTRO = '1')
		BEGIN 	
			SET @ES_VINCULADA = 1
		END
	END

	IF(@CODIGO_ESTADO_CONTRATO_ESTADIO = 'I') BEGIN
		/*3. Información del Flujo de Aprobación. */
		SELECT	@IndicadorVersionOficial		= INDICADOR_VERSION_OFICIAL,
				@IndicadorPermiteCarga			= INDICADOR_PERMITE_CARGA,
				@IndicadorNumeroContrato		= INDICADOR_NUMERO_CONTRATO,
				@OrdenFlujoAprobacionEstadio	= FAE.ORDEN
		FROM CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK)
		WHERE CODIGO_FLUJO_APROBACION_ESTADIO	= @CodigoFlujoEstadioActual 
				
		IF(@ES_VINCULADA = 1)
		BEGIN
			SELECT @CodigoUsuarioEstadioEdicion = FAP.CODIGO_TRABAJADOR
			FROM CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK) 
			INNER JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP (NOLOCK) 
				ON ( FAE.CODIGO_FLUJO_APROBACION_ESTADIO=	FAP.CODIGO_FLUJO_APROBACION_ESTADIO )
			WHERE	FAE.CODIGO_FLUJO_APROBACION			=	@CodigoFlujoAprobacion
			AND		FAE.ESTADO_REGISTRO					=	'1' 
			AND		FAP.ESTADO_REGISTRO					=	'1' 
			AND		FAP.CODIGO_TIPO_PARTICIPANTE		=	'V'		
			AND		FAE.ORDEN							=    1	
	   END

	   IF(@ES_VINCULADA = 0 OR @CodigoUsuarioEstadioEdicion IS NULL)
	   BEGIN
			SELECT @CodigoUsuarioEstadioEdicion = FAP.CODIGO_TRABAJADOR
			FROM CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK) 
			INNER JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP (NOLOCK) 
				ON ( FAE.CODIGO_FLUJO_APROBACION_ESTADIO=	FAP.CODIGO_FLUJO_APROBACION_ESTADIO )
			WHERE	FAE.CODIGO_FLUJO_APROBACION			=	@CodigoFlujoAprobacion
			AND		FAE.ESTADO_REGISTRO					=	'1' 
			AND		FAP.ESTADO_REGISTRO					=	'1' 
			AND		FAP.CODIGO_TIPO_PARTICIPANTE		=	'R'		
			AND		FAE.ORDEN							=    1
	   END
	  
		/*3. Obtenemos los flujos de Aprobación del Contrato*/

		SELECT  ROW_NUMBER() OVER(ORDER BY FAE.ORDEN) AS ROWID,
				CodigoContrato				= @CodigoContrato, 
				CodigoFlujoAprobacionEstadio= FAE.CODIGO_FLUJO_APROBACION_ESTADIO,
				CodigoResponsable			= CASE 
												WHEN @ES_VINCULADA = 1 and ISNULL((SELECT FAPV.CODIGO_TRABAJADOR FROM CTR.FLUJO_APROBACION_PARTICIPANTE FAPV 
																			WHERE FAPV.CODIGO_FLUJO_APROBACION_ESTADIO = FAE.CODIGO_FLUJO_APROBACION_ESTADIO 
																			AND FAPV.ESTADO_REGISTRO = '1' AND FAPV.CODIGO_TIPO_PARTICIPANTE = 'V'), FAP.CODIGO_TRABAJADOR) = @CodigoUsuarioEstadioEdicion 
													THEN @CodigoUsuarioCreacionContrato
												WHEN @ES_VINCULADA = 1 and ISNULL((SELECT FAPV.CODIGO_TRABAJADOR FROM CTR.FLUJO_APROBACION_PARTICIPANTE FAPV 
																			WHERE FAPV.CODIGO_FLUJO_APROBACION_ESTADIO = FAE.CODIGO_FLUJO_APROBACION_ESTADIO 
																			AND FAPV.ESTADO_REGISTRO = '1' AND FAPV.CODIGO_TIPO_PARTICIPANTE = 'V'), FAP.CODIGO_TRABAJADOR) <> @CodigoUsuarioEstadioEdicion 
													THEN ISNULL((SELECT FAPV.CODIGO_TRABAJADOR FROM CTR.FLUJO_APROBACION_PARTICIPANTE FAPV 
																			WHERE FAPV.CODIGO_FLUJO_APROBACION_ESTADIO = FAE.CODIGO_FLUJO_APROBACION_ESTADIO 
																			AND FAPV.ESTADO_REGISTRO = '1' AND FAPV.CODIGO_TIPO_PARTICIPANTE = 'V'), FAP.CODIGO_TRABAJADOR)	
												WHEN @ES_VINCULADA = 0 and FAP.CODIGO_TRABAJADOR = @CodigoUsuarioEstadioEdicion 
												THEN @CodigoUsuarioCreacionContrato else FAP.CODIGO_TRABAJADOR END, 
				FAE.ORDEN
		INTO #TEMP_FLUJOS
		FROM CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK) 
		INNER JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP (NOLOCK) 
			ON ( FAE.CODIGO_FLUJO_APROBACION_ESTADIO=	FAP.CODIGO_FLUJO_APROBACION_ESTADIO )		
		WHERE	FAE.CODIGO_FLUJO_APROBACION			=	@CodigoFlujoAprobacion
		AND		FAE.ESTADO_REGISTRO					=	'1' 
		AND		FAP.ESTADO_REGISTRO					=	'1' 
		AND		FAP.CODIGO_TIPO_PARTICIPANTE		=	'R'	
		AND		FAE.CODIGO_FLUJO_APROBACION_ESTADIO	<>	@CodigoFlujoEstadioActual 
		AND		FAE.ORDEN							>	@OrdenFlujoAprobacionEstadio
		
		/*4. Insertamos el siguiente estadio.*/
		IF EXISTS (SELECT  CodigoFlujoAprobacionEstadio FROM #TEMP_FLUJOS )BEGIN
		--SELECT @RowMin = MIN(ROWID), @RowMax=MAX(ROWID), @UltimoEstadio=MAX(ORDEN) FROM #TEMP_FLUJOS
			SELECT @RowMin = MIN(ROWID), @RowMax=MAX(ROWID) FROM #TEMP_FLUJOS
			WHILE  @RowMin < = @RowMax BEGIN
				SELECT @CodigoEstadioActual = CodigoFlujoAprobacionEstadio, @OrdenNuevoFAE=ORDEN  FROM #TEMP_FLUJOS WHERE ROWID=@RowMin

				INSERT INTO CTR.CONTRATO_ESTADIO (CODIGO_CONTRATO_ESTADIO,CODIGO_CONTRATO,CODIGO_FLUJO_APROBACION_ESTADIO,
							FECHA_INGRESO,CODIGO_RESPONSABLE,CODIGO_ESTADO_CONTRATO_ESTADIO,
						ESTADO_REGISTRO,USUARIO_CREACION,FECHA_CREACION, TERMINAL_CREACION)
				SELECT   NEWID(),CodigoContrato, CodigoFlujoAprobacionEstadio, GETDATE(),  CodigoResponsable,'I','1',@USUARIO_CREACION, GETDATE(), @TERMINAL_CREACION
				FROM #TEMP_FLUJOS 
				WHERE ROWID=@RowMin
				SET @RowMin = @RowMax + 1--para q termine el flujo.
				-----------
				UPDATE CTR.CONTRATO SET CODIGO_ESTADIO_ACTUAL = @CodigoEstadioActual
				WHERE CODIGO_CONTRATO=@CodigoContrato
												
				/*Evaluamos si estamos en el ultimo orden para dar por Vigente al Contrato.*/
				--14-07-2015
				--if @OrdenNuevoFAE=@UltimoEstadio
				--	BEGIN
				--					UPDATE CTR.CONTRATO SET CODIGO_ESTADO='V'
				--					WHERE CODIGO_CONTRATO=@CodigoContrato						
				--	END
			END
		END

		/*14-07-2015*/
		SELECT @UltimoEstadio=MAX(ORDEN) FROM CTR.FLUJO_APROBACION_ESTADIO (NOLOCK)
		WHERE CODIGO_FLUJO_APROBACION=@CodigoFlujoAprobacion AND ESTADO_REGISTRO='1'

		IF ( @OrdenFlujoAprobacionEstadio = @UltimoEstadio ) BEGIN
			DECLARE @FECHA_INICIO	DATETIME,
					@FECHA_FIN		DATETIME,
					@CODIGO_ESTADO	VARCHAR(2)=''

			SELECT	@FECHA_INICIO	=	FECHA_INICIO_VIGENCIA,
					@FECHA_FIN		=	FECHA_FIN_VIGENCIA
			FROM CTR.CONTRATO 
			WHERE CODIGO_CONTRATO	=	@CodigoContrato	

			SELECT @CODIGO_ESTADO	=	CASE WHEN @FECHA_FIN<CAST(GETDATE() as date) THEN 'C' ELSE 'V' END

			UPDATE CTR.CONTRATO 
				SET CODIGO_ESTADO	=	@CODIGO_ESTADO--'V' 
			WHERE CODIGO_CONTRATO	=	@CodigoContrato	
		END 
		/****************************************************************************************/

		/*5. Finalizamos el Contrato Estadio Actual*/

		UPDATE CTR.CONTRATO_ESTADIO 
			SET FECHA_FINALIZACION				=	GETDATE(),
				CODIGO_ESTADO_CONTRATO_ESTADIO	=	'A',														  
				USUARIO_MODIFICACION			=	@USUARIO_CREACION, 
				FECHA_MODIFICACION				=	GETDATE(), 
				TERMINAL_MODIFICACION			=	@TERMINAL_CREACION,
				MOTIVO_APROBACION				=	@motivo_aprobacion	
		WHERE CODIGO_CONTRATO_ESTADIO			=	@CODIGO_CONTRATO_ESTADIO

		/*6. Actualizaciones dependiendo de los Indicadores.*/
		--Número de Contrato
		IF  (@INDICADORNUMEROCONTRATO = 1 )BEGIN
			SELECT	@PrefijoNumeroContratoAnioMes= @CODIGO_IDENTIFICACION_UO+'-'+convert(varchar(4),GETDATE(),112)+'-%'
			SELECT	@TotalContratos = COUNT(CODIGO_CONTRATO) 
			FROM	CTR.CONTRATO CT (NOLOCK) 
			WHERE	CT.ESTADO_REGISTRO='1' 
			AND NUMERO_CONTRATO LIKE @PrefijoNumeroContratoAnioMes

			SELECT	@TotalContratos +=1
			SELECT	@NumeroContrato = @CODIGO_IDENTIFICACION_UO+'-'+convert(varchar(4),GETDATE(),112)+'-'+RIGHT('0000'+CONVERT(VARCHAR(4),@TotalContratos),4)

			IF EXISTS ( SELECT CT.CODIGO_CONTRATO FROM CTR.CONTRATO CT (NOLOCK) 
						WHERE CODIGO_CONTRATO	=	@CodigoContrato 
						AND ( NUMERO_CONTRATO IS NULL OR NUMERO_CONTRATO='' ) ) BEGIN					
				UPDATE CTR.CONTRATO 
					SET	NUMERO_CONTRATO		=	@NumeroContrato, 
						USUARIO_MODIFICACION=	@USUARIO_CREACION,
						FECHA_MODIFICACION	=	GETDATE(),
						TERMINAL_CREACION	=	@TERMINAL_CREACION	
				WHERE CODIGO_CONTRATO		=	@CodigoContrato
			END ELSE BEGIN
				SELECT	@NumeroContrato =	NUMERO_CONTRATO
				FROM	CTR.CONTRATO (NOLOCK)
				WHERE	CODIGO_CONTRATO	=	@CodigoContrato
			END
			
			SELECT TOP 1 CODIGO_CONTRATO,CODIGO_ARCHIVO,RUTA_ARCHIVO_SHAREPOINT,INDICADOR_ACTUAL,
			CONTENIDO=REPLACE(CONTENIDO,'#numero_contrato', @NumeroContrato), 
			NEW_VERSION= ISNULL([VERSION],0) + 1, ESTADO_REGISTRO,USUARIO_CREACION,FECHA_CREACION,TERMINAL_CREACION
			INTO #TEMP_NUEVO_CTRDOC
			FROM CTR.CONTRATO_DOCUMENTO (NOLOCK) WHERE CODIGO_CONTRATO=@CodigoContrato AND  INDICADOR_ACTUAL=1 AND ESTADO_REGISTRO='1'

			---Damos de baja a todos los documentos anteriores.------			

			UPDATE CTR.CONTRATO_DOCUMENTO  SET INDICADOR_ACTUAL=0, USUARIO_MODIFICACION=@USUARIO_CREACION,
			FECHA_MODIFICACION=GETDATE(), TERMINAL_CREACION=@TERMINAL_CREACION	
			WHERE CODIGO_CONTRATO=@CodigoContrato AND ESTADO_REGISTRO='1'

			INSERT INTO CTR.CONTRATO_DOCUMENTO (CODIGO_CONTRATO_DOCUMENTO,CODIGO_CONTRATO,
			CODIGO_ARCHIVO,RUTA_ARCHIVO_SHAREPOINT,INDICADOR_ACTUAL,[VERSION],CONTENIDO,
			ESTADO_REGISTRO,USUARIO_CREACION,FECHA_CREACION,TERMINAL_CREACION )
			SELECT NEWID(),CODIGO_CONTRATO,
			CODIGO_ARCHIVO,RUTA_ARCHIVO_SHAREPOINT,INDICADOR_ACTUAL,NEW_VERSION,CONTENIDO,
			ESTADO_REGISTRO,@USUARIO_CREACION,GETDATE(),@TERMINAL_CREACION
			FROM #TEMP_NUEVO_CTRDOC
			---Este registro será actualizado con el Código de Archivo de  SharePoint desde la aplicación.
			DROP TABLE #TEMP_NUEVO_CTRDOC
		END
		---Versión Oficial
		if  (@IndicadorVersionOficial= 1 )begin
		UPDATE CTR.CONTRATO 
		SET INDICADOR_VERSION_OFICIAL=1,
			USUARIO_MODIFICACION=@USUARIO_CREACION,
			FECHA_MODIFICACION=GETDATE(),
			TERMINAL_CREACION=@TERMINAL_CREACION
			WHERE CODIGO_CONTRATO=@CodigoContrato
		END

		DROP TABLE #TEMP_FLUJOS

	END

SELECT 1

END

GO
/****** Object:  StoredProcedure [CTR].[USP_AUDITORIA_EXISTE_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_AUDITORIA_EXISTE_SEL]
@CODIGO_UNIDAD_OPERATIVA UNIQUEIDENTIFIER = NULL,
@FECHA_PLANIFICADA DATETIME = NULL
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_AUDITORIA_EXISTE_SEL
Propósito:   Obtener el listado de la auditoría existente  
Descripción de Parámetros: 
		@CODIGO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@FECHA_PLANIFICADA:	Parámetro de entrada de tipo datetime, que representa fecha planificada.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
SELECT CODIGO_AUDITORIA AS CodigoAuditoria
FROM CTR.AUDITORIA
WHERE (CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA)
AND   (FECHA_PLANIFICADA = @FECHA_PLANIFICADA)
AND ESTADO_REGISTRO = '1'






GO
/****** Object:  StoredProcedure [CTR].[USP_AUDITORIA_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_AUDITORIA_SEL]
    (
      @CODIGO_AUDITORIA UNIQUEIDENTIFIER = NULL ,
      @CODIGO_UNIDAD_OPERATIVA UNIQUEIDENTIFIER = NULL ,
      @FECHA_PLANIFICADA_DESDE DATETIME = NULL ,
      @FECHA_PLANIFICADA_HASTA DATETIME = NULL ,
      @ESTADO_REGISTRO CHAR(1) = '1'
    )
AS 
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_AUDITORIA_SEL
Propósito:   Obtener el listado de la auditoría   
Descripción de Parámetros: 
		@CODIGO_AUDITORIA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo auditoria.
		@CODIGO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@FECHA_PLANIFICADA_DESDE:	Parámetro de entrada de tipo datetime, que representa fecha planificada desde.
		@FECHA_PLANIFICADA_HASTA:	Parámetro de entrada de tipo datetime, que representa fecha planificada hasta.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
    SELECT  [CODIGO_AUDITORIA] AS CodigoAuditoria ,
            [CODIGO_UNIDAD_OPERATIVA] AS CodigoUnidadOperativa ,
            [FECHA_PLANIFICADA] AS FechaPlanificada ,
            [FECHA_EJECUCION] AS FechaEjecucion ,
            [CANTIDAD_AUDITADAS] AS CantidadAuditadas ,
            [CANTIDAD_OBSERVADAS] AS CantidadObservadas ,
            [ESTADO_REGISTRO] AS EstadoRegistro ,
            [RESULTADO_AUDITORIA] AS ResultadoAuditoria
    FROM    [CTR].[AUDITORIA]
    WHERE   ( CODIGO_AUDITORIA = @CODIGO_AUDITORIA
              OR @CODIGO_AUDITORIA IS NULL
            )
            AND ( CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA
                  OR @CODIGO_UNIDAD_OPERATIVA IS NULL
                )
            AND ( ( FECHA_PLANIFICADA >= @FECHA_PLANIFICADA_DESDE
                    OR @FECHA_PLANIFICADA_DESDE IS NULL
                  )
                  AND ( FECHA_PLANIFICADA <= @FECHA_PLANIFICADA_HASTA
                        OR @FECHA_PLANIFICADA_HASTA IS NULL
                      )
                )
            AND ESTADO_REGISTRO = @ESTADO_REGISTRO

GO
/****** Object:  StoredProcedure [CTR].[USP_BANDEJA_BIEN_ALQUILER]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_BANDEJA_BIEN_ALQUILER]
@CODIGO_BIEN uniqueidentifier
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_BANDEJA_BIEN_ALQUILER
Propósito:  Obtener campos de tabla 
Descripción de Parámetros: 
		@CODIGO_BIEN:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo bien.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
SELECT BA.CODIGO_BIEN_ALQUILER, BA.CODIGO_BIEN, BA.INDICADOR_SIN_LIMITE, 
			 BA.CANTIDAD_LIMITE, BA.MONTO 
			 FROM CTR.BIEN_ALQUILER BA (NOLOCK)
WHERE BA.CODIGO_BIEN_ALQUILER=@CODIGO_BIEN
AND BA.ESTADO_REGISTRO='1'
END

GO
/****** Object:  StoredProcedure [CTR].[USP_BANDEJA_BIENALQUILER_POR_BIEN]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_BANDEJA_BIENALQUILER_POR_BIEN]
@CODIGO_BIEN UNIQUEIDENTIFIER = null
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_BANDEJA_BIENALQUILER_POR_BIEN
Propósito:  Retorna todos los bienes 
Descripción de Parámetros: 
		@CODIGO_BIEN:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo bien.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

SELECT CodigoBienAlquiler=CODIGO_BIEN_ALQUILER, 
			 CodigoBien=CODIGO_BIEN,
		     IndicadorSinLimite=INDICADOR_SIN_LIMITE,
		     CantidadLimite=CANTIDAD_LIMITE,
		     Monto=MONTO
 FROM CTR.BIEN_ALQUILER  (NOLOCK)
 WHERE CODIGO_BIEN=@CODIGO_BIEN
 AND ESTADO_REGISTRO='1'
 ORDER BY INDICADOR_SIN_LIMITE,CANTIDAD_LIMITE 
END

GO
/****** Object:  StoredProcedure [CTR].[USP_BANDEJA_BIENES]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_BANDEJA_BIENES]
@CODIGO_IDENTIFICACION NVARCHAR(50) = NULL,
@TIPO_BIEN NVARCHAR(5) = NULL,
@NUMERO_SERIE NVARCHAR(30) = NULL,
@DESCRIPCION NVARCHAR(30) = NULL,
@MARCA NVARCHAR(30) = NULL,
@MODELO NVARCHAR(30) = NULL,
@FECHA_DESDE NVARCHAR(10) = NULL,
@FECHA_HASTA NVARCHAR(10) = NULL,
@TIPO_TARIFA NVARCHAR(5) = NULL
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_BANDEJA_BIENES
Propósito:  Retorna todos los bienes 
Descripción de Parámetros: 
		@CODIGO_IDENTIFICACION:	Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.
		@TIPO_BIEN:	Parámetro de entrada de tipo nvarchar, que representa tipo bien.
		@NUMERO_SERIE:	Parámetro de entrada de tipo nvarchar, que representa numero serie.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
		@MARCA:	Parámetro de entrada de tipo nvarchar, que representa marca.
		@MODELO:	Parámetro de entrada de tipo nvarchar, que representa modelo.
		@FECHA_DESDE:	Parámetro de entrada de tipo nvarchar, que representa fecha desde.
		@FECHA_HASTA:	Parámetro de entrada de tipo nvarchar, que representa fecha hasta.
		@TIPO_TARIFA:	Parámetro de entrada de tipo nvarchar, que representa tipo tarifa.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/

BEGIN
DECLARE @DT_FECHA_INICIO DATETIME,
			  @DT_FECHA_FIN DATETIME
			  
select	@TIPO_BIEN				=	'%'+ ltrim(rtrim(isnull(@TIPO_BIEN,'')))+'%', 
		@NUMERO_SERIE			=	'%'+ ltrim(rtrim(isnull(@NUMERO_SERIE,'')))+'%', 
		@DESCRIPCION			=	'%'+ ltrim(rtrim(isnull(@DESCRIPCION,'')))+'%',
		@MARCA					=	'%'+ ltrim(rtrim(isnull(@MARCA,'')))+'%',
		@MODELO					=	'%'+ ltrim(rtrim(isnull(@MODELO,'')))+'%',
		@TIPO_TARIFA			=	'%'+ ltrim(rtrim(isnull(@TIPO_TARIFA,'')))+'%', 
		@DT_FECHA_INICIO		=	CONVERT(DATETIME,@FECHA_DESDE,103),
		@DT_FECHA_FIN			=	CONVERT(DATETIME,@FECHA_HASTA,103)

SELECT	CodigoBien				=	CB.CODIGO_BIEN,
		CodigoTipoBien			=	CB.CODIGO_TIPO_BIEN,
		CodigoIdentificacion	=	CB.CODIGO_IDENTIFICACION,
		NumeroSerie				=	CB.NUMERO_SERIE,
		Descripcion				=	CB.DESCRIPCION,
		Marca					=	CB.MARCA,
		Modelo					=	CB.MODELO,
		FechaAdquisicion		=	CB.FECHA_ADQUISICION,
		TiempoVida				=	CB.TIEMPO_VIDA,
		ValorResidual			=	CB.VALOR_RESIDUAL,
		CodigoTipoTarifa		=	CB.CODIGO_TIPO_TARIFA,
		CodigoPeriodoAlquiler	=	CB.CODIGO_PERIODO_ALQUILER,
		ValorAlquiler			=	CB.VALOR_ALQUILER,
		CodigoMoneda			=	CB.CODIGO_MONEDA,
		MesInicioAlquiler		=	CB.MES_INICIO_ALQUILER,
		AnioInicioAlquiler		=	CB.ANIO_INICIO_ALQUILER
FROM	CTR.BIEN	CB (NOLOCK)
WHERE	(CB.CODIGO_IDENTIFICACION LIKE '%' + @CODIGO_IDENTIFICACION + '%' OR ISNULL(@CODIGO_IDENTIFICACION,'') = '') AND
		CB.NUMERO_SERIE LIKE @NUMERO_SERIE AND
		CB.DESCRIPCION LIKE @DESCRIPCION AND
		CB.MARCA LIKE @MARCA AND
		CB.MODELO LIKE @MODELO AND
		CB.CODIGO_TIPO_BIEN LIKE @TIPO_BIEN AND
		CB.CODIGO_TIPO_TARIFA LIKE @TIPO_TARIFA  AND
		(@DT_FECHA_INICIO	IS NULL OR CB.FECHA_ADQUISICION >= @DT_FECHA_INICIO) AND
		(@DT_FECHA_FIN		IS NULL OR CB.FECHA_ADQUISICION <= @DT_FECHA_FIN) AND
		CB.ESTADO_REGISTRO = '1'
ORDER BY Descripcion
END

GO
/****** Object:  StoredProcedure [CTR].[USP_BANDEJA_CONSULTAS_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_BANDEJA_CONSULTAS_SEL]
@CodigoContratoEstadio uniqueidentifier
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_BANDEJA_CONSULTAS_SEL
Propósito:  Retorna todos las observaciones por Contrato por Estadio 
Descripción de Parámetros: 
		@CodigoContratoEstadio:	Parámetro de entrada de tipo uniqueidentifier, que representa codigocontratoestadio.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

DECLARE @CODIGO_CONTRATO UNIQUEIDENTIFIER

SELECT @CODIGO_CONTRATO = CODIGO_CONTRATO
		 FROM CTR.CONTRATO_ESTADIO (NOLOCK) 
WHERE CODIGO_CONTRATO_ESTADIO = @CodigoContratoEstadio AND ESTADO_REGISTRO = '1'
		
SELECT	   CodigoContratoEstadioConsulta = CEC.CODIGO_CONTRATO_ESTADIO_CONSULTA,
		   CodigoContratoEstadio= CEC.CODIGO_CONTRATO_ESTADIO,
		   Consultor = CEC.USUARIO_CREACION,
		   --Consultor  = ( SELECT FAP.CODIGO_TRABAJADOR FROM CTR.FLUJO_APROBACION_PARTICIPANTE FAP (NOLOCK) INNER JOIN CTR.CONTRATO_ESTADIO CE (NOLOCK)
					--									ON (FAP.CODIGO_FLUJO_APROBACION_ESTADIO=CE.CODIGO_FLUJO_APROBACION_ESTADIO ) 
					--						 			WHERE FAP.ESTADO_REGISTRO='1' AND CE.ESTADO_REGISTRO='1' AND CE.CODIGO_CONTRATO_ESTADIO=CEC.CODIGO_CONTRATO_ESTADIO 
					--									AND FAP.CODIGO_TIPO_PARTICIPANTE  ='R' ),
		   Descripcion = ( CASE WHEN LEN(CEC.DESCRIPCION)>120 THEN LEFT(CEC.DESCRIPCION,120)+'...' else CEC.DESCRIPCION end) ,
		   FechaRegistro = CEC.FECHA_REGISTRO,		   
		   Respuesta = ( CASE WHEN LEN(CEC.RESPUESTA)>120 THEN LEFT(CEC.RESPUESTA,120)+'...' else CEC.RESPUESTA end),
		   Destinatario = CEC.DESTINATARIO,
		   FechaRespuesta = CEC.FECHA_RESPUESTA,
		   CodigoContrato = (SELECT CODIGO_CONTRATO FROM CTR.CONTRATO_ESTADIO CC WHERE CC.CODIGO_CONTRATO_ESTADIO=CEC.CODIGO_CONTRATO_ESTADIO)
FROM CTR.CONTRATO_ESTADIO_CONSULTA CEC (NOLOCK)
WHERE CEC.CODIGO_CONTRATO_ESTADIO = @CodigoContratoEstadio

/*Obtenemos el resto de consultas del Contrato que no sean de este estadio.*/
UNION
SELECT CodigoContratoEstadioConsulta = CEC.CODIGO_CONTRATO_ESTADIO_CONSULTA,
		   CodigoContratoEstadio= CEC.CODIGO_CONTRATO_ESTADIO,
		   Consultor = CEC.USUARIO_CREACION,
		   --Consultor  = ( SELECT FAP.CODIGO_TRABAJADOR FROM CTR.FLUJO_APROBACION_PARTICIPANTE FAP (NOLOCK) INNER JOIN CTR.CONTRATO_ESTADIO CE (NOLOCK)
					--									ON (FAP.CODIGO_FLUJO_APROBACION_ESTADIO=CE.CODIGO_FLUJO_APROBACION_ESTADIO ) 
					--						 			WHERE FAP.ESTADO_REGISTRO='1' AND CE.ESTADO_REGISTRO='1' AND CE.CODIGO_CONTRATO_ESTADIO=CEC.CODIGO_CONTRATO_ESTADIO 
					--									AND FAP.CODIGO_TIPO_PARTICIPANTE  ='R' ),
		   Descripcion = ( case when len(CEC.DESCRIPCION)>120 then left(CEC.DESCRIPCION,120)+'...' else CEC.DESCRIPCION end) ,
		   FechaRegistro = CEC.FECHA_REGISTRO,		   
		   Respuesta = ( case when len(CEC.RESPUESTA)>120 then left(CEC.RESPUESTA,120)+'...' else CEC.RESPUESTA end),
		   Destinatario = CEC.DESTINATARIO,
		   FechaRespuesta = CEC.FECHA_RESPUESTA,
		   CE.CODIGO_CONTRATO AS CodigoContrato 
FROM CTR.CONTRATO_ESTADIO_CONSULTA CEC (NOLOCK) INNER JOIN CTR.CONTRATO_ESTADIO CE (NOLOCK)
ON (CEC.CODIGO_CONTRATO_ESTADIO = CE.CODIGO_CONTRATO_ESTADIO)
WHERE CEC.CODIGO_CONTRATO_ESTADIO <> @CodigoContratoEstadio
		AND CE.CODIGO_CONTRATO = @CODIGO_CONTRATO
		AND CEC.ESTADO_REGISTRO = '1'
ORDER BY CEC.FECHA_REGISTRO DESC

END

GO
/****** Object:  StoredProcedure [CTR].[USP_BANDEJA_CONTRATOS_ORDENADO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_BANDEJA_CONTRATOS_ORDENADO_SEL]
	@CodigoResponsable				uniqueidentifier,
	@UnidadOperativa				uniqueidentifier,
	@NombreProveedor				NVARCHAR(30),
	@NumeroDocumentoPrv				NVARCHAR(15),
	@TipoServicio					NVARCHAR(5),
	@TipoRequerimiento				NVARCHAR(15),
	@NombreEstadio					NVARCHAR(300),
	@IndicadorFinalizarAprobacion	NVARCHAR(10),
	@COLUMNA_ORDEN					VARCHAR(50),
    @TIPO_ORDEN						VARCHAR(50),
	@NUMERO_PAGINA					INT =  0,
    @TAMANIO_PAGINA					INT =  42121
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_BANDEJA_CONTRATOS_ORDENADO_SEL
Propósito:  Retorna los contratos para la bandeja del usuario de acuerdo al perfil 
Descripción de Parámetros: 
		@CodigoResponsable:	Parámetro de entrada de tipo uniqueidentifier, que representa codigoresponsable.
		@UnidadOperativa:	Parámetro de entrada de tipo uniqueidentifier, que representa unidadoperativa.
		@NombreProveedor:	Parámetro de entrada de tipo nvarchar, que representa nombreproveedor.
		@NumeroDocumentoPrv:	Parámetro de entrada de tipo nvarchar, que representa numerodocumentoprv.
		@TipoServicio:	Parámetro de entrada de tipo nvarchar, que representa tiposervicio.
		@TipoRequerimiento:	Parámetro de entrada de tipo nvarchar, que representa tiporequerimiento.
		@NombreEstadio: Parámetro de entrada de tipo nvarchar, que representa el Nombre de Estadio.
		@IndicadorFinalizarAprobacion: Parámetro de entrada de tipo nvarchar, que representa el Indicador de Finalizar Aprobación.
		@COLUMNA_ORDEN: Parámetro de entrada que indica el nombre de la columna a ordenar.
		@TIPO_ORDEN: Parámetro de entrada que indica el tipo de ordenamiento: ascendente o descendente.
	    @NUMERO_PAGINA:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@TAMANIO_PAGINA:  Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
Creado por: GMD
Fecha. Creación: 2017-08-15
Fecha. Actualización: 2017-11-27 Corrección para la validación de responsables para estadios en observación
					  2018-01-30 Corrección para visualización de bandeja en usuario logueado como reemplazo de usuario responsable de estadio.
**********************************************************************************************************************************/

BEGIN

	DECLARE @TablaContratos TABLE
	(
		CodigoContratoEstadio			uniqueidentifier,
		CodigoContrato					uniqueidentifier,
		CodigoFlujoAprobacionEstadio	uniqueidentifier,
		CodigoFlujoAprobacion			uniqueidentifier,
		NumeroContrato					nvarchar(50),
		CodigoUnidadOperativa			uniqueidentifier,
		CodigoTipoServicio				nvarchar(5),
		CodigoTipoRequerimiento			nvarchar(15),
		MontoContrato					DECIMAL(12,2),
		MontoAcumulado					DECIMAL(12,2),
		NombreProveedor					nvarchar(250),
		CodigoMoneda					char(3),
		UsuarioCreacion					nvarchar(100),
		FechaIngreso					datetime,
		FechaUltimaNotificacion			datetime,
		IndicadorPermiteCarga			bit,
		DescripcionEstadioActual		nvarchar(250),
		DiasPendiente					int,
		EstadioPropioConsulta			char(1),
		DescripcionContrato				nvarchar(250),
		CodigoEstado					nvarchar(5)
	);

	SET @COLUMNA_ORDEN	=	ISNULL(@COLUMNA_ORDEN,'')
    SET @TIPO_ORDEN		=	ISNULL(@TIPO_ORDEN,'')

	IF @NombreEstadio IS NOT NULL BEGIN
		SET @NombreEstadio = '%' + @NombreEstadio + '%'
	END

	DECLARE @TMP_ULTIMO_ESTADIO_CONTRATO CTR.LISTA_GUID

	IF @IndicadorFinalizarAprobacion = 'A' OR @IndicadorFinalizarAprobacion = 'NA'
	BEGIN
		INSERT INTO @TMP_ULTIMO_ESTADIO_CONTRATO
		SELECT	(SELECT TOP 1 FAE.CODIGO_FLUJO_APROBACION_ESTADIO
				 FROM CTR.FLUJO_APROBACION_ESTADIO FAE 
				 WHERE FAE.CODIGO_FLUJO_APROBACION = FA.CODIGO_FLUJO_APROBACION AND FAE.ESTADO_REGISTRO = '1' 
				 ORDER BY ORDEN DESC) AS CODIGO_ULTIMO_ESTADIO
		FROM	CTR.FLUJO_APROBACION FA
		WHERE	FA.ESTADO_REGISTRO = '1'
	END

	SELECT @NombreProveedor	='%'+ ltrim(rtrim(isnull(@NombreProveedor,'')))+'%', @NumeroDocumentoPrv='%'+ ltrim(rtrim(isnull(@NumeroDocumentoPrv,'')))+'%',
			@TipoServicio	=ltrim(rtrim(isnull(@TipoServicio,'')))+'%', @TipoRequerimiento = ltrim(rtrim(isnull(@TipoRequerimiento,'')))+'%'

	INSERT INTO @TablaContratos
	SELECT  CE.CODIGO_CONTRATO_ESTADIO,
			CE.CODIGO_CONTRATO,
			CE.CODIGO_FLUJO_APROBACION_ESTADIO,
			FAE.CODIGO_FLUJO_APROBACION,
			ISNULL(CT.NUMERO_ADENDA_CONCATENADO,ISNULL(CT.NUMERO_CONTRATO,'-')), 
			CT.CODIGO_UNIDAD_OPERATIVA,
			CT.CODIGO_TIPO_SERVICIO,
			CT.CODIGO_TIPO_REQUERIMIENTO,
			CT.MONTO_CONTRATO,
			CT.MONTO_ACUMULADO,
			ISNULL(PR.NOMBRE,''),
			CT.CODIGO_MONEDA,
			CT.USUARIO_CREACION,
			CT.FECHA_CREACION AS FECHA_INGRESO,
			CE.FECHA_INGRESO  AS FECHA_ULTIMA_NOTIFICACION,
			FAE.INDICADOR_PERMITE_CARGA , 
			FAE.DESCRIPCION, 
			CASE WHEN DATEADD(dd,FAE.TIEMPO_ATENCION,DATEADD(hh, FAE.HORAS_ATENCION, CE.FECHA_INGRESO)) < GETDATE()
											THEN DATEDIFF(dd, DATEADD(dd,FAE.TIEMPO_ATENCION,DATEADD(hh, FAE.HORAS_ATENCION, CE.FECHA_INGRESO)),GETDATE())
											ELSE 0 END,
			'P',
			isnull(CT.DESCRIPCION,''),
			CODIGO_ESTADO
	FROM	CTR.CONTRATO CT (nolock)
		INNER JOIN CTR.PROVEEDOR				PR  (NOLOCK) ON CT.CODIGO_PROVEEDOR					= PR.CODIGO_PROVEEDOR
		INNER JOIN CTR.CONTRATO_ESTADIO			CE  (NOLOCK) ON CT.CODIGO_CONTRATO					= CE.CODIGO_CONTRATO
		INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK) ON CE.CODIGO_FLUJO_APROBACION_ESTADIO	= FAE.CODIGO_FLUJO_APROBACION_ESTADIO
	WHERE		CT.ESTADO_REGISTRO			=	'1'
		AND		CT.CODIGO_UNIDAD_OPERATIVA  = (CASE WHEN @UnidadOperativa IS NULL THEN CT.CODIGO_UNIDAD_OPERATIVA ELSE @UnidadOperativa END)
		AND		PR.NOMBRE					 LIKE @NombreProveedor
		AND		PR.NUMERO_DOCUMENTO			 LIKE @NumeroDocumentoPrv
		AND		CT.CODIGO_TIPO_SERVICIO		 LIKE (CASE WHEN @TipoServicio IS NULL THEN CT.CODIGO_TIPO_SERVICIO ELSE @TipoServicio END)
		AND		CT.CODIGO_TIPO_REQUERIMIENTO LIKE (CASE WHEN @TipoRequerimiento IS NULL THEN CT.CODIGO_TIPO_REQUERIMIENTO ELSE @TipoRequerimiento END)
		AND		CT.CODIGO_ESTADO IN ('A','E')
		AND		CE.CODIGO_ESTADO_CONTRATO_ESTADIO = 'I' --Iniciado
		AND		CE.ESTADO_REGISTRO = '1'
		AND		FAE.ESTADO_REGISTRO = 1
		AND (
				(
				--Si es una empresa vinculada se obtiene el responsable
				(EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA E 
						WHERE E.NUMERO_RUC = PR.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND E.ESTADO_REGISTRO = '1') AND 

				EXISTS (SELECT	1
							FROM	CTR.FLUJO_APROBACION_PARTICIPANTE FAP
							WHERE	FAP.ESTADO_REGISTRO = '1' 
							AND		FAP.CODIGO_TIPO_PARTICIPANTE = 'V'
							AND		FAP.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO 
							AND		FAP.CODIGO_TRABAJADOR =  @CodigoResponsable)
				)
				OR
				(EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA E 
						 WHERE E.NUMERO_RUC = PR.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND E.ESTADO_REGISTRO = '1') AND 
					EXISTS (SELECT	1
								FROM	CTR.FLUJO_APROBACION_PARTICIPANTE FAP
								WHERE	FAP.ESTADO_REGISTRO = '1' 
								AND		FAP.CODIGO_TIPO_PARTICIPANTE = 'R'
								AND		FAP.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO 
								AND		FAP.CODIGO_TRABAJADOR =  @CodigoResponsable)
					AND NOT	EXISTS (SELECT	1
								FROM	CTR.FLUJO_APROBACION_PARTICIPANTE FAP
								WHERE	FAP.ESTADO_REGISTRO = '1' 
								AND		FAP.CODIGO_TIPO_PARTICIPANTE = 'V'
								AND		FAP.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO 
								AND		FAP.CODIGO_TRABAJADOR =  @CodigoResponsable)
								AND 
										NOT EXISTS				
										( SELECT 1 FROM CTR.CONTRATO_ESTADIO_OBSERVACION CEO 
											INNER JOIN CTR.FLUJO_APROBACION_ESTADIO EST ON EST.CODIGO_FLUJO_APROBACION_ESTADIO = CEO.CODIGO_ESTADIO_RETORNO
											WHERE CEO.CODIGO_CONTRATO_ESTADIO = CE.CODIGO_CONTRATO_ESTADIO AND EST.ORDEN = 1
										)	
				)
				OR	
				(
					EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA E 
							WHERE E.NUMERO_RUC = PR.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND E.ESTADO_REGISTRO = '1') AND 

					EXISTS (SELECT	CEC.CODIGO_CONTRATO_ESTADIO_CONSULTA
							FROM	CTR.CONTRATO_ESTADIO_CONSULTA CEC (NOLOCK) 
							WHERE	CEC.CODIGO_CONTRATO_ESTADIO = CE.CODIGO_CONTRATO_ESTADIO
							AND		CEC.FECHA_RESPUESTA IS NULL
							AND		CEC.ESTADO_REGISTRO = '1'
							AND		CEC.DESTINATARIO = @CodigoResponsable)
							AND 
							NOT EXISTS (SELECT	1
									FROM	CTR.FLUJO_APROBACION_PARTICIPANTE FAP
									WHERE	FAP.ESTADO_REGISTRO = '1' 
									AND		FAP.CODIGO_TIPO_PARTICIPANTE = 'V'
									AND		FAP.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO 
									AND		FAP.CODIGO_TRABAJADOR =  @CodigoResponsable)
							AND 
							NOT EXISTS				
							( SELECT 1 FROM CTR.CONTRATO_ESTADIO_OBSERVACION CEO 
								INNER JOIN CTR.FLUJO_APROBACION_ESTADIO EST ON EST.CODIGO_FLUJO_APROBACION_ESTADIO = CEO.CODIGO_ESTADIO_RETORNO
								WHERE CEO.CODIGO_CONTRATO_ESTADIO = CE.CODIGO_CONTRATO_ESTADIO AND EST.ORDEN = 1
							)				
				)
				OR				
				(
					EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA E 
							WHERE E.NUMERO_RUC = PR.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND E.ESTADO_REGISTRO = '1') AND 
						EXISTS (
							SELECT 1 
							FROM CTR.CONTRATO_ESTADIO 
							WHERE CODIGO_CONTRATO = CT.CODIGO_CONTRATO 
						    AND CODIGO_ESTADO_CONTRATO_ESTADIO = 'I' AND CODIGO_RESPONSABLE =@CodigoResponsable
					)
				)	
			)
			--Fin
			OR
			(
				(
					NOT EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA E 
							WHERE E.NUMERO_RUC = PR.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND E.ESTADO_REGISTRO = '1') 
					AND

					EXISTS (
							SELECT 1 
							FROM CTR.CONTRATO_ESTADIO 
							WHERE CODIGO_CONTRATO = CT.CODIGO_CONTRATO 
						    AND CODIGO_ESTADO_CONTRATO_ESTADIO = 'I' AND CODIGO_RESPONSABLE =@CodigoResponsable
					)

					AND 

					NOT EXISTS				
					( SELECT 1 FROM CTR.CONTRATO_ESTADIO_OBSERVACION CEO 
						INNER JOIN CTR.FLUJO_APROBACION_ESTADIO EST ON EST.CODIGO_FLUJO_APROBACION_ESTADIO = CEO.CODIGO_ESTADIO_RETORNO
						WHERE CEO.CODIGO_CONTRATO_ESTADIO = CE.CODIGO_CONTRATO_ESTADIO AND EST.ORDEN = 1
					)	
				)
				
				OR
				(
					NOT EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA E 
							WHERE E.NUMERO_RUC = PR.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND E.ESTADO_REGISTRO = '1') AND 

					EXISTS				
					( SELECT 1 FROM CTR.CONTRATO_ESTADIO_OBSERVACION CEO 
						INNER JOIN CTR.FLUJO_APROBACION_ESTADIO EST ON EST.CODIGO_FLUJO_APROBACION_ESTADIO = CEO.CODIGO_ESTADIO_RETORNO
						WHERE CEO.CODIGO_CONTRATO_ESTADIO = CE.CODIGO_CONTRATO_ESTADIO AND EST.ORDEN = 1
						AND CEO.DESTINATARIO = @CodigoResponsable
					)	
				)	
			)
	)

	--Filtros Adicionales
	AND		(@NombreEstadio IS NULL OR (FAE.DESCRIPCION LIKE @NombreEstadio AND CT.CODIGO_ESTADO = 'A'))

	AND		((@IndicadorFinalizarAprobacion IS NULL OR @IndicadorFinalizarAprobacion = 'A' AND CT.CODIGO_ESTADO = 'A' AND CT.CODIGO_ESTADIO_ACTUAL IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO))
				OR (@IndicadorFinalizarAprobacion = 'NA' AND (CT.CODIGO_ESTADO = 'A') AND CT.CODIGO_ESTADIO_ACTUAL NOT IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO)))

	UNION
	SELECT  CE.CODIGO_CONTRATO_ESTADIO,
			CE.CODIGO_CONTRATO,
			CE.CODIGO_FLUJO_APROBACION_ESTADIO,
			FAE.CODIGO_FLUJO_APROBACION,
			ISNULL(CT.NUMERO_ADENDA_CONCATENADO,ISNULL(CT.NUMERO_CONTRATO,'-')),
			CT.CODIGO_UNIDAD_OPERATIVA,
			CT.CODIGO_TIPO_SERVICIO,
			CT.CODIGO_TIPO_REQUERIMIENTO,
			CT.MONTO_CONTRATO,
			CT.MONTO_ACUMULADO,
			ISNULL(PR.NOMBRE,''),
			CT.CODIGO_MONEDA,
			CT.USUARIO_CREACION,
			CT.FECHA_CREACION AS FECHA_INGRESO,
			CE.FECHA_INGRESO  AS FECHA_ULTIMA_NOTIFICACION,
			FAE.INDICADOR_PERMITE_CARGA, 
			FAE.DESCRIPCION, 
			CASE WHEN DATEADD(dd,FAE.TIEMPO_ATENCION,DATEADD(hh, FAE.HORAS_ATENCION, CE.FECHA_INGRESO)) < GETDATE()
											THEN DATEDIFF(dd, DATEADD(dd,FAE.TIEMPO_ATENCION,DATEADD(hh, FAE.HORAS_ATENCION, CE.FECHA_INGRESO)),GETDATE())
											ELSE 0 END,
			'C',---para distinguir si es del usuario o solo por responder.,
			ISNULL(CT.DESCRIPCION,''),
			CODIGO_ESTADO
	FROM	CTR.CONTRATO CT (NOLOCK)
		INNER JOIN CTR.PROVEEDOR				PR	(NOLOCK) ON CT.CODIGO_PROVEEDOR					= PR.CODIGO_PROVEEDOR
		INNER JOIN CTR.CONTRATO_ESTADIO			CE	(NOLOCK) ON CT.CODIGO_CONTRATO					= CE.CODIGO_CONTRATO
		INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK) ON CE.CODIGO_FLUJO_APROBACION_ESTADIO	= FAE.CODIGO_FLUJO_APROBACION_ESTADIO
	WHERE	
					CT.ESTADO_REGISTRO			=	'1' 
			AND		CT.CODIGO_UNIDAD_OPERATIVA	=	( CASE WHEN @UnidadOperativa IS NULL THEN CT.CODIGO_UNIDAD_OPERATIVA ELSE @UnidadOperativa END)
			AND		PR.NOMBRE						LIKE @NombreProveedor
			AND		PR.NUMERO_DOCUMENTO				LIKE @NumeroDocumentoPrv
			AND		CT.CODIGO_TIPO_SERVICIO			LIKE ( CASE WHEN @TipoServicio IS NULL THEN CT.CODIGO_TIPO_SERVICIO ELSE @TipoServicio END)
			AND		CT.CODIGO_TIPO_REQUERIMIENTO	LIKE ( CASE WHEN @TipoRequerimiento IS NULL THEN CT.CODIGO_TIPO_REQUERIMIENTO ELSE @TipoRequerimiento END)
			AND		CE.CODIGO_ESTADO_CONTRATO_ESTADIO	=	'I' --Iniciado
			AND		CT.CODIGO_ESTADO IN ('A','E')
			AND		CE.ESTADO_REGISTRO = '1'
	AND		EXISTS (SELECT	CEC.CODIGO_CONTRATO_ESTADIO_CONSULTA
					FROM	CTR.CONTRATO_ESTADIO_CONSULTA CEC (NOLOCK) 
					WHERE	CEC.CODIGO_CONTRATO_ESTADIO = CE.CODIGO_CONTRATO_ESTADIO
					AND		CEC.FECHA_RESPUESTA IS NULL
					AND		CEC.ESTADO_REGISTRO = '1'
					AND		CEC.DESTINATARIO = @CodigoResponsable)

	--Filtros Adicionales
	AND		(@NombreEstadio IS NULL OR (FAE.DESCRIPCION LIKE @NombreEstadio AND CT.CODIGO_ESTADO = 'A'))

	AND		((@IndicadorFinalizarAprobacion IS NULL OR @IndicadorFinalizarAprobacion = 'A' AND CT.CODIGO_ESTADO = 'A' AND CT.CODIGO_ESTADIO_ACTUAL IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO))
				OR (@IndicadorFinalizarAprobacion = 'NA' AND (CT.CODIGO_ESTADO = 'A') AND CT.CODIGO_ESTADIO_ACTUAL NOT IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO)))


	SELECT  
			TotalRegistro,
		    NumeroRegistro,
		    CodigoContratoEstadio,
			CodigoContrato,
			CodigoFlujoAprobacionEstadio,
			CodigoFlujoAprobacion,
			NumeroContrato,
			CodigoUnidadOperativa,
			CodigoTipoServicio,
			CodigoTipoRequerimiento,
			NombreProveedor,
			MontoContrato,
			MontoAcumulado,
			CodigoMoneda,
			UsuarioCreacion,
			FechaIngreso,
			FechaUltimaNotificacion,
			IndicadorPermiteCarga,
			DescripcionEstadioActual,
			DiasPendiente,
			EstadioPropioConsulta,
			DescripcionContrato,
			CodigoEstado

			FROM 
				(SELECT 
						TotalRegistro   =      CONVERT(BIGINT,COUNT(1) OVER())      ,
						NumeroRegistro  =      CONVERT(BIGINT,ROW_NUMBER() OVER (ORDER BY 
													CASE WHEN (@COLUMNA_ORDEN='' OR @COLUMNA_ORDEN='FechaIngreso') AND (@TIPO_ORDEN='desc' OR @TIPO_ORDEN='') THEN FechaIngreso END DESC,
													
													CASE WHEN @COLUMNA_ORDEN='NumeroContrato' AND @TIPO_ORDEN='desc' THEN NumeroContrato END ASC,
													CASE WHEN @COLUMNA_ORDEN='NumeroContrato' AND @TIPO_ORDEN='asc' THEN NumeroContrato END ASC,
													CASE WHEN @COLUMNA_ORDEN='DescripcionContrato' AND @TIPO_ORDEN='asc' THEN DescripcionContrato END ASC,
													CASE WHEN @COLUMNA_ORDEN='DescripcionContrato' AND @TIPO_ORDEN='desc' THEN DescripcionContrato END DESC,
													CASE WHEN @COLUMNA_ORDEN='NombreProveedor' AND @TIPO_ORDEN='asc' THEN NombreProveedor END ASC,
													CASE WHEN @COLUMNA_ORDEN='NombreProveedor' AND @TIPO_ORDEN='desc' THEN NombreProveedor END DESC,
													CASE WHEN @COLUMNA_ORDEN='NombreEstadioActual' AND @TIPO_ORDEN='asc' THEN DescripcionEstadioActual END ASC,
													CASE WHEN @COLUMNA_ORDEN='NombreEstadioActual' AND @TIPO_ORDEN='desc' THEN DescripcionEstadioActual END DESC,
													CASE WHEN @COLUMNA_ORDEN='FechaIngreso' AND @TIPO_ORDEN='asc' THEN FechaIngreso END ASC,
													--CASE WHEN @COLUMNA_ORDEN='FechaIngreso' AND @TIPO_ORDEN='desc' THEN FechaIngreso END DESC,
													CASE WHEN @COLUMNA_ORDEN='DiasPendiente' AND @TIPO_ORDEN='asc' THEN DiasPendiente END ASC,
													CASE WHEN @COLUMNA_ORDEN='DiasPendiente' AND @TIPO_ORDEN='desc' THEN DiasPendiente END DESC,
													CASE WHEN @COLUMNA_ORDEN='FechaUltimaNotificacion' AND @TIPO_ORDEN='asc' THEN FechaUltimaNotificacion END ASC,
													CASE WHEN @COLUMNA_ORDEN='FechaUltimaNotificacion' AND @TIPO_ORDEN='desc' THEN FechaUltimaNotificacion END DESC
											   )),
						CodigoContratoEstadio,
						CodigoContrato,
						CodigoFlujoAprobacionEstadio,
						CodigoFlujoAprobacion,
						NumeroContrato,
						CodigoUnidadOperativa,
						CodigoTipoServicio,
						CodigoTipoRequerimiento,
						NombreProveedor,
						MontoContrato,
						MontoAcumulado,
						CodigoMoneda,
						UsuarioCreacion,
						FechaIngreso,
						FechaUltimaNotificacion,
						IndicadorPermiteCarga,
						DescripcionEstadioActual,
						DiasPendiente,
						EstadioPropioConsulta,
						DescripcionContrato,
						CodigoEstado
						FROM @TablaContratos
			)data
			WHERE (data.NumeroRegistro BETWEEN (@NUMERO_PAGINA*@TAMANIO_PAGINA)+1 AND @TAMANIO_PAGINA*(@NUMERO_PAGINA+1))  
			ORDER BY data.FechaIngreso ASC
END


GO
/****** Object:  StoredProcedure [CTR].[USP_BANDEJA_CONTRATOS_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_BANDEJA_CONTRATOS_SEL]
	@CodigoResponsable uniqueidentifier,
	@UnidadOperativa uniqueidentifier,
	@NombreProveedor nvarchar(30),
	@NumeroDocumentoPrv nvarchar(15),
	@TipoServicio nvarchar(5),
	@TipoRequerimiento nvarchar(5),
	@NombreEstadio NVARCHAR(300),
	@IndicadorFinalizarAprobacion NVARCHAR(10)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_BANDEJA_CONTRATOS_SEL
Propósito:  Retorna todos las contratos para la bandeja del usuario de acuerdo al perfil 
Descripción de Parámetros: 
		@CodigoResponsable:	Parámetro de entrada de tipo uniqueidentifier, que representa codigoresponsable.
		@UnidadOperativa:	Parámetro de entrada de tipo uniqueidentifier, que representa unidadoperativa.
		@NombreProveedor:	Parámetro de entrada de tipo nvarchar, que representa nombreproveedor.
		@NumeroDocumentoPrv:	Parámetro de entrada de tipo nvarchar, que representa numerodocumentoprv.
		@TipoServicio:	Parámetro de entrada de tipo nvarchar, que representa tiposervicio.
		@TipoRequerimiento:	Parámetro de entrada de tipo nvarchar, que representa tiporequerimiento.
		@NombreEstadio: Parámetro de entrada de tipo nvarchar, que representa el Nombre de Estadio.
		@IndicadorFinalizarAprobacion: Parámetro de entrada de tipo nvarchar, que representa el Indicador de Finalizar Aprobación.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 2017-08-15 Cambio para obtener responsable de vinculadas.
**********************************************************************************************************************************/

BEGIN
	IF @NombreEstadio IS NOT NULL BEGIN
		SET @NombreEstadio = '%' + @NombreEstadio + '%'
	END

	DECLARE @TMP_ULTIMO_ESTADIO_CONTRATO CTR.LISTA_GUID

	IF @IndicadorFinalizarAprobacion = 'A' OR @IndicadorFinalizarAprobacion = 'NA'
	BEGIN
		INSERT INTO @TMP_ULTIMO_ESTADIO_CONTRATO
		SELECT	(SELECT TOP 1 FAE.CODIGO_FLUJO_APROBACION_ESTADIO
				 FROM CTR.FLUJO_APROBACION_ESTADIO FAE 
				 WHERE FAE.CODIGO_FLUJO_APROBACION = FA.CODIGO_FLUJO_APROBACION AND FAE.ESTADO_REGISTRO = '1' 
				 ORDER BY ORDEN DESC) AS CODIGO_ULTIMO_ESTADIO
		FROM	CTR.FLUJO_APROBACION FA
		WHERE	FA.ESTADO_REGISTRO = '1'
	END

	SELECT @NombreProveedor	='%'+ ltrim(rtrim(isnull(@NombreProveedor,'')))+'%', @NumeroDocumentoPrv='%'+ ltrim(rtrim(isnull(@NumeroDocumentoPrv,'')))+'%',
			@TipoServicio	=ltrim(rtrim(isnull(@TipoServicio,'')))+'%', @TipoRequerimiento = ltrim(rtrim(isnull(@TipoRequerimiento,'')))+'%'

	SELECT  CodigoContratoEstadio		=	CE.CODIGO_CONTRATO_ESTADIO,
			CodigoContrato				=	CE.CODIGO_CONTRATO,
			CodigoFlujoAprobacionEstadio=	CE.CODIGO_FLUJO_APROBACION_ESTADIO,
			CodigoFlujoAprobacion		=	FAE.CODIGO_FLUJO_APROBACION,
			NumeroContrato				=	ISNULL(CT.NUMERO_ADENDA_CONCATENADO,ISNULL(CT.NUMERO_CONTRATO,'-')), 
			CodigoUnidadOperativa		=	CT.CODIGO_UNIDAD_OPERATIVA,
			CodigoTipoServicio			=	CT.CODIGO_TIPO_SERVICIO,
			CodigoTipoRequerimiento		=	CT.CODIGO_TIPO_REQUERIMIENTO,
			NombreProveedor				=	ISNULL(PR.NOMBRE,''),
			CodigoMoneda				=	CT.CODIGO_MONEDA,
			FechaIngreso				=	CE.FECHA_INGRESO,
			FechaUltimaNotificacion		=	CE.FECHA_ULTIMA_NOTIFICACION,
			IndicadorPermiteCarga		=	FAE.INDICADOR_PERMITE_CARGA , 
			DescripcionEstadioActual	=	FAE.DESCRIPCION, 
			DiasPendiente				=	CASE WHEN DATEADD(dd,FAE.TIEMPO_ATENCION,DATEADD(hh, FAE.HORAS_ATENCION, CE.FECHA_INGRESO)) < GETDATE()
											THEN DATEDIFF(dd, DATEADD(dd,FAE.TIEMPO_ATENCION,DATEADD(hh, FAE.HORAS_ATENCION, CE.FECHA_INGRESO)),GETDATE())
											ELSE 0 END,
			EstadioPropioConsulta		=	'P',
			DescripcionContrato			=	isnull(CT.DESCRIPCION,''),
			CodigoEstado				=	CODIGO_ESTADO
	FROM	CTR.CONTRATO CT (nolock)
	INNER JOIN CTR.PROVEEDOR PR (NOLOCK) ON CT.CODIGO_PROVEEDOR = PR.CODIGO_PROVEEDOR
	INNER JOIN CTR.CONTRATO_ESTADIO CE (NOLOCK) ON CT.CODIGO_CONTRATO = CE.CODIGO_CONTRATO
	INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK) ON CE.CODIGO_FLUJO_APROBACION_ESTADIO = FAE.CODIGO_FLUJO_APROBACION_ESTADIO
	WHERE	CT.ESTADO_REGISTRO='1'
	AND		CT.CODIGO_UNIDAD_OPERATIVA = (CASE WHEN @UnidadOperativa IS NULL THEN CT.CODIGO_UNIDAD_OPERATIVA ELSE @UnidadOperativa END)
	AND		PR.NOMBRE LIKE @NombreProveedor
	AND		PR.NUMERO_DOCUMENTO LIKE @NumeroDocumentoPrv
	AND		CT.CODIGO_TIPO_SERVICIO LIKE (CASE WHEN @TipoServicio IS NULL THEN CT.CODIGO_TIPO_SERVICIO ELSE @TipoServicio END)
	AND		CT.CODIGO_TIPO_REQUERIMIENTO LIKE (CASE WHEN @TipoRequerimiento IS NULL THEN CT.CODIGO_TIPO_REQUERIMIENTO ELSE @TipoRequerimiento END)
	AND		CT.CODIGO_ESTADO IN ('A','E')
	AND		CE.CODIGO_ESTADO_CONTRATO_ESTADIO = 'I' --Iniciado
	AND		CE.ESTADO_REGISTRO = '1'
	--AND CE.CODIGO_RESPONSABLE = @CodigoResponsable
	--AND	   EXISTS (
					
	--				 SELECT	1
	--					FROM	CTR.FLUJO_APROBACION_PARTICIPANTE FAP
	--					WHERE	FAP.ESTADO_REGISTRO = '1' 
	--					AND		FAP.CODIGO_TIPO_PARTICIPANTE = 'R'
	--					AND		FAP.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO 
	--					AND		FAP.CODIGO_TRABAJADOR =  @CodigoResponsable					
	--		)
	AND (
			(
			--Si es una empresa vinculada se obtiene el responsable
				EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA E 
						WHERE E.NUMERO_RUC = PR.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND E.ESTADO_REGISTRO = '1') AND 

				EXISTS (SELECT	1
							FROM	CTR.FLUJO_APROBACION_PARTICIPANTE FAP
							WHERE	FAP.ESTADO_REGISTRO = '1' 
							AND		FAP.CODIGO_TIPO_PARTICIPANTE = 'V'
							AND		FAP.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO 
							AND		FAP.CODIGO_TRABAJADOR =  @CodigoResponsable)		
			)
			OR
			(
				NOT EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA E 
						WHERE E.NUMERO_RUC = PR.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND E.ESTADO_REGISTRO = '1') AND 

				EXISTS (SELECT	1
							FROM	CTR.FLUJO_APROBACION_PARTICIPANTE FAP
							WHERE	FAP.ESTADO_REGISTRO = '1' 
							AND		FAP.CODIGO_TIPO_PARTICIPANTE = 'R'
							AND		FAP.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO 
							AND		FAP.CODIGO_TRABAJADOR =  @CodigoResponsable)		
			)
					
	)

	--Filtros Adicionales
	AND		(@NombreEstadio IS NULL OR (FAE.DESCRIPCION LIKE @NombreEstadio AND CT.CODIGO_ESTADO = 'A'))

	AND		((@IndicadorFinalizarAprobacion IS NULL OR @IndicadorFinalizarAprobacion = 'A' AND CT.CODIGO_ESTADO = 'A' AND CT.CODIGO_ESTADIO_ACTUAL IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO))
				OR (@IndicadorFinalizarAprobacion = 'NA' AND (CT.CODIGO_ESTADO = 'A') AND CT.CODIGO_ESTADIO_ACTUAL NOT IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO)))
	UNION
	SELECT CodigoContratoEstadio		=	CE.CODIGO_CONTRATO_ESTADIO,
			CodigoContrato				=	CE.CODIGO_CONTRATO,
			CodigoFlujoAprobacionEstadio=	CE.CODIGO_FLUJO_APROBACION_ESTADIO,
			CodigoFlujoAprobacion		=	FAE.CODIGO_FLUJO_APROBACION,
			NumeroContrato				=	ISNULL(CT.NUMERO_ADENDA_CONCATENADO,ISNULL(CT.NUMERO_CONTRATO,'-')),
			CodigoUnidadOperativa		=	CT.CODIGO_UNIDAD_OPERATIVA,
			CodigoTipoServicio			=	CT.CODIGO_TIPO_SERVICIO,
			CodigoTipoRequerimiento		=	CT.CODIGO_TIPO_REQUERIMIENTO,
			NombreProveedor				=	ISNULL(PR.NOMBRE,''),
			CodigoMoneda				=	CT.CODIGO_MONEDA,
			FechaIngreso				=	CE.FECHA_INGRESO,
			FechaUltimaNotificacion		=	CE.FECHA_ULTIMA_NOTIFICACION,
			IndicadorPermiteCarga		=	FAE.INDICADOR_PERMITE_CARGA , 
			DescripcionEstadioActual	=	FAE.DESCRIPCION, 
			DiasPendiente				=	CASE WHEN DATEADD(dd,FAE.TIEMPO_ATENCION,DATEADD(hh, FAE.HORAS_ATENCION, CE.FECHA_INGRESO)) < GETDATE()
											THEN DATEDIFF(dd, DATEADD(dd,FAE.TIEMPO_ATENCION,DATEADD(hh, FAE.HORAS_ATENCION, CE.FECHA_INGRESO)),GETDATE())
											ELSE 0 END,
			EstadioPropioConsulta		=	'C',---para distinguir si es del usuario o solo por responder.,
			DescripcionContrato			=	ISNULL(CT.DESCRIPCION,''),
			CodigoEstado				=	CODIGO_ESTADO
	FROM	CTR.CONTRATO CT (NOLOCK)
	INNER JOIN CTR.PROVEEDOR PR (NOLOCK) ON CT.CODIGO_PROVEEDOR = PR.CODIGO_PROVEEDOR
	INNER JOIN CTR.CONTRATO_ESTADIO CE (NOLOCK) ON CT.CODIGO_CONTRATO = CE.CODIGO_CONTRATO
	INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK) ON CE.CODIGO_FLUJO_APROBACION_ESTADIO = FAE.CODIGO_FLUJO_APROBACION_ESTADIO
	WHERE	CT.ESTADO_REGISTRO='1' 
	AND		CT.CODIGO_UNIDAD_OPERATIVA =( CASE WHEN @UnidadOperativa IS NULL THEN CT.CODIGO_UNIDAD_OPERATIVA ELSE @UnidadOperativa END)
	AND		PR.NOMBRE LIKE @NombreProveedor
	AND		PR.NUMERO_DOCUMENTO LIKE @NumeroDocumentoPrv
	AND		CT.CODIGO_TIPO_SERVICIO LIKE ( CASE WHEN @TipoServicio IS NULL THEN CT.CODIGO_TIPO_SERVICIO ELSE @TipoServicio END)
	AND		CT.CODIGO_TIPO_REQUERIMIENTO LIKE ( CASE WHEN @TipoRequerimiento IS NULL THEN CT.CODIGO_TIPO_REQUERIMIENTO ELSE @TipoRequerimiento END)
	AND		CE.CODIGO_ESTADO_CONTRATO_ESTADIO='I' --Iniciado
	AND		CT.CODIGO_ESTADO IN ('A','E')
	AND		CE.ESTADO_REGISTRO = '1'
	AND		EXISTS (SELECT	CEC.CODIGO_CONTRATO_ESTADIO_CONSULTA
					FROM	CTR.CONTRATO_ESTADIO_CONSULTA CEC (NOLOCK) 
					WHERE	CEC.CODIGO_CONTRATO_ESTADIO = CE.CODIGO_CONTRATO_ESTADIO
					AND		CEC.FECHA_RESPUESTA IS NULL
					AND		CEC.ESTADO_REGISTRO = '1'
					AND		CEC.DESTINATARIO = @CodigoResponsable)

	--AND (
	--		(
	--			EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA E 
	--					WHERE E.NUMERO_RUC = PR.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND E.ESTADO_REGISTRO = '1') AND 

	--			EXISTS (SELECT	1
	--						FROM	CTR.FLUJO_APROBACION_PARTICIPANTE FAP
	--						WHERE	FAP.ESTADO_REGISTRO = '1' 
	--						AND		FAP.CODIGO_TIPO_PARTICIPANTE = 'V'
	--						AND		FAP.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO 
	--						AND		FAP.CODIGO_TRABAJADOR =  @CodigoResponsable)		
	--		)
	--		OR
	--		(
	--			NOT EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA E 
	--					WHERE E.NUMERO_RUC = PR.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND E.ESTADO_REGISTRO = '1') AND 

	--			EXISTS (SELECT	1
	--						FROM	CTR.FLUJO_APROBACION_PARTICIPANTE FAP
	--						WHERE	FAP.ESTADO_REGISTRO = '1' 
	--						AND		FAP.CODIGO_TIPO_PARTICIPANTE = 'R'
	--						AND		FAP.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO 
	--						AND		FAP.CODIGO_TRABAJADOR =  @CodigoResponsable)		
	--		)
					
	--)


	--Filtros Adicionales
	AND		(@NombreEstadio IS NULL OR (FAE.DESCRIPCION LIKE @NombreEstadio AND CT.CODIGO_ESTADO = 'A'))

	AND		((@IndicadorFinalizarAprobacion IS NULL OR @IndicadorFinalizarAprobacion = 'A' AND CT.CODIGO_ESTADO = 'A' AND CT.CODIGO_ESTADIO_ACTUAL IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO))
				OR (@IndicadorFinalizarAprobacion = 'NA' AND (CT.CODIGO_ESTADO = 'A') AND CT.CODIGO_ESTADIO_ACTUAL NOT IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO)))
END

GO
/****** Object:  StoredProcedure [CTR].[USP_BANDEJA_OBSERVACIONES_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_BANDEJA_OBSERVACIONES_SEL]
@CodigoContratoEstadio uniqueidentifier
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_BANDEJA_OBSERVACIONES_SEL
Propósito:  Retorna todos las observaciones por Contrato por Estadio 
Descripción de Parámetros: 
		@CodigoContratoEstadio:	Parámetro de entrada de tipo uniqueidentifier, que representa codigocontratoestadio.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

DECLARE @CODIGO_CONTRATO uniqueidentifier

SELECT @CODIGO_CONTRATO = CODIGO_CONTRATO
		 FROM CTR.CONTRATO_ESTADIO (NOLOCK) 
WHERE CODIGO_CONTRATO_ESTADIO = @CodigoContratoEstadio AND ESTADO_REGISTRO='1'

select CodigoContratoEstadioObservacion = CEO.CODIGO_CONTRATO_ESTADIO_OBSERVACION,
		   CodigoContratoEstadio= CEO.CODIGO_CONTRATO_ESTADIO,
			Observador = CEO.USUARIO_CREACION ,
		   Descripcion = case when LEN(CEO.DESCRIPCION)>110 then left(CEO.DESCRIPCION,110) + '...' else (CEO.DESCRIPCION) end  ,
		   FechaRegistro = CEO.FECHA_REGISTRO,
		   CodigoTipoRespuesta =  CEO.CODIGO_TIPO_RESPUESTA,
		   CodigoArchivo = CEO.CODIGO_ARCHIVO,
		   Respuesta= case when LEN(isnull(CEO.RESPUESTA,''))>110 then left(CEO.RESPUESTA,110) + '...' else (isnull(CEO.RESPUESTA,'')) end ,
		   Destinatario= ( case when LEN(isnull(CEO.RESPUESTA,''))>0 then CEO.DESTINATARIO else null end ),
		   FechaRespuesta=CEO.FECHA_RESPUESTA
from CTR.CONTRATO_ESTADIO_OBSERVACION CEO (NOLOCK)
WHERE CEO.CODIGO_CONTRATO_ESTADIO = @CodigoContratoEstadio

union
select CodigoContratoEstadioObservacion = CEO.CODIGO_CONTRATO_ESTADIO_OBSERVACION,
		   CodigoContratoEstadio= CEO.CODIGO_CONTRATO_ESTADIO,
			Observador = CEO.USUARIO_CREACION ,
		   Descripcion = case when LEN(CEO.DESCRIPCION)>110 then left(CEO.DESCRIPCION,110) + '...' else (CEO.DESCRIPCION) end  ,
		   FechaRegistro = CEO.FECHA_REGISTRO,
		   CodigoTipoRespuesta =  CEO.CODIGO_TIPO_RESPUESTA,
		   CodigoArchivo = CEO.CODIGO_ARCHIVO,
		   Respuesta= case when LEN(isnull(CEO.RESPUESTA,''))>110 then left(CEO.RESPUESTA,110) + '...' else (isnull(CEO.RESPUESTA,'')) end ,
		   Destinatario= ( case when LEN(isnull(CEO.RESPUESTA,''))>0 then CEO.DESTINATARIO else null end ),
		   FechaRespuesta=CEO.FECHA_RESPUESTA
from CTR.CONTRATO_ESTADIO_OBSERVACION CEO (NOLOCK) INNER JOIN CTR.CONTRATO_ESTADIO CE (NOLOCK)
ON (CEO.CODIGO_CONTRATO_ESTADIO=CE.CODIGO_CONTRATO_ESTADIO)
WHERE CEO.CODIGO_CONTRATO_ESTADIO <> @CodigoContratoEstadio
	AND CE.CODIGO_CONTRATO=@CODIGO_CONTRATO
	AND CEO.ESTADO_REGISTRO='1'
	
ORDER BY CEO.FECHA_REGISTRO	 DESC
END

GO
/****** Object:  StoredProcedure [CTR].[USP_BANDEJA_REVISION_CONTRATO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_BANDEJA_REVISION_CONTRATO_SEL]
@NumeroContrato nvarchar(30),
@UnidadOperativa uniqueidentifier,
@NombreProveedor nvarchar(30),
@NumeroDocumentoPrv nvarchar(15)
AS

/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_BANDEJA_REVISION_CONTRATO_SEL
Propósito:  Retorna todos los contratos que han sido aprobados en la solicitud de Modificación
Descripción de Parámetros: 
		@NumeroContrato:	Parámetro de entrada de tipo nvarchar, que representa numerocontrato.
		@UnidadOperativa:	Parámetro de entrada de tipo uniqueidentifier, que representa unidadoperativa.
		@NombreProveedor:	Parámetro de entrada de tipo nvarchar, que representa nombreproveedor.
		@NumeroDocumentoPrv:	Parámetro de entrada de tipo nvarchar, que representa numerodocumentoprv.
Creado por: GMD
Fecha. Creación: 2017-11-13
Fecha. Actualización: 
**********************************************************************************************************************************/

BEGIN
select @NombreProveedor='%'+ ltrim(rtrim(isnull(@NombreProveedor,'')))+'%',
		   @NumeroDocumentoPrv='%'+ ltrim(rtrim(isnull(@NumeroDocumentoPrv,'')))+'%',
		   @NumeroContrato =ltrim(rtrim(isnull(@NumeroContrato,'')))+'%'

select CodigoContrato=CT.CODIGO_CONTRATO,		   
           NumeroContrato= ISNULL(CT.NUMERO_CONTRATO,''), 
		   CodigoUnidadOperativa=CT.CODIGO_UNIDAD_OPERATIVA,
		   CodigoTipoDocumento = CT.CODIGO_TIPO_DOCUMENTO,
		   NombreProveedor=ISNULL(PR.NOMBRE,''),
		   CodigoProveedor=CT.CODIGO_PROVEEDOR,
		   CodigoEstadoEdicion= CT.CODIGO_ESTADO_EDICION,
		   FechaModificacion = CT.FECHA_MODIFICACION,
		   UsuarioCreacion = CT.USUARIO_CREACION
		   from CTR.CONTRATO CT (nolock) inner join CTR.PROVEEDOR PR (NOLOCK)
		   ON ( CT.CODIGO_PROVEEDOR = PR.CODIGO_PROVEEDOR)
 WHERE CT.ESTADO_REGISTRO='1' 
			 AND ISNULL(CT.NUMERO_CONTRATO,'') LIKE 	@NumeroContrato
			  AND CT.CODIGO_UNIDAD_OPERATIVA =( CASE WHEN @UnidadOperativa IS NULL THEN CT.CODIGO_UNIDAD_OPERATIVA ELSE @UnidadOperativa END)
			 AND PR.NOMBRE LIKE @NombreProveedor
			 AND PR.NUMERO_DOCUMENTO LIKE @NumeroDocumentoPrv
			 AND CT.CODIGO_ESTADO='R'
			 AND CT.CODIGO_ESTADO_EDICION IN ('R')
END

GO
/****** Object:  StoredProcedure [CTR].[USP_BANDEJA_SOLICITUD_CONTRATO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_BANDEJA_SOLICITUD_CONTRATO_SEL]
@NumeroContrato nvarchar(30),
@UnidadOperativa uniqueidentifier,
@NombreProveedor nvarchar(30),
@NumeroDocumentoPrv nvarchar(15)
AS

/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_BANDEJA_SOLICITUD_CONTRATO_SEL
Propósito:  Retorna todos las contratos que tienen una solicitud de autoreizacion 
Descripción de Parámetros: 
		@NumeroContrato:	Parámetro de entrada de tipo nvarchar, que representa numerocontrato.
		@UnidadOperativa:	Parámetro de entrada de tipo uniqueidentifier, que representa unidadoperativa.
		@NombreProveedor:	Parámetro de entrada de tipo nvarchar, que representa nombreproveedor.
		@NumeroDocumentoPrv:	Parámetro de entrada de tipo nvarchar, que representa numerodocumentoprv.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 2017-11-10 Se agrega columnas Fecha Modificación y Usuario Creación
**********************************************************************************************************************************/

BEGIN
select @NombreProveedor='%'+ ltrim(rtrim(isnull(@NombreProveedor,'')))+'%',
		   @NumeroDocumentoPrv='%'+ ltrim(rtrim(isnull(@NumeroDocumentoPrv,'')))+'%',
		   @NumeroContrato =ltrim(rtrim(isnull(@NumeroContrato,'')))+'%'

select CodigoContrato=CT.CODIGO_CONTRATO,		   
           NumeroContrato= ISNULL(CT.NUMERO_CONTRATO,''), 
		   CodigoUnidadOperativa=CT.CODIGO_UNIDAD_OPERATIVA,
		   CodigoTipoDocumento = CT.CODIGO_TIPO_DOCUMENTO,
		   NombreProveedor=ISNULL(PR.NOMBRE,''),
		   CodigoProveedor=CT.CODIGO_PROVEEDOR,
		   CodigoEstadoEdicion= CT.CODIGO_ESTADO_EDICION,
		   FechaModificacion = CT.FECHA_MODIFICACION,
		   UsuarioCreacion = CT.USUARIO_CREACION
		   from CTR.CONTRATO CT (nolock) inner join CTR.PROVEEDOR PR (NOLOCK)
		   ON ( CT.CODIGO_PROVEEDOR = PR.CODIGO_PROVEEDOR)
 WHERE CT.ESTADO_REGISTRO='1' 
			 AND ISNULL(CT.NUMERO_CONTRATO,'') LIKE 	@NumeroContrato
			  AND CT.CODIGO_UNIDAD_OPERATIVA =( CASE WHEN @UnidadOperativa IS NULL THEN CT.CODIGO_UNIDAD_OPERATIVA ELSE @UnidadOperativa END)
			 AND PR.NOMBRE LIKE @NombreProveedor
			 AND PR.NUMERO_DOCUMENTO LIKE @NumeroDocumentoPrv
			 AND CT.CODIGO_ESTADO='E'
			 AND CT.CODIGO_ESTADO_EDICION IN ('E','S')
END

GO
/****** Object:  StoredProcedure [CTR].[USP_BIEN_CONTRATO_RPT]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [CTR].[USP_BIEN_CONTRATO_RPT] --NULL,NULL,NULL,NULL,NULL,NULL,NULL
@CODIGO_UNIDAD_OPERATIVA UNIQUEIDENTIFIER,
@CODIGO_TIPO_BIEN NVARCHAR(5),
@RUC_PROVEEDOR NVARCHAR(20),
@NOMBRE_PROVEEDOR NVARCHAR(255),
@NUMERO_CONTRATO NVARCHAR(25),
@NUMERO_SERIE NVARCHAR(50),
@ANO VARCHAR(4)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_BIEN_CONTRATO_RPT
Propósito: <<No especificado>>
Descripción de Parámetros: 
		@CODIGO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@CODIGO_TIPO_BIEN:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo bien.
		@RUC_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa ruc proveedor.
		@NOMBRE_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa nombre proveedor.
		@NUMERO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa numero contrato.
		@NUMERO_SERIE:	Parámetro de entrada de tipo nvarchar, que representa numero serie.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
--DECLARE @FECHA DATETIME;
--SET @FECHA = CAST(CAST(@ANO AS varchar) + '-' + CAST(@MES AS varchar) + '-01' AS DATETIME)
---SELECT	ROW_NUMBER() OVER(ORDER BY C.FECHA_INICIO_VIGENCIA DESC) ITEM,
SELECT	
		MONTH(C.FECHA_INICIO_VIGENCIA)			MES_PERIODO,
		YEAR(C.FECHA_INICIO_VIGENCIA)			ANIO_PERIODO,
		C.CODIGO_UNIDAD_OPERATIVA				CODIGO_UNIDAD_OPERATIVA,
		P.NUMERO_DOCUMENTO						RUC_PROVEEDOR,
		P.NOMBRE								PROVEEDOR,
		C.NUMERO_CONTRATO						NUMERO_CONTRATO,
		C.CODIGO_MONEDA							CODIGO_MONEDA_CONTRATO,
		C.MONTO_CONTRATO						MONTO_CONTRATO,
		C.FECHA_INICIO_VIGENCIA					FECHA_INICIO_VIGENCIA,
		C.FECHA_FIN_VIGENCIA					FECHA_FIN_VIGENCIA,
		C.CODIGO_ESTADO							CODIGO_ESTADO_CONTRATO,
		B.CODIGO_IDENTIFICACION					CODIGO_IDENTIFICACION_BIEN,
		B.CODIGO_TIPO_BIEN						CODIGO_TIPO_BIEN,
		B.NUMERO_SERIE							NUMERO_SERIE,
		B.DESCRIPCION							DESCRIPCION,
		B.MARCA									MARCA,
		B.MODELO								MODELO,
		B.CODIGO_TIPO_TARIFA					CODIGO_TIPO_TARIFA,
		B.CODIGO_PERIODO_ALQUILER				CODIGO_PERIODO_ALQUILER,
		B.VALOR_ALQUILER						VALOR_ALQUILER,
		B.FECHA_ADQUISICION						FECHA_ADQUISICION,
		B.TIEMPO_VIDA							TIEMPO_VIDA_UTIL,
		B.CODIGO_BIEN							CODIGO_BIEN,
		B.VALOR_RESIDUAL						VALOR_RESIDUAL,
		--
		(SELECT MAX(FECHA_INGRESO) FROM [CTR].[CONTRATO_ESTADIO] WHERE CODIGO_CONTRATO = C.CODIGO_CONTRATO) FECHA_ULTIMA_APROBACION,
		CB.TIPO_TARIFA							TIPO_TARIFA,
		CB.TIPO_PERIODO							TIPO_PERIODO,
		CB.HORAS_MINIMAS						HORAS_MINIMAS,
		CB.TARIFA								TARIFA,
		CB.MAYORMENOR							MAYORMENOR
		--
INTO	#TMP_REPORTE
FROM	CTR.BIEN B
INNER JOIN	CTR.CONTRATO_BIEN CB ON CB.CODIGO_BIEN = B.CODIGO_BIEN
INNER JOIN	CTR.CONTRATO C ON C.CODIGO_CONTRATO = CB.CODIGO_CONTRATO
INNER JOIN	CTR.PROVEEDOR P ON P.CODIGO_PROVEEDOR = C.CODIGO_PROVEEDOR
WHERE	(C.CODIGO_UNIDAD_OPERATIVA	= @CODIGO_UNIDAD_OPERATIVA	OR @CODIGO_UNIDAD_OPERATIVA IS NULL)
AND		(B.CODIGO_TIPO_BIEN			= @CODIGO_TIPO_BIEN			OR ISNULL(@CODIGO_TIPO_BIEN, '') = '')
AND		(P.NUMERO_DOCUMENTO LIKE '%' + @RUC_PROVEEDOR + '%'		OR ISNULL(@RUC_PROVEEDOR, '') = '')
AND		(P.NOMBRE			LIKE '%' + @NOMBRE_PROVEEDOR + '%'	OR ISNULL(@NOMBRE_PROVEEDOR, '') = '')
--AND		(C.NUMERO_CONTRATO	= @NUMERO_CONTRATO OR ISNULL(@NUMERO_CONTRATO, '') = '')
AND		(C.NUMERO_CONTRATO	LIKE '%' + @NUMERO_CONTRATO + '%'	OR ISNULL(@NUMERO_CONTRATO, '') = '')
AND		(B.NUMERO_SERIE		LIKE '%' + @NUMERO_SERIE + '%'		OR ISNULL(@NUMERO_SERIE, '') = '')
AND		B.ESTADO_REGISTRO = '1'
AND		CB.ESTADO_REGISTRO = '1'
AND		C.ESTADO_REGISTRO = '1'
------
--AND		C.CODIGO_ESTADO NOT IN ('E')
--AND     C.FECHA_INICIO_VIGENCIA <= @FECHA AND C.FECHA_FIN_VIGENCIA >= @FECHA
AND (YEAR(C.FECHA_INICIO_VIGENCIA) = @ANO OR @ANO IS NULL)
------
 
UNION ALL

SELECT	
		MONTH(C.FECHA_INICIO_VIGENCIA)			MES_PERIODO,
		YEAR(C.FECHA_INICIO_VIGENCIA)			ANIO_PERIODO,
		C.CODIGO_UNIDAD_OPERATIVA				CODIGO_UNIDAD_OPERATIVA,
		P.NUMERO_DOCUMENTO						RUC_PROVEEDOR,
		P.NOMBRE								PROVEEDOR,
		C.NUMERO_ADENDA_CONCATENADO COLLATE Latin1_General_CI_AS,
		C.CODIGO_MONEDA							CODIGO_MONEDA_CONTRATO,
		C.MONTO_CONTRATO						MONTO_CONTRATO,
		C.FECHA_INICIO_VIGENCIA					FECHA_INICIO_VIGENCIA,
		C.FECHA_FIN_VIGENCIA					FECHA_FIN_VIGENCIA,
		C.CODIGO_ESTADO							CODIGO_ESTADO_CONTRATO,
		B.CODIGO_IDENTIFICACION					CODIGO_IDENTIFICACION_BIEN,
		B.CODIGO_TIPO_BIEN						CODIGO_TIPO_BIEN,
		B.NUMERO_SERIE							NUMERO_SERIE,
		B.DESCRIPCION							DESCRIPCION,
		B.MARCA									MARCA,
		B.MODELO								MODELO,
		B.CODIGO_TIPO_TARIFA					CODIGO_TIPO_TARIFA,
		B.CODIGO_PERIODO_ALQUILER				CODIGO_PERIODO_ALQUILER,
		B.VALOR_ALQUILER						VALOR_ALQUILER,
		B.FECHA_ADQUISICION						FECHA_ADQUISICION,
		B.TIEMPO_VIDA							TIEMPO_VIDA_UTIL,
		B.CODIGO_BIEN							CODIGO_BIEN,
		B.VALOR_RESIDUAL						VALOR_RESIDUAL,
		--
		(SELECT MAX(FECHA_INGRESO) FROM [CTR].[CONTRATO_ESTADIO] WHERE CODIGO_CONTRATO = C.CODIGO_CONTRATO) FECHA_ULTIMA_APROBACION,
		CB.TIPO_TARIFA							TIPO_TARIFA,
		CB.TIPO_PERIODO							TIPO_PERIODO,
		CB.HORAS_MINIMAS						HORAS_MINIMAS,
		CB.TARIFA								TARIFA,
		CB.MAYORMENOR							MAYORMENOR
		--
FROM	CTR.BIEN B
INNER JOIN	CTR.CONTRATO_BIEN CB ON CB.CODIGO_BIEN = B.CODIGO_BIEN
INNER JOIN	CTR.CONTRATO C ON C.CODIGO_CONTRATO_PRINCIPAL = CB.CODIGO_CONTRATO
INNER JOIN	CTR.PROVEEDOR P ON P.CODIGO_PROVEEDOR = C.CODIGO_PROVEEDOR
WHERE	(C.CODIGO_UNIDAD_OPERATIVA	= @CODIGO_UNIDAD_OPERATIVA	OR @CODIGO_UNIDAD_OPERATIVA IS NULL)
AND		(B.CODIGO_TIPO_BIEN			= @CODIGO_TIPO_BIEN			OR ISNULL(@CODIGO_TIPO_BIEN, '') = '')
AND		(P.NUMERO_DOCUMENTO LIKE '%' + @RUC_PROVEEDOR + '%'		OR ISNULL(@RUC_PROVEEDOR, '') = '')
AND		(P.NOMBRE			LIKE '%' + @NOMBRE_PROVEEDOR + '%'	OR ISNULL(@NOMBRE_PROVEEDOR, '') = '')
AND		(C.NUMERO_CONTRATO	LIKE '%' + @NUMERO_CONTRATO + '%'	OR ISNULL(@NUMERO_CONTRATO, '') = '')
AND		(B.NUMERO_SERIE		LIKE '%' + @NUMERO_SERIE + '%'		OR ISNULL(@NUMERO_SERIE, '') = '')
AND		B.ESTADO_REGISTRO = '1'
AND		CB.ESTADO_REGISTRO = '1'
AND		C.ESTADO_REGISTRO = '1'
------
--AND		C.CODIGO_ESTADO NOT IN ('E')
--AND     C.FECHA_INICIO_VIGENCIA <= @FECHA AND C.FECHA_FIN_VIGENCIA >= @FECHA
AND (YEAR(C.FECHA_INICIO_VIGENCIA) = @ANO OR @ANO IS NULL)
------
END

SELECT ROW_NUMBER() OVER (ORDER BY (SELECT 1)) ITEM,
	   MES_PERIODO,
	   ANIO_PERIODO,
	   CODIGO_UNIDAD_OPERATIVA,
	   RUC_PROVEEDOR,
	   PROVEEDOR,
	   NUMERO_CONTRATO,
	   CODIGO_MONEDA_CONTRATO,
	   MONTO_CONTRATO,
	   FECHA_INICIO_VIGENCIA,
	   FECHA_FIN_VIGENCIA,
	   CODIGO_ESTADO_CONTRATO,
	   CODIGO_IDENTIFICACION_BIEN,
	   CODIGO_TIPO_BIEN,
	   NUMERO_SERIE,
	   DESCRIPCION,
	   MARCA,
	   MODELO,
	   FECHA_ULTIMA_APROBACION,
	   --
	   CASE WHEN B.TIPO_TARIFA IS NULL THEN CODIGO_TIPO_TARIFA COLLATE DATABASE_DEFAULT ELSE B.TIPO_TARIFA END AS CODIGO_TIPO_TARIFA,
	   --CODIGO_TIPO_TARIFA,
	   --
	   CASE WHEN B.MAYORMENOR = 'Sí' THEN B.TIPO_PERIODO ELSE CODIGO_PERIODO_ALQUILER COLLATE DATABASE_DEFAULT END AS CODIGO_PERIODO_ALQUILER,
	   --CASE WHEN B.TIPO_TARIFA IS NULL THEN CODIGO_PERIODO_ALQUILER COLLATE DATABASE_DEFAULT ELSE B.CODIGO_PERIODO_ALQUILER END AS CODIGO_PERIODO_ALQUILER,
	   --CODIGO_PERIODO_ALQUILER,
	   --
	   CASE
		WHEN B.CODIGO_TIPO_TARIFA = 'F' THEN -1
		ELSE 
			CASE
				WHEN BA.INDICADOR_SIN_LIMITE = 1 THEN -1
				ELSE BA.CANTIDAD_LIMITE
			END
	   END AS CANTIDAD_LIMITE,
	   CASE
		WHEN B.CODIGO_TIPO_TARIFA = 'F' THEN B.VALOR_ALQUILER
		ELSE BA.MONTO
	   END AS VALOR_ALQUILER,
	   FECHA_ADQUISICION,
	   TIEMPO_VIDA_UTIL,
	   VALOR_RESIDUAL,
	   --

	   MAYORMENOR,
	   --CASE WHEN MAYORMENOR = 'QCAE' THEN 'SI' WHEN MAYORMENOR = 'QCAEM' THEN 'NO' END AS EQUIPO_MAYOR,
	   --'Si' AS PROVEEDOR_COMUNIDAD,	
	   B.HORAS_MINIMAS AS HORAS_MINIMAS,
	   B.TARIFA AS TARIFA,
	   --CASE WHEN B.TIPO_TARIFA = 'E' THEN B.HORAS_MINIMAS * B.TARIFA * (SELECT CTR.FN_CALCULAMESESCONTRATO(FECHA_INICIO_VIGENCIA,FECHA_FIN_VIGENCIA)) ELSE B.TARIFA * (SELECT CTR.FN_CALCULAMESESCONTRATO(FECHA_INICIO_VIGENCIA,FECHA_FIN_VIGENCIA)) END AS TOTAL,
	   B.HORAS_MINIMAS * B.TARIFA * (SELECT CTR.FN_CALCULAMESESCONTRATO(FECHA_INICIO_VIGENCIA,FECHA_FIN_VIGENCIA)) AS TOTAL,
	   (SELECT CTR.FN_CALCULAMESESCONTRATO(FECHA_INICIO_VIGENCIA,FECHA_FIN_VIGENCIA)) AS PLAZO_CONTRATO_MESES
	   --
  FROM #TMP_REPORTE B
  LEFT JOIN CTR.BIEN_ALQUILER BA
    ON BA.CODIGO_BIEN = B.CODIGO_BIEN
   AND BA.ESTADO_REGISTRO = '1'
   AND B.CODIGO_TIPO_TARIFA = 'E'
 ORDER BY CODIGO_UNIDAD_OPERATIVA,
		  PROVEEDOR,
		  NUMERO_CONTRATO,
		  DESCRIPCION,
		  (CASE WHEN B.CODIGO_TIPO_TARIFA = 'E' AND BA.INDICADOR_SIN_LIMITE = 1 THEN 2 ELSE 1 END),
		  CANTIDAD_LIMITE


GO
/****** Object:  StoredProcedure [CTR].[USP_BIEN_DESCRIPCION_COMPLETA_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_BIEN_DESCRIPCION_COMPLETA_SEL]
@DESCRIPCION NVARCHAR(MAX)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_BIEN_DESCRIPCION_COMPLETA_SEL
Propósito: <<No especificado>>
Descripción de Parámetros: 
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
SELECT	CB.CODIGO_BIEN
INTO	#TMP_BIENES_SIN_CONTRATO
FROM	CTR.BIEN B
INNER JOIN CTR.CONTRATO_BIEN CB ON CB.CODIGO_BIEN = B.CODIGO_BIEN
INNER JOIN CTR.CONTRATO C ON C.CODIGO_CONTRATO = CB.CODIGO_CONTRATO
WHERE	B.ESTADO_REGISTRO = '1'
AND		CB.ESTADO_REGISTRO = '1'
AND		C.CODIGO_ESTADO = 'V'
AND		C.ESTADO_REGISTRO = '1'

SELECT	B.CODIGO_BIEN				CodigoBien,
		B.CODIGO_IDENTIFICACION		CodigoIdentificacion,
		B.NUMERO_SERIE				NumeroSerie,
		B.DESCRIPCION				Descripcion,
		B.MARCA						Marca,
		B.MODELO					Modelo,
		B.CODIGO_TIPO_TARIFA		CodigoTipoTarifa,
		B.CODIGO_PERIODO_ALQUILER	CodigoPeriodoAlquiler,
		B.FECHA_ADQUISICION			FechaAdquisicion,
		B.MES_INICIO_ALQUILER		MesInicioAlquiler,
		B.ANIO_INICIO_ALQUILER		AnioInicioAlquiler,
		CASE	B.CODIGO_TIPO_TARIFA WHEN 'F' THEN B.VALOR_ALQUILER 
		ELSE	(SELECT	BA.MONTO 
				 FROM	CTR.BIEN_ALQUILER BA
				 WHERE	BA.CODIGO_BIEN = B.CODIGO_BIEN
				 AND	BA.ESTADO_REGISTRO = '1'
				 AND	BA.CANTIDAD_LIMITE = (	SELECT	MIN(BA2.CANTIDAD_LIMITE) 
												FROM	CTR.BIEN_ALQUILER BA2
												WHERE	BA2.CODIGO_BIEN = B.CODIGO_BIEN
												AND		BA2.ESTADO_REGISTRO = '1')) END ValorAlquiler,
		--B.VALOR_ALQUILER			ValorAlquiler,
		B.CODIGO_MONEDA				CodigoMoneda
FROM	CTR.BIEN B
WHERE	((B.CODIGO_IDENTIFICACION	LIKE '%' + @DESCRIPCION + '%' OR ISNULL(@DESCRIPCION,'') = '')
OR		(B.NUMERO_SERIE				LIKE '%' + @DESCRIPCION + '%' OR ISNULL(@DESCRIPCION,'') = '')
OR		(B.DESCRIPCION				LIKE '%' + @DESCRIPCION + '%' OR ISNULL(@DESCRIPCION,'') = '')
OR		(B.MARCA					LIKE '%' + @DESCRIPCION + '%' OR ISNULL(@DESCRIPCION,'') = '')
OR		(B.MODELO					LIKE '%' + @DESCRIPCION + '%' OR ISNULL(@DESCRIPCION,'') = ''))
AND		(B.ESTADO_REGISTRO = '1')
--AND		NOT EXISTS (SELECT 1 FROM #TMP_BIENES_SIN_CONTRATO T WHERE T.CODIGO_BIEN = B.CODIGO_BIEN)
AND LEFT(B.CODIGO_IDENTIFICACION,1) = '1'
--INICIO: Agregado por Julio Carrera temporalmente
AND B.CODIGO_IDENTIFICACION NOT LIKE '%[A-B-C-D-E-F-G-H-I-J-K-L-M-N-Ñ-O-P-Q-R-S-T-U-W-Y-X-Z-_]%'
--FIN: Agregado por Julio Carrera temporalmente

GO
/****** Object:  StoredProcedure [CTR].[USP_BIEN_REGISTRO_INS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_BIEN_REGISTRO_INS]
@TIPO_CONTENIDO CHAR(3),
@CONTENIDO NVARCHAR(255),
@USUARIO_CREACION NVARCHAR(50),
@TERMINAL_CREACION NVARCHAR(50)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_BIEN_REGISTRO_INS
Propósito:  Inserta Registros 
Descripción de Parámetros: 
		@TIPO_CONTENIDO:	Parámetro de entrada de tipo char, que representa tipo contenido.
		@CONTENIDO:	Parámetro de entrada de tipo nvarchar, que representa contenido.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
DECLARE @EXISTE INT
SELECT @CONTENIDO=UPPER(ISNULL(@CONTENIDO,''))
SELECT @EXISTE=COUNT(CODIGO_BIEN_REGISTRO) FROM HST.BIEN_REGISTRO BR (NOLOCK)
WHERE BR.CODIGO_TIPO_CONTENIDO=@TIPO_CONTENIDO AND CONTENIDO=@CONTENIDO
AND ESTADO_REGISTRO='1'
IF (@EXISTE=0)
	BEGIN
		INSERT INTO HST.BIEN_REGISTRO(CODIGO_BIEN_REGISTRO,CODIGO_TIPO_CONTENIDO,CONTENIDO,
										ESTADO_REGISTRO,USUARIO_CREACION,FECHA_CREACION,TERMINAL_CREACION )
													SELECT NEWID(), @TIPO_CONTENIDO, @CONTENIDO,
													'1', @USUARIO_CREACION, GETDATE(), @TERMINAL_CREACION
	END
SELECT 1

END

GO
/****** Object:  StoredProcedure [CTR].[USP_BIEN_REGISTRO_INS_UPD]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_BIEN_REGISTRO_INS_UPD]
--@CODIGO_BIEN_REGISTRO UNIQUEIDENTIFIER,
@CODIGO_TIPO_CONTENIDO CHAR(3),
@CONTENIDO nvarchar(255),
@USER_CREATE nvarchar(50),
@TERMINAL_CREATE nvarchar(50)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_BIEN_REGISTRO_INS_UPD
Propósito:  Registra y/o actualiza información de descripción de los Bienes. 
Descripción de Parámetros: 
		@CODIGO_TIPO_CONTENIDO:	Parámetro de entrada de tipo char, que representa codigo tipo contenido.
		@CONTENIDO:	Parámetro de entrada de tipo nvarchar, que representa contenido.
		@USER_CREATE:	Parámetro de entrada de tipo nvarchar, que representa user create.
		@TERMINAL_CREATE:	Parámetro de entrada de tipo nvarchar, que representa terminal create.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
DECLARE @EXISTE INT,
				@CODIGO_BIEN_REGISTRO UNIQUEIDENTIFIER

SELECT @CONTENIDO=UPPER(ISNULL(@CONTENIDO,''))

SELECT @EXISTE = COUNT( CODIGO_BIEN_REGISTRO ) FROM HST.BIEN_REGISTRO (NOLOCK) WHERE CODIGO_TIPO_CONTENIDO=@CODIGO_TIPO_CONTENIDO
																									AND CONTENIDO=@CONTENIDO AND ESTADO_REGISTRO='1'
IF @EXISTE=0
	BEGIN
			SELECT @CODIGO_BIEN_REGISTRO = NEWID()
			INSERT INTO HST.BIEN_REGISTRO (  CODIGO_BIEN_REGISTRO, CODIGO_TIPO_CONTENIDO, CONTENIDO, ESTADO_REGISTRO, 
																		USUARIO_CREACION, TERMINAL_CREACION , FECHA_CREACION )
											SELECT @CODIGO_BIEN_REGISTRO, @CODIGO_TIPO_CONTENIDO, @CONTENIDO, '1',	
																		@USER_CREATE, @TERMINAL_CREATE, GETDATE()
	END
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONSULTA_ADJUNTO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONSULTA_ADJUNTO_SEL]
(
	@CODIGO_CONSULTA_ADJUNTO UNIQUEIDENTIFIER = NULL,
	@CODIGO_CONSULTA UNIQUEIDENTIFIER = NULL,
	@CODIGO_ARCHIVO INT= NULL ,
	@NOMBRE_ARCHIVO NVARCHAR(MAX)= NULL,
	@ESTADO_REGISTRO CHAR(1)= NULL
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_DOCUMENTO_ADJUNTO_SEL
Propósito:   Obtiene el listado de los contratos de documento adjunto
Descripción de Parámetros: 
		@CODIGO_CONSULTA_ADJUNTO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo CONSULTA adjunto.
		@CODIGO_CONSULTA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo consulta.
		@CODIGO_ARCHIVO:	Parámetro de entrada de tipo int, que representa codigo archivo.
		@NOMBRE_ARCHIVO:	Parámetro de entrada de tipo nvarchar, que representa al nombre del documento.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa el estado de registro.
Creado por: GMD
Fecha. Creación: 2015-10-14
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN 
	SELECT 
	   CTR_AD.[CODIGO_CONSULTA_ADJUNTO]					AS CodigoConsultaAdjunto
      ,CTR_AD.[CODIGO_CONSULTA]							AS CodigoConsulta
      ,CTR_AD.[CODIGO_ARCHIVO]							AS CodigoArchivo
      ,CTR_AD.[NOMBRE_ARCHIVO]							AS NombreArchivo
      ,CTR_AD.[RUTA_ARCHIVO_SHAREPOINT]					AS RutaArchivoSharepoint
      ,CTR_AD.[ESTADO_REGISTRO]							AS EstadoRegistro      
	  ,CTR_AD.[USUARIO_CREACION]						AS UsuarioCreacion
  FROM [CTR].[CONSULTA_ADJUNTO] CTR_AD
  WHERE (@CODIGO_CONSULTA_ADJUNTO	IS NULL				OR CTR_AD.[CODIGO_CONSULTA_ADJUNTO] = @CODIGO_CONSULTA_ADJUNTO)
  AND   (@CODIGO_CONSULTA IS NULL						OR CTR_AD.[CODIGO_CONSULTA] = @CODIGO_CONSULTA)
  AND   (@CODIGO_ARCHIVO IS NULL						OR CTR_AD.[CODIGO_ARCHIVO] = @CODIGO_ARCHIVO)
  AND	(@NOMBRE_ARCHIVO IS NULL						OR CTR_AD.[NOMBRE_ARCHIVO] = @NOMBRE_ARCHIVO)
  AND   (@ESTADO_REGISTRO IS NULL						OR CTR_AD.[ESTADO_REGISTRO] = @ESTADO_REGISTRO)
END


GO
/****** Object:  StoredProcedure [CTR].[USP_CONSULTA_RPT]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_CONSULTA_RPT] --NULL, NULL, NULL, NULL, NULL, NULL
@CODIGO_REMITENTE			UNIQUEIDENTIFIER,
@CODIGO_DESTINATARIO		UNIQUEIDENTIFIER,
@CODIGO_TIPO_CONSULTA		VARCHAR(10),
@CODIGO_UNIDAD_OPERATIVA	UNIQUEIDENTIFIER,
@CODIGO_AREA_EMPRESA		NVARCHAR(5),
@CODIGO_ESTADO_CONSULTA		NVARCHAR(5)
AS 
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONSULTA_RPT
Propósito:   Obtener el listado de la consulta   
Descripción de Parámetros: 
		@CODIGO_REMITENTE:			Parámetro de entrada de tipo uniqueidentifier, que representa codigo de remitente.
		@CODIGO_DESTINATARIO:		Parámetro de entrada de tipo uniqueidentifier, que representa codigo de destinatario.
		@CODIGO_TIPO_CONSULTA:		Parámetro de entrada de tipo varchar, que representa tipo de consulta.
		@CODIGO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo uniqueidentifier, que representa Código de Unidad Operativa.
		@CODIGO_AREA_EMPRESA:		Parámetro de entrada de tipo varchar, que representa el Código de Área de Empresa.
		@CODIGO_ESTADO_CONSULTA:	Parámetro de entrada de tipo varchar, que representa el Código de Estado de Consulta.
Creado por: GMD
Fecha. Creación: 2016-07-13
Fecha. Actualización:
**********************************************************************************************************************************/
BEGIN


	DECLARE @CODIGO_CONSULTA_ORIGINAL AS UNIQUEIDENTIFIER 
    SELECT	CODIGO_CONSULTA							AS CodigoConsulta,
			CODIGO_REMITENTE						AS CodigoRemitente,
			CODIGO_DESTINATARIO						AS CodigoDestinatario,
			TIPO									AS CodigoTipoConsulta,
			CODIGO_UNIDAD_OPERATIVA					AS CodigoUnidadOperativa,
			CODIGO_AREA								AS CodigoAreaEmpresa,
			ASUNTO									AS Asunto,
			CONTENIDO								AS Contenido,
			ESTADO_CONSULTA							AS CodigoEstadoConsulta,
			FECHA_ENVIO								AS FechaEnvio,
			RESPUESTA								AS Respuesta,
			FECHA_RESPUESTA							AS FechaRespuesta,			
			(SELECT FECHA_ENVIO FROM CTR.CONSULTA WHERE CODIGO_CONSULTA = CN.CODIGO_CONSULTA_ORIGINAL AND CN.CODIGO_CONSULTA_ORIGINAL IS NOT NULL) AS FechaEnvioConsultaOriginal,
			--IIF(FECHA_RESPUESTA IS NOT NULL, DATEDIFF(dd,FECHA_ENVIO,FECHA_RESPUESTA),
			--'-') AS TiempoRespuesta
			IIF(FECHA_RESPUESTA IS NOT NULL, CAST(DATEDIFF(dd,FECHA_ENVIO,FECHA_RESPUESTA) AS VARCHAR),
			'-') AS TiempoRespuesta
    FROM    CTR.CONSULTA AS CN
    WHERE   (CODIGO_REMITENTE			= @CODIGO_REMITENTE			OR @CODIGO_REMITENTE		IS NULL)
	AND		(CODIGO_DESTINATARIO		= @CODIGO_DESTINATARIO		OR @CODIGO_DESTINATARIO		IS NULL)
	AND		(TIPO						= @CODIGO_TIPO_CONSULTA		OR @CODIGO_TIPO_CONSULTA	IS NULL)
	AND		(CODIGO_UNIDAD_OPERATIVA	= @CODIGO_UNIDAD_OPERATIVA	OR @CODIGO_UNIDAD_OPERATIVA	IS NULL)
	AND		(CODIGO_AREA				= @CODIGO_AREA_EMPRESA		OR @CODIGO_AREA_EMPRESA		IS NULL)
	AND		(ESTADO_CONSULTA		= @CODIGO_ESTADO_CONSULTA	OR @CODIGO_ESTADO_CONSULTA	IS NULL)
	AND		(ESTADO_REGISTRO = '1')
	--AND		VISTO_REMITENTE_ORIGINAL=1
	ORDER BY FECHA_CREACION DESC
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONSULTA_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONSULTA_SEL] --NULL, NULL, NULL, NULL, NULL,null, null, '9CD3A8CF-4009-482E-B062-AA48F8080E1D'
    (
       @CODIGO_REMITENTE UNIQUEIDENTIFIER
	  ,@CODIGO_DESTINATARIO UNIQUEIDENTIFIER
	  ,@CODIGO_TIPO_CONSULTA VARCHAR(10)
	  ,@CODIGO_UNIDAD_OPERATIVA UNIQUEIDENTIFIER
	  ,@CODIGO_AREA VARCHAR(10)
	  ,@CODIGO_CONSULTA UNIQUEIDENTIFIER
	  ,@ESTADO_CONSULTA VARCHAR(5)
	  ,@CODIGO_USUARIO_SESSION UNIQUEIDENTIFIER
	  ,@PageNo		INT = 1
	  ,@PageSize	INT = -1
    )
AS 
BEGIN
DECLARE @lPageNbr	INT,
		@lPageSize	INT,
		@lFirstRec	INT,
		@lLAStRec	INT

SET @lPageNbr = @PageNo
SET @lPageSize = @PageSize

SET @lFirstRec = (@lPageNbr - 1) * @lPageSize
SET @lLAStRec = (@lPageNbr * @lPageSize + 1);
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONSULTA_SEL
Propósito:   Obtener el listado de la consulta   
Descripción de Parámetros: 
		@CODIGO_REMITENTE:		  Parámetro de entrada de tipo uniqueidentifier, que representa codigo de remitente.
		@CODIGO_DESTINATARIO:	  Parámetro de entrada de tipo uniqueidentifier, que representa codigo de destinatario.
		@CODIGO_TIPO_CONSULTA:	  Parámetro de entrada de tipo varchar, que representa tipo de consulta.
		@CODIGO_UNIDAD_OPERATIVA: Parámetro de entrada de tipo uniqueidentifier, que representa la unidad operativa.
		@CODIGO_AREA:			  Parámetro de entrada de tipo varchar, que representa el área.
		@CODIGO_CONSULTA:		  Parámetro de entrada de tipo uniqueidentifier, que representa código de consulta.
		@CODIGO_USUARIO_SESSION	  Parámtro de entrada de tipo uniqueidentifier, que representa código de usuario de sesón
		 por: GMD
Fecha. Creación: 2016-07-07
Fecha. Actualización: 
**********************************************************************************************************************************/
SELECT CODIGO_CONSULTA
INTO #CONSULTAS_QUITAR
FROM CTR.CONSULTA 
WHERE CODIGO_REMITENTE = @CODIGO_USUARIO_SESSION
AND VISTO_REMITENTE_ORIGINAL = 0
AND ESTADO_REGISTRO = '1';

 WITH	CTE_Results AS (SELECT ROW_NUMBER() OVER (ORDER BY C.[FECHA_ENVIO] DESC) AS RowNumber,
		COUNT(*) OVER() AS RowsTotal,
		CONVERT(VARCHAR, COUNT(*) OVER())		AS RowId,  
		 C.[CODIGO_CONSULTA] AS CodigoConsulta
        ,C.[CODIGO_REMITENTE] AS CodigoRemitente
        ,C.[CODIGO_DESTINATARIO] AS CodigoDestinatario
        ,C.[TIPO] AS Tipo
        ,C.[ASUNTO] AS Asunto
        ,C.[CONTENIDO] AS Contenido
        ,C.[ESTADO_CONSULTA] AS EstadoConsulta
        ,C.[FECHA_ENVIO] AS FechaEnvio
        ,C.[RESPUESTA] AS Respuesta
        ,C.[FECHA_RESPUESTA] AS FechaRespuesta
		,C.[CODIGO_UNIDAD_OPERATIVA] AS CodigoUnidadOperativa
		,C.[CODIGO_AREA] AS CodigoArea
		,C.[CODIGO_CONSULTA_RELACIONADO] AS CodigoConsultaRelacionado
		,C.[CODIGO_CONSULTA_ORIGINAL] AS CodigoConsultaOriginal
		,(SELECT TOP 1 CODIGO_REMITENTE FROM CTR.CONSULTA WHERE CODIGO_CONSULTA = C.[CODIGO_CONSULTA_ORIGINAL]) AS CodigoRemitenteOriginal
		,ISNULL((SELECT DATEDIFF(day, C.[FECHA_ENVIO], GETDATE()) WHERE C.FECHA_RESPUESTA IS NULL), 0) AS DiaSinRespuesta
		,C.[VISTO_REMITENTE_ORIGINAL] AS VistoRemitenteOriginal
    FROM    [CTR].[CONSULTA] C
    WHERE		( @CODIGO_REMITENTE IS NULL OR CODIGO_REMITENTE = @CODIGO_REMITENTE)
            AND ( @CODIGO_DESTINATARIO IS NULL OR CODIGO_DESTINATARIO = @CODIGO_DESTINATARIO)
            AND ( @CODIGO_TIPO_CONSULTA IS NULL OR TIPO = @CODIGO_TIPO_CONSULTA)
			AND ( @CODIGO_UNIDAD_OPERATIVA IS NULL OR CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA)
			AND ( @CODIGO_AREA IS NULL OR CODIGO_AREA = @CODIGO_AREA)
			AND ( @CODIGO_CONSULTA IS NULL OR CODIGO_CONSULTA = @CODIGO_CONSULTA)
			AND ( @ESTADO_CONSULTA IS NULL OR ESTADO_CONSULTA = @ESTADO_CONSULTA)
			AND ( CODIGO_REMITENTE = @CODIGO_USUARIO_SESSION OR CODIGO_DESTINATARIO = @CODIGO_USUARIO_SESSION)
            AND	  ESTADO_REGISTRO = '1'
			AND C.CODIGO_CONSULTA NOT IN (SELECT CODIGO_CONSULTA FROM #CONSULTAS_QUITAR)
)

SELECT	RowNumber,
		RowsTotal,	
		RowId,
        CodigoConsulta,
        CodigoRemitente,
        CodigoDestinatario,
		Tipo,
		Asunto,
		Contenido,
		EstadoConsulta,
		FechaEnvio,
        Respuesta,
		FechaRespuesta,
		CodigoUnidadOperativa,
		CodigoArea,
		CodigoConsultaRelacionado,
		CodigoConsultaOriginal,
		CodigoRemitenteOriginal,
		DiaSinRespuesta
FROM    CTE_Results
WHERE   @PageSize < 0 OR ( RowNumber > @lFirstRec AND RowNumber < @lLAStRec)
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTENIDO_BIEN_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTENIDO_BIEN_SEL]
@CODIGO_TIPO_CONTENIDO CHAR(3)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTENIDO_BIEN_SEL
Propósito: <<No especificado>>
Descripción de Parámetros: 
		@CODIGO_TIPO_CONTENIDO:	Parámetro de entrada de tipo char, que representa codigo tipo contenido.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
select CodigoTipoContenido=CODIGO_TIPO_CONTENIDO,
		   Contenido= CONTENIDO
 from  HST.BIEN_REGISTRO (NOLOCK)
 WHERE CODIGO_TIPO_CONTENIDO=@CODIGO_TIPO_CONTENIDO AND ESTADO_REGISTRO='1'
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_BIEN_INS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_CONTRATO_BIEN_INS]
@CODIGO_CONTRATO_BIEN UNIQUEIDENTIFIER,
@CODIGO_CONTRATO UNIQUEIDENTIFIER,
@CODIGO_BIEN UNIQUEIDENTIFIER,
@ESTADO_REGISTRO CHAR(1),
@USUARIO_CREACION NVARCHAR(50),
@FECHA_CREACION DATETIME,
@TERMINAL_CREACION NVARCHAR(50),
@TIPO_TARIFA CHAR(1),
@TIPO_PERIODO CHAR(1),
@HORAS_MINIMAS INT,
@TARIFA DECIMAL(18,2),
@MAYORMENOR VARCHAR(10)
AS 
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_BIEN_INS
Propósito: <<No especificado>>
Descripción de Parámetros: 
		@CODIGO_CONTRATO_BIEN:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato bien.
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
		@CODIGO_BIEN:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo bien.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@FECHA_CREACION:	Parámetro de entrada de tipo datetime, que representa fecha creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
INSERT INTO CTR.CONTRATO_BIEN
	(
		CODIGO_CONTRATO_BIEN ,
		CODIGO_CONTRATO ,
		CODIGO_BIEN,
		ESTADO_REGISTRO ,
		USUARIO_CREACION ,
		FECHA_CREACION,
		TERMINAL_CREACION,
		TIPO_TARIFA,
		TIPO_PERIODO,
		HORAS_MINIMAS,
		TARIFA,
		MAYORMENOR
	)
	VALUES
	(	
		@CODIGO_CONTRATO_BIEN ,
		@CODIGO_CONTRATO ,
		@CODIGO_BIEN ,
		@ESTADO_REGISTRO ,
		@USUARIO_CREACION ,
		@FECHA_CREACION ,
		@TERMINAL_CREACION,
		@TIPO_TARIFA,
		@TIPO_PERIODO,
		@HORAS_MINIMAS,
		@TARIFA,
		@MAYORMENOR
	)
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_BIEN_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_BIEN_SEL] --'75c276ce-ee68-41d3-81d8-a1899fe56588'
@CODIGO_CONTRATO uniqueidentifier
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_BIEN_SEL
Propósito:  Retorna los bienes de los párrafos de un contrato. 
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
Creado por: GMD
Fecha. Creación: 2015-10-20
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
SELECT 
		[CODIGO_CONTRATO_BIEN] AS 'CodigoContratoBien'
      ,[CODIGO_CONTRATO] AS 'CodigoContrato'
      ,[CODIGO_BIEN] AS 'CodigoBien'
      ,[ESTADO_REGISTRO] AS 'EstadoRegistro'
FROM [CTR].[CONTRATO_BIEN] (NOLOCK) 
WHERE [CODIGO_CONTRATO] = @CODIGO_CONTRATO
AND ESTADO_REGISTRO='1'
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_CORPORATIVO_RPT]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_CORPORATIVO_RPT]
(
	@CODIGO_UNIDAD_OPERATIVA		UNIQUEIDENTIFIER,
	@NUMERO_CONTRATO				NVARCHAR(50),
	@DESCRIPCION					NVARCHAR(255),
	@CODIGO_TIPO_SERVICIO			NVARCHAR(5),
	@CODIGO_TIPO_REQUERIMIENTO		NVARCHAR(5),
	@CODIGO_TIPO_DOCUMENTO			NVARCHAR(5),
	@CODIGO_ESTADO					NVARCHAR(5),	
	@FECHA_INICIO_VIGENCIA			DATETIME,
	@FECHA_FIN_VIGENCIA				DATETIME,
	@NAME_DATABASE					NVARCHAR(500),
	@RUC_NOMBRE						NVARCHAR(500),
	@PageNo							INT = 1,
	@PageSize						BIGINT = -1
) 
AS
BEGIN
DECLARE @Query NVARCHAR(MAX)

SET @Query = N'DECLARE	@lPageNbr	INT,
						@lPageSize	INT,
						@lFirstRec	INT,
						@lLAStRec	INT;

	WITH CTE_Results AS (SELECT		
				ROW_NUMBER() OVER (ORDER BY C.DESCRIPCION ASC)  AS RowNumber,
				COUNT(*) OVER()									AS RowsTotal,
				CONVERT(VARCHAR, COUNT(*) OVER())				AS RowId,
				C.CODIGO_CONTRATO								AS CodigoContrato,
				C.CODIGO_UNIDAD_OPERATIVA						AS CodigoUnidadOperativa,
				C.NUMERO_CONTRATO								AS NumeroContrato,
				C.NUMERO_ADENDA_CONCATENADO						AS NumeroAdendaConcatenado,
				C.DESCRIPCION									AS Descripcion, 
				P.NUMERO_DOCUMENTO + '' - '' + P.NOMBRE			AS NombreProveedor,    
				C.FECHA_INICIO_VIGENCIA							AS FechaInicioVigencia,
				C.FECHA_FIN_VIGENCIA							AS FechaFinVigencia,
				C.CODIGO_TIPO_SERVICIO							AS CodigoTipoServicio,
				C.CODIGO_TIPO_REQUERIMIENTO						AS CodigoTipoRequerimiento,
				C.CODIGO_TIPO_DOCUMENTO							AS CodigoTipoDocumento,
				C.CODIGO_ESTADO									AS CodigoEstadoContrato,
				C.CODIGO_ESTADO_EDICION							AS CodigoEstadoEdicion,
				UO.NOMBRE										AS NombreUnidadOperativa,
				C.USUARIO_CREACION								AS UsuarioCreacion,
				C.FECHA_CREACION								AS FechaCreacion

			FROM	CTR.CONTRATO C
				INNER JOIN '+ @NAME_DATABASE +'.GRL.UNIDAD_OPERATIVA UO ON UO.CODIGO_UNIDAD_OPERATIVA = C.CODIGO_UNIDAD_OPERATIVA
				LEFT JOIN CTR.PROVEEDOR	P ON P.CODIGO_PROVEEDOR = C.CODIGO_PROVEEDOR
			WHERE	(C.CODIGO_UNIDAD_OPERATIVA				=		@CODIGO_UNIDAD_OPERATIVA		OR @CODIGO_UNIDAD_OPERATIVA IS NULL)
			
			AND		(C.NUMERO_CONTRATO						=		@NUMERO_CONTRATO			    OR ISNULL(@NUMERO_CONTRATO,'''') = '''')
			AND		(C.DESCRIPCION							LIKE	''%'' + @DESCRIPCION + ''%''	OR ISNULL(@DESCRIPCION, '''') = '''')
			AND		(C.CODIGO_TIPO_SERVICIO					=		@CODIGO_TIPO_SERVICIO			OR ISNULL(@CODIGO_TIPO_SERVICIO,'''') = '''')
			AND		(C.CODIGO_TIPO_REQUERIMIENTO			=		@CODIGO_TIPO_REQUERIMIENTO		OR ISNULL(@CODIGO_TIPO_REQUERIMIENTO,'''') = '''')							  	
			AND		(C.CODIGO_TIPO_DOCUMENTO				=		@CODIGO_TIPO_DOCUMENTO			OR ISNULL(@CODIGO_TIPO_DOCUMENTO,'''') = '''')								  	
			AND		(C.CODIGO_ESTADO						=		@CODIGO_ESTADO					OR ISNULL(@CODIGO_ESTADO,'''') = '''')	
			AND		(C.FECHA_INICIO_VIGENCIA				>=		@FECHA_INICIO_VIGENCIA OR @FECHA_INICIO_VIGENCIA IS NULL) 
			AND		(C.FECHA_FIN_VIGENCIA					<=		@FECHA_FIN_VIGENCIA OR @FECHA_FIN_VIGENCIA IS NULL)
			AND		C.ESTADO_REGISTRO = ''1''
			AND		C.ES_CORPORATIVO = 1
			AND     ((P.NUMERO_DOCUMENTO + '' - '' + P.NOMBRE) LIKE	''%'' + @RUC_NOMBRE + ''%''	OR ISNULL(@RUC_NOMBRE, '''') = '''')
			)

	SELECT	RowNumber,
			RowsTotal,
			RowId,
			CodigoContrato,
			CodigoUnidadOperativa,	
			NombreProveedor,
			NumeroContrato,
			NumeroAdendaConcatenado,
			Descripcion,
			CodigoTipoServicio,
			CodigoTipoRequerimiento,
			CodigoTipoDocumento,
			FechaInicioVigencia,
			FechaFinVigencia,		
			CodigoEstadoContrato,
			CodigoEstadoEdicion,
			NombreUnidadOperativa,
			UsuarioCreacion,
			FechaCreacion			

	FROM    CTE_Results
	WHERE   @PageSize < 0 OR ( RowNumber > @lFirstRec AND RowNumber < @lLAStRec)  
	ORDER BY  CodigoUnidadOperativa, Descripcion'

  BEGIN
	DECLARE @paramDef NVARCHAR(max) = N'
			@CODIGO_UNIDAD_OPERATIVA		UNIQUEIDENTIFIER,
			@NUMERO_CONTRATO				NVARCHAR(50),
			@DESCRIPCION					NVARCHAR(255),
			@CODIGO_TIPO_SERVICIO			NVARCHAR(5),
			@CODIGO_TIPO_REQUERIMIENTO		NVARCHAR(5),
			@CODIGO_TIPO_DOCUMENTO			NVARCHAR(5),
			@CODIGO_ESTADO					NVARCHAR(5),	
			@FECHA_INICIO_VIGENCIA			DATETIME,
			@FECHA_FIN_VIGENCIA				DATETIME,
			@NAME_DATABASE					NVARCHAR(500),
			@RUC_NOMBRE						NVARCHAR(500),
			@PageNo							INT = 1,
			@PageSize						BIGINT = -1'

	EXEC sys.sp_executesql @Query,
			@paramDef,
			@CODIGO_UNIDAD_OPERATIVA,	
			@NUMERO_CONTRATO,			
			@DESCRIPCION,				
			@CODIGO_TIPO_SERVICIO,		
			@CODIGO_TIPO_REQUERIMIENTO,	
			@CODIGO_TIPO_DOCUMENTO,		
			@CODIGO_ESTADO,				
			@FECHA_INICIO_VIGENCIA,		
			@FECHA_FIN_VIGENCIA,
			@NAME_DATABASE,
			@RUC_NOMBRE,		
			@PageNo,						
			@PageSize					


  END
END

--EXEC [CTR].[USP_CONTRATO_CORPORATIVO_RPT] NULL,null,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'STRACON_POLITICAS_SGC_DEV','G',1,-1


GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION_SEL]
(@CODIGO_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION UNIQUEIDENTIFIER = NULL,
@CODIGO_CONTRATO UNIQUEIDENTIFIER = NULL,
@CODIGO_ARCHIVO INT= NULL ,
@NOMBRE_ARCHIVO NVARCHAR(MAX)= NULL,
@ESTADO_REGISTRO CHAR(1)= NULL)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION_SEL
Propósito:   Obtiene el listado de los contratos de documento adjunto de resolución
Descripción de Parámetros: 
@CODIGO_CONTRATO_DOCUMENTO_ADJUNTO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato documento adjunto.
@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
@CODIGO_ARCHIVO:	Parámetro de entrada de tipo int, que representa codigo archivo.
@NOMBRE_ARCHIVO:	Parámetro de entrada de tipo nvarchar, que representa al nombre del documento.
@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa el estado de registro.
Creado por: Adexus
Fecha. Creación: 2018-08-07
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN 

DECLARE @NUMERO_CONTRATO VARCHAR(100) = (SELECT NUMERO_CONTRATO FROM CTR.CONTRATO WHERE CODIGO_CONTRATO = @CODIGO_CONTRATO)

SELECT [CODIGO_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION]	AS CodigoContratoDocumentoAdjuntoResolucion
,CTR_AD.[CODIGO_CONTRATO]						AS CodigoContrato
,CTR_AD.[CODIGO_ARCHIVO]							AS CodigoArchivo
,CTR_AD.[NOMBRE_ARCHIVO]							AS NombreArchivo
,CTR_AD.[RUTA_ARCHIVO_SHAREPOINT]				AS RutaArchivoSharepoint
,CTR_AD.[ESTADO_REGISTRO]						AS EstadoRegistro      
,CTR_AD.[USUARIO_CREACION]							AS UsuarioCreacion
FROM [CTR].[CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION] CTR_AD JOIN CTR.CONTRATO CTO
ON CTR_AD.CODIGO_CONTRATO = CTO.CODIGO_CONTRATO
WHERE (@CODIGO_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION	IS NULL		OR CTR_AD.[CODIGO_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION] = @CODIGO_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION)
--AND   (@CODIGO_CONTRATO IS NULL						OR CTR_AD.[CODIGO_CONTRATO] = @CODIGO_CONTRATO)
AND	  (CTO.NUMERO_CONTRATO = @NUMERO_CONTRATO OR @CODIGO_CONTRATO IS NULL)
AND   (@CODIGO_ARCHIVO IS NULL						OR CTR_AD.[CODIGO_ARCHIVO] = @CODIGO_ARCHIVO)
AND	  (@NOMBRE_ARCHIVO IS NULL						OR CTR_AD.[NOMBRE_ARCHIVO] = @NOMBRE_ARCHIVO)
AND   (@ESTADO_REGISTRO IS NULL						OR CTR_AD.[ESTADO_REGISTRO] = @ESTADO_REGISTRO)

END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_DOCUMENTO_ADJUNTO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_DOCUMENTO_ADJUNTO_SEL]
(
	@CODIGO_CONTRATO_DOCUMENTO_ADJUNTO UNIQUEIDENTIFIER = NULL,
	@CODIGO_CONTRATO UNIQUEIDENTIFIER = NULL,
	@CODIGO_ARCHIVO INT= NULL ,
	@NOMBRE_ARCHIVO NVARCHAR(MAX)= NULL,
	@ESTADO_REGISTRO CHAR(1)= NULL
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_DOCUMENTO_ADJUNTO_SEL
Propósito:   Obtiene el listado de los contratos de documento adjunto
Descripción de Parámetros: 
		@CODIGO_CONTRATO_DOCUMENTO_ADJUNTO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato documento adjunto.
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
		@CODIGO_ARCHIVO:	Parámetro de entrada de tipo int, que representa codigo archivo.
		@NOMBRE_ARCHIVO:	Parámetro de entrada de tipo nvarchar, que representa al nombre del documento.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa el estado de registro.
Creado por: GMD
Fecha. Creación: 2015-10-14
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN 
	SELECT [CODIGO_CONTRATO_DOCUMENTO_ADJUNTO]	AS CodigoContratoDocumentoAdjunto
      ,CTR_AD.[CODIGO_CONTRATO]						AS CodigoContrato
      ,CTR_AD.[CODIGO_ARCHIVO]							AS CodigoArchivo
      ,CTR_AD.[NOMBRE_ARCHIVO]							AS NombreArchivo
      ,CTR_AD.[RUTA_ARCHIVO_SHAREPOINT]				AS RutaArchivoSharepoint
      ,CTR_AD.[ESTADO_REGISTRO]						AS EstadoRegistro      
	  ,CTR_AD.[USUARIO_CREACION]							AS UsuarioCreacion
  FROM [CTR].[CONTRATO_DOCUMENTO_ADJUNTO] CTR_AD
  WHERE (@CODIGO_CONTRATO_DOCUMENTO_ADJUNTO	IS NULL		OR CTR_AD.[CODIGO_CONTRATO_DOCUMENTO_ADJUNTO] = @CODIGO_CONTRATO_DOCUMENTO_ADJUNTO)
  AND   (@CODIGO_CONTRATO IS NULL						OR CTR_AD.[CODIGO_CONTRATO] = @CODIGO_CONTRATO)
  AND   (@CODIGO_ARCHIVO IS NULL						OR CTR_AD.[CODIGO_ARCHIVO] = @CODIGO_ARCHIVO)
  AND	(@NOMBRE_ARCHIVO IS NULL						OR CTR_AD.[NOMBRE_ARCHIVO] = @NOMBRE_ARCHIVO)
  AND   (@ESTADO_REGISTRO IS NULL						OR CTR_AD.[ESTADO_REGISTRO] = @ESTADO_REGISTRO)
END


GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_DOCUMENTO_INS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_CONTRATO_DOCUMENTO_INS]
@CODIGO_CONTRATO_DOCUMENTO UNIQUEIDENTIFIER,
@CODIGO_CONTRATO UNIQUEIDENTIFIER,
@CODIGO_ARCHIVO INT,
@RUTA_ARCHIVO_SHAREPOINT NVARCHAR(MAX),
@CONTENIDO NVARCHAR(MAX),
@CONTENIDO_BUSQUEDA NVARCHAR(MAX),
@INDICADOR_ACTUAL BIT,
@VERSION TINYINT,
@ESTADO_REGISTRO CHAR(1),
@USUARIO_CREACION NVARCHAR(50),
@FECHA_CREACION DATETIME,
@TERMINAL_CREACION NVARCHAR(50)
AS 
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_DOCUMENTO_INS
Propósito:  Inserta y actualiza registros en la tabla Contrato documento 
Descripción de Parámetros: 
		@CODIGO_CONTRATO_DOCUMENTO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato documento.
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
		@CODIGO_ARCHIVO:	Parámetro de entrada de tipo int, que representa codigo archivo.
		@RUTA_ARCHIVO_SHAREPOINT:	Parámetro de entrada de tipo nvarchar, que representa ruta archivo sharepoint.
		@CONTENIDO:	Parámetro de entrada de tipo nvarchar, que representa contenido.
		@CONTENIDO_BUSQUEDA:	Parámetro de entrada de tipo nvarchar, que representa contenido del contrato en formato de texto plano.
		@INDICADOR_ACTUAL:	Parámetro de entrada de tipo bit, que representa indicador actual.
		@VERSION:	Parámetro de entrada de tipo tinyint, que representa version.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@FECHA_CREACION:	Parámetro de entrada de tipo datetime, que representa fecha creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

DECLARE 	@VersionDoc tinyint

	SELECT	@VersionDoc			= MAX([VERSION]	)
	FROM	CTR.CONTRATO_DOCUMENTO  CD (NOLOCK)
	WHERE	CODIGO_CONTRATO		=	@CODIGO_CONTRATO 
	AND		ESTADO_REGISTRO		=	'1'

	SET 	@VERSION			=	ISNULL(@VersionDoc,0) + 1

INSERT INTO CTR.CONTRATO_DOCUMENTO
	(
		CODIGO_CONTRATO_DOCUMENTO ,
		CODIGO_CONTRATO ,
		CODIGO_ARCHIVO,
		RUTA_ARCHIVO_SHAREPOINT ,
		CONTENIDO ,
		CONTENIDO_BUSQUEDA ,
		INDICADOR_ACTUAL,
		[VERSION] ,
		ESTADO_REGISTRO ,
		USUARIO_CREACION ,
		FECHA_CREACION,
		TERMINAL_CREACION 
	)
	VALUES
	(	
		@CODIGO_CONTRATO_DOCUMENTO ,
		@CODIGO_CONTRATO ,
		@CODIGO_ARCHIVO ,
		@RUTA_ARCHIVO_SHAREPOINT ,
		@CONTENIDO ,
		@CONTENIDO_BUSQUEDA,
		@INDICADOR_ACTUAL ,
		@VERSION ,
		@ESTADO_REGISTRO ,
		@USUARIO_CREACION ,
		@FECHA_CREACION ,
		@TERMINAL_CREACION 
	)
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_DOCUMENTO_POR_CONTRATO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_DOCUMENTO_POR_CONTRATO]
@CodigoContrato uniqueidentifier
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_DOCUMENTO_POR_CONTRATO
Propósito:  Retorna información de los documentos del contrato. 
Descripción de Parámetros: 
		@CodigoContrato:	Parámetro de entrada de tipo uniqueidentifier, que representa codigocontrato.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
		select NumeroContrato= CT.NUMERO_CONTRATO,
				   CodigoContratoDocumento= CD.CODIGO_CONTRATO_DOCUMENTO,
				   CodigoArchivo=CD.CODIGO_ARCHIVO,
				   RutaArchivoSharePoint= isnull(CD.RUTA_ARCHIVO_SHAREPOINT,''),
				   IndicadorActual=CD.INDICADOR_ACTUAL,
				   Contenido= CD.CONTENIDO,
				   SVersion = CD.[VERSION] from CTR.CONTRATO_DOCUMENTO CD (NOLOCK) INNER JOIN CTR.CONTRATO CT (NOLOCK)
			ON (CD.CODIGO_CONTRATO= CT.CODIGO_CONTRATO)
			WHERE CT.CODIGO_CONTRATO=@CodigoContrato
			and CT.ESTADO_REGISTRO='1'  ORDER BY  CD.INDICADOR_ACTUAL DESC
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_DOCUMENTO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_DOCUMENTO_SEL]
(	
	@CODIGO_CONTRATO UNIQUEIDENTIFIER = NULL,
	@CODIGO_CONTRATO_DOCUMENTO UNIQUEIDENTIFIER = NULL,
	@CODIGO_ARCHIVO INT= NULL ,
	@RUTA_ARCHIVO_SHAREPOINT NVARCHAR(MAX)= NULL,
	@CONTENIDO NVARCHAR(MAX)= NULL,
	@INDICADOR_ACTUAL BIT= NULL,
	@VERSION TINYINT= NULL,
	@PageNo		INT = 1,
	@PageSize	INT = -1
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_DOCUMENTO_SEL
Propósito:   Obtiene el listado de los contratos de documento  
Descripción de Parámetros: 		
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
		@CODIGO_CONTRATO_DOCUMENTO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato documento.
		@CODIGO_ARCHIVO:	Parámetro de entrada de tipo int, que representa codigo archivo.
		@RUTA_ARCHIVO_SHAREPOINT:	Parámetro de entrada de tipo nvarchar, que representa ruta archivo sharepoint.
		@CONTENIDO:	Parámetro de entrada de tipo nvarchar, que representa contenido.
		@INDICADOR_ACTUAL:	Parámetro de entrada de tipo bit, que representa indicador actual.
		@VERSION:	Parámetro de entrada de tipo tinyint, que representa version.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN 
	DECLARE @lPageNbr	INT,
			@lPageSize	INT,
			@lFirstRec	INT,
			@lLAStRec	INT

	SET @lPageNbr = @PageNo
	SET @lPageSize = @PageSize

	SET @lFirstRec = (@lPageNbr - 1) * @lPageSize
	SET @lLAStRec = (@lPageNbr * @lPageSize + 1);

	WITH	CTE_Results AS (SELECT ROW_NUMBER() OVER (ORDER BY CODIGO_CONTRATO ASC) AS RowNumber,
			COUNT(*) OVER() AS RowsTotal,
			CONVERT(VARCHAR, COUNT(*) OVER())		AS RowId,
			CODIGO_CONTRATO_DOCUMENTO				AS CodigoContratoDocumento,
			CODIGO_CONTRATO							AS CodigoContrato,
			CODIGO_ARCHIVO							AS CodigoArchivo,
			RUTA_ARCHIVO_SHAREPOINT					AS RutaArchivoSharePoint,
			CONTENIDO								AS Contenido,
			INDICADOR_ACTUAL						AS IndicadorActual,
			[VERSION]								AS [Version]
	FROM	CTR.CONTRATO_DOCUMENTO
	WHERE	(CODIGO_CONTRATO_DOCUMENTO				=		@CODIGO_CONTRATO_DOCUMENTO		OR @CODIGO_CONTRATO_DOCUMENTO IS NULL)
	AND		(CODIGO_CONTRATO						=		@CODIGO_CONTRATO				OR @CODIGO_CONTRATO IS NULL)
	AND		(CODIGO_ARCHIVO							=		@CODIGO_ARCHIVO					OR ISNULL(@CODIGO_ARCHIVO,'') = '')	
	AND		(RUTA_ARCHIVO_SHAREPOINT				=		@RUTA_ARCHIVO_SHAREPOINT		OR ISNULL(@RUTA_ARCHIVO_SHAREPOINT, '') = '')
	AND		(CONTENIDO								=		@CONTENIDO						OR ISNULL(@CONTENIDO, '') = '')
	AND		(INDICADOR_ACTUAL						=		@INDICADOR_ACTUAL				OR ISNULL(@INDICADOR_ACTUAL,'') = '')
	AND		([VERSION]								=		@VERSION						OR ISNULL(@VERSION,'') = '')
	AND		(ESTADO_REGISTRO = '1')
	)

	SELECT	RowNumber,
			RowsTotal,
			RowId,
			CodigoContratoDocumento,
			CodigoContrato,
			CodigoArchivo,
			RutaArchivoSharePoint,
			Contenido,
			IndicadorActual,
			[Version]			
	FROM    CTE_Results
	WHERE   @PageSize < 0 OR ( RowNumber > @lFirstRec AND RowNumber < @lLAStRec)        
END


GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_ELIMINADOS_RPT]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_CONTRATO_ELIMINADOS_RPT] 
(
	@CODIGO_UNIDAD_OPERATIVA		UNIQUEIDENTIFIER,
	@NUMERO_CONTRATO				NVARCHAR(50),
	@DESCRIPCION					NVARCHAR(255),
	@CODIGO_TIPO_SERVICIO			NVARCHAR(5),
	@CODIGO_TIPO_REQUERIMIENTO		NVARCHAR(5),
	@CODIGO_TIPO_DOCUMENTO			NVARCHAR(5),
	@CODIGO_ESTADO					NVARCHAR(5),
	@FECHA_INICIO_VIGENCIA			DATETIME,
	@FECHA_FIN_VIGENCIA				DATETIME	
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_ELIMINADOS_RPT
Propósito:   Obtiene el listado de contratos eliminados  
Descripción de Parámetros: 
		@CODIGO_UNIDAD_OPERATIVA: Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@NUMERO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa numero contrato.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
		@CODIGO_TIPO_SERVICIO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo servicio.
		@CODIGO_TIPO_REQUERIMIENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo requerimiento.
		@CODIGO_TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.
		@CODIGO_ESTADO:	Parámetro de entrada de tipo nvarchar, que representa codigo estado.		
		@FECHA_INICIO_VIGENCIA:	Parámetro de entrada de tipo datetime, que representa fecha de inicio de vigencia del contrato.
		@FECHA_FIN_VIGENCIA:	Parámetro de entrada de tipo datetime, que representa fecha fin de vigencia del contrato.	
Creado por: GMD
Fecha. Creación: 2017-06-27
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

	SELECT	C.CODIGO_UNIDAD_OPERATIVA				AS CodigoUnidad,
			C.NUMERO_CONTRATO						AS NumeroContrato,
			C.NUMERO_ADENDA_CONCATENADO				AS NumeroAdendaConcatenado,
			C.DESCRIPCION							AS Descripcion,      
			P.NOMBRE_COMERCIAL						AS NombreComercial,
			C.FECHA_INICIO_VIGENCIA					AS FechaInicioVigencia,
			C.FECHA_FIN_VIGENCIA					AS FechaFinVigencia,
			C.CODIGO_TIPO_SERVICIO					AS CodigoTipoServicio,
			C.CODIGO_TIPO_REQUERIMIENTO				AS CodigoTipoRequerimiento,
			C.CODIGO_TIPO_DOCUMENTO					AS CodigoTipoDocumento,
			C.CODIGO_ESTADO							AS CodigoEstadoContrato,
			C.CODIGO_ESTADO_EDICION					AS CodigoEstadoEdicion,	
			C.USUARIO_CREACION						AS UsuarioCreacionContrato,
			C.FECHA_CREACION						AS FechaCreacionContrato,
			C.USUARIO_MODIFICACION					AS UsuarioModificacionContrato,
			C.FECHA_MODIFICACION					AS FechaModificacion,
			C.MOTIVO_ELIMINACION					AS MotivoEliminacion
		
	FROM	CTR.CONTRATO C
	LEFT JOIN CTR.PROVEEDOR	P ON P.CODIGO_PROVEEDOR = C.CODIGO_PROVEEDOR
	WHERE	(C.CODIGO_UNIDAD_OPERATIVA				=		@CODIGO_UNIDAD_OPERATIVA		OR @CODIGO_UNIDAD_OPERATIVA IS NULL)
	AND		(C.NUMERO_CONTRATO						=		@NUMERO_CONTRATO			OR ISNULL(@NUMERO_CONTRATO,'') = '')
	AND		(C.DESCRIPCION							LIKE	'%' + @DESCRIPCION + '%'	OR ISNULL(@DESCRIPCION, '') = '')
	AND		(C.CODIGO_TIPO_SERVICIO					=		@CODIGO_TIPO_SERVICIO			OR ISNULL(@CODIGO_TIPO_SERVICIO,'') = '')
	AND		(C.CODIGO_TIPO_REQUERIMIENTO			=		@CODIGO_TIPO_REQUERIMIENTO		OR ISNULL(@CODIGO_TIPO_REQUERIMIENTO,'') = '')							  	
	AND		(C.CODIGO_TIPO_DOCUMENTO				=		@CODIGO_TIPO_DOCUMENTO			OR ISNULL(@CODIGO_TIPO_DOCUMENTO,'') = '')							  	
	AND		(C.CODIGO_ESTADO						=		@CODIGO_ESTADO					OR ISNULL(@CODIGO_ESTADO,'') = '')	
	AND		(C.FECHA_INICIO_VIGENCIA				>=		@FECHA_INICIO_VIGENCIA OR @FECHA_INICIO_VIGENCIA IS NULL) 
	AND		(C.FECHA_FIN_VIGENCIA					<=		@FECHA_FIN_VIGENCIA OR @FECHA_FIN_VIGENCIA IS NULL)
	AND		(C.ESTADO_REGISTRO = '0' AND C.MOTIVO_ELIMINACION IS NOT NULL)

	ORDER BY C.FECHA_CREACION, C.CODIGO_UNIDAD_OPERATIVA, C.DESCRIPCION DESC
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_ELIMINAR_UPD]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_ELIMINAR_UPD]
(
	@CODIGO_CONTRATO UNIQUEIDENTIFIER,	
	@MOTIVO_ELIMINACION NVARCHAR(MAX),
	@USUARIO_MODIFICACION NVARCHAR(50),
	@TERMINAL_MODIFICACION NVARCHAR(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_ELIMINAR_UPD
Propósito:   Permite eliminar un registro de un contrato  
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier que representa codigo contrato.	
		@MOTIVO_ELIMINACION: Parámetro de entrada de tipo nvarchar que representa el motivo de eliminación.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creación.
		@FECHA_MODIFICACION:	Parámetro de entrada de tipo datetime, que representa fecha creación.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creación.	
Creado por: GMD
Fecha. Creación: 2017-06-26
Fecha. Actualización: 			   
**********************************************************************************************************************************/
BEGIN
	UPDATE CTR.CONTRATO
	SET		
		MOTIVO_ELIMINACION = @MOTIVO_ELIMINACION,
		USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
		FECHA_MODIFICACION = GETDATE(),
		TERMINAL_MODIFICACION = @TERMINAL_MODIFICACION,
		ESTADO_REGISTRO = '0'	
	WHERE CODIGO_CONTRATO = @CODIGO_CONTRATO

END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_ESTADIO_INS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_ESTADIO_INS]
@CODIGO_CONTRATO_ESTADIO UNIQUEIDENTIFIER,
@CODIGO_CONTRATO UNIQUEIDENTIFIER,
@CODIGO_FLUJO_APROBACION_ESTADIO UNIQUEIDENTIFIER,
@FECHA_INGRESO DATETIME,
@FECHA_FINALIZACION DATETIME,
@CODIGO_RESPONSABLE UNIQUEIDENTIFIER,
@CODIGO_ESTADO_CONTRATO_ESTADIO NVARCHAR(5),
@FECHA_PRIMERA_NOTIFICACION DATETIME,
@FECHA_ULTIMA_NOTIFICACION DATETIME,
@ESTADO_REGISTRO CHAR(1),
@USUARIO_CREACION NVARCHAR(50),
@FECHA_CREACION DATETIME,
@TERMINAL_CREACION NVARCHAR(50)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_ESTADIO_INS
Propósito:  Inserta y actualiza registros en la tabla Contrato documento 
Descripción de Parámetros: 
		@CODIGO_CONTRATO_ESTADIO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio.
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
		@CODIGO_FLUJO_APROBACION_ESTADIO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.
		@FECHA_INGRESO:	Parámetro de entrada de tipo datetime, que representa fecha ingreso.
		@FECHA_FINALIZACION:	Parámetro de entrada de tipo datetime, que representa fecha finalizacion.
		@CODIGO_RESPONSABLE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo responsable.
		@CODIGO_ESTADO_CONTRATO_ESTADIO:	Parámetro de entrada de tipo nvarchar, que representa codigo estado contrato estadio.
		@FECHA_PRIMERA_NOTIFICACION:	Parámetro de entrada de tipo datetime, que representa fecha primera notificacion.
		@FECHA_ULTIMA_NOTIFICACION:	Parámetro de entrada de tipo datetime, que representa fecha ultima notificacion.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@FECHA_CREACION:	Parámetro de entrada de tipo datetime, que representa fecha creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN 
	INSERT INTO CTR.CONTRATO_ESTADIO
	(
		CODIGO_CONTRATO_ESTADIO ,
	    CODIGO_CONTRATO ,
	    CODIGO_FLUJO_APROBACION_ESTADIO ,
	    FECHA_INGRESO ,
	    FECHA_FINALIZACION ,
	    CODIGO_RESPONSABLE ,
	    CODIGO_ESTADO_CONTRATO_ESTADIO ,
	    FECHA_PRIMERA_NOTIFICACION ,
	    FECHA_ULTIMA_NOTIFICACION ,
	    ESTADO_REGISTRO ,
	    USUARIO_CREACION ,
	    FECHA_CREACION ,
	    TERMINAL_CREACION 
	)
	VALUES  
	( 
		@CODIGO_CONTRATO_ESTADIO,
		@CODIGO_CONTRATO,
		@CODIGO_FLUJO_APROBACION_ESTADIO,
		@FECHA_INGRESO ,
		@FECHA_FINALIZACION,
		@CODIGO_RESPONSABLE,
		@CODIGO_ESTADO_CONTRATO_ESTADIO,
		@FECHA_PRIMERA_NOTIFICACION,
		@FECHA_ULTIMA_NOTIFICACION,
		@ESTADO_REGISTRO,
		@USUARIO_CREACION,
		@FECHA_CREACION,
		@TERMINAL_CREACION
	)
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_ESTADIO_OBTENER_ESTADIO_EDICION]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_CONTRATO_ESTADIO_OBTENER_ESTADIO_EDICION]
(
	@CODIGO_CONTRATO UNIQUEIDENTIFIER,
	@CODIGO_FLUJO_APROBACION UNIQUEIDENTIFIER
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_ESTADIO_OBTENER_ESTADIO_EDICION
Propósito:   Obtiene el estadio de edición de un flujo de aprobación
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
		@CODIGO_FLUJO_APROBACION:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo de flujo de aprobación.
Creado por: GMD
Fecha. Creación: 2017-10-03
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	
	SELECT CODIGO_CONTRATO_ESTADIO 
	FROM CTR.CONTRATO_ESTADIO 
	WHERE CODIGO_CONTRATO = @CODIGO_CONTRATO
			AND CODIGO_FLUJO_APROBACION_ESTADIO = (
			SELECT CODIGO_FLUJO_APROBACION_ESTADIO FROM CTR.FLUJO_APROBACION_ESTADIO 
			WHERE CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION AND ORDEN = 1 AND ESTADO_REGISTRO  = '1')

END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_ESTADIO_OBTENER_RESPONSABLE_EDICION]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_CONTRATO_ESTADIO_OBTENER_RESPONSABLE_EDICION]
(
	@CODIGO_CONTRATO_ESTADIO UNIQUEIDENTIFIER,
	@CODIGO_ESTADIO_RETORNO UNIQUEIDENTIFIER,
	@CODIGO_RESPONSABLE UNIQUEIDENTIFIER
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_ESTADIO_OBTENER_RESPONSABLE_EDICION
Propósito:   Obtiene el estadio de edición de un flujo de aprobación
Descripción de Parámetros: 
		@CODIGO_CONTRATO_ESTADIO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio.
		@CODIGO_ESTADIO_RETORNO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo estadio retorno.
		@CODIGO_RESPONSABLE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato del responsable.
Creado por: GMD
Fecha. Creación: 2017-10-05
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	
	IF((SELECT ORDEN FROM CTR.FLUJO_APROBACION_ESTADIO WHERE CODIGO_FLUJO_APROBACION_ESTADIO = @CODIGO_ESTADIO_RETORNO) = 1)
	BEGIN
		SELECT @CODIGO_RESPONSABLE
	END
	ELSE
	BEGIN		
		SELECT CODIGO_RESPONSABLE FROM CTR.CONTRATO_ESTADIO WHERE CODIGO_CONTRATO_ESTADIO = @CODIGO_CONTRATO_ESTADIO
	END
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_ESTADIO_RESPONSABLE_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_ESTADIO_RESPONSABLE_SEL] --'9ae2b5fd-e713-4ba8-a699-37533d201cd0'
(
	@CODIGO_CONTRATO UNIQUEIDENTIFIER = NULL
)
AS

/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_ESTADIO_RESPONSABLE_SEL
Propósito:   Obtiene el listado de responsables por estadio
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
Creado por: GMD
Fecha. Creación: 2016-01-27
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN 

/*SE COMENTO YA QUE NO OBTENIA EL FLUJO DE APROBACION ACTUAL*/
/*
DECLARE @ORDEN_ACTUAL INT = (SELECT ORDEN FROM CTR.FLUJO_APROBACION_ESTADIO WHERE CODIGO_FLUJO_APROBACION_ESTADIO = (SELECT CODIGO_ESTADIO_ACTUAL FROM CTR.CONTRATO WHERE CODIGO_CONTRATO = @CODIGO_CONTRATO))

	SELECT DISTINCT CODIGO_FLUJO_APROBACION_ESTADIO
	INTO #LISTA_CODIGO_FLUJO_APROBACION_ESTADIO
	FROM CTR.FLUJO_APROBACION_ESTADIO 
	WHERE ORDEN < @ORDEN_ACTUAL

	DROP TABLE #LISTA_CODIGO_FLUJO_APROBACION_ESTADIO
*/
/*INICIO SE AGREGO*/
DECLARE @ORDEN_ACTUAL INT, @CODIGO_FLUJO_APROBACION UNIQUEIDENTIFIER

SELECT @ORDEN_ACTUAL = ORDEN
	 , @CODIGO_FLUJO_APROBACION = CODIGO_FLUJO_APROBACION
FROM CTR.FLUJO_APROBACION_ESTADIO 
WHERE CODIGO_FLUJO_APROBACION_ESTADIO = (SELECT CODIGO_ESTADIO_ACTUAL FROM CTR.CONTRATO WHERE CODIGO_CONTRATO = @CODIGO_CONTRATO)

SELECT DISTINCT CODIGO_FLUJO_APROBACION_ESTADIO
	INTO #LISTA_CODIGO_FLUJO_APROBACION_ESTADIO
FROM CTR.FLUJO_APROBACION_ESTADIO 
WHERE CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION AND ORDEN < @ORDEN_ACTUAL
/*FIN SE AGREGO*/
SELECT * FROM
(
	SELECT 
		ROW_NUMBER() OVER
		(PARTITION BY CODIGO_RESPONSABLE ORDER BY FECHA_FINALIZACION ASC) as num
	  ,C.[CODIGO_CONTRATO_ESTADIO] as CodigoContratoEstadio
      ,C.[CODIGO_CONTRATO] as CodigoContrato
      ,C.[CODIGO_FLUJO_APROBACION_ESTADIO] as CodigoFlujoAprobacionEstadio
      ,C.[FECHA_INGRESO] as FechaIngreso
      ,C.[FECHA_FINALIZACION] as FechaFinalizacion
      ,C.[CODIGO_RESPONSABLE] AS CodigoResponsable
      ,C.[CODIGO_ESTADO_CONTRATO_ESTADIO] AS CodigoEstadoContratoEstadio
      ,C.[FECHA_PRIMERA_NOTIFICACION] AS FechaPrimeraNotificacion
      ,C.[FECHA_ULTIMA_NOTIFICACION] AS FechaUltimaNotificacion
  FROM [CTR].[CONTRATO_ESTADIO] C
  INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FAE ON FAE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_FLUJO_APROBACION_ESTADIO
  WHERE CODIGO_CONTRATO = @CODIGO_CONTRATO AND FAE.INDICADOR_INCLUIR_VISTO = 1 AND C.ESTADO_REGISTRO = 1 AND CODIGO_ESTADO_CONTRATO_ESTADIO = 'A'
  AND C.CODIGO_FLUJO_APROBACION_ESTADIO IN (SELECT CODIGO_FLUJO_APROBACION_ESTADIO FROM #LISTA_CODIGO_FLUJO_APROBACION_ESTADIO)
)a
	WHERE a.num = 1
	ORDER BY FechaFinalizacion ASC

END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_ESTADIO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_ESTADIO_SEL]
(
	@CODIGO_CONTRATO_ESTADIO UNIQUEIDENTIFIER = NULL,
	@CODIGO_CONTRATO UNIQUEIDENTIFIER = NULL,
	@CODIGO_FLUJO_APROBACION_ESTADIO UNIQUEIDENTIFIER = NULL,
	@FECHA_INGRESO DATETIME = NULL,
	@FECHA_FINALIZACION DATETIME = NULL,
	@CODIGO_RESPONSABLE UNIQUEIDENTIFIER= NULL,
	@CODIGO_ESTADO_CONTRATO_ESTADIO NVARCHAR(5)= NULL,
	@FECHA_PRIMERA_NOTIFICACION DATETIME= NULL,
	@FECHA_ULTIMA_NOTIFICACION DATETIME= NULL,
	@PageNo		INT = 1,
	@PageSize	INT = -1
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_ESTADIO_SEL
Propósito:   Obtiene el listado del contrato de estadio  
Descripción de Parámetros: 
		@CODIGO_CONTRATO_ESTADIO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio.
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
		@CODIGO_FLUJO_APROBACION_ESTADIO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.
		@FECHA_INGRESO:	Parámetro de entrada de tipo datetime, que representa fecha ingreso.
		@FECHA_FINALIZACION:	Parámetro de entrada de tipo datetime, que representa fecha finalizacion.
		@CODIGO_RESPONSABLE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo responsable.
		@CODIGO_ESTADO_CONTRATO_ESTADIO:	Parámetro de entrada de tipo nvarchar, que representa codigo estado contrato estadio.
		@FECHA_PRIMERA_NOTIFICACION:	Parámetro de entrada de tipo datetime, que representa fecha primera notificacion.
		@FECHA_ULTIMA_NOTIFICACION:	Parámetro de entrada de tipo datetime, que representa fecha ultima notificacion.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN 

DECLARE @lPageNbr	INT,
			@lPageSize	INT,
			@lFirstRec	INT,
			@lLAStRec	INT

	SET @lPageNbr = @PageNo
	SET @lPageSize = @PageSize

	SET @lFirstRec = (@lPageNbr - 1) * @lPageSize
	SET @lLAStRec = (@lPageNbr * @lPageSize + 1);

	
	WITH	CTE_Results AS (SELECT ROW_NUMBER() OVER (ORDER BY FECHA_FINALIZACION DESC) AS RowNumber,
			COUNT(CODIGO_CONTRATO_ESTADIO) OVER() AS RowsTotal,
			CONVERT(VARCHAR, COUNT(CODIGO_CONTRATO_ESTADIO) OVER())			AS RowId,
			CODIGO_CONTRATO_ESTADIO						AS CodigoContratoEstadio,
			CODIGO_CONTRATO								AS CodigoContrato,
			CODIGO_FLUJO_APROBACION_ESTADIO				AS CodigoFlujoAprobacionEstadio,
			FECHA_INGRESO								AS FechaIngreso,
			FECHA_FINALIZACION							AS FechaFinalizacion,
			CODIGO_RESPONSABLE		AS CodigoResponsable,
			CODIGO_ESTADO_CONTRATO_ESTADIO				AS CodigoEstadoContratoEstadio,
			FECHA_PRIMERA_NOTIFICACION					AS FechaPrimeraNotificacion,
			FECHA_ULTIMA_NOTIFICACION					AS FechaUltimaNotificacion
	FROM	CTR.CONTRATO_ESTADIO (NOLOCK)
	WHERE	(CODIGO_CONTRATO_ESTADIO =	@CODIGO_CONTRATO_ESTADIO OR  	@CODIGO_CONTRATO_ESTADIO IS NULL)
		AND		(CODIGO_CONTRATO	 =	@CODIGO_CONTRATO OR @CODIGO_CONTRATO IS NULL)	
		AND		(CODIGO_FLUJO_APROBACION_ESTADIO	=	@CODIGO_FLUJO_APROBACION_ESTADIO OR @CODIGO_FLUJO_APROBACION_ESTADIO IS  NULL )	
		AND		(FECHA_INGRESO			=		@FECHA_INGRESO		OR @FECHA_INGRESO IS NULL)
		AND		(FECHA_FINALIZACION	=		@FECHA_FINALIZACION	OR @FECHA_FINALIZACION IS NULL)
		AND		(CODIGO_RESPONSABLE	=		@CODIGO_RESPONSABLE	OR @CODIGO_RESPONSABLE IS NULL)
		AND		(CODIGO_ESTADO_CONTRATO_ESTADIO			=		@CODIGO_ESTADO_CONTRATO_ESTADIO		OR @CODIGO_ESTADO_CONTRATO_ESTADIO IS NULL)
		AND		(FECHA_PRIMERA_NOTIFICACION				=		@FECHA_PRIMERA_NOTIFICACION	OR @FECHA_PRIMERA_NOTIFICACION IS NULL)
		AND		(FECHA_ULTIMA_NOTIFICACION				=		@FECHA_ULTIMA_NOTIFICACION		OR @FECHA_ULTIMA_NOTIFICACION IS NULL )
		AND		(ESTADO_REGISTRO = '1')
	)

	SELECT	RowNumber,
			RowsTotal,
			RowId,
			CodigoContratoEstadio,
			CodigoContrato,
			CodigoFlujoAprobacionEstadio,
			FechaIngreso,
			FechaFinalizacion,
			CodigoResponsable,
			CodigoEstadoContratoEstadio,
			FechaPrimeraNotificacion,
			FechaUltimaNotificacion						
	FROM    CTE_Results
	WHERE   @PageSize < 0 OR ( RowNumber > @lFirstRec AND RowNumber < @lLAStRec) 
END


GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_ESTADO_UPD]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [CTR].[USP_CONTRATO_ESTADO_UPD]
(@USUARIO_MODIFICACION VARCHAR(50),
@TERMINAL_MODIFICACION VARCHAR(50))
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_ESTADO_UPD
Propósito:  Verifica y actualiza el codigo_estado de los registros de acuerdo a la fecha actual. 
Descripción de Parámetros: 
		@FECHA_ACTUAL:	Fecha actual del registro.
Creado por: GMD
Fecha. Creación: 2016-06-16
Fecha. Actualización: 2017-11-14 Corrección para que condición de fecha de fin de vigencia sea mayor a fecha actual para actualizar estado de contrato a Vencido
Fecha. Actualización: 2018-08-02 Se Actualiza estado a "C" = Vencido si el estado NO ES EDICION, REVISION, VENCIDO Y RESUELTO
**********************************************************************************************************************************/
BEGIN

DECLARE @FECHA_ACTUAL DATE = GETDATE()

UPDATE CTR.CONTRATO SET
CODIGO_ESTADO = 'C',
USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
TERMINAL_MODIFICACION = @TERMINAL_MODIFICACION
WHERE  CODIGO_CONTRATO IN (
  SELECT [CODIGO_CONTRATO]
  FROM [CTR].[CONTRATO]
  where ((FECHA_FIN_VIGENCIA < @FECHA_ACTUAL)) AND (CODIGO_ESTADO NOT IN ('E','A','C','RS'))--'V'
  AND ESTADO_REGISTRO = '1')
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_FIRMANTE_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_FIRMANTE_SEL] --'75c276ce-ee68-41d3-81d8-a1899fe56588'
@CODIGO_CONTRATO uniqueidentifier
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_FIRMANTE_SEL
Propósito:  Retorna los firmantes de los párrafos de un contrato. 
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
Creado por: GMD
Fecha. Creación: 2015-10-20
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

SELECT 
	[CODIGO_CONTRATO_PARRAFO]
	INTO #TMP_CODIGO_CONTRATO_PARRAFO
	FROM [CTR].[CONTRATO_PARRAFO]
	WHERE [CODIGO_CONTRATO] = @CODIGO_CONTRATO

SELECT 
	[CODIGO_CONTRATO_PARRAFO_VARIABLE]
	INTO #TMP_CODIGO_CONTRATO_PARRAFO_VARIABLE
	FROM [CTR].[CONTRATO_PARRAFO_VARIABLE]
	WHERE [CODIGO_CONTRATO_PARRAFO] IN (SELECT TBL_PARRAFO.[CODIGO_CONTRATO_PARRAFO] FROM #TMP_CODIGO_CONTRATO_PARRAFO TBL_PARRAFO)

SELECT 
		CONTRATO_FIRMANTE.[CODIGO_CONTRATO_FIRMANTE]					AS CodigoContratoFirmante,
		CONTRATO_FIRMANTE.[CODIGO_CONTRATO_PARRAFO_VARIABLE]			AS CodigoContratoParrafoVariable,
		CONTRATO_FIRMANTE.[NOMBRE_FIRMANTE]								AS NombreFirmante,
		CONTRATO_FIRMANTE.[DATO_ADICIONAL]								AS DatoAdicional,
		CONTRATO_FIRMANTE.[ESTADO_REGISTRO]								AS EstadoRegistro
FROM [CTR].[CONTRATO_FIRMANTE] CONTRATO_FIRMANTE (NOLOCK)
INNER JOIN [CTR].[CONTRATO_PARRAFO_VARIABLE] CONTRATO_PARRAFO_VARIABLE ON CONTRATO_FIRMANTE.CODIGO_CONTRATO_PARRAFO_VARIABLE = CONTRATO_PARRAFO_VARIABLE.CODIGO_CONTRATO_PARRAFO_VARIABLE AND CONTRATO_PARRAFO_VARIABLE.ESTADO_REGISTRO = '1'
INNER JOIN [CTR].[CONTRATO_PARRAFO] CONTRATO_PARRAFO ON CONTRATO_PARRAFO_VARIABLE.CODIGO_CONTRATO_PARRAFO = CONTRATO_PARRAFO.CODIGO_CONTRATO_PARRAFO AND CONTRATO_PARRAFO.ESTADO_REGISTRO = '1'
WHERE CONTRATO_FIRMANTE.[CODIGO_CONTRATO_PARRAFO_VARIABLE] IN (SELECT TBL_PARRAFO_VARIABLE.[CODIGO_CONTRATO_PARRAFO_VARIABLE] FROM #TMP_CODIGO_CONTRATO_PARRAFO_VARIABLE TBL_PARRAFO_VARIABLE)
AND CONTRATO_FIRMANTE.ESTADO_REGISTRO='1'
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_INS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---ALTER TABLE [CTR].[CONTRATO] ALTER COLUMN [CODIGO_TIPO_REQUERIMIENTO] [nvarchar] (15) COLLATE Modern_Spanish_CI_AS NULL

CREATE PROCEDURE [CTR].[USP_CONTRATO_INS]
@CODIGO_CONTRATO UNIQUEIDENTIFIER,
@CODIGO_UNIDAD_OPERATIVA UNIQUEIDENTIFIER,
@CODIGO_PROVEEDOR UNIQUEIDENTIFIER,
@NUMERO_CONTRATO NVARCHAR(50),
@DESCRIPCION NVARCHAR(255),
@NUMERO_ADENDA NVARCHAR(15),
@NUMERO_ADENDA_CONCATENADO NVARCHAR(80),
@CODIGO_TIPO_SERVICIO NVARCHAR(5),
@CODIGO_TIPO_REQUERIMIENTO NVARCHAR(15),
@CODIGO_TIPO_DOCUMENTO NVARCHAR(5),
@INDICADOR_VERSION_OFICIAL BIT,
@FECHA_INICIO_VIGENCIA DATETIME,
@FECHA_FIN_VIGENCIA DATETIME,
@CODIGO_MONEDA CHAR(3),
@MONTO_CONTRATO DECIMAL,
@MONTO_ACUMULADO DECIMAL,
@CODIGO_ESTADO NVARCHAR(5),
@CODIGO_PLANTILLA UNIQUEIDENTIFIER,
@CODIGO_CONTRATO_PRINCIPAL UNIQUEIDENTIFIER,
@CODIGO_ESTADO_EDICION NVARCHAR(5),
@COMENTARIO_MODIFICACION VARCHAR(MAX),
@RESPUESTA_MODIFICACION NVARCHAR(MAX),
@CODIGO_FLUJO_APROBACION UNIQUEIDENTIFIER,
@CODIGO_ESTADIO_ACTUAL UNIQUEIDENTIFIER,
@ESTADO_REGISTRO CHAR(1),
@USUARIO_CREACION NVARCHAR(50),
@FECHA_CREACION DATETIME,
@TERMINAL_CREACION NVARCHAR(50),
@ES_FLEXIBLE BIT,
@ES_CORPORATIVO BIT = 0,
@CODIGO_CONTRATO_ORIGINAL UNIQUEIDENTIFIER,
@CODIGOREQUERIDO UNIQUEIDENTIFIER
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_INS
Propósito:  Inserta y actualiza registros en la tabla Contrato 
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
		@CODIGO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@CODIGO_PROVEEDOR:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo proveedor.
		@NUMERO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa numero contrato.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
		@NUMERO_ADENDA:	Parámetro de entrada de tipo nvarchar, que representa número de adenda.
		@NUMERO_ADENDA_CONCATENADO:	Parámetro de entrada de tipo nvarchar, que representa número de adenda concatenado.
		@CODIGO_TIPO_SERVICIO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo contrato.
		@CODIGO_TIPO_REQUERIMIENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo servicio.		
		@CODIGO_TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.
		@INDICADOR_VERSION_OFICIAL:	Parámetro de entrada de tipo bit, que representa indicador version oficial.
		@FECHA_INICIO_VIGENCIA:	Parámetro de entrada de tipo datetime, que representa fecha inicio vigencia.
		@FECHA_FIN_VIGENCIA:	Parámetro de entrada de tipo datetime, que representa fecha fin vigencia.
		@CODIGO_MONEDA:	Parámetro de entrada de tipo char, que representa codigo moneda.
		@MONTO_CONTRATO:	Parámetro de entrada de tipo decimal, que representa monto contrato.
		@MONTO_ACUMULADO:	Parámetro de entrada de tipo decimal, que representa monto acumulado.
		@CODIGO_ESTADO:	Parámetro de entrada de tipo nvarchar, que representa codigo estado.
		@CODIGO_PLANTILLA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla.
		@CODIGO_CONTRATO_PRINCIPAL:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato principal.
		@CODIGO_ESTADO_EDICION:	Parámetro de entrada de tipo nvarchar, que representa codigo estado edicion.
		@COMENTARIO_MODIFICACION:	Parámetro de entrada de tipo varchar, que representa comentario modificacion.
		@RESPUESTA_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa respuesta modificacion.
		@CODIGO_FLUJO_APROBACION:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.
		@CODIGO_ESTADIO_ACTUAL:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo estadio actual.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@FECHA_CREACION:	Parámetro de entrada de tipo datetime, que representa fecha creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
		@ES_FLEXIBLE: Parámetro de entrada de tipo bit, que representa si el contrato es flexible.
		@ES_CORPORATIVO: Parámetro de entrada de tipo bit, que representa si el contrato es corporativo.
		@CODIGO_CONTRATO_ORIGINAL Parámetro de entrada de tipo uniqueidentifier, que representa el código del contrato original cuando se registra una copia del contrato.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 2016-01-10 Se agrega parametro @ES_FLEXIBLE
					  2016-06-23 Se agrega parametro @ES_CORPORATIVO
					  2016-07-02 Se agrega parametro @CODIGO_CONTRATO_ORIGINAL 
**********************************************************************************************************************************/
BEGIN
	INSERT INTO CTR.CONTRATO
	(
		CODIGO_CONTRATO ,
		CODIGO_UNIDAD_OPERATIVA ,
		CODIGO_PROVEEDOR ,
		NUMERO_CONTRATO ,
		DESCRIPCION ,
		NUMERO_ADENDA,
		NUMERO_ADENDA_CONCATENADO,
		CODIGO_TIPO_SERVICIO ,
		CODIGO_TIPO_REQUERIMIENTO ,
		CODIGO_TIPO_DOCUMENTO ,
		INDICADOR_VERSION_OFICIAL,
		FECHA_INICIO_VIGENCIA ,
		FECHA_FIN_VIGENCIA,
		CODIGO_MONEDA,
		MONTO_CONTRATO,
		MONTO_ACUMULADO,
		CODIGO_ESTADO,
		CODIGO_PLANTILLA,
		CODIGO_CONTRATO_PRINCIPAL,
		CODIGO_ESTADO_EDICION,
		COMENTARIO_MODIFICACION,
		RESPUESTA_MODIFICACION,
		CODIGO_FLUJO_APROBACION,
		CODIGO_ESTADIO_ACTUAL,
		ESTADO_REGISTRO,
		USUARIO_CREACION,
		FECHA_CREACION,
		TERMINAL_CREACION,
		ES_FLEXIBLE,
		ES_CORPORATIVO,
		CODIGO_CONTRATO_ORIGINAL,
		CODIGOREQUERIDO
	)
	VALUES
	(	
		@CODIGO_CONTRATO ,
		@CODIGO_UNIDAD_OPERATIVA ,
		@CODIGO_PROVEEDOR ,
		@NUMERO_CONTRATO ,
		@DESCRIPCION ,
		@NUMERO_ADENDA,
		@NUMERO_ADENDA_CONCATENADO,		
		@CODIGO_TIPO_SERVICIO,
		@CODIGO_TIPO_REQUERIMIENTO ,
		@CODIGO_TIPO_DOCUMENTO ,
		@INDICADOR_VERSION_OFICIAL,
		@FECHA_INICIO_VIGENCIA ,
		@FECHA_FIN_VIGENCIA,
		@CODIGO_MONEDA,
		@MONTO_CONTRATO,
		@MONTO_ACUMULADO,
		@CODIGO_ESTADO,
		@CODIGO_PLANTILLA,
		@CODIGO_CONTRATO_PRINCIPAL,
		@CODIGO_ESTADO_EDICION,
		@COMENTARIO_MODIFICACION,
		@RESPUESTA_MODIFICACION,
		@CODIGO_FLUJO_APROBACION,
		@CODIGO_ESTADIO_ACTUAL,
		@ESTADO_REGISTRO,
		@USUARIO_CREACION,
		@FECHA_CREACION,
		@TERMINAL_CREACION,
		@ES_FLEXIBLE,
		@ES_CORPORATIVO,
		@CODIGO_CONTRATO_ORIGINAL,
		@CODIGOREQUERIDO
	)
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_NOT_NUMBERED_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_NOT_NUMBERED_SEL]
(
	@CODIGO_CONTRATO			UNIQUEIDENTIFIER,
	@CODIGO_CONTRATO_PRINCIPAL	UNIQUEIDENTIFIER,
	@CODIGO_TIPO_SERVICIO		NVARCHAR(5),
	@CODIGO_TIPO_REQUERIMIENTO	NVARCHAR(5),
	@CODIGO_TIPO_DOCUMENTO		NVARCHAR(5),
	@CODIGO_ESTADO				NVARCHAR(5),
	@NUMERO_CONTRATO			NVARCHAR(50),
	@NUMERO_DOCUMENTO			NVARCHAR(20),
	@NOMBRE_PROVEEDOR			NVARCHAR(255),
	@DESCRIPCION				NVARCHAR(255)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_NOT_NUMBERED_SEL
Propósito:   Obtiene el listado del contrato sin paginación  
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
		@CODIGO_TIPO_SERVICIO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo contrato.
		@CODIGO_TIPO_REQUERIMIENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo servicio.
		@CODIGO_TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.
		@CODIGO_ESTADO:	Parámetro de entrada de tipo nvarchar, que representa codigo estado.
		@NUMERO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa numero contrato.
		@NUMERO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa numero documento.
		@NOMBRE_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa nombre proveedor.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

SELECT
        C.CODIGO_CONTRATO						AS	CodigoContrato,
        C.CODIGO_UNIDAD_OPERATIVA				AS	CodigoUnidadOperativa,
        C.CODIGO_PROVEEDOR						AS	CodigoProveedor,
		C.NUMERO_CONTRATO						AS	NumeroContrato,
		C.NUMERO_ADENDA							AS	NumeroAdenda,
		C.DESCRIPCION							AS	Descripcion,
		C.CODIGO_TIPO_REQUERIMIENTO				AS	CodigoTipoRequerimiento,
		C.CODIGO_TIPO_SERVICIO					AS	CodigoTipoServicio,
		C.CODIGO_TIPO_DOCUMENTO					AS	CodigoTipoDocumento,
        C.FECHA_INICIO_VIGENCIA					AS	FechaInicioVigencia,
		C.FECHA_FIN_VIGENCIA					AS	FechaFinVigencia,
		C.CODIGO_MONEDA							AS	CodigoMoneda,
		C.MONTO_CONTRATO						AS	MontoContrato,
		C.CODIGO_ESTADO							AS	CodigoEstadoContrato,
		C.CODIGO_PLANTILLA						AS	CodigoPlantilla,
		C.CODIGO_CONTRATO_PRINCIPAL				AS	CodigoContratoPrincipal,
		C.CODIGO_ESTADO_EDICION					AS	CodigoEstadoEdicion,
		C.COMENTARIO_MODIFICACION				AS	ComentarioModificacion,
		C.RESPUESTA_MODIFICACION				AS	RespuestaModificacion,
		C.CODIGO_ESTADIO_ACTUAL					AS	CodigoEstadioActual,
		c.NUMERO_ADENDA_CONCATENADO				AS	NumeroAdendaConcatenado,
		C.ESTADO_REGISTRO						AS	EstadoRegistro
FROM	CTR.CONTRATO C
WHERE	(C.CODIGO_CONTRATO						=		@CODIGO_CONTRATO				OR @CODIGO_CONTRATO IS NULL)
AND		(C.CODIGO_CONTRATO_PRINCIPAL			=		@CODIGO_CONTRATO_PRINCIPAL		OR @CODIGO_CONTRATO_PRINCIPAL IS NULL)
AND		(C.CODIGO_TIPO_SERVICIO					=		@CODIGO_TIPO_SERVICIO			OR ISNULL(@CODIGO_TIPO_SERVICIO,'') = '')							  	
AND		(C.CODIGO_TIPO_REQUERIMIENTO			=		@CODIGO_TIPO_REQUERIMIENTO		OR ISNULL(@CODIGO_TIPO_REQUERIMIENTO,'') = '')
AND		(C.CODIGO_TIPO_DOCUMENTO				=		@CODIGO_TIPO_DOCUMENTO			OR ISNULL(@CODIGO_TIPO_DOCUMENTO,'') = '')							  	
AND		(C.CODIGO_ESTADO						=		@CODIGO_ESTADO					OR ISNULL(@CODIGO_ESTADO,'') = '')							  	
AND		(C.NUMERO_CONTRATO						=		@NUMERO_CONTRATO				OR ISNULL(@NUMERO_CONTRATO,'') = '')							  	
AND		(C.DESCRIPCION							LIKE	'%' + @DESCRIPCION + '%'	OR ISNULL(@DESCRIPCION, '') = '')
AND		(C.ESTADO_REGISTRO = '1')
      
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_OBSERVACIONES_APROBADAS_RPT]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_OBSERVACIONES_APROBADAS_RPT]
@CODIGO_UNIDAD_OPERATIVA	NVARCHAR(50),
@CODIGO_CONTRATO			NVARCHAR(50),
@TIPO_ACCION_CONTRATO		NVARCHAR(50),
@FECHA_INICIO				DATETIME,
@FECHA_FIN					DATETIME,
@NAME_DATABASE				NVARCHAR(500),
@PageNo						INT		=  1,
@PageSize					BIGINT	= 42121
AS 
--exec CTR.USP_CONTRATO_OBSERVACIONES_APROBADAS_RPT NULL,NULL,NULL,'2018-09-01 00:00:00.000','2018-09-25 00:00:00.000','STRACON_POLITICAS_SGC_DEV',0,10
BEGIN

DECLARE @Query NVARCHAR(MAX)

SET @Query = N'
WITH CTE AS (SELECT 
A.CODIGO_CONTRATO AS CodigoContrato,
A.CODIGO_UNIDAD_OPERATIVA AS CodigoUnidadOperativa,
UO.NOMBRE AS NombreUnidadOperativa,
A.NUMERO_CONTRATO AS NumeroContrato,
ISNULL(A.NUMERO_ADENDA_CONCATENADO,'''') AS NumeroAdenda,
A.DESCRIPCION AS DescripcionContrato,
A.FECHA_INICIO_VIGENCIA AS FechaInicioVigencia,
A.FECHA_FIN_VIGENCIA AS FechaFinVigencia,
A.MONTO_CONTRATO AS MontoContrato,
''Observado'' AS TipoAccion,
C.DESCRIPCION AS Comentario,
C.USUARIO_CREACION AS AccionPor,
C.FECHA_REGISTRO AS FechaAccion,
C.FECHA_CREACION AS FechaCreacionObs,
C.RESPUESTA AS Respuesta,
C.FECHA_RESPUESTA AS FechaRespuesta,
C.USUARIO_MODIFICACION AS UsuarioRespuesta
FROM CTR.CONTRATO A INNER JOIN ' + @NAME_DATABASE + '.GRL.UNIDAD_OPERATIVA  UO ON UO.CODIGO_UNIDAD_OPERATIVA=A.CODIGO_UNIDAD_OPERATIVA
INNER JOIN CTR.CONTRATO_ESTADIO	B ON A.CODIGO_CONTRATO=B.CODIGO_CONTRATO
INNER JOIN CTR.CONTRATO_ESTADIO_OBSERVACION	C ON B.CODIGO_CONTRATO_ESTADIO=C.CODIGO_CONTRATO_ESTADIO AND B.codigo_flujo_aprobacion_estadio=C.codigo_estadio_retorno
WHERE (A.CODIGO_UNIDAD_OPERATIVA=case when ISNULL(@CODIGO_UNIDAD_OPERATIVA,'''')='''' then  A.CODIGO_UNIDAD_OPERATIVA else @CODIGO_UNIDAD_OPERATIVA end )
AND (A.CODIGO_CONTRATO=case when ISNULL(@CODIGO_CONTRATO,'''')='''' then A.CODIGO_CONTRATO else @CODIGO_CONTRATO end)
AND (ISNULL(@TIPO_ACCION_CONTRATO,'''')='''' OR ''1''=@TIPO_ACCION_CONTRATO)
AND	CAST(C.FECHA_REGISTRO AS DATE)BETWEEN ISNULL(@FECHA_INICIO,''40000101'') and ISNULL(@FECHA_FIN,''40000101'')
AND A.ESTADO_REGISTRO=''1'' AND B.ESTADO_REGISTRO=''1'' AND C.ESTADO_REGISTRO=''1''
UNION ALL SELECT 
A.CODIGO_CONTRATO AS CodigoContrato,
A.CODIGO_UNIDAD_OPERATIVA As CodigoUnidadOperativa,
UO.NOMBRE AS NombreUnidadOperativa,
A.NUMERO_CONTRATO AS NumeroContrato,
ISNULL(A.NUMERO_ADENDA_CONCATENADO,'''') AS NumeroAdenda,
A.DESCRIPCION AS DescripcionContrato,
A.FECHA_INICIO_VIGENCIA	AS FechaInicioVigencia,
A.FECHA_FIN_VIGENCIA AS FechaFinVigencia,
A.MONTO_CONTRATO AS MontoContrato,
''Aprobado'' AS TipoAccion,
B.MOTIVO_APROBACION COLLATE Modern_Spanish_CI_AS AS Comentario,
B.USUARIO_MODIFICACION AS AccionPor,
B.FECHA_FINALIZACION  AS FechaAccion,
'''' AS FechaCreacionObs,
'''' AS Respuesta,
'''' AS FechaRespuesta,
'''' AS UsuarioRespuesta
FROM CTR.CONTRATO A INNER JOIN ' + @NAME_DATABASE + '.GRL.UNIDAD_OPERATIVA UO ON UO.CODIGO_UNIDAD_OPERATIVA=A.CODIGO_UNIDAD_OPERATIVA
INNER JOIN CTR.CONTRATO_ESTADIO	B ON A.CODIGO_CONTRATO=B.CODIGO_CONTRATO AND ISNULL(B.MOTIVO_APROBACION,'''') <> ''''
WHERE (A.CODIGO_UNIDAD_OPERATIVA=case when ISNULL(@CODIGO_UNIDAD_OPERATIVA,'''')='''' then A.CODIGO_UNIDAD_OPERATIVA ELSE @CODIGO_UNIDAD_OPERATIVA END)
AND (A.CODIGO_CONTRATO=case when ISNULL(@CODIGO_CONTRATO,'''')='''' then  A.CODIGO_CONTRATO	ELSE @CODIGO_CONTRATO END)AND (ISNULL(@TIPO_ACCION_CONTRATO,'''')='''' OR ''2''=@TIPO_ACCION_CONTRATO)
AND	CAST(B.FECHA_FINALIZACION AS DATE)	BETWEEN	ISNULL(@FECHA_INICIO,''40000101'') and ISNULL(@FECHA_FIN,''40000101'')AND A.ESTADO_REGISTRO=''1'' AND B.ESTADO_REGISTRO =''1'')
SELECT 
CTE.CodigoContrato,
CTE.CodigoUnidadOperativa,
CTE.NombreUnidadOperativa,
CTE.NumeroContrato,
CTE.NumeroAdenda,
CTE.DescripcionContrato,
CTE.FechaInicioVigencia,	
CTE.FechaFinVigencia,
CTE.MontoContrato,
CTE.TipoAccion,
CTE.Comentario,
CTE.AccionPor,
isnull(CTE.FechaAccion,''1900-01-01'') as FechaAccion,
CTE.FechaCreacionObs,
CTE.Respuesta,
isnull(CTE.FechaRespuesta,''1900-01-01'') as FechaRespuesta,
CTE.UsuarioRespuesta,
TR1.NOMBRE_COMPLETO AS NomCompletoAccionPor,
TR.NOMBRE_COMPLETO AS NomCompletoUsuarioRes
FROM CTE
LEFT JOIN '+@NAME_DATABASE+'.GRL.TRABAJADOR TR  ON TR.CODIGO_IDENTIFICACION=CTE.UsuarioRespuesta COLLATE Modern_Spanish_CI_AS
LEFT JOIN '+@NAME_DATABASE+'.GRL.TRABAJADOR TR1 ON TR1.CODIGO_IDENTIFICACION=CTE.AccionPor COLLATE Modern_Spanish_CI_AS'

		BEGIN
			DECLARE @paramDef NVARCHAR(max) = N'
					@CODIGO_UNIDAD_OPERATIVA	NVARCHAR(50),
					@CODIGO_CONTRATO			NVARCHAR(50),
					@TIPO_ACCION_CONTRATO		NVARCHAR(50),
					@FECHA_INICIO				DATETIME,
					@FECHA_FIN					DATETIME,
					@NAME_DATABASE				NVARCHAR(500)'
			
			CREATE TABLE #TBL_RESULTADO
			(
				CodigoContrato						UNIQUEIDENTIFIER,
				CodigoUnidadOperativa				UNIQUEIDENTIFIER,
				NombreUnidadOperativa				NVARCHAR(MAX),
				NumeroContrato						NVARCHAR(MAX),
				NumeroAdenda						NVARCHAR(MAX),
				DescripcionContrato					NVARCHAR(MAX),
				FechaInicioVigencia					DATETIME,	
				FechaFinVigencia					DATETIME,
				MontoContrato						DECIMAL(12,2),
				TipoAccion							NVARCHAR(MAX),
				Comentario							NVARCHAR(MAX),
				AccionPor							NVARCHAR(MAX),
				FechaAccion							DATETIME,
				FechaCreacionObs					DATETIME,
				Respuesta							NVARCHAR(MAX),
				FechaRespuesta						DATETIME,
				UsuarioRespuesta					NVARCHAR(MAX),
				NombreCompletoAccionPor				NVARCHAR(MAX),
				NombreCompletoUsuarioRespuesta		NVARCHAR(MAX))

			INSERT INTO #TBL_RESULTADO
			EXEC sys.sp_executesql @Query,
					@paramDef,
					@CODIGO_UNIDAD_OPERATIVA,
					@CODIGO_CONTRATO		,
					@TIPO_ACCION_CONTRATO	,
					@FECHA_INICIO			,
					@FECHA_FIN				,
					@NAME_DATABASE;
			
			WITH CTE_FINAL AS (	SELECT
									CONVERT(BIGINT,ROW_NUMBER() OVER (ORDER BY FechaAccion DESC))		AS NumeroRegistro,
									CONVERT(BIGINT,COUNT(1) OVER())										AS TotalRegistro,
									CONVERT(VARCHAR,COUNT(*) OVER())									AS RowId,
									CodigoContrato,
									CodigoUnidadOperativa,
									NombreUnidadOperativa,
									NumeroContrato,
									NumeroAdenda,
									DescripcionContrato,
									FechaInicioVigencia,	
									FechaFinVigencia,
									MontoContrato,
									TipoAccion,
									Comentario,
									AccionPor,
									FechaAccion,
									FechaCreacionObs,
									Respuesta,
									FechaRespuesta,
									UsuarioRespuesta,
									NombreCompletoAccionPor,
									NombreCompletoUsuarioRespuesta
								FROM #TBL_RESULTADO)

			SELECT
				CTE_FINAL.NumeroRegistro,
				CTE_FINAL.TotalRegistro,
				CTE_FINAL.RowId,
				CTE_FINAL.CodigoContrato,
				CTE_FINAL.CodigoUnidadOperativa,
				CTE_FINAL.NombreUnidadOperativa,
				CTE_FINAL.NumeroContrato,
				CTE_FINAL.NumeroAdenda,
				CTE_FINAL.DescripcionContrato,
				CTE_FINAL.FechaInicioVigencia,	
				CTE_FINAL.FechaFinVigencia,
				CTE_FINAL.MontoContrato,
				CTE_FINAL.TipoAccion,
				CTE_FINAL.Comentario,
				CTE_FINAL.AccionPor,
				CTE_FINAL.FechaAccion,
				CTE_FINAL.FechaCreacionObs,
				CTE_FINAL.Respuesta,
				CTE_FINAL.FechaRespuesta,
				CTE_FINAL.UsuarioRespuesta,
				CTE_FINAL.NombreCompletoAccionPor,
				CTE_FINAL.NombreCompletoUsuarioRespuesta
				
			FROM CTE_FINAL
			WHERE (NumeroRegistro BETWEEN (@PageNo*@PageSize)+1 AND @PageSize*(@PageNo+1)) 
			ORDER BY NumeroRegistro ASC
		  END
  END
GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_OBTENER_MONTO_ACUMULADO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_CONTRATO_OBTENER_MONTO_ACUMULADO]
(
	@CODIGO_CONTRATO_PRINCIPAL	UNIQUEIDENTIFIER
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_OBTENER_MONTO_ACUMULADO
Propósito:   Obtiene el Monto Acumulado del Contrato Principal más sus Adendas 
Descripción de Parámetros: 
		@CODIGO_CONTRATO_PRINCIPAL:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato principal.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	SELECT	SUM(MONTO_CONTRATO) MontoAcumulado
	FROM	CTR.CONTRATO
	WHERE	(CODIGO_CONTRATO = @CODIGO_CONTRATO_PRINCIPAL OR (CODIGO_CONTRATO_PRINCIPAL = @CODIGO_CONTRATO_PRINCIPAL AND CODIGO_TIPO_DOCUMENTO = 'A'))
	AND		(ESTADO_REGISTRO = '1')
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_ORDENADO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_ORDENADO_SEL]
(@CODIGO_CONTRATO					UNIQUEIDENTIFIER,
@CODIGO_UNIDAD_OPERATIVA			UNIQUEIDENTIFIER,
@CODIGO_PLANTILLA					UNIQUEIDENTIFIER,
@CODIGO_TIPO_SERVICIO				NVARCHAR(5),
@CODIGO_TIPO_REQUERIMIENTO			NVARCHAR(6),
@CODIGO_TIPO_DOCUMENTO				NVARCHAR(5),
@CODIGO_ESTADO						NVARCHAR(5),
@NUMERO_CONTRATO					NVARCHAR(50),
@NUMERO_ADENDA_CONCATENADO			NVARCHAR(80),
@NUMERO_DOCUMENTO					NVARCHAR(20),
@NOMBRE_PROVEEDOR					NVARCHAR(255),
@DESCRIPCION						NVARCHAR(255),
@INDICADOR_TODA_UNIDAD_OPERATIVA	BIT,
@LISTA_UNIDAD_OPERATIVA_ACCESO		CTR.LISTA_GUID READONLY,
@CODIGO_ESTADO_EDICION				NVARCHAR(255),
@CONTENIDO_CONTRATO					NVARCHAR(MAX),
@CODIGO_TRABAJADOR_RESPONSABLE		UNIQUEIDENTIFIER,
@NOMBRE_ESTADIO						NVARCHAR(300),
@INDICADOR_FINALIZAR_APROBACION		NVARCHAR(10),
@MONTO_INICIO						DECIMAL(12,2),
@MONTO_FIN							DECIMAL(12,2),
@CODIGO_MONEDA						CHAR(3),
@USUARIO_CREACION					VARCHAR(100),
@COLUMNA_ORDEN                      VARCHAR(50),
@TIPO_ORDEN                         VARCHAR(50),
@NUMERO_PAGINA                      BIGINT =      0,
@TAMANIO_PAGINA                     BIGINT =      42121)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_SEL
Propósito:   Obtiene el listado del contrato  
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
		@CODIGO_UNIDAD_OPERATIVA: Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@CODIGO_PLANTILLA: Parámetro de entrada de tipo uniqueidentifier, que representa código de plantilla.
		@CODIGO_TIPO_SERVICIO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo servicio.
		@CODIGO_TIPO_REQUERIMIENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo requerimiento.
		@CODIGO_TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.
		@CODIGO_ESTADO:	Parámetro de entrada de tipo nvarchar, que representa codigo estado.
		@NUMERO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa numero contrato.
		@NUMERO_ADENDA_CONCATENADO:	Parámetro de entrada de tipo nvarchar, que representa numero de adenda concatenado.
		@NUMERO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa numero documento.
		@NOMBRE_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa nombre proveedor.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
		@INDICADOR_TODA_UNIDAD_OPERATIVA: Parámetro de entrada de tipo bit, que indica si el trabajadador puede acceder a todas las unidades operativas o no.
		@LISTA_UNIDAD_OPERATIVA_ACCESO Parámetro de entrada de tipo CTR.LISTA_GUID, que representa una lista de códigos de unidades operativas.
		@CODIGO_ESTADO_EDICION: Parámetro de entrada de tipo nvarchar, que representa un estado de edición.
		@DESCRIPCION_CONTRATO: Parámetro de entrada de tipo nvarchar, que representa la descripción del contrato.
		@CODIGO_TRABAJADOR_RESPONSABLE: Parámetro de entrada de tipo UNIQUEIDENTIFIER, que representa el Código de Trabajador Responsable.
		@NOMBRE_ESTADIO: Parámetro de entrada de tipo NVARCHAR, que representa el Nombre del Estadio.
		@INDICADOR_FINALIZAR_APROBACION: Parámetro de entrada de tipo NVARCHAR, que representa el Indicador de Finalizar Aprobación.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 2017-01-10 Se agrega retornar EsFlexible
       Actualización: 2017-11-27 Se agrega validación para obtener responsable para empresa vinculada
	   Actualización: ADEXUS 2018-10-09 Se modifica query para que ejecute en menor tiempo.
**********************************************************************************************************************************/
BEGIN

DECLARE @lPageNbr	INT, @lPageSize	INT, @lFirstRec	INT, @lLAStRec	INT

	IF(@CONTENIDO_CONTRATO IS NOT NULL)
		BEGIN
			SET @CONTENIDO_CONTRATO = '%' + @CONTENIDO_CONTRATO + '%'
		END

	IF @NOMBRE_ESTADIO IS NOT NULL
		BEGIN
			SET @NOMBRE_ESTADIO = '%' + @NOMBRE_ESTADIO + '%'		
		END

	DECLARE @TMP_ULTIMO_ESTADIO_CONTRATO CTR.LISTA_GUID
	DECLARE @ROW_NUMBER VARCHAR(250), @SENTENCIA NVARCHAR(MAX),@AGRUPADOS NVARCHAR(MAX) = '',@PERMISOS_UNIDAD_OPERATIVA NVARCHAR(MAX) = ''


	IF @INDICADOR_FINALIZAR_APROBACION = 'A' OR @INDICADOR_FINALIZAR_APROBACION = 'NA'
	BEGIN

		--INSERT INTO @TMP_ULTIMO_ESTADIO_CONTRATO
		SELECT	(SELECT TOP 1 FAE.CODIGO_FLUJO_APROBACION_ESTADIO
					FROM CTR.FLUJO_APROBACION_ESTADIO FAE 
					WHERE FAE.CODIGO_FLUJO_APROBACION = FA.CODIGO_FLUJO_APROBACION AND FAE.ESTADO_REGISTRO = '1' 
					ORDER BY ORDEN DESC) AS CODIGO_ULTIMO_ESTADIO
		INTO #TMP_ULTIMO_ESTADIO_CONTRATO
		FROM	CTR.FLUJO_APROBACION FA
		WHERE	FA.ESTADO_REGISTRO = '1'

		SELECT @AGRUPADOS = @AGRUPADOS + COALESCE('''' + CAST(CODIGO_ULTIMO_ESTADIO AS VARCHAR(40)) + ''',','') FROM #TMP_ULTIMO_ESTADIO_CONTRATO

		IF @AGRUPADOS <> ''
		BEGIN
		SET @AGRUPADOS = (LEFT(@AGRUPADOS, LEN(@AGRUPADOS) - 1))
		END

		DROP TABLE #TMP_ULTIMO_ESTADIO_CONTRATO

	END
	 
	IF @INDICADOR_TODA_UNIDAD_OPERATIVA <> '1'
	BEGIN
		IF (SELECT COUNT(*) FROM @LISTA_UNIDAD_OPERATIVA_ACCESO) > 0
		BEGIN
			SELECT CODIGO INTO #LISTA_ACCESO FROM @LISTA_UNIDAD_OPERATIVA_ACCESO
			SELECT @PERMISOS_UNIDAD_OPERATIVA = @PERMISOS_UNIDAD_OPERATIVA + COALESCE('''' + CAST(CODIGO AS VARCHAR(40)) + ''',','') FROM #LISTA_ACCESO
			
			IF @PERMISOS_UNIDAD_OPERATIVA <> ''
			BEGIN
			SET @PERMISOS_UNIDAD_OPERATIVA = (LEFT(@PERMISOS_UNIDAD_OPERATIVA, LEN(@PERMISOS_UNIDAD_OPERATIVA) - 1))
			END
			
			DROP TABLE #LISTA_ACCESO
		END
	END

SET @COLUMNA_ORDEN =ISNULL(@COLUMNA_ORDEN,'')
SET @TIPO_ORDEN    =ISNULL(@TIPO_ORDEN,'')

SET @ROW_NUMBER = (SELECT CASE @COLUMNA_ORDEN
WHEN 'FechaCreacionString'			THEN 'C.FECHA_CREACION'
WHEN 'NumeroContrato'				THEN 'C.NUMERO_CONTRATO'
WHEN 'NumeroAdendaConcatenado'		THEN 'C.NUMERO_ADENDA_CONCATENADO'
WHEN 'Descripcion'					THEN 'C.DESCRIPCION'
WHEN 'NombreProveedor'				THEN 'P.NOMBRE'
WHEN 'FechaInicioVigenciaString'	THEN 'C.FECHA_INICIO_VIGENCIA'
WHEN 'FechaFinVigenciaString'		THEN 'C.FECHA_FIN_VIGENCIA'
WHEN 'DescripcionTipoDocumento'		THEN 'C.CODIGO_TIPO_DOCUMENTO'
WHEN 'DescripcionEstadoContrato'	THEN 'C.CODIGO_ESTADO'
WHEN 'UsuarioCreacion'				THEN 'C.USUARIO_CREACION'
WHEN 'NombreEstadioActual'			THEN 'FAE.DESCRIPCION'
WHEN 'NombreUnidadOperativa'		THEN 'C.CODIGO_UNIDAD_OPERATIVA'
ELSE 'C.FECHA_CREACION'	 END)

IF @COLUMNA_ORDEN = 'NombreUnidadOperativa'
BEGIN
SET @ROW_NUMBER = 'C.FECHA_CREACION'
SET @TIPO_ORDEN = 'DESC'
END

SET @SENTENCIA = '
SELECT * FROM 
(SELECT
TotalRegistro  = CONVERT(BIGINT,COUNT(1) OVER()),
NumeroRegistro = CONVERT(BIGINT,ROW_NUMBER() OVER (ORDER BY ' + @ROW_NUMBER + ' ' + @TIPO_ORDEN + ')),
C.CODIGO_CONTRATO						AS CodigoContrato,
C.CODIGO_UNIDAD_OPERATIVA				AS CodigoUnidadOperativa,
C.CODIGO_PROVEEDOR						AS CodigoProveedor,
C.NUMERO_CONTRATO						AS NumeroContrato,
C.NUMERO_ADENDA_CONCATENADO				AS NumeroAdendaConcatenado,
C.DESCRIPCION							AS Descripcion,
C.CODIGO_TIPO_SERVICIO					AS CodigoTipoServicio,
C.CODIGO_TIPO_REQUERIMIENTO				AS CodigoTipoRequerimiento,
C.CODIGO_TIPO_DOCUMENTO					AS CodigoTipoDocumento,
C.FECHA_INICIO_VIGENCIA					AS FechaInicioVigencia,
C.FECHA_FIN_VIGENCIA					AS FechaFinVigencia,
CASE C.CODIGO_ESTADO WHEN ''RS'' THEN 2 WHEN ''V'' THEN (CASE WHEN C.FECHA_FIN_VIGENCIA >= CONVERT(VARCHAR(10),GETDATE(),112) THEN 1 ELSE 0 END) ELSE 0 END AS ValidacionResolucion,
ISNULL(C.FECHA_RESOLUCION,''31001230'')	AS FechaResolucion,
C.CODIGO_MONEDA							AS CodigoMoneda,
C.MONTO_CONTRATO						AS MontoContrato,
C.MONTO_ACUMULADO						AS MontoAcumulado,
C.CODIGO_ESTADO							AS CodigoEstadoContrato,
C.CODIGO_PLANTILLA						AS CodigoPlantilla,
C.CODIGO_CONTRATO_PRINCIPAL				AS CodigoContratoPrincipal,
C.CODIGO_ESTADO_EDICION					AS CodigoEstadoEdicion,
C.COMENTARIO_MODIFICACION				AS ComentarioModificacion,
C.RESPUESTA_MODIFICACION				AS RespuestaModificacion,
C.CODIGO_ESTADIO_ACTUAL					AS CodigoEstadioActual,
P.NUMERO_DOCUMENTO						AS NumeroDocumentoProveedor,
P.NOMBRE								AS NombreProveedor,
(CASE 
WHEN C.CODIGO_ESTADO = ''A'' THEN 
CASE 
WHEN (EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA EM 
WHERE EM.NUMERO_RUC = P.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND EM.ESTADO_REGISTRO = ''1'')) THEN ISNULL(CE.CODIGO_RESPONSABLE, FAP.CODIGO_TRABAJADOR)
ELSE CE.CODIGO_RESPONSABLE END
ELSE NULL END)							AS CodigoTrabajadorResponsable,
CE.FECHA_CREACION						AS FechaCreacionEstadioActual,
PL.INDICADOR_ADHESION					AS IndicadorAdhesion,
C.ESTADO_REGISTRO						AS EstadoRegistro,
C.FECHA_CREACION						AS FechaCreacion,
C.USUARIO_CREACION						AS UsuarioCreacion,
FAE.DESCRIPCION							AS NombreEstadioActual,
ISNULL(C.ES_FLEXIBLE,0)					AS EsFlexible,
FAP.CODIGO_TRABAJADOR AS FAPCODIGO_TRABAJADOR,
FAPV.CODIGO_TRABAJADOR AS FAPVCODIGO_TRABAJADOR,
CE.CODIGO_RESPONSABLE AS CECODIGO_RESPONSABLE 
FROM CTR.CONTRATO C
LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP ON FAP.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL 
AND FAP.CODIGO_TIPO_PARTICIPANTE = ''R'' AND FAP.ESTADO_REGISTRO = ''1''
LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAPV ON FAPV.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL 
AND FAPV.CODIGO_TIPO_PARTICIPANTE = ''V'' AND FAPV.ESTADO_REGISTRO = ''1''
LEFT JOIN CTR.PROVEEDOR P ON P.CODIGO_PROVEEDOR  = C.CODIGO_PROVEEDOR
LEFT JOIN CTR.PLANTILLA PL ON PL.CODIGO_PLANTILLA = C.CODIGO_PLANTILLA
LEFT JOIN CTR.CONTRATO_DOCUMENTO CD ON CD.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CD.ESTADO_REGISTRO = ''1'' AND CD.INDICADOR_ACTUAL = 1
LEFT JOIN CTR.[CONTRATO_ESTADIO] CE ON CE.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND CE.CODIGO_ESTADO_CONTRATO_ESTADIO = ''I''
AND CE.ESTADO_REGISTRO = 1
LEFT JOIN CTR.FLUJO_APROBACION_ESTADIO  FAE ON FAE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAE.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO AND FAE.ESTADO_REGISTRO = ''1''
WHERE C.ESTADO_REGISTRO = ''1'''

IF @CODIGO_CONTRATO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_CONTRATO = ''' + CAST(@CODIGO_CONTRATO AS VARCHAR(100)) + ''')'

IF @CODIGO_UNIDAD_OPERATIVA IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_UNIDAD_OPERATIVA = ''' + CAST(@CODIGO_UNIDAD_OPERATIVA AS VARCHAR(100)) + ''')'

IF @CODIGO_PLANTILLA IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_PLANTILLA = ''' + CAST(@CODIGO_PLANTILLA AS VARCHAR(100)) + ''')'

IF @CODIGO_TIPO_SERVICIO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_TIPO_SERVICIO	= ''' + @CODIGO_TIPO_SERVICIO + ''')'

IF @CODIGO_TIPO_REQUERIMIENTO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_TIPO_REQUERIMIENTO = ''' + @CODIGO_TIPO_REQUERIMIENTO + ''')'

IF @CODIGO_TIPO_DOCUMENTO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_TIPO_DOCUMENTO = ''' + @CODIGO_TIPO_DOCUMENTO + ''')'

IF @CODIGO_ESTADO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_ESTADO = ''' + @CODIGO_ESTADO + ''')'

IF @NUMERO_CONTRATO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.NUMERO_CONTRATO = ''' + @NUMERO_CONTRATO + ''')'

IF @USUARIO_CREACION IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.USUARIO_CREACION	 = ''' + @USUARIO_CREACION + ''')'

IF @NUMERO_ADENDA_CONCATENADO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.NUMERO_ADENDA_CONCATENADO = ''' + @NUMERO_ADENDA_CONCATENADO + ''')'

IF @NUMERO_DOCUMENTO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (P.NUMERO_DOCUMENTO = ''' + @NUMERO_DOCUMENTO + ''')'

IF @NOMBRE_PROVEEDOR IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (P.NOMBRE LIKE ''%' + @NOMBRE_PROVEEDOR + '%'')'

IF @DESCRIPCION IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.DESCRIPCION LIKE ''%' + @DESCRIPCION + '%'')'

IF @CODIGO_ESTADO_EDICION IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_ESTADO_EDICION = ''' + @CODIGO_ESTADO_EDICION + ''')'

IF @CONTENIDO_CONTRATO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (ISNULL(CD.CONTENIDO_BUSQUEDA,'''') LIKE ''' + @CONTENIDO_CONTRATO + ''')'

IF @CODIGO_TRABAJADOR_RESPONSABLE IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (CE.CODIGO_RESPONSABLE IS NOT NULL AND CE.CODIGO_RESPONSABLE = ''' + CAST(@CODIGO_TRABAJADOR_RESPONSABLE AS VARCHAR(100)) + ''' AND C.CODIGO_ESTADO  IN (''A'',''E''))'

IF @NOMBRE_ESTADIO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (FAE.DESCRIPCION LIKE ''' + @NOMBRE_ESTADIO + ''' AND C.CODIGO_ESTADO  IN (''A''))'

IF @MONTO_INICIO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.MONTO_ACUMULADO >= ''' + CAST(@MONTO_INICIO AS VARCHAR(25)) + ''')'

IF @MONTO_FIN IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.MONTO_ACUMULADO <= ''' + CAST(@MONTO_FIN AS VARCHAR(25)) + ''')'

IF @CODIGO_MONEDA IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_MONEDA = ''' + @CODIGO_MONEDA + ''')'

--IF @INDICADOR_TODA_UNIDAD_OPERATIVA IS NOT NULL
--SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_MONEDA = ''' + @CODIGO_MONEDA + ''')'


DECLARE @IDENTIFICADOR UNIQUEIDENTIFIER = NEWID()
IF @INDICADOR_TODA_UNIDAD_OPERATIVA <> '1'
BEGIN
	IF @PERMISOS_UNIDAD_OPERATIVA <> ''
	BEGIN
		SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_UNIDAD_OPERATIVA IN (' + @PERMISOS_UNIDAD_OPERATIVA + '))'
	END
	ELSE
	BEGIN
		SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_UNIDAD_OPERATIVA IN (''' + CAST(@IDENTIFICADOR AS VARCHAR(40)) + '''))'
	END
END

IF @INDICADOR_FINALIZAR_APROBACION = 'A'
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_ESTADO = ''A'' AND C.CODIGO_ESTADIO_ACTUAL IN (' + @AGRUPADOS + '))'

IF @INDICADOR_FINALIZAR_APROBACION = 'NA'
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_ESTADO = ''A'' AND C.CODIGO_ESTADIO_ACTUAL NOT IN (' + @AGRUPADOS + '))'


SET @SENTENCIA = @SENTENCIA + ')data
WHERE (Data.NumeroRegistro BETWEEN (' + CAST(@NUMERO_PAGINA AS VARCHAR(5)) + ' * ' + CAST(@TAMANIO_PAGINA AS VARCHAR(5)) + ') + 1 AND ' + 
CAST(@TAMANIO_PAGINA AS VARCHAR(5)) + ' * (' + CAST(@NUMERO_PAGINA AS VARCHAR(5)) + ' + 1)) 
ORDER BY Data.FechaCreacion DESC'

EXEC(@SENTENCIA)

END
GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_ORDENADO_SEL1]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_ORDENADO_SEL1]
(@CODIGO_CONTRATO					UNIQUEIDENTIFIER,
@CODIGO_UNIDAD_OPERATIVA			UNIQUEIDENTIFIER,
@CODIGO_PLANTILLA					UNIQUEIDENTIFIER,
@CODIGO_TIPO_SERVICIO				NVARCHAR(5),
@CODIGO_TIPO_REQUERIMIENTO			NVARCHAR(6),
@CODIGO_TIPO_DOCUMENTO				NVARCHAR(5),
@CODIGO_ESTADO						NVARCHAR(5),
@NUMERO_CONTRATO					NVARCHAR(50),
@NUMERO_ADENDA_CONCATENADO			NVARCHAR(80),
@NUMERO_DOCUMENTO					NVARCHAR(20),
@NOMBRE_PROVEEDOR					NVARCHAR(255),
@DESCRIPCION						NVARCHAR(255),
@INDICADOR_TODA_UNIDAD_OPERATIVA	BIT,
--@LISTA_UNIDAD_OPERATIVA_ACCESO		CTR.LISTA_GUID READONLY,
@CODIGO_ESTADO_EDICION				NVARCHAR(255),
@CONTENIDO_CONTRATO					NVARCHAR(MAX),
@CODIGO_TRABAJADOR_RESPONSABLE		UNIQUEIDENTIFIER,
@NOMBRE_ESTADIO						NVARCHAR(300),
@INDICADOR_FINALIZAR_APROBACION		NVARCHAR(10),
@MONTO_INICIO						DECIMAL(12,2),
@MONTO_FIN							DECIMAL(12,2),
@CODIGO_MONEDA						CHAR(3),
@USUARIO_CREACION					VARCHAR(100),
@COLUMNA_ORDEN                      VARCHAR(50),
@TIPO_ORDEN                         VARCHAR(50),
@NUMERO_PAGINA                      BIGINT =      0,
@TAMANIO_PAGINA                     BIGINT =      42121)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_SEL
Propósito:   Obtiene el listado del contrato  
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
		@CODIGO_UNIDAD_OPERATIVA: Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@CODIGO_PLANTILLA: Parámetro de entrada de tipo uniqueidentifier, que representa código de plantilla.
		@CODIGO_TIPO_SERVICIO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo servicio.
		@CODIGO_TIPO_REQUERIMIENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo requerimiento.
		@CODIGO_TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.
		@CODIGO_ESTADO:	Parámetro de entrada de tipo nvarchar, que representa codigo estado.
		@NUMERO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa numero contrato.
		@NUMERO_ADENDA_CONCATENADO:	Parámetro de entrada de tipo nvarchar, que representa numero de adenda concatenado.
		@NUMERO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa numero documento.
		@NOMBRE_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa nombre proveedor.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
		@INDICADOR_TODA_UNIDAD_OPERATIVA: Parámetro de entrada de tipo bit, que indica si el trabajadador puede acceder a todas las unidades operativas o no.
		@LISTA_UNIDAD_OPERATIVA_ACCESO Parámetro de entrada de tipo CTR.LISTA_GUID, que representa una lista de códigos de unidades operativas.
		@CODIGO_ESTADO_EDICION: Parámetro de entrada de tipo nvarchar, que representa un estado de edición.
		@DESCRIPCION_CONTRATO: Parámetro de entrada de tipo nvarchar, que representa la descripción del contrato.
		@CODIGO_TRABAJADOR_RESPONSABLE: Parámetro de entrada de tipo UNIQUEIDENTIFIER, que representa el Código de Trabajador Responsable.
		@NOMBRE_ESTADIO: Parámetro de entrada de tipo NVARCHAR, que representa el Nombre del Estadio.
		@INDICADOR_FINALIZAR_APROBACION: Parámetro de entrada de tipo NVARCHAR, que representa el Indicador de Finalizar Aprobación.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 2017-01-10 Se agrega retornar EsFlexible
       Actualización: 2017-11-27 Se agrega validación para obtener responsable para empresa vinculada
	   Actualización: ADEXUS 2018-10-09 Se modifica query para que ejecute en menor tiempo.
**********************************************************************************************************************************/
BEGIN

DECLARE @lPageNbr	INT, @lPageSize	INT, @lFirstRec	INT, @lLAStRec	INT

	IF(@CONTENIDO_CONTRATO IS NOT NULL)
		BEGIN
			SET @CONTENIDO_CONTRATO = '%' + @CONTENIDO_CONTRATO + '%'
		END

	IF @NOMBRE_ESTADIO IS NOT NULL
		BEGIN
			SET @NOMBRE_ESTADIO = '%' + @NOMBRE_ESTADIO + '%'		
		END

	DECLARE @TMP_ULTIMO_ESTADIO_CONTRATO CTR.LISTA_GUID
	DECLARE @ROW_NUMBER VARCHAR(250), @SENTENCIA NVARCHAR(MAX),@AGRUPADOS NVARCHAR(MAX) = '',@PERMISOS_UNIDAD_OPERATIVA NVARCHAR(MAX) = ''


	IF @INDICADOR_FINALIZAR_APROBACION = 'A' OR @INDICADOR_FINALIZAR_APROBACION = 'NA'
	BEGIN

		--INSERT INTO @TMP_ULTIMO_ESTADIO_CONTRATO
		SELECT	(SELECT TOP 1 FAE.CODIGO_FLUJO_APROBACION_ESTADIO
					FROM CTR.FLUJO_APROBACION_ESTADIO FAE 
					WHERE FAE.CODIGO_FLUJO_APROBACION = FA.CODIGO_FLUJO_APROBACION AND FAE.ESTADO_REGISTRO = '1' 
					ORDER BY ORDEN DESC) AS CODIGO_ULTIMO_ESTADIO
		INTO #TMP_ULTIMO_ESTADIO_CONTRATO
		FROM	CTR.FLUJO_APROBACION FA
		WHERE	FA.ESTADO_REGISTRO = '1'

		SELECT @AGRUPADOS = @AGRUPADOS + COALESCE('''' + CAST(CODIGO_ULTIMO_ESTADIO AS VARCHAR(40)) + ''',','') FROM #TMP_ULTIMO_ESTADIO_CONTRATO

		IF @AGRUPADOS <> ''
		BEGIN
		SET @AGRUPADOS = (LEFT(@AGRUPADOS, LEN(@AGRUPADOS) - 1))
		END

		DROP TABLE #TMP_ULTIMO_ESTADIO_CONTRATO

	END
	 
	--IF @INDICADOR_TODA_UNIDAD_OPERATIVA <> '1'
	--BEGIN
	--	IF (SELECT COUNT(*) FROM @LISTA_UNIDAD_OPERATIVA_ACCESO) > 0
	--	BEGIN
	--		SELECT CODIGO INTO #LISTA_ACCESO FROM @LISTA_UNIDAD_OPERATIVA_ACCESO
	--		SELECT @PERMISOS_UNIDAD_OPERATIVA = @PERMISOS_UNIDAD_OPERATIVA + COALESCE('''' + CAST(CODIGO AS VARCHAR(40)) + ''',','') FROM #LISTA_ACCESO
			
	--		IF @PERMISOS_UNIDAD_OPERATIVA <> ''
	--		BEGIN
	--		SET @PERMISOS_UNIDAD_OPERATIVA = (LEFT(@PERMISOS_UNIDAD_OPERATIVA, LEN(@PERMISOS_UNIDAD_OPERATIVA) - 1))
	--		END
			
	--		DROP TABLE #LISTA_ACCESO
	--	END
	--END

SET @COLUMNA_ORDEN =ISNULL(@COLUMNA_ORDEN,'')
SET @TIPO_ORDEN    =ISNULL(@TIPO_ORDEN,'')

SET @ROW_NUMBER = (SELECT CASE @COLUMNA_ORDEN
WHEN 'FechaCreacionString'			THEN 'C.FECHA_CREACION'
WHEN 'NumeroContrato'				THEN 'C.NUMERO_CONTRATO'
WHEN 'NumeroAdendaConcatenado'		THEN 'C.NUMERO_ADENDA_CONCATENADO'
WHEN 'Descripcion'					THEN 'C.DESCRIPCION'
WHEN 'NombreProveedor'				THEN 'P.NOMBRE'
WHEN 'FechaInicioVigenciaString'	THEN 'C.FECHA_INICIO_VIGENCIA'
WHEN 'FechaFinVigenciaString'		THEN 'C.FECHA_FIN_VIGENCIA'
WHEN 'DescripcionTipoDocumento'		THEN 'C.CODIGO_TIPO_DOCUMENTO'
WHEN 'DescripcionEstadoContrato'	THEN 'C.CODIGO_ESTADO'
WHEN 'UsuarioCreacion'				THEN 'C.USUARIO_CREACION'
WHEN 'NombreEstadioActual'			THEN 'FAE.DESCRIPCION'
WHEN 'NombreUnidadOperativa'		THEN 'C.CODIGO_UNIDAD_OPERATIVA'
ELSE 'C.FECHA_CREACION'	 END)

IF @COLUMNA_ORDEN = 'NombreUnidadOperativa'
BEGIN
SET @ROW_NUMBER = 'C.FECHA_CREACION'
SET @TIPO_ORDEN = 'DESC'
END

SET @SENTENCIA = '
SELECT * FROM 
(SELECT
TotalRegistro  = CONVERT(BIGINT,COUNT(1) OVER()),
NumeroRegistro = CONVERT(BIGINT,ROW_NUMBER() OVER (ORDER BY ' + @ROW_NUMBER + ' ' + @TIPO_ORDEN + ')),
C.CODIGO_CONTRATO						AS CodigoContrato,
C.CODIGO_UNIDAD_OPERATIVA				AS CodigoUnidadOperativa,
C.CODIGO_PROVEEDOR						AS CodigoProveedor,
C.NUMERO_CONTRATO						AS NumeroContrato,
C.NUMERO_ADENDA_CONCATENADO				AS NumeroAdendaConcatenado,
C.DESCRIPCION							AS Descripcion,
C.CODIGO_TIPO_SERVICIO					AS CodigoTipoServicio,
C.CODIGO_TIPO_REQUERIMIENTO				AS CodigoTipoRequerimiento,
C.CODIGO_TIPO_DOCUMENTO					AS CodigoTipoDocumento,
C.FECHA_INICIO_VIGENCIA					AS FechaInicioVigencia,
C.FECHA_FIN_VIGENCIA					AS FechaFinVigencia,
CASE C.CODIGO_ESTADO WHEN ''RS'' THEN 2 WHEN ''V'' THEN (CASE WHEN C.FECHA_FIN_VIGENCIA >= CONVERT(VARCHAR(10),GETDATE(),112) THEN 1 ELSE 0 END) ELSE 0 END AS ValidacionResolucion,
ISNULL(C.FECHA_RESOLUCION,''31001230'')	AS FechaResolucion,
C.CODIGO_MONEDA							AS CodigoMoneda,
C.MONTO_CONTRATO						AS MontoContrato,
C.MONTO_ACUMULADO						AS MontoAcumulado,
C.CODIGO_ESTADO							AS CodigoEstadoContrato,
C.CODIGO_PLANTILLA						AS CodigoPlantilla,
C.CODIGO_CONTRATO_PRINCIPAL				AS CodigoContratoPrincipal,
C.CODIGO_ESTADO_EDICION					AS CodigoEstadoEdicion,
C.COMENTARIO_MODIFICACION				AS ComentarioModificacion,
C.RESPUESTA_MODIFICACION				AS RespuestaModificacion,
C.CODIGO_ESTADIO_ACTUAL					AS CodigoEstadioActual,
P.NUMERO_DOCUMENTO						AS NumeroDocumentoProveedor,
P.NOMBRE								AS NombreProveedor,
(CASE 
WHEN C.CODIGO_ESTADO = ''A'' THEN 
CASE 
WHEN (EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA EM 
WHERE EM.NUMERO_RUC = P.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND EM.ESTADO_REGISTRO = ''1'')) THEN ISNULL(CE.CODIGO_RESPONSABLE, FAP.CODIGO_TRABAJADOR)
ELSE CE.CODIGO_RESPONSABLE END
ELSE NULL END)							AS CodigoTrabajadorResponsable,
CE.FECHA_CREACION						AS FechaCreacionEstadioActual,
PL.INDICADOR_ADHESION					AS IndicadorAdhesion,
C.ESTADO_REGISTRO						AS EstadoRegistro,
C.FECHA_CREACION						AS FechaCreacion,
C.USUARIO_CREACION						AS UsuarioCreacion,
FAE.DESCRIPCION							AS NombreEstadioActual,
ISNULL(C.ES_FLEXIBLE,0)					AS EsFlexible,
FAP.CODIGO_TRABAJADOR AS FAPCODIGO_TRABAJADOR,
FAPV.CODIGO_TRABAJADOR AS FAPVCODIGO_TRABAJADOR,
CE.CODIGO_RESPONSABLE AS CECODIGO_RESPONSABLE 
FROM CTR.CONTRATO C
LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP ON FAP.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL 
AND FAP.CODIGO_TIPO_PARTICIPANTE = ''R'' AND FAP.ESTADO_REGISTRO = ''1''
LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAPV ON FAPV.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL 
AND FAPV.CODIGO_TIPO_PARTICIPANTE = ''V'' AND FAPV.ESTADO_REGISTRO = ''1''
LEFT JOIN CTR.PROVEEDOR P ON P.CODIGO_PROVEEDOR  = C.CODIGO_PROVEEDOR
LEFT JOIN CTR.PLANTILLA PL ON PL.CODIGO_PLANTILLA = C.CODIGO_PLANTILLA
LEFT JOIN CTR.CONTRATO_DOCUMENTO CD ON CD.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CD.ESTADO_REGISTRO = ''1'' AND CD.INDICADOR_ACTUAL = 1
LEFT JOIN CTR.[CONTRATO_ESTADIO] CE ON CE.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND CE.CODIGO_ESTADO_CONTRATO_ESTADIO = ''I''
AND CE.ESTADO_REGISTRO = 1
LEFT JOIN CTR.FLUJO_APROBACION_ESTADIO  FAE ON FAE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAE.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO AND FAE.ESTADO_REGISTRO = ''1''
WHERE C.ESTADO_REGISTRO = ''1'''

IF @CODIGO_CONTRATO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_CONTRATO = ''' + CAST(@CODIGO_CONTRATO AS VARCHAR(100)) + ''')'

IF @CODIGO_UNIDAD_OPERATIVA IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_UNIDAD_OPERATIVA = ''' + CAST(@CODIGO_UNIDAD_OPERATIVA AS VARCHAR(100)) + ''')'

IF @CODIGO_PLANTILLA IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_PLANTILLA = ''' + CAST(@CODIGO_PLANTILLA AS VARCHAR(100)) + ''')'

IF @CODIGO_TIPO_SERVICIO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_TIPO_SERVICIO	= ''' + @CODIGO_TIPO_SERVICIO + ''')'

IF @CODIGO_TIPO_REQUERIMIENTO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_TIPO_REQUERIMIENTO = ''' + @CODIGO_TIPO_REQUERIMIENTO + ''')'

IF @CODIGO_TIPO_DOCUMENTO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_TIPO_DOCUMENTO = ''' + @CODIGO_TIPO_DOCUMENTO + ''')'

IF @CODIGO_ESTADO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_ESTADO = ''' + @CODIGO_ESTADO + ''')'

IF @NUMERO_CONTRATO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.NUMERO_CONTRATO = ''' + @NUMERO_CONTRATO + ''')'

IF @USUARIO_CREACION IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.USUARIO_CREACION	 = ''' + @USUARIO_CREACION + ''')'

IF @NUMERO_ADENDA_CONCATENADO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.NUMERO_ADENDA_CONCATENADO = ''' + @NUMERO_ADENDA_CONCATENADO + ''')'

IF @NUMERO_DOCUMENTO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (P.NUMERO_DOCUMENTO = ''' + @NUMERO_DOCUMENTO + ''')'

IF @NOMBRE_PROVEEDOR IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (P.NOMBRE LIKE ''%' + @NOMBRE_PROVEEDOR + '%'')'

IF @DESCRIPCION IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.DESCRIPCION LIKE ''%' + @DESCRIPCION + '%'')'

IF @CODIGO_ESTADO_EDICION IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_ESTADO_EDICION = ''' + @CODIGO_ESTADO_EDICION + ''')'

IF @CONTENIDO_CONTRATO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (ISNULL(CD.CONTENIDO_BUSQUEDA,'''') LIKE ''' + @CONTENIDO_CONTRATO + ''')'

IF @CODIGO_TRABAJADOR_RESPONSABLE IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (CE.CODIGO_RESPONSABLE IS NOT NULL AND CE.CODIGO_RESPONSABLE = ''' + CAST(@CODIGO_TRABAJADOR_RESPONSABLE AS VARCHAR(100)) + ''' AND C.CODIGO_ESTADO  IN (''A'',''E''))'

IF @NOMBRE_ESTADIO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (FAE.DESCRIPCION LIKE ''' + @NOMBRE_ESTADIO + ''' AND C.CODIGO_ESTADO  IN (''A''))'

IF @MONTO_INICIO IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.MONTO_ACUMULADO >= ''' + CAST(@MONTO_INICIO AS VARCHAR(25)) + ''')'

IF @MONTO_FIN IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.MONTO_ACUMULADO <= ''' + CAST(@MONTO_FIN AS VARCHAR(25)) + ''')'

IF @CODIGO_MONEDA IS NOT NULL
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_MONEDA = ''' + @CODIGO_MONEDA + ''')'

--IF @INDICADOR_TODA_UNIDAD_OPERATIVA IS NOT NULL
--SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_MONEDA = ''' + @CODIGO_MONEDA + ''')'


DECLARE @IDENTIFICADOR UNIQUEIDENTIFIER = NEWID()
IF @INDICADOR_TODA_UNIDAD_OPERATIVA <> '1'
BEGIN
	IF @PERMISOS_UNIDAD_OPERATIVA <> ''
	BEGIN
		SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_UNIDAD_OPERATIVA IN (' + @PERMISOS_UNIDAD_OPERATIVA + '))'
	END
	ELSE
	BEGIN
		SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_UNIDAD_OPERATIVA IN (''' + CAST(@IDENTIFICADOR AS VARCHAR(40)) + '''))'
	END
END

IF @INDICADOR_FINALIZAR_APROBACION = 'A'
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_ESTADO = ''A'' AND C.CODIGO_ESTADIO_ACTUAL IN (' + @AGRUPADOS + '))'

IF @INDICADOR_FINALIZAR_APROBACION = 'NA'
SET @SENTENCIA = @SENTENCIA + ' AND (C.CODIGO_ESTADO = ''A'' AND C.CODIGO_ESTADIO_ACTUAL NOT IN (' + @AGRUPADOS + '))'


SET @SENTENCIA = @SENTENCIA + ')data
WHERE (Data.NumeroRegistro BETWEEN (' + CAST(@NUMERO_PAGINA AS VARCHAR(5)) + ' * ' + CAST(@TAMANIO_PAGINA AS VARCHAR(5)) + ') + 1 AND ' + 
CAST(@TAMANIO_PAGINA AS VARCHAR(5)) + ' * (' + CAST(@NUMERO_PAGINA AS VARCHAR(5)) + ' + 1)) 
ORDER BY Data.FechaCreacion DESC'

EXEC(@SENTENCIA)

PRINT (@SENTENCIA)

END
GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_PARRAFO_INS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_CONTRATO_PARRAFO_INS]
@CODIGO_CONTRATO_PARRAFO UNIQUEIDENTIFIER,
@CODIGO_CONTRATO UNIQUEIDENTIFIER,
@CODIGO_PLANTILLA_PARRAFO UNIQUEIDENTIFIER,
@CONTENIDO NVARCHAR(MAX),
@ESTADO_REGISTRO CHAR(1),
@USUARIO_CREACION NVARCHAR(50),
@FECHA_CREACION DATETIME,
@TERMINAL_CREACION NVARCHAR(50)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_PARRAFO_INS
Propósito:  Inserta y actualiza registros en la tabla Contrato parrafo 
Descripción de Parámetros: 
		@CODIGO_CONTRATO_PARRAFO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato parrafo.
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
		@CODIGO_PLANTILLA_PARRAFO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla parrafo.
		@CONTENIDO:	Parámetro de entrada de tipo nvarchar, que representa contenido.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@FECHA_CREACION:	Parámetro de entrada de tipo datetime, que representa fecha creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	INSERT INTO CTR.CONTRATO_PARRAFO
	        ( 
				CODIGO_CONTRATO_PARRAFO ,
				CODIGO_CONTRATO ,
				CODIGO_PLANTILLA_PARRAFO ,
				CONTENIDO,
				ESTADO_REGISTRO ,
				USUARIO_CREACION ,
				FECHA_CREACION ,
				TERMINAL_CREACION
	        )
	VALUES  ( 
				@CODIGO_CONTRATO_PARRAFO ,
				@CODIGO_CONTRATO ,
				@CODIGO_PLANTILLA_PARRAFO ,
				@CONTENIDO,
				@ESTADO_REGISTRO ,
				@USUARIO_CREACION ,
				@FECHA_CREACION ,
				@TERMINAL_CREACION
	        )
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_PARRAFO_POR_CONTRATO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_PARRAFO_POR_CONTRATO]
@CODIGO_CONTRATO uniqueidentifier
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_PARRAFO_POR_CONTRATO
Propósito:  Retorna información de los documentos del contrato. 
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
		select CodigoContratoParrafo= CP.CODIGO_CONTRATO_PARRAFO,
				   CodigoContrato=CP.CODIGO_CONTRATO,
				   CodigoPlantillaParrafo= CP.CODIGO_PLANTILLA_PARRAFO,				   
				   Contenido= isnull(CP.CONTENIDO,'')
				   from CTR.CONTRATO_PARRAFO CP (NOLOCK)			
			WHERE CP.CODIGO_CONTRATO=@CODIGO_CONTRATO
			and CP.ESTADO_REGISTRO='1'  
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_PARRAFO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_PARRAFO_SEL]
@CODIGO_CONTRATO uniqueidentifier
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_PARRAFO_SEL
Propósito:  Retorna los párrafos de un contrato. 
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/

BEGIN
select CodigoContratoParrafo= CP.CODIGO_CONTRATO_PARRAFO,
		   CodigoContrato = 	 CP.CODIGO_CONTRATO,
		  CodigoPlantillaParrafo = CP.CODIGO_PLANTILLA_PARRAFO,
		  Titulo = PP.TITULO,
		  Contenido= CP.CONTENIDO,
		  --Contenido= PP.CONTENIDO,
		  Orden= PP.ORDEN
	 from CTR.CONTRATO_PARRAFO CP (NOLOCK) INNER JOIN CTR.PLANTILLA_PARRAFO PP (NOLOCK)
	 ON ( CP.CODIGO_PLANTILLA_PARRAFO=PP.CODIGO_PLANTILLA_PARRAFO )
WHERE CP.CODIGO_CONTRATO=@CODIGO_CONTRATO
AND CP.ESTADO_REGISTRO='1'
ORDER BY PP.ORDEN

END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_PARRAFO_VARIABLE_INS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_CONTRATO_PARRAFO_VARIABLE_INS]
@CODIGO_CONTRATO_PARRAFO_VARIABLE UNIQUEIDENTIFIER,
@CODIGO_CONTRATO_PARRAFO UNIQUEIDENTIFIER,
@CODIGO_VARIABLE UNIQUEIDENTIFIER,
@VALOR_TEXTO NVARCHAR(3000),
@VALOR_NUMERO DECIMAL(12,2),
@VALOR_FECHA DATETIME,
@VALOR_IMAGEN VARBINARY(MAX),
@VALOR_TABLA NVARCHAR(MAX),
@VALOR_TABLA_EDITABLE NVARCHAR(MAX),
@VALOR_BIEN NVARCHAR(MAX),
@VALOR_BIEN_EDITABLE NVARCHAR(MAX),
@VALOR_FIRMANTE NVARCHAR(MAX),
@VALOR_FIRMANTE_EDITABLE NVARCHAR(MAX),
@VALOR_LISTA UNIQUEIDENTIFIER,
@ESTADO_REGISTRO CHAR(1),
@USUARIO_CREACION NVARCHAR(50),
@FECHA_CREACION DATETIME,
@TERMINAL_CREACION NVARCHAR(50)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_PARRAFO_VARIABLE_INS
Propósito:  Inserta y actualiza registros en la tabla Contrato documento 
Descripción de Parámetros: 
		@CODIGO_CONTRATO_PARRAFO_VARIABLE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato parrafo variable.
		@CODIGO_CONTRATO_PARRAFO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato parrafo.
		@CODIGO_VARIABLE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo variable.
		@VALOR_TEXTO:	Parámetro de entrada de tipo nvarchar, que representa valor texto.
		@VALOR_NUMERO:	Parámetro de entrada de tipo decimal, que representa valor numero.
		@VALOR_FECHA:	Parámetro de entrada de tipo datetime, que representa valor fecha.
		@VALOR_IMAGEN:	Parámetro de entrada de tipo varbinary, que representa valor imagen.
		@VALOR_TABLA:	Parámetro de entrada de tipo nvarchar, que representa valor tabla.
		@VALOR_TABLA_EDITABLE:	Parámetro de entrada de tipo nvarchar, que representa valor tabla editable.
		@VALOR_BIEN:	Parámetro de entrada de tipo nvarchar, que representa valor bien.
		@VALOR_BIEN_EDITABLE:	Parámetro de entrada de tipo nvarchar, que representa valor bien editable.
		@VALOR_FIRMANTE: Parámetro de entrada de tipo nvarchar, que representa valor firmante.
		@VALOR_FIRMANTE_EDITABLE: Parámetro de entrada de tipo nvarchar, que representa valor firmante editable.
		@VALOR_LISTA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo de la variable tipo seleccionable.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@FECHA_CREACION:	Parámetro de entrada de tipo datetime, que representa fecha creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	INSERT INTO CTR.CONTRATO_PARRAFO_VARIABLE
	        ( 
				CODIGO_CONTRATO_PARRAFO_VARIABLE ,
				CODIGO_CONTRATO_PARRAFO ,
				CODIGO_VARIABLE ,
				VALOR_TEXTO ,
				VALOR_NUMERO ,
				VALOR_FECHA ,
				VALOR_IMAGEN ,
				VALOR_TABLA,
				VALOR_TABLA_EDITABLE,
				VALOR_BIEN,
				VALOR_BIEN_EDITABLE,
				VALOR_FIRMANTE,
				VALOR_FIRMANTE_EDITABLE,
				VALOR_LISTA,
				ESTADO_REGISTRO ,
				USUARIO_CREACION ,
				FECHA_CREACION ,
				TERMINAL_CREACION 
	        )
	VALUES  ( 
				@CODIGO_CONTRATO_PARRAFO_VARIABLE ,
				@CODIGO_CONTRATO_PARRAFO ,
				@CODIGO_VARIABLE ,
				@VALOR_TEXTO ,
				@VALOR_NUMERO ,
				@VALOR_FECHA ,
				@VALOR_IMAGEN ,
				@VALOR_TABLA ,
				@VALOR_TABLA_EDITABLE,
				@VALOR_BIEN ,
				@VALOR_BIEN_EDITABLE,
				@VALOR_FIRMANTE,
				@VALOR_FIRMANTE_EDITABLE,
				@VALOR_LISTA,
				@ESTADO_REGISTRO ,
				@USUARIO_CREACION ,
				@FECHA_CREACION ,
				@TERMINAL_CREACION 
	        )
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_PARRAFO_VARIABLE_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_PARRAFO_VARIABLE_SEL]
@CODIGO_CONTRATO uniqueidentifier
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_PARRAFO_VARIABLE_SEL
Propósito:  Retorna las variables de los párrafos de un contrato. 
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
SELECT 
	   [CODIGO_CONTRATO_PARRAFO_VARIABLE] AS 'CodigoContratoParrafoVariable'
      ,CPV.[CODIGO_CONTRATO_PARRAFO] AS 'CodigoContratoParrafo'
	  ,CP.[CODIGO_PLANTILLA_PARRAFO] AS 'CodigoPlantillaParrafo'
      ,CPV.[CODIGO_VARIABLE] AS 'CodigoVariable'
	  ,[CODIGO_TIPO] AS 'CodigoTipo'
      ,[VALOR_TEXTO] AS 'ValorTexto'
      ,[VALOR_NUMERO] AS 'ValorNumero'
      ,CAST([VALOR_FECHA] AS DATE) AS 'ValorFecha'
      ,[VALOR_IMAGEN] AS 'ValorImagen'
      ,[VALOR_TABLA] AS 'ValorTabla'
	  ,[VALOR_TABLA_EDITABLE] AS 'ValorTablaEditable'
      ,[VALOR_BIEN] AS 'ValorBien'
	  ,[VALOR_BIEN_EDITABLE] AS 'ValorBienEditable'
	  ,[VALOR_FIRMANTE] AS 'ValorFirmante'
	  ,[VALOR_FIRMANTE_EDITABLE] AS 'ValorFirmanteEditable'
	  ,[VALOR_LISTA] AS 'ValorLista'
      ,CPV.[ESTADO_REGISTRO] AS 'EstadoRegistro'
	  ,V.[IDENTIFICADOR] AS 'Identificador'	  
	 FROM [CTR].[CONTRATO_PARRAFO_VARIABLE] CPV (NOLOCK) 
	 INNER JOIN [CTR].[CONTRATO_PARRAFO] CP (NOLOCK) 
	 ON [CPV].[CODIGO_CONTRATO_PARRAFO] = CP.[CODIGO_CONTRATO_PARRAFO]
	 INNER JOIN [CTR].[VARIABLE] V (NOLOCK)
	 ON V.[CODIGO_VARIABLE] = CPV.[CODIGO_VARIABLE]
WHERE CP.CODIGO_CONTRATO = @CODIGO_CONTRATO
AND CP.ESTADO_REGISTRO='1'

END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_POR_FINALIZAR_RPT]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_CONTRATO_POR_FINALIZAR_RPT] --[CTR].[USP_CONTRATO_POR_FINALIZAR_RPT] NULL,NULL,NULL,NULL,'A'
@CODIGO_UNIDAD_OPERATIVA			UNIQUEIDENTIFIER,
@CODIGO_TIPO_CONTRATO				NVARCHAR(10),
@CODIGO_TIPO_SERVICIO				NVARCHAR(10),
@NUMERO_CONTRATO					NVARCHAR(50),
@INDICADOR_ULTIMO_ESTADIO_APROBADO	NVARCHAR(10)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_SEL
Propósito:   Obtiene el listado del contrato  
Descripción de Parámetros: 
		@CODIGO_UNIDAD_OPERATIVA:			Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@CODIGO_TIPO_CONTRATO:				Parámetro de entrada de tipo nvarchar, que representa Código de Tipo de Contrato.
		@CODIGO_TIPO_SERVICIO:				Parámetro de entrada de tipo nvarchar, que representa Código de Tipo de Servicio.
		@NUMERO_CONTRATO:					Parámetro de entrada de tipo nvarchar, que representa el Número de Contrato.
		@INDICADOR_ULTIMO_ESTADIO_APROBADO:	Parámetro de entrada de tipo nvarchar, que representa el Indicador de Último Estadio / Aprobado.
Creado por: GMD
Fecha. Creación: 2016-06-24
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	IF @NUMERO_CONTRATO IS NOT NULL
		BEGIN
			SET @NUMERO_CONTRATO = '%' + @NUMERO_CONTRATO + '%'
		END

	DECLARE @TMP_ULTIMO_ESTADIO_CONTRATO CTR.LISTA_GUID

	IF @INDICADOR_ULTIMO_ESTADIO_APROBADO = 'U'
	BEGIN
		INSERT INTO @TMP_ULTIMO_ESTADIO_CONTRATO 
		SELECT	(SELECT TOP 1 FAE.CODIGO_FLUJO_APROBACION_ESTADIO
				 FROM CTR.FLUJO_APROBACION_ESTADIO FAE 
				 WHERE FAE.CODIGO_FLUJO_APROBACION = FA.CODIGO_FLUJO_APROBACION AND FAE.ESTADO_REGISTRO = '1' 
				 ORDER BY ORDEN DESC) AS CODIGO_ULTIMO_ESTADIO
		FROM	CTR.FLUJO_APROBACION FA
		WHERE	FA.ESTADO_REGISTRO = '1'
	END

	SELECT	C.CODIGO_CONTRATO										AS CodigoContrato,
			C.CODIGO_UNIDAD_OPERATIVA								AS CodigoUnidadOperativa,
			ISNULL(C.NUMERO_ADENDA_CONCATENADO,C.NUMERO_CONTRATO)	AS NumeroContrato,
			C.CODIGO_PROVEEDOR										AS CodigoProveedor,
			PR.NUMERO_DOCUMENTO										AS RucProveedor,
			PR.NOMBRE												AS NombreProveedor,
			FAE.DESCRIPCION											AS NombreEstadio,
			C.CODIGO_ESTADO											AS CodigoEstadoContrato,
			
			CE.FECHA_CREACION										AS FechaCreacionEstadioActual,
			DATEDIFF(dd, CE.FECHA_CREACION, GETDATE())				AS DiasEnBandeja,

			(CASE 
			 WHEN C.CODIGO_ESTADO = 'A' THEN FAP.CODIGO_TRABAJADOR
			 ELSE NULL END)											AS CodigoTrabajadorResponsable,

			(CASE WHEN @INDICADOR_ULTIMO_ESTADIO_APROBADO = 'U' THEN 'Último Estadio' ELSE 'Aprobados' END) AS UltimoEstadioAprobados	
	FROM	CTR.CONTRATO C
	LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP ON FAP.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAP.CODIGO_TIPO_PARTICIPANTE = 'R' AND FAP.ESTADO_REGISTRO = '1'
	INNER JOIN CTR.PROVEEDOR PR ON PR.CODIGO_PROVEEDOR = C.CODIGO_PROVEEDOR
	LEFT JOIN CTR.CONTRATO_ESTADIO CE ON CE.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND CE.CODIGO_ESTADO_CONTRATO_ESTADIO = 'I'
	INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FAE ON FAE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAE.ESTADO_REGISTRO = '1'
	WHERE	C.ESTADO_REGISTRO = '1'
	AND		(@CODIGO_UNIDAD_OPERATIVA IS NULL OR C.CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA)
	AND		(@CODIGO_TIPO_CONTRATO	IS NULL OR C.CODIGO_TIPO_SERVICIO	=	 @CODIGO_TIPO_CONTRATO)
	AND		(@CODIGO_TIPO_SERVICIO	IS NULL OR C.CODIGO_TIPO_REQUERIMIENTO	=	 @CODIGO_TIPO_SERVICIO)
	AND		(@NUMERO_CONTRATO		IS NULL OR C.NUMERO_CONTRATO		LIKE @NUMERO_CONTRATO)
	AND		((@INDICADOR_ULTIMO_ESTADIO_APROBADO = 'U' AND C.CODIGO_ESTADO = 'A' AND C.CODIGO_ESTADIO_ACTUAL IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO))
			OR (@INDICADOR_ULTIMO_ESTADIO_APROBADO = 'A' AND (C.CODIGO_ESTADO = 'V' OR C.CODIGO_ESTADO = 'T' OR C.CODIGO_ESTADO = 'C')))
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_PRINCIPAL_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_PRINCIPAL_SEL]
	@NUMERO_CONTRATO	NVARCHAR(50),
	@DESCRIPCION		NVARCHAR(20),
	@TIPO_SERVICIO_LC	NVARCHAR(5)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_PRINCIPAL_SEL
Propósito:   Obtiene el listado del contratos principales 
Descripción de Parámetros: 
		@NUMERO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa numero contrato.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
Prueba:--EXEC [CTR].[USP_CONTRATO_PRINCIPAL_SEL] 'STGYM.1000.CLSM.17.007',NULL,'25'
**********************************************************************************************************************************/
BEGIN
	DECLARE @ROWMIN INT, @ROWMAX INT,
			@NUMERO_CONTRATO_TEMP VARCHAR(MAX),
			@FECHA_FIN_VIGENCIA DATETIME

	SELECT	@NUMERO_CONTRATO='%'+ISNULL(@NUMERO_CONTRATO,'')+'%',
			@DESCRIPCION	='%'+ISNULL(@DESCRIPCION,'')+'%'


	SELECT	ROW_NUMBER() OVER(ORDER BY CT.CODIGO_CONTRATO) AS ROW_ID,
			CT.CODIGO_CONTRATO,
			CT.CODIGO_TIPO_SERVICIO,
			CT.NUMERO_CONTRATO,
			CT.DESCRIPCION,
			CT.CODIGO_ESTADO,
			CT.CODIGO_PROVEEDOR,
			CT.MONTO_CONTRATO
	INTO	#TMP_LISTA_CODIGO_CONTRATO
	FROM	[CTR].[CONTRATO] CT (NOLOCK)
	WHERE		CT.CODIGO_TIPO_DOCUMENTO<>'A' 
		AND		CT.NUMERO_CONTRATO IS NOT NULL
		AND		CT.ESTADO_REGISTRO				='1'
		AND		ISNULL(CT.NUMERO_CONTRATO,'') LIKE @NUMERO_CONTRATO
		AND		ISNULL(CT.DESCRIPCION,'')	  LIKE @DESCRIPCION

	SELECT @ROWMIN=MIN(ROW_ID),@ROWMAX= MAX(ROW_ID) FROM #TMP_LISTA_CODIGO_CONTRATO

	WHILE(@ROWMIN <=@ROWMAX)BEGIN
		SELECT
			@NUMERO_CONTRATO_TEMP = NUMERO_CONTRATO
		FROM #TMP_LISTA_CODIGO_CONTRATO
		WHERE ROW_ID = @ROWMIN

		SET @FECHA_FIN_VIGENCIA = (SELECT TOP 1 A.FECHA_FIN_VIGENCIA FROM [CTR].[CONTRATO] A (NOLOCK)
									WHERE A.NUMERO_CONTRATO = @NUMERO_CONTRATO_TEMP 
									AND A.CODIGO_TIPO_DOCUMENTO = 'A' 
									AND A.CODIGO_ESTADO = 'V' 
									AND A.ESTADO_REGISTRO = '1' 
									ORDER BY A.FECHA_FIN_VIGENCIA DESC)

		IF(@FECHA_FIN_VIGENCIA IS NOT NULL AND @FECHA_FIN_VIGENCIA >= CAST(GETDATE() AS DATE))
		BEGIN
			UPDATE #TMP_LISTA_CODIGO_CONTRATO SET CODIGO_ESTADO = 'V' WHERE ROW_ID = @ROWMIN
		END

		SET @ROWMIN = @ROWMIN + 1

	END

	--IF(@TIPO_SERVICIO_LC!='34')BEGIN

	--	SELECT	L.CODIGO_CONTRATO				AS CODIGOCONTRATO,
	--			ISNULL(L.NUMERO_CONTRATO,'')	AS NUMEROCONTRATO,
	--			L.DESCRIPCION					AS DESCRIPCION,
	--			PV.NOMBRE						AS NOMBREPROVEEDOR,
	--			ISNULL((SELECT MAX(CP.NUMERO_ADENDA)
	--	FROM [CTR].[CONTRATO] CP
	--	WHERE CP.CODIGO_CONTRATO_PRINCIPAL = L.CODIGO_CONTRATO
	--	AND CP.ESTADO_REGISTRO = '1'), 0)	AS CANTIDADADENDA
	--	FROM #TMP_LISTA_CODIGO_CONTRATO L (NOLOCK) 
	--	INNER JOIN CTR.PROVEEDOR PV (NOLOCK)	ON (L.CODIGO_PROVEEDOR=PV.CODIGO_PROVEEDOR)
	--	---WHERE L.CODIGO_ESTADO = 'V'//comentado 10-04-2017
	--	--Agrega
	--	WHERE L.CODIGO_TIPO_SERVICIO<>'34' AND L.CODIGO_ESTADO = 'V' 
	----Fin
	--END ELSE BEGIN
		SELECT	
				L.CODIGO_CONTRATO																AS CODIGOCONTRATO,
				ISNULL(L.NUMERO_CONTRATO,'')													AS NUMEROCONTRATO,
				L.DESCRIPCION																	AS DESCRIPCION,
				PV.NOMBRE																		AS NOMBREPROVEEDOR,
				ISNULL((SELECT 
							MAX(CP.NUMERO_ADENDA)
						FROM [CTR].[CONTRATO] CP (NOLOCK)
						WHERE 
							  CP.CODIGO_CONTRATO_PRINCIPAL = L.CODIGO_CONTRATO
						  AND CP.ESTADO_REGISTRO = '1'), 0)										AS CANTIDADADENDA,
				L.MONTO_CONTRATO																As MontoContrato,
			    Convert(nvarchar(max),L.MONTO_CONTRATO)											AS MontoContratoString,

				ISNULL((SELECT 
							 MONTO_ACUMULADO
						FROM [CTR].[CONTRATO] CP (NOLOCK)
						WHERE 
							  CP.CODIGO_CONTRATO_PRINCIPAL = L.CODIGO_CONTRATO
						  AND NUMERO_ADENDA = (ISNULL((SELECT 
															MAX(CP.NUMERO_ADENDA)
														FROM [CTR].[CONTRATO] CP (NOLOCK)
														WHERE 
															  CP.CODIGO_CONTRATO_PRINCIPAL = L.CODIGO_CONTRATO
														  AND CP.ESTADO_REGISTRO = '1'), 0))
						  AND CP.ESTADO_REGISTRO = '1'), L.MONTO_CONTRATO)						AS MontoAcumulado,

				Convert(nvarchar(max),ISNULL((SELECT 
							 MONTO_ACUMULADO
						FROM [CTR].[CONTRATO] CP (NOLOCK)
						WHERE 
							  CP.CODIGO_CONTRATO_PRINCIPAL = L.CODIGO_CONTRATO
						  AND NUMERO_ADENDA = (ISNULL((SELECT 
															MAX(CP.NUMERO_ADENDA)
														FROM [CTR].[CONTRATO] CP (NOLOCK)
														WHERE 
															  CP.CODIGO_CONTRATO_PRINCIPAL = L.CODIGO_CONTRATO
														  AND CP.ESTADO_REGISTRO = '1'), 0))
						  AND CP.ESTADO_REGISTRO = '1'), L.MONTO_CONTRATO))						AS MontoAcumuladoString,

						isnull((SELECT 
							 CODIGO_MONEDA
						FROM [CTR].[CONTRATO] CP (NOLOCK)
						WHERE 
							  CP.CODIGO_CONTRATO_PRINCIPAL = L.CODIGO_CONTRATO
						  AND NUMERO_ADENDA = (ISNULL((SELECT 
															MAX(CP.NUMERO_ADENDA)
														FROM [CTR].[CONTRATO] CP (NOLOCK)
														WHERE 
															  CP.CODIGO_CONTRATO_PRINCIPAL = L.CODIGO_CONTRATO
														  AND CP.ESTADO_REGISTRO = '1'), 0))
						  AND CP.ESTADO_REGISTRO = '1'),(select codigo_moneda from ctr.contrato (NOLOCK) where codigo_contrato = l.codigo_contrato))			AS CodigoMoneda




		FROM #TMP_LISTA_CODIGO_CONTRATO L (NOLOCK) 
		INNER JOIN CTR.PROVEEDOR PV (NOLOCK) ON (L.CODIGO_PROVEEDOR=PV.CODIGO_PROVEEDOR)
		---WHERE L.CODIGO_ESTADO = 'V'//comentado 10-04-2017
		--Agrega
		WHERE  (/*L.CODIGO_TIPO_SERVICIO='34' AND*/ (L.CODIGO_ESTADO = 'C'  OR L.CODIGO_ESTADO = 'V' ))
	--Fin
	--END
END



GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_RPT]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_CONTRATO_RPT] --NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,null,NULL,NULL,NULL,NULL,NULL, NULL,NULL

(@CODIGO_UNIDAD_OPERATIVA		UNIQUEIDENTIFIER,

@NUMERO_CONTRATO				NVARCHAR(50),

@DESCRIPCION					NVARCHAR(255),

@CODIGO_TIPO_SERVICIO			NVARCHAR(5),

@CODIGO_TIPO_REQUERIMIENTO		NVARCHAR(5),

@CODIGO_TIPO_DOCUMENTO			NVARCHAR(5),

@CODIGO_ESTADO					NVARCHAR(5),

@NUMERO_DOCUMENTO_PROVEEDOR		NVARCHAR(20),

@NOMBRE_COMERCIAL_PROVEEDOR		NVARCHAR(255),

@FECHA_INICIO_VIGENCIA			DATETIME,

@FECHA_FIN_VIGENCIA				DATETIME,

@CONTENIDO_CONTRATO				NVARCHAR(MAX),

@CODIGO_TRABAJADOR_RESPONSABLE	UNIQUEIDENTIFIER,

@NOMBRE_ESTADIO					NVARCHAR(300),

@INDICADOR_FINALIZAR_APROBACION	NVARCHAR(10),

@MONTO_INICIO					NVARCHAR(20),

@MONTO_FIN						NVARCHAR(20),

@CODIGO_MONEDA					CHAR(3),

@CAMBIO_SOLES					NVARCHAR(10) = NULL,

@CAMBIO_GUYANA					NVARCHAR(10) = NULL)

AS

/**********************************************************************************************************************************

Nombre Objeto: CTR.USP_CONTRATO_RPT

Propósito:   Obtiene el listado del contrato  

Descripción de Parámetros: 

		@CODIGO_UNIDAD_OPERATIVA: Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.

		@NUMERO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa numero contrato.

		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.

		@CODIGO_TIPO_SERVICIO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo servicio.

		@CODIGO_TIPO_REQUERIMIENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo requerimiento.

		@CODIGO_TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.

		@CODIGO_ESTADO:	Parámetro de entrada de tipo nvarchar, que representa codigo estado.

		@NUMERO_DOCUMENTO_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa número de documento del proveedor.

		@NOMBRE_COMERCIAL_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa el nombre comercial del proveedor.

		@FECHA_INICIO_VIGENCIA:	Parámetro de entrada de tipo datetime, que representa fecha de inicio de vigencia del contrato.

		@FECHA_FIN_VIGENCIA:	Parámetro de entrada de tipo datetime, que representa fecha fin de vigencia del contrato.

		@CONTENIDO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa el contenido de contrato a buscar.

		@CODIGO_TRABAJADOR_RESPONSABLE: Parámetro de entrada de tipo UNIQUEIDENTIFIER, que representa el Código de Trabajador Responsable.

		@NOMBRE_ESTADIO: Parámetro de entrada de tipo NVARCHAR, que representa el Nombre del Estadio.

		@INDICADOR_FINALIZAR_APROBACION: Parámetro de entrada de tipo NVARCHAR, que representa el Indicador de Finalizar Aprobación.

Creado por: GMD

Fecha. Creación: 2015-08-25

Fecha. Actualización: 2017-11-27 Se agrega validación para obtener responsable para empresa vinculada

**********************************************************************************************************************************/



BEGIN


IF @NOMBRE_ESTADIO IS NOT NULL

	BEGIN

		SET @NOMBRE_ESTADIO = '%' + @NOMBRE_ESTADIO + '%'		

	END



DECLARE @TMP_ULTIMO_ESTADIO_CONTRATO CTR.LISTA_GUID

DECLARE @TIPO_SERVICIO TABLE(CODIGO NVARCHAR(255), VALOR  NVARCHAR(255))

DECLARE @TIPO_CONTRATO TABLE(CODIGO NVARCHAR(255), VALOR  NVARCHAR(255))



IF @INDICADOR_FINALIZAR_APROBACION = 'A' OR @INDICADOR_FINALIZAR_APROBACION = 'NA'

	BEGIN

		INSERT INTO @TMP_ULTIMO_ESTADIO_CONTRATO

		SELECT	(SELECT TOP 1 FAE.CODIGO_FLUJO_APROBACION_ESTADIO

				 FROM CTR.FLUJO_APROBACION_ESTADIO FAE 

				 WHERE FAE.CODIGO_FLUJO_APROBACION = FA.CODIGO_FLUJO_APROBACION AND FAE.ESTADO_REGISTRO = '1' 

				 ORDER BY ORDEN DESC) AS CODIGO_ULTIMO_ESTADIO

		FROM	CTR.FLUJO_APROBACION FA

		WHERE	FA.ESTADO_REGISTRO = '1'

	END

INSERT INTO @TIPO_SERVICIO (CODIGO, VALOR)
SELECT	CODIGO, VALOR
FROM	STRACON_POLITICAS.GRL.FN_LISTAR_VALORES_PARAMETRO('STR',0,'SGC','00013',2)

INSERT INTO @TIPO_CONTRATO (CODIGO, VALOR)
SELECT	CODIGO, VALOR
FROM	STRACON_POLITICAS.GRL.FN_LISTAR_VALORES_PARAMETRO('STR',0,'SGC','00014',2)





SELECT	

		C.CODIGO_UNIDAD_OPERATIVA				AS CodigoUnidadOperativa,

		C.NUMERO_CONTRATO						AS NumeroContrato,

		C.NUMERO_ADENDA_CONCATENADO				AS NumeroAdendaConcatenado,

		C.DESCRIPCION							AS Descripcion,

        P.NUMERO_DOCUMENTO						AS NumeroDocumentoProveedor,

		P.NOMBRE_COMERCIAL						AS NombreComercial,

        C.FECHA_INICIO_VIGENCIA					AS FechaInicioVigencia,

		--INICIO: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019
		C.FECHA_FIN_VIGENCIA					AS FechaFinVigencia,		
		C.NUMERO_ADENDA							AS Numero_Adenda,		
		(SELECT DATEDIFF(day, C.FECHA_INICIO_VIGENCIA, C.FECHA_CREACION)) AS Periodo_Sin_Contrato,
		(SELECT TOP 1 POLITICA.NOMBRES + ' ' + POLITICA.APELLIDO_PATERNO + ' ' + POLITICA.APELLIDO_MATERNO
		 FROM ECUADOR.STRACON_POLITICAS.GRL.TRABAJADOR AS POLITICA
		 INNER JOIN CTR.CONTRATO AS CTT ON POLITICA.CODIGO_TRABAJADOR = C.CODIGOREQUERIDO
		 WHERE CTT.CODIGOREQUERIDO = C.CODIGOREQUERIDO) AS Requerido_Por,	 
		--FIN: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019
		C.CODIGO_TIPO_SERVICIO					AS CodigoTipoServicio,
	
		C.CODIGO_TIPO_REQUERIMIENTO				AS CodigoTipoRequerimiento,

		C.CODIGO_TIPO_DOCUMENTO					AS CodigoTipoDocumento,

		C.CODIGO_ESTADO							AS CodigoEstadoContrato,

		C.FECHA_RESOLUCION						AS FechaResolucion,

		C.CODIGO_ESTADO_EDICION					AS CodigoEstadoEdicion,

		(CASE 

							WHEN C.CODIGO_ESTADO = 'A' THEN 

									CASE 

									WHEN (EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA EM 

									WHERE EM.NUMERO_RUC = P.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND EM.ESTADO_REGISTRO = '1')) THEN ISNULL(CE.CODIGO_RESPONSABLE, FAP.CODIGO_TRABAJADOR)

									ELSE CE.CODIGO_RESPONSABLE END

							ELSE NULL END)						AS CodigoTrabajadorResponsable,

		CE.FECHA_CREACION						AS FechaCreacionEstadioActual,

		C.USUARIO_CREACION						AS UsuarioCreacionContrato,

		C.FECHA_CREACION						AS FechaCreacionContrato,

		FAE.DESCRIPCION							AS NombreEstadioActual,

		c.CODIGO_MONEDA							AS Moneda,
		--INICIO: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019
		C.MONTO_CONTRATO						AS MontoContrato,
		C.MONTO_ACUMULADO						AS MontoAcumulado,
		(CASE   
		  WHEN c.CODIGO_MONEDA = 'PEN' THEN C.MONTO_ACUMULADO / @CAMBIO_SOLES
		  WHEN c.CODIGO_MONEDA = 'GYD' THEN C.MONTO_ACUMULADO * convert(float,@CAMBIO_GUYANA)  
		  WHEN c.CODIGO_MONEDA = 'USD' THEN C.MONTO_ACUMULADO 
	    END) as MontoAcumuladoCambio,
		--FIN: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019

		TS.VALOR                                AS TipoServicio,

		TC.VALOR								AS TipoContrato,
		       
		(CASE WHEN CHARINDEX('el pago de las facturas dentro de los',ISNULL(CD.CONTENIDO,'')) = 0 THEN '' 
          ELSE CTR.FN_OBTENER_NUMEROS(SUBSTRING(ISNULL(CD.CONTENIDO,''),CHARINDEX('el pago de las facturas dentro de los',ISNULL(CD.CONTENIDO,''))+38,20)) 
        END) 	                                AS DiasPagoFactura

FROM	CTR.CONTRATO C With (Nolock)

		LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP With (Nolock) ON FAP.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAP.CODIGO_TIPO_PARTICIPANTE = 'R' AND FAP.ESTADO_REGISTRO = '1'

		LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAPV With (Nolock) ON FAPV.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL 

								AND FAPV.CODIGO_TIPO_PARTICIPANTE = 'V' AND FAPV.ESTADO_REGISTRO = '1' 

		LEFT JOIN CTR.PROVEEDOR	P With (Nolock) ON P.CODIGO_PROVEEDOR = C.CODIGO_PROVEEDOR

		LEFT JOIN CTR.CONTRATO_DOCUMENTO CD With (Nolock) ON CD.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CD.ESTADO_REGISTRO = '1' AND CD.INDICADOR_ACTUAL = 1

		LEFT JOIN CTR.CONTRATO_ESTADIO CE With (Nolock) ON CE.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND CE.CODIGO_ESTADO_CONTRATO_ESTADIO = 'I'

		AND CE.ESTADO_REGISTRO = 1

		LEFT JOIN CTR.FLUJO_APROBACION_ESTADIO FAE With (Nolock) ON FAE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAE.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO AND FAE.ESTADO_REGISTRO = '1'

		LEFT JOIN @TIPO_SERVICIO TS ON TS.CODIGO = C.CODIGO_TIPO_REQUERIMIENTO

		LEFT JOIN @TIPO_CONTRATO TC ON TC.CODIGO COLLATE Modern_Spanish_CI_AS = C.CODIGO_TIPO_SERVICIO 
		

WHERE			(C.CODIGO_UNIDAD_OPERATIVA				=		@CODIGO_UNIDAD_OPERATIVA		OR @CODIGO_UNIDAD_OPERATIVA IS NULL)

		AND		(C.NUMERO_CONTRATO						=		@NUMERO_CONTRATO			OR ISNULL(@NUMERO_CONTRATO,'') = '')

		AND		(C.DESCRIPCION							LIKE	'%' + @DESCRIPCION + '%'	OR ISNULL(@DESCRIPCION, '') = '')

		AND		(C.CODIGO_TIPO_SERVICIO					=		@CODIGO_TIPO_SERVICIO			OR ISNULL(@CODIGO_TIPO_SERVICIO,'') = '')

		AND		(C.CODIGO_TIPO_REQUERIMIENTO			=		@CODIGO_TIPO_REQUERIMIENTO		OR ISNULL(@CODIGO_TIPO_REQUERIMIENTO,'') = '')							  	

		AND		(C.CODIGO_TIPO_DOCUMENTO				=		@CODIGO_TIPO_DOCUMENTO			OR ISNULL(@CODIGO_TIPO_DOCUMENTO,'') = '')							  	

		AND		(C.CODIGO_ESTADO						=		@CODIGO_ESTADO					OR ISNULL(@CODIGO_ESTADO,'') = '')							  			  	

		AND		(P.NUMERO_DOCUMENTO						=		@NUMERO_DOCUMENTO_PROVEEDOR				OR ISNULL(@NUMERO_DOCUMENTO_PROVEEDOR, '') = '')

		AND		(P.NOMBRE_COMERCIAL						LIKE	'%' + @NOMBRE_COMERCIAL_PROVEEDOR + '%'	OR ISNULL(@NOMBRE_COMERCIAL_PROVEEDOR, '') = '')

		AND		(C.FECHA_INICIO_VIGENCIA				>=		@FECHA_INICIO_VIGENCIA OR @FECHA_INICIO_VIGENCIA IS NULL) 

		AND		(C.FECHA_FIN_VIGENCIA					<=		@FECHA_FIN_VIGENCIA OR @FECHA_FIN_VIGENCIA IS NULL)

		AND		(C.ESTADO_REGISTRO = '1')

		AND		(@CONTENIDO_CONTRATO IS NULL			OR ISNULL(CD.CONTENIDO_BUSQUEDA,'')							LIKE	'%' + @CONTENIDO_CONTRATO + '%')

		AND		(@CODIGO_TRABAJADOR_RESPONSABLE IS NULL OR (  (CE.CODIGO_RESPONSABLE IS NOT NULL AND CE.CODIGO_RESPONSABLE = @CODIGO_TRABAJADOR_RESPONSABLE )  AND C.CODIGO_ESTADO  IN ('A','E')) )

		AND		(@NOMBRE_ESTADIO IS NULL OR (FAE.DESCRIPCION LIKE @NOMBRE_ESTADIO AND C.CODIGO_ESTADO = 'A'))

		AND		(@INDICADOR_FINALIZAR_APROBACION IS NULL OR (@INDICADOR_FINALIZAR_APROBACION = 'A' AND C.CODIGO_ESTADO = 'A' AND C.CODIGO_ESTADIO_ACTUAL IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO))

					OR (@INDICADOR_FINALIZAR_APROBACION = 'NA' AND (C.CODIGO_ESTADO = 'A') AND C.CODIGO_ESTADIO_ACTUAL NOT IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO)))

		AND		(C.MONTO_ACUMULADO			>=		@MONTO_INICIO OR @MONTO_INICIO IS NULL) 

		AND		(C.MONTO_ACUMULADO			<=		@MONTO_FIN    OR @MONTO_FIN IS NULL)

		AND		(C.CODIGO_MONEDA			=		@CODIGO_MONEDA			OR ISNULL(@CODIGO_MONEDA,'') = '')

ORDER BY  C.CODIGO_UNIDAD_OPERATIVA, C.DESCRIPCION DESC, C.NUMERO_ADENDA

END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_RPT_2]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


 

CREATE PROCEDURE [CTR].[USP_CONTRATO_RPT_2] --NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,null,NULL,NULL,NULL,NULL,NULL, NULL,NULL

(@CODIGO_UNIDAD_OPERATIVA		UNIQUEIDENTIFIER,

@NUMERO_CONTRATO				NVARCHAR(50),

@DESCRIPCION					NVARCHAR(255),

@CODIGO_TIPO_SERVICIO			NVARCHAR(5),

@CODIGO_TIPO_REQUERIMIENTO		NVARCHAR(5),

@CODIGO_TIPO_DOCUMENTO			NVARCHAR(5),

@CODIGO_ESTADO					NVARCHAR(5),

@NUMERO_DOCUMENTO_PROVEEDOR		NVARCHAR(20),

@NOMBRE_COMERCIAL_PROVEEDOR		NVARCHAR(255),

@FECHA_INICIO_VIGENCIA			DATETIME,

@FECHA_FIN_VIGENCIA				DATETIME,

@CONTENIDO_CONTRATO				NVARCHAR(MAX),

@CODIGO_TRABAJADOR_RESPONSABLE	UNIQUEIDENTIFIER,

@NOMBRE_ESTADIO					NVARCHAR(300),

@INDICADOR_FINALIZAR_APROBACION	NVARCHAR(10),

@MONTO_INICIO					NVARCHAR(20),

@MONTO_FIN						NVARCHAR(20),

@CODIGO_MONEDA					CHAR(3),

@CAMBIO_SOLES					NVARCHAR(10) = NULL,

@CAMBIO_GUYANA					NVARCHAR(10) = NULL)

AS

/**********************************************************************************************************************************

Nombre Objeto: CTR.USP_CONTRATO_RPT

Propósito:   Obtiene el listado del contrato  

Descripción de Parámetros: 

		@CODIGO_UNIDAD_OPERATIVA: Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.

		@NUMERO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa numero contrato.

		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.

		@CODIGO_TIPO_SERVICIO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo servicio.

		@CODIGO_TIPO_REQUERIMIENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo requerimiento.

		@CODIGO_TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.

		@CODIGO_ESTADO:	Parámetro de entrada de tipo nvarchar, que representa codigo estado.

		@NUMERO_DOCUMENTO_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa número de documento del proveedor.

		@NOMBRE_COMERCIAL_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa el nombre comercial del proveedor.

		@FECHA_INICIO_VIGENCIA:	Parámetro de entrada de tipo datetime, que representa fecha de inicio de vigencia del contrato.

		@FECHA_FIN_VIGENCIA:	Parámetro de entrada de tipo datetime, que representa fecha fin de vigencia del contrato.

		@CONTENIDO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa el contenido de contrato a buscar.

		@CODIGO_TRABAJADOR_RESPONSABLE: Parámetro de entrada de tipo UNIQUEIDENTIFIER, que representa el Código de Trabajador Responsable.

		@NOMBRE_ESTADIO: Parámetro de entrada de tipo NVARCHAR, que representa el Nombre del Estadio.

		@INDICADOR_FINALIZAR_APROBACION: Parámetro de entrada de tipo NVARCHAR, que representa el Indicador de Finalizar Aprobación.

Creado por: GMD

Fecha. Creación: 2015-08-25

Fecha. Actualización: 2017-11-27 Se agrega validación para obtener responsable para empresa vinculada

**********************************************************************************************************************************/



BEGIN


IF @NOMBRE_ESTADIO IS NOT NULL

	BEGIN

		SET @NOMBRE_ESTADIO = '%' + @NOMBRE_ESTADIO + '%'		

	END



DECLARE @TMP_ULTIMO_ESTADIO_CONTRATO CTR.LISTA_GUID

DECLARE @TIPO_SERVICIO TABLE(CODIGO NVARCHAR(255), VALOR  NVARCHAR(255))

DECLARE @TIPO_CONTRATO TABLE(CODIGO NVARCHAR(255), VALOR  NVARCHAR(255))



IF @INDICADOR_FINALIZAR_APROBACION = 'A' OR @INDICADOR_FINALIZAR_APROBACION = 'NA'

	BEGIN

		INSERT INTO @TMP_ULTIMO_ESTADIO_CONTRATO

		SELECT	(SELECT TOP 1 FAE.CODIGO_FLUJO_APROBACION_ESTADIO

				 FROM CTR.FLUJO_APROBACION_ESTADIO FAE 

				 WHERE FAE.CODIGO_FLUJO_APROBACION = FA.CODIGO_FLUJO_APROBACION AND FAE.ESTADO_REGISTRO = '1' 

				 ORDER BY ORDEN DESC) AS CODIGO_ULTIMO_ESTADIO

		FROM	CTR.FLUJO_APROBACION FA

		WHERE	FA.ESTADO_REGISTRO = '1'

	END

INSERT INTO @TIPO_SERVICIO (CODIGO, VALOR)
SELECT	CODIGO, VALOR
FROM	STRACON_POLITICAS.GRL.FN_LISTAR_VALORES_PARAMETRO('STR',0,'SGC','00013',2)

INSERT INTO @TIPO_CONTRATO (CODIGO, VALOR)
SELECT	CODIGO, VALOR
FROM	STRACON_POLITICAS.GRL.FN_LISTAR_VALORES_PARAMETRO('STR',0,'SGC','00014',2)





--INICIO: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019
SELECT	C.CODIGO_UNIDAD_OPERATIVA				AS CodigoUnidadOperativa,
		C.NUMERO_CONTRATO						AS NumeroContrato,
		C.NUMERO_ADENDA_CONCATENADO				AS NumeroAdendaConcatenado,
		C.DESCRIPCION							AS Descripcion,
        P.NUMERO_DOCUMENTO						AS NumeroDocumentoProveedor,
		P.NOMBRE_COMERCIAL						AS NombreComercial,
        C.FECHA_INICIO_VIGENCIA					AS FechaInicioVigencia,
		C.FECHA_FIN_VIGENCIA					AS FechaFinVigencia,
		C.CODIGO_TIPO_SERVICIO					AS CodigoTipoServicio,
		C.CODIGO_TIPO_REQUERIMIENTO				AS CodigoTipoRequerimiento,
		C.CODIGO_TIPO_DOCUMENTO					AS CodigoTipoDocumento,
		C.CODIGO_ESTADO							AS CodigoEstadoContrato,
		C.FECHA_RESOLUCION						AS FechaResolucion,
		C.CODIGO_ESTADO_EDICION					AS CodigoEstadoEdicion,
		C.NUMERO_ADENDA							AS Numero_Adenda,
		(CASE 
							WHEN C.CODIGO_ESTADO = 'A' THEN CASE 
							WHEN (EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA EM 
							WHERE EM.NUMERO_RUC = P.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND EM.ESTADO_REGISTRO = '1')) THEN ISNULL(CE.CODIGO_RESPONSABLE, FAP.CODIGO_TRABAJADOR)
							ELSE CE.CODIGO_RESPONSABLE END
							ELSE NULL END)	AS CodigoTrabajadorResponsable,

		CE.FECHA_CREACION						AS FechaCreacionEstadioActual,
		C.USUARIO_CREACION						AS UsuarioCreacionContrato,
		C.FECHA_CREACION						AS FechaCreacionContrato,
		FAE.DESCRIPCION							AS NombreEstadioActual,
		C.MONTO_CONTRATO						AS MontoContrato,
		C.MONTO_ACUMULADO						AS MontoAcumulado,
		C.CODIGO_MONEDA							AS Moneda,
		TS.VALOR                                AS TipoServicio,
		TC.VALOR								AS TipoContrato,	       
		(CASE WHEN CHARINDEX('el pago de las facturas dentro de los',ISNULL(CD.CONTENIDO,'')) = 0 THEN '' 
          ELSE CTR.FN_OBTENER_NUMEROS(SUBSTRING(ISNULL(CD.CONTENIDO,''),CHARINDEX('el pago de las facturas dentro de los',ISNULL(CD.CONTENIDO,''))+38,20)) 
        END) 	                                AS DiasPagoFactura
		INTO	#TMP_REPORTE
		FROM	CTR.CONTRATO C With (Nolock)
		LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP With (Nolock) ON FAP.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAP.CODIGO_TIPO_PARTICIPANTE = 'R' AND FAP.ESTADO_REGISTRO = '1'
		LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAPV With (Nolock) ON FAPV.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL 
								AND FAPV.CODIGO_TIPO_PARTICIPANTE = 'V' AND FAPV.ESTADO_REGISTRO = '1' 
		LEFT JOIN CTR.PROVEEDOR	P With (Nolock) ON P.CODIGO_PROVEEDOR = C.CODIGO_PROVEEDOR
		LEFT JOIN CTR.CONTRATO_DOCUMENTO CD With (Nolock) ON CD.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CD.ESTADO_REGISTRO = '1' AND CD.INDICADOR_ACTUAL = 1
		LEFT JOIN CTR.CONTRATO_ESTADIO CE With (Nolock) ON CE.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND CE.CODIGO_ESTADO_CONTRATO_ESTADIO = 'I'
		AND CE.ESTADO_REGISTRO = 1
		LEFT JOIN CTR.FLUJO_APROBACION_ESTADIO FAE With (Nolock) ON FAE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAE.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO AND FAE.ESTADO_REGISTRO = '1'
		LEFT JOIN @TIPO_SERVICIO TS ON TS.CODIGO = C.CODIGO_TIPO_REQUERIMIENTO
		LEFT JOIN @TIPO_CONTRATO TC ON TC.CODIGO COLLATE Modern_Spanish_CI_AS = C.CODIGO_TIPO_SERVICIO 
		WHERE			(C.CODIGO_UNIDAD_OPERATIVA				=		@CODIGO_UNIDAD_OPERATIVA		OR @CODIGO_UNIDAD_OPERATIVA IS NULL)
		AND		(C.NUMERO_CONTRATO						=		@NUMERO_CONTRATO			OR ISNULL(@NUMERO_CONTRATO,'') = '')
		AND		(C.DESCRIPCION							LIKE	'%' + @DESCRIPCION + '%'	OR ISNULL(@DESCRIPCION, '') = '')
		AND		(C.CODIGO_TIPO_SERVICIO					=		@CODIGO_TIPO_SERVICIO			OR ISNULL(@CODIGO_TIPO_SERVICIO,'') = '')
		AND		(C.CODIGO_TIPO_REQUERIMIENTO			=		@CODIGO_TIPO_REQUERIMIENTO		OR ISNULL(@CODIGO_TIPO_REQUERIMIENTO,'') = '')							  	
		AND		(C.CODIGO_TIPO_DOCUMENTO				=		@CODIGO_TIPO_DOCUMENTO			OR ISNULL(@CODIGO_TIPO_DOCUMENTO,'') = '')							  	
		AND		(C.CODIGO_ESTADO						=		@CODIGO_ESTADO					OR ISNULL(@CODIGO_ESTADO,'') = '')							  			  	
		AND		(P.NUMERO_DOCUMENTO						=		@NUMERO_DOCUMENTO_PROVEEDOR				OR ISNULL(@NUMERO_DOCUMENTO_PROVEEDOR, '') = '')
		AND		(P.NOMBRE_COMERCIAL						LIKE	'%' + @NOMBRE_COMERCIAL_PROVEEDOR + '%'	OR ISNULL(@NOMBRE_COMERCIAL_PROVEEDOR, '') = '')
		AND		(C.FECHA_INICIO_VIGENCIA				>=		@FECHA_INICIO_VIGENCIA OR @FECHA_INICIO_VIGENCIA IS NULL) 
		AND		(C.FECHA_FIN_VIGENCIA					<=		@FECHA_FIN_VIGENCIA OR @FECHA_FIN_VIGENCIA IS NULL)
		AND		(C.ESTADO_REGISTRO = '1')
		AND		(@CONTENIDO_CONTRATO IS NULL			OR ISNULL(CD.CONTENIDO_BUSQUEDA,'')							LIKE	'%' + @CONTENIDO_CONTRATO + '%')
		AND		(@CODIGO_TRABAJADOR_RESPONSABLE IS NULL OR (  (CE.CODIGO_RESPONSABLE IS NOT NULL AND CE.CODIGO_RESPONSABLE = @CODIGO_TRABAJADOR_RESPONSABLE )  AND C.CODIGO_ESTADO  IN ('A','E')) )
		AND		(@NOMBRE_ESTADIO IS NULL OR (FAE.DESCRIPCION LIKE @NOMBRE_ESTADIO AND C.CODIGO_ESTADO = 'A'))
		AND		(@INDICADOR_FINALIZAR_APROBACION IS NULL OR (@INDICADOR_FINALIZAR_APROBACION = 'A' AND C.CODIGO_ESTADO = 'A' AND C.CODIGO_ESTADIO_ACTUAL IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO))
					OR (@INDICADOR_FINALIZAR_APROBACION = 'NA' AND (C.CODIGO_ESTADO = 'A') AND C.CODIGO_ESTADIO_ACTUAL NOT IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO)))
		AND		(C.MONTO_ACUMULADO			>=		@MONTO_INICIO OR @MONTO_INICIO IS NULL) 
		AND		(C.MONTO_ACUMULADO			<=		@MONTO_FIN    OR @MONTO_FIN IS NULL)
		AND		(C.CODIGO_MONEDA			=		@CODIGO_MONEDA			OR ISNULL(@CODIGO_MONEDA,'') = '')
--FIN: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019




SELECT	

		C.CODIGO_UNIDAD_OPERATIVA				AS CodigoUnidadOperativa,

		C.NUMERO_CONTRATO						AS NumeroContrato,

		C.NUMERO_ADENDA_CONCATENADO				AS NumeroAdendaConcatenado,

		C.DESCRIPCION							AS Descripcion,

        P.NUMERO_DOCUMENTO						AS NumeroDocumentoProveedor,

		P.NOMBRE_COMERCIAL						AS NombreComercial,

        C.FECHA_INICIO_VIGENCIA					AS FechaInicioVigencia,

		--INICIO: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019
		--C.FECHA_FIN_VIGENCIA					AS FechaFinVigencia,		
		C.NUMERO_ADENDA							AS Numero_Adenda,
		--CASE WHEN C.NUMERO_ADENDA = 0 THEN C.FECHA_FIN_VIGENCIA ELSE (
		--SELECT	MAX(FechaFinVigencia) FROM #TMP_REPORTE WHERE Numero_Adenda != 0 
		--) END AS FechaFinVigencia,		
		(SELECT	MAX(FechaFinVigencia) FROM #TMP_REPORTE WHERE Numero_Adenda != 0) AS FechaFinVigencia,
		(SELECT DATEDIFF(day, C.FECHA_INICIO_VIGENCIA, C.FECHA_CREACION)) AS Periodo_Sin_Contrato,
		(SELECT TOP 1 POLITICA.NOMBRES + ' ' + POLITICA.APELLIDO_PATERNO + ' ' + POLITICA.APELLIDO_MATERNO
		 FROM VENEZUELA.STRACON_POLITICAS.GRL.TRABAJADOR AS POLITICA
		 INNER JOIN CTR.CONTRATO AS CTT ON POLITICA.CODIGO_TRABAJADOR = C.CODIGOREQUERIDO
		 WHERE CTT.CODIGOREQUERIDO = C.CODIGOREQUERIDO) AS Requerido_Por,	 
		--FIN: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019
		C.CODIGO_TIPO_SERVICIO					AS CodigoTipoServicio,
	
		C.CODIGO_TIPO_REQUERIMIENTO				AS CodigoTipoRequerimiento,

		C.CODIGO_TIPO_DOCUMENTO					AS CodigoTipoDocumento,

		C.CODIGO_ESTADO							AS CodigoEstadoContrato,

		C.FECHA_RESOLUCION						AS FechaResolucion,

		C.CODIGO_ESTADO_EDICION					AS CodigoEstadoEdicion,

		(CASE 

							WHEN C.CODIGO_ESTADO = 'A' THEN 

									CASE 

									WHEN (EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA EM 

									WHERE EM.NUMERO_RUC = P.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND EM.ESTADO_REGISTRO = '1')) THEN ISNULL(CE.CODIGO_RESPONSABLE, FAP.CODIGO_TRABAJADOR)

									ELSE CE.CODIGO_RESPONSABLE END

							ELSE NULL END)						AS CodigoTrabajadorResponsable,

		CE.FECHA_CREACION						AS FechaCreacionEstadioActual,

		C.USUARIO_CREACION						AS UsuarioCreacionContrato,

		C.FECHA_CREACION						AS FechaCreacionContrato,

		FAE.DESCRIPCION							AS NombreEstadioActual,

		c.CODIGO_MONEDA							AS Moneda,
		--INICIO: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019
		C.MONTO_CONTRATO						AS MontoContrato,
		C.MONTO_ACUMULADO						AS MontoAcumulado,
		(CASE   
		  WHEN c.CODIGO_MONEDA = 'PEN' THEN C.MONTO_ACUMULADO / @CAMBIO_SOLES
		  WHEN c.CODIGO_MONEDA = 'GYD' THEN C.MONTO_ACUMULADO * convert(float,@CAMBIO_GUYANA)  
		  WHEN c.CODIGO_MONEDA = 'USD' THEN C.MONTO_ACUMULADO 
	    END) as MontoAcumuladoCambio,
		--FIN: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019

		TS.VALOR                                AS TipoServicio,

		TC.VALOR								AS TipoContrato,
		       
		(CASE WHEN CHARINDEX('el pago de las facturas dentro de los',ISNULL(CD.CONTENIDO,'')) = 0 THEN '' 
          ELSE CTR.FN_OBTENER_NUMEROS(SUBSTRING(ISNULL(CD.CONTENIDO,''),CHARINDEX('el pago de las facturas dentro de los',ISNULL(CD.CONTENIDO,''))+38,20)) 
        END) 	                                AS DiasPagoFactura

FROM	CTR.CONTRATO C With (Nolock)

		LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP With (Nolock) ON FAP.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAP.CODIGO_TIPO_PARTICIPANTE = 'R' AND FAP.ESTADO_REGISTRO = '1'

		LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAPV With (Nolock) ON FAPV.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL 

								AND FAPV.CODIGO_TIPO_PARTICIPANTE = 'V' AND FAPV.ESTADO_REGISTRO = '1' 

		LEFT JOIN CTR.PROVEEDOR	P With (Nolock) ON P.CODIGO_PROVEEDOR = C.CODIGO_PROVEEDOR

		LEFT JOIN CTR.CONTRATO_DOCUMENTO CD With (Nolock) ON CD.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CD.ESTADO_REGISTRO = '1' AND CD.INDICADOR_ACTUAL = 1

		LEFT JOIN CTR.CONTRATO_ESTADIO CE With (Nolock) ON CE.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND CE.CODIGO_ESTADO_CONTRATO_ESTADIO = 'I'

		AND CE.ESTADO_REGISTRO = 1

		LEFT JOIN CTR.FLUJO_APROBACION_ESTADIO FAE With (Nolock) ON FAE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAE.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO AND FAE.ESTADO_REGISTRO = '1'

		LEFT JOIN @TIPO_SERVICIO TS ON TS.CODIGO = C.CODIGO_TIPO_REQUERIMIENTO

		LEFT JOIN @TIPO_CONTRATO TC ON TC.CODIGO COLLATE Modern_Spanish_CI_AS = C.CODIGO_TIPO_SERVICIO 
		

WHERE			(C.CODIGO_UNIDAD_OPERATIVA				=		@CODIGO_UNIDAD_OPERATIVA		OR @CODIGO_UNIDAD_OPERATIVA IS NULL)

		AND		(C.NUMERO_CONTRATO						=		@NUMERO_CONTRATO			OR ISNULL(@NUMERO_CONTRATO,'') = '')

		AND		(C.DESCRIPCION							LIKE	'%' + @DESCRIPCION + '%'	OR ISNULL(@DESCRIPCION, '') = '')

		AND		(C.CODIGO_TIPO_SERVICIO					=		@CODIGO_TIPO_SERVICIO			OR ISNULL(@CODIGO_TIPO_SERVICIO,'') = '')

		AND		(C.CODIGO_TIPO_REQUERIMIENTO			=		@CODIGO_TIPO_REQUERIMIENTO		OR ISNULL(@CODIGO_TIPO_REQUERIMIENTO,'') = '')							  	

		AND		(C.CODIGO_TIPO_DOCUMENTO				=		@CODIGO_TIPO_DOCUMENTO			OR ISNULL(@CODIGO_TIPO_DOCUMENTO,'') = '')							  	

		AND		(C.CODIGO_ESTADO						=		@CODIGO_ESTADO					OR ISNULL(@CODIGO_ESTADO,'') = '')							  			  	

		AND		(P.NUMERO_DOCUMENTO						=		@NUMERO_DOCUMENTO_PROVEEDOR				OR ISNULL(@NUMERO_DOCUMENTO_PROVEEDOR, '') = '')

		AND		(P.NOMBRE_COMERCIAL						LIKE	'%' + @NOMBRE_COMERCIAL_PROVEEDOR + '%'	OR ISNULL(@NOMBRE_COMERCIAL_PROVEEDOR, '') = '')

		AND		(C.FECHA_INICIO_VIGENCIA				>=		@FECHA_INICIO_VIGENCIA OR @FECHA_INICIO_VIGENCIA IS NULL) 

		AND		(C.FECHA_FIN_VIGENCIA					<=		@FECHA_FIN_VIGENCIA OR @FECHA_FIN_VIGENCIA IS NULL)

		AND		(C.ESTADO_REGISTRO = '1')

		AND		(@CONTENIDO_CONTRATO IS NULL			OR ISNULL(CD.CONTENIDO_BUSQUEDA,'')							LIKE	'%' + @CONTENIDO_CONTRATO + '%')

		AND		(@CODIGO_TRABAJADOR_RESPONSABLE IS NULL OR (  (CE.CODIGO_RESPONSABLE IS NOT NULL AND CE.CODIGO_RESPONSABLE = @CODIGO_TRABAJADOR_RESPONSABLE )  AND C.CODIGO_ESTADO  IN ('A','E')) )

		AND		(@NOMBRE_ESTADIO IS NULL OR (FAE.DESCRIPCION LIKE @NOMBRE_ESTADIO AND C.CODIGO_ESTADO = 'A'))

		AND		(@INDICADOR_FINALIZAR_APROBACION IS NULL OR (@INDICADOR_FINALIZAR_APROBACION = 'A' AND C.CODIGO_ESTADO = 'A' AND C.CODIGO_ESTADIO_ACTUAL IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO))

					OR (@INDICADOR_FINALIZAR_APROBACION = 'NA' AND (C.CODIGO_ESTADO = 'A') AND C.CODIGO_ESTADIO_ACTUAL NOT IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO)))

		AND		(C.MONTO_ACUMULADO			>=		@MONTO_INICIO OR @MONTO_INICIO IS NULL) 

		AND		(C.MONTO_ACUMULADO			<=		@MONTO_FIN    OR @MONTO_FIN IS NULL)

		AND		(C.CODIGO_MONEDA			=		@CODIGO_MONEDA			OR ISNULL(@CODIGO_MONEDA,'') = '')
		--INICIO: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019
		--AND C.NUMERO_ADENDA IN (0, (SELECT	MAX(Numero_Adenda)FROM	#TMP_REPORTE))
		AND C.NUMERO_ADENDA IN (0)
		--FIN: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019

ORDER BY  C.CODIGO_UNIDAD_OPERATIVA, C.DESCRIPCION DESC, C.NUMERO_ADENDA

END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_RPT_SIN_ADENDAS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SELECT * FROM [CTR].[CONTRATO] WHERE NUMERO_CONTRATO = 'ST.10101001.OCH.19.006'
--SELECT * FROM [CTR].[CONTRATO] WHERE NUMERO_CONTRATO = 'STGYM.9998.CAV.18.001'

CREATE PROCEDURE [CTR].[USP_CONTRATO_RPT_SIN_ADENDAS] --NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL,null,NULL,NULL,NULL,NULL,NULL, NULL,NULL

(@CODIGO_UNIDAD_OPERATIVA		UNIQUEIDENTIFIER,

@NUMERO_CONTRATO				NVARCHAR(50),

@DESCRIPCION					NVARCHAR(255),

@CODIGO_TIPO_SERVICIO			NVARCHAR(5),

@CODIGO_TIPO_REQUERIMIENTO		NVARCHAR(5),

@CODIGO_TIPO_DOCUMENTO			NVARCHAR(5),

@CODIGO_ESTADO					NVARCHAR(5),

@NUMERO_DOCUMENTO_PROVEEDOR		NVARCHAR(20),

@NOMBRE_COMERCIAL_PROVEEDOR		NVARCHAR(255),

@FECHA_INICIO_VIGENCIA			DATETIME,

@FECHA_FIN_VIGENCIA				DATETIME,

@CONTENIDO_CONTRATO				NVARCHAR(MAX),

@CODIGO_TRABAJADOR_RESPONSABLE	UNIQUEIDENTIFIER,

@NOMBRE_ESTADIO					NVARCHAR(300),

@INDICADOR_FINALIZAR_APROBACION	NVARCHAR(10),

@MONTO_INICIO					NVARCHAR(20),

@MONTO_FIN						NVARCHAR(20),

@CODIGO_MONEDA					CHAR(3),

@CAMBIO_SOLES					NVARCHAR(10) = NULL,

@CAMBIO_GUYANA					NVARCHAR(10) = NULL)

AS

/**********************************************************************************************************************************

Nombre Objeto: CTR.USP_CONTRATO_RPT

Propósito:   Obtiene el listado del contrato  

Descripción de Parámetros: 

		@CODIGO_UNIDAD_OPERATIVA: Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.

		@NUMERO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa numero contrato.

		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.

		@CODIGO_TIPO_SERVICIO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo servicio.

		@CODIGO_TIPO_REQUERIMIENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo requerimiento.

		@CODIGO_TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.

		@CODIGO_ESTADO:	Parámetro de entrada de tipo nvarchar, que representa codigo estado.

		@NUMERO_DOCUMENTO_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa número de documento del proveedor.

		@NOMBRE_COMERCIAL_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa el nombre comercial del proveedor.

		@FECHA_INICIO_VIGENCIA:	Parámetro de entrada de tipo datetime, que representa fecha de inicio de vigencia del contrato.

		@FECHA_FIN_VIGENCIA:	Parámetro de entrada de tipo datetime, que representa fecha fin de vigencia del contrato.

		@CONTENIDO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa el contenido de contrato a buscar.

		@CODIGO_TRABAJADOR_RESPONSABLE: Parámetro de entrada de tipo UNIQUEIDENTIFIER, que representa el Código de Trabajador Responsable.

		@NOMBRE_ESTADIO: Parámetro de entrada de tipo NVARCHAR, que representa el Nombre del Estadio.

		@INDICADOR_FINALIZAR_APROBACION: Parámetro de entrada de tipo NVARCHAR, que representa el Indicador de Finalizar Aprobación.

Creado por: GMD

Fecha. Creación: 2015-08-25

Fecha. Actualización: 2017-11-27 Se agrega validación para obtener responsable para empresa vinculada

**********************************************************************************************************************************/



BEGIN


IF @NOMBRE_ESTADIO IS NOT NULL

	BEGIN

		SET @NOMBRE_ESTADIO = '%' + @NOMBRE_ESTADIO + '%'		

	END



DECLARE @TMP_ULTIMO_ESTADIO_CONTRATO CTR.LISTA_GUID

DECLARE @TIPO_SERVICIO TABLE(CODIGO NVARCHAR(255), VALOR  NVARCHAR(255))

DECLARE @TIPO_CONTRATO TABLE(CODIGO NVARCHAR(255), VALOR  NVARCHAR(255))



IF @INDICADOR_FINALIZAR_APROBACION = 'A' OR @INDICADOR_FINALIZAR_APROBACION = 'NA'

	BEGIN

		INSERT INTO @TMP_ULTIMO_ESTADIO_CONTRATO

		SELECT	(SELECT TOP 1 FAE.CODIGO_FLUJO_APROBACION_ESTADIO

				 FROM CTR.FLUJO_APROBACION_ESTADIO FAE 

				 WHERE FAE.CODIGO_FLUJO_APROBACION = FA.CODIGO_FLUJO_APROBACION AND FAE.ESTADO_REGISTRO = '1' 

				 ORDER BY ORDEN DESC) AS CODIGO_ULTIMO_ESTADIO

		FROM	CTR.FLUJO_APROBACION FA

		WHERE	FA.ESTADO_REGISTRO = '1'

	END

INSERT INTO @TIPO_SERVICIO (CODIGO, VALOR)
SELECT	CODIGO, VALOR
FROM	STRACON_POLITICAS.GRL.FN_LISTAR_VALORES_PARAMETRO('STR',0,'SGC','00013',2)

INSERT INTO @TIPO_CONTRATO (CODIGO, VALOR)
SELECT	CODIGO, VALOR
FROM	STRACON_POLITICAS.GRL.FN_LISTAR_VALORES_PARAMETRO('STR',0,'SGC','00014',2)





--INICIO: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019
SELECT	C.CODIGO_UNIDAD_OPERATIVA				AS CodigoUnidadOperativa,
		C.NUMERO_CONTRATO						AS NumeroContrato,
		C.NUMERO_ADENDA_CONCATENADO				AS NumeroAdendaConcatenado,
		C.DESCRIPCION							AS Descripcion,
        P.NUMERO_DOCUMENTO						AS NumeroDocumentoProveedor,
		P.NOMBRE_COMERCIAL						AS NombreComercial,
        C.FECHA_INICIO_VIGENCIA					AS FechaInicioVigencia,
		C.FECHA_FIN_VIGENCIA					AS FechaFinVigencia,
		C.CODIGO_TIPO_SERVICIO					AS CodigoTipoServicio,
		C.CODIGO_TIPO_REQUERIMIENTO				AS CodigoTipoRequerimiento,
		C.CODIGO_TIPO_DOCUMENTO					AS CodigoTipoDocumento,
		C.CODIGO_ESTADO							AS CodigoEstadoContrato,
		C.FECHA_RESOLUCION						AS FechaResolucion,
		C.CODIGO_ESTADO_EDICION					AS CodigoEstadoEdicion,
		C.NUMERO_ADENDA							AS Numero_Adenda,
		(CASE 
							WHEN C.CODIGO_ESTADO = 'A' THEN CASE 
							WHEN (EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA EM 
							WHERE EM.NUMERO_RUC = P.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND EM.ESTADO_REGISTRO = '1')) THEN ISNULL(CE.CODIGO_RESPONSABLE, FAP.CODIGO_TRABAJADOR)
							ELSE CE.CODIGO_RESPONSABLE END
							ELSE NULL END)	AS CodigoTrabajadorResponsable,

		CE.FECHA_CREACION						AS FechaCreacionEstadioActual,
		C.USUARIO_CREACION						AS UsuarioCreacionContrato,
		C.FECHA_CREACION						AS FechaCreacionContrato,
		FAE.DESCRIPCION							AS NombreEstadioActual,
		C.MONTO_CONTRATO						AS MontoContrato,
		C.MONTO_ACUMULADO						AS MontoAcumulado,
		C.CODIGO_MONEDA							AS Moneda,
		TS.VALOR                                AS TipoServicio,
		TC.VALOR								AS TipoContrato,	       
		(CASE WHEN CHARINDEX('el pago de las facturas dentro de los',ISNULL(CD.CONTENIDO,'')) = 0 THEN '' 
          ELSE CTR.FN_OBTENER_NUMEROS(SUBSTRING(ISNULL(CD.CONTENIDO,''),CHARINDEX('el pago de las facturas dentro de los',ISNULL(CD.CONTENIDO,''))+38,20)) 
        END) 	                                AS DiasPagoFactura
		INTO	#TMP_REPORTE
		FROM	CTR.CONTRATO C With (Nolock)
		LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP With (Nolock) ON FAP.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAP.CODIGO_TIPO_PARTICIPANTE = 'R' AND FAP.ESTADO_REGISTRO = '1'
		LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAPV With (Nolock) ON FAPV.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL 
								AND FAPV.CODIGO_TIPO_PARTICIPANTE = 'V' AND FAPV.ESTADO_REGISTRO = '1' 
		LEFT JOIN CTR.PROVEEDOR	P With (Nolock) ON P.CODIGO_PROVEEDOR = C.CODIGO_PROVEEDOR
		LEFT JOIN CTR.CONTRATO_DOCUMENTO CD With (Nolock) ON CD.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CD.ESTADO_REGISTRO = '1' AND CD.INDICADOR_ACTUAL = 1
		LEFT JOIN CTR.CONTRATO_ESTADIO CE With (Nolock) ON CE.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND CE.CODIGO_ESTADO_CONTRATO_ESTADIO = 'I'
		AND CE.ESTADO_REGISTRO = 1
		LEFT JOIN CTR.FLUJO_APROBACION_ESTADIO FAE With (Nolock) ON FAE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAE.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO AND FAE.ESTADO_REGISTRO = '1'
		LEFT JOIN @TIPO_SERVICIO TS ON TS.CODIGO = C.CODIGO_TIPO_REQUERIMIENTO
		LEFT JOIN @TIPO_CONTRATO TC ON TC.CODIGO COLLATE Modern_Spanish_CI_AS = C.CODIGO_TIPO_SERVICIO 
		WHERE			(C.CODIGO_UNIDAD_OPERATIVA				=		@CODIGO_UNIDAD_OPERATIVA		OR @CODIGO_UNIDAD_OPERATIVA IS NULL)
		AND		(C.NUMERO_CONTRATO						=		@NUMERO_CONTRATO			OR ISNULL(@NUMERO_CONTRATO,'') = '')
		AND		(C.DESCRIPCION							LIKE	'%' + @DESCRIPCION + '%'	OR ISNULL(@DESCRIPCION, '') = '')
		AND		(C.CODIGO_TIPO_SERVICIO					=		@CODIGO_TIPO_SERVICIO			OR ISNULL(@CODIGO_TIPO_SERVICIO,'') = '')
		AND		(C.CODIGO_TIPO_REQUERIMIENTO			=		@CODIGO_TIPO_REQUERIMIENTO		OR ISNULL(@CODIGO_TIPO_REQUERIMIENTO,'') = '')							  	
		AND		(C.CODIGO_TIPO_DOCUMENTO				=		@CODIGO_TIPO_DOCUMENTO			OR ISNULL(@CODIGO_TIPO_DOCUMENTO,'') = '')							  	
		AND		(C.CODIGO_ESTADO						=		@CODIGO_ESTADO					OR ISNULL(@CODIGO_ESTADO,'') = '')							  			  	
		AND		(P.NUMERO_DOCUMENTO						=		@NUMERO_DOCUMENTO_PROVEEDOR				OR ISNULL(@NUMERO_DOCUMENTO_PROVEEDOR, '') = '')
		AND		(P.NOMBRE_COMERCIAL						LIKE	'%' + @NOMBRE_COMERCIAL_PROVEEDOR + '%'	OR ISNULL(@NOMBRE_COMERCIAL_PROVEEDOR, '') = '')
		AND		(C.FECHA_INICIO_VIGENCIA				>=		@FECHA_INICIO_VIGENCIA OR @FECHA_INICIO_VIGENCIA IS NULL) 
		AND		(C.FECHA_FIN_VIGENCIA					<=		@FECHA_FIN_VIGENCIA OR @FECHA_FIN_VIGENCIA IS NULL)
		AND		(C.ESTADO_REGISTRO = '1')
		AND		(@CONTENIDO_CONTRATO IS NULL			OR ISNULL(CD.CONTENIDO_BUSQUEDA,'')							LIKE	'%' + @CONTENIDO_CONTRATO + '%')
		AND		(@CODIGO_TRABAJADOR_RESPONSABLE IS NULL OR (  (CE.CODIGO_RESPONSABLE IS NOT NULL AND CE.CODIGO_RESPONSABLE = @CODIGO_TRABAJADOR_RESPONSABLE )  AND C.CODIGO_ESTADO  IN ('A','E')) )
		AND		(@NOMBRE_ESTADIO IS NULL OR (FAE.DESCRIPCION LIKE @NOMBRE_ESTADIO AND C.CODIGO_ESTADO = 'A'))
		AND		(@INDICADOR_FINALIZAR_APROBACION IS NULL OR (@INDICADOR_FINALIZAR_APROBACION = 'A' AND C.CODIGO_ESTADO = 'A' AND C.CODIGO_ESTADIO_ACTUAL IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO))
					OR (@INDICADOR_FINALIZAR_APROBACION = 'NA' AND (C.CODIGO_ESTADO = 'A') AND C.CODIGO_ESTADIO_ACTUAL NOT IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO)))
		AND		(C.MONTO_ACUMULADO			>=		@MONTO_INICIO OR @MONTO_INICIO IS NULL) 
		AND		(C.MONTO_ACUMULADO			<=		@MONTO_FIN    OR @MONTO_FIN IS NULL)
		AND		(C.CODIGO_MONEDA			=		@CODIGO_MONEDA			OR ISNULL(@CODIGO_MONEDA,'') = '')
--FIN: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019


SELECT	

		C.CODIGO_UNIDAD_OPERATIVA				AS CodigoUnidadOperativa,

		C.NUMERO_CONTRATO						AS NumeroContrato,

		C.NUMERO_ADENDA_CONCATENADO				AS NumeroAdendaConcatenado,

		C.DESCRIPCION							AS Descripcion,

        P.NUMERO_DOCUMENTO						AS NumeroDocumentoProveedor,

		P.NOMBRE_COMERCIAL						AS NombreComercial,

        C.FECHA_INICIO_VIGENCIA					AS FechaInicioVigencia,

		--INICIO: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019
		--C.FECHA_FIN_VIGENCIA					AS FechaFinVigencia,		
		C.NUMERO_ADENDA							AS Numero_Adenda,
		--CASE WHEN C.NUMERO_ADENDA = 0 THEN C.FECHA_FIN_VIGENCIA ELSE (
		--SELECT	MAX(FechaFinVigencia) FROM #TMP_REPORTE WHERE Numero_Adenda != 0 
		--) END AS FechaFinVigencia,
		
		--(SELECT   FechaFinVigencia =  
		--	  CASE (SELECT COUNT(*) FROM #TMP_REPORTE WHERE NumeroContrato = C.NUMERO_CONTRATO)  
		--		 WHEN 1 THEN (SELECT MAX(FechaFinVigencia) FROM #TMP_REPORTE WHERE NumeroContrato = C.NUMERO_CONTRATO)
		--		 ELSE (SELECT MAX(FechaFinVigencia) FROM #TMP_REPORTE WHERE Numero_Adenda != 0 AND NumeroContrato = C.NUMERO_CONTRATO)
		--	  END,  
		--   FechaFinVigencia  
		--FROM Production.Product),

				(SELECT
			  CASE (SELECT COUNT(*) FROM #TMP_REPORTE WHERE NumeroContrato = C.NUMERO_CONTRATO)  
				 WHEN 1 THEN (SELECT MAX(FechaFinVigencia) FROM #TMP_REPORTE WHERE NumeroContrato = C.NUMERO_CONTRATO)
				 ELSE (SELECT MAX(FechaFinVigencia) FROM #TMP_REPORTE WHERE Numero_Adenda != 0 AND NumeroContrato = C.NUMERO_CONTRATO)
			  END)  
		   FechaFinVigencia,
	
		--(SELECT	MAX(FechaFinVigencia) FROM #TMP_REPORTE WHERE Numero_Adenda != 0 AND NumeroContrato = C.NUMERO_CONTRATO) AS FechaFinVigencia,
		(SELECT DATEDIFF(day, C.FECHA_INICIO_VIGENCIA, C.FECHA_CREACION)) AS Periodo_Sin_Contrato,
		(SELECT TOP 1 POLITICA.NOMBRES + ' ' + POLITICA.APELLIDO_PATERNO + ' ' + POLITICA.APELLIDO_MATERNO
		 FROM ECUADOR.STRACON_POLITICAS.GRL.TRABAJADOR AS POLITICA
		 INNER JOIN CTR.CONTRATO AS CTT ON POLITICA.CODIGO_TRABAJADOR = C.CODIGOREQUERIDO
		 WHERE CTT.CODIGOREQUERIDO = C.CODIGOREQUERIDO) AS Requerido_Por,	 
		--FIN: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019
		C.CODIGO_TIPO_SERVICIO					AS CodigoTipoServicio,
	
		C.CODIGO_TIPO_REQUERIMIENTO				AS CodigoTipoRequerimiento,

		C.CODIGO_TIPO_DOCUMENTO					AS CodigoTipoDocumento,

		C.CODIGO_ESTADO							AS CodigoEstadoContrato,

		C.FECHA_RESOLUCION						AS FechaResolucion,

		C.CODIGO_ESTADO_EDICION					AS CodigoEstadoEdicion,

		(CASE 

							WHEN C.CODIGO_ESTADO = 'A' THEN 

									CASE 

									WHEN (EXISTS (SELECT 1 FROM CTR.EMPRESA_VINCULADA EM 

									WHERE EM.NUMERO_RUC = P.NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND EM.ESTADO_REGISTRO = '1')) THEN ISNULL(CE.CODIGO_RESPONSABLE, FAP.CODIGO_TRABAJADOR)

									ELSE CE.CODIGO_RESPONSABLE END

							ELSE NULL END)						AS CodigoTrabajadorResponsable,

		CE.FECHA_CREACION						AS FechaCreacionEstadioActual,

		C.USUARIO_CREACION						AS UsuarioCreacionContrato,

		C.FECHA_CREACION						AS FechaCreacionContrato,

		FAE.DESCRIPCION							AS NombreEstadioActual,

		c.CODIGO_MONEDA							AS Moneda,
		--INICIO: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019
		C.MONTO_CONTRATO						AS MontoContrato,
		C.MONTO_ACUMULADO						AS MontoAcumulado,
		(CASE   
		  WHEN c.CODIGO_MONEDA = 'PEN' THEN C.MONTO_ACUMULADO / @CAMBIO_SOLES
		  WHEN c.CODIGO_MONEDA = 'GYD' THEN C.MONTO_ACUMULADO * convert(float,@CAMBIO_GUYANA)  
		  WHEN c.CODIGO_MONEDA = 'USD' THEN C.MONTO_ACUMULADO 
	    END) as MontoAcumuladoCambio,
		--FIN: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019

		TS.VALOR                                AS TipoServicio,

		TC.VALOR								AS TipoContrato,
		       
		(CASE WHEN CHARINDEX('el pago de las facturas dentro de los',ISNULL(CD.CONTENIDO,'')) = 0 THEN '' 
          ELSE CTR.FN_OBTENER_NUMEROS(SUBSTRING(ISNULL(CD.CONTENIDO,''),CHARINDEX('el pago de las facturas dentro de los',ISNULL(CD.CONTENIDO,''))+38,20)) 
        END) 	                                AS DiasPagoFactura

FROM	CTR.CONTRATO C With (Nolock)

		LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP With (Nolock) ON FAP.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAP.CODIGO_TIPO_PARTICIPANTE = 'R' AND FAP.ESTADO_REGISTRO = '1'

		LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAPV With (Nolock) ON FAPV.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL 

								AND FAPV.CODIGO_TIPO_PARTICIPANTE = 'V' AND FAPV.ESTADO_REGISTRO = '1' 

		LEFT JOIN CTR.PROVEEDOR	P With (Nolock) ON P.CODIGO_PROVEEDOR = C.CODIGO_PROVEEDOR

		LEFT JOIN CTR.CONTRATO_DOCUMENTO CD With (Nolock) ON CD.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CD.ESTADO_REGISTRO = '1' AND CD.INDICADOR_ACTUAL = 1

		LEFT JOIN CTR.CONTRATO_ESTADIO CE With (Nolock) ON CE.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND CE.CODIGO_ESTADO_CONTRATO_ESTADIO = 'I'

		AND CE.ESTADO_REGISTRO = 1

		LEFT JOIN CTR.FLUJO_APROBACION_ESTADIO FAE With (Nolock) ON FAE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAE.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO AND FAE.ESTADO_REGISTRO = '1'

		LEFT JOIN @TIPO_SERVICIO TS ON TS.CODIGO = C.CODIGO_TIPO_REQUERIMIENTO

		LEFT JOIN @TIPO_CONTRATO TC ON TC.CODIGO COLLATE Modern_Spanish_CI_AS = C.CODIGO_TIPO_SERVICIO 
		

WHERE			(C.CODIGO_UNIDAD_OPERATIVA				=		@CODIGO_UNIDAD_OPERATIVA		OR @CODIGO_UNIDAD_OPERATIVA IS NULL)

		AND		(C.NUMERO_CONTRATO						=		@NUMERO_CONTRATO			OR ISNULL(@NUMERO_CONTRATO,'') = '')

		AND		(C.DESCRIPCION							LIKE	'%' + @DESCRIPCION + '%'	OR ISNULL(@DESCRIPCION, '') = '')

		AND		(C.CODIGO_TIPO_SERVICIO					=		@CODIGO_TIPO_SERVICIO			OR ISNULL(@CODIGO_TIPO_SERVICIO,'') = '')

		AND		(C.CODIGO_TIPO_REQUERIMIENTO			=		@CODIGO_TIPO_REQUERIMIENTO		OR ISNULL(@CODIGO_TIPO_REQUERIMIENTO,'') = '')							  	

		AND		(C.CODIGO_TIPO_DOCUMENTO				=		@CODIGO_TIPO_DOCUMENTO			OR ISNULL(@CODIGO_TIPO_DOCUMENTO,'') = '')							  	

		AND		(C.CODIGO_ESTADO						=		@CODIGO_ESTADO					OR ISNULL(@CODIGO_ESTADO,'') = '')							  			  	

		AND		(P.NUMERO_DOCUMENTO						=		@NUMERO_DOCUMENTO_PROVEEDOR				OR ISNULL(@NUMERO_DOCUMENTO_PROVEEDOR, '') = '')

		AND		(P.NOMBRE_COMERCIAL						LIKE	'%' + @NOMBRE_COMERCIAL_PROVEEDOR + '%'	OR ISNULL(@NOMBRE_COMERCIAL_PROVEEDOR, '') = '')

		AND		(C.FECHA_INICIO_VIGENCIA				>=		@FECHA_INICIO_VIGENCIA OR @FECHA_INICIO_VIGENCIA IS NULL) 

		AND		(C.FECHA_FIN_VIGENCIA					<=		@FECHA_FIN_VIGENCIA OR @FECHA_FIN_VIGENCIA IS NULL)

		AND		(C.ESTADO_REGISTRO = '1')

		AND		(@CONTENIDO_CONTRATO IS NULL			OR ISNULL(CD.CONTENIDO_BUSQUEDA,'')							LIKE	'%' + @CONTENIDO_CONTRATO + '%')

		AND		(@CODIGO_TRABAJADOR_RESPONSABLE IS NULL OR (  (CE.CODIGO_RESPONSABLE IS NOT NULL AND CE.CODIGO_RESPONSABLE = @CODIGO_TRABAJADOR_RESPONSABLE )  AND C.CODIGO_ESTADO  IN ('A','E')) )

		AND		(@NOMBRE_ESTADIO IS NULL OR (FAE.DESCRIPCION LIKE @NOMBRE_ESTADIO AND C.CODIGO_ESTADO = 'A'))

		AND		(@INDICADOR_FINALIZAR_APROBACION IS NULL OR (@INDICADOR_FINALIZAR_APROBACION = 'A' AND C.CODIGO_ESTADO = 'A' AND C.CODIGO_ESTADIO_ACTUAL IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO))

					OR (@INDICADOR_FINALIZAR_APROBACION = 'NA' AND (C.CODIGO_ESTADO = 'A') AND C.CODIGO_ESTADIO_ACTUAL NOT IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO)))

		AND		(C.MONTO_ACUMULADO			>=		@MONTO_INICIO OR @MONTO_INICIO IS NULL) 

		AND		(C.MONTO_ACUMULADO			<=		@MONTO_FIN    OR @MONTO_FIN IS NULL)

		AND		(C.CODIGO_MONEDA			=		@CODIGO_MONEDA			OR ISNULL(@CODIGO_MONEDA,'') = '')
		--INICIO: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019
		--AND C.NUMERO_ADENDA IN (0, (SELECT	MAX(Numero_Adenda)FROM	#TMP_REPORTE))
		AND C.NUMERO_ADENDA IN (0)
		--FIN: CAMBIO A SOLICITUD DE MERLYN MANRIQUE 12/08/2019

ORDER BY  C.CODIGO_UNIDAD_OPERATIVA, C.DESCRIPCION DESC, C.NUMERO_ADENDA

END


GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_SEL] --'a5e73eeb-fae5-4266-8f10-030dd1f59d68',NULL,NULL,NULL,NULL,NULL,NULL,'STGYM.1000.OCH.17.029',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,-1
--'41dbc8e7-3c14-4d8a-90c0-1ee2f0d82274',NULL,NULL,NULL,NULL,NULL,NULL,'STGYM.30033 - 1022.CAES.18.008',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,-1
(
@CODIGO_CONTRATO					UNIQUEIDENTIFIER,
@CODIGO_UNIDAD_OPERATIVA			UNIQUEIDENTIFIER,
@CODIGO_PLANTILLA					UNIQUEIDENTIFIER,
@CODIGO_TIPO_SERVICIO				NVARCHAR(5),
@CODIGO_TIPO_REQUERIMIENTO			NVARCHAR(5),
@CODIGO_TIPO_DOCUMENTO				NVARCHAR(5),
@CODIGO_ESTADO						NVARCHAR(5),
@NUMERO_CONTRATO					NVARCHAR(50),
@NUMERO_ADENDA_CONCATENADO			NVARCHAR(80),
@NUMERO_DOCUMENTO					NVARCHAR(20),
@NOMBRE_PROVEEDOR					NVARCHAR(255),
@DESCRIPCION						NVARCHAR(255),
@INDICADOR_TODA_UNIDAD_OPERATIVA	BIT,
@LISTA_UNIDAD_OPERATIVA_ACCESO		CTR.LISTA_GUID READONLY,
@CODIGO_ESTADO_EDICION				NVARCHAR(255),
@CONTENIDO_CONTRATO					NVARCHAR(MAX),
@CODIGO_TRABAJADOR_RESPONSABLE		UNIQUEIDENTIFIER,
@NOMBRE_ESTADIO						NVARCHAR(300),
@INDICADOR_FINALIZAR_APROBACION		NVARCHAR(10),
@PageNo								INT = 1,
@PageSize							BIGINT = -1)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_SEL
Propósito:   Obtiene el listado del contrato  
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
		@CODIGO_UNIDAD_OPERATIVA: Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@CODIGO_PLANTILLA: Parámetro de entrada de tipo uniqueidentifier, que representa código de plantilla.
		@CODIGO_TIPO_SERVICIO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo servicio.
		@CODIGO_TIPO_REQUERIMIENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo requerimiento.
		@CODIGO_TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.
		@CODIGO_ESTADO:	Parámetro de entrada de tipo nvarchar, que representa codigo estado.
		@NUMERO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa numero contrato.
		@NUMERO_ADENDA_CONCATENADO:	Parámetro de entrada de tipo nvarchar, que representa numero de adenda concatenado.
		@NUMERO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa numero documento.
		@NOMBRE_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa nombre proveedor.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
		@INDICADOR_TODA_UNIDAD_OPERATIVA: Parámetro de entrada de tipo bit, que indica si el trabajadador puede acceder a todas las unidades operativas o no.
		@LISTA_UNIDAD_OPERATIVA_ACCESO Parámetro de entrada de tipo CTR.LISTA_GUID, que representa una lista de códigos de unidades operativas.
		@CODIGO_ESTADO_EDICION: Parámetro de entrada de tipo nvarchar, que representa un estado de edición.
		@DESCRIPCION_CONTRATO: Parámetro de entrada de tipo nvarchar, que representa la descripción del contrato.
		@CODIGO_TRABAJADOR_RESPONSABLE: Parámetro de entrada de tipo UNIQUEIDENTIFIER, que representa el Código de Trabajador Responsable.
		@NOMBRE_ESTADIO: Parámetro de entrada de tipo NVARCHAR, que representa el Nombre del Estadio.
		@INDICADOR_FINALIZAR_APROBACION: Parámetro de entrada de tipo NVARCHAR, que representa el Indicador de Finalizar Aprobación.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 2017-01-10 Se agrega retornar EsFlexible
**********************************************************************************************************************************/
BEGIN

DECLARE @lPageNbr	INT,
		@lPageSize	INT,
		@lFirstRec	INT,
		@lLAStRec	INT

IF(@CONTENIDO_CONTRATO IS NOT NULL)
	BEGIN
		SET @CONTENIDO_CONTRATO = '%' + @CONTENIDO_CONTRATO + '%'
	END

IF @NOMBRE_ESTADIO IS NOT NULL
	BEGIN
		SET @NOMBRE_ESTADIO = '%' + @NOMBRE_ESTADIO + '%'		
	END

DECLARE @TMP_ULTIMO_ESTADIO_CONTRATO CTR.LISTA_GUID

IF @INDICADOR_FINALIZAR_APROBACION = 'A' OR @INDICADOR_FINALIZAR_APROBACION = 'NA'
	BEGIN
		INSERT INTO @TMP_ULTIMO_ESTADIO_CONTRATO
		SELECT	(SELECT TOP 1 FAE.CODIGO_FLUJO_APROBACION_ESTADIO
				 FROM CTR.FLUJO_APROBACION_ESTADIO FAE 
				 WHERE FAE.CODIGO_FLUJO_APROBACION = FA.CODIGO_FLUJO_APROBACION AND FAE.ESTADO_REGISTRO = '1' 
				 ORDER BY ORDEN DESC) AS CODIGO_ULTIMO_ESTADIO
		FROM	CTR.FLUJO_APROBACION FA
		WHERE	FA.ESTADO_REGISTRO = '1'
	END

SET @lPageNbr = @PageNo
SET @lPageSize = @PageSize

SET @lFirstRec = (@lPageNbr - 1) * @lPageSize
SET @lLAStRec = (@lPageNbr * @lPageSize + 1);

WITH	CTE_Results AS (SELECT ROW_NUMBER() OVER (ORDER BY C.DESCRIPCION ASC) AS RowNumber,
        COUNT(*) OVER() AS RowsTotal,
        CONVERT(VARCHAR, COUNT(*) OVER())		AS RowId,
        C.CODIGO_CONTRATO						AS CodigoContrato,
        C.CODIGO_UNIDAD_OPERATIVA				AS CodigoUnidadOperativa,
        C.CODIGO_PROVEEDOR						AS CodigoProveedor,
		C.NUMERO_CONTRATO						AS NumeroContrato,
		C.NUMERO_ADENDA_CONCATENADO				AS NumeroAdendaConcatenado,
		C.DESCRIPCION							AS Descripcion,
		C.CODIGO_TIPO_SERVICIO					AS CodigoTipoServicio,
		C.CODIGO_TIPO_REQUERIMIENTO				AS CodigoTipoRequerimiento,
		C.CODIGO_TIPO_DOCUMENTO					AS CodigoTipoDocumento,
        C.FECHA_INICIO_VIGENCIA					AS FechaInicioVigencia,
		C.FECHA_FIN_VIGENCIA					AS FechaFinVigencia,
		CASE C.CODIGO_ESTADO WHEN 'RS' THEN 2 WHEN 'V' THEN (CASE WHEN C.FECHA_FIN_VIGENCIA >= CONVERT(VARCHAR(10),GETDATE(),112) THEN 1 ELSE 0 END) ELSE 0 END AS ValidacionResolucion,
		ISNULL(C.FECHA_RESOLUCION,'31001230')	AS FechaResolucion,
		C.CODIGO_MONEDA							AS CodigoMoneda,
		C.MONTO_CONTRATO						AS MontoContrato,
		C.CODIGO_ESTADO							AS CodigoEstadoContrato,
		C.CODIGO_PLANTILLA						AS CodigoPlantilla,
		C.CODIGO_CONTRATO_PRINCIPAL				AS CodigoContratoPrincipal,
		C.CODIGO_ESTADO_EDICION					AS CodigoEstadoEdicion,
		C.COMENTARIO_MODIFICACION				AS ComentarioModificacion,
		C.RESPUESTA_MODIFICACION				AS RespuestaModificacion,
		C.CODIGO_ESTADIO_ACTUAL					AS CodigoEstadioActual,
		P.NUMERO_DOCUMENTO						AS NumeroDocumentoProveedor,
		P.NOMBRE								AS NombreProveedor,
		(CASE 
		WHEN C.CODIGO_ESTADO = 'A' THEN FAP.CODIGO_TRABAJADOR
		ELSE NULL END)							AS CodigoTrabajadorResponsable,
		CE.FECHA_CREACION						AS FechaCreacionEstadioActual,
		PL.INDICADOR_ADHESION					AS IndicadorAdhesion,
		C.ESTADO_REGISTRO						AS EstadoRegistro,
		C.FECHA_CREACION						AS FechaCreacion,
		C.USUARIO_CREACION						AS UsuarioCreacion,
		FAE.DESCRIPCION							AS NombreEstadioActual,
		ISNULL(C.ES_FLEXIBLE,0)					AS EsFlexible
FROM	CTR.CONTRATO C
LEFT JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP ON FAP.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAP.CODIGO_TIPO_PARTICIPANTE = 'R'
 AND FAP.ESTADO_REGISTRO = '1'
LEFT JOIN CTR.PROVEEDOR	P ON P.CODIGO_PROVEEDOR = C.CODIGO_PROVEEDOR
LEFT JOIN CTR.PLANTILLA PL ON PL.CODIGO_PLANTILLA = C.CODIGO_PLANTILLA
LEFT JOIN CTR.CONTRATO_DOCUMENTO CD ON CD.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CD.ESTADO_REGISTRO = '1' AND CD.INDICADOR_ACTUAL = 1
LEFT JOIN CTR.[CONTRATO_ESTADIO] CE ON CE.CODIGO_CONTRATO = C.CODIGO_CONTRATO AND CE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND CE.CODIGO_ESTADO_CONTRATO_ESTADIO = 'I'
LEFT JOIN CTR.FLUJO_APROBACION_ESTADIO FAE ON FAE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL AND FAE.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO AND FAE.ESTADO_REGISTRO = '1'
WHERE	(C.CODIGO_CONTRATO						=		@CODIGO_CONTRATO				OR @CODIGO_CONTRATO IS NULL)
AND		(C.CODIGO_UNIDAD_OPERATIVA				=		@CODIGO_UNIDAD_OPERATIVA		OR @CODIGO_UNIDAD_OPERATIVA IS NULL)
AND		(C.CODIGO_PLANTILLA						=		@CODIGO_PLANTILLA				OR @CODIGO_PLANTILLA IS NULL)
AND		(C.CODIGO_TIPO_SERVICIO					=		@CODIGO_TIPO_SERVICIO			OR ISNULL(@CODIGO_TIPO_SERVICIO,'') = '')
AND		(C.CODIGO_TIPO_REQUERIMIENTO			=		@CODIGO_TIPO_REQUERIMIENTO		OR ISNULL(@CODIGO_TIPO_REQUERIMIENTO,'') = '')							  	
AND		(C.CODIGO_TIPO_DOCUMENTO				=		@CODIGO_TIPO_DOCUMENTO			OR ISNULL(@CODIGO_TIPO_DOCUMENTO,'') = '')							  	
AND		(C.CODIGO_ESTADO						=		@CODIGO_ESTADO					OR ISNULL(@CODIGO_ESTADO,'') = '')							  	
--AND		(replace (C.NUMERO_CONTRATO,' ','')		=	 	@NUMERO_CONTRATO				OR ISNULL(@NUMERO_CONTRATO,'') = '')
--AND		(replace (C.NUMERO_ADENDA_CONCATENADO,' ','')		=		@NUMERO_ADENDA_CONCATENADO		OR ISNULL(@NUMERO_ADENDA_CONCATENADO,'') = '')
AND		(C.NUMERO_CONTRATO		=	 	LTRIM(RTRIM(@NUMERO_CONTRATO))				OR ISNULL(LTRIM(RTRIM(@NUMERO_CONTRATO)),'') = '')
AND		(C.NUMERO_ADENDA_CONCATENADO		=		LTRIM(RTRIM(@NUMERO_ADENDA_CONCATENADO))		OR ISNULL(LTRIM(RTRIM(@NUMERO_ADENDA_CONCATENADO)),'') = '')							  	
AND		(P.NUMERO_DOCUMENTO						=		@NUMERO_DOCUMENTO				OR ISNULL(@NUMERO_DOCUMENTO, '') = '')
AND		(P.NOMBRE								LIKE	'%' + @NOMBRE_PROVEEDOR + '%'	OR ISNULL(@NOMBRE_PROVEEDOR, '') = '')
AND		(C.DESCRIPCION							LIKE	'%' + @DESCRIPCION + '%'	OR ISNULL(@DESCRIPCION, '') = '')
AND		(@INDICADOR_TODA_UNIDAD_OPERATIVA		IS NULL								OR @INDICADOR_TODA_UNIDAD_OPERATIVA = 1		
		OR EXISTS (SELECT 1 FROM @LISTA_UNIDAD_OPERATIVA_ACCESO WHERE CODIGO = C.CODIGO_UNIDAD_OPERATIVA)
)
AND		(C.CODIGO_ESTADO_EDICION			=		@CODIGO_ESTADO_EDICION			OR ISNULL(@CODIGO_ESTADO_EDICION,'') = '')
AND		(C.ESTADO_REGISTRO = '1')
AND		(@CONTENIDO_CONTRATO IS NULL			OR ISNULL(CD.CONTENIDO_BUSQUEDA,'')							LIKE	@CONTENIDO_CONTRATO)
AND		(@CODIGO_TRABAJADOR_RESPONSABLE IS NULL OR (FAP.CODIGO_TRABAJADOR = @CODIGO_TRABAJADOR_RESPONSABLE AND C.CODIGO_ESTADO = 'A'))
AND		(@NOMBRE_ESTADIO IS NULL OR (FAE.DESCRIPCION LIKE @NOMBRE_ESTADIO AND C.CODIGO_ESTADO = 'A'))
AND		(@INDICADOR_FINALIZAR_APROBACION IS NULL OR (@INDICADOR_FINALIZAR_APROBACION = 'A' AND C.CODIGO_ESTADO = 'A' AND C.CODIGO_ESTADIO_ACTUAL IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO))
			OR (@INDICADOR_FINALIZAR_APROBACION = 'NA' AND (C.CODIGO_ESTADO = 'A') AND C.CODIGO_ESTADIO_ACTUAL NOT IN (SELECT CODIGO FROM @TMP_ULTIMO_ESTADIO_CONTRATO)))
)

SELECT	RowNumber,
		RowsTotal,
		RowId,
        CodigoContrato,
        CodigoUnidadOperativa,
		--NombreUnidadOperativa,
        CodigoProveedor,
		NumeroContrato,
		NumeroAdendaConcatenado,
		Descripcion,
		CodigoTipoServicio,
		CodigoTipoRequerimiento,
		CodigoTipoDocumento,
		FechaInicioVigencia,
		FechaFinVigencia,
		ValidacionResolucion,
		FechaResolucion,
		CodigoMoneda,
		MontoContrato,
		CodigoEstadoContrato,
		CodigoPlantilla,
		CodigoContratoPrincipal,
		CodigoEstadoEdicion,
		ComentarioModificacion,
		RespuestaModificacion,
		CodigoEstadioActual,
		NumeroDocumentoProveedor,
		NombreProveedor,
		CodigoTrabajadorResponsable,
		IndicadorAdhesion,
		EstadoRegistro,
		FechaCreacion,
		UsuarioCreacion,
		FechaCreacionEstadioActual,
		NombreEstadioActual,
		EsFlexible
FROM    CTE_Results
WHERE   @PageSize < 0 OR ( RowNumber > @lFirstRec AND RowNumber < @lLAStRec)  
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATO_UPD]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATO_UPD]
(
	@CODIGO_CONTRATO UNIQUEIDENTIFIER,
	@CODIGO_ESTADO NVARCHAR(5),
	@CODIGO_ESTADO_EDICION NVARCHAR(5),
	@NUMERO_CONTRATO VARCHAR(50),
	@COMENTARIO_MODIFICACION VARCHAR(MAX),
	@USUARIO_MODIFICACION NVARCHAR(50),
	@FECHA_MODIFICACION DATETIME,
	@TERMINAL_MODIFICACION NVARCHAR(50),
	@ES_FLEXIBLE BIT
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATO_UPD
Propósito:   Permite modificar un registro de un contrato  
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.		
		@CODIGO_ESTADO:	Parámetro de entrada de tipo nvarchar, que representa codigo estado.		
		@CODIGO_ESTADO_EDICION:	Parámetro de entrada de tipo nvarchar, que representa codigo estado edicion.
		@COMENTARIO_MODIFICACION:	Parámetro de entrada de tipo varchar, que representa comentario modificacion.
		@RESPUESTA_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa respuesta modificacion.
		@CODIGO_FLUJO_APROBACION:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.
		@CODIGO_ESTADIO_ACTUAL:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo estadio actual.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@FECHA_MODIFICACION:	Parámetro de entrada de tipo datetime, que representa fecha creacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
		@ES_FLEXIBLE: Parámetro de entrada de tipo bit, que representa si el contrato es flexible.		
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 2016-01-10 Se agrega parametro @ES_FLEXIBLE				   
**********************************************************************************************************************************/
BEGIN
UPDATE CTR.CONTRATO
SET		
	CODIGO_ESTADO = @CODIGO_ESTADO,	
	CODIGO_ESTADO_EDICION = @CODIGO_ESTADO_EDICION,
	NUMERO_CONTRATO = @NUMERO_CONTRATO,
	COMENTARIO_MODIFICACION = @COMENTARIO_MODIFICACION,
	USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
	FECHA_MODIFICACION = @FECHA_MODIFICACION,
	TERMINAL_MODIFICACION = @TERMINAL_MODIFICACION,
	ES_FLEXIBLE = @ES_FLEXIBLE	
WHERE CODIGO_CONTRATO = @CODIGO_CONTRATO

END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATOS_ESTADIO_NOTIFICACION_UPD]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATOS_ESTADIO_NOTIFICACION_UPD]
(		
	@CODIGO_CONTRATO_ESTADIO nvarchar(50),
	@USER_UPDATE nvarchar(50),
	@TERMINAL_UPDATE nvarchar(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATOS_ESTADIO_NOTIFICACION_UPD
Propósito:  Actualiza las notificaciones de los contratos estadios. 
Descripción de Parámetros: 
		@CODIGO_CONTRATO_ESTADIO:	Parámetro de entrada de tipo nvarchar, que representa codigo contrato estadio.
		@USER_UPDATE:	Parámetro de entrada de tipo nvarchar, que representa user update.
		@TERMINAL_UPDATE:	Parámetro de entrada de tipo nvarchar, que representa terminal update.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/

BEGIN
UPDATE [CTR].[CONTRATO_ESTADIO]
			SET FECHA_PRIMERA_NOTIFICACION = (CASE WHEN FECHA_PRIMERA_NOTIFICACION IS NULL THEN GETDATE() ELSE FECHA_PRIMERA_NOTIFICACION END ),
				  FECHA_ULTIMA_NOTIFICACION = GETDATE(),
				  USUARIO_MODIFICACION=@USER_UPDATE,
				  TERMINAL_MODIFICACION=@TERMINAL_UPDATE
			WHERE CODIGO_CONTRATO_ESTADIO=@CODIGO_CONTRATO_ESTADIO 
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATOS_ESTADIO_RPT]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATOS_ESTADIO_RPT]
@CODIGO_FLUJO_APROBACION_ESTADIO uniqueidentifier,
@FECHA_INICIO datetime,
@FECHA_FIN datetime
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATOS_ESTADIO_RPT
Propósito:  Aprueba los estadios de los contratos. 
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACION_ESTADIO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.
		@FECHA_INICIO:	Parámetro de entrada de tipo datetime, que representa fecha inicio.
		@FECHA_FIN:	Parámetro de entrada de tipo datetime, que representa fecha fin.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN		
	SELECT 	NUMERO_CONTRATO=ISNULL(CT.NUMERO_CONTRATO,''), 
				RUC_PROVEEDOR=PR.NUMERO_DOCUMENTO,
				NOMBRE_PROVEEDOR= PR.NOMBRE,
				FECHA_ESTADIO=CONVERT(VARCHAR(10),CE.FECHA_INGRESO,103)
			FROM CTR.CONTRATO_ESTADIO CE (NOLOCK) INNER JOIN CTR.CONTRATO CT (NOLOCK)
	ON (CE.CODIGO_CONTRATO=CT.CODIGO_CONTRATO ) INNER JOIN CTR.PROVEEDOR PR (NOLOCK)
	ON (CT.CODIGO_PROVEEDOR=PR.CODIGO_PROVEEDOR) 
	WHERE CT.CODIGO_ESTADIO_ACTUAL=@CODIGO_FLUJO_APROBACION_ESTADIO 
			AND ( CE.FECHA_INGRESO >= @FECHA_INICIO OR @FECHA_INICIO IS NULL)
			AND ( CE.FECHA_INGRESO <=@FECHA_FIN OR @FECHA_FIN IS NULL)						
			AND CE.ESTADO_REGISTRO='1'
			AND CE.CODIGO_ESTADO_CONTRATO_ESTADIO='I'			
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATOS_PENDIENTES_ELABORAR]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATOS_PENDIENTES_ELABORAR]
@RUC_PROVEEDOR NVARCHAR(15),
@NOMBRE_PROVEEDOR NVARCHAR(30),
@TIPO_ORDEN NVARCHAR(5),
@PERIODO_ANIO INT,
@PERIODO_MES INT,
@MONEDA varchar(3)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATOS_PENDIENTES_ELABORAR
Propósito:  Muestra los contrato pendiees eborar 
Descripción de Parámetros: 
		@RUC_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa ruc proveedor.
		@NOMBRE_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa nombre proveedor.
		@TIPO_ORDEN:	Parámetro de entrada de tipo nvarchar, que representa tipo orden.
		@PERIODO_ANIO:	Parámetro de entrada de tipo int, que representa periodo anio.
		@PERIODO_MES:	Parámetro de entrada de tipo int, que representa periodo mes.
		@MONEDA:	Parámetro de entrada de tipo varchar, que representa moneda.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

select @RUC_PROVEEDOR='%'+isnull(@RUC_PROVEEDOR,'')+'%', 
		  @NOMBRE_PROVEEDOR='%'+isnull(@NOMBRE_PROVEEDOR,'')+'%',
		  @TIPO_ORDEN = ISNULL(@TIPO_ORDEN,'')+'%',
		  @MONEDA = ISNULL(@MONEDA,'')+'%'

	select RUC_PROVEEDOR= P.NUMERO_DOCUMENTO,
			  P.NOMBRE,	
			  ANIO=YEAR(PA.FECHA_FIN) ,
			  MES = MONTH(PA.FECHA_FIN),
			  PA.CODIGO_TIPO_ORDEN,
			  PA.CODIGO_MONEDA,
			  PA.MONTO_ACUMULADO
		from [CTR].[PROVEEDOR_ACUMULADO] PA (nolock)  inner join CTR.PROVEEDOR P (NOLOCK)
ON ( PA.CODIGO_PROVEEDOR=P.CODIGO_PROVEEDOR )		
where PA.ESTADO_REGISTRO='1' AND
		  PA.INDICADOR_LIMITE_ALCANZADO=1 AND	
		  P.NUMERO_DOCUMENTO LIKE @RUC_PROVEEDOR AND
		  P.NOMBRE LIKE @NOMBRE_PROVEEDOR AND
		  PA.CODIGO_TIPO_ORDEN LIKE @TIPO_ORDEN AND
		  PA.CODIGO_MONEDA LIKE @MONEDA AND
		  YEAR(PA.FECHA_FIN) =@PERIODO_ANIO AND
		  (MONTH(PA.FECHA_FIN) = @PERIODO_MES OR @PERIODO_MES=0 OR @PERIODO_MES IS NULL)
END

GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATOS_POR_VENCER_RPT]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATOS_POR_VENCER_RPT]
@CODIGO_UNIDAD_OPERATIVA UNIQUEIDENTIFIER = null,
@FECHA_INICIO VARCHAR(8),
@FECHA_FIN VARCHAR(8),
@ESTADO NVARCHAR(5),
@NUMDIAS_ROJO INT,
@NUMDIAS_AMBAR INT
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATOS_POR_VENCER_RPT
Propósito:  Muestra el estadio actual de los contratos. 
Descripción de Parámetros: 
		@CODIGO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@FECHA_INICIO:	Parámetro de entrada de tipo datetime, que representa fecha inicio.
		@FECHA_FIN:	Parámetro de entrada de tipo datetime, que representa fecha fin.
		@ESTADO:	Parámetro de entrada de tipo nvarchar, que representa estado.
		@NUMDIAS_ROJO:	Parámetro de entrada de tipo int, que representa numdias rojo.
		@NUMDIAS_AMBAR:	Parámetro de entrada de tipo int, que representa numdias ambar.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

SELECT DISTINCT CODIGO_CONTRATO 
INTO #TEMPORAL
FROM CTR.CONTRATO 
WHERE ESTADO_REGISTRO = 1 
  AND CODIGO_ESTADO = @ESTADO
  AND FECHA_FIN_VIGENCIA BETWEEN CONVERT(SMALLDATETIME,@FECHA_INICIO) AND CONVERT(SMALLDATETIME,@FECHA_FIN)
  AND ISNULL(NUMERO_CONTRATO,'') <> '' 
  AND (@CODIGO_UNIDAD_OPERATIVA IS NULL OR CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA)

SELECT 
CT.CODIGO_UNIDAD_OPERATIVA,
UP.NOMBRE AS UNIDAD_OPERATIVA,
CT.CODIGO_CONTRATO,
CT.NUMERO_CONTRATO,
ISNULL(CT.NUMERO_ADENDA_CONCATENADO,'') AS NUMERO_ADENDA,
RUC_PROVEEDOR=PR.NUMERO_DOCUMENTO,
NOMBRE_PROVEEDOR= PR.NOMBRE,
FECHA_VENCIMIENTO = CONVERT(VARCHAR(10),CT.FECHA_FIN_VIGENCIA,103),
DIAS_VENCIMIENTO = (CASE WHEN DATEDIFF(DD,GETDATE(),CT.FECHA_FIN_VIGENCIA) >=0 THEN CONVERT(nVARCHAR(5),DATEDIFF(DD,GETDATE(),CT.FECHA_FIN_VIGENCIA)) ELSE ' ' END),
SEMAFORO = (CASE WHEN DATEDIFF(DD,GETDATE(),CT.FECHA_FIN_VIGENCIA) BETWEEN 0 AND 15 THEN 1--'RED' 
			WHEN DATEDIFF(DD,GETDATE(),CT.FECHA_FIN_VIGENCIA) BETWEEN 16 AND 30 THEN 2--'YELLOW' 
			WHEN DATEDIFF(DD,GETDATE(),CT.FECHA_FIN_VIGENCIA) > 30 THEN 3--'GREEN' 
			ELSE 0--'NO COLOR'
			END)
FROM  CTR.CONTRATO CT (NOLOCK) 
INNER JOIN CTR.PROVEEDOR PR (NOLOCK) ON CT.CODIGO_PROVEEDOR = PR.CODIGO_PROVEEDOR 
INNER JOIN #TEMPORAL TMP ON CT.CODIGO_CONTRATO = TMP.CODIGO_CONTRATO
INNER JOIN STRACON_POLITICAS.GRL.UNIDAD_OPERATIVA UP ON UP.CODIGO_UNIDAD_OPERATIVA = CT.CODIGO_UNIDAD_OPERATIVA
ORDER BY CT.NUMERO_CONTRATO, CT.FECHA_FIN_VIGENCIA ASC

DROP TABLE #TEMPORAL

END
GO
/****** Object:  StoredProcedure [CTR].[USP_CONTRATOS_PROVEEDOR_ORACLE_WS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_CONTRATOS_PROVEEDOR_ORACLE_WS]
AS
BEGIN
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONTRATOS_PROVEEDOR_ORACLE_WS
Propósito:  Web Service 
Descripción de Parámetros: 
         <<None>>
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
DECLARE 
	@FechaInicio datetime, @FechaFin datetime, @rowIni int, @rowFin int			  
	
	TRUNCATE TABLE TMP.ACUMULADO_PROVEEDOR
	TRUNCATE TABLE TMP.CONTRATOS_NOTIFICAR

	SELECT @FechaInicio =CONVERT(DATETIME,CONVERT(VARCHAR(4),YEAR(GETDATE()))+'-01-01'),
				 @FechaFin = GETDATE()

select rucProveedor=RUC_PROVEEDOR,codigoTipoOrden=CODIGO_TIPO_ORDEN,
		  numeroOrden=NUMERO_ORDEN,fechaOrden=FECHA_ORDEN,
		  codigoMoneda=CODIGOMONEDA,monto=MONTO
		INTO  #temp_infoProveedor
		from TMP.PROVEEDOR_ORDENES_COMPRA (NOLOCK)
		

select rucProveedor,  codigoTipoOrden,		  
		  codigoMoneda, sum(monto) as TotalProveedor
			into #temp_totalProvedor_actual
		  from #temp_infoProveedor
		  group by rucProveedor, codigoTipoOrden,	 codigoMoneda
		  

select rucProveedor=PR.NUMERO_DOCUMENTO,
		   codigoTipoOrden=PA.CODIGO_TIPO_ORDEN,
		   codigoMoneda=PA.CODIGO_MONEDA,
		   TotalAcumuladoProveedor=SUM(PA.MONTO_ACUMULADO) 
		   into #temp_totalProvedor_acumulado
	 from CTR.PROVEEDOR_ACUMULADO PA (nolock) inner join CTR.PROVEEDOR  PR (NOLOCK)
	 ON ( PA.CODIGO_PROVEEDOR=PR.CODIGO_PROVEEDOR )
where PA.FECHA_FIN between @FechaInicio and @FechaFin and PA.ESTADO_REGISTRO='1'
	GROUP BY PR.NUMERO_DOCUMENTO, PA.CODIGO_TIPO_ORDEN, 
					 PA.CODIGO_MONEDA


select rowid=IDENTITY(int, 1,1),	
		   PA.rucProveedor, 
		   PA.codigoTipoOrden, 
		   PA.codigoMoneda,
		  MontoProveedor =  (PA.TotalProveedor - isnull(PM.TotalAcumuladoProveedor,0) ),
		  Existe = -1
		 Into #temp_resumen	
		  from #temp_totalProvedor_actual PA left join #temp_totalProvedor_acumulado PM
		  on (PA.rucProveedor=PM.rucProveedor AND PA.codigoTipoOrden=PM.codigoTipoOrden
		  AND PA.codigoMoneda=PM.codigoMoneda)
	  
select @rowIni=min(rowid), @rowFin=max(rowid) from #temp_resumen
while @rowIni<=@rowFin
begin		
			if exists ( select TP.rowid from TMP.MONTO_ACUMULADO_CONTRATO (NOLOCK) mn inner join  #temp_resumen tp
									on (mn.CODIGO_MONEDA=tp.codigoMoneda)
									where tp.rowid=@rowIni and tp.MontoProveedor>=mn.MONTO_CONTRATO )
				BEGIN
					
					if exists ( SELECT   PR.CODIGO_PROVEEDOR FROM #temp_resumen TP INNER JOIN CTR.PROVEEDOR PR (NOLOCK)
																						 on ( TP.rucProveedor=PR.NUMERO_DOCUMENTO )
																						 WHERE TP.rowid=@rowIni )
							BEGIN
									INSERT INTO CTR.PROVEEDOR_ACUMULADO (CODIGO_PROVEEDOR_ACUMULADO,CODIGO_PROVEEDOR,CODIGO_TIPO_ORDEN,
																											  CODIGO_MONEDA, MONTO_ACUMULADO,FECHA_INICIO,FECHA_FIN,
																											  INDICADOR_LIMITE_ALCANZADO,INDICADOR_NOTIFICADO,
																											  ESTADO_REGISTRO,USUARIO_CREACION,FECHA_CREACION,TERMINAL_CREACION)
																								SELECT CodigoProveedorAcumulado=NEWID(), PR.CODIGO_PROVEEDOR, TP.codigoTipoOrden,
																											 tp.codigoMoneda, tp.MontoProveedor, FecIni= @FechaInicio,FecFin= @FechaFin,
																											 1, 0 , '1', SUSER_SNAME(), GETDATE(), HOST_NAME()
																											 FROM #temp_resumen TP INNER JOIN CTR.PROVEEDOR PR (NOLOCK)
																											 on ( TP.rucProveedor=PR.NUMERO_DOCUMENTO )
																											 WHERE TP.rowid=@rowIni and PR.ESTADO_REGISTRO='1'

									UPDATE #temp_resumen SET Existe= 1  WHERE rowid=@rowIni
							END
					ELSE
							BEGIN
								INSERT INTO 	TMP.ACUMULADO_PROVEEDOR ( RUC_PROVEEDOR, CODIGO_TIPO_ORDEN,CODIGO_MONEDA, MONTO_PROVEEDOR )
																						 SELECT TP.rucProveedor, TP.codigoTipoOrden, tp.codigoMoneda, tp.MontoProveedor
																						FROM  #temp_resumen TP WHERE rowid=@rowIni
							END
				END
		set @rowIni+=1
end

end

GO
/****** Object:  StoredProcedure [CTR].[USP_COPIAR_ESTADIOS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_COPIAR_ESTADIOS] 
(
	@CODIGO_FLUJO_APROBACION_ORIGEN AS UNIQUEIDENTIFIER,
	@CODIGO_FLUJO_APROBACION_DESTINO AS UNIQUEIDENTIFIER,
	@USUARIO AS NVARCHAR(50),
	@TERMINAL AS NVARCHAR(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_COPIAR_ESTADIOS
Propósito:   Permite copiar los estadios  
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACION_ORIGEN:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion origen.
		@CODIGO_FLUJO_APROBACION_DESTINO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion destino.
		@USUARIO:	Parámetro de entrada de tipo nvarchar, que representa usuario.
		@TERMINAL:	Parámetro de entrada de tipo nvarchar, que representa terminal.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	SELECT FAE.CODIGO_FLUJO_APROBACION_ESTADIO AS CODIGO_FLUJO_APROBACION_ESTADIO_ORIGEN,
		   NEWID() AS CODIGO_FLUJO_APROBACION_ESTADIO_DESTINO
	  INTO #TMP_EQUIVALENCIA
	  FROM CTR.FLUJO_APROBACION_ESTADIO FAE
	 WHERE FAE.CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION_ORIGEN
	   AND FAE.ESTADO_REGISTRO = '1'

	UPDATE CTR.FLUJO_APROBACION_PARTICIPANTE
	   SET ESTADO_REGISTRO = '0',
		   USUARIO_MODIFICACION = @USUARIO,
		   FECHA_MODIFICACION = GETDATE(),
		   TERMINAL_MODIFICACION = @TERMINAL
	 WHERE ESTADO_REGISTRO = '1'
	   AND EXISTS (SELECT 1
					 FROM CTR.FLUJO_APROBACION_ESTADIO FAE
					WHERE FAE.CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION_DESTINO
					  AND FAE.ESTADO_REGISTRO = '1'
					  AND FAE.CODIGO_FLUJO_APROBACION_ESTADIO = CTR.FLUJO_APROBACION_PARTICIPANTE.CODIGO_FLUJO_APROBACION_ESTADIO)
	
	UPDATE CTR.FLUJO_APROBACION_ESTADIO
	   SET ESTADO_REGISTRO = '0',
		   USUARIO_MODIFICACION = @USUARIO,
		   FECHA_MODIFICACION = GETDATE(),
		   TERMINAL_MODIFICACION = @TERMINAL
	 WHERE CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION_DESTINO
	   AND ESTADO_REGISTRO = '1'
	
	INSERT INTO CTR.FLUJO_APROBACION_ESTADIO (
		CODIGO_FLUJO_APROBACION_ESTADIO,
		CODIGO_FLUJO_APROBACION,
		ORDEN,
		DESCRIPCION,
		TIEMPO_ATENCION,
		HORAS_ATENCION,
		INDICADOR_MONTO_MINIMO,
		INDICADOR_VERSION_OFICIAL,
		INDICADOR_PERMITE_CARGA,
		INDICADOR_NUMERO_CONTRATO,
		ESTADO_REGISTRO,
		USUARIO_CREACION,
		FECHA_CREACION,
		TERMINAL_CREACION,
		USUARIO_MODIFICACION,
		FECHA_MODIFICACION,
		TERMINAL_MODIFICACION
	)
	SELECT T.CODIGO_FLUJO_APROBACION_ESTADIO_DESTINO AS CODIGO_FLUJO_APROBACION_ESTADIO,
		   @CODIGO_FLUJO_APROBACION_DESTINO AS CODIGO_FLUJO_APROBACION,
		   FAE.ORDEN,
		   FAE.DESCRIPCION,
		   FAE.TIEMPO_ATENCION,
		   FAE.HORAS_ATENCION,
		   FAE.INDICADOR_MONTO_MINIMO,
		   FAE.INDICADOR_VERSION_OFICIAL,
		   FAE.INDICADOR_PERMITE_CARGA,
		   FAE.INDICADOR_NUMERO_CONTRATO,
		   FAE.ESTADO_REGISTRO,
		   @USUARIO AS USUARIO_CREACION,
		   GETDATE() AS FECHA_CREACION,
		   @TERMINAL TERMINAL_CREACION,
		   NULL AS USUARIO_MODIFICACION,
		   NULL AS FECHA_MODIFICACION,
		   NULL AS TERMINAL_MODIFICACION
	  FROM CTR.FLUJO_APROBACION_ESTADIO FAE
	 INNER JOIN #TMP_EQUIVALENCIA T
		ON T.CODIGO_FLUJO_APROBACION_ESTADIO_ORIGEN = FAE.CODIGO_FLUJO_APROBACION_ESTADIO
	
	INSERT INTO CTR.FLUJO_APROBACION_PARTICIPANTE (
		CODIGO_FLUJO_APROBACION_PARTICIPANTE,
		CODIGO_FLUJO_APROBACION_ESTADIO,
		CODIGO_TRABAJADOR,
		CODIGO_TIPO_PARTICIPANTE,
		ESTADO_REGISTRO,
		USUARIO_CREACION,
		FECHA_CREACION,
		TERMINAL_CREACION,
		USUARIO_MODIFICACION,
		FECHA_MODIFICACION,
		TERMINAL_MODIFICACION
	)
	SELECT NEWID() AS CODIGO_FLUJO_APROBACION_PARTICIPANTE,
		   T.CODIGO_FLUJO_APROBACION_ESTADIO_DESTINO AS CODIGO_FLUJO_APROBACION_PARTICIPANTE,
		   FAP.CODIGO_TRABAJADOR,
		   FAP.CODIGO_TIPO_PARTICIPANTE,
		   FAP.ESTADO_REGISTRO,
		   @USUARIO AS USUARIO_CREACION,
		   GETDATE() AS FECHA_CREACION,
		   @TERMINAL TERMINAL_CREACION,
		   NULL AS USUARIO_MODIFICACION,
		   NULL AS FECHA_MODIFICACION,
		   NULL AS TERMINAL_MODIFICACION
	  FROM CTR.FLUJO_APROBACION_PARTICIPANTE FAP
	 INNER JOIN #TMP_EQUIVALENCIA T
		ON T.CODIGO_FLUJO_APROBACION_ESTADIO_ORIGEN = FAP.CODIGO_FLUJO_APROBACION_ESTADIO
	
	DROP TABLE #TMP_EQUIVALENCIA
END

GO
/****** Object:  StoredProcedure [CTR].[USP_COPIAR_PLANTILLA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_COPIAR_PLANTILLA] --'9f96e0fe-f2e0-4c29-8a0e-d0ce6ce6d82e', 'Adenda de Transporte de Residuos Solidos y Peligrosos', 'CLST', 'A', '2016-04-15 10:24:23.677', 'ehuamanfe', '200.48.13.146' --'Arrendamiento de equipos - Shahuindo'
    @CODIGO_PLANTILLA_COPIAR UNIQUEIDENTIFIER ,
    @DESCRIPCION NVARCHAR(255) ,
    @CODIGO_TIPO_CONTRATO NVARCHAR(5) ,
    @CODIGO_TIPO_DOCUMENTO NVARCHAR(5) ,
    @FECHA_INICIO_VIGENCIA DATETIME ,
    @USUARIO_CREACION VARCHAR(50) ,
    @TERMINAL_CREACION VARCHAR(50),
	@ES_MAYORMENOR BIT
AS /**********************************************************************************************************************************
Nombre Objeto: CTR.USP_COPIAR_PLANTILLA
Propósito:   Copia una plantilla
Descripción de Parámetros: 
		@CODIGO_PLANTILLA_COPIAR:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo de plantilla a copiar.
		@DESCRIPCION:	Parámetro de entrada de tipo varchar, que representa la descripción.
		@CODIGO_TIPO_CONTRATO:	Parámetro de entrada de tipo varchar, que representa el tipo de contrato.
		@FECHA_INICIO_VIGENCIA:	Parámetro de entrada de tipo varchar, que representa fecha de inicio de vigencia.
		@USUARIO_CREACION: Parámetro de entrada de tipo varchar, que representa el usuario de creación.
		@TERMINAL_CREACION: Parámetro de entrada de tipo varchar, que representa el terminal de creación.
Creado por: GMD
Fecha. Creación: 2016-02-25
Fecha. Actualización: 
**********************************************************************************************************************************/
    BEGIN

        DECLARE @CTR_PLANTILLA_PARRAFO TABLE
            (
              CODIGO_PLANTILLA_PARRAFO UNIQUEIDENTIFIER ,
              CODIGO_PLANTILLA UNIQUEIDENTIFIER ,
              ORDEN TINYINT ,
              TITULO NVARCHAR(255) ,
              CONTENIDO VARCHAR(MAX) ,
              ESTADO_REGISTRO CHAR(1) ,
              USUARIO_CREACION NVARCHAR(50) ,
              FECHA_CREACION DATETIME ,
              TERMINAL_CREACION NVARCHAR(50) ,
              USUARIO_MODIFICACION NVARCHAR(50) ,
              FECHA_MODIFICACION DATETIME ,
              TERMINAL_MODIFICACION NVARCHAR(50)
            );


        DECLARE @CTR_PLANTILLA_PARRAFO_VARIABLE TABLE
            (
              CODIGO_PLANTILLA_PARRAFO_VARIABLE UNIQUEIDENTIFIER ,
              CODIGO_PLANTILLA_PARRAFO UNIQUEIDENTIFIER ,
              CODIGO_VARIABLE UNIQUEIDENTIFIER ,
              ORDEN SMALLINT ,
              ESTADO_REGISTRO CHAR(1) ,
              USUARIO_CREACION NVARCHAR(50) ,
              FECHA_CREACION DATETIME ,
              TERMINAL_CREACION NVARCHAR(50) ,
              USUARIO_MODIFICACION NVARCHAR(50) ,
              FECHA_MODIFICACION DATETIME ,
              TERMINAL_MODIFICACION NVARCHAR(50)
            );

        DECLARE @FECHA_ACTUAL DATETIME = GETDATE()

        SELECT  *
        INTO    #TMP_PLANTILLA
        FROM    [CTR].[PLANTILLA]
        WHERE   [CODIGO_PLANTILLA] = @CODIGO_PLANTILLA_COPIAR

        DECLARE @CODIGO_PLANTILLA_NUEVA UNIQUEIDENTIFIER = NEWID()

        INSERT  INTO [CTR].[PLANTILLA]
        VALUES  ( @CODIGO_PLANTILLA_NUEVA, @DESCRIPCION, @CODIGO_TIPO_CONTRATO,
                  @CODIGO_TIPO_DOCUMENTO, ( SELECT  CODIGO_ESTADO
                                            FROM    #TMP_PLANTILLA
                                          ), ( SELECT   INDICADOR_ADHESION
                                               FROM     #TMP_PLANTILLA
                                             ), @FECHA_INICIO_VIGENCIA,
                  ( SELECT  FECHA_FIN_VIGENCIA
                    FROM    #TMP_PLANTILLA
                  ), ( SELECT   ESTADO_REGISTRO
                       FROM     #TMP_PLANTILLA
                     ), @USUARIO_CREACION, @FECHA_ACTUAL, @TERMINAL_CREACION,
                  NULL, NULL, NULL, @ES_MAYORMENOR)

        DECLARE @TMP_PLANTILLA_PARRAFO AS TABLE
            (
              [ROW_ID] INT IDENTITY(1, 1) ,
              [CODIGO_PLANTILLA_PARRAFO] UNIQUEIDENTIFIER ,
              [ORDEN] TINYINT ,
              [TITULO] NVARCHAR(255) ,
              [CONTENIDO] VARCHAR(MAX) ,
              [ESTADO_REGISTRO] CHAR(1) ,
              [USUARIO_CREACION] NVARCHAR(50) ,
              [FECHA_CREACION] DATETIME ,
              [TERMINAL_CREACION] NVARCHAR(50) ,
              [USUARIO_MODIFICACION] NVARCHAR(50) ,
              [FECHA_MODIFICACION] DATETIME ,
              [TERMINAL_MODIFICACION] NVARCHAR(50)
            )

        INSERT  @TMP_PLANTILLA_PARRAFO
                SELECT  NEWID() ,
                        [ORDEN] ,
                        [TITULO] ,
                        [CONTENIDO] ,
                        [ESTADO_REGISTRO] ,
                        @USUARIO_CREACION ,
                        @FECHA_ACTUAL ,
                        @TERMINAL_CREACION ,
                        [USUARIO_MODIFICACION] ,
                        [FECHA_MODIFICACION] ,
                        [TERMINAL_MODIFICACION]
                FROM    [CTR].[PLANTILLA_PARRAFO]
                WHERE   CODIGO_PLANTILLA = @CODIGO_PLANTILLA_COPIAR
                        AND ESTADO_REGISTRO = '1'

        DECLARE @I_ROW_MIN INT = 1 ,
            @I_ROW_MAX INT = ( SELECT   COUNT(ROW_ID)
                               FROM     @TMP_PLANTILLA_PARRAFO
                             ) ,
            @NEW_ID UNIQUEIDENTIFIER

        WHILE ( @I_ROW_MIN <= @I_ROW_MAX )
            BEGIN
                SET @NEW_ID = NEWID()

			--Guardamos en tabl temporal, al slir del while se insertara en bloque
                INSERT  INTO @CTR_PLANTILLA_PARRAFO--[CTR].[PLANTILLA_PARRAFO]
                        ( [CODIGO_PLANTILLA_PARRAFO] ,
                          [CODIGO_PLANTILLA] ,
                          [ORDEN] ,
                          [TITULO] ,
                          [CONTENIDO] ,
                          [ESTADO_REGISTRO] ,
                          [USUARIO_CREACION] ,
                          [FECHA_CREACION] ,
                          [TERMINAL_CREACION] ,
                          [USUARIO_MODIFICACION] ,
                          [FECHA_MODIFICACION] ,
                          [TERMINAL_MODIFICACION]
                        )
                VALUES  ( @NEW_ID ,
                          @CODIGO_PLANTILLA_NUEVA ,
                          ( SELECT  [ORDEN]
                            FROM    @TMP_PLANTILLA_PARRAFO
                            WHERE   ROW_ID = @I_ROW_MIN
                          ) ,
                          ( SELECT  [TITULO]
                            FROM    @TMP_PLANTILLA_PARRAFO
                            WHERE   ROW_ID = @I_ROW_MIN
                          ) ,
                          ( SELECT  [CONTENIDO]
                            FROM    @TMP_PLANTILLA_PARRAFO
                            WHERE   ROW_ID = @I_ROW_MIN
                          ) ,
                          ( SELECT  [ESTADO_REGISTRO]
                            FROM    @TMP_PLANTILLA_PARRAFO
                            WHERE   ROW_ID = @I_ROW_MIN
                          ) ,
                          @USUARIO_CREACION ,
                          @FECHA_ACTUAL ,
                          @TERMINAL_CREACION ,
                          NULL ,
                          NULL ,
                          NULL
                        )

                UPDATE  @TMP_PLANTILLA_PARRAFO
                SET     [CODIGO_PLANTILLA_PARRAFO] = @NEW_ID
                WHERE   ROW_ID = @I_ROW_MIN

                SET @I_ROW_MIN = @I_ROW_MIN + 1
            END

		--Se inserta en bloque los datos
        INSERT  INTO [CTR].[PLANTILLA_PARRAFO]
                ( [CODIGO_PLANTILLA_PARRAFO] ,
                  [CODIGO_PLANTILLA] ,
                  [ORDEN] ,
                  [TITULO] ,
                  [CONTENIDO] ,
                  [ESTADO_REGISTRO] ,
[USUARIO_CREACION] ,
                  [FECHA_CREACION] ,
                  [TERMINAL_CREACION] ,
                  [USUARIO_MODIFICACION] ,
                  [FECHA_MODIFICACION] ,
                  [TERMINAL_MODIFICACION]
		        )
                SELECT  CODIGO_PLANTILLA_PARRAFO ,
                        CODIGO_PLANTILLA ,
                        ORDEN ,
                        TITULO ,
                        CONTENIDO ,
                        ESTADO_REGISTRO ,
                        USUARIO_CREACION ,
                        FECHA_CREACION ,
                        TERMINAL_CREACION ,
                        USUARIO_MODIFICACION ,
                        FECHA_MODIFICACION ,
                        TERMINAL_MODIFICACION
                FROM    @CTR_PLANTILLA_PARRAFO

        DECLARE @TMP_PLANTILLA_PARRAFO_VARIABLE AS TABLE
            (
              ROW_ID INT IDENTITY(1, 1) ,
              [CODIGO_PLANTILLA_PARRAFO] UNIQUEIDENTIFIER ,
              [TITULO] VARCHAR(200) ,
              [CODIGO_VARIABLE] UNIQUEIDENTIFIER ,
              [ORDEN] SMALLINT ,
              [ESTADO_REGISTRO] CHAR(1) ,
              [USUARIO_CREACION] NVARCHAR(50) ,
              [FECHA_CREACION] DATETIME ,
              [TERMINAL_CREACION] NVARCHAR(50) ,
              [USUARIO_MODIFICACION] NVARCHAR(50) ,
              [FECHA_MODIFICACION] DATETIME ,
              [TERMINAL_MODIFICACION] NVARCHAR(50)
            )

        INSERT  @TMP_PLANTILLA_PARRAFO_VARIABLE
                SELECT  P.[CODIGO_PLANTILLA_PARRAFO] ,
                        F.[TITULO] ,
                        [CODIGO_VARIABLE] ,
                        P.[ORDEN] ,
                        P.[ESTADO_REGISTRO] ,
                        @USUARIO_CREACION ,
                        @FECHA_ACTUAL ,
                        @TERMINAL_CREACION ,
                        P.[USUARIO_MODIFICACION] ,
                        P.[FECHA_MODIFICACION] ,
                        P.[TERMINAL_MODIFICACION]
                FROM    [CTR].[PLANTILLA_PARRAFO_VARIABLE] P
                        INNER JOIN [CTR].[PLANTILLA_PARRAFO] F ON P.[CODIGO_PLANTILLA_PARRAFO] = F.[CODIGO_PLANTILLA_PARRAFO]
                                                              AND F.ESTADO_REGISTRO = '1'
                WHERE   F.[CODIGO_PLANTILLA] = @CODIGO_PLANTILLA_COPIAR
                        AND P.ESTADO_REGISTRO = '1'
                ORDER BY F.CODIGO_PLANTILLA_PARRAFO



        DECLARE @I_ROW_MIN_PARRAFO_VARIABLE INT = 1 ,
            @I_ROW_MAX_PARRAFO_VARIABLE INT = ( SELECT  MAX(ROW_ID)
                                                FROM    @TMP_PLANTILLA_PARRAFO_VARIABLE
                                              ) ,
            @I_ROW_MIN_PARRAFO INT = 1 ,
            @I_ROW_MAX_PARRAFO INT = ( SELECT   MAX(ROW_ID)
                                       FROM     @TMP_PLANTILLA_PARRAFO
                                     )

        WHILE ( @I_ROW_MIN_PARRAFO_VARIABLE <= @I_ROW_MAX_PARRAFO_VARIABLE )
            BEGIN
                WHILE ( @I_ROW_MIN_PARRAFO <= @I_ROW_MAX_PARRAFO )
                    BEGIN
                        IF ( ( SELECT   [TITULO]
                               FROM     @TMP_PLANTILLA_PARRAFO_VARIABLE
                               WHERE    ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE
                             ) = ( SELECT   [TITULO]
                                   FROM     @TMP_PLANTILLA_PARRAFO
                                   WHERE    ROW_ID = @I_ROW_MIN_PARRAFO
                                 ) )
                            BEGIN

                                INSERT  INTO @CTR_PLANTILLA_PARRAFO_VARIABLE--[CTR].[PLANTILLA_PARRAFO_VARIABLE]
                                        ( [CODIGO_PLANTILLA_PARRAFO_VARIABLE] ,
                                          [CODIGO_PLANTILLA_PARRAFO] ,
                                          [CODIGO_VARIABLE] ,
  [ORDEN] ,
                                          [ESTADO_REGISTRO] ,
                                          [USUARIO_CREACION] ,
                                          [FECHA_CREACION] ,
                                          [TERMINAL_CREACION] ,
                                          [USUARIO_MODIFICACION] ,
                                          [FECHA_MODIFICACION] ,
                                          [TERMINAL_MODIFICACION]
                                        )
                                VALUES  ( NEWID() ,
                                          ( SELECT  CODIGO_PLANTILLA_PARRAFO
                                            FROM    @TMP_PLANTILLA_PARRAFO
                                            WHERE   TITULO = ( SELECT
                                                              [TITULO]
                                                              FROM
                                                              @TMP_PLANTILLA_PARRAFO
                                                              WHERE
                                                              ROW_ID = @I_ROW_MIN_PARRAFO
                                                             )
                                          ) ,
                                          ( SELECT  [CODIGO_VARIABLE]
                                            FROM    @TMP_PLANTILLA_PARRAFO_VARIABLE
                                            WHERE   ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE
                                          ) ,
                                          ( SELECT  [ORDEN]
                                            FROM    @TMP_PLANTILLA_PARRAFO_VARIABLE
                                            WHERE   ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE
                                          ) ,
                                          ( SELECT  [ESTADO_REGISTRO]
                                            FROM    @TMP_PLANTILLA_PARRAFO_VARIABLE
                                            WHERE   ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE
                                          ) ,
                                          @USUARIO_CREACION ,
                                          @FECHA_ACTUAL ,
                                          @TERMINAL_CREACION ,
                                          NULL ,
                                          NULL ,
                                          NULL
                                        )
                            END

                        SET @I_ROW_MIN_PARRAFO = @I_ROW_MIN_PARRAFO + 1

                    END
                SET @I_ROW_MIN_PARRAFO_VARIABLE = @I_ROW_MIN_PARRAFO_VARIABLE
                    + 1
                SET @I_ROW_MIN_PARRAFO = 1

            END


        INSERT  INTO [CTR].[PLANTILLA_PARRAFO_VARIABLE]
                ( [CODIGO_PLANTILLA_PARRAFO_VARIABLE] ,
                  [CODIGO_PLANTILLA_PARRAFO] ,
                  [CODIGO_VARIABLE] ,
                  [ORDEN] ,
                  [ESTADO_REGISTRO] ,
                  [USUARIO_CREACION] ,
                  [FECHA_CREACION] ,
                  [TERMINAL_CREACION] ,
                  [USUARIO_MODIFICACION] ,
                  [FECHA_MODIFICACION] ,
                  [TERMINAL_MODIFICACION]
		        )
                SELECT  CODIGO_PLANTILLA_PARRAFO_VARIABLE ,
                        CODIGO_PLANTILLA_PARRAFO ,
                        CODIGO_VARIABLE ,
                        ORDEN ,
                        ESTADO_REGISTRO ,
                        USUARIO_CREACION ,
                        FECHA_CREACION ,
                        TERMINAL_CREACION ,
                        USUARIO_MODIFICACION ,
                        FECHA_MODIFICACION ,
                        TERMINAL_MODIFICACION
                FROM    @CTR_PLANTILLA_PARRAFO_VARIABLE
    END

GO
/****** Object:  StoredProcedure [CTR].[USP_CORRELATIVO_CONTRATO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [CTR].[USP_CORRELATIVO_CONTRATO_SEL](



	@CODIGO_UNIDAD_OPERATIVA	UNIQUEIDENTIFIER,



	@CODIGO_TIPO_REQUERIMIENTO	VARCHAR(15),



	@CODIGO_TIPO_DOCUMENTO		VARCHAR(10)



)



AS



BEGIN



	DECLARE @UO_PADRE UNIQUEIDENTIFIER = (SELECT TOP 1 CODIGO_UNIDAD_OPERATIVA_PADRE FROM STRACON_POLITICAS.GRL.UNIDAD_OPERATIVA WHERE CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA)



	DECLARE @UO_PADRE_DESC VARCHAR(20) = (SELECT  TOP 1 CODIGO_IDENTIFICACION FROM STRACON_POLITICAS.GRL.UNIDAD_OPERATIVA WHERE CODIGO_UNIDAD_OPERATIVA = @UO_PADRE)



	DECLARE @CODIGO_IDENTIFICACION VARCHAR(50) = (SELECT CODIGO_IDENTIFICACION FROM STRACON_POLITICAS.GRL.UNIDAD_OPERATIVA WHERE CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA)
	







	SELECT	Top 1 NumeroContrato = NUMERO_CONTRATO 



	FROM	CTR.CONTRATO



	WHERE	CHARINDEX(@CODIGO_IDENTIFICACION,NUMERO_CONTRATO) > 0 
	      --CODIGO_UNIDAD_OPERATIVA		=	@CODIGO_UNIDAD_OPERATIVA


	AND		CODIGO_TIPO_REQUERIMIENTO	=	@CODIGO_TIPO_REQUERIMIENTO



	AND		ISNULL(NUMERO_CONTRATO,'')	!=	''



	AND		CODIGO_TIPO_DOCUMENTO		=	@CODIGO_TIPO_DOCUMENTO AND ESTADO_REGISTRO = 1



	AND		(LEFT(NUMERO_CONTRATO,LEN(@UO_PADRE_DESC) + 1)) =  (@UO_PADRE_DESC + '.')



	ORDER BY NUMERO_CONTRATO DESC  



END
GO
/****** Object:  StoredProcedure [CTR].[USP_DATOS_CORREO_CONTRATO_RETRASADO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_DATOS_CORREO_CONTRATO_RETRASADO_SEL]
/*
EXEC CTR.USP_DATOS_CORREO_CONTRATO_RETRASADO_SEL
*/
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_DATOS_CORREO_CONTRATO_RETRASADO_SEL
Propósito:  Obtener datos de tabla 
Descripción de Parámetros: 
         <<None>>
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

DECLARE @CORREOS_INFORMADOS VARCHAR(1000)
SELECT @CORREOS_INFORMADOS=''

SELECT CR.ASUNTO, 
			CR.NUMERO_CONTRATO,
			CR.NOMBRE_PROVEEDOR,
			CR.NOMBRE_UNIDAD_OPERATIVA,
			CR.URL_SISTEMA,
		    CONTENIDO = REPLACE(CR.CONTENIDO,'@responsable_estadio',CR.NOMBRE_RESPONSABLE),
			CR.CORREO_RESPONSABLE,
			CR.PROFILE_CORREO,
			CR.CODIGO_FLUJO_APROBACION_ESTADIO,
			CR.CODIGO_CONTRATO_ESTADIO
			INTO #TEMP_DATOS_CORREO
 FROM TMP.CONTRATOS_RETRASADOS CR (nolock) 

 UPDATE #TEMP_DATOS_CORREO SET CONTENIDO = REPLACE(CONTENIDO,'@numero_contrato',NUMERO_CONTRATO)
 UPDATE #TEMP_DATOS_CORREO SET CONTENIDO = REPLACE(CONTENIDO,'@nombre_proveedor',NOMBRE_PROVEEDOR)
 UPDATE #TEMP_DATOS_CORREO SET CONTENIDO = REPLACE(CONTENIDO,'@url_opcion_sistema',URL_SISTEMA)
 UPDATE #TEMP_DATOS_CORREO SET CONTENIDO = REPLACE(CONTENIDO,'@nombre_proyecto',NOMBRE_UNIDAD_OPERATIVA)

 /*Obtenemos a los informados.*/

 SELECT @CORREOS_INFORMADOS = @CORREOS_INFORMADOS + COALESCE(CORREO_INFORMADO,';','')
	FROM #TEMP_DATOS_CORREO TMP INNER JOIN TMP.CONTRATOS_INFORMADOS CI (NOLOCK)
	ON (TMP.CODIGO_FLUJO_APROBACION_ESTADIO=CI.CODIGO_FLUJO_APROBACION_ESTADIO)
	
SELECT ASUNTO=CONVERT(nvarchar(255),ASUNTO), 
			CONTENIDO=CONVERT(nvarchar(4000),CONTENIDO),
			CORREO_RESPONSABLE=CONVERT(nvarchar(255),CORREO_RESPONSABLE),
			CORREO_COPIAR= CONVERT(nvarchar(255),@CORREOS_INFORMADOS), 
			PROFILE_CORREO = CONVERT(nvarchar(100),PROFILE_CORREO),
			CODIGO_CONTRATO_ESTADIO
FROM #TEMP_DATOS_CORREO

END

GO
/****** Object:  StoredProcedure [CTR].[USP_DOCUMENTO_POR_CONTRATO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_DOCUMENTO_POR_CONTRATO_SEL] 
(
	@CodigoContrato uniqueidentifier
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_DOCUMENTO_POR_CONTRATO_SEL
Propósito:  Retorna información de los documentos del contrato. 
Descripción de Parámetros: 
		@CodigoContrato:	Parámetro de entrada de tipo uniqueidentifier, que representa codigocontrato.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
--WITH CTE_DocActual AS (
DECLARE @MIN_VERSION	INT
DECLARE @MAX_VERSION	INT

		SELECT	@MIN_VERSION	=	MIN([VERSION]),
				@MAX_VERSION	=	MAX([VERSION])
		FROM	CTR.CONTRATO_DOCUMENTO
		WHERE	CODIGO_CONTRATO	=	@CodigoContrato

		SELECT TOP 2	NumeroContrato				= CT.NUMERO_CONTRATO,
						CodigoContratoDocumento		= CD.CODIGO_CONTRATO_DOCUMENTO,
						CodigoContrato				= CD.CODIGO_CONTRATO,
						CodigoArchivo				= CD.CODIGO_ARCHIVO,
						RutaArchivoSharePoint		= isnull(CD.RUTA_ARCHIVO_SHAREPOINT,''),
						IndicadorActual				= CD.INDICADOR_ACTUAL,
						Contenido					= CD.CONTENIDO,
						Version					= CD.[VERSION],
						UsuarioCreacion				= CD.USUARIO_CREACION,
						FechaCreacion				= CD.FECHA_CREACION,
						TerminalCreacion			= CD.TERMINAL_CREACION,
						CodigoContratoEstadio		= ISNULL((SELECT TOP 1 CE.CODIGO_CONTRATO_ESTADIO 
														FROM CTR.CONTRATO_ESTADIO CE (NOLOCK) 
														WHERE CE.CODIGO_CONTRATO				=	CT.CODIGO_CONTRATO 
														AND   CE.CODIGO_ESTADO_CONTRATO_ESTADIO  IN ('I', 'A' )
														AND		CE.ESTADO_REGISTRO				=	'1'	ORDER BY CE.FECHA_CREACION DESC ),'00000000-0000-0000-0000-000000000000')--Para la respuesta del Contrato.
			INTO	#TMP_CONTRATO_DOCUMENTO
			FROM	CTR.CONTRATO_DOCUMENTO CD (NOLOCK) 
			INNER JOIN CTR.CONTRATO CT (NOLOCK)
				ON	CD.CODIGO_CONTRATO		=	CT.CODIGO_CONTRATO
			--INNER JOIN CTR.CONTRATO_ESTADIO  CCE
			--	ON	CCE.CODIGO_CONTRATO						=	CT.CODIGO_CONTRATO 
			--	AND CCE.CODIGO_ESTADO_CONTRATO_ESTADIO		=	'I' 
			--	AND	CCE.ESTADO_REGISTRO						=	'1'
			WHERE	CT.CODIGO_CONTRATO						=	@CodigoContrato
			AND		CT.ESTADO_REGISTRO						=	'1' 
			AND		CD.[VERSION]				IN	(@MIN_VERSION,@MAX_VERSION)

			SELECT NumeroContrato, CodigoContratoDocumento,CodigoContrato ,CodigoArchivo,RutaArchivoSharePoint,
						IndicadorActual, Contenido, Version , UsuarioCreacion, FechaCreacion, TerminalCreacion, CodigoContratoEstadio
			FROM #TMP_CONTRATO_DOCUMENTO 
			ORDER BY IndicadorActual DESC
END

GO
/****** Object:  StoredProcedure [CTR].[USP_ELIMINAR_CONTENIDO_CONTRATO_DEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_ELIMINAR_CONTENIDO_CONTRATO_DEL]
(	
	@CODIGO_CONTRATO uniqueidentifier,
	@USER_CREACION nvarchar(50),
	@TERMINAL_CREACION nvarchar(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_ELIMINAR_CONTENIDO_CONTRATO_DEL
Propósito:   Elimina el contenido de un contrato
Descripción de Parámetros: 
		@CODIGO_PARRAFO: Código de contrato.
		@USER_CREACION:	Parámetro de entrada de tipo nvarchar, que representa user creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

DELETE FROM [CTR].[CONTRATO_BIEN] WHERE [CODIGO_CONTRATO] = @CODIGO_CONTRATO


SELECT 
	[CODIGO_CONTRATO_PARRAFO]
	INTO #TMP_CODIGO_CONTRATO_PARRAFO
	FROM [CTR].[CONTRATO_PARRAFO]
	WHERE [CODIGO_CONTRATO] = @CODIGO_CONTRATO


SELECT 
	[CODIGO_CONTRATO_PARRAFO_VARIABLE]
	INTO #TMP_CODIGO_CONTRATO_PARRAFO_VARIABLE
	FROM [CTR].[CONTRATO_PARRAFO_VARIABLE]
	WHERE [CODIGO_CONTRATO_PARRAFO] IN (SELECT TBL_PARRAFO.[CODIGO_CONTRATO_PARRAFO] FROM #TMP_CODIGO_CONTRATO_PARRAFO TBL_PARRAFO)

	DELETE FROM [CTR].[CONTRATO_FIRMANTE] 
	WHERE [CODIGO_CONTRATO_PARRAFO_VARIABLE] IN (SELECT TBL_PARRAFO_VARIABLE.[CODIGO_CONTRATO_PARRAFO_VARIABLE] FROM #TMP_CODIGO_CONTRATO_PARRAFO_VARIABLE TBL_PARRAFO_VARIABLE)

	DELETE FROM [CTR].[CONTRATO_PARRAFO_VARIABLE] 
	WHERE [CODIGO_CONTRATO_PARRAFO] IN (SELECT TBL_PARRAFO.[CODIGO_CONTRATO_PARRAFO] FROM #TMP_CODIGO_CONTRATO_PARRAFO TBL_PARRAFO)

	DELETE FROM [CTR].[CONTRATO_PARRAFO] WHERE [CODIGO_CONTRATO] = @CODIGO_CONTRATO

	--DELETE FROM [CTR].[CONTRATO_ESTADIO] WHERE [CODIGO_CONTRATO] = @CODIGO_CONTRATO

	--DELETE FROM [CTR].[CONTRATO_DOCUMENTO] WHERE [CODIGO_CONTRATO] = @CODIGO_CONTRATO

	---Damos de baja a todos los documentos anteriores.------
	UPDATE CTR.CONTRATO_DOCUMENTO  SET INDICADOR_ACTUAL=0, 
									USUARIO_MODIFICACION=@USER_CREACION,
									FECHA_MODIFICACION=GETDATE(), TERMINAL_MODIFICACION =@TERMINAL_CREACION	
	WHERE CODIGO_CONTRATO=@CODIGO_CONTRATO AND ESTADO_REGISTRO='1' AND INDICADOR_ACTUAL=1

END

GO
/****** Object:  StoredProcedure [CTR].[USP_EMPRESA_VINCULADA_POR_PROVEEDOR]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_EMPRESA_VINCULADA_POR_PROVEEDOR]
(	
	@CODIGO_PROVEEDOR uniqueidentifier
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_EMPRESA_VINCULADA_POR_PROVEEDOR
Propósito:   Obtiene la empresa vinculada
Descripción de Parámetros: 
		@CODIGO_PROVEEDOR:	Parámetro de entrada de tipo uniqueidentifier, que representa el código del proveedor.
Creado por: GMD
Fecha. Creación: 2017-10-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	
	SELECT CODIGO_EMPRESA_VINCULADA CodigoEmpresaVinculada, 
	   NOMBRE_EMPRESA NombreEmpresa, 
	   NUMERO_RUC NumeroRuc 
	FROM CTR.EMPRESA_VINCULADA 
	WHERE NUMERO_RUC = (SELECT NUMERO_DOCUMENTO 
						FROM CTR.PROVEEDOR 
						WHERE CODIGO_PROVEEDOR = @CODIGO_PROVEEDOR) COLLATE Latin1_General_CI_AS AND ESTADO_REGISTRO = '1'

END


GO
/****** Object:  StoredProcedure [CTR].[USP_ENVIAR_CORREO_CONSULTA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_ENVIAR_CORREO_CONSULTA] --'[SGC] test gmd', 'Estimado(a) Sr(a). Diana Elizabeth Camus Alva', 'dcamus@gmd.com.pe', 
	@ASUNTO nvarchar(255),
	@TEXTO_NOTIFICAR nvarchar(4000),
	@CUENTA_NOTIFICAR nvarchar(255),
	@CUENTAS_COPIAS nvarchar(255),
	@PROFILE_CORREO nvarchar(100)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_ENVIAR_CORREO_CONSULTA
Propósito:  Inserta Registros 
Descripción de Parámetros: 
		@ASUNTO:			Parámetro de entrada de tipo nvarchar, que representa asunto.
		@TEXTO_NOTIFICAR:	Parámetro de entrada de tipo nvarchar, que representa texto notificar.
		@CUENTA_NOTIFICAR:	Parámetro de entrada de tipo nvarchar, que representa cuenta notificar.
		@CUENTAS_COPIAS:	Parámetro de entrada de tipo nvarchar, que representa cuentas copias.
		@PROFILE_CORREO:	Parámetro de entrada de tipo nvarchar, que representa profile correo.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	select @CUENTAS_COPIAS=isnull(@CUENTAS_COPIAS,''),
		  @CUENTA_NOTIFICAR=isnull(@CUENTA_NOTIFICAR,''),
		  @TEXTO_NOTIFICAR=isnull(@TEXTO_NOTIFICAR,'')

if len(@CUENTA_NOTIFICAR)>0 and len(@TEXTO_NOTIFICAR)>0
begin
	EXEC [msdb].[dbo].[sp_send_dbmail] @profile_name = @PROFILE_CORREO, 
	@recipients = @CUENTA_NOTIFICAR , @body = @TEXTO_NOTIFICAR,
	@copy_recipients = @CUENTAS_COPIAS,
	@body_format='html', @subject = @ASUNTO, @importance = 'High';
END

	select 1
END

GO
/****** Object:  StoredProcedure [CTR].[USP_ESTADIO_ANTERIOR_CONTRATO_ESTADIO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_ESTADIO_ANTERIOR_CONTRATO_ESTADIO]
@CODIGO_CONTRATO_ESTADIO uniqueidentifier,
@CODIGO_CONTRATO uniqueidentifier
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_ESTADIO_ANTERIOR_CONTRATO_ESTADIO
Propósito:  Retorna el estadio anterior del Contrato por Estadio 
Descripción de Parámetros: 
		@CODIGO_CONTRATO_ESTADIO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio.
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	
	SELECT CodigoFlujoAprobacionEstadio = CODIGO_FLUJO_APROBACION_ESTADIO ,
				 CodigoTrabajador=CODIGO_RESPONSABLE
			   FROM ctr.CONTRATO_ESTADIO (NOLOCK)
	WHERE CODIGO_CONTRATO=@CODIGO_CONTRATO and ESTADO_REGISTRO='1' and CODIGO_ESTADO_CONTRATO_ESTADIO<>'I'
		and FECHA_CREACION =  ( SELECT MAX(CE.FECHA_CREACION) FROM CTR.CONTRATO_ESTADIO CE (nolock)
												WHERE CE.CODIGO_CONTRATO=@CODIGO_CONTRATO AND 
												CE.CODIGO_CONTRATO_ESTADIO<>@CODIGO_CONTRATO_ESTADIO AND
												CE.ESTADO_REGISTRO='1' and CE.CODIGO_ESTADO_CONTRATO_ESTADIO<>'I' )	
END

GO
/****** Object:  StoredProcedure [CTR].[USP_ESTADIO_POR_DEFECTO_INS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_ESTADIO_POR_DEFECTO_INS]
(
	@CODIGO_FLUJO_APROBACION_ESTADIO UNIQUEIDENTIFIER,
	@CODIGO_FLUJO_APROBACION UNIQUEIDENTIFIER,
	@ORDEN TINYINT,
	@DESCRIPCION NVARCHAR(255),
	@TIEMPO_ATENCION DECIMAL,
	@HORAS_ATENCION DECIMAL,
	@INDICADOR_VERSION_OFICIAL BIT,
	@INDICADOR_PERMITE_CARGA BIT,
	@INDICADOR_NUMERO_CONTRATO BIT ,
	@ESTADO_REGISTRO CHAR(1),
	@USUARIO_CREACION NVARCHAR(50),
	@FECHA_CREACION DATETIME,
	@TERMINAL_CREACION NVARCHAR(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_ESTADIO_POR_DEFECTO_INS
Propósito:   Permite registrar un estadio por defecto  
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACION_ESTADIO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.
		@CODIGO_FLUJO_APROBACION:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.
		@ORDEN:	Parámetro de entrada de tipo tinyint, que representa orden.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
		@TIEMPO_ATENCION:	Parámetro de entrada de tipo decimal, que representa tiempo atencion.
		@HORAS_ATENCION:	Parámetro de entrada de tipo decimal, que representa horas atencion.
		@INDICADOR_VERSION_OFICIAL:	Parámetro de entrada de tipo bit, que representa indicador version oficial.
		@INDICADOR_PERMITE_CARGA:	Parámetro de entrada de tipo bit, que representa indicador permite carga.
		@INDICADOR_NUMERO_CONTRATO:	Parámetro de entrada de tipo bit, que representa indicador numero contrato.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@FECHA_CREACION:	Parámetro de entrada de tipo datetime, que representa fecha creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
INSERT INTO CTR.FLUJO_APROBACION_ESTADIO(
	CODIGO_FLUJO_APROBACION_ESTADIO,
	CODIGO_FLUJO_APROBACION,
	ORDEN,
	DESCRIPCION,
	TIEMPO_ATENCION,
	HORAS_ATENCION,
	INDICADOR_VERSION_OFICIAL,
	INDICADOR_PERMITE_CARGA,
	INDICADOR_NUMERO_CONTRATO,
	ESTADO_REGISTRO,
	USUARIO_CREACION,
	FECHA_CREACION,
	TERMINAL_CREACION
)
VALUES(
	@CODIGO_FLUJO_APROBACION_ESTADIO,
	@CODIGO_FLUJO_APROBACION,
	@ORDEN,
	@DESCRIPCION,
	@TIEMPO_ATENCION,
	@HORAS_ATENCION,
	@INDICADOR_VERSION_OFICIAL,
	@INDICADOR_PERMITE_CARGA,
	@INDICADOR_NUMERO_CONTRATO,
	@ESTADO_REGISTRO,
	@USUARIO_CREACION,
	@FECHA_CREACION,
	@TERMINAL_CREACION
)
END

GO
/****** Object:  StoredProcedure [CTR].[USP_ESTADIOS_CONTRATO_OBSERVACION]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_ESTADIOS_CONTRATO_OBSERVACION]
@CodigoContratoEstadio uniqueidentifier
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_ESTADIOS_CONTRATO_OBSERVACION
Propósito:  Retorna todos las contratos para la bandeja del usuario de acuerdo al perfil 
Descripción de Parámetros: 
		@CodigoContratoEstadio:	Parámetro de entrada de tipo uniqueidentifier, que representa codigocontratoestadio.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 2017-10-06 Modificación para obtener el responsable de estadio
	   Actualización: 2017-11-27 Modificación para obtener el responsable de estadio para empresas vinculadas
**********************************************************************************************************************************/

BEGIN
/*1. Seleccionamos el estadio actual y obtenemos su orden, para traer los menores a este.*/
DECLARE @OrdenEstadio tinyint,
@CodigoFlujoAprobacion uniqueidentifier,
@CodigoResponsable uniqueidentifier,
@CodigoEstado varchar(1),
@CodigoContrato uniqueidentifier,
@usuarioCreacion nvarchar(50),
@CodigoUsuarioEstadioEdicion uniqueidentifier,
@NUMERO_DOCUMENTO VARCHAR (20) = NULL,
@ES_VINCULADA BIT = 0

SELECT @OrdenEstadio= FAE.ORDEN, @CodigoFlujoAprobacion = FAE.CODIGO_FLUJO_APROBACION, @CodigoResponsable = CE.CODIGO_RESPONSABLE, 
	@CodigoContrato = CE.CODIGO_CONTRATO
	FROM CTR.FLUJO_APROBACION_ESTADIO FAE INNER JOIN CTR.CONTRATO_ESTADIO CE (NOLOCK)
	ON (  CE.CODIGO_FLUJO_APROBACION_ESTADIO = FAE.CODIGO_FLUJO_APROBACION_ESTADIO  )
	WHERE CE.CODIGO_CONTRATO_ESTADIO = @CodigoContratoEstadio AND CE.CODIGO_ESTADO_CONTRATO_ESTADIO='I'
	AND FAE.ESTADO_REGISTRO='1' AND CE.ESTADO_REGISTRO='1'

SELECT @usuarioCreacion = USUARIO_CREACION FROM CTR.CONTRATO WHERE CODIGO_CONTRATO = @CodigoContrato


--Ver si empresa es vinculada
	SELECT @NUMERO_DOCUMENTO = NUMERO_DOCUMENTO FROM CTR.PROVEEDOR 
	   WHERE CODIGO_PROVEEDOR = (SELECT CODIGO_PROVEEDOR FROM CTR.CONTRATO WHERE CODIGO_CONTRATO = @CodigoContrato)
	   	   
	IF (@NUMERO_DOCUMENTO IS NOT NULL)
	BEGIN
	
		IF EXISTS(SELECT 1 FROM CTR.EMPRESA_VINCULADA EM 
			WHERE EM.NUMERO_RUC = @NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND EM.ESTADO_REGISTRO = '1')
		BEGIN 	
			SET @ES_VINCULADA = 1
		END
	END

	IF(@ES_VINCULADA = 1)
		BEGIN
			SELECT @CodigoUsuarioEstadioEdicion = FAP.CODIGO_TRABAJADOR
			FROM CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK) 
			INNER JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP (NOLOCK) 
				ON ( FAE.CODIGO_FLUJO_APROBACION_ESTADIO=	FAP.CODIGO_FLUJO_APROBACION_ESTADIO )
			WHERE	FAE.CODIGO_FLUJO_APROBACION			=	@CodigoFlujoAprobacion
			AND		FAE.ESTADO_REGISTRO					=	'1' 
			AND		FAP.ESTADO_REGISTRO					=	'1' 
			AND		FAP.CODIGO_TIPO_PARTICIPANTE		=	'V'		
			AND		FAE.ORDEN							=    1	
	   END

	   IF(@ES_VINCULADA = 0 OR @CodigoUsuarioEstadioEdicion IS NULL)
	   BEGIN
			SELECT @CodigoUsuarioEstadioEdicion = FAP.CODIGO_TRABAJADOR
			FROM CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK) 
			INNER JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP (NOLOCK) 
				ON ( FAE.CODIGO_FLUJO_APROBACION_ESTADIO=	FAP.CODIGO_FLUJO_APROBACION_ESTADIO )
			WHERE	FAE.CODIGO_FLUJO_APROBACION			=	@CodigoFlujoAprobacion
			AND		FAE.ESTADO_REGISTRO					=	'1' 
			AND		FAP.ESTADO_REGISTRO					=	'1' 
			AND		FAP.CODIGO_TIPO_PARTICIPANTE		=	'R'		
			AND		FAE.ORDEN							=    1
	   END

	select CodigoFlujoAprobacionEstadio = FAE.CODIGO_FLUJO_APROBACION_ESTADIO, 
			  CodigoFlujoAprobacion = FAE.CODIGO_FLUJO_APROBACION,
			  Orden= FAE.ORDEN, 
			  Descripcion= FAE.DESCRIPCION, 
			  CodigoResponsable= CASE
								WHEN @ES_VINCULADA = 1 AND ISNULL((SELECT FAPV.CODIGO_TRABAJADOR FROM CTR.FLUJO_APROBACION_PARTICIPANTE FAPV 
																			WHERE FAPV.CODIGO_FLUJO_APROBACION_ESTADIO = FAE.CODIGO_FLUJO_APROBACION_ESTADIO 
																			AND FAPV.ESTADO_REGISTRO = '1' AND FAPV.CODIGO_TIPO_PARTICIPANTE = 'V'), FAP.CODIGO_TRABAJADOR) = @CodigoUsuarioEstadioEdicion THEN ''
								WHEN @ES_VINCULADA = 1 AND ISNULL((SELECT FAPV.CODIGO_TRABAJADOR FROM CTR.FLUJO_APROBACION_PARTICIPANTE FAPV 
																			WHERE FAPV.CODIGO_FLUJO_APROBACION_ESTADIO = FAE.CODIGO_FLUJO_APROBACION_ESTADIO 
																			AND FAPV.ESTADO_REGISTRO = '1' AND FAPV.CODIGO_TIPO_PARTICIPANTE = 'V'), FAP.CODIGO_TRABAJADOR) <> @CodigoUsuarioEstadioEdicion 
																THEN convert(varchar(50),ISNULL((SELECT FAPV.CODIGO_TRABAJADOR FROM CTR.FLUJO_APROBACION_PARTICIPANTE FAPV 
																			WHERE FAPV.CODIGO_FLUJO_APROBACION_ESTADIO = FAE.CODIGO_FLUJO_APROBACION_ESTADIO 
																			AND FAPV.ESTADO_REGISTRO = '1' AND FAPV.CODIGO_TIPO_PARTICIPANTE = 'V'), FAP.CODIGO_TRABAJADOR))						
								WHEN @ES_VINCULADA = 0 AND FAP.CODIGO_TRABAJADOR = @CodigoUsuarioEstadioEdicion THEN ''
								ELSE convert(varchar(50),FAP.CODIGO_TRABAJADOR) END,
			  UsuarioCreacion = @usuarioCreacion
	 from CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK) 
	 INNER JOIN CTR.FLUJO_APROBACION_PARTICIPANTE FAP (NOLOCK)
	 ON ( FAE.CODIGO_FLUJO_APROBACION_ESTADIO=FAP.CODIGO_FLUJO_APROBACION_ESTADIO)	
	WHERE FAP.ESTADO_REGISTRO='1' 
		AND FAE.ESTADO_REGISTRO = '1' 
		AND FAP.CODIGO_TIPO_PARTICIPANTE='R' 
		AND  FAE.ORDEN < @OrdenEstadio
		AND FAE.CODIGO_FLUJO_APROBACION= @CodigoFlujoAprobacion		
	AND EXISTS 
	( SELECT  CE.CODIGO_CONTRATO  FROM CTR.CONTRATO_ESTADIO CE (NOLOCK) 
	  WHERE  CE.CODIGO_FLUJO_APROBACION_ESTADIO = FAE.CODIGO_FLUJO_APROBACION_ESTADIO AND CE.ESTADO_REGISTRO='1'  
	  AND FAP.ESTADO_REGISTRO='1')
	  ORDER BY  FAE.ORDEN

END

GO
/****** Object:  StoredProcedure [CTR].[USP_FLUJO_APROBACION_ESTADIO_DESCRIPCION_EXISTE_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_FLUJO_APROBACION_ESTADIO_DESCRIPCION_EXISTE_SEL]
(
	@CODIGO_FLUJO_APROBACION UNIQUEIDENTIFIER,
	@DESCRIPCION NVARCHAR(255)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_FLUJO_APROBACION_ESTADIO_DESCRIPCION_EXISTE_SEL
Propósito:   Obtiene el listado de aprobación de estadio de descripción existente   
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACION:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
SELECT	CODIGO_FLUJO_APROBACION_ESTADIO CodigoFlujoAprobacionEstadio,
		DESCRIPCION  Descripcion
FROM	CTR.FLUJO_APROBACION_ESTADIO
WHERE	CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION
AND		DESCRIPCION = @DESCRIPCION
AND		ESTADO_REGISTRO = '1'



GO
/****** Object:  StoredProcedure [CTR].[USP_FLUJO_APROBACION_ESTADIO_DESCRIPCION_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_FLUJO_APROBACION_ESTADIO_DESCRIPCION_SEL]
@DESCRIPCION		NVARCHAR(300),
@ESTADO_REGISTRO	CHAR(1)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_FLUJO_APROBACION_ESTADIO_DESCRIPCION_SEL
Propósito:   Obtiene el listado de Estadios de la tabla FLUJO_APROBACION_ESTADIO
Descripción de Parámetros: 
		@DESCRIPCION:		Parámetro de entrada de tipo NVARCHAR, que representa la descripción del flujo de aprobación estadio.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
Creado por: GMD
Fecha. Creación: 2016-06-22
Fecha. Actualización: 
**********************************************************************************************************************************/
IF @DESCRIPCION IS NOT NULL
	BEGIN
		SET @DESCRIPCION = '%' + @DESCRIPCION + '%'
	END

SELECT	FAE.DESCRIPCION			AS Descripcion
FROM	CTR.FLUJO_APROBACION_ESTADIO FAE
WHERE	(FAE.DESCRIPCION LIKE @DESCRIPCION OR @DESCRIPCION IS NULL)
AND		(ESTADO_REGISTRO = @ESTADO_REGISTRO)
GROUP BY FAE.DESCRIPCION

GO
/****** Object:  StoredProcedure [CTR].[USP_FLUJO_APROBACION_ESTADIO_ORDEN_EXISTE_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_FLUJO_APROBACION_ESTADIO_ORDEN_EXISTE_SEL]
(
	@CODIGO_FLUJO_APROBACION UNIQUEIDENTIFIER,
	@ORDEN TINYINT
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_FLUJO_APROBACION_ESTADIO_ORDEN_EXISTE_SEL
Propósito:   Obtiene el listado del flujo de aprobación de orden existente  
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACION:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.
		@ORDEN:	Parámetro de entrada de tipo tinyint, que representa orden.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
SELECT	CODIGO_FLUJO_APROBACION_ESTADIO CodigoFlujoAprobacionEstadio,
		ORDEN		Orden
FROM	CTR.FLUJO_APROBACION_ESTADIO
WHERE	CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION
AND		ORDEN = @ORDEN
AND		ESTADO_REGISTRO = '1'



GO
/****** Object:  StoredProcedure [CTR].[USP_FLUJO_APROBACION_ESTADIO_PRE_INS_UDP]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_FLUJO_APROBACION_ESTADIO_PRE_INS_UDP] (
	@CODIGO_FLUJO_APROBACION_ESTADIO uniqueidentifier,
	@CODIGO_FLUJO_APROBACION uniqueidentifier,
	@ORDEN tinyint,
	@USUARIO_PROCESO nvarchar(50),
	@TERMINAL_PROCESO nvarchar(50),
	@ACCION CHAR(1)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_FLUJO_APROBACION_ESTADIO_PRE_INS_UDP
Propósito:  Reordena registros en base al parametro orden 
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACION_ESTADIO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.
		@CODIGO_FLUJO_APROBACION:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.
		@ORDEN:	Parámetro de entrada de tipo tinyint, que representa orden.
		@USUARIO_PROCESO:	Parámetro de entrada de tipo nvarchar, que representa usuario proceso.
		@TERMINAL_PROCESO:	Parámetro de entrada de tipo nvarchar, que representa terminal proceso.
		@ACCION:	Parámetro de entrada de tipo char, que representa accion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	DECLARE @INCREMENTO INT
	DECLARE @ORDEN_ACTUAL TINYINT
	DECLARE @ORDEN_MINIMO TINYINT
	DECLARE @ORDEN_MAYOR TINYINT

	--Insertar
	IF @ACCION = 'I' BEGIN
		UPDATE CTR.FLUJO_APROBACION_ESTADIO
		   SET ORDEN = ORDEN + 1,
			   USUARIO_MODIFICACION = @USUARIO_PROCESO,
			   FECHA_MODIFICACION = GETDATE(),
			   TERMINAL_MODIFICACION = @TERMINAL_PROCESO
		 WHERE ESTADO_REGISTRO = '1'
		   AND CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION
		   AND ORDEN >= @ORDEN
	END
	--Actualizar
	ELSE IF @ACCION = 'U' BEGIN
		SELECT @ORDEN_ACTUAL = ORDEN
		  FROM CTR.FLUJO_APROBACION_ESTADIO FAE
		 WHERE CODIGO_FLUJO_APROBACION_ESTADIO = @CODIGO_FLUJO_APROBACION_ESTADIO

		IF @ORDEN < @ORDEN_ACTUAL BEGIN
			SET @INCREMENTO = 1
			SET @ORDEN_MINIMO = @ORDEN
			SET @ORDEN_MAYOR = @ORDEN_ACTUAL
		END
		ELSE BEGIN
			SET @INCREMENTO = -1
			SET @ORDEN_MINIMO = @ORDEN_ACTUAL
			SET @ORDEN_MAYOR = @ORDEN
		END

		UPDATE CTR.FLUJO_APROBACION_ESTADIO
		   SET ORDEN = ORDEN + @INCREMENTO,
			   USUARIO_MODIFICACION = @USUARIO_PROCESO,
			   FECHA_MODIFICACION = GETDATE(),
			   TERMINAL_MODIFICACION = @TERMINAL_PROCESO
		 WHERE ESTADO_REGISTRO = '1'
		   AND CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION
		   AND ORDEN BETWEEN @ORDEN_MINIMO AND @ORDEN_MAYOR
	END
	--Eliminar
	ELSE IF @ACCION = 'D' BEGIN
		SELECT @CODIGO_FLUJO_APROBACION = FAE.CODIGO_FLUJO_APROBACION,
			   @ORDEN = FAE.ORDEN
		  FROM CTR.FLUJO_APROBACION_ESTADIO FAE
		 WHERE FAE.CODIGO_FLUJO_APROBACION_ESTADIO = @CODIGO_FLUJO_APROBACION_ESTADIO

		UPDATE CTR.FLUJO_APROBACION_ESTADIO
		   SET ORDEN = ORDEN - 1,
			   USUARIO_MODIFICACION = @USUARIO_PROCESO,
			   FECHA_MODIFICACION = GETDATE(),
			   TERMINAL_MODIFICACION = @TERMINAL_PROCESO
		 WHERE ESTADO_REGISTRO = '1'
		   AND CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION
		   AND ORDEN >= @ORDEN
	END
END

GO
/****** Object:  StoredProcedure [CTR].[USP_FLUJO_APROBACION_ESTADIO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_FLUJO_APROBACION_ESTADIO_SEL]  
(
	@CODIGO_FLUJO_APROBACION_ESTADIO UNIQUEIDENTIFIER = NULL,
	@CODIGO_FLUJO_APROBACION UNIQUEIDENTIFIER = NULL,
	@ESTADO_REGISTRO CHAR(1) = NULL
)
AS 
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_FLUJO_APROBACION_ESTADIO_SEL
Propósito:   Obtiene el listado del flujo de aprobación de estadio  
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACION_ESTADIO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.
		@CODIGO_FLUJO_APROBACION:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
SELECT FAE.CODIGO_FLUJO_APROBACION_ESTADIO AS CodigoFlujoAprobacionEstadio,
	   FAE.CODIGO_FLUJO_APROBACION AS CodigoFlujoAprobacion,
	   FAE.ORDEN AS Orden ,
	   FAE.DESCRIPCION AS Descripcion,
	   FAE.TIEMPO_ATENCION AS TiempoAtencion,
	   FAE.HORAS_ATENCION AS HorasAtencion,
	   FAE.INDICADOR_VERSION_OFICIAL AS IndicadorVersionOficial,
	   FAE.INDICADOR_PERMITE_CARGA AS IndicadorPermiteCarga,
	   FAE.INDICADOR_NUMERO_CONTRATO AS IndicadorNumeroContrato,
	   [CTR].[FN_RETORNA_FLUJO_APROBACION_PARTICIPANTE](FAE.CODIGO_FLUJO_APROBACION_ESTADIO,'R') AS CodigosRepresentante,
	   [CTR].[FN_RETORNA_FLUJO_APROBACION_PARTICIPANTE](FAE.CODIGO_FLUJO_APROBACION_ESTADIO,'I') AS CodigosInformado,
	   [CTR].[FN_RETORNA_FLUJO_APROBACION_PARTICIPANTE](FAE.CODIGO_FLUJO_APROBACION_ESTADIO,'V') AS CodigosResponsableVinculadas,
	   FAE.INDICADOR_INCLUIR_VISTO AS IndicadorIncluirVisto
FROM CTR.FLUJO_APROBACION_ESTADIO FAE
WHERE	(FAE.[CODIGO_FLUJO_APROBACION_ESTADIO] = @CODIGO_FLUJO_APROBACION_ESTADIO OR @CODIGO_FLUJO_APROBACION_ESTADIO IS NULL)
AND		(FAE.[CODIGO_FLUJO_APROBACION] = @CODIGO_FLUJO_APROBACION OR @CODIGO_FLUJO_APROBACION IS NULL)
AND		(ESTADO_REGISTRO = '1')

ORDER BY FAE.ORDEN

GO
/****** Object:  StoredProcedure [CTR].[USP_FLUJO_APROBACION_PARTICIPANTE_DEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_FLUJO_APROBACION_PARTICIPANTE_DEL]
(
    @CODIGO_FLUJO_APROBACION_ESTADIO UNIQUEIDENTIFIER
)
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_FLUJO_APROBACION_PARTICIPANTE_DEL
Propósito:  Elimina los registros de la tabla Flujo_aprobacion_participante 
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACION_ESTADIO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
AS 
	UPDATE CTR.FLUJO_APROBACION_PARTICIPANTE
	   SET ESTADO_REGISTRO = '0'
     WHERE CODIGO_FLUJO_APROBACION_ESTADIO = @CODIGO_FLUJO_APROBACION_ESTADIO

GO
/****** Object:  StoredProcedure [CTR].[USP_FLUJO_APROBACION_PARTICIPANTE_DTS_UPD]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [CTR].[USP_FLUJO_APROBACION_PARTICIPANTE_DTS_UPD]
(
	@CODIGO_SUPLENTE				UNIQUEIDENTIFIER, 
	@CODIGO_TRABAJADOR				UNIQUEIDENTIFIER
)
AS
BEGIN
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_TRABAJADOR_SUPLENTE_DTS_UPD
Propósito: Actualiza los registros de la tabla FLUJO_APROBACION_PARTICIPANTE
Descripción de Parámetros: 
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
UPDATE CTR.FLUJO_APROBACION_PARTICIPANTE
SET 
	CODIGO_TRABAJADOR = @CODIGO_SUPLENTE
WHERE CODIGO_TRABAJADOR_ORIGINAL = @CODIGO_TRABAJADOR

UPDATE CTR.FLUJO_APROBACION
SET 
	CODIGO_PRIMER_FIRMANTE = @CODIGO_SUPLENTE
WHERE CODIGO_PRIMER_FIRMANTE_ORIGINAL = @CODIGO_TRABAJADOR

UPDATE CTR.FLUJO_APROBACION
SET 
	CODIGO_SEGUNDO_FIRMANTE = @CODIGO_SUPLENTE
WHERE CODIGO_SEGUNDO_FIRMANTE_ORIGINAL = @CODIGO_TRABAJADOR

UPDATE [CTR].[CONTRATO_ESTADIO]
SET CODIGO_RESPONSABLE = @CODIGO_SUPLENTE
WHERE CODIGO_CONTRATO IN (
SELECT CODIGO_CONTRATO
FROM CTR.CONTRATO
WHERE ESTADO_REGISTRO = '1'
AND CODIGO_ESTADO = 'A'
AND CODIGO_ESTADIO_ACTUAL IN (
SELECT  CODIGO_FLUJO_APROBACION_ESTADIO
FROM CTR.FLUJO_APROBACION_PARTICIPANTE 
WHERE CODIGO_TRABAJADOR_ORIGINAL = @CODIGO_TRABAJADOR))

END

GO
/****** Object:  StoredProcedure [CTR].[USP_FLUJO_APROBACION_PARTICIPANTE_OBTENER_RESPONSABLE_SIGUIENTE_ESTADIO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_FLUJO_APROBACION_PARTICIPANTE_OBTENER_RESPONSABLE_SIGUIENTE_ESTADIO]
(	
	@CODIGO_FLUJO_APROBACION UNIQUEIDENTIFIER,
	@ORDEN INT,
	@CODIGO_FLUJO_APROBACION_ESTADIO uniqueidentifier,
	@CODIGO_CONTRATO_ESTADIO uniqueidentifier
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_FLUJO_APROBACION_PARTICIPANTE_OBTENER_RESPONSABLE_SIGUIENTE_ESTADIO
Propósito:   Obtiene el responsable del siguiente estadio del flujo de aprobación
Descripción de Parámetros: 	
	@CODIGO_FLUJO_APROBACION: Parámetro de entrada de tipo uniqueidentifier que representa codigo de flujo de aprobación.
	@ORDEN: Parámetro de entrada de tipo integer que representa el orden del estadio.
	@CODIGO_FLUJO_APROBACION_ESTADIO: Parámetro de entrada de tipo uniqueidentifier que representa codigo de flujo de aprobación estadio.
	@CODIGO_CONTRATO_ESTADIO: Parámetro de entrada de tipo uniqueidentifier que representa codigo contrato estadio.
Creado por: GMD
Fecha. Creación: 2017-10-06
Fecha. Actualización: 2017-11-17 Cambio para obtener el responsable de CTR.CONTRATO_ESTADIO 
**********************************************************************************************************************************/
BEGIN

	DECLARE @CODIGO_TRABAJADOR uniqueidentifier,
	@NUMERO_DOCUMENTO VARCHAR (20) = NULL
	
	--SELECT @CODIGO_TRABAJADOR = CODIGO_TRABAJADOR FROM CTR.FLUJO_APROBACION_PARTICIPANTE WHERE CODIGO_FLUJO_APROBACION_ESTADIO = 
	--(SELECT CODIGO_FLUJO_APROBACION_ESTADIO FROM ctr.FLUJO_APROBACION_ESTADIO
	--WHERE ORDEN = 
	--	(Select MIN(ORDEN) from ctr.FLUJO_APROBACION_ESTADIO where CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION 
	--	 AND ORDEN > @ORDEN)
	--AND CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION)
	--AND ESTADO_REGISTRO = '1' AND CODIGO_TIPO_PARTICIPANTE = 'R'

	SELECT  @CODIGO_TRABAJADOR = CODIGO_RESPONSABLE
	FROM CTR.CONTRATO_ESTADIO 
	WHERE CODIGO_CONTRATO = (select CODIGO_CONTRATO from ctr.CONTRATO_ESTADIO where CODIGO_CONTRATO_ESTADIO = @CODIGO_CONTRATO_ESTADIO)
	AND CODIGO_ESTADO_CONTRATO_ESTADIO = 'I'
	
	
	SELECT @CODIGO_TRABAJADOR

END

GO
/****** Object:  StoredProcedure [CTR].[USP_FLUJO_APROBACION_PARTICIPANTE_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_FLUJO_APROBACION_PARTICIPANTE_SEL] --'fc19f8b1-40a2-4c37-8749-dded021df667'
(
	@CODIGO_FLUJO_APROBACION UNIQUEIDENTIFIER
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_FLUJO_APROBACION_PARTICIPANTE_SEL
Propósito:   Obtiene el listado de responsables por estadio
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
Creado por: GMD
Fecha. Creación: 2016-01-27
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN 
SELECT 
      FAP.[CODIGO_FLUJO_APROBACION_ESTADIO] as CodigoFlujoAprobacionEstadio
      ,FAP.[CODIGO_TRABAJADOR] as CodigoTrabajador
      ,FAP.[CODIGO_TIPO_PARTICIPANTE] as CodigoTipoParticipante
	  ,FAE.INDICADOR_INCLUIR_VISTO AS IndicadorIncluirVisto
	  --,FAE.INDICADOR_ES_FIRMANTE AS IndicadorEsFirmante
	 -- ,FAE.ORDEN_FIRMANTE AS OrdenFirmante
  FROM [CTR].FLUJO_APROBACION F
  INNER JOIN [CTR].[FLUJO_APROBACION_ESTADIO] FAE ON FAE.CODIGO_FLUJO_APROBACION = F.CODIGO_FLUJO_APROBACION
  INNER JOIN [CTR].FLUJO_APROBACION_PARTICIPANTE FAP ON FAP.CODIGO_FLUJO_APROBACION_ESTADIO = FAE.CODIGO_FLUJO_APROBACION_ESTADIO
  WHERE F.CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION AND FAE.ESTADO_REGISTRO = 1 AND FAP.ESTADO_REGISTRO = 1 AND F.ESTADO_REGISTRO = 1
  --AND FAE.INDICADOR_INCLUIR_VISTO = 1
  END

GO
/****** Object:  StoredProcedure [CTR].[USP_FLUJO_APROBACION_PARTICIPANTE2_DTS_UPD]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [CTR].[USP_FLUJO_APROBACION_PARTICIPANTE2_DTS_UPD]
(
	@CODIGO_TRABAJADOR				UNIQUEIDENTIFIER
)
AS
BEGIN
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_FLUJO_APROBACION_PARTICIPANTE2_DTS_UPD
Propósito: Actualiza los registros de la tabla FLUJO_APROBACION_PARTICIPANTE
Descripción de Parámetros: 
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
	UPDATE CTR.FLUJO_APROBACION_PARTICIPANTE
		SET	CODIGO_TRABAJADOR = CODIGO_TRABAJADOR_ORIGINAL
	WHERE CODIGO_TRABAJADOR_ORIGINAL = @CODIGO_TRABAJADOR

	UPDATE CTR.FLUJO_APROBACION
		SET	CODIGO_PRIMER_FIRMANTE = CODIGO_PRIMER_FIRMANTE_ORIGINAL
	WHERE CODIGO_PRIMER_FIRMANTE_ORIGINAL = @CODIGO_TRABAJADOR

	UPDATE CTR.FLUJO_APROBACION
		SET	CODIGO_SEGUNDO_FIRMANTE = CODIGO_SEGUNDO_FIRMANTE_ORIGINAL
	WHERE CODIGO_SEGUNDO_FIRMANTE_ORIGINAL = @CODIGO_TRABAJADOR

	UPDATE [CTR].[CONTRATO_ESTADIO]
		SET CODIGO_RESPONSABLE = @CODIGO_TRABAJADOR
	WHERE CODIGO_CONTRATO IN (SELECT CODIGO_CONTRATO FROM CTR.CONTRATO
							WHERE ESTADO_REGISTRO = '1'
							AND CODIGO_ESTADO = 'A'
							AND CODIGO_ESTADIO_ACTUAL IN (
							SELECT  CODIGO_FLUJO_APROBACION_ESTADIO
							FROM CTR.FLUJO_APROBACION_PARTICIPANTE 
							WHERE CODIGO_TRABAJADOR_ORIGINAL = @CODIGO_TRABAJADOR))

	SELECT 1
END

GO
/****** Object:  StoredProcedure [CTR].[USP_FLUJO_APROBACION_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_FLUJO_APROBACION_SEL]
( 
	@CODIGO_FLUJO_APROBACION UNIQUEIDENTIFIER = NULL,
	@CODIGO_UNIDAD_OPERATIVA UNIQUEIDENTIFIER = NULL,
	@INDICADOR_APLICA_MONTO_MINIMO BIT = NULL,
	@ESTADO_REGISTRO CHAR(1) = NULL
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_FLUJO_APROBACION_SEL
Propósito:   Obtiene el listado del flujo de la aprobación  
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACION:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.
		@CODIGO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@INDICADOR_APLICA_MONTO_MINIMO:	Parámetro de entrada de tipo bit, que representa si el estadio aplica la configucación del monto mínimo.
		@CODIGO_FORMA_EDICION:	Parámetro de entrada de tipo nvarchar, que representa codigo forma edicion.		
		@CODIGO_TIPO_REQUERIMIENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo requerimiento.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 2017-10-09 Se agrega obtener primer firmante y segundo firmante para empresa vinculada
**********************************************************************************************************************************/
SELECT [CODIGO_FLUJO_APROBACION] AS CodigoFlujoAprobacion
      ,[CODIGO_UNIDAD_OPERATIVA] AS CodigoUnidadOperativa
	  ,[INDICADOR_APLICA_MONTO_MINIMO] AS IndicadorAplicaMontoMinimo
      ,[ESTADO_REGISTRO] AS estadoRegistro
	  ,[CODIGO_PRIMER_FIRMANTE] AS CodigoPrimerFirmante
	  ,[CODIGO_SEGUNDO_FIRMANTE] AS CodigoSegundoFirmante
	  ,[CODIGO_PRIMER_FIRMANTE_VINCULADA] AS CodigoPrimerFirmanteVinculada
	  ,[CODIGO_SEGUNDO_FIRMANTE_VINCULADA] AS CodigoSegundoFirmanteVinculada
FROM [CTR].[FLUJO_APROBACION]
WHERE	(CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION OR @CODIGO_FLUJO_APROBACION IS NULL)
AND		(CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA OR @CODIGO_UNIDAD_OPERATIVA IS NULL)
AND		(INDICADOR_APLICA_MONTO_MINIMO = @INDICADOR_APLICA_MONTO_MINIMO OR @INDICADOR_APLICA_MONTO_MINIMO IS NULL)
AND ESTADO_REGISTRO = @ESTADO_REGISTRO

ORDER BY CODIGO_UNIDAD_OPERATIVA


GO
/****** Object:  StoredProcedure [CTR].[USP_FLUJO_APROBACION_TIPO_CONTRATO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_FLUJO_APROBACION_TIPO_CONTRATO_SEL]
( 
	@CODIGO_FLUJO_APROBACION_TIPO_CONTRATO	UNIQUEIDENTIFIER = NULL,
	@CODIGO_FLUJO_APROBACION				UNIQUEIDENTIFIER = NULL,
	@CODIGO_TIPO_CONTRATO					NVARCHAR(5) = NULL,
	@ESTADO_REGISTRO						CHAR(1) = NULL
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_FLUJO_APROBACION_TIPO_CONTRATO_SEL
Propósito:   Obtiene el listado del flujo de la aprobación tipo de contrato 
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACION_TIPO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa código flujo aprobación tipo de contrato.
		@CODIGO_FLUJO_APROBACION:	Parámetro de entrada de tipo uniqueidentifier, que representa código flujo aprobación.
		@CODIGO_TIPO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa código tipo contrato.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
Creado por: GMD
Fecha. Creación: 2017-16-21
Fecha. Actualización: 
**********************************************************************************************************************************/
SELECT	CodigoFlujoAprobacionTipoContrato		=	CODIGO_FLUJO_APROBACION_TIPO_CONTRATO,
		CodigoFlujoAprobacion					=	CODIGO_FLUJO_APROBACION,
		CodigoTipoContrato						=	CODIGO_TIPO_CONTRATO,
		EstadoRegistro							=	ESTADO_REGISTRO
FROM [CTR].[FLUJO_APROBACION_TIPO_CONTRATO]
WHERE	(CODIGO_FLUJO_APROBACION_TIPO_CONTRATO	= @CODIGO_FLUJO_APROBACION_TIPO_CONTRATO OR @CODIGO_FLUJO_APROBACION_TIPO_CONTRATO IS NULL)
AND		(CODIGO_FLUJO_APROBACION				= @CODIGO_FLUJO_APROBACION				 OR @CODIGO_FLUJO_APROBACION IS NULL)
AND		(CODIGO_TIPO_CONTRATO					= @CODIGO_TIPO_CONTRATO					 OR @CODIGO_TIPO_CONTRATO IS NULL)
AND		(ESTADO_REGISTRO						= @ESTADO_REGISTRO						 OR @ESTADO_REGISTRO IS NULL)

GO
/****** Object:  StoredProcedure [CTR].[USP_FLUJO_APROBACION_TIPO_SERVICIO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_FLUJO_APROBACION_TIPO_SERVICIO_SEL]
( 
	@CODIGO_FLUJO_APROBACION_TIPO_SERVICIO	UNIQUEIDENTIFIER = NULL,
	@CODIGO_FLUJO_APROBACION				UNIQUEIDENTIFIER = NULL,
	@CODIGO_TIPO_SERVICIO					NVARCHAR(5) = NULL,
	@ESTADO_REGISTRO						CHAR(1) = NULL
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_FLUJO_APROBACION_TIPO_SERVICIO_SEL
Propósito:   Obtiene el listado del flujo de la aprobación tipo de servicio 
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACION_TIPO_SERVICIO:	Parámetro de entrada de tipo uniqueidentifier, que representa código flujo aprobación tipo de servicio.
		@CODIGO_FLUJO_APROBACION:	Parámetro de entrada de tipo uniqueidentifier, que representa código flujo aprobación.
		@CODIGO_TIPO_SERVICIO:	Parámetro de entrada de tipo nvarchar, que representa código tipo servicio.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
Creado por: GMD
Fecha. Creación: 2015-11-24
Fecha. Actualización: 
**********************************************************************************************************************************/
SELECT	CodigoFlujoAprobacionTipoServicio		=	CODIGO_FLUJO_APROBACION_TIPO_SERVICIO,
		CodigoFlujoAprobacion					=	CODIGO_FLUJO_APROBACION,
		CodigoTipoServicio						=	CODIGO_TIPO_SERVICIO,
		EstadoRegistro							=	ESTADO_REGISTRO
FROM [CTR].[FLUJO_APROBACION_TIPO_SERVICIO]
WHERE	(CODIGO_FLUJO_APROBACION_TIPO_SERVICIO	= @CODIGO_FLUJO_APROBACION_TIPO_SERVICIO OR @CODIGO_FLUJO_APROBACION_TIPO_SERVICIO IS NULL)
AND		(CODIGO_FLUJO_APROBACION				= @CODIGO_FLUJO_APROBACION				 OR @CODIGO_FLUJO_APROBACION IS NULL)
AND		(CODIGO_TIPO_SERVICIO					= @CODIGO_TIPO_SERVICIO					 OR @CODIGO_TIPO_SERVICIO IS NULL)
AND		(ESTADO_REGISTRO						= @ESTADO_REGISTRO						 OR @ESTADO_REGISTRO IS NULL)

GO
/****** Object:  StoredProcedure [CTR].[USP_HOJA_RUTA_RPT]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_HOJA_RUTA_RPT]
@CODIGO_UNIDAD_OPERATIVA uniqueidentifier,
@CODIGO_TIPO_SERVICIO nvarchar(5),
@CODIGO_TIPO_REQUERIMIENTO nvarchar(5),
@FECHA_INICIO datetime,
@FECHA_FIN datetime,
@NUMERO_CONTRATO NVARCHAR(50)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_HOJA_RUTA_RPT
Propósito:  Aprueba los estadios de los contratos. 
Descripción de Parámetros: 
		@CODIGO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo de unidad operativa.
		@CODIGO_TIPO_SERVICIO: Párametro de entrada de tipo uniqueidentifier, que representa codigo de tipo de servicio.
		@CODIGO_TIPO_REQUERIMIENTO: Párametro de entrada de tipo uniqueidentifier, que representa codigo de tipo de requerimiento.
		@FECHA_INICIO:	Parámetro de entrada de tipo datetime, que representa fecha inicio.
		@FECHA_FIN:	Parámetro de entrada de tipo datetime, que representa fecha fin.
		@NUMERO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa numero contrato.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	DECLARE @ROWMIN INT, @ROWMAX INT,
			@ROWMIN_ESTADIO INT, @ROWMAX_ESTADIO INT,
			@CODIGO_CONTRATO_TEMP UNIQUEIDENTIFIER,
			@NUMERO_CONTRATO_TEMP nvarchar(MAX),

			@RUC_PROVEEDOR_TEMP nvarchar(MAX),
			@NOMBRE_PROVEEDOR_TEMP nvarchar(MAX), 
			@ORDEN_TEMP INT,
			@DESCRIPCION_ESTADIO_TEMP nvarchar(MAX),
			@FECHA_INGRESO_ESTADIO_TEMP DATETIME,
			@DESCRIPCION_ULTIMO_ESTADIO_TEMP NVARCHAR(MAX),
			@POSICION_TEMP INT

	SELECT 
	CONTRATO.CODIGO_CONTRATO,
	CONTRATO.NUMERO_CONTRATO,
	PROVEEDOR.NUMERO_DOCUMENTO AS RUC_PROVEEDOR,
	PROVEEDOR.NOMBRE AS NOMBRE_PROVEEDOR,
	FLUJO_APROBACION_ESTADIO.ORDEN,


	FLUJO_APROBACION_ESTADIO.DESCRIPCION,
	CONTRATO_ESTADIO.FECHA_INGRESO,
	CAST(0 AS INTEGER) AS POSICION
	INTO #TEMP_CONTRATO_RESULTADO
	FROM CTR.CONTRATO CONTRATO
	INNER JOIN CTR.PROVEEDOR PROVEEDOR ON PROVEEDOR.CODIGO_PROVEEDOR = CONTRATO.CODIGO_PROVEEDOR AND PROVEEDOR.ESTADO_REGISTRO = '1'

	INNER JOIN CTR.CONTRATO_ESTADIO CONTRATO_ESTADIO ON CONTRATO_ESTADIO.CODIGO_CONTRATO = CONTRATO.CODIGO_CONTRATO AND CONTRATO_ESTADIO.ESTADO_REGISTRO = '1'
	INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FLUJO_APROBACION_ESTADIO ON FLUJO_APROBACION_ESTADIO.CODIGO_FLUJO_APROBACION_ESTADIO = CONTRATO_ESTADIO.CODIGO_FLUJO_APROBACION_ESTADIO AND FLUJO_APROBACION_ESTADIO.ESTADO_REGISTRO = '1'
	WHERE 1 = 2


	SELECT ROW_NUMBER() OVER(ORDER BY CONTRATO.NUMERO_CONTRATO ASC) AS ROW_ID, 
		   CONTRATO.CODIGO_CONTRATO,
		   CONTRATO.NUMERO_CONTRATO,
		   CONTRATO.CODIGO_PROVEEDOR,
		   PROVEEDOR.NUMERO_DOCUMENTO AS RUC_PROVEEDOR,
		   PROVEEDOR.NOMBRE AS NOMBRE_PROVEEDOR
	INTO #TABLE_CONTRATO_CONSULTA
	FROM CTR.CONTRATO CONTRATO
	INNER JOIN CTR.PROVEEDOR PROVEEDOR ON PROVEEDOR.CODIGO_PROVEEDOR = CONTRATO.CODIGO_PROVEEDOR AND PROVEEDOR.ESTADO_REGISTRO = '1'
	WHERE
			(CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA OR @CODIGO_UNIDAD_OPERATIVA IS NULL)
		AND (CODIGO_TIPO_SERVICIO = @CODIGO_TIPO_SERVICIO OR @CODIGO_TIPO_SERVICIO = '' OR @CODIGO_TIPO_SERVICIO IS NULL)
		AND (CODIGO_TIPO_REQUERIMIENTO = @CODIGO_TIPO_REQUERIMIENTO OR @CODIGO_TIPO_REQUERIMIENTO = '' OR @CODIGO_TIPO_REQUERIMIENTO IS NULL)
		AND (NUMERO_CONTRATO = @NUMERO_CONTRATO OR @NUMERO_CONTRATO = '' OR @NUMERO_CONTRATO IS NULL)
		AND (CONTRATO.FECHA_CREACION >= @FECHA_INICIO OR  @FECHA_INICIO IS NULL)
		AND (CONTRATO.FECHA_CREACION <= @FECHA_FIN OR  @FECHA_FIN IS NULL)

		AND CONTRATO.ESTADO_REGISTRO = '1'
	ORDER BY CONTRATO.NUMERO_CONTRATO ASC


	SELECT @ROWMIN=MIN(ROW_ID),@ROWMAX= MAX(ROW_ID) FROM #TABLE_CONTRATO_CONSULTA
	
	WHILE @ROWMIN<=@ROWMAX
	BEGIN
		SET @POSICION_TEMP = 0
		SET @DESCRIPCION_ULTIMO_ESTADIO_TEMP = NULL
		SELECT 
			@CODIGO_CONTRATO_TEMP = TABLE_CONTRATO_CONSULTA.CODIGO_CONTRATO,
			@NUMERO_CONTRATO_TEMP = TABLE_CONTRATO_CONSULTA.NUMERO_CONTRATO,

			@RUC_PROVEEDOR_TEMP = TABLE_CONTRATO_CONSULTA.RUC_PROVEEDOR,
			@NOMBRE_PROVEEDOR_TEMP = TABLE_CONTRATO_CONSULTA.NOMBRE_PROVEEDOR
		FROM #TABLE_CONTRATO_CONSULTA TABLE_CONTRATO_CONSULTA
		WHERE ROW_ID = @ROWMIN

		SELECT 
			 ROW_NUMBER() OVER(ORDER BY (SELECT CE.FECHA_INGRESO)) AS ROW_ID,
			 FLUJO_APROBACION_ESTADIO.DESCRIPCION,
			 CE.FECHA_INGRESO,
			 FLUJO_APROBACION_ESTADIO.ORDEN

		INTO #TABLE_CONTRATO_ESTADIOS_POR_CONTRATO
		FROM CTR.CONTRATO_ESTADIO CE
		INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FLUJO_APROBACION_ESTADIO ON FLUJO_APROBACION_ESTADIO.CODIGO_FLUJO_APROBACION_ESTADIO = CE.CODIGO_FLUJO_APROBACION_ESTADIO AND FLUJO_APROBACION_ESTADIO.ESTADO_REGISTRO = '1'
		WHERE CODIGO_CONTRATO = @CODIGO_CONTRATO_TEMP
		AND CE.ESTADO_REGISTRO = '1'
		ORDER BY CE.FECHA_INGRESO ASC
		
		SELECT @ROWMIN_ESTADIO=MIN(ROW_ID),@ROWMAX_ESTADIO= MAX(ROW_ID) FROM #TABLE_CONTRATO_ESTADIOS_POR_CONTRATO

			WHILE @ROWMIN_ESTADIO<=@ROWMAX_ESTADIO
			BEGIN

				SELECT 
					@DESCRIPCION_ESTADIO_TEMP = DESCRIPCION,
					@FECHA_INGRESO_ESTADIO_TEMP = FECHA_INGRESO,
					@ORDEN_TEMP = ORDEN
				FROM #TABLE_CONTRATO_ESTADIOS_POR_CONTRATO
				WHERE ROW_ID = @ROWMIN_ESTADIO

				IF @DESCRIPCION_ULTIMO_ESTADIO_TEMP IS NULL OR @DESCRIPCION_ULTIMO_ESTADIO_TEMP != @DESCRIPCION_ESTADIO_TEMP
				BEGIN
					INSERT INTO #TEMP_CONTRATO_RESULTADO VALUES(
					@CODIGO_CONTRATO_TEMP, 
					@NUMERO_CONTRATO_TEMP, 
					@RUC_PROVEEDOR_TEMP, 
					@NOMBRE_PROVEEDOR_TEMP,
					@ORDEN_TEMP, 
					@DESCRIPCION_ESTADIO_TEMP, 
					@FECHA_INGRESO_ESTADIO_TEMP, 
					@POSICION_TEMP)

					SET @POSICION_TEMP = @POSICION_TEMP+1
					SET @DESCRIPCION_ULTIMO_ESTADIO_TEMP = @DESCRIPCION_ESTADIO_TEMP
				END
				
				SET @ROWMIN_ESTADIO = @ROWMIN_ESTADIO + 1
			END

		DROP TABLE #TABLE_CONTRATO_ESTADIOS_POR_CONTRATO

	SET @ROWMIN = @ROWMIN + 1


	END

	SELECT CODIGO_CONTRATO,
	NUMERO_CONTRATO,
	RUC_PROVEEDOR,
	NOMBRE_PROVEEDOR,
	ORDEN,
	DESCRIPCION,
	FECHA_INGRESO,
	POSICION
	FROM #TEMP_CONTRATO_RESULTADO
	ORDER BY NUMERO_CONTRATO ASC, POSICION ASC
END

GO
/****** Object:  StoredProcedure [CTR].[USP_INDICADOR_NUMERO_CONTRATO_UPD]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_INDICADOR_NUMERO_CONTRATO_UPD]
(
	@CODIGO_FLUJO_APROBACION UNIQUEIDENTIFIER,
	@USUARIO_MODIFICACION NVARCHAR(5),
	@TERMINAL_MODIFICACION NVARCHAR(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_INDICADOR_NUMERO_CONTRATO_UPD
Propósito:   Permite actualizar el indicador del número de contrato  
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACION:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

UPDATE CTR.FLUJO_APROBACION_ESTADIO
SET INDICADOR_NUMERO_CONTRATO = 0,
	USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
	FECHA_MODIFICACION = GETDATE(),
	TERMINAL_MODIFICACION = @TERMINAL_MODIFICACION
WHERE CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION
AND  INDICADOR_NUMERO_CONTRATO = 1
AND ESTADO_REGISTRO = '1'
END



GO
/****** Object:  StoredProcedure [CTR].[USP_INDICADOR_VERSION_OFICIAL_UPDATE]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_INDICADOR_VERSION_OFICIAL_UPDATE]
(
	@CODIGO_FLUJO_APROBACION UNIQUEIDENTIFIER,
	@USUARIO_MODIFICACION NVARCHAR(5),
	@TERMINAL_MODIFICACION NVARCHAR(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_INDICADOR_VERSION_OFICIAL_UPDATE
Propósito:   Permite actualizar el indicador de versión oficial  
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACION:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

UPDATE CTR.FLUJO_APROBACION_ESTADIO
SET INDICADOR_VERSION_OFICIAL = 0,
	USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
	FECHA_MODIFICACION = GETDATE(),
	TERMINAL_MODIFICACION = @TERMINAL_MODIFICACION


WHERE CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION
AND  INDICADOR_VERSION_OFICIAL = 1
AND ESTADO_REGISTRO = '1'

END













GO
/****** Object:  StoredProcedure [CTR].[USP_INF_NOTIFICACION_CONTRATO_ESTADIO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_INF_NOTIFICACION_CONTRATO_ESTADIO_SEL]
@CODIGO_CONTRATO_ESTADIO uniqueidentifier,
@TIPO_NOTIFICACION		 NVARCHAR(2)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_INF_NOTIFICACION_CONTRATO_ESTADIO_SEL
Propósito:  Obtener registros de tabla 
Descripción de Parámetros: 
		@CODIGO_CONTRATO_ESTADIO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio.
		@TIPO_NOTIFICACION:	Parámetro de entrada de tipo nvarchar, que representa tipo notificacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	
	declare @DESCRIPCION_OBS nvarchar(max)
	declare @RESPONSABLE_CORREO uniqueidentifier,
			@CODIGO_CONTRATO uniqueidentifier
	declare @TBL_ESTADIO_ANTERIOR_CE table ( CODIGO_FAE uniqueidentifier,
											 CODIGO_RESPONSABLE uniqueidentifier )

	IF @TIPO_NOTIFICACION='03'
	BEGIN
		SELECT @RESPONSABLE_CORREO= DESTINATARIO FROM CTR.CONTRATO_ESTADIO_CONSULTA (NOLOCK) 
		WHERE CODIGO_CONTRATO_ESTADIO=@CODIGO_CONTRATO_ESTADIO AND ESTADO_REGISTRO='1'
		AND FECHA_CREACION = ( SELECT MAX(FECHA_CREACION) FROM CTR.CONTRATO_ESTADIO_CONSULTA (NOLOCK)  WHERE   CODIGO_CONTRATO_ESTADIO=@CODIGO_CONTRATO_ESTADIO  )
	END
	IF @TIPO_NOTIFICACION='05' --Observado
	BEGIN
		SELECT 
			 @RESPONSABLE_CORREO = DESTINATARIO,
			 @DESCRIPCION_OBS    = DESCRIPCION
		FROM CTR.CONTRATO_ESTADIO_OBSERVACION (NOLOCK) 
		WHERE 
				CODIGO_CONTRATO_ESTADIO=@CODIGO_CONTRATO_ESTADIO 
			AND ESTADO_REGISTRO='1'
			AND FECHA_CREACION = ( SELECT MAX(FECHA_CREACION) FROM CTR.CONTRATO_ESTADIO_OBSERVACION (NOLOCK)  WHERE   CODIGO_CONTRATO_ESTADIO=@CODIGO_CONTRATO_ESTADIO)
	END
	IF @TIPO_NOTIFICACION='06'
	BEGIN
		SELECT 
			  @CODIGO_CONTRATO=CODIGO_CONTRATO 
		FROM  CTR.CONTRATO_ESTADIO CE (NOLOCK) 
		WHERE CE.CODIGO_CONTRATO_ESTADIO = @CODIGO_CONTRATO_ESTADIO
			
		INSERT INTO @TBL_ESTADIO_ANTERIOR_CE (CODIGO_FAE, CODIGO_RESPONSABLE)
		EXEC CTR.USP_ESTADIO_ANTERIOR_CONTRATO_ESTADIO @CODIGO_CONTRATO_ESTADIO,@CODIGO_CONTRATO

		SELECT @RESPONSABLE_CORREO =CODIGO_RESPONSABLE 
		FROM @TBL_ESTADIO_ANTERIOR_CE		
	END

	SELECT 
		CASE 
			WHEN CT.CODIGO_TIPO_DOCUMENTO = 'A' 
			THEN ISNULL(CT.NUMERO_ADENDA_CONCATENADO,'SIN NUMERO') COLLATE Latin1_General_CI_AS 
			ELSE ISNULL(CT.NUMERO_CONTRATO,'SIN NUMERO') 
		END NumeroContrato,
			CodigoUnidadOperativa	= CT.CODIGO_UNIDAD_OPERATIVA,
		    NombreProveedor			= ( SELECT PR.NOMBRE FROM CTR.PROVEEDOR PR (NOLOCK) WHERE PR.CODIGO_PROVEEDOR=CT.CODIGO_PROVEEDOR ),
			CodigoResponsable		= ( CASE WHEN @TIPO_NOTIFICACION in ('03','05','06') 
											THEN  @RESPONSABLE_CORREO 
											ELSE CTR.FN_RETORNA_RESPONSABLE_FLUJO_ESTADIO(CE.CODIGO_FLUJO_APROBACION_ESTADIO, @CODIGO_CONTRATO_ESTADIO) END ),
			 Informados			    = CTR.FN_RETORNA_INFORMADOS_ESTADIO(CE.CODIGO_FLUJO_APROBACION_ESTADIO),
			 DescripcionObservacion = ( CASE WHEN @TIPO_NOTIFICACION = '05'
			 						  	THEN  @DESCRIPCION_OBS 
			 		  					ELSE '' END ),
			 DescripcionContrato	= ISNULL(CT.DESCRIPCION,''),
			 UsuarioCreacion		= ISNULL(CT.USUARIO_CREACION,'')
		FROM CTR.CONTRATO_ESTADIO CE (NOLOCK) 
			 INNER JOIN CTR.CONTRATO CT (NOLOCK) ON ( CT.CODIGO_CONTRATO=CE.CODIGO_CONTRATO )
		WHERE CE.CODIGO_CONTRATO_ESTADIO=@CODIGO_CONTRATO_ESTADIO		
END



GO
/****** Object:  StoredProcedure [CTR].[USP_INSERT_CONTRATO_SQL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_INSERT_CONTRATO_SQL] --'Arrendamiento de Oficina - TEST'
  @TITULO_PLANTILLA_NUEVA VARCHAR(250)
 --,@DESCRIPCION_PLANTILLA_COPIAR NVARCHAR(255)
AS
BEGIN

DECLARE @CODIGO_PLANTILLA_COPIAR UNIQUEIDENTIFIER = 'CEB8B066-2F90-4E52-AA73-2FFB2EF5CD29'--(SELECT [CODIGO_PLANTILLA] FROM [CTR].[PLANTILLA] WHERE [DESCRIPCION] = @DESCRIPCION_PLANTILLA_COPIAR)

SELECT * 
INTO #TMP_PLANTILLA
FROM [CTR].[PLANTILLA]
WHERE [CODIGO_PLANTILLA] = @CODIGO_PLANTILLA_COPIAR

DECLARE @CODIGO_PLANTILLA_NUEVA UNIQUEIDENTIFIER = NEWID()

INSERT 
INTO [CTR].[PLANTILLA] 
VALUES
(
	 @CODIGO_PLANTILLA_NUEVA
	,@TITULO_PLANTILLA_NUEVA--(SELECT DESCRIPCION FROM #TMP_PLANTILLA)
	,'OSV'--(SELECT CODIGO_TIPO_SERVICIO FROM #TMP_PLANTILLA)
	,(SELECT CODIGO_TIPO_REQUERIMIENTO FROM #TMP_PLANTILLA)
	,(SELECT CODIGO_TIPO_DOCUMENTO FROM #TMP_PLANTILLA)
	,(SELECT CODIGO_ESTADO FROM #TMP_PLANTILLA)
	,(SELECT INDICADOR_ADHESION FROM #TMP_PLANTILLA)
	,(SELECT FECHA_INICIO_VIGENCIA FROM #TMP_PLANTILLA)
	,(SELECT FECHA_FIN_VIGENCIA FROM #TMP_PLANTILLA)
	,(SELECT ESTADO_REGISTRO FROM #TMP_PLANTILLA)
	,'SCRIPT'--(SELECT USUARIO_CREACION FROM #TMP_PLANTILLA)
	, GETDATE()
	,(SELECT TERMINAL_CREACION FROM #TMP_PLANTILLA)
	,(SELECT USUARIO_MODIFICACION FROM #TMP_PLANTILLA)
	,(SELECT FECHA_MODIFICACION FROM #TMP_PLANTILLA)
	,(SELECT TERMINAL_MODIFICACION FROM #TMP_PLANTILLA)
)

DECLARE @TMP_PLANTILLA_PARRAFO AS TABLE(
	   ROW_ID INT IDENTITY(1,1)
	  ,[CODIGO_PLANTILLA_PARRAFO] UNIQUEIDENTIFIER
	  ,[ORDEN] TINYINT
      ,[TITULO] NVARCHAR(255)
      ,[CONTENIDO] VARCHAR (MAX)
      ,[ESTADO_REGISTRO] CHAR(1)
      ,[USUARIO_CREACION] NVARCHAR(50)
      ,[FECHA_CREACION] DATETIME
      ,[TERMINAL_CREACION] NVARCHAR(50)
      ,[USUARIO_MODIFICACION] NVARCHAR(50)
      ,[FECHA_MODIFICACION] DATETIME
      ,[TERMINAL_MODIFICACION] NVARCHAR(50)
)

INSERT @TMP_PLANTILLA_PARRAFO
SELECT 
	  NEWID()
	  ,[ORDEN]
      ,[TITULO]
      ,[CONTENIDO]
      ,[ESTADO_REGISTRO]
      ,[USUARIO_CREACION]
      ,GETDATE()
      ,[TERMINAL_CREACION]
      ,'SCRIPT'--[USUARIO_MODIFICACION]
      ,[FECHA_MODIFICACION]
      ,[TERMINAL_MODIFICACION]
FROM [CTR].[PLANTILLA_PARRAFO]
WHERE CODIGO_PLANTILLA = @CODIGO_PLANTILLA_COPIAR
--AND [TITULO] != 'P9'

--SELECT * 
--INTO #TMP_PLANTILLA_PARRAFO
--FROM [CTR].[PLANTILLA_PARRAFO]
--WHERE CODIGO_PLANTILLA = '3215280C-4BE7-4A8A-A2BF-D3CD0F0FD356'

DECLARE 
@I_ROW_MIN INT =1,
@I_ROW_MAX INT = (SELECT COUNT(ROW_ID) FROM @TMP_PLANTILLA_PARRAFO),
@NEW_ID UNIQUEIDENTIFIER

WHILE(@I_ROW_MIN <= @I_ROW_MAX)
BEGIN
	SET @NEW_ID =  NEWID()
	INSERT 
	INTO [CTR].[PLANTILLA_PARRAFO]
	VALUES
	(
		   @NEW_ID
		  ,@CODIGO_PLANTILLA_NUEVA
		  ,(SELECT [ORDEN] FROM @TMP_PLANTILLA_PARRAFO WHERE ROW_ID = @I_ROW_MIN)
		  ,(SELECT [TITULO] FROM @TMP_PLANTILLA_PARRAFO WHERE ROW_ID = @I_ROW_MIN)
		  ,(SELECT [CONTENIDO] FROM @TMP_PLANTILLA_PARRAFO WHERE ROW_ID = @I_ROW_MIN)
		  ,(SELECT [ESTADO_REGISTRO] FROM @TMP_PLANTILLA_PARRAFO WHERE ROW_ID = @I_ROW_MIN)
		  ,(SELECT [USUARIO_CREACION] FROM @TMP_PLANTILLA_PARRAFO WHERE ROW_ID = @I_ROW_MIN)
		  ,(SELECT [FECHA_CREACION] FROM @TMP_PLANTILLA_PARRAFO WHERE ROW_ID = @I_ROW_MIN)
		  ,(SELECT [TERMINAL_CREACION] FROM @TMP_PLANTILLA_PARRAFO WHERE ROW_ID = @I_ROW_MIN)
		  ,(SELECT [USUARIO_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO WHERE ROW_ID = @I_ROW_MIN)
		  ,(SELECT [FECHA_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO WHERE ROW_ID = @I_ROW_MIN)
		  ,(SELECT [TERMINAL_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO WHERE ROW_ID = @I_ROW_MIN)
	)

	UPDATE @TMP_PLANTILLA_PARRAFO SET [CODIGO_PLANTILLA_PARRAFO] = @NEW_ID WHERE ROW_ID = @I_ROW_MIN

	SET @I_ROW_MIN = @I_ROW_MIN +1
END

DECLARE @TMP_PLANTILLA_PARRAFO_VARIABLE AS TABLE(
	   ROW_ID INT IDENTITY(1,1)
	  ,[CODIGO_PLANTILLA_PARRAFO] UNIQUEIDENTIFIER
	  ,[TITULO] VARCHAR(200)
      ,[CODIGO_VARIABLE] UNIQUEIDENTIFIER
      ,[ORDEN] SMALLINT
      ,[ESTADO_REGISTRO] CHAR(1)
      ,[USUARIO_CREACION] NVARCHAR(50)
      ,[FECHA_CREACION] DATETIME
      ,[TERMINAL_CREACION] NVARCHAR(50)
      ,[USUARIO_MODIFICACION] NVARCHAR(50)
      ,[FECHA_MODIFICACION] DATETIME
      ,[TERMINAL_MODIFICACION] NVARCHAR(50)
)

INSERT @TMP_PLANTILLA_PARRAFO_VARIABLE
SELECT 
	   P.[CODIGO_PLANTILLA_PARRAFO]
	  ,F.[TITULO]
      ,[CODIGO_VARIABLE]
      ,P.[ORDEN] 
      ,P.[ESTADO_REGISTRO]
      ,P.[USUARIO_CREACION]
      ,GETDATE()
      ,P.[TERMINAL_CREACION]
      ,'SCRIPT'--P.[USUARIO_MODIFICACION]
      ,P.[FECHA_MODIFICACION]
      ,P.[TERMINAL_MODIFICACION]
--INTO #TMP_PLANTILLA_PARRAFO_VARIABLE
FROM [CTR].[PLANTILLA_PARRAFO_VARIABLE] P
INNER JOIN [STRACON_SGC].[CTR].[PLANTILLA_PARRAFO] F
ON P.[CODIGO_PLANTILLA_PARRAFO] = F.[CODIGO_PLANTILLA_PARRAFO]
WHERE F.[CODIGO_PLANTILLA] = @CODIGO_PLANTILLA_COPIAR 


DECLARE 
@I_ROW_MIN_PARRAFO_VARIABLE INT =1,
@I_ROW_MAX_PARRAFO_VARIABLE INT = (SELECT MAX(ROW_ID) FROM @TMP_PLANTILLA_PARRAFO_VARIABLE),
@I_ROW_MIN_PARRAFO INT =1,
@I_ROW_MAX_PARRAFO INT = (SELECT MAX(ROW_ID) FROM @TMP_PLANTILLA_PARRAFO)

WHILE(@I_ROW_MIN_PARRAFO_VARIABLE <= @I_ROW_MAX_PARRAFO_VARIABLE)
BEGIN

	WHILE(@I_ROW_MIN_PARRAFO <= @I_ROW_MAX_PARRAFO)
	BEGIN
		
		IF((SELECT TITULO FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE) = (SELECT [TITULO] FROM @TMP_PLANTILLA_PARRAFO WHERE ROW_ID = @I_ROW_MIN_PARRAFO))
		BEGIN
			INSERT 
			INTO [CTR].[PLANTILLA_PARRAFO_VARIABLE]
			VALUES
			(
				   NEWID()
				  ,(SELECT CODIGO_PLANTILLA_PARRAFO FROM @TMP_PLANTILLA_PARRAFO WHERE TITULO = (SELECT [TITULO] FROM @TMP_PLANTILLA_PARRAFO WHERE ROW_ID = @I_ROW_MIN_PARRAFO))
				  ,(SELECT [CODIGO_VARIABLE] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
				  ,(SELECT [ORDEN] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
				  ,(SELECT [ESTADO_REGISTRO] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
				  ,(SELECT [USUARIO_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
				  ,(SELECT [FECHA_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
				  ,(SELECT [TERMINAL_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
				  ,(SELECT [USUARIO_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
				  ,(SELECT [FECHA_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
				  ,(SELECT [TERMINAL_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
			)
		END

		SET @I_ROW_MIN_PARRAFO = @I_ROW_MIN_PARRAFO + 1

	END

	--IF((SELECT TITULO FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE) = 'P1')
	--BEGIN
	--	INSERT 
	--	INTO [CTR].[PLANTILLA_PARRAFO_VARIABLE]
	--	VALUES
	--	(
	--		   NEWID()
	--		  ,(SELECT CODIGO_PLANTILLA_PARRAFO FROM @TMP_PLANTILLA_PARRAFO WHERE TITULO = 'P1')
	--		  ,(SELECT [CODIGO_VARIABLE] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ORDEN] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ESTADO_REGISTRO] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--	)
	--END
	--ELSE IF((SELECT TITULO FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE) = 'P2')
	--BEGIN
	--	INSERT 
	--	INTO [CTR].[PLANTILLA_PARRAFO_VARIABLE]
	--	VALUES
	--	(
	--		   NEWID()
	--		  ,(SELECT CODIGO_PLANTILLA_PARRAFO FROM @TMP_PLANTILLA_PARRAFO WHERE TITULO = 'P2')
	--		  ,(SELECT [CODIGO_VARIABLE] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ORDEN] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ESTADO_REGISTRO] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--	)
	--END
	--ELSE IF((SELECT TITULO FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE) = 'P3')
	--BEGIN
	--	INSERT 
	--	INTO [CTR].[PLANTILLA_PARRAFO_VARIABLE]
	--	VALUES
	--	(
	--		   NEWID()
	--		  ,(SELECT CODIGO_PLANTILLA_PARRAFO FROM @TMP_PLANTILLA_PARRAFO WHERE TITULO = 'P3')
	--		  ,(SELECT [CODIGO_VARIABLE] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ORDEN] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ESTADO_REGISTRO] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--	)
	--END
	--ELSE IF((SELECT TITULO FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE) = 'P4')
	--BEGIN
	--	INSERT 
	--	INTO [CTR].[PLANTILLA_PARRAFO_VARIABLE]
	--	VALUES
	--	(
	--		   NEWID()
	--		  ,(SELECT CODIGO_PLANTILLA_PARRAFO FROM @TMP_PLANTILLA_PARRAFO WHERE TITULO = 'P4')
	--		  ,(SELECT [CODIGO_VARIABLE] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ORDEN] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ESTADO_REGISTRO] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--	)
	--END
	--ELSE IF((SELECT TITULO FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE) = 'P5')
	--BEGIN
	--	INSERT 
	--	INTO [CTR].[PLANTILLA_PARRAFO_VARIABLE]
	--	VALUES
	--	(
	--		   NEWID()
	--		  ,(SELECT CODIGO_PLANTILLA_PARRAFO FROM @TMP_PLANTILLA_PARRAFO WHERE TITULO = 'P5')
	--		  ,(SELECT [CODIGO_VARIABLE] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ORDEN] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ESTADO_REGISTRO] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--	)
	--END
	--ELSE IF((SELECT TITULO FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE) = 'P6')
	--BEGIN
	--	INSERT 
	--	INTO [CTR].[PLANTILLA_PARRAFO_VARIABLE]
	--	VALUES
	--	(
	--		   NEWID()
	--		  ,(SELECT CODIGO_PLANTILLA_PARRAFO FROM @TMP_PLANTILLA_PARRAFO WHERE TITULO = 'P6')
	--		  ,(SELECT [CODIGO_VARIABLE] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ORDEN] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ESTADO_REGISTRO] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--	)
	--END
	--ELSE IF((SELECT TITULO FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE) = 'P7')
	--BEGIN
	--	INSERT 
	--	INTO [CTR].[PLANTILLA_PARRAFO_VARIABLE]
	--	VALUES
	--	(
	--		   NEWID()
	--		  ,(SELECT CODIGO_PLANTILLA_PARRAFO FROM @TMP_PLANTILLA_PARRAFO WHERE TITULO = 'P7')
	--		  ,(SELECT [CODIGO_VARIABLE] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ORDEN] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ESTADO_REGISTRO] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--	)
	--END
	--ELSE IF((SELECT TITULO FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE) = 'P8')
	--BEGIN
	--	INSERT 
	--	INTO [CTR].[PLANTILLA_PARRAFO_VARIABLE]
	--	VALUES
	--	(
	--		   NEWID()
	--		  ,(SELECT CODIGO_PLANTILLA_PARRAFO FROM @TMP_PLANTILLA_PARRAFO WHERE TITULO = 'P8')
	--		  ,(SELECT [CODIGO_VARIABLE] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ORDEN] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [ESTADO_REGISTRO] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_CREACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [USUARIO_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [FECHA_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--		  ,(SELECT [TERMINAL_MODIFICACION] FROM @TMP_PLANTILLA_PARRAFO_VARIABLE WHERE ROW_ID = @I_ROW_MIN_PARRAFO_VARIABLE)
	--	)
	--END
		SET @I_ROW_MIN_PARRAFO_VARIABLE = @I_ROW_MIN_PARRAFO_VARIABLE + 1
	END
END
--GO 
--EXEC [CTR].[USP_INSERT_CONTRATO_SQL] 'COPIA 1'

GO
/****** Object:  StoredProcedure [CTR].[USP_LISTA_NOTIFICAR_ESCALAMIENTO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_LISTA_NOTIFICAR_ESCALAMIENTO_SEL]
AS
BEGIN

	DECLARE @MAX_ROW INT = (SELECT COUNT(1) FROM TMP.LISTA_CORREO_ESCALAMIENTO)
	DECLARE @MIN_ROW INT = 1
	DECLARE @FECHA_ESCALAMIENTO_1 DATETIME,
		@FECHA_ESCALAMIENTO_2 DATETIME,
		@FECHA_ESCALAMIENTO_3 DATETIME,
		@FECHA_ESCALAMIENTO_4 DATETIME,
		@CODIGO_TRABAJADOR1 UNIQUEIDENTIFIER,
		@CODIGO_TRABAJADOR2 UNIQUEIDENTIFIER,
		@CODIGO_TRABAJADOR3 UNIQUEIDENTIFIER,
		@CODIGO_TRABAJADOR4 UNIQUEIDENTIFIER,
		@CODIGO_CONTRATO UNIQUEIDENTIFIER,
		@NOMBRE_COMPLETO_1 VARCHAR(MAX),
		@NOMBRE_COMPLETO_2 VARCHAR(MAX),
		@NOMBRE_COMPLETO_3 VARCHAR(MAX),
		@NOMBRE_COMPLETO_4 VARCHAR(MAX),
		@CORREO_ELECTRONICO_1 VARCHAR(MAX),
		@CORREO_ELECTRONICO_2 VARCHAR(MAX),
		@CORREO_ELECTRONICO_3 VARCHAR(MAX),
		@CORREO_ELECTRONICO_4 VARCHAR(MAX),
		@NUMERO_CONTRATO VARCHAR(MAX),
		@DIRECCION_SISTEMA VARCHAR(MAX),
		@FECHA_ACTUAL DATE = CAST (GETDATE() AS DATE),
		@ASUNTO VARCHAR(MAX),
		@CONTENIDO VARCHAR(MAX),
		@NOMBRE_RESPONSABLE VARCHAR(MAX),
		@FECHA_VENCIMIENTO DATE,
		@EMISOR VARCHAR(MAX)

DECLARE @TABLE_NOTIFICAR AS TABLE
(
	CODIGO_TRABAJADOR UNIQUEIDENTIFIER,
    CODIGO_CONTRATO UNIQUEIDENTIFIER,
    NOMBRE_COMPLETO VARCHAR(255),
    CORREO_ELECTRONICO NVARCHAR(50),
    NUMERO_CONTRATO NVARCHAR(50),
    DIRECCION_SISTEMA VARCHAR(MAX),
	ASUNTO VARCHAR(MAX),
	CONTENIDO VARCHAR(MAX),
	NOMBRE_RESPONSABLE VARCHAR(MAX),
	FECHA_VENCIMIENTO DATE,
	EMISOR VARCHAR(MAX)
)

SELECT 
	ROW_NUMBER() OVER (ORDER BY CODIGO_CONTRATO DESC) AS ROW_ID,
	*
INTO #TEMP_LISTA
FROM TMP.LISTA_CORREO_ESCALAMIENTO

WHILE(@MIN_ROW <= @MAX_ROW)
BEGIN
	SELECT
		 @FECHA_ESCALAMIENTO_1 =  CAST (FECHA_NTF_ESCALAMIENTO_1 AS DATE)
		,@FECHA_ESCALAMIENTO_2 =  CAST (FECHA_NTF_ESCALAMIENTO_2 AS DATE)
		,@FECHA_ESCALAMIENTO_3 =  CAST (FECHA_NTF_ESCALAMIENTO_3 AS DATE)
		,@FECHA_ESCALAMIENTO_4 =  CAST (FECHA_NTF_ESCALAMIENTO_4 AS DATE)
		,@CODIGO_TRABAJADOR1 = CODIGO_TRABAJADOR_1
		,@CODIGO_TRABAJADOR2 = CODIGO_TRABAJADOR_2
		,@CODIGO_TRABAJADOR3 = CODIGO_TRABAJADOR_3
		,@CODIGO_TRABAJADOR4 = CODIGO_TRABAJADOR_4
		,@CODIGO_CONTRATO = CODIGO_CONTRATO
		,@NOMBRE_COMPLETO_1 = NOMBRE_COMPLETO_1
		,@NOMBRE_COMPLETO_2 = NOMBRE_COMPLETO_2
		,@NOMBRE_COMPLETO_3 = NOMBRE_COMPLETO_3
		,@NOMBRE_COMPLETO_4 = NOMBRE_COMPLETO_4
		,@CORREO_ELECTRONICO_1 = CORREO_ELECTRONICO_1
		,@CORREO_ELECTRONICO_2 = CORREO_ELECTRONICO_2
		,@CORREO_ELECTRONICO_3 = CORREO_ELECTRONICO_3
		,@CORREO_ELECTRONICO_4 = CORREO_ELECTRONICO_4
		,@NUMERO_CONTRATO = NUMERO_CONTRATO
		,@DIRECCION_SISTEMA = DIRECCION_SISTEMA
		,@ASUNTO = ASUNTO
		,@CONTENIDO = CONTENIDO
		,@NOMBRE_RESPONSABLE = NOMBRE_RESPONSABLE
		,@FECHA_VENCIMIENTO = FECHA_VENCIMIENTO
		,@EMISOR=EMISOR
	FROM #TEMP_LISTA
	WHERE ROW_ID = @MIN_ROW

	IF(@FECHA_ESCALAMIENTO_1 = @FECHA_ACTUAL)
	BEGIN
		INSERT INTO @TABLE_NOTIFICAR VALUES(@CODIGO_TRABAJADOR1, @CODIGO_CONTRATO, @NOMBRE_COMPLETO_1, @CORREO_ELECTRONICO_1, @NUMERO_CONTRATO, @DIRECCION_SISTEMA, @ASUNTO, @CONTENIDO, @NOMBRE_RESPONSABLE, @FECHA_VENCIMIENTO,@EMISOR)
	END
	IF(@FECHA_ESCALAMIENTO_2 = @FECHA_ACTUAL)
	BEGIN
		INSERT INTO @TABLE_NOTIFICAR VALUES(@CODIGO_TRABAJADOR2, @CODIGO_CONTRATO, @NOMBRE_COMPLETO_2, @CORREO_ELECTRONICO_2, @NUMERO_CONTRATO, @DIRECCION_SISTEMA, @ASUNTO, @CONTENIDO, @NOMBRE_RESPONSABLE, @FECHA_VENCIMIENTO,@EMISOR)
	END
	IF(@FECHA_ESCALAMIENTO_3 = @FECHA_ACTUAL)
	BEGIN
		INSERT INTO @TABLE_NOTIFICAR VALUES(@CODIGO_TRABAJADOR3, @CODIGO_CONTRATO, @NOMBRE_COMPLETO_3, @CORREO_ELECTRONICO_3, @NUMERO_CONTRATO, @DIRECCION_SISTEMA, @ASUNTO, @CONTENIDO, @NOMBRE_RESPONSABLE, @FECHA_VENCIMIENTO,@EMISOR)
	END
	IF(@FECHA_ESCALAMIENTO_4 = @FECHA_ACTUAL)
	BEGIN
		INSERT INTO @TABLE_NOTIFICAR VALUES(@CODIGO_TRABAJADOR4, @CODIGO_CONTRATO, @NOMBRE_COMPLETO_4, @CORREO_ELECTRONICO_4, @NUMERO_CONTRATO, @DIRECCION_SISTEMA, @ASUNTO, @CONTENIDO, @NOMBRE_RESPONSABLE, @FECHA_VENCIMIENTO,@EMISOR)
	END

	SET @MIN_ROW = @MIN_ROW + 1

END

SELECT 
 REPLACE(ASUNTO, '@usuario_responsable', ISNULL(NOMBRE_RESPONSABLE, '')) ASUNTO,
 CORREO_ELECTRONICO,
 REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(CONTENIDO, '@usuario_escalamiento', ISNULL(NOMBRE_COMPLETO, '')),'@numero_contrato', ISNULL(NUMERO_CONTRATO, '')), '@url_opcion_sistema', ISNULL(DIRECCION_SISTEMA, '')),'@usuario_responsable', ISNULL(NOMBRE_RESPONSABLE, '')),'@fecha_aprobacion',ISNULL(CONVERT(VARCHAR, FECHA_VENCIMIENTO , 103), '')) CONTENIDO
 ,EMISOR
FROM @TABLE_NOTIFICAR
WHERE CORREO_ELECTRONICO IS NOT NULL

END


GO
/****** Object:  StoredProcedure [CTR].[USP_LISTAR_CONSULTA_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_LISTAR_CONSULTA_SEL] --NULL, NULL, NULL, NULL, NULL,null, null, '9CD3A8CF-4009-482E-B062-AA48F8080E1D'
    (
       @CODIGO_REMITENTE UNIQUEIDENTIFIER
	  ,@CODIGO_DESTINATARIO UNIQUEIDENTIFIER
	  ,@CODIGO_TIPO_CONSULTA VARCHAR(10)
	  ,@CODIGO_UNIDAD_OPERATIVA UNIQUEIDENTIFIER
	  ,@CODIGO_AREA VARCHAR(10)
	  ,@CODIGO_CONSULTA UNIQUEIDENTIFIER
	  ,@ESTADO_CONSULTA VARCHAR(5)
    )
AS 
BEGIN

/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_CONSULTA_SEL
Propósito:   Obtener el listado de la consulta   
Descripción de Parámetros: 
		@CODIGO_REMITENTE:		  Parámetro de entrada de tipo uniqueidentifier, que representa codigo de remitente.
		@CODIGO_DESTINATARIO:	  Parámetro de entrada de tipo uniqueidentifier, que representa codigo de destinatario.
		@CODIGO_TIPO_CONSULTA:	  Parámetro de entrada de tipo varchar, que representa tipo de consulta.
		@CODIGO_UNIDAD_OPERATIVA: Parámetro de entrada de tipo uniqueidentifier, que representa la unidad operativa.
		@CODIGO_AREA:			  Parámetro de entrada de tipo varchar, que representa el área.
		@CODIGO_CONSULTA:		  Parámetro de entrada de tipo uniqueidentifier, que representa código de consulta.
		@CODIGO_USUARIO_SESSION	  Parámtro de entrada de tipo uniqueidentifier, que representa código de usuario de sesón
		 por: GMD
Fecha. Creación: 2016-07-07
Fecha. Actualización: 
**********************************************************************************************************************************/
 SELECT	
		 C.[CODIGO_CONSULTA] AS CodigoConsulta
        ,C.[CODIGO_REMITENTE] AS CodigoRemitente
        ,C.[CODIGO_DESTINATARIO] AS CodigoDestinatario
        ,C.[TIPO] AS Tipo
        ,C.[ASUNTO] AS Asunto
        ,C.[CONTENIDO] AS Contenido
        ,C.[ESTADO_CONSULTA] AS EstadoConsulta
        ,C.[FECHA_ENVIO] AS FechaEnvio
        ,C.[RESPUESTA] AS Respuesta
        ,C.[FECHA_RESPUESTA] AS FechaRespuesta
		,C.[CODIGO_UNIDAD_OPERATIVA] AS CodigoUnidadOperativa
		,C.[CODIGO_AREA] AS CodigoArea
		,C.[CODIGO_CONSULTA_RELACIONADO] AS CodigoConsultaRelacionado
		,C.[CODIGO_CONSULTA_ORIGINAL] AS CodigoConsultaOriginal
		,(SELECT TOP 1 CODIGO_REMITENTE FROM CTR.CONSULTA WHERE CODIGO_CONSULTA = C.[CODIGO_CONSULTA_ORIGINAL]) AS CodigoRemitenteOriginal
		,ISNULL((SELECT DATEDIFF(day, C.[FECHA_ENVIO], GETDATE()) WHERE C.FECHA_RESPUESTA IS NULL), 0) AS DiaSinRespuesta
		,C.[VISTO_REMITENTE_ORIGINAL] AS VistoRemitenteOriginal
    FROM    [CTR].[CONSULTA] C
    WHERE		( @CODIGO_REMITENTE IS NULL OR CODIGO_REMITENTE = @CODIGO_REMITENTE)
            AND ( @CODIGO_DESTINATARIO IS NULL OR CODIGO_DESTINATARIO = @CODIGO_DESTINATARIO)
            AND ( @CODIGO_TIPO_CONSULTA IS NULL OR TIPO = @CODIGO_TIPO_CONSULTA)
			AND ( @CODIGO_UNIDAD_OPERATIVA IS NULL OR CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA)
			AND ( @CODIGO_AREA IS NULL OR CODIGO_AREA = @CODIGO_AREA)
			AND ( @CODIGO_CONSULTA IS NULL OR CODIGO_CONSULTA = @CODIGO_CONSULTA)
			AND ( @ESTADO_CONSULTA IS NULL OR ESTADO_CONSULTA = @ESTADO_CONSULTA)
            AND	  ESTADO_REGISTRO = '1'
END

GO
/****** Object:  StoredProcedure [CTR].[USP_LISTAR_UO_POR_PARTICIPANTE_RESPONSABLE]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_LISTAR_UO_POR_PARTICIPANTE_RESPONSABLE]
@CODIGO_TRABAJADOR uniqueidentifier
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_LISTAR_UO_POR_PARTICIPANTE_RESPONSABLE
Propósito:  Lista unidad operativa por participante responsable 
Descripción de Parámetros: 
		@CODIGO_TRABAJADOR:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo trabajador.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
SELECT DISTINCT CodigoUnidadOperativa=FA.CODIGO_UNIDAD_OPERATIVA FROM CTR.FLUJO_APROBACION FA (NOLOCK) 
	WHERE  EXISTS  
	( SELECT DISTINCT CODIGO_FLUJO_APROBACION FROM CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK)
		WHERE FA.CODIGO_FLUJO_APROBACION=FAE.CODIGO_FLUJO_APROBACION 
			AND EXISTS 
				 ( SELECT DISTINCT CODIGO_FLUJO_APROBACION_ESTADIO 
						FROM CTR.FLUJO_APROBACION_PARTICIPANTE FAP (NOLOCK) WHERE 
							FAE.CODIGO_FLUJO_APROBACION_ESTADIO = FAP.CODIGO_FLUJO_APROBACION_ESTADIO
							AND FAP.CODIGO_TRABAJADOR=@CODIGO_TRABAJADOR
							AND ESTADO_REGISTRO='1' and CODIGO_TIPO_PARTICIPANTE='R' 
							AND CODIGO_UNIDAD_OPERATIVA IN (SELECT CODIGO_UNIDAD_OPERATIVA 
							                                FROM STRACON_POLITICAS.GRL.UNIDAD_OPERATIVA
														    WHERE (LEN(CONVERT(VARCHAR(10),CODIGO_IDENTIFICACION))=8 OR CODIGO_IDENTIFICACION = '1867')
															))
			)
    
END 

GO
/****** Object:  StoredProcedure [CTR].[USP_NOTIFICACION_ADENDAS_CONTRATOS_VENCIDOS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_NOTIFICACION_ADENDAS_CONTRATOS_VENCIDOS]
(
	@NAME_DATABASE					NVARCHAR(500)
)
as
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_NOTIFICACION_ADENDAS_CONTRATOS_VENCIDOS
Propósito: Notifica a usuarios sobre adendas agregadas a contratos vencidos
Descripción de Parámetros: 		
Creado por: GMD
Fecha. Creación: 2017-07-04
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
DECLARE @Query NVARCHAR(MAX)

SET @Query = N' DECLARE 
				@Asunto nvarchar(max), 
				@Contenido nvarchar(max),
				@Destinatarios nvarchar(max),
				@DestinatariosCopia nvarchar(max),
				@CuentaCorreo nvarchar(50),
				@RowMin smallint, 
				@RowMax smallint,
				@NewContenido nvarchar(max),
				@ADENDAS nvarchar(max) = '''',
				@CODIGO_PARAMETRO INT,
				@PROFILE nvarchar(50)

				DECLARE	@Tb_Destinatarios TABLE(
				  ROWID BIGINT,		
				  CORREO NVARCHAR(1000)
				)

	IF EXISTS (SELECT NUMERO_CONTRATO FROM TMP.ADENDAS_CONTRATO_VENCIDO where ESTADO_ENVIO = 0)
	BEGIN
		SELECT 
				@Destinatarios		= DESTINATARIO,
				@DestinatariosCopia = DESTINATARIO_COPIA,
			    @Asunto				= ASUNTO, 
			    @Contenido			= CONTENIDO 
		FROM '+ @NAME_DATABASE +'.GRL.PLANTILLA_NOTIFICACION 
		WHERE 
				CODIGO_TIPO_NOTIFICACION	=''17''
			AND ESTADO_REGISTRO				=''1''			

		SELECT 
				@CODIGO_PARAMETRO = CODIGO_PARAMETRO 
		FROM '+ @NAME_DATABASE +'.GRL.PARAMETRO 
		WHERE 
				CODIGO_SISTEMA		 = ''A4C353EF-A593-4E59-8366-CA1BEC446115'' 
			AND CODIGO_IDENTIFICADOR = ''00034'' 
			AND ESTADO_REGISTRO		 = ''1''

		SELECT 
				@PROFILE = VALOR 
		FROM '+ @NAME_DATABASE +'.GRL.PARAMETRO_VALOR 
		WHERE 
				CODIGO_PARAMETRO = @CODIGO_PARAMETRO 
			AND CODIGO_SECCION = (SELECT CODIGO_SECCION from '+ @NAME_DATABASE +'.GRL.PARAMETRO_SECCION WHERE CODIGO_PARAMETRO = @CODIGO_PARAMETRO 
			AND NOMBRE = ''Nombre Profile'')

		INSERT INTO @Tb_Destinatarios
		select  ROW_NUMBER() OVER(ORDER BY Item) AS RowID, Item from CTR.SplitString(@Destinatarios,'';'')
	
		SELECT @ADENDAS = @ADENDAS + ''Nro. Adenda: '' + CONVERT(varchar(2), A.NUMERO_ADENDA) + ''-''+ A.NUMERO_ADENDA_CONCATENADO + ''-'' + A.DESCRIPCION   + '','' + N''</br>'' 
		FROM TMP.ADENDAS_CONTRATO_VENCIDO A 
		WHERE 
				A.ESTADO_ENVIO = 0
			AND (SELECT ESTADO_REGISTRO FROM CTR.CONTRATO WHERE NUMERO_CONTRATO COLLATE SQL_Latin1_General_CP1_CI_AS = A.NUMERO_CONTRATO
			AND NUMERO_ADENDA_CONCATENADO COLLATE SQL_Latin1_General_CP1_CI_AS = A.NUMERO_ADENDA_CONCATENADO 
			AND CODIGO_TIPO_DOCUMENTO COLLATE SQL_Latin1_General_CP1_CI_AS = ''A'' 
			AND DESCRIPCION COLLATE SQL_Latin1_General_CP1_CI_AS = A.DESCRIPCION) = ''1''
		
		IF(@ADENDAS <> '''')
		BEGIN

			select  substring(@ADENDAS, 0, len(@ADENDAS) - 1) 

			SELECT @RowMin = min(RowID), @RowMax = MAX(RowID) FROM  @Tb_Destinatarios

				while @RowMin <=@RowMax
				begin	
						select @NewContenido= REPLACE(@Contenido,''@lista_adendas_contratos_vencidos'', @ADENDAS), 
								@CuentaCorreo = CORREO
								from @Tb_Destinatarios where ROWID = @RowMin

						EXEC [msdb].[dbo].[sp_send_dbmail] 
									@profile_name = @PROFILE, 
									@recipients = @CuentaCorreo , 
									@copy_recipients = @DestinatariosCopia,
									@body = @NewContenido,
									@body_format=''html'', 
									@subject = @Asunto, 
									@importance = ''High'';	
			
						select @NewContenido='''', @CuentaCorreo='''', @RowMin +=1
				end	

			UPDATE TMP.ADENDAS_CONTRATO_VENCIDO SET ESTADO_ENVIO = 1 where ESTADO_ENVIO = 0

		END

		select 1
	END
	ELSE
	BEGIN
		select 0
	END'
  BEGIN
	DECLARE @paramDef NVARCHAR(max) = N'
			@NAME_DATABASE					NVARCHAR(500)'

	EXEC sys.sp_executesql @Query,
			@paramDef,
			@NAME_DATABASE		
  END
END

--EXEC [CTR].[USP_NOTIFICACION_ADENDAS_CONTRATOS_VENCIDOS] 'STRACON_POLITICAS_SGC'

GO
/****** Object:  StoredProcedure [CTR].[USP_NOTIFICACION_BANDEJA_CONTRATOS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_NOTIFICACION_BANDEJA_CONTRATOS]
@ASUNTO				nvarchar(255),
@TEXTO_NOTIFICAR	nvarchar(4000),
@CUENTA_NOTIFICAR	nvarchar(255),
@CUENTAS_COPIAS		nvarchar(MAX),
@PROFILE_CORREO		nvarchar(100)
AS
BEGIN
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_NOTIFICACION_BANDEJA_CONTRATOS
Propósito:  Notifica a los usuarios involucrados de contratos. 
Descripción de Parámetros: 
		@ASUNTO:	Parámetro de entrada de tipo nvarchar, que representa asunto.
		@TEXTO_NOTIFICAR:	Parámetro de entrada de tipo nvarchar, que representa texto notificar.
		@CUENTA_NOTIFICAR:	Parámetro de entrada de tipo nvarchar, que representa cuenta notificar.
		@CUENTAS_COPIAS:	Parámetro de entrada de tipo nvarchar, que representa cuentas copias.
		@PROFILE_CORREO:	Parámetro de entrada de tipo nvarchar, que representa profile correo.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/

SELECT	  @CUENTAS_COPIAS		= isnull(@CUENTAS_COPIAS,''),
			@CUENTA_NOTIFICAR		= isnull(@CUENTA_NOTIFICAR,''),
			@TEXTO_NOTIFICAR		= isnull(@TEXTO_NOTIFICAR,'')
			
IF len(@CUENTA_NOTIFICAR)>0 and len(@TEXTO_NOTIFICAR)>0
BEGIN
	EXEC [msdb].[dbo].[sp_send_dbmail]  @profile_name	 = @PROFILE_CORREO, 
										@recipients		 = @CUENTA_NOTIFICAR ,
										@body			 = @TEXTO_NOTIFICAR,
										@copy_recipients = @CUENTAS_COPIAS,
										@body_format	 ='html', 
										@subject		 = @ASUNTO, 
										@importance		 = 'High';
END
	
SELECT 1

END

GO
/****** Object:  StoredProcedure [CTR].[USP_NUMERO_CONTRATO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [CTR].[USP_NUMERO_CONTRATO_SEL]
(
	@CODIGO_UNIDAD_OPERATIVA UNIQUEIDENTIFIER,
	@NUMERO_CONTRATO		 NVARCHAR(250),
	@PageNo					 INT = 1,
	@PageSize				 BIGINT = -1

)
--EXEC CTR.USP_NUMERO_CONTRATO_SEL NULL,'STGYM.1000.CHS.18.001'
AS
BEGIN
	SELECT
		CODIGO_UNIDAD_OPERATIVA	as CodigoUnidadOperativa,
		CODIGO_CONTRATO			AS CodigoContrato,
		NUMERO_CONTRATO			as NumeroContrato,
		NUMERO_ADENDA			as NumeroAdenda,
		ESTADO_REGISTRO			as EstadoRegistro
	FROM 
	[CTR].[CONTRATO]
	WHERE   CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA OR @CODIGO_UNIDAD_OPERATIVA IS NULL
		AND NUMERO_CONTRATO		    like '%'+ @NUMERO_CONTRATO	+'%' OR ISNULL(@NUMERO_CONTRATO,'') = ''
		AND  ESTADO_REGISTRO        = 1
	ORDER BY NUMERO_CONTRATO DESC
END

GO
/****** Object:  StoredProcedure [CTR].[USP_NUMERO_CONTRATO_VALIDA_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_NUMERO_CONTRATO_VALIDA_SEL]
(
	@NUMERO_CONTRATO			VARCHAR(50),
	@VALOR_NUMERO				INT OUTPUT
)
AS
--exec CTR.USP_NUMERO_CONTRATO_VALIDA_SEL 'STGYM.1727.CLS-ADM.18.002','0'
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_NUMERO_CONTRATO_VALIDA_SEL
Propósito:   Permite modificar un registro de un contrato  
Descripción de Parámetros: 
		@NUMERO_CONTRATO :	Parámetro de entrada de tipo varchar, que representa numero contrato.		
		@VALOR_NUMERO    :  Parámetro de entrada de tipo int, que representa si el valordel numero de contrato se repite		
Creado por: GMD
Fecha. Creación: 2018-04-09
Fecha. 				   
**********************************************************************************************************************************/
BEGIN

		IF EXISTS (SELECT TOP 1 NUMERO_CONTRATO FROM CTR.CONTRATO WHERE NUMERO_CONTRATO = @NUMERO_CONTRATO AND ESTADO_REGISTRO= '1')
			BEGIN
				SET @VALOR_NUMERO = 3
			END
		ELSE
			BEGIN
				SET @VALOR_NUMERO = 0
			END
END


GO
/****** Object:  StoredProcedure [CTR].[USP_OBSERVA_ESTADIO_CONTRATO_UPD]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_OBSERVA_ESTADIO_CONTRATO_UPD] 
	@CODIGO_CONTRATO_ESTADIO			uniqueidentifier,
	@CODIGO_CONTRATO_ESTADIO_OBSERVADO	uniqueidentifier,
	@CODIGO_CONTRATO					uniqueidentifier,
	@CODIGO_FLUJO_ESTADIO_RETORNO		uniqueidentifier,
	@CODIGO_RESPONSABLE					uniqueidentifier,
	@USER_CREATION						nvarchar(50),
	@TERMINAL_CREATION					nvarchar(50)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_OBSERVA_ESTADIO_CONTRATO_UPD
Propósito:  Observar el contrato, generando un nuevo estadio. 
Descripción de Parámetros: 
@CODIGO_CONTRATO_ESTADIO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio.
@CODIGO_CONTRATO_ESTADIO_OBSERVADO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio observado.
@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
@CODIGO_FLUJO_ESTADIO_RETORNO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo estadio retorno.
@CODIGO_RESPONSABLE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo responsable.
@USER_CREATION:	Parámetro de entrada de tipo nvarchar, que representa user creation.
@TERMINAL_CREATION:	Parámetro de entrada de tipo nvarchar, que representa terminal creation.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
DECLARE @OrdenEstadioRetorno				tinyint,
		@OrdenPrimerEstadioFlujoAprobacion	tinyint,
		@CodigoFlujoAprobacion				uniqueidentifier

	DECLARE @CODIGO_ESTADO_CONTRATO_ESTADIO VARCHAR(10) = (
			SELECT CODIGO_ESTADO_CONTRATO_ESTADIO 
			FROM CTR.CONTRATO_ESTADIO 
			WHERE CODIGO_CONTRATO_ESTADIO = @CODIGO_CONTRATO_ESTADIO_OBSERVADO
	)

	IF(@CODIGO_ESTADO_CONTRATO_ESTADIO = 'I')BEGIN
		/*Registramos el Nuevo Estadio*/
		INSERT INTO CTR.CONTRATO_ESTADIO (CODIGO_CONTRATO_ESTADIO,CODIGO_CONTRATO,CODIGO_FLUJO_APROBACION_ESTADIO,FECHA_INGRESO,
		CODIGO_RESPONSABLE,CODIGO_ESTADO_CONTRATO_ESTADIO,ESTADO_REGISTRO,
		USUARIO_CREACION,FECHA_CREACION, TERMINAL_CREACION)
		SELECT @CODIGO_CONTRATO_ESTADIO, @CODIGO_CONTRATO, @CODIGO_FLUJO_ESTADIO_RETORNO,CONVERT(datetime,CONVERT(date,GETDATE())), 
		@CODIGO_RESPONSABLE, 'I', '1', @USER_CREATION, GETDATE(), @TERMINAL_CREATION	

		/*Actualizamos el Codigo de Estadio Actual en el Contrato.*/
		UPDATE CTR.CONTRATO SET CODIGO_ESTADIO_ACTUAL=@CODIGO_FLUJO_ESTADIO_RETORNO ,
		USUARIO_MODIFICACION=@USER_CREATION, 
		FECHA_MODIFICACION=GETDATE(),
		TERMINAL_MODIFICACION=@TERMINAL_CREATION
		WHERE CODIGO_CONTRATO=@CODIGO_CONTRATO

		/*Inhablitamos al anterior.*/
		UPDATE CTR.CONTRATO_ESTADIO  SET CODIGO_ESTADO_CONTRATO_ESTADIO='O', --Observado,
		USUARIO_MODIFICACION=@USER_CREATION, 
		FECHA_MODIFICACION=GETDATE(),
		TERMINAL_MODIFICACION=@TERMINAL_CREATION
		WHERE CODIGO_CONTRATO_ESTADIO=@CODIGO_CONTRATO_ESTADIO_OBSERVADO

		/*Revisamos si se retorna al Primer Estadio.*/ 
		SELECT  @OrdenEstadioRetorno = ORDEN, @CodigoFlujoAprobacion=CODIGO_FLUJO_APROBACION 
		FROM CTR.FLUJO_APROBACION_ESTADIO FAE (nolock)
		WHERE CODIGO_FLUJO_APROBACION_ESTADIO =@CODIGO_FLUJO_ESTADIO_RETORNO  AND ESTADO_REGISTRO='1' 
                
		SELECT @OrdenPrimerEstadioFlujoAprobacion = MIN(ORDEN) 
		FROM CTR.FLUJO_APROBACION_ESTADIO (NOLOCK)
		WHERE CODIGO_FLUJO_APROBACION =@CodigoFlujoAprobacion AND ESTADO_REGISTRO='1' 

                
		IF ( @OrdenEstadioRetorno=@OrdenPrimerEstadioFlujoAprobacion)BEGIN 
			UPDATE CTR.CONTRATO  SET CODIGO_ESTADO_EDICION='EP',
			CODIGO_ESTADO='E',
			USUARIO_MODIFICACION=@USER_CREATION,
			INDICADOR_VERSION_OFICIAL = 0,
			FECHA_MODIFICACION=GETDATE(),
			TERMINAL_MODIFICACION=@TERMINAL_CREATION,
			CODIGO_ESTADIO_ACTUAL=@CODIGO_FLUJO_ESTADIO_RETORNO
			WHERE CODIGO_CONTRATO = @CODIGO_CONTRATO             
		END
		SELECT 1 
	END	ELSE	BEGIN
		SELECT 2
	END
END

GO
/****** Object:  StoredProcedure [CTR].[USP_OBTENER_LISTA_TRABAJADORES_ENVIO_ALERTA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC  [CTR].[USP_OBTENER_LISTA_TRABAJADORES_ENVIO_ALERTA]
/****************************************************************************
Nombre SP: [CON].[USP_EFICIENCIA_REP]
Propósito: Obtiene los datos para el reporte de eficiencia
Input:
Output: 
	Listado de datos para enciar notificacion
Test:
	EXEC [CTR].[USP_OBTENER_LISTA_TRABAJADORES_ENVIO_ALERTA]
Creado por: GMD
Fecha. Creación: 27-07-16
Fecha. Actualización:	
****************************************************************************/
AS
BEGIN
SELECT C.[CODIGO_CONTRATO]
      ,C.[CODIGO_UNIDAD_OPERATIVA]
      ,C.[CODIGO_PROVEEDOR]
      ,C.[NUMERO_CONTRATO]
      ,C.[DESCRIPCION]
      ,C.[NUMERO_ADENDA]
      ,C.[CODIGO_TIPO_SERVICIO]
      ,C.[CODIGO_TIPO_REQUERIMIENTO]
      ,C.[CODIGO_TIPO_DOCUMENTO]
      ,C.[INDICADOR_VERSION_OFICIAL]
      ,C.[FECHA_INICIO_VIGENCIA]
      ,C.[FECHA_FIN_VIGENCIA]
      ,C.[CODIGO_MONEDA]
      ,C.[MONTO_CONTRATO]
      ,C.[MONTO_ACUMULADO]
      ,C.[CODIGO_ESTADO]
      ,C.[CODIGO_PLANTILLA]
      ,C.[CODIGO_CONTRATO_PRINCIPAL]
      ,C.[CODIGO_ESTADO_EDICION]
      ,C.[COMENTARIO_MODIFICACION]
      ,C.[RESPUESTA_MODIFICACION]
      ,C.[CODIGO_FLUJO_APROBACION]
      ,C.[CODIGO_ESTADIO_ACTUAL]
      ,C.[ESTADO_REGISTRO]
      ,C.[USUARIO_CREACION]
      ,C.[FECHA_CREACION]
      ,C.[TERMINAL_CREACION]
      ,C.[USUARIO_MODIFICACION]
      ,C.[FECHA_MODIFICACION]
      ,C.[TERMINAL_MODIFICACION]
      ,C.[NUMERO_ADENDA_CONCATENADO]
	  ,CE.CODIGO_RESPONSABLE
	  ,FAE.TIEMPO_ATENCION
	  ,FAE.HORAS_ATENCION
	  ,CE.FECHA_INGRESO
	  ,DATEADD(HOUR,((TIEMPO_ATENCION * 24) + HORAS_ATENCION),FECHA_INGRESO) AS RESULTADO_FECHA
	  ,CE.NOTIFICAR_USUARIO
	  ,CE.CODIGO_CONTRATO_ESTADIO
  FROM [CTR].[CONTRATO] C
  INNER JOIN [CTR].[CONTRATO_ESTADIO] CE ON C.CODIGO_CONTRATO = CE.CODIGO_CONTRATO
  INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FAE ON FAE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL
  WHERE (CE.NOTIFICAR_USUARIO IS NULL OR CE.NOTIFICAR_USUARIO = 0) AND C.CODIGO_ESTADO = 'A' AND CE.CODIGO_ESTADO_CONTRATO_ESTADIO = 'I' AND C.ESTADO_REGISTRO = '1' AND CE.ESTADO_REGISTRO = '1' AND FAE.ESTADO_REGISTRO = '1'
  AND DATEADD(HOUR,((TIEMPO_ATENCION * 24) + HORAS_ATENCION),FECHA_INGRESO) < GETDATE()
  
  END



GO
/****** Object:  StoredProcedure [CTR].[USP_OBTENER_LISTA_TRABAJADORES_ENVIO_ALERTA_ESCALAMIENTO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [CTR].[USP_OBTENER_LISTA_TRABAJADORES_ENVIO_ALERTA_ESCALAMIENTO]
/****** Object:  StoredProcedure [CTR].[USP_OBTENER_LISTA_TRABAJADORES_ENVIO_ALERTA_ESCALAMIENTO]    Script Date: 09/08/2016 03:39:22 p.m. ******/ 
/****************************************************************************
Nombre SP: [CTR].[USP_OBTENER_LISTA_TRABAJADORES_ENVIO_ALERTA_ESCALAMIENTO]
Propósito: Obtiene los datos para el reporte de eficiencia
Input:
Output: 
	Listado de datos para enciar notificacion
Test:
	EXEC [CTR].[USP_OBTENER_LISTA_TRABAJADORES_ENVIO_ALERTA_ESCALAMIENTO]
Creado por: GMD
Fecha. Creación: 27-07-16
Fecha. Actualización:	
****************************************************************************/
AS
BEGIN
SELECT C.[CODIGO_CONTRATO]
      ,C.[CODIGO_UNIDAD_OPERATIVA]
      ,C.[NUMERO_CONTRATO]
      ,C.[DESCRIPCION]
	  ,CE.[CODIGO_RESPONSABLE]
	  ,FAE.[TIEMPO_ATENCION]
	  ,FAE.[HORAS_ATENCION]
	  ,CE.[FECHA_INGRESO]
	  ,DATEADD(HOUR,((TIEMPO_ATENCION * 24) + HORAS_ATENCION),FECHA_INGRESO) AS FECHA_VENCIMIENTO
	  ,CE.[NOTIFICAR_USUARIO]
	  ,CE.[NTF_NIVEL_ESCALAMIENTO_1]
	  ,CE.[NTF_NIVEL_ESCALAMIENTO_2]
	  ,CE.[NTF_NIVEL_ESCALAMIENTO_3]
	  ,CE.[NTF_NIVEL_ESCALAMIENTO_4]
	  ,CE.[CODIGO_CONTRATO_ESTADIO]
  FROM [CTR].[CONTRATO] C
  INNER JOIN [CTR].[CONTRATO_ESTADIO] CE ON C.CODIGO_CONTRATO = CE.CODIGO_CONTRATO
  INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FAE ON FAE.CODIGO_FLUJO_APROBACION_ESTADIO = C.CODIGO_ESTADIO_ACTUAL
  WHERE C.CODIGO_ESTADO = 'A' AND CE.CODIGO_ESTADO_CONTRATO_ESTADIO = 'I' AND C.ESTADO_REGISTRO = '1' AND CE.ESTADO_REGISTRO = '1' AND FAE.ESTADO_REGISTRO = '1'
  AND DATEADD(HOUR,((TIEMPO_ATENCION * 24) + HORAS_ATENCION),FECHA_INGRESO) < GETDATE()
  END

  




GO
/****** Object:  StoredProcedure [CTR].[USP_OBTENER_TIPO_CONTRATO_SEGUN_UNIDAD_OPERATIVA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_OBTENER_TIPO_CONTRATO_SEGUN_UNIDAD_OPERATIVA]
@CODIGO_UNIDAD_OPERATIVA UNIQUEIDENTIFIER
AS
BEGIN
SELECT DISTINCT B.CODIGO_TIPO_CONTRATO FROM CTR.FLUJO_APROBACION A JOIN CTR.FLUJO_APROBACION_TIPO_CONTRATO B
ON A.CODIGO_FLUJO_APROBACION = B.CODIGO_FLUJO_APROBACION
WHERE A.ESTADO_REGISTRO = 1 AND B.ESTADO_REGISTRO = 1
AND A.CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA
ORDER BY 1
END
GO
/****** Object:  StoredProcedure [CTR].[USP_PLANTILLA_NOTA_PIE_POR_CONTRATO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Stored Procedure

CREATE PROCEDURE [CTR].[USP_PLANTILLA_NOTA_PIE_POR_CONTRATO_SEL]
@CODIGO_CONTRATO uniqueidentifier
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_PLANTILLA_NOTA_PIE_POR_CONTRATO_SEL
Propósito:  Retorna las notas al pie para un contrato. 
Descripción de Parámetros: 
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
Creado por: GMD
Fecha. Creación: 2017-08-18
Fecha. Actualización: 
**********************************************************************************************************************************/

BEGIN

	SELECT 
		P.CODIGO_PLANTILLA_NOTA_PIE CodigoPlantillaNotaPie, 
		P.CODIGO_PLANTILLA CodigoPlantilla, 
		P.ORDEN Orden, 
		P.TITULO Titulo, 
		P.CONTENIDO Contenido
	FROM CTR.PLANTILLA_NOTA_PIE P
		INNER JOIN CTR.CONTRATO C ON C.CODIGO_PLANTILLA = P.CODIGO_PLANTILLA
	WHERE C.CODIGO_CONTRATO = @CODIGO_CONTRATO AND P.ESTADO_REGISTRO = '1'
	ORDER BY ORDEN  

END

GO
/****** Object:  StoredProcedure [CTR].[USP_PLANTILLA_NOTA_PIE_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_PLANTILLA_NOTA_PIE_SEL]
(	
	@CODIGO_PLANTILLA_NOTA_PIE	UNIQUEIDENTIFIER,
	@CODIGO_PLANTILLA			UNIQUEIDENTIFIER,
	@PageNo		INT = 1,
	@PageSize	INT = -1
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_PLANTILLA_NOTA_PIE_SEL
Propósito:   Obtiene el listado de notas al pie por plantilla
Descripción de Parámetros: 	
		@CODIGO_PLANTILLA_NOTA_PIE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla nota al pie.
		@CODIGO_PLANTILLA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla.	
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
Creado por: GMD
Fecha. Creación: 2017-08-21
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
DECLARE @lPageNbr	INT,
		@lPageSize	INT,
		@lFirstRec	INT,
		@lLAStRec	INT

SET @lPageNbr = @PageNo
SET @lPageSize = @PageSize

SET @lFirstRec = (@lPageNbr - 1) * @lPageSize
SET @lLAStRec = (@lPageNbr * @lPageSize + 1);

WITH	CTE_Results AS (SELECT ROW_NUMBER() OVER (ORDER BY ORDEN ASC) AS RowNumber,
        COUNT(*) OVER() AS RowsTotal,
        CONVERT(VARCHAR, COUNT(*) OVER())	AS RowId,
		CODIGO_PLANTILLA_NOTA_PIE			AS CodigoPlantillaNotaPie,
        CODIGO_PLANTILLA					AS CodigoPlantilla,
        ORDEN								AS Orden,
        TITULO								AS Titulo,
		CONTENIDO							AS Contenido,
        ESTADO_REGISTRO						AS EstadoRegistro
FROM	CTR.PLANTILLA_NOTA_PIE
WHERE	
		(CODIGO_PLANTILLA_NOTA_PIE	=		@CODIGO_PLANTILLA_NOTA_PIE	OR @CODIGO_PLANTILLA_NOTA_PIE IS NULL)
		AND (CODIGO_PLANTILLA		=		@CODIGO_PLANTILLA			OR @CODIGO_PLANTILLA IS NULL)
		AND	(ESTADO_REGISTRO = '1')
)

SELECT	RowNumber,
		RowsTotal,
		RowId,
		CodigoPlantillaNotaPie,
        CodigoPlantilla,
        Orden,
        Titulo,
		Contenido,
		EstadoRegistro
FROM    CTE_Results
WHERE   @PageSize < 0 OR ( RowNumber > @lFirstRec AND RowNumber < @lLAStRec)
END


GO
/****** Object:  StoredProcedure [CTR].[USP_PLANTILLA_PARRAFO_ORDEN_TITULO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_PLANTILLA_PARRAFO_ORDEN_TITULO_SEL]
(
	@CODIGO_PLANTILLA	UNIQUEIDENTIFIER,
	@ORDEN				TINYINT,
	@TITULO				NVARCHAR(255),
	@ESTADO_REGISTRO	CHAR(1)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_PLANTILLA_PARRAFO_ORDEN_TITULO_SEL
Propósito:   Obtiene el listado de la planilla de párrafo  
Descripción de Parámetros: 
		@CODIGO_PLANTILLA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla.
		@ORDEN:	Parámetro de entrada de tipo tinyint, que representa orden.
		@TITULO:	Parámetro de entrada de tipo nvarchar, que representa titulo.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
SELECT	CODIGO_PLANTILLA_PARRAFO	CodigoPlantillaParrafo,
		CODIGO_PLANTILLA			CodigoPlantilla,
        ORDEN						Orden,
		TITULO						Titulo
FROM	CTR.PLANTILLA_PARRAFO
WHERE	(CODIGO_PLANTILLA	= @CODIGO_PLANTILLA)
AND		(ORDEN				= @ORDEN	OR	TITULO = @TITULO)
AND		(ESTADO_REGISTRO	= @ESTADO_REGISTRO)

GO
/****** Object:  StoredProcedure [CTR].[USP_PLANTILLA_PARRAFO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_PLANTILLA_PARRAFO_SEL]
(
	@CODIGO_PLANTILLA_PARRAFO	UNIQUEIDENTIFIER,
	@CODIGO_PLANTILLA			UNIQUEIDENTIFIER,
	@ORDEN						TINYINT,
	@TITULO						NVARCHAR(255),
	@CONTENIDO					VARCHAR(MAX),
	@PageNo		INT = 1,
	@PageSize	INT = -1
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_PLANTILLA_PARRAFO_SEL
Propósito:   Obtiene el listado de la plantilla de párrafo  
Descripción de Parámetros: 
		@CODIGO_PLANTILLA_PARRAFO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla parrafo.
		@CODIGO_PLANTILLA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla.
		@ORDEN:	Parámetro de entrada de tipo tinyint, que representa orden.
		@TITULO:	Parámetro de entrada de tipo nvarchar, que representa titulo.
		@CONTENIDO:	Parámetro de entrada de tipo varchar, que representa contenido.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
DECLARE @lPageNbr	INT,
		@lPageSize	INT,
		@lFirstRec	INT,
		@lLAStRec	INT

SET @lPageNbr = @PageNo
SET @lPageSize = @PageSize

SET @lFirstRec = (@lPageNbr - 1) * @lPageSize
SET @lLAStRec = (@lPageNbr * @lPageSize + 1);

WITH	CTE_Results AS (SELECT ROW_NUMBER() OVER (ORDER BY ORDEN ASC) AS RowNumber,
        COUNT(*) OVER() AS RowsTotal,
        CONVERT(VARCHAR, COUNT(*) OVER())	AS RowId,
		CODIGO_PLANTILLA_PARRAFO			AS CodigoPlantillaParrafo,
        CODIGO_PLANTILLA					AS CodigoPlantilla,
        ORDEN								AS Orden,
        TITULO								AS Titulo,
		CONTENIDO							AS Contenido,
        ESTADO_REGISTRO						AS EstadoRegistro
FROM	CTR.PLANTILLA_PARRAFO
WHERE	(CODIGO_PLANTILLA_PARRAFO	=		@CODIGO_PLANTILLA_PARRAFO	OR @CODIGO_PLANTILLA_PARRAFO IS NULL)
AND		(CODIGO_PLANTILLA			=		@CODIGO_PLANTILLA			OR @CODIGO_PLANTILLA IS NULL)
AND		(ORDEN						=		@ORDEN						OR @ORDEN IS NULL)
AND		(TITULO						LIKE	'%' + @TITULO + '%'			OR ISNULL(@TITULO,'') = '')							  	
AND		(CONTENIDO					=		@CONTENIDO					OR ISNULL(@CONTENIDO,'') = '')
AND		(ESTADO_REGISTRO = '1')
)

SELECT	RowNumber,
		RowsTotal,
		RowId,
		CodigoPlantillaParrafo,
        CodigoPlantilla,
        Orden,
        Titulo,
		Contenido,
		EstadoRegistro
FROM    CTE_Results
WHERE   @PageSize < 0 OR ( RowNumber > @lFirstRec AND RowNumber < @lLAStRec)
END

GO
/****** Object:  StoredProcedure [CTR].[USP_PLANTILLA_PARRAFO_VARIABLE_CODIGO_PLANTILLA_PARRAFO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_PLANTILLA_PARRAFO_VARIABLE_CODIGO_PLANTILLA_PARRAFO_SEL]
(
	@CODIGO_PLANTILLA_PARRAFO	UNIQUEIDENTIFIER,
	@ESTADO_REGISTRO			CHAR(1)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_PLANTILLA_PARRAFO_VARIABLE_CODIGO_PLANTILLA_PARRAFO_SEL
Propósito:   Obtiene el listado de la plantilla de párrafo de variable de código de plantilla párrafo  
Descripción de Parámetros: 
		@CODIGO_PLANTILLA_PARRAFO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla parrafo.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
SELECT	PPV.CODIGO_PLANTILLA_PARRAFO_VARIABLE	CodigoPlantillaParrafoVariable,
		PPV.CODIGO_PLANTILLA_PARRAFO			CodigoPlantillaParrafo,
		PPV.CODIGO_VARIABLE						CodigoVariable,
        PPV.ORDEN								Orden,
		V.CODIGO_TIPO							CodigoTipoVariable,
		V.NOMBRE								NombreVariable,
		V.DESCRIPCION							DescripcionVariable,
		V.IDENTIFICADOR							IdentificadorVariable,
		PPV.ESTADO_REGISTRO						EstadoRegistro
FROM	CTR.PLANTILLA_PARRAFO_VARIABLE PPV
INNER JOIN CTR.VARIABLE V ON V.CODIGO_VARIABLE = PPV.CODIGO_VARIABLE AND V.ESTADO_REGISTRO = @ESTADO_REGISTRO
WHERE	(PPV.CODIGO_PLANTILLA_PARRAFO	= @CODIGO_PLANTILLA_PARRAFO)
AND		(PPV.ESTADO_REGISTRO			= @ESTADO_REGISTRO)
ORDER BY PPV.ORDEN

GO
/****** Object:  StoredProcedure [CTR].[USP_PLANTILLA_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_PLANTILLA_SEL]
(
	@CODIGO_PLANTILLA				UNIQUEIDENTIFIER,
	@DESCRIPCION					NVARCHAR(255),
	@CODIGO_TIPO_CONTRATO			NVARCHAR(5),
	@CODIGO_TIPO_DOCUMENTO			NVARCHAR(5),
	@CODIGO_ESTADO					NVARCHAR(5),
	@INDICADOR_ADHESION				BIT,
	@FECHA_INICIO_VIGENCIA			DATETIME,
	@FECHA_FIN_VIGENCIA				DATETIME,
	@PageNo		INT = 1,
	@PageSize	INT = -1
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_PLANTILLA_SEL
Propósito:   Obtiene el listado de la plantilla  
Descripción de Parámetros: 
		@CODIGO_PLANTILLA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
		@CODIGO_TIPO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo servicio.
		@CODIGO_TIPO_REQUERIMIENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo requerimiento.
		@CODIGO_TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.
		@CODIGO_ESTADO:	Parámetro de entrada de tipo nvarchar, que representa codigo estado.
		@INDICADOR_ADHESION: Parámetro de entrada de tipo bit, que representa el indicador de adhesión.
		@FECHA_INICIO_VIGENCIA:	Parámetro de entrada de tipo datetime, que representa fecha inicio vigencia.
		@FECHA_FIN_VIGENCIA:	Parámetro de entrada de tipo datetime, que representa fecha fin vigencia.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
DECLARE @lPageNbr	INT,
		@lPageSize	INT,
		@lFirstRec	INT,
		@lLAStRec	INT

IF (@DESCRIPCION IS NOT NULL)
BEGIN 
	SET @DESCRIPCION = '%' + @DESCRIPCION + '%'
END

SET @lPageNbr = @PageNo
SET @lPageSize = @PageSize

SET @lFirstRec = (@lPageNbr - 1) * @lPageSize
SET @lLAStRec = (@lPageNbr * @lPageSize + 1);


WITH	CTE_Results AS (SELECT ROW_NUMBER() OVER (ORDER BY DESCRIPCION ASC) AS RowNumber,
        COUNT(*) OVER() AS RowsTotal,
        CONVERT(VARCHAR, COUNT(*) OVER())		AS RowId,
        CODIGO_PLANTILLA						AS CodigoPlantilla,
        DESCRIPCION								AS Descripcion,
        CODIGO_TIPO_CONTRATO					AS CodigoTipoContrato,		
		CODIGO_TIPO_DOCUMENTO					AS CodigoTipoDocumentoContrato,
		CODIGO_ESTADO							AS CodigoEstadoVigencia,
		INDICADOR_ADHESION						AS IndicadorAdhesion,
		FECHA_INICIO_VIGENCIA					AS FechaInicioVigenciaDate,
		FECHA_FIN_VIGENCIA						AS FechaFinVigenciaDate,
        ESTADO_REGISTRO							AS EstadoRegistro,
		ES_MAYORMENOR							AS EsMayorMenor
FROM	CTR.PLANTILLA
WHERE	(@CODIGO_PLANTILLA IS NULL				OR CODIGO_PLANTILLA				=		@CODIGO_PLANTILLA)
AND		(@DESCRIPCION IS NULL					OR DESCRIPCION					LIKE	@DESCRIPCION)
AND		(@CODIGO_TIPO_CONTRATO IS NULL			OR CODIGO_TIPO_CONTRATO			=		@CODIGO_TIPO_CONTRATO)
AND		(@CODIGO_TIPO_DOCUMENTO IS NULL			OR CODIGO_TIPO_DOCUMENTO		=		@CODIGO_TIPO_DOCUMENTO)
AND		(@INDICADOR_ADHESION IS NULL			OR INDICADOR_ADHESION			=		@INDICADOR_ADHESION)
AND		(@CODIGO_ESTADO	IS NULL					OR CODIGO_ESTADO				=		@CODIGO_ESTADO)
AND		(@FECHA_INICIO_VIGENCIA IS NULL			OR FECHA_INICIO_VIGENCIA		>=		@FECHA_INICIO_VIGENCIA)
AND		(@FECHA_FIN_VIGENCIA IS NULL			OR FECHA_FIN_VIGENCIA			=		@FECHA_FIN_VIGENCIA)
AND		(ESTADO_REGISTRO = '1')
)

SELECT	RowNumber,
		RowsTotal,
		RowId,
        CodigoPlantilla,
        Descripcion,
        CodigoTipoContrato,
		CodigoTipoDocumentoContrato,
		CodigoEstadoVigencia,
		IndicadorAdhesion,
		FechaInicioVigenciaDate,
		FechaFinVigenciaDate,
        EstadoRegistro,
		EsMayorMenor
FROM    CTE_Results
WHERE   @PageSize < 0 OR ( RowNumber > @lFirstRec AND RowNumber < @lLAStRec)        
END

GO
/****** Object:  StoredProcedure [CTR].[USP_PLANTILLA_TIPO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_PLANTILLA_TIPO_SEL]
(
	@CODIGO_TIPO_CONTRATO			NVARCHAR(5),
	@CODIGO_TIPO_DOCUMENTO			NVARCHAR(5),
	@INDICADOR_ADHESION				BIT
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_PLANTILLA_TIPO_SEL
Propósito:   Obtiene el listado de la plantilla tipo  
Descripción de Parámetros: 
		@CODIGO_TIPO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo contrato.
		@CODIGO_TIPO_REQUERIMIENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo requerimiento.
		@CODIGO_TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.
		@INDICADOR_ADHESION:	Parámetro de entrada de tipo bit, que representa indicador de Adhesión.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
SELECT	CODIGO_PLANTILLA			AS CodigoPlantilla,
        @CODIGO_TIPO_CONTRATO		AS CodigoTipoContrato,
		CODIGO_TIPO_DOCUMENTO		AS CodigoTipoDocumentoContrato,
		CODIGO_ESTADO				AS CodigoEstadoVigencia,
		INDICADOR_ADHESION			AS IndicadorAdhesion,
		FECHA_INICIO_VIGENCIA		AS FechaInicioVigenciaDate
FROM	CTR.PLANTILLA
WHERE	(CODIGO_TIPO_CONTRATO		= @CODIGO_TIPO_CONTRATO)	
AND		(CODIGO_TIPO_DOCUMENTO		= @CODIGO_TIPO_DOCUMENTO)
AND		(INDICADOR_ADHESION			= @INDICADOR_ADHESION)
AND		(ESTADO_REGISTRO = '1')

GO
/****** Object:  StoredProcedure [CTR].[USP_PLANTILLA_VIGENCIA_UPD]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_PLANTILLA_VIGENCIA_UPD] (
	@USUARIO_MODIFICACION	NVARCHAR(50) = NULL,
	@TERMINAL_MODIFICACION	NVARCHAR(50) = NULL
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_PLANTILLA_VIGENCIA_UPD
Propósito:  Actualiza Plantilla Vigencia 
Descripción de Parámetros: 
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	--Obtenemos la fecha límite de vigencia de todos los tipos de plantilla
	SELECT P.CODIGO_TIPO_CONTRATO,
		   P.CODIGO_TIPO_DOCUMENTO,
		   P.INDICADOR_ADHESION,
		   MAX(P.FECHA_INICIO_VIGENCIA) AS FECHA_INICIO_VIGENCIA
	  INTO #TMP_PLANTILLAS
	  FROM CTR.PLANTILLA P
	 WHERE P.ESTADO_REGISTRO = '1'
	   AND CONVERT(DATE,P.FECHA_INICIO_VIGENCIA) <= CONVERT(DATE, GETDATE())
	 GROUP BY P.CODIGO_TIPO_CONTRATO,
			  P.CODIGO_TIPO_DOCUMENTO,
			  P.INDICADOR_ADHESION
	
	--Actualizamos los próximos
	UPDATE CTR.PLANTILLA
	   SET CODIGO_ESTADO		= 'P',
		   FECHA_FIN_VIGENCIA	= NULL,
		   USUARIO_MODIFICACION	= @USUARIO_MODIFICACION,
		   FECHA_MODIFICACION	= GETDATE(),
		   TERMINAL_MODIFICACION= @TERMINAL_MODIFICACION
	 WHERE ESTADO_REGISTRO = '1'
	   AND CODIGO_ESTADO  <> 'P'
	   AND CONVERT(DATE,FECHA_INICIO_VIGENCIA) > CONVERT(DATE, GETDATE())

	--Actualizamos los vigentes
	UPDATE CTR.PLANTILLA
	   SET CODIGO_ESTADO		= 'V',
		   FECHA_FIN_VIGENCIA	= NULL,
		   USUARIO_MODIFICACION	= @USUARIO_MODIFICACION,
		   FECHA_MODIFICACION	= GETDATE(),
		   TERMINAL_MODIFICACION= @TERMINAL_MODIFICACION
	 WHERE ESTADO_REGISTRO = '1'
	   AND CODIGO_ESTADO  <> 'V'
	   AND EXISTS (SELECT 1
					 FROM #TMP_PLANTILLAS T
					WHERE T.CODIGO_TIPO_CONTRATO		= CTR.PLANTILLA.CODIGO_TIPO_CONTRATO
					  AND T.CODIGO_TIPO_DOCUMENTO		= CTR.PLANTILLA.CODIGO_TIPO_DOCUMENTO
					  AND T.INDICADOR_ADHESION			= CTR.PLANTILLA.INDICADOR_ADHESION
					  AND T.FECHA_INICIO_VIGENCIA		= CTR.PLANTILLA.FECHA_INICIO_VIGENCIA )
	
	--Actualizamos los históricos
	UPDATE CTR.PLANTILLA
	   SET CODIGO_ESTADO		= 'H',
		   FECHA_FIN_VIGENCIA	= (SELECT DATEADD(dd, -1, CONVERT(DATE, MIN(P.FECHA_INICIO_VIGENCIA)))
									 FROM CTR.PLANTILLA P
									WHERE P.CODIGO_TIPO_CONTRATO		= CTR.PLANTILLA.CODIGO_TIPO_CONTRATO
									  AND P.CODIGO_TIPO_DOCUMENTO		= CTR.PLANTILLA.CODIGO_TIPO_DOCUMENTO
									  AND P.INDICADOR_ADHESION			= CTR.PLANTILLA.INDICADOR_ADHESION
									  AND P.FECHA_INICIO_VIGENCIA		> CTR.PLANTILLA.FECHA_INICIO_VIGENCIA),
		   USUARIO_MODIFICACION	= @USUARIO_MODIFICACION,
		   FECHA_MODIFICACION	= GETDATE(),
		   TERMINAL_MODIFICACION= @TERMINAL_MODIFICACION
	 WHERE ESTADO_REGISTRO = '1'
	   AND CODIGO_ESTADO  <> 'H'
	   AND EXISTS (SELECT 1
					 FROM #TMP_PLANTILLAS T
					WHERE T.CODIGO_TIPO_CONTRATO		= CTR.PLANTILLA.CODIGO_TIPO_CONTRATO
					  AND T.CODIGO_TIPO_DOCUMENTO		= CTR.PLANTILLA.CODIGO_TIPO_DOCUMENTO
					  AND T.INDICADOR_ADHESION			= CTR.PLANTILLA.INDICADOR_ADHESION
					  AND T.FECHA_INICIO_VIGENCIA		> CTR.PLANTILLA.FECHA_INICIO_VIGENCIA )
END


GO
/****** Object:  StoredProcedure [CTR].[USP_PROCESA_CONTRATOS_RETRASO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_PROCESA_CONTRATOS_RETRASO_SEL]
/*
EXEC CTR.USP_PROCESA_CONTRATOS_RETRASO_SEL
*/
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_PROCESA_CONTRATOS_RETRASO_SEL
Propósito:  Obtener registros de tabla 
Descripción de Parámetros: 
         <<None>>
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

TRUNCATE TABLE TMP.CONTRATOS_RETRASADOS
TRUNCATE TABLE TMP.CONTRATOS_INFORMADOS

SELECT CE.CODIGO_CONTRATO_ESTADIO,
		    CE.CODIGO_FLUJO_APROBACION_ESTADIO,
			CT.NUMERO_CONTRATO,
			CT.CODIGO_UNIDAD_OPERATIVA,
			NOMBRE_PROVEEDOR=(SELECT PR.NOMBRE  FROM CTR.PROVEEDOR PR (NOLOCK) WHERE PR.CODIGO_PROVEEDOR=CT.CODIGO_PROVEEDOR ), 
			FECHA_INGRESO, 
			FECHA_LIMITE = DATEADD(DD, FAE.TIEMPO_ATENCION, FECHA_INGRESO),
			FECHA_ACTUAL = GETDATE(),
			RESPONSABLE= CTR.FN_RETORNA_RESPONSABLES_ESTADIO(CE.CODIGO_FLUJO_APROBACION_ESTADIO)			 
			INTO #TEMP_CONTRATOS_PROCESAR
 FROM CTR.CONTRATO_ESTADIO CE (nolock)  INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK)
ON ( CE.CODIGO_FLUJO_APROBACION_ESTADIO = FAE.CODIGO_FLUJO_APROBACION_ESTADIO ) INNER JOIN CTR.CONTRATO CT (NOLOCK)
ON (CT.CODIGO_CONTRATO = CE.CODIGO_CONTRATO )
WHERE CE.CODIGO_ESTADO_CONTRATO_ESTADIO='I' AND CE.ESTADO_REGISTRO='1' AND FAE.ESTADO_REGISTRO='1'

--Agregamos las HORAS.
UPDATE CP SET CP.FECHA_LIMITE=DATEADD(HH,FAE.HORAS_ATENCION,CP.FECHA_LIMITE)
		FROM #TEMP_CONTRATOS_PROCESAR CP INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FAE (NOLOCK)
		ON ( CP.CODIGO_FLUJO_APROBACION_ESTADIO = FAE.CODIGO_FLUJO_APROBACION_ESTADIO )
		WHERE FAE.HORAS_ATENCION>0

--DEJAMOS SOLO A LOS QUE SE DEBEN NOTIFICAR
DELETE FROM #TEMP_CONTRATOS_PROCESAR WHERE FECHA_LIMITE>FECHA_ACTUAL

--Registramos en una Temporal a los Informados, ya que por cada FLUJO_CONTRATO_ESTADIO puede haber mas de uno-------
INSERT INTO TMP.CONTRATOS_INFORMADOS(CODIGO_FLUJO_APROBACION_ESTADIO, CODIGO_INFORMADO)
select FAP.CODIGO_FLUJO_APROBACION_ESTADIO, FAP.CODIGO_TRABAJADOR from CTR.FLUJO_APROBACION_PARTICIPANTE FAP (NOLOCK) INNER JOIN #TEMP_CONTRATOS_PROCESAR CP
			ON ( FAP.CODIGO_FLUJO_APROBACION_ESTADIO=CP.CODIGO_FLUJO_APROBACION_ESTADIO )
			WHERE FAP.CODIGO_TIPO_PARTICIPANTE='I'  AND FAP.ESTADO_REGISTRO='1'
			ORDER BY CODIGO_FLUJO_APROBACION_ESTADIO

SELECT CODIGO_CONTRATO_ESTADIO,
			CODIGO_FLUJO_APROBACION_ESTADIO,
			CODIGO='01', NUMERO_CONTRATO,NOMBRE_PROVEEDOR,	
			RESPONSABLE=CONVERT(VARCHAR(50),RESPONSABLE)	,
			UNIDAD_OPERATIVA =CONVERT(VARCHAR(50),CODIGO_UNIDAD_OPERATIVA)
FROM #TEMP_CONTRATOS_PROCESAR

DROP TABLE #TEMP_CONTRATOS_PROCESAR

 END
 

GO
/****** Object:  StoredProcedure [CTR].[USP_PROVEEDOR_ACUMULADO_INS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_PROVEEDOR_ACUMULADO_INS]
(	
	@RUC_PROVEEDOR NVARCHAR(20),
	@CODIGO_TIPO_ORDEN NVARCHAR(5),
	@CODIGO_MONEDA NVARCHAR(255),
	@MONTO_ACUMULADO DECIMAL(18,6),	
	@ESTADO_REGISTRO NVARCHAR(1),
	@USUARIO_CREACION NVARCHAR(50),
	@FECHA_CREACION DATETIME,
	@TERMINAL_CREACION NVARCHAR(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_PROVEEDOR_ACUMULADO_INS
Propósito:   Registra un proveedor acumulado 
Descripción de Parámetros: 
		@RUC_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa ruc proveedor.
		@CODIGO_TIPO_ORDEN:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo orden.
		@CODIGO_MONEDA:	Parámetro de entrada de tipo nvarchar, que representa codigo moneda.
		@MONTO_ACUMULADO:	Parámetro de entrada de tipo decimal, que representa monto acumulado.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo nvarchar, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@FECHA_CREACION:	Parámetro de entrada de tipo datetime, que representa fecha creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

	declare @FechaInicio datetime, @FechaFin datetime,
				@CODIGO_PROVEEDOR UNIQUEIDENTIFIER

	SELECT @FechaInicio =CONVERT(DATETIME,CONVERT(VARCHAR(4),YEAR(GETDATE()))+'-01-01'), @FechaFin = GETDATE()
	SELECT TOP 1 @CODIGO_PROVEEDOR = CODIGO_PROVEEDOR FROM CTR.PROVEEDOR (NOLOCK)
	WHERE NUMERO_DOCUMENTO=@RUC_PROVEEDOR AND ESTADO_REGISTRO='1'

	INSERT INTO CTR.PROVEEDOR_ACUMULADO
	(
	   CODIGO_PROVEEDOR_ACUMULADO,
		CODIGO_PROVEEDOR,
		CODIGO_TIPO_ORDEN,
		CODIGO_MONEDA,
		MONTO_ACUMULADO, 
		FECHA_INICIO,
		FECHA_FIN,
		INDICADOR_LIMITE_ALCANZADO,
		INDICADOR_NOTIFICADO,
		ESTADO_REGISTRO,
		USUARIO_CREACION,
		FECHA_CREACION,
		TERMINAL_CREACION
	)
	VALUES
	(
		NEWID(),
		@CODIGO_PROVEEDOR,
		@CODIGO_TIPO_ORDEN,
		@CODIGO_MONEDA,
		@MONTO_ACUMULADO,
		@FechaInicio,
		@FechaFin,
		1,
		0,
		@ESTADO_REGISTRO,
		@USUARIO_CREACION,
		@FECHA_CREACION,
		@TERMINAL_CREACION
	)
END

GO
/****** Object:  StoredProcedure [CTR].[USP_PROVEEDOR_EXISTE_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_PROVEEDOR_EXISTE_SEL]
(
	@CODIGO_IDENTIFICACION NVARCHAR(50),
	@NOMBRE NVARCHAR(255),
	@NOMBRE_COMERCIAL NVARCHAR(255),
	@TIPO_DOCUMENTO NVARCHAR(5),
	@NUMERO_DOCUMENTO NVARCHAR(20),
	@ESTADO_REGISTRO CHAR(1),
	@USUARIO_CREACION NVARCHAR(50),
	@FECHA_CREACION DATETIME,
	@TERMINAL_CREACION NVARCHAR(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_PROVEEDOR_EXISTE_SEL
Propósito:   Obtiene el listado del proveedor existente  
Descripción de Parámetros: 
		@CODIGO_IDENTIFICACION:	Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@NOMBRE_COMERCIAL:	Parámetro de entrada de tipo nvarchar, que representa nombre comercial.
		@TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa tipo documento.
		@NUMERO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa numero documento.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@FECHA_CREACION:	Parámetro de entrada de tipo datetime, que representa fecha creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

	IF EXISTS(SELECT 1 FROM CTR.PROVEEDOR WHERE NUMERO_DOCUMENTO = @NUMERO_DOCUMENTO)
		BEGIN
			SELECT 1
		END
	ELSE
		BEGIN
			INSERT INTO CTR.PROVEEDOR(
										CODIGO_PROVEEDOR,
										CODIGO_IDENTIFICACION,
										NOMBRE,
										NOMBRE_COMERCIAL,
										TIPO_DOCUMENTO,
										NUMERO_DOCUMENTO,
										ESTADO_REGISTRO,
										USUARIO_CREACION,
										FECHA_CREACION,
										TERMINAL_CREACION
										)
			VALUES(
					NEWID(),
					@CODIGO_IDENTIFICACION,
					@NOMBRE,
					@NOMBRE_COMERCIAL,
					@TIPO_DOCUMENTO,
					@NUMERO_DOCUMENTO,
					@ESTADO_REGISTRO,
					@USUARIO_CREACION,
					@FECHA_CREACION,
					@TERMINAL_CREACION
					)
			SELECT 0
		END
END





GO
/****** Object:  StoredProcedure [CTR].[USP_PROVEEDOR_INS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_PROVEEDOR_INS]
(	
	@CODIGO_IDENTIFICACION NVARCHAR(50),
	@NOMBRE NVARCHAR(255),
	@NOMBRE_COMERCIAL NVARCHAR(255),
	@TIPO_DOCUMENTO NVARCHAR(5),
	@NUMERO_DOCUMENTO NVARCHAR(20),
	@ESTADO_REGISTRO NVARCHAR(1),
	@USUARIO_CREACION NVARCHAR(50),
	@FECHA_CREACION DATETIME,
	@TERMINAL_CREACION NVARCHAR(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_PROVEEDOR_INS
Propósito:   Registra un proveedor 
Descripción de Parámetros: 
		@CODIGO_IDENTIFICACION:	Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@NOMBRE_COMERCIAL:	Parámetro de entrada de tipo nvarchar, que representa nombre comercial.
		@TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa tipo documento.
		@NUMERO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa numero documento.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo nvarchar, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@FECHA_CREACION:	Parámetro de entrada de tipo datetime, que representa fecha creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	INSERT INTO CTR.PROVEEDOR
	(
		CODIGO_PROVEEDOR,
		CODIGO_IDENTIFICACION,
		NOMBRE,
		NOMBRE_COMERCIAL,
		TIPO_DOCUMENTO,
		NUMERO_DOCUMENTO,
		ESTADO_REGISTRO,
		USUARIO_CREACION,
		FECHA_CREACION,
		TERMINAL_CREACION
	)
	VALUES
	(
		NEWID(),
		@CODIGO_IDENTIFICACION,
		@NOMBRE,
		@NOMBRE_COMERCIAL,
		@TIPO_DOCUMENTO,
		@NUMERO_DOCUMENTO,
		@ESTADO_REGISTRO,
		@USUARIO_CREACION,
		@FECHA_CREACION,
		@TERMINAL_CREACION
	)
END

GO
/****** Object:  StoredProcedure [CTR].[USP_PROVEEDOR_NOMBRE_RUC_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_PROVEEDOR_NOMBRE_RUC_SEL]
( 
	@CODIGO_PROVEEDOR		UNIQUEIDENTIFIER = NULL,
	@CODIGO_IDENTIFICACION	NVARCHAR(50)	 = NULL,
	@NOMBRE					NVARCHAR(255)	 = NULL,
	@NOMBRE_COMERCIAL		NVARCHAR(255)	 = NULL,
	@TIPO_DOCUMENTO			NVARCHAR(20)	 = NULL,
	@NUMERO_DOCUMENTO		NVARCHAR(20)	 = NULL,
	@PageNo					INT				 = 1,
	@PageSize				INT				 = -1
)
AS

--EXEC [CTR].[USP_PROVEEDOR_NOMBRE_RUC_SEL] NULL,NULL,NULL,'CAMPAMENTOS Y CATERING S.A.C.',NULL,NULL,1,10000
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_PROVEEDOR_SEL
Propósito:   Obtiene el listado del proveedor  
Descripción de Parámetros: 
		@CODIGO_PROVEEDOR:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo proveedor.
		@CODIGO_IDENTIFICACION:	Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@NOMBRE_COMERCIAL:	Parámetro de entrada de tipo nvarchar, que representa nombre comercial.
		@TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa tipo documento.
		@NUMERO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa numero documento.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
DECLARE @lPageNbr	INT,
		@lPageSize	INT,
		@lFirstRec	INT,
		@lLAStRec	INT

SET @lPageNbr = @PageNo
SET @lPageSize = @PageSize

SET @lFirstRec = (@lPageNbr - 1) * @lPageSize
SET @lLAStRec = (@lPageNbr * @lPageSize + 1);

WITH	CTE_Results AS (SELECT ROW_NUMBER() OVER (ORDER BY NOMBRE ASC) AS RowNumber,
        COUNT(*) OVER() AS RowsTotal,
        CONVERT(VARCHAR, COUNT(*) OVER())			AS RowId,
        CODIGO_PROVEEDOR							AS CodigoProveedor,
        CODIGO_IDENTIFICACION						AS CodigoIdentificacion,
        NOMBRE										AS Nombre,
		NUMERO_DOCUMENTO + ' - ' +NOMBRE_COMERCIAL    AS NombreComercial,
		TIPO_DOCUMENTO								AS TipoDocumento,
		NUMERO_DOCUMENTO							AS NumeroDocumento,
		ESTADO_REGISTRO								AS EstadoRegistro

FROM	CTR.PROVEEDOR

WHERE	(CODIGO_PROVEEDOR		= @CODIGO_PROVEEDOR					 OR @CODIGO_PROVEEDOR IS NULL)
AND		(CODIGO_IDENTIFICACION	= @CODIGO_IDENTIFICACION			 OR ISNULL(@CODIGO_IDENTIFICACION,'') = '')
AND		(NOMBRE					= @NOMBRE							 OR ISNULL(@NOMBRE,'') = '')
AND		((NUMERO_DOCUMENTO + ' - ' +NOMBRE_COMERCIAL)		LIKE '%'+ @NOMBRE_COMERCIAL +'%'	 OR ISNULL(@NOMBRE_COMERCIAL,'') = '')
AND		(TIPO_DOCUMENTO			= @TIPO_DOCUMENTO					 OR ISNULL(@TIPO_DOCUMENTO,'') = '')
AND		(NUMERO_DOCUMENTO		LIKE '%'+ @NUMERO_DOCUMENTO	+'%'	 OR ISNULL(@NUMERO_DOCUMENTO,'') = '')
AND		(ESTADO_REGISTRO		= '1')
)

SELECT	RowNumber,
		RowsTotal,
		RowId,
		CodigoProveedor,
		CodigoIdentificacion,
		Nombre,
		NombreComercial,
		TipoDocumento,
		NumeroDocumento,
		EstadoRegistro

FROM    CTE_Results
WHERE   @PageSize < 0 OR ( RowNumber > @lFirstRec AND RowNumber < @lLAStRec)        
END

GO
/****** Object:  StoredProcedure [CTR].[USP_PROVEEDOR_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_PROVEEDOR_SEL]
( 
	@CODIGO_PROVEEDOR UNIQUEIDENTIFIER = NULL,
	@CODIGO_IDENTIFICACION NVARCHAR(50) = NULL,
	@NOMBRE NVARCHAR(255) = NULL,
	@NOMBRE_COMERCIAL NVARCHAR(255) = NULL,
	@TIPO_DOCUMENTO NVARCHAR(20) = NULL,
	@NUMERO_DOCUMENTO NVARCHAR(20) = NULL,
	@PageNo		INT = 1,
	@PageSize	INT = -1
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_PROVEEDOR_SEL
Propósito:   Obtiene el listado del proveedor  
Descripción de Parámetros: 
		@CODIGO_PROVEEDOR:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo proveedor.
		@CODIGO_IDENTIFICACION:	Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@NOMBRE_COMERCIAL:	Parámetro de entrada de tipo nvarchar, que representa nombre comercial.
		@TIPO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa tipo documento.
		@NUMERO_DOCUMENTO:	Parámetro de entrada de tipo nvarchar, que representa numero documento.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
DECLARE @lPageNbr	INT,
		@lPageSize	INT,
		@lFirstRec	INT,
		@lLAStRec	INT

SET @lPageNbr = @PageNo
SET @lPageSize = @PageSize

SET @lFirstRec = (@lPageNbr - 1) * @lPageSize
SET @lLAStRec = (@lPageNbr * @lPageSize + 1);

WITH	CTE_Results AS (SELECT ROW_NUMBER() OVER (ORDER BY NOMBRE ASC) AS RowNumber,
        COUNT(*) OVER() AS RowsTotal,
        CONVERT(VARCHAR, COUNT(*) OVER())		AS RowId,
        CODIGO_PROVEEDOR						AS CodigoProveedor,
        CODIGO_IDENTIFICACION					AS CodigoIdentificacion,
        NOMBRE									AS Nombre,
		NOMBRE_COMERCIAL						AS NombreComercial,
		TIPO_DOCUMENTO							AS TipoDocumento,
		NUMERO_DOCUMENTO						AS NumeroDocumento,
		ESTADO_REGISTRO							AS EstadoRegistro

FROM	CTR.PROVEEDOR

WHERE	(CODIGO_PROVEEDOR		= @CODIGO_PROVEEDOR  OR @CODIGO_PROVEEDOR IS NULL)
AND		(CODIGO_IDENTIFICACION	= @CODIGO_IDENTIFICACION OR ISNULL(@CODIGO_IDENTIFICACION,'') = '')
AND		(NOMBRE					= @NOMBRE OR ISNULL(@NOMBRE,'') = '')
AND		(NOMBRE_COMERCIAL		= @NOMBRE_COMERCIAL OR ISNULL(@NOMBRE_COMERCIAL,'') = '')
AND		(TIPO_DOCUMENTO			= @TIPO_DOCUMENTO OR ISNULL(@TIPO_DOCUMENTO,'') = '')
AND		(NUMERO_DOCUMENTO		= @NUMERO_DOCUMENTO OR ISNULL(@NUMERO_DOCUMENTO,'') = '')
AND		(ESTADO_REGISTRO		= '1')
)

SELECT	RowNumber,
		RowsTotal,
		RowId,
		CodigoProveedor,
		CodigoIdentificacion,
		Nombre,
		NombreComercial,
		TipoDocumento,
		NumeroDocumento,
		EstadoRegistro

FROM    CTE_Results
WHERE   @PageSize < 0 OR ( RowNumber > @lFirstRec AND RowNumber < @lLAStRec)        
END


	


GO
/****** Object:  StoredProcedure [CTR].[USP_REGISTRA_CONTRATODOC_CARGA_ARCHIVO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_REGISTRA_CONTRATODOC_CARGA_ARCHIVO]
(
	@CODIGO_CONTRATO_DOCUMENTO	UNIQUEIDENTIFIER,
	@CODIGO_CONTRATO			UNIQUEIDENTIFIER,
	@CODIGO_ARCHIVO				INT,
	@RUTA_ARCHIVOSHP			NVARCHAR(MAX),
	@CONTENIDO					NVARCHAR(MAX) = NULL,
	@USER_CREACION				NVARCHAR(50),
	@TERMINAL_CREACION			NVARCHAR(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_REGISTRA_CONTRATODOC_CARGA_ARCHIVO
Propósito:   Permite registrar un contrato de carga de archivo  
Descripción de Parámetros: 
		@CODIGO_CONTRATO_DOCUMENTO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato documento.
		@CODIGO_CONTRATO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.
		@CODIGO_ARCHIVO:	Parámetro de entrada de tipo int, que representa codigo archivo.
		@RUTA_ARCHIVOSHP:	Parámetro de entrada de tipo nvarchar, que representa ruta archivoshp.
		@CONTENIDO:	Parámetro de entrada de tipo nvarchar, que representa contenido.
		@USER_CREACION:	Parámetro de entrada de tipo nvarchar, que representa user creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	DECLARE @UltimoContenido nvarchar(max) ,
		@VersionDoc tinyint

	SELECT	@UltimoContenido	=	(CASE WHEN @CONTENIDO IS NULL THEN CD.CONTENIDO ELSE @CONTENIDO END ), 
			@VersionDoc			=	(SELECT MAX([VERSION]) FROM CTR.CONTRATO_DOCUMENTO TT WHERE TT.CODIGO_CONTRATO	=	CD.CODIGO_CONTRATO)--- mlv se agrego para que los correlativos coincidan
	FROM	CTR.CONTRATO_DOCUMENTO  CD (NOLOCK)
	WHERE	CODIGO_CONTRATO		=	@CODIGO_CONTRATO 
	AND		INDICADOR_ACTUAL	=	1 
	AND		ESTADO_REGISTRO		=	'1'

	SELECT	@UltimoContenido	=	ISNULL(@UltimoContenido,''), 
			@VersionDoc			=	ISNULL(@VersionDoc,0) + 1
	---Damos de baja a todos los documentos anteriores.------
	UPDATE CTR.CONTRATO_DOCUMENTO  
	SET INDICADOR_ACTUAL=0, 
		USUARIO_MODIFICACION	=	@USER_CREACION,
		FECHA_MODIFICACION		=	GETDATE(), 
		TERMINAL_MODIFICACION	=	@TERMINAL_CREACION	
	WHERE	CODIGO_CONTRATO		=	@CODIGO_CONTRATO 
	AND		ESTADO_REGISTRO		=	'1' 
	AND		INDICADOR_ACTUAL	=	1

	INSERT INTO CTR.CONTRATO_DOCUMENTO (CODIGO_CONTRATO_DOCUMENTO,CODIGO_CONTRATO,CODIGO_ARCHIVO,RUTA_ARCHIVO_SHAREPOINT,
			CONTENIDO, INDICADOR_ACTUAL,[VERSION],
			ESTADO_REGISTRO,USUARIO_CREACION,FECHA_CREACION,TERMINAL_CREACION )
	SELECT @CODIGO_CONTRATO_DOCUMENTO,@CODIGO_CONTRATO,@CODIGO_ARCHIVO,@RUTA_ARCHIVOSHP,
	@UltimoContenido, 1,@VersionDoc,
	'1',@USER_CREACION,GETDATE(),@TERMINAL_CREACION
	SELECT 1
END


GO
/****** Object:  StoredProcedure [CTR].[USP_RESPONDER_CONSULTA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_RESPONDER_CONSULTA]
@CODIGO_CONTRATO_ESTADIO_CONSULTA UNIQUEIDENTIFIER,
@RESPUESTA VARCHAR(MAX),
@USUARIO_MODIFICACION VARCHAR(100),
@TERMINAL_MODIFICACION VARCHAR(100)
AS
BEGIN

UPDATE CTR.CONTRATO_ESTADIO_CONSULTA SET 
RESPUESTA = @RESPUESTA,
FECHA_RESPUESTA = GETDATE(),
USUARIO_MODIFICACION = @USUARIO_MODIFICACION,
FECHA_MODIFICACION = GETDATE(),
TERMINAL_MODIFICACION = @TERMINAL_MODIFICACION
WHERE CODIGO_CONTRATO_ESTADIO_CONSULTA = @CODIGO_CONTRATO_ESTADIO_CONSULTA

SELECT 1

END
GO
/****** Object:  StoredProcedure [CTR].[USP_RESPONSABLES_FLUJO_ESTADIO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_RESPONSABLES_FLUJO_ESTADIO]
@CodigoFlujoAprobacion UNIQUEIDENTIFIER,
@CodigoContrato UNIQUEIDENTIFIER
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_RESPONSABLES_FLUJO_ESTADIO
Propósito:   Obtiene el listado de los responsables de flujo de estadio  
Descripción de Parámetros: 
		@CodigoFlujoAprobacion:	Parámetro de entrada de tipo uniqueidentifier, que representa codigoflujoaprobacion.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
DECLARE @USUARIO_CREACION VARCHAR(100) = (SELECT USUARIO_CREACION FROM CTR.CONTRATO WITH(NOLOCK) WHERE CODIGO_CONTRATO = @CODIGOCONTRATO)
DECLARE @CODIGO_TRABAJADOR_EDITOR UNIQUEIDENTIFIER
--VAMOS A OBTENER EL CODIGO DEL TRABAJADOR DE ORDEN 1, QUE ES USUALMENTE EL EDITOR

SELECT @CODIGO_TRABAJADOR_EDITOR = FAP.CODIGO_TRABAJADOR
FROM CTR.FLUJO_APROBACION_PARTICIPANTE FAP (NOLOCK) INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FAE (nolock)
ON ( FAP.CODIGO_FLUJO_APROBACION_ESTADIO=FAE.CODIGO_FLUJO_APROBACION_ESTADIO )
WHERE FAE.CODIGO_FLUJO_APROBACION = @CodigoFlujoAprobacion AND
FAP.ESTADO_REGISTRO='1' AND FAP.CODIGO_TIPO_PARTICIPANTE='R' AND ORDEN = 1

SELECT DISTINCT 
CASE FAP.CODIGO_TRABAJADOR WHEN @CODIGO_TRABAJADOR_EDITOR THEN '' ELSE CAST(FAP.CODIGO_TRABAJADOR AS VARCHAR(40)) END AS CodigoTrabajador, 
CASE FAP.CODIGO_TRABAJADOR WHEN @CODIGO_TRABAJADOR_EDITOR THEN @USUARIO_CREACION ELSE '' END AS UsuarioCreacion
--DISTINCT CASE ORDEN WHEN 1 THEN '' ELSE CAST(FAP.CODIGO_TRABAJADOR AS VARCHAR(40)) END AS CodigoTrabajador, 
--CASE ORDEN WHEN 1 THEN @USUARIO_CREACION ELSE '' END AS UsuarioCreacion
FROM CTR.FLUJO_APROBACION_PARTICIPANTE FAP (NOLOCK) INNER JOIN CTR.FLUJO_APROBACION_ESTADIO FAE (nolock)
ON ( FAP.CODIGO_FLUJO_APROBACION_ESTADIO=FAE.CODIGO_FLUJO_APROBACION_ESTADIO )
WHERE FAE.CODIGO_FLUJO_APROBACION = @CodigoFlujoAprobacion AND
FAP.ESTADO_REGISTRO='1' AND FAP.CODIGO_TIPO_PARTICIPANTE='R'

--SELECT DISTINCT CodigoTrabajador= convert(varchar(50), FAP.CODIGO_TRABAJADOR)
--			 FROM CTR.FLUJO_APROBACION_PARTICIPANTE FAP (NOLOCK) inner join CTR.FLUJO_APROBACION_ESTADIO FAE (nolock)
--ON ( FAP.CODIGO_FLUJO_APROBACION_ESTADIO=FAE.CODIGO_FLUJO_APROBACION_ESTADIO )
--WHERE FAE.CODIGO_FLUJO_APROBACION=@CodigoFlujoAprobacion and
--	FAP.ESTADO_REGISTRO='1' AND FAP.CODIGO_TIPO_PARTICIPANTE='R' AND ORDEN <> '1'

END

GO
/****** Object:  StoredProcedure [CTR].[USP_TEMP_CONTRATOS_INFORMADO_UPD]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_TEMP_CONTRATOS_INFORMADO_UPD]
(		
	@CODIGO_FLUJO_APROBACION_ESTADIO NVARCHAR(50),
	@CODIGO_INFORMADO NVARCHAR(50),
	@NOMBRE_INFORMADO NVARCHAR(255),
	@CORREO_INFORMADO NVARCHAR(100)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_TEMP_CONTRATOS_INFORMADO_UPD
Propósito:  Actualiza registros de tabla 
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACION_ESTADIO:	Parámetro de entrada de tipo nvarchar, que representa codigo flujo aprobacion estadio.
		@CODIGO_INFORMADO:	Parámetro de entrada de tipo nvarchar, que representa codigo informado.
		@NOMBRE_INFORMADO:	Parámetro de entrada de tipo nvarchar, que representa nombre informado.
		@CORREO_INFORMADO:	Parámetro de entrada de tipo nvarchar, que representa correo informado.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
UPDATE TMP.CONTRATOS_INFORMADOS
SET NOMBRE_INFORMADO = @NOMBRE_INFORMADO,
	  CORREO_INFORMADO=@CORREO_INFORMADO
WHERE CODIGO_FLUJO_APROBACION_ESTADIO=@CODIGO_FLUJO_APROBACION_ESTADIO AND CODIGO_INFORMADO=@CODIGO_INFORMADO
END

GO
/****** Object:  StoredProcedure [CTR].[USP_TEMP_CONTRATOS_RETRASADOS_INS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_TEMP_CONTRATOS_RETRASADOS_INS]
(		
	@CODIGO_FLUJO_APROBACIONE  NVARCHAR(50),
	@CODIGO_CONTRATO_ESTADIO  NVARCHAR(50),
	@NUMERO_CONTRATO NVARCHAR(15),
	@NOMBRE_PROVEEDOR NVARCHAR(255),
	@NOMBRE_RESPONSABLE NVARCHAR(100),
	@NOMBRE_UNIDAD_OPERATIVA NVARCHAR(255),
	@CORREO_RESPONSABLE NVARCHAR(100),
	@ASUNTO NVARCHAR(255),
	@CONTENIDO NVARCHAR(1000),
	@URL_SISTEMA NVARCHAR(255),
	@PROFILE_CORREO NVARCHAR(255)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_TEMP_CONTRATOS_RETRASADOS_INS
Propósito:  Insertar registros en tabla 
Descripción de Parámetros: 
		@CODIGO_FLUJO_APROBACIONE:	Parámetro de entrada de tipo nvarchar, que representa codigo flujo aprobacione.
		@CODIGO_CONTRATO_ESTADIO:	Parámetro de entrada de tipo nvarchar, que representa codigo contrato estadio.
		@NUMERO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa numero contrato.
		@NOMBRE_PROVEEDOR:	Parámetro de entrada de tipo nvarchar, que representa nombre proveedor.
		@NOMBRE_RESPONSABLE:	Parámetro de entrada de tipo nvarchar, que representa nombre responsable.
		@NOMBRE_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo nvarchar, que representa nombre unidad operativa.
		@CORREO_RESPONSABLE:	Parámetro de entrada de tipo nvarchar, que representa correo responsable.
		@ASUNTO:	Parámetro de entrada de tipo nvarchar, que representa asunto.
		@CONTENIDO:	Parámetro de entrada de tipo nvarchar, que representa contenido.
		@URL_SISTEMA:	Parámetro de entrada de tipo nvarchar, que representa url sistema.
		@PROFILE_CORREO:	Parámetro de entrada de tipo nvarchar, que representa profile correo.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
INSERT INTO TMP.CONTRATOS_RETRASADOS( CODIGO_FLUJO_APROBACION_ESTADIO, CODIGO_CONTRATO_ESTADIO, NUMERO_CONTRATO,
																	NOMBRE_PROVEEDOR, NOMBRE_RESPONSABLE,NOMBRE_UNIDAD_OPERATIVA , CORREO_RESPONSABLE, 
																	ASUNTO,CONTENIDO , URL_SISTEMA ,	 PROFILE_CORREO )
														SELECT  CONVERT(UNIQUEIDENTIFIER,@CODIGO_FLUJO_APROBACIONE),CONVERT(UNIQUEIDENTIFIER,@CODIGO_CONTRATO_ESTADIO),@NUMERO_CONTRATO,
																	@NOMBRE_PROVEEDOR, @NOMBRE_RESPONSABLE,@NOMBRE_UNIDAD_OPERATIVA, @CORREO_RESPONSABLE,
																	@ASUNTO,@CONTENIDO,@URL_SISTEMA, @PROFILE_CORREO
END

GO
/****** Object:  StoredProcedure [CTR].[USP_TIEMPOS_ATENCION_RPT]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_TIEMPOS_ATENCION_RPT]
@CODIGO_UNIDAD_OPERATIVA uniqueidentifier = null,
@FECHA_INICIO datetime,
@FECHA_FIN datetime,
@NUMERO_CONTRATO NVARCHAR(15)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_TIEMPOS_ATENCION_RPT
Propósito:  Aprueba los estadios de los contratos. 
Descripción de Parámetros: 
		@CODIGO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@FECHA_INICIO:	Parámetro de entrada de tipo datetime, que representa fecha inicio.
		@FECHA_FIN:	Parámetro de entrada de tipo datetime, que representa fecha fin.
		@NUMERO_CONTRATO:	Parámetro de entrada de tipo nvarchar, que representa numero contrato.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/

BEGIN
	SELECT @NUMERO_CONTRATO='%'+ISNULL(@NUMERO_CONTRATO,'')+'%'
	SELECT NUMERO_CONTRATO=ISNULL(CT.NUMERO_CONTRATO,''), CT.CODIGO_UNIDAD_OPERATIVA,
				 Emisor=CTR.FN_RETORNA_RESPONSABLES_ESTADIO(CE.CODIGO_FLUJO_APROBACION_ESTADIO),
				 Receptor=CEC.DESTINATARIO,
				 FechaConsulta=CEC.FECHA_REGISTRO,
				 FechaRespuesta=CEC.FECHA_RESPUESTA,
				 TiempoRespuesta = convert(decimal(8,2),convert(decimal(8,2),DATEDIFF(hh,CEC.FECHA_REGISTRO,CEC.FECHA_RESPUESTA))/convert(decimal(2,0),24))
				 FROM 	CTR.CONTRATO_ESTADIO_CONSULTA CEC (nolock) INNER JOIN CTR.CONTRATO_ESTADIO CE (NOLOCK)
		ON ( CEC.CODIGO_CONTRATO_ESTADIO = CE.CODIGO_CONTRATO_ESTADIO ) INNER JOIN CTR.CONTRATO CT (NOLOCK)
		ON ( CE.CODIGO_CONTRATO=CT.CODIGO_CONTRATO )
		WHERE (@FECHA_INICIO IS NULL OR CEC.FECHA_REGISTRO >= @FECHA_INICIO)
		AND (@FECHA_FIN IS NULL OR CEC.FECHA_REGISTRO <= @FECHA_FIN)
		AND (@CODIGO_UNIDAD_OPERATIVA IS NULL OR CT.CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA)
		AND ISNULL(CT.NUMERO_CONTRATO,'') LIKE @NUMERO_CONTRATO
		AND CEC.ESTADO_REGISTRO='1'
		AND CE.ESTADO_REGISTRO='1'
		ORDER BY CEC.FECHA_REGISTRO
END

GO
/****** Object:  StoredProcedure [CTR].[USP_TRAZABILIDAD_CONTRATO_RPT]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_TRAZABILIDAD_CONTRATO_RPT] --NULL,NULL,NULL

@CODIGO_UNIDAD_OPERATIVA uniqueidentifier = null,

@FECHA_INICIO datetime,

@FECHA_FIN datetime

AS

/**********************************************************************************************************************************

Nombre Objeto: CTR.USP_TRAZABILIDAD_CONTRATO_RPT

Propósito:  Muestra el estadio actual de los contratos. 

Descripción de Parámetros: 

		@CODIGO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.

		@FECHA_INICIO:	Parámetro de entrada de tipo datetime, que representa fecha inicio.

		@FECHA_FIN:	Parámetro de entrada de tipo datetime, que representa fecha fin.

Creado por: GMD

Fecha. Creación: 2015-08-25

Fecha. Actualización: 

**********************************************************************************************************************************/

BEGIN

	DECLARE @ST_FECINI VARCHAR(10), @ST_FECFIN VARCHAR(10)



	SELECT CT.CODIGO_UNIDAD_OPERATIVA,

				CT.CODIGO_CONTRATO,

				NUMERO_CONTRATO=ISNULL(CT.NUMERO_CONTRATO,'') ,

				RUC_PROVEEDOR=PR.NUMERO_DOCUMENTO,

				NOMBRE_PROVEEDOR= PR.NOMBRE,

				FECHA_ESTADIO = CONVERT(VARCHAR(10),CE.FECHA_INGRESO,103),

				ESTADIO_ACTUAL =CTR.FN_RETORNA_DESCRIPCION_ESTADIO(CE.CODIGO_FLUJO_APROBACION_ESTADIO)	,

				RESPONSABLE=CTR.FN_RETORNA_RESPONSABLES_ESTADIO(CE.CODIGO_FLUJO_APROBACION_ESTADIO)	

				FROM CTR.CONTRATO_ESTADIO CE (NOLOCK) INNER JOIN CTR.CONTRATO CT (NOLOCK)

	ON ( CE.CODIGO_CONTRATO=CT.CODIGO_CONTRATO  

	AND  CE.CODIGO_FLUJO_APROBACION_ESTADIO=CT.CODIGO_ESTADIO_ACTUAL) 

	INNER JOIN CTR.PROVEEDOR PR (NOLOCK)

	ON (CT.CODIGO_PROVEEDOR=PR.CODIGO_PROVEEDOR)

	WHERE CE.CODIGO_ESTADO_CONTRATO_ESTADIO='I'	

	AND (@CODIGO_UNIDAD_OPERATIVA IS NULL OR CT.CODIGO_UNIDAD_OPERATIVA=@CODIGO_UNIDAD_OPERATIVA)

	AND (@FECHA_INICIO IS NULL OR CT.FECHA_CREACION >= @FECHA_INICIO)

	AND (@FECHA_FIN IS NULL OR CONVERT(DATE,CT.FECHA_CREACION) <= @FECHA_FIN)

	AND CE.ESTADO_REGISTRO='1' AND CT.ESTADO_REGISTRO='1' 

	 AND PR.ESTADO_REGISTRO='1'

	ORDER BY 	CE.FECHA_INGRESO DESC

END

GO
/****** Object:  StoredProcedure [CTR].[USP_VARIABLE_CAMPO_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_VARIABLE_CAMPO_SEL](
	@CODIGO_VARIABLE_CAMPO	UNIQUEIDENTIFIER,
	@CODIGO_VARIABLE		UNIQUEIDENTIFIER,
	@NOMBRE					NVARCHAR(255),
	@ORDEN					TINYINT
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_VARIABLE_CAMPO_SEL
Propósito:  Obtener registros de tabla 
Descripción de Parámetros: 
		@CODIGO_VARIABLE_CAMPO:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo variable campo.
		@CODIGO_VARIABLE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo variable.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@ORDEN:	Parámetro de entrada de tipo tinyint, que representa orden.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	SELECT VC.CODIGO_VARIABLE_CAMPO AS CodigoVariableCampo,
		   VC.CODIGO_VARIABLE AS CodigoVariable,
		   VC.NOMBRE AS Nombre,
		   VC.ORDEN AS Orden,
		   VC.TIPO_ALINEAMIENTO AS TipoAlineamiento,
		   VC.TAMANIO AS Tamanio
	  FROM CTR.VARIABLE_CAMPO VC
	 WHERE VC.ESTADO_REGISTRO = '1'
	   AND (@CODIGO_VARIABLE_CAMPO	IS NULL OR VC.CODIGO_VARIABLE_CAMPO	= @CODIGO_VARIABLE_CAMPO)
	   AND (@CODIGO_VARIABLE		IS NULL OR VC.CODIGO_VARIABLE		= @CODIGO_VARIABLE)
	   AND (@NOMBRE					IS NULL OR VC.NOMBRE				= @NOMBRE)
	   AND (@ORDEN					IS NULL OR VC.ORDEN					= @ORDEN)
	 ORDER BY VC.ORDEN
END

GO
/****** Object:  StoredProcedure [CTR].[USP_VARIABLE_GLOBAL_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [CTR].[USP_VARIABLE_GLOBAL_SEL]
(
	@CODIGO_PLANTILLA	UNIQUEIDENTIFIER,
	@ESTADO_REGISTRO	CHAR(1)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_VARIABLE_GLOBAL_SEL
Propósito:   Obtiene el listado de la variable global  
Descripción de Parámetros: 
		@CODIGO_PLANTILLA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
SELECT	CODIGO_VARIABLE	as 	CodigoVariable,
		CODIGO_PLANTILLA	as CodigoPlantilla,
		IDENTIFICADOR	as	Identificador,
		NOMBRE	as			Nombre
FROM	CTR.VARIABLE (nolock)
WHERE	 INDICADOR_GLOBAL = 1
	--(case when INDICADOR_GLOBAL = 1 then @CODIGO_PLANTILLA else  CODIGO_PLANTILLA end )  = @CODIGO_PLANTILLA OR INDICADOR_GLOBAL = 1)
AND		ESTADO_REGISTRO = @ESTADO_REGISTRO
UNION
SELECT	CODIGO_VARIABLE	as 	CodigoVariable,
		CODIGO_PLANTILLA	as CodigoPlantilla,
		IDENTIFICADOR	as	Identificador,
		NOMBRE	as			Nombre
FROM	CTR.VARIABLE (nolock)
WHERE	 INDICADOR_GLOBAL = 0
	AND CODIGO_PLANTILLA = @CODIGO_PLANTILLA 
AND		ESTADO_REGISTRO = @ESTADO_REGISTRO
order by NOMBRE	

GO
/****** Object:  StoredProcedure [CTR].[USP_VARIABLE_LISTA_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_VARIABLE_LISTA_SEL](
	@CODIGO_VARIABLE_LISTA	UNIQUEIDENTIFIER,
	@CODIGO_VARIABLE		UNIQUEIDENTIFIER,
	@NOMBRE					NVARCHAR(255)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_VARIABLE_LISTA_SEL
Propósito:  Obtener registros de tabla 
Descripción de Parámetros: 
		@CODIGO_VARIABLE_LISTA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo variable lista.
		@CODIGO_VARIABLE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo variable.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	SELECT VL.CODIGO_VARIABLE_LISTA AS CodigoVariableLista,
		   VL.CODIGO_VARIABLE AS CodigoVariable,
		   VL.NOMBRE AS Nombre,
		   VL.DESCRIPCION AS Descripcion
	  FROM CTR.VARIABLE_LISTA VL
	 WHERE Vl.ESTADO_REGISTRO = '1'
	   AND (@CODIGO_VARIABLE_LISTA	IS NULL OR VL.CODIGO_VARIABLE_LISTA	= @CODIGO_VARIABLE_LISTA)
	   AND (@CODIGO_VARIABLE		IS NULL OR VL.CODIGO_VARIABLE		= @CODIGO_VARIABLE)
	   AND (@NOMBRE					IS NULL OR VL.NOMBRE				= @NOMBRE)
	 ORDER BY VL.NOMBRE ASC
END

GO
/****** Object:  StoredProcedure [CTR].[USP_VARIABLE_SEL]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CTR].[USP_VARIABLE_SEL] 
@CODIGO_VARIABLE UNIQUEIDENTIFIER = NULL,
@IDENTIFICADOR NVARCHAR(255) = NULL,
@NOMBRE NVARCHAR(255) = NULL,
@CODIGO_TIPO NVARCHAR(5) = NULL,
@INDICADOR_GLOBAL BIT = NULL,
@CODIGO_PLANTILLA UNIQUEIDENTIFIER = NULL,
@INDICADOR_VARIABLE_SISTEMA BIT = NULL
AS
/**********************************************************************************************************************************
Nombre Objeto: CTR.USP_VARIABLE_SEL
Propósito:   Obtener registros   
Descripción de Parámetros: 
		@CODIGO_VARIABLE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo variable.
		@IDENTIFICADOR:	Parámetro de entrada de tipo nvarchar, que representa identificador.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@CODIGO_TIPO:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo.
		@INDICADOR_GLOBAL:	Parámetro de entrada de tipo bit, que representa indicador global.
		@CODIGO_PLANTILLA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla.
		@INDICADOR_VARIABLE_SISTEMA:	Parámetro de entrada de tipo bit, que representa indicador variable sistema.
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	SELECT
			CODIGO_VARIABLE AS CodigoVariable,
			IDENTIFICADOR AS Identificador,
			NOMBRE AS Nombre,
			DESCRIPCION AS Descripcion,
			CODIGO_TIPO AS CodigoTipo,
			INDICADOR_GLOBAL AS IndicadorGlobal,
			CODIGO_PLANTILLA AS CodigoPlantilla,
			INDICADOR_VARIABLE_SISTEMA AS IndicadorVariableSistema

	FROM	CTR.VARIABLE

	WHERE	(CODIGO_VARIABLE = @CODIGO_VARIABLE OR @CODIGO_VARIABLE IS NULL)
	AND		(IDENTIFICADOR LIKE + '%' + @IDENTIFICADOR + '%' OR ISNULL(@IDENTIFICADOR,'')='')
	AND		(NOMBRE LIKE +'%' + @NOMBRE + '%' OR ISNULL(@NOMBRE,'')='')
	AND		(CODIGO_TIPO = @CODIGO_TIPO OR ISNULL(@CODIGO_TIPO,'')='')
	AND		(INDICADOR_GLOBAL = @INDICADOR_GLOBAL OR @INDICADOR_GLOBAL IS NULL)
	AND		(CODIGO_PLANTILLA = @CODIGO_PLANTILLA OR @CODIGO_PLANTILLA IS NULL)
	AND		(INDICADOR_VARIABLE_SISTEMA = @INDICADOR_VARIABLE_SISTEMA OR @INDICADOR_VARIABLE_SISTEMA IS NULL)
	AND		(ESTADO_REGISTRO = '1')

	ORDER BY NOMBRE
END


GO
/****** Object:  StoredProcedure [dbo].[USP_ENVIO_CORREO_DTS_ENVIO_ALERTA_ESTADIO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_ENVIO_CORREO_DTS_ENVIO_ALERTA_ESTADIO]
AS
BEGIN
	DECLARE @DESTINATARIO		NVARCHAR(MAX)
	DECLARE @ASUNTO				NVARCHAR(MAX)
	DECLARE @CONTENIDO		    NVARCHAR(MAX)
	DECLARE @FILA				INT

	SET LANGUAGE	spanish;
	SET DATEFORMAT  dmy;

		--Creamos el rownumber para la lista de correo y lo guardamos en un temporal
			SELECT  
						ROW_NUMBER() OVER (Order by CODIGO_TRABAJADOR) AS RowNumber,
						EMISOR,
        				CODIGO_CONTRATO,
        				NOMBRE_COMPLETO,
						ASUNTO,
        				CORREO_ELECTRONICO,
        				NUMERO_CONTRATO,
        				DIRECCION_SISTEMA,
        				REPLACE(
								REPLACE(REPLACE(CONTENIDO, '@usuario', ISNULL(NOMBRE_COMPLETO, '')), '@numero_contrato', ISNULL	(NUMERO_CONTRATO,'')),
												'@direccion_sistema', ISNULL(DIRECCION_SISTEMA, ''))	CONTENIDO
			INTO	#TMP_DATA_CORREO
			FROM    TMP.LISTA_CORREO

		--Declaramos las variables para recorrer la lista.
		DECLARE @LoopCounter INT = 1, @Max INT = (SELECT COUNT(RowNumber) FROM #TMP_DATA_CORREO)

		WHILE	(@LoopCounter <= @Max )
			BEGIN
				SELECT	
						@FILA			= RowNumber,
						@DESTINATARIO	= CORREO_ELECTRONICO,
						@ASUNTO			= ASUNTO,
						@CONTENIDO		= CONTENIDO
				FROM #TMP_DATA_CORREO
				WHERE RowNumber = @LoopCounter
				ORDER BY RowNumber ASC

				SET @LoopCounter = @LoopCounter + 1

				WAITFOR DELAY '00:00:05';  
				EXEC	[MSDB].[DBO].[SP_SEND_DBMAIL]	@PROFILE_NAME		=  'SISTEMA SGC',
														@RECIPIENTS			=  @DESTINATARIO,
														@BODY				=  @CONTENIDO,
														@COPY_RECIPIENTS 	=  '',
														@BODY_FORMAT   		=  'html',
														@SUBJECT        	=   @ASUNTO,
														@IMPORTANCE     	=   'High'

			END
END
GO
/****** Object:  UserDefinedFunction [CTR].[CONVERT_HTML_TEXT]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [CTR].[CONVERT_HTML_TEXT]  
(@HTMLText varchar(max))  
RETURNS VARCHAR(MAX)  
AS  
BEGIN  
DECLARE @Start INT  
DECLARE @End INT  
DECLARE @Length INT  
SET @HTMLText = REPLACE(@HTMLText,'&nbsp;', ' ')
SET @HTMLText = REPLACE(@HTMLText,'&amp;', '&')
SET @Start = CHARINDEX('<',@HTMLText)  
SET @End = CHARINDEX('>',@HTMLText,@Start)  
SET @Length = (@End - @Start) + 1  
WHILE @Start > 0  
AND @End > 0  
AND @Length > 0  
BEGIN  
SET @HTMLText = STUFF(@HTMLText,@Start,@Length,'')  
SET @Start = CHARINDEX('<',@HTMLText)  
SET @End = CHARINDEX('>',@HTMLText,@Start)  
SET @Length = (@End - @Start) + 1  
END  
RETURN LTRIM(RTRIM(@HTMLText))  
END  


GO
/****** Object:  UserDefinedFunction [CTR].[FN_CALCULAMESESCONTRATO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [CTR].[FN_CALCULAMESESCONTRATO] (@fecha_inicio DATETIME, @fecha_fin DATETIME)
RETURNS DECIMAL(5,1)
AS BEGIN
	DECLARE @Retorno DECIMAL(5,1) = 0
	DECLARE @Cantidad_meses INT
	DECLARE @Residuo INT
    DECLARE @Cantidad_dias INT
	DECLARE @Quincenas INT

	SET @Cantidad_dias = (SELECT DATEDIFF(DAY,@fecha_inicio, @fecha_fin));
	SET @Cantidad_meses = (SELECT @Cantidad_dias / 30);
	SET @Residuo = (SELECT @Cantidad_dias % 30);

	IF @Cantidad_meses = 0
	BEGIN
		--SET @Quincenas = @Cantidad_dias / 15
		--IF @Quincenas = 1 SET @Retorno = 0.5;
		SET @Retorno = 1;
	END
	ELSE
	IF @Cantidad_meses > 0
	BEGIN
		SET @Quincenas = @Residuo / 15
		IF @Quincenas = 1 SET @Retorno = 0.5 + @Cantidad_meses ELSE SET @Retorno = @Cantidad_meses;
	END
RETURN @Retorno
END

GO
/****** Object:  UserDefinedFunction [CTR].[FN_OBTENER_NUMEROS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Creo una funcion de usuario
Create Function [CTR].[FN_OBTENER_NUMEROS](@Data VarChar(8000))
Returns VarChar(8000)
AS
Begin
    Return Left(
             SubString(@Data, PatIndex('%[0-9.-]%', @Data), 8000),
             PatIndex('%[^0-9.-]%', SubString(@Data, PatIndex('%[0-9.-]%', @Data), 8000) + 'X')-1)
End
GO
/****** Object:  UserDefinedFunction [CTR].[FN_RETORNA_DESCRIPCION_ESTADIO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [CTR].[FN_RETORNA_DESCRIPCION_ESTADIO](
@CODIGO_FLUJO_APROBACION_ESTADIO uniqueidentifier
)
/***********************************************************************************
Nombre: FN_RETORNA_DESCRIPCION_ESTADIO
Propósito: Retorna la descripción del estadio del Flujo de aprobación
Descripción de Parámetros: 
	@CODIGO_FLUJO_APROBACION_ESTADIO: código del flujo de aprobación de estadio.
Creado por: GARC
Fecha. Creación: 2015-06-22
Fecha. Actualización: 
************************************************************************************/
RETURNS NVARCHAR(255)
BEGIN
DECLARE @DESCRIPCION NVARCHAR(255)
		SELECT @DESCRIPCION=ISNULL(DESCRIPCION,'')
		FROM CTR.FLUJO_APROBACION_ESTADIO (NOLOCK)	
		WHERE CODIGO_FLUJO_APROBACION_ESTADIO=@CODIGO_FLUJO_APROBACION_ESTADIO		

SELECT @DESCRIPCION =ISNULL(@DESCRIPCION,'')

return @DESCRIPCION
END

GO
/****** Object:  UserDefinedFunction [CTR].[FN_RETORNA_FLUJO_APROBACION_PARTICIPANTE]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [CTR].[FN_RETORNA_FLUJO_APROBACION_PARTICIPANTE]
(
	@CODIGO_FLUJO_APROBACION_ESTADIO uniqueidentifier,
	@CODIGO_TIPO_PARTICIPANTE CHAR(1)
)
/**********************************************************************************************************************************
Nombre Objeto: CTR.FN_RETORNA_FLUJO_APROBACION_PARTICIPANTE
Propósito: Permite retornar los flujos de participantes y la lista de aprobación
Descripción de Parámetros: 
			@CODIGO_FLUJO_APROBACION_ESTADIO Parámetro de entrada de tipo uniqueidentifier, que representa el codigo flujo aprobacion de estado
			@CODIGO_TIPO_PARTICIPANTE Parámetro de entrada de tipo char, que representa codigo tipo participante
Creado por: GMD
Fecha. Creación: 2015-06-10
Fecha. Actualización: 
**********************************************************************************************************************************/
RETURNS VARCHAR(1000)
BEGIN
		DECLARE @CODIGOS_TRABAJADOR NVARCHAR(MAX)
		SET @CODIGOS_TRABAJADOR = ''
		
		SELECT @CODIGOS_TRABAJADOR += '/' + CONVERT(NVARCHAR(MAX), FAP.CODIGO_TRABAJADOR)
		FROM CTR.FLUJO_APROBACION_PARTICIPANTE FAP
		WHERE FAP.CODIGO_FLUJO_APROBACION_ESTADIO = @CODIGO_FLUJO_APROBACION_ESTADIO
		AND FAP.ESTADO_REGISTRO = '1' AND FAP.CODIGO_TIPO_PARTICIPANTE = @CODIGO_TIPO_PARTICIPANTE
		IF @CODIGOS_TRABAJADOR <> NULL AND @CODIGOS_TRABAJADOR <> ''
		BEGIN
			SET @CODIGOS_TRABAJADOR = SUBSTRING(@CODIGOS_TRABAJADOR,1,LEN(@CODIGOS_TRABAJADOR))
		END

return @CODIGOS_TRABAJADOR 
END

GO
/****** Object:  UserDefinedFunction [CTR].[FN_RETORNA_INFORMADOS_ESTADIO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE FUNCTION [CTR].[FN_RETORNA_INFORMADOS_ESTADIO](
@CODIGO_FLUJO_APROBACION_ESTADIO uniqueidentifier
)
/***********************************************************************************
Nombre: FN_RETORNA_INFORMADOS_ESTADIO
Propósito: Retorna los informados del estadio del Flujo de aprobación
Descripción de Parámetros: 
	@CODIGO_FLUJO_APROBACION_ESTADIO: código del flujo de aprobación de estadio.
Creado por: GARC
Fecha. Creación: 2015-07-02
Fecha. Actualización: 2017-11-06 Corrección para obtener involucrados con el código flujo de aprobación
************************************************************************************/
RETURNS VARCHAR(1000)
BEGIN
DECLARE @TBL_INFORMADOS TABLE( CODIGO_TRABAJADOR VARCHAR(40) );
DECLARE @CODIGO_FLUJO_APROBACION uniqueidentifier, @ORDEN INT

		SELECT @CODIGO_FLUJO_APROBACION = CODIGO_FLUJO_APROBACION, @ORDEN = ORDEN FROM CTR.FLUJO_APROBACION_ESTADIO WHERE CODIGO_FLUJO_APROBACION_ESTADIO= @CODIGO_FLUJO_APROBACION_ESTADIO

		--INSERT INTO @TBL_INFORMADOS (CODIGO_TRABAJADOR)
		--SELECT CODIGO_TRABAJADOR  FROM CTR.FLUJO_APROBACION_PARTICIPANTE (NOLOCK)	
		--WHERE CODIGO_FLUJO_APROBACION_ESTADIO=@CODIGO_FLUJO_APROBACION_ESTADIO
		--AND CODIGO_TIPO_PARTICIPANTE='I' AND ESTADO_REGISTRO='1'

	INSERT INTO @TBL_INFORMADOS (CODIGO_TRABAJADOR)
	SELECT CODIGO_TRABAJADOR FROM CTR.FLUJO_APROBACION_PARTICIPANTE WHERE CODIGO_FLUJO_APROBACION_ESTADIO = 
	(SELECT CODIGO_FLUJO_APROBACION_ESTADIO FROM ctr.FLUJO_APROBACION_ESTADIO
	WHERE ORDEN = 
		(Select MIN(ORDEN) from ctr.FLUJO_APROBACION_ESTADIO where CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION 
		 AND ORDEN > @ORDEN AND ESTADO_REGISTRO='1')
	AND CODIGO_FLUJO_APROBACION = @CODIGO_FLUJO_APROBACION AND ESTADO_REGISTRO='1')
	AND ESTADO_REGISTRO = '1' AND CODIGO_TIPO_PARTICIPANTE = 'I'

DECLARE @INFORMADOS VARCHAR(1000)
SET   @INFORMADOS=''
SELECT @INFORMADOS = @INFORMADOS + COALESCE(CODIGO_TRABAJADOR +';','' )
	FROM @TBL_INFORMADOS

return @INFORMADOS
END


GO
/****** Object:  UserDefinedFunction [CTR].[FN_RETORNA_LISTA_CONTRATOS_PRV_NOTIFICAR]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [CTR].[FN_RETORNA_LISTA_CONTRATOS_PRV_NOTIFICAR]()
/**********************************************************************************************************************************
Nombre Objeto: CTR.FN_RETORNA_LISTA_CONTRATOS_PRV_NOTIFICAR
Propósito: <<No especificado>>
Descripción de Parámetros: 
         <<None>>
Creado por: GMD
Fecha. Creación: 2015-08-25
Fecha. Actualización: 
**********************************************************************************************************************************/
RETURNS VARCHAR(2500)
BEGIN
DECLARE @ROWMIN INT,@ROWMAX INT
DECLARE @LV_FILA VARCHAR(1000)
--DECLARE @TBL_INFORMADOS TABLE(FILA INT, TEXTO_MENSAJE VARCHAR(8000) )
--INSERT INTO @TBL_INFORMADOS (FILA, TEXTO_MENSAJE)
--SELECT ROW_ID, 'Proveedor: '+ NOMBRE_PROVEEDOR+' - Tipo: '+NOMBRE_ORDEN+' - Moneda: '+NOMBRE_MONEDA+' - Monto Acumulado: '+CONVERT(VARCHAR(20),CONVERT(NUMERIC(18,2),MONTO_CONTRATO))
--FROM TMP.CONTRATOS_NOTIFICAR
SELECT @ROWMIN=MIN(ROW_ID), 
			@ROWMAX=MAX(ROW_ID),@LV_FILA='' FROM TMP.CONTRATOS_NOTIFICAR (NOLOCK)
				  
DECLARE @LISTA_ORDENES VARCHAR(2500)

SET   @LISTA_ORDENES='<table align="center" border=1 style="text-align:center;" >
  <caption><b>[SGC] Contratos por Generar</b></caption>
  <thead>
    <tr style="background-color:#A8CFF1" ><th style="width:40%">Proveedor</th><th style="width:20%">Tipo de Orden</th><th style="width:20%">Moneda</th><th style="width:20%">Monto Acumulado</th></tr>
  </thead>
  <tbody>@@contenido</tbody>
</table>'

WHILE @ROWMIN<=@ROWMAX
BEGIN
		SELECT @LV_FILA +='<tr><td>'+ NOMBRE_PROVEEDOR+'</td><td>'+NOMBRE_ORDEN+ '</td><td>' +
					NOMBRE_MONEDA+ '</td><td>' + CONVERT(VARCHAR(20),CONVERT(NUMERIC(18,2),MONTO_CONTRATO))+'</td></tr>'
					FROM TMP.CONTRATOS_NOTIFICAR WHERE ROW_ID=@ROWMIN
		SET @ROWMIN +=1
END
SELECT @LISTA_ORDENES=REPLACE(@LISTA_ORDENES,'@@contenido', @LV_FILA )
--SELECT @LISTA_ORDENES = @LISTA_ORDENES + COALESCE(TEXTO_MENSAJE + CHAR(13) +'','' )
--	FROM @TBL_INFORMADOS

return @LISTA_ORDENES
END

GO
/****** Object:  UserDefinedFunction [CTR].[FN_RETORNA_NOMBRE_NUMDOC_PROVEEDOR]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [CTR].[FN_RETORNA_NOMBRE_NUMDOC_PROVEEDOR](
@CODIGO_PROVEEDOR uniqueidentifier,
@TIPO_CAMPO CHAR(1)
)
/***********************************************************************************
Nombre: FN_RETORNA_NOMBRE_NUMDOC_PROVEEDOR
Propósito: Retorna el número de documento o nombre del proveedor por su código y un parámetro.
Descripción de Parámetros: 
	@CODIGO_PROVEEDOR: código de proveedor
	@TIPO_CAMPO: tipo de valor devuelto: D: número de documento, N: nombre
Creado por: GARC
Fecha. Creación: 2015-07-02
Fecha. Actualización: 
************************************************************************************/
RETURNS nvarchar(255)
BEGIN
DECLARE @RETORNO nvarchar(255)

		SELECT @RETORNO=(CASE @TIPO_CAMPO WHEN 'D' THEN  PR.NUMERO_DOCUMENTO WHEN 'N' then PR.NOMBRE ELSE '' END ) FROM CTR.PROVEEDOR PR (NOLOCK)
		WHERE PR.CODIGO_PROVEEDOR = @CODIGO_PROVEEDOR AND ESTADO_REGISTRO='1'
return @RETORNO
END

GO
/****** Object:  UserDefinedFunction [CTR].[FN_RETORNA_ORDEN_FLUJO_APROBACION_ESTADIO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [CTR].[FN_RETORNA_ORDEN_FLUJO_APROBACION_ESTADIO]
(
	@CODIGO_FLUJO_APROBACION_ESTADIO uniqueidentifier
)
/**********************************************************************************************************************************
Nombre Objeto: CTR.FN_RETORNA_ORDEN_FLUJO_APROBACION_ESTADIO
Propósito: Permite retornar el orden de un Flujo de Aprobacion estadio.
Descripción de Parámetros: 
			@CODIGO_FLUJO_APROBACION_ESTADIO Parámetro de entrada de tipo uniqueidentifier, que representa el codigo flujo aprobacion de estado			
Creado por: GMD
Fecha. Creación: 2015-07-02
Fecha. Actualización: 
**********************************************************************************************************************************/
RETURNS int
BEGIN
		DECLARE @ORDEN INT				
		SELECT @ORDEN =FAE.ORDEN
		FROM CTR.FLUJO_APROBACION_ESTADIO FAE (nolock)
		WHERE FAE.CODIGO_FLUJO_APROBACION_ESTADIO = @CODIGO_FLUJO_APROBACION_ESTADIO				
		SELECT @ORDEN=ISNULL(@ORDEN,0)
		return @ORDEN
END

GO
/****** Object:  UserDefinedFunction [CTR].[FN_RETORNA_RESPONSABLE_FLUJO_ESTADIO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [CTR].[FN_RETORNA_RESPONSABLE_FLUJO_ESTADIO](
@CODIGO_FLUJO_APROBACION_ESTADIO uniqueidentifier,
@CODIGO_CONTRATO_ESTADIO uniqueidentifier
)
/***********************************************************************************
Nombre: FN_RETORNA_RESPONSABLE_FLUJO_ESTADIO
Propósito: Retorna el responsable del estadio del Flujo de aprobación teniendo en cuenta empresas vinculadas
Descripción de Parámetros: 
	@CODIGO_FLUJO_APROBACION_ESTADIO: Código del flujo de aprobación de estadio
	@CODIGO_CONTRATO_ESTADIO: Código de contrato estadio
Creado por: GARC
Fecha. Creación: 2015-09-29
Fecha. Actualización: 
************************************************************************************/
RETURNS uniqueidentifier
BEGIN

DECLARE @CODIGO_TRABAJADOR uniqueidentifier,
@NUMERO_DOCUMENTO VARCHAR (20) = NULL

		SELECT @CODIGO_TRABAJADOR=CODIGO_TRABAJADOR  FROM CTR.FLUJO_APROBACION_PARTICIPANTE (NOLOCK)	
		WHERE CODIGO_FLUJO_APROBACION_ESTADIO=@CODIGO_FLUJO_APROBACION_ESTADIO
		AND CODIGO_TIPO_PARTICIPANTE='R' AND ESTADO_REGISTRO='1'
		
		IF (@CODIGO_CONTRATO_ESTADIO IS NOT NULL)
		BEGIN

			SELECT @NUMERO_DOCUMENTO = NUMERO_DOCUMENTO FROM CTR.PROVEEDOR 
			WHERE CODIGO_PROVEEDOR = (SELECT CODIGO_PROVEEDOR FROM CTR.CONTRATO WHERE CODIGO_CONTRATO = 
					(SELECT CODIGO_CONTRATO from ctr.CONTRATO_ESTADIO where CODIGO_CONTRATO_ESTADIO = @CODIGO_CONTRATO_ESTADIO))

			IF (@NUMERO_DOCUMENTO IS NOT NULL)
			BEGIN
	
				IF EXISTS(SELECT 1 FROM CTR.EMPRESA_VINCULADA EM 
					WHERE EM.NUMERO_RUC = @NUMERO_DOCUMENTO COLLATE Latin1_General_CI_AS AND EM.ESTADO_REGISTRO = '1')
				BEGIN 		
		
					SELECT @CODIGO_TRABAJADOR = CODIGO_TRABAJADOR  FROM CTR.FLUJO_APROBACION_PARTICIPANTE (NOLOCK)	
							WHERE CODIGO_FLUJO_APROBACION_ESTADIO= @CODIGO_FLUJO_APROBACION_ESTADIO
							AND CODIGO_TIPO_PARTICIPANTE='V' AND ESTADO_REGISTRO='1'
				END
			END

		END


return @CODIGO_TRABAJADOR
END

GO
/****** Object:  UserDefinedFunction [CTR].[FN_RETORNA_RESPONSABLES_ESTADIO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [CTR].[FN_RETORNA_RESPONSABLES_ESTADIO](
@CODIGO_FLUJO_APROBACION_ESTADIO uniqueidentifier
)
/***********************************************************************************
Nombre: FN_RETORNA_RESPONSABLES_ESTADIO
Propósito: Retorna el responsable del estadio del Flujo de aprobación
Descripción de Parámetros: 
	@CODIGO_FLUJO_APROBACION_ESTADIO: código del flujo de aprobación de estadio.
Creado por: GARC
Fecha. Creación: 2015-06-11
Fecha. Actualización: 
************************************************************************************/
RETURNS uniqueidentifier
BEGIN
DECLARE @CODIGO_TRABAJADOR uniqueidentifier
		SELECT @CODIGO_TRABAJADOR=CODIGO_TRABAJADOR  FROM CTR.FLUJO_APROBACION_PARTICIPANTE (NOLOCK)	
		WHERE CODIGO_FLUJO_APROBACION_ESTADIO=@CODIGO_FLUJO_APROBACION_ESTADIO
		AND CODIGO_TIPO_PARTICIPANTE='R' AND ESTADO_REGISTRO='1'
return @CODIGO_TRABAJADOR
END


GO
/****** Object:  UserDefinedFunction [CTR].[SplitString]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [CTR].[SplitString]
(    
      @Input NVARCHAR(MAX),
      @Character CHAR(1)
)
RETURNS @Output TABLE (
      Item NVARCHAR(1000)
)
AS
BEGIN
      DECLARE @StartIndex INT, @EndIndex INT
 
      SET @StartIndex = 1
      IF SUBSTRING(@Input, LEN(@Input) - 1, LEN(@Input)) <> @Character
      BEGIN
            SET @Input = @Input + @Character
      END
 
      WHILE CHARINDEX(@Character, @Input) > 0
      BEGIN
            SET @EndIndex = CHARINDEX(@Character, @Input)
           
            INSERT INTO @Output(Item)
            SELECT SUBSTRING(@Input, @StartIndex, @EndIndex - 1)
           
            SET @Input = SUBSTRING(@Input, @EndIndex + 1, LEN(@Input))
      END
 
      RETURN
END

GO
/****** Object:  Table [CTR].[AUDITORIA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[AUDITORIA](
	[CODIGO_AUDITORIA] [uniqueidentifier] NOT NULL,
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NOT NULL,
	[FECHA_PLANIFICADA] [datetime] NOT NULL,
	[FECHA_EJECUCION] [datetime] NULL,
	[CANTIDAD_AUDITADAS] [smallint] NULL,
	[CANTIDAD_OBSERVADAS] [smallint] NULL,
	[RESULTADO_AUDITORIA] [nvarchar](max) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_AUDITORIA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_AUDITORIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[BIEN]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[BIEN](
	[CODIGO_BIEN] [uniqueidentifier] NOT NULL,
	[CODIGO_TIPO_BIEN] [nvarchar](5) NOT NULL,
	[CODIGO_IDENTIFICACION] [nvarchar](50) NULL,
	[NUMERO_SERIE] [nvarchar](50) NOT NULL,
	[DESCRIPCION] [nvarchar](255) NOT NULL,
	[MARCA] [nvarchar](255) NULL,
	[MODELO] [nvarchar](255) NULL,
	[FECHA_ADQUISICION] [datetime] NULL,
	[TIEMPO_VIDA] [decimal](10, 2) NOT NULL,
	[VALOR_RESIDUAL] [decimal](10, 2) NOT NULL,
	[CODIGO_TIPO_TARIFA] [nvarchar](5) NOT NULL,
	[CODIGO_PERIODO_ALQUILER] [nvarchar](5) NULL,
	[VALOR_ALQUILER] [decimal](10, 2) NULL,
	[CODIGO_MONEDA] [nvarchar](3) NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
	[MES_INICIO_ALQUILER] [tinyint] NULL,
	[ANIO_INICIO_ALQUILER] [smallint] NULL,
 CONSTRAINT [PK_EQUIPO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_BIEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[BIEN_ALQUILER]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[BIEN_ALQUILER](
	[CODIGO_BIEN_ALQUILER] [uniqueidentifier] NOT NULL,
	[CODIGO_BIEN] [uniqueidentifier] NOT NULL,
	[INDICADOR_SIN_LIMITE] [bit] NOT NULL,
	[CANTIDAD_LIMITE] [decimal](10, 2) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
	[MONTO] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_BIEN_ALQUILER] PRIMARY KEY CLUSTERED 
(
	[CODIGO_BIEN_ALQUILER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONSULTA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONSULTA](
	[CODIGO_CONSULTA] [uniqueidentifier] NOT NULL,
	[CODIGO_REMITENTE] [uniqueidentifier] NOT NULL,
	[CODIGO_DESTINATARIO] [uniqueidentifier] NOT NULL,
	[TIPO] [nvarchar](5) NOT NULL,
	[ASUNTO] [varchar](255) NOT NULL,
	[CONTENIDO] [nvarchar](4000) NOT NULL,
	[ESTADO_CONSULTA] [nvarchar](5) NULL,
	[FECHA_ENVIO] [datetime] NULL,
	[RESPUESTA] [nvarchar](4000) NULL,
	[FECHA_RESPUESTA] [datetime] NULL,
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NULL,
	[CODIGO_AREA] [varchar](50) NULL,
	[ES_VALIDO] [bit] NULL,
	[CODIGO_CONSULTA_RELACIONADO] [uniqueidentifier] NULL,
	[CODIGO_CONSULTA_ORIGINAL] [uniqueidentifier] NULL,
	[VISTO_REMITENTE_ORIGINAL] [bit] NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONSULTA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONSULTA_ADJUNTO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONSULTA_ADJUNTO](
	[CODIGO_CONSULTA_ADJUNTO] [uniqueidentifier] NOT NULL,
	[CODIGO_CONSULTA] [uniqueidentifier] NOT NULL,
	[CODIGO_ARCHIVO] [int] NOT NULL,
	[NOMBRE_ARCHIVO] [nvarchar](255) NOT NULL,
	[RUTA_ARCHIVO_SHAREPOINT] [nvarchar](max) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_CONSULTA_ADJUNTO_1] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONSULTA_ADJUNTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONTRATO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONTRATO](
	[CODIGO_CONTRATO] [uniqueidentifier] NOT NULL,
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NOT NULL,
	[CODIGO_PROVEEDOR] [uniqueidentifier] NOT NULL,
	[NUMERO_CONTRATO] [nvarchar](50) NULL,
	[DESCRIPCION] [nvarchar](255) NULL,
	[NUMERO_ADENDA] [int] NULL,
	[CODIGO_TIPO_SERVICIO] [nvarchar](5) NOT NULL,
	[CODIGO_TIPO_REQUERIMIENTO] [nvarchar](15) NULL,
	[CODIGO_TIPO_DOCUMENTO] [nvarchar](5) NULL,
	[INDICADOR_VERSION_OFICIAL] [bit] NULL,
	[FECHA_INICIO_VIGENCIA] [datetime] NOT NULL,
	[FECHA_FIN_VIGENCIA] [datetime] NOT NULL,
	[CODIGO_MONEDA] [char](3) NOT NULL,
	[MONTO_CONTRATO] [decimal](12, 2) NOT NULL,
	[MONTO_ACUMULADO] [decimal](12, 2) NOT NULL,
	[CODIGO_ESTADO] [nvarchar](5) NOT NULL,
	[CODIGO_PLANTILLA] [uniqueidentifier] NULL,
	[CODIGO_CONTRATO_PRINCIPAL] [uniqueidentifier] NULL,
	[CODIGO_ESTADO_EDICION] [nvarchar](5) NULL,
	[COMENTARIO_MODIFICACION] [varchar](max) NULL,
	[RESPUESTA_MODIFICACION] [nvarchar](max) NULL,
	[CODIGO_FLUJO_APROBACION] [uniqueidentifier] NULL,
	[CODIGO_ESTADIO_ACTUAL] [uniqueidentifier] NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
	[NUMERO_ADENDA_CONCATENADO] [nvarchar](80) NULL,
	[ES_FLEXIBLE] [bit] NULL,
	[ES_CORPORATIVO] [bit] NULL,
	[MOTIVO_ELIMINACION] [nvarchar](max) NULL,
	[CODIGO_CONTRATO_ORIGINAL] [uniqueidentifier] NULL,
	[FECHA_RESOLUCION] [datetime] NULL,
	[CODIGOREQUERIDO] [uniqueidentifier] NULL,
 CONSTRAINT [PK_CONTRATO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONTRATO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONTRATO_BIEN]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONTRATO_BIEN](
	[CODIGO_CONTRATO_BIEN] [uniqueidentifier] NOT NULL,
	[CODIGO_CONTRATO] [uniqueidentifier] NOT NULL,
	[CODIGO_BIEN] [uniqueidentifier] NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
	[TIPO_TARIFA] [char](1) NULL,
	[TIPO_PERIODO] [char](1) NULL,
	[HORAS_MINIMAS] [int] NULL,
	[TARIFA] [decimal](18, 2) NULL,
	[MAYORMENOR] [varchar](100) NULL,
 CONSTRAINT [PK_CONTRATO_BIEN] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONTRATO_BIEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONTRATO_DOCUMENTO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONTRATO_DOCUMENTO](
	[CODIGO_CONTRATO_DOCUMENTO] [uniqueidentifier] NOT NULL,
	[CODIGO_CONTRATO] [uniqueidentifier] NOT NULL,
	[CODIGO_ARCHIVO] [int] NOT NULL,
	[RUTA_ARCHIVO_SHAREPOINT] [nvarchar](max) NULL,
	[CONTENIDO] [nvarchar](max) NULL,
	[CONTENIDO_BUSQUEDA] [nvarchar](max) NULL,
	[INDICADOR_ACTUAL] [bit] NOT NULL,
	[VERSION] [tinyint] NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_CONTRATO_DOCUMENTO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONTRATO_DOCUMENTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONTRATO_DOCUMENTO_ADJUNTO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONTRATO_DOCUMENTO_ADJUNTO](
	[CODIGO_CONTRATO_DOCUMENTO_ADJUNTO] [uniqueidentifier] NOT NULL,
	[CODIGO_CONTRATO] [uniqueidentifier] NOT NULL,
	[CODIGO_ARCHIVO] [int] NOT NULL,
	[NOMBRE_ARCHIVO] [nvarchar](255) NOT NULL,
	[RUTA_ARCHIVO_SHAREPOINT] [nvarchar](max) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_CONTRATO_DOCUMENTO_ADJUNTO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONTRATO_DOCUMENTO_ADJUNTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION](
	[CODIGO_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION] [uniqueidentifier] NOT NULL,
	[CODIGO_CONTRATO] [uniqueidentifier] NOT NULL,
	[CODIGO_ARCHIVO] [int] NOT NULL,
	[NOMBRE_ARCHIVO] [nvarchar](255) NOT NULL,
	[RUTA_ARCHIVO_SHAREPOINT] [nvarchar](max) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONTRATO_ESTADIO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONTRATO_ESTADIO](
	[CODIGO_CONTRATO_ESTADIO] [uniqueidentifier] NOT NULL,
	[CODIGO_CONTRATO] [uniqueidentifier] NOT NULL,
	[CODIGO_FLUJO_APROBACION_ESTADIO] [uniqueidentifier] NOT NULL,
	[FECHA_INGRESO] [datetime] NOT NULL,
	[FECHA_FINALIZACION] [datetime] NULL,
	[CODIGO_RESPONSABLE] [uniqueidentifier] NULL,
	[CODIGO_ESTADO_CONTRATO_ESTADIO] [nvarchar](5) NOT NULL,
	[FECHA_PRIMERA_NOTIFICACION] [datetime] NULL,
	[FECHA_ULTIMA_NOTIFICACION] [datetime] NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
	[NOTIFICAR_USUARIO] [bit] NULL,
	[NTF_NIVEL_ESCALAMIENTO_1] [bit] NULL,
	[NTF_NIVEL_ESCALAMIENTO_2] [bit] NULL,
	[NTF_NIVEL_ESCALAMIENTO_3] [bit] NULL,
	[NTF_NIVEL_ESCALAMIENTO_4] [bit] NULL,
	[MOTIVO_APROBACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_CONTRATO_ESTADIO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONTRATO_ESTADIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONTRATO_ESTADIO_CONSULTA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONTRATO_ESTADIO_CONSULTA](
	[CODIGO_CONTRATO_ESTADIO_CONSULTA] [uniqueidentifier] NOT NULL,
	[CODIGO_CONTRATO_ESTADIO] [uniqueidentifier] NOT NULL,
	[DESCRIPCION] [nvarchar](max) NOT NULL,
	[FECHA_REGISTRO] [datetime] NOT NULL,
	[CODIGO_CONTRATO_PARRAFO] [uniqueidentifier] NULL,
	[DESTINATARIO] [uniqueidentifier] NOT NULL,
	[RESPUESTA] [nvarchar](max) NULL,
	[FECHA_RESPUESTA] [datetime] NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_CONTRATO_ESTADIO_CONSULTA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONTRATO_ESTADIO_CONSULTA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONTRATO_ESTADIO_OBSERVACION]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONTRATO_ESTADIO_OBSERVACION](
	[CODIGO_CONTRATO_ESTADIO_OBSERVACION] [uniqueidentifier] NOT NULL,
	[CODIGO_CONTRATO_ESTADIO] [uniqueidentifier] NOT NULL,
	[DESCRIPCION] [nvarchar](max) NOT NULL,
	[FECHA_REGISTRO] [datetime] NOT NULL,
	[CODIGO_CONTRATO_PARRAFO] [uniqueidentifier] NULL,
	[CODIGO_ARCHIVO] [int] NULL,
	[RUTA_ARCHIVO_SHAREPOINT] [nvarchar](max) NULL,
	[CODIGO_ESTADIO_RETORNO] [uniqueidentifier] NULL,
	[DESTINATARIO] [uniqueidentifier] NULL,
	[CODIGO_TIPO_RESPUESTA] [nvarchar](5) NULL,
	[RESPUESTA] [nvarchar](max) NULL,
	[FECHA_RESPUESTA] [datetime] NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_CONTRATO_ESTADIO_OBSERVACION] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONTRATO_ESTADIO_OBSERVACION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONTRATO_FIRMANTE]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONTRATO_FIRMANTE](
	[CODIGO_CONTRATO_FIRMANTE] [uniqueidentifier] NOT NULL,
	[CODIGO_CONTRATO_PARRAFO_VARIABLE] [uniqueidentifier] NOT NULL,
	[NOMBRE_FIRMANTE] [varchar](200) NULL,
	[DATO_ADICIONAL] [varchar](200) NULL,
	[ESTADO_REGISTRO] [char](10) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_CONTRATO_FIRMANTE] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONTRATO_FIRMANTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONTRATO_HITO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONTRATO_HITO](
	[CODIGO_CONTRATO_HITO] [uniqueidentifier] NOT NULL,
	[CODIGO_CONTRATO] [uniqueidentifier] NOT NULL,
	[CODIGO_TIPO_HITO] [nvarchar](255) NOT NULL,
	[DESCRIPCION] [nvarchar](5) NOT NULL,
	[FECHA_LIMITE] [datetime] NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_CONTRATO_HITO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONTRATO_HITO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONTRATO_PARRAFO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONTRATO_PARRAFO](
	[CODIGO_CONTRATO_PARRAFO] [uniqueidentifier] NOT NULL,
	[CODIGO_CONTRATO] [uniqueidentifier] NOT NULL,
	[CODIGO_PLANTILLA_PARRAFO] [uniqueidentifier] NOT NULL,
	[CONTENIDO] [nvarchar](max) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_CONTRATO_PARRAFO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONTRATO_PARRAFO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONTRATO_PARRAFO_VARIABLE]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONTRATO_PARRAFO_VARIABLE](
	[CODIGO_CONTRATO_PARRAFO_VARIABLE] [uniqueidentifier] NOT NULL,
	[CODIGO_CONTRATO_PARRAFO] [uniqueidentifier] NOT NULL,
	[CODIGO_VARIABLE] [uniqueidentifier] NOT NULL,
	[VALOR_TEXTO] [nvarchar](3000) NULL,
	[VALOR_NUMERO] [decimal](12, 2) NULL,
	[VALOR_FECHA] [datetime] NULL,
	[VALOR_IMAGEN] [varbinary](max) NULL,
	[VALOR_TABLA] [nvarchar](max) NULL,
	[VALOR_TABLA_EDITABLE] [nvarchar](max) NULL,
	[VALOR_BIEN] [nvarchar](max) NULL,
	[VALOR_BIEN_EDITABLE] [nvarchar](max) NULL,
	[VALOR_FIRMANTE] [nvarchar](max) NULL,
	[VALOR_FIRMANTE_EDITABLE] [nvarchar](max) NULL,
	[VALOR_LISTA] [uniqueidentifier] NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_CONTRATO_PARRAFO_VARIABLE] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONTRATO_PARRAFO_VARIABLE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[CONTRATO_PARRAFO_VARIABLE_CAMPO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[CONTRATO_PARRAFO_VARIABLE_CAMPO](
	[CODIGO_CONTRATO_PARRAFO_VARIABLE_CAMPO] [uniqueidentifier] NOT NULL,
	[CODIGO_CONTRATO_PARRAFO_VARIABLE] [uniqueidentifier] NOT NULL,
	[CODIGO_VARIABLE_CAMPO] [uniqueidentifier] NOT NULL,
	[NUMERO_FILA] [tinyint] NOT NULL,
	[VALOR] [nvarchar](3000) NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_CONTRATO_PARRAFO_VARIABLE_CAMPO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_CONTRATO_PARRAFO_VARIABLE_CAMPO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[EMPRESA_VINCULADA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[EMPRESA_VINCULADA](
	[CODIGO_EMPRESA_VINCULADA] [uniqueidentifier] NOT NULL,
	[NOMBRE_EMPRESA] [nvarchar](255) NOT NULL,
	[NUMERO_RUC] [nvarchar](20) NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_EMPRESA_VINCULADA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_EMPRESA_VINCULADA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[FLUJO_APROBACION]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[FLUJO_APROBACION](
	[CODIGO_FLUJO_APROBACION] [uniqueidentifier] NOT NULL,
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NOT NULL,
	[INDICADOR_APLICA_MONTO_MINIMO] [bit] NOT NULL,
	[CODIGO_PRIMER_FIRMANTE] [uniqueidentifier] NULL,
	[CODIGO_PRIMER_FIRMANTE_ORIGINAL] [uniqueidentifier] NULL,
	[CODIGO_SEGUNDO_FIRMANTE] [uniqueidentifier] NULL,
	[CODIGO_SEGUNDO_FIRMANTE_ORIGINAL] [uniqueidentifier] NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
	[CODIGO_PRIMER_FIRMANTE_VINCULADA] [uniqueidentifier] NULL,
	[CODIGO_SEGUNDO_FIRMANTE_VINCULADA] [uniqueidentifier] NULL,
 CONSTRAINT [PK_FLUJO_APROBACION] PRIMARY KEY CLUSTERED 
(
	[CODIGO_FLUJO_APROBACION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[FLUJO_APROBACION_ESTADIO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[FLUJO_APROBACION_ESTADIO](
	[CODIGO_FLUJO_APROBACION_ESTADIO] [uniqueidentifier] NOT NULL,
	[CODIGO_FLUJO_APROBACION] [uniqueidentifier] NOT NULL,
	[ORDEN] [tinyint] NOT NULL,
	[DESCRIPCION] [nvarchar](255) NOT NULL,
	[TIEMPO_ATENCION] [decimal](5, 2) NOT NULL,
	[HORAS_ATENCION] [decimal](5, 2) NULL,
	[INDICADOR_VERSION_OFICIAL] [bit] NOT NULL,
	[INDICADOR_PERMITE_CARGA] [bit] NOT NULL,
	[INDICADOR_NUMERO_CONTRATO] [bit] NOT NULL,
	[INDICADOR_INCLUIR_VISTO] [bit] NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
	[FLAG_REGISTRAR] [bit] NULL,
 CONSTRAINT [PK_FLUJO_APROBACION_ESTADIO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_FLUJO_APROBACION_ESTADIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[FLUJO_APROBACION_PARTICIPANTE]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[FLUJO_APROBACION_PARTICIPANTE](
	[CODIGO_FLUJO_APROBACION_PARTICIPANTE] [uniqueidentifier] NOT NULL,
	[CODIGO_FLUJO_APROBACION_ESTADIO] [uniqueidentifier] NOT NULL,
	[CODIGO_TRABAJADOR] [uniqueidentifier] NOT NULL,
	[CODIGO_TIPO_PARTICIPANTE] [char](1) NOT NULL,
	[CODIGO_TRABAJADOR_ORIGINAL] [uniqueidentifier] NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_FLUJO_APROBACION_PARTICIPANTE] PRIMARY KEY CLUSTERED 
(
	[CODIGO_FLUJO_APROBACION_PARTICIPANTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[FLUJO_APROBACION_TIPO_CONTRATO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[FLUJO_APROBACION_TIPO_CONTRATO](
	[CODIGO_FLUJO_APROBACION_TIPO_CONTRATO] [uniqueidentifier] NOT NULL,
	[CODIGO_FLUJO_APROBACION] [uniqueidentifier] NOT NULL,
	[CODIGO_TIPO_CONTRATO] [nvarchar](5) NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_FLUJO_APROBACION_CONTRATO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_FLUJO_APROBACION_TIPO_CONTRATO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[FLUJO_APROBACION_TIPO_SERVICIO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[FLUJO_APROBACION_TIPO_SERVICIO](
	[CODIGO_FLUJO_APROBACION_TIPO_SERVICIO] [uniqueidentifier] NOT NULL,
	[CODIGO_FLUJO_APROBACION] [uniqueidentifier] NOT NULL,
	[CODIGO_TIPO_SERVICIO] [nvarchar](5) NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_FLUJO_APROBACION_SERVICIO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_FLUJO_APROBACION_TIPO_SERVICIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[PLANTILLA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[PLANTILLA](
	[CODIGO_PLANTILLA] [uniqueidentifier] NOT NULL,
	[DESCRIPCION] [nvarchar](255) NOT NULL,
	[CODIGO_TIPO_CONTRATO] [nvarchar](5) NOT NULL,
	[CODIGO_TIPO_DOCUMENTO] [nvarchar](5) NOT NULL,
	[CODIGO_ESTADO] [nvarchar](5) NOT NULL,
	[INDICADOR_ADHESION] [bit] NOT NULL,
	[FECHA_INICIO_VIGENCIA] [datetime] NOT NULL,
	[FECHA_FIN_VIGENCIA] [datetime] NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
	[ES_MAYORMENOR] [bit] NULL,
 CONSTRAINT [PK_PLANTILLA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PLANTILLA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[PLANTILLA_NOTA_PIE]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[PLANTILLA_NOTA_PIE](
	[CODIGO_PLANTILLA_NOTA_PIE] [uniqueidentifier] NOT NULL,
	[CODIGO_PLANTILLA] [uniqueidentifier] NOT NULL,
	[ORDEN] [tinyint] NOT NULL,
	[TITULO] [nvarchar](255) NOT NULL,
	[CONTENIDO] [varchar](max) NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_PLANTILLA_NOTA_PIE] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PLANTILLA_NOTA_PIE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[PLANTILLA_PARRAFO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[PLANTILLA_PARRAFO](
	[CODIGO_PLANTILLA_PARRAFO] [uniqueidentifier] NOT NULL,
	[CODIGO_PLANTILLA] [uniqueidentifier] NOT NULL,
	[ORDEN] [tinyint] NOT NULL,
	[TITULO] [nvarchar](255) NOT NULL,
	[CONTENIDO] [varchar](max) NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_PLANTILLA_PARRAFO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PLANTILLA_PARRAFO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[PLANTILLA_PARRAFO_VARIABLE]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[PLANTILLA_PARRAFO_VARIABLE](
	[CODIGO_PLANTILLA_PARRAFO_VARIABLE] [uniqueidentifier] NOT NULL,
	[CODIGO_PLANTILLA_PARRAFO] [uniqueidentifier] NOT NULL,
	[CODIGO_VARIABLE] [uniqueidentifier] NOT NULL,
	[ORDEN] [smallint] NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_PANTILLA_PARRAFO_VARIABLE] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PLANTILLA_PARRAFO_VARIABLE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[PROVEEDOR]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[PROVEEDOR](
	[CODIGO_PROVEEDOR] [uniqueidentifier] NOT NULL,
	[CODIGO_IDENTIFICACION] [nvarchar](50) NOT NULL,
	[NOMBRE] [nvarchar](255) NOT NULL,
	[NOMBRE_COMERCIAL] [nvarchar](255) NOT NULL,
	[TIPO_DOCUMENTO] [nvarchar](5) NOT NULL,
	[NUMERO_DOCUMENTO] [nvarchar](20) NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_PROVEEDOR] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PROVEEDOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[PROVEEDOR_ACUMULADO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[PROVEEDOR_ACUMULADO](
	[CODIGO_PROVEEDOR_ACUMULADO] [uniqueidentifier] NOT NULL,
	[CODIGO_PROVEEDOR] [uniqueidentifier] NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
	[CODIGO_TIPO_ORDEN] [nvarchar](5) NOT NULL,
	[CODIGO_MONEDA] [char](3) NOT NULL,
	[MONTO_ACUMULADO] [decimal](18, 6) NOT NULL,
	[FECHA_INICIO] [datetime] NOT NULL,
	[FECHA_FIN] [datetime] NULL,
	[INDICADOR_LIMITE_ALCANZADO] [bit] NOT NULL,
	[INDICADOR_NOTIFICADO] [bit] NOT NULL,
 CONSTRAINT [PK_PROVEEDOR_ACUMULADO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PROVEEDOR_ACUMULADO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[VARIABLE]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[VARIABLE](
	[CODIGO_VARIABLE] [uniqueidentifier] NOT NULL,
	[IDENTIFICADOR] [nvarchar](255) NOT NULL,
	[NOMBRE] [nvarchar](255) NOT NULL,
	[INDICADOR_VARIABLE_SISTEMA] [bit] NOT NULL,
	[CODIGO_TIPO] [nvarchar](5) NOT NULL,
	[INDICADOR_GLOBAL] [bit] NOT NULL,
	[CODIGO_PLANTILLA] [uniqueidentifier] NULL,
	[DESCRIPCION] [nvarchar](255) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_VARIABLE] PRIMARY KEY CLUSTERED 
(
	[CODIGO_VARIABLE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[VARIABLE_CAMPO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[VARIABLE_CAMPO](
	[CODIGO_VARIABLE_CAMPO] [uniqueidentifier] NOT NULL,
	[CODIGO_VARIABLE] [uniqueidentifier] NOT NULL,
	[NOMBRE] [nvarchar](255) NOT NULL,
	[ORDEN] [tinyint] NOT NULL,
	[TIPO_ALINEAMIENTO] [nvarchar](50) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
	[TAMANIO] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_VARIABLE_CAMPO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_VARIABLE_CAMPO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [CTR].[VARIABLE_LISTA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [CTR].[VARIABLE_LISTA](
	[CODIGO_VARIABLE_LISTA] [uniqueidentifier] NOT NULL,
	[CODIGO_VARIABLE] [uniqueidentifier] NULL,
	[NOMBRE] [nvarchar](255) NULL,
	[DESCRIPCION] [nvarchar](max) NULL,
	[ESTADO_REGISTRO] [char](1) NULL,
	[USUARIO_CREACION] [nvarchar](50) NULL,
	[FECHA_CREACION] [datetime] NULL,
	[TERMINAL_CREACION] [nvarchar](50) NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_VARIABLE_LISTA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_VARIABLE_LISTA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TMPCONTRATO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TMPCONTRATO](
	[CODIGO_CONTRATO_DOCUMENTO] [uniqueidentifier] NOT NULL,
	[CODIGO_CONTRATO] [uniqueidentifier] NOT NULL,
	[CODIGO_ARCHIVO] [int] NOT NULL,
	[RUTA_ARCHIVO_SHAREPOINT] [nvarchar](max) NULL,
	[CONTENIDO] [nvarchar](max) NULL,
	[CONTENIDO_BUSQUEDA] [nvarchar](max) NULL,
	[INDICADOR_ACTUAL] [bit] NOT NULL,
	[VERSION] [tinyint] NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[DEPARTAMENTO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[DEPARTAMENTO](
	[CODIGO_DEPARTAMENTO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_PAIS] [int] NOT NULL,
	[CODIGO_UBIGEO] [nvarchar](max) NULL,
	[NOMBRE] [nvarchar](max) NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.DEPARTAMENTO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_DEPARTAMENTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[DISTRITO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[DISTRITO](
	[CODIGO_DISTRITO] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_PROVINCIA] [int] NOT NULL,
	[CODIGO_UBIGEO] [nvarchar](max) NULL,
	[NOMBRE] [nvarchar](max) NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.DISTRITO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_DISTRITO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[PAIS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[PAIS](
	[CODIGO_PAIS] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](max) NULL,
	[CODIGO_SECUNDARIO] [int] NOT NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.PAIS] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PAIS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[PARAMETRO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[PARAMETRO](
	[CODIGO_PARAMETRO] [int] NOT NULL,
	[CODIGO_EMPRESA] [uniqueidentifier] NOT NULL,
	[CODIGO_SISTEMA] [uniqueidentifier] NULL,
	[CODIGO_IDENTIFICADOR] [nvarchar](max) NULL,
	[NOMBRE] [nvarchar](max) NULL,
	[DESCRIPCION] [nvarchar](max) NULL,
	[INDICADOR_PERMITE_AGREGAR] [bit] NOT NULL,
	[INDICADOR_PERMITE_MODIFICAR] [bit] NOT NULL,
	[INDICADOR_PERMITE_ELIMINAR] [bit] NOT NULL,
	[TIPO_PARAMETRO] [nvarchar](max) NULL,
	[INDICADOR_EMPRESA] [bit] NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.PARAMETRO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PARAMETRO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[PARAMETRO_SECCION]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[PARAMETRO_SECCION](
	[CODIGO_PARAMETRO] [int] NOT NULL,
	[CODIGO_SECCION] [int] NOT NULL,
	[NOMBRE] [nvarchar](max) NULL,
	[CODIGO_TIPO_DATO] [nvarchar](max) NULL,
	[INDICADOR_PERMITE_MODIFICAR] [bit] NOT NULL,
	[INDICADOR_OBLIGATORIO] [bit] NOT NULL,
	[INDICADOR_SISTEMA] [bit] NOT NULL,
	[CODIGO_PARAMETRO_RELACIONADO] [int] NULL,
	[CODIGO_SECCION_RELACIONADO] [int] NULL,
	[CODIGO_SECCION_RELACIONADO_MOSTRAR] [int] NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.PARAMETRO_SECCION] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PARAMETRO] ASC,
	[CODIGO_SECCION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[PARAMETRO_VALOR]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[PARAMETRO_VALOR](
	[CODIGO_PARAMETRO] [int] NOT NULL,
	[CODIGO_SECCION] [int] NOT NULL,
	[CODIGO_VALOR] [int] NOT NULL,
	[VALOR] [nvarchar](max) NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.PARAMETRO_VALOR] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PARAMETRO] ASC,
	[CODIGO_SECCION] ASC,
	[CODIGO_VALOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[PLANTILLA_NOTIFICACION]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[PLANTILLA_NOTIFICACION](
	[CODIGO_PLANTILLA_NOTIFICACION] [uniqueidentifier] NOT NULL,
	[CODIGO_SISTEMA] [uniqueidentifier] NOT NULL,
	[CODIGO_TIPO_NOTIFICACION] [nvarchar](max) NULL,
	[ASUNTO] [nvarchar](max) NULL,
	[INDICADOR_ACTIVA] [bit] NOT NULL,
	[CONTENIDO] [nvarchar](max) NULL,
	[CODIGO_TIPO_DESTINATARIO] [nvarchar](max) NULL,
	[DESTINATARIO] [nvarchar](max) NULL,
	[DESTINATARIO_COPIA] [nvarchar](max) NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.PLANTILLA_NOTIFICACION] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PLANTILLA_NOTIFICACION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[PROVINCIA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[PROVINCIA](
	[CODIGO_PROVINCIA] [int] IDENTITY(1,1) NOT NULL,
	[CODIGO_DEPARTAMENTO] [int] NOT NULL,
	[CODIGO_UBIGEO] [nvarchar](max) NULL,
	[NOMBRE] [nvarchar](max) NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.PROVINCIA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PROVINCIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[SISTEMA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[SISTEMA](
	[CODIGO_SISTEMA] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](max) NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.SISTEMA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_SISTEMA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[TRABAJADOR]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[TRABAJADOR](
	[CODIGO_TRABAJADOR] [uniqueidentifier] NOT NULL,
	[CODIGO_IDENTIFICACION] [nvarchar](max) NULL,
	[CODIGO_TIPO_DOCUMENTO_IDENTIDAD] [nvarchar](max) NULL,
	[NUMERO_DOCUMENTO_IDENTIDAD] [nvarchar](max) NULL,
	[APELLIDO_PATERNO] [nvarchar](max) NULL,
	[APELLIDO_MATERNO] [nvarchar](max) NULL,
	[NOMBRES] [nvarchar](max) NULL,
	[NOMBRE_COMPLETO] [nvarchar](max) NULL,
	[ORGANIZACION] [nvarchar](max) NULL,
	[DEPARTAMENTO] [nvarchar](max) NULL,
	[CARGO] [nvarchar](max) NULL,
	[TELEFONO_TRABAJO] [nvarchar](max) NULL,
	[ANEXO] [nvarchar](max) NULL,
	[TELEFONO_MOVIL] [nvarchar](max) NULL,
	[TELEFONO_PERSONAL] [nvarchar](max) NULL,
	[CORREO_ELECTRONICO] [nvarchar](max) NULL,
	[DOMINIO] [nvarchar](max) NULL,
	[INDICADOR_TIENE_FOTO] [bit] NOT NULL,
	[INDICADOR_TODA_UNIDAD_OPERATIVA] [bit] NOT NULL,
	[CODIGO_UNIDAD_OPERATIVA_MATRIZ] [uniqueidentifier] NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.TRABAJADOR] PRIMARY KEY CLUSTERED 
(
	[CODIGO_TRABAJADOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[TRABAJADOR_FIRMA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[TRABAJADOR_FIRMA](
	[CODIGO_FIRMA] [uniqueidentifier] NOT NULL,
	[CODIGO_TRABAJADOR] [uniqueidentifier] NULL,
	[FIRMA_TRABAJADOR] [varbinary](max) NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.TRABAJADOR_FIRMA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_FIRMA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[TRABAJADOR_SUPLENTE]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[TRABAJADOR_SUPLENTE](
	[CODIGO_TRABAJADOR] [uniqueidentifier] NOT NULL,
	[CODIGO_SUPLENTE] [uniqueidentifier] NULL,
	[FECHA_INICIO] [datetime] NOT NULL,
	[FECHA_FIN] [datetime] NOT NULL,
	[ACTIVO] [bit] NOT NULL,
	[EJECUTADO] [bit] NULL,
	[PERFILES_AGREGADOS] [nvarchar](max) NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.TRABAJADOR_SUPLENTE] PRIMARY KEY CLUSTERED 
(
	[CODIGO_TRABAJADOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[TRABAJADOR_UNIDAD_OPERATIVA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[TRABAJADOR_UNIDAD_OPERATIVA](
	[CODIGO_TRABAJADOR_UNIDAD_OPERATIVA] [uniqueidentifier] NOT NULL,
	[CODIGO_UNIDAD_OPERATIVA_MATRIZ] [uniqueidentifier] NOT NULL,
	[CODIGO_TRABAJADOR] [uniqueidentifier] NULL,
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.TRABAJADOR_UNIDAD_OPERATIVA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_TRABAJADOR_UNIDAD_OPERATIVA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[UNIDAD_OPERATIVA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[UNIDAD_OPERATIVA](
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NOT NULL,
	[CODIGO_IDENTIFICACION] [nvarchar](max) NULL,
	[NOMBRE] [nvarchar](max) NULL,
	[INDICADOR_ACTIVA] [bit] NULL,
	[CODIGO_NIVEL_JERARQUIA] [nvarchar](max) NULL,
	[CODIGO_UNIDAD_OPERATIVA_PADRE] [uniqueidentifier] NULL,
	[CODIGO_TIPO_UNIDAD_OPERATIVA] [nvarchar](max) NULL,
	[CODIGO_RESPONSABLE] [uniqueidentifier] NULL,
	[CODIGO_PRIMER_REPRESENTANTE] [uniqueidentifier] NULL,
	[CODIGO_SEGUNDO_REPRESENTANTE] [uniqueidentifier] NULL,
	[CODIGO_TERCER_REPRESENTANTE] [uniqueidentifier] NULL,
	[CODIGO_CUARTO_REPRESENTANTE] [uniqueidentifier] NULL,
	[DIRECCION] [nvarchar](max) NULL,
	[CODIGO_ZONA_HORARIA] [uniqueidentifier] NULL,
	[CODIGO_PRIMER_REPRESENTANTE_ORIGINAL] [uniqueidentifier] NULL,
	[CODIGO_SEGUNDO_REPRESENTANTE_ORIGINAL] [uniqueidentifier] NULL,
	[CODIGO_TERCER_REPRESENTANTE_ORIGINAL] [uniqueidentifier] NULL,
	[CODIGO_CUARTO_REPRESENTANTE_ORIGINAL] [uniqueidentifier] NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
	[LOGO_UNIDAD_OPERATIVA] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.UNIDAD_OPERATIVA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_UNIDAD_OPERATIVA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[UNIDAD_OPERATIVA_STAFF]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[UNIDAD_OPERATIVA_STAFF](
	[CODIGO_UNIDAD_OPERATIVA_STAFF] [uniqueidentifier] NOT NULL,
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NULL,
	[CODIGO_SISTEMA] [uniqueidentifier] NULL,
	[CODIGO_TRABAJADOR] [uniqueidentifier] NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.UNIDAD_OPERATIVA_STAFF] PRIMARY KEY CLUSTERED 
(
	[CODIGO_UNIDAD_OPERATIVA_STAFF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[UNIDAD_OPERATIVA_USUARIO_CONSULTA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[UNIDAD_OPERATIVA_USUARIO_CONSULTA](
	[CODIGO_UNIDAD_OPERATIVA_USUARIO_CONSULTA] [uniqueidentifier] NOT NULL,
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NULL,
	[CODIGO_TRABAJADOR] [uniqueidentifier] NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.UNIDAD_OPERATIVA_USUARIO_CONSULTA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_UNIDAD_OPERATIVA_USUARIO_CONSULTA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [GRL].[ZONA_HORARIA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GRL].[ZONA_HORARIA](
	[CODIGO_ZONA_HORARIA] [int] IDENTITY(1,1) NOT NULL,
	[HORA_UTC] [smallint] NOT NULL,
	[MINUTO_UTC] [smallint] NOT NULL,
	[DESCRIPCION] [nvarchar](max) NULL,
	[ESTADO_REGISTRO] [nvarchar](max) NULL,
	[USUARIO_CREACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](max) NULL,
	[USUARIO_MODIFICACION] [nvarchar](max) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](max) NULL,
 CONSTRAINT [PK_GRL.ZONA_HORARIA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_ZONA_HORARIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [HST].[BIEN_REGISTRO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [HST].[BIEN_REGISTRO](
	[CODIGO_BIEN_REGISTRO] [uniqueidentifier] NOT NULL,
	[CODIGO_TIPO_CONTENIDO] [char](3) NOT NULL,
	[CONTENIDO] [nvarchar](255) NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_BIEN_REGISTRO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_BIEN_REGISTRO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TMP].[ACUMULADO_PROVEEDOR]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TMP].[ACUMULADO_PROVEEDOR](
	[RUC_PROVEEDOR] [nvarchar](20) NULL,
	[CODIGO_TIPO_ORDEN] [nvarchar](1) NULL,
	[CODIGO_MONEDA] [nvarchar](3) NULL,
	[MONTO_PROVEEDOR] [decimal](18, 2) NULL,
	[FECHA_CREACION] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [TMP].[ADENDAS_CONTRATO_VENCIDO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TMP].[ADENDAS_CONTRATO_VENCIDO](
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NULL,
	[NUMERO_CONTRATO] [nvarchar](50) NULL,
	[DESCRIPCION] [nvarchar](255) NULL,
	[NUMERO_ADENDA] [int] NULL,
	[NUMERO_ADENDA_CONCATENADO] [nvarchar](100) NULL,
	[FECHA_CREACION] [datetime] NULL,
	[ESTADO_ENVIO] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [TMP].[CONTRATO_POR_VENCER]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TMP].[CONTRATO_POR_VENCER](
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NULL,
	[NOMBRE] [nvarchar](500) NULL,
	[NUMERO_CONTRATO] [nvarchar](100) NULL,
	[NUMERO_DOCUMENTO] [nvarchar](100) NULL,
	[PROVEEDOR] [nvarchar](500) NULL,
	[FECHA_VENCIMIENTO] [datetime] NULL,
	[CONTENIDO] [nvarchar](max) NULL,
	[EMISOR] [nvarchar](500) NULL,
	[ASUNTO] [nvarchar](max) NULL,
	[DESTINATARIO] [nvarchar](max) NULL,
	[DESTINATARIO_COPIA] [nvarchar](max) NULL,
	[DIAS_VENCIMIENTO] [int] NULL,
	[DIAS_LIMITE] [int] NULL,
	[NUMERO_ADENDA_CONCATENADO] [nvarchar](80) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [TMP].[CONTRATOS_INFORMADOS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TMP].[CONTRATOS_INFORMADOS](
	[CODIGO_FLUJO_APROBACION_ESTADIO] [nvarchar](50) NULL,
	[CODIGO_INFORMADO] [nvarchar](50) NULL,
	[NOMBRE_INFORMADO] [nvarchar](255) NULL,
	[CORREO_INFORMADO] [nvarchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [TMP].[CONTRATOS_NOTIFICAR]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TMP].[CONTRATOS_NOTIFICAR](
	[ROW_ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_PROVEEDOR] [nvarchar](255) NULL,
	[NOMBRE_ORDEN] [nvarchar](255) NULL,
	[NOMBRE_MONEDA] [nvarchar](255) NULL,
	[MONTO_CONTRATO] [decimal](18, 6) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [TMP].[CONTRATOS_RETRASADOS]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TMP].[CONTRATOS_RETRASADOS](
	[CODIGO_FLUJO_APROBACION_ESTADIO] [nvarchar](50) NULL,
	[CODIGO_CONTRATO_ESTADIO] [nvarchar](50) NULL,
	[NUMERO_CONTRATO] [nvarchar](50) NULL,
	[NOMBRE_PROVEEDOR] [nvarchar](255) NULL,
	[NOMBRE_RESPONSABLE] [nvarchar](100) NULL,
	[NOMBRE_UNIDAD_OPERATIVA] [nvarchar](255) NULL,
	[CORREO_RESPONSABLE] [nvarchar](100) NULL,
	[ASUNTO] [nvarchar](255) NULL,
	[CONTENIDO] [nvarchar](1000) NULL,
	[URL_SISTEMA] [nvarchar](255) NULL,
	[PROFILE_CORREO] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [TMP].[INFORMACION_ENVIAR_CORREO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TMP].[INFORMACION_ENVIAR_CORREO](
	[ROW_ID] [int] IDENTITY(1,1) NOT NULL,
	[INFORMACION] [nvarchar](max) NULL,
	[FECHA_CREACION] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [TMP].[LISTA_CORREO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TMP].[LISTA_CORREO](
	[CODIGO_TRABAJADOR] [uniqueidentifier] NULL,
	[CODIGO_CONTRATO] [uniqueidentifier] NULL,
	[NOMBRE_COMPLETO] [nvarchar](255) NULL,
	[CORREO_ELECTRONICO] [nvarchar](255) NULL,
	[EMISOR] [nvarchar](255) NULL,
	[ASUNTO] [nvarchar](255) NULL,
	[CONTENIDO] [nvarchar](max) NULL,
	[NUMERO_CONTRATO] [nvarchar](50) NULL,
	[CODIGO_CONTRATO_ESTADIO] [uniqueidentifier] NOT NULL,
	[DIRECCION_SISTEMA] [nvarchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [TMP].[LISTA_CORREO_ESCALAMIENTO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TMP].[LISTA_CORREO_ESCALAMIENTO](
	[CODIGO_CONTRATO] [uniqueidentifier] NULL,
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NULL,
	[CODIGO_RESPONSABLE] [uniqueidentifier] NULL,
	[CODIGO_TRABAJADOR_1] [uniqueidentifier] NULL,
	[CODIGO_TRABAJADOR_2] [uniqueidentifier] NULL,
	[CODIGO_TRABAJADOR_3] [uniqueidentifier] NULL,
	[CODIGO_TRABAJADOR_4] [uniqueidentifier] NULL,
	[NOMBRE_RESPONSABLE] [nvarchar](255) NULL,
	[NOMBRE_COMPLETO_1] [nvarchar](255) NULL,
	[NOMBRE_COMPLETO_2] [nvarchar](255) NULL,
	[NOMBRE_COMPLETO_3] [nvarchar](255) NULL,
	[NOMBRE_COMPLETO_4] [nvarchar](255) NULL,
	[CORREO_ELECTRONICO_1] [nvarchar](255) NULL,
	[CORREO_ELECTRONICO_2] [nvarchar](255) NULL,
	[CORREO_ELECTRONICO_3] [nvarchar](255) NULL,
	[CORREO_ELECTRONICO_4] [nvarchar](255) NULL,
	[FECHA_VENCIMIENTO] [datetime] NULL,
	[FECHA_NTF_ESCALAMIENTO_1] [datetime] NULL,
	[FECHA_NTF_ESCALAMIENTO_2] [datetime] NULL,
	[FECHA_NTF_ESCALAMIENTO_3] [datetime] NULL,
	[FECHA_NTF_ESCALAMIENTO_4] [datetime] NULL,
	[ASUNTO] [nvarchar](255) NULL,
	[CONTENIDO] [nvarchar](max) NULL,
	[NUMERO_CONTRATO] [nvarchar](50) NULL,
	[CODIGO_CONTRATO_ESTADIO] [uniqueidentifier] NOT NULL,
	[DIRECCION_SISTEMA] [nvarchar](255) NULL,
	[EMISOR] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [TMP].[LISTA_CORREO_ESCALAMIENTO_TEMP]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TMP].[LISTA_CORREO_ESCALAMIENTO_TEMP](
	[CODIGO_CONTRATO] [uniqueidentifier] NULL,
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NULL,
	[CODIGO_RESPONSABLE] [uniqueidentifier] NULL,
	[CODIGO_TRABAJADOR_1] [uniqueidentifier] NULL,
	[CODIGO_TRABAJADOR_2] [uniqueidentifier] NULL,
	[CODIGO_TRABAJADOR_3] [uniqueidentifier] NULL,
	[CODIGO_TRABAJADOR_4] [uniqueidentifier] NULL,
	[NOMBRE_RESPONSABLE] [nvarchar](255) NULL,
	[NOMBRE_COMPLETO_1] [nvarchar](255) NULL,
	[NOMBRE_COMPLETO_2] [nvarchar](255) NULL,
	[NOMBRE_COMPLETO_3] [nvarchar](255) NULL,
	[NOMBRE_COMPLETO_4] [nvarchar](255) NULL,
	[CORREO_ELECTRONICO_1] [nvarchar](255) NULL,
	[CORREO_ELECTRONICO_2] [nvarchar](255) NULL,
	[CORREO_ELECTRONICO_3] [nvarchar](255) NULL,
	[CORREO_ELECTRONICO_4] [nvarchar](255) NULL,
	[FECHA_VENCIMIENTO] [datetime] NULL,
	[FECHA_NTF_ESCALAMIENTO_1] [datetime] NULL,
	[FECHA_NTF_ESCALAMIENTO_2] [datetime] NULL,
	[FECHA_NTF_ESCALAMIENTO_3] [datetime] NULL,
	[FECHA_NTF_ESCALAMIENTO_4] [datetime] NULL,
	[ASUNTO] [nvarchar](255) NULL,
	[CONTENIDO] [nvarchar](max) NULL,
	[NUMERO_CONTRATO] [nvarchar](50) NULL,
	[CODIGO_CONTRATO_ESTADIO] [uniqueidentifier] NOT NULL,
	[DIRECCION_SISTEMA] [nvarchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [TMP].[MONTO_ACUMULADO_CONTRATO]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TMP].[MONTO_ACUMULADO_CONTRATO](
	[CODIGO_MONEDA] [nvarchar](3) NULL,
	[MONTO_CONTRATO] [decimal](18, 2) NULL,
	[FECHA_CREACION] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [TMP].[PROVEEDOR_ORDENES_COMPRA]    Script Date: 25/02/2020 17:59:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TMP].[PROVEEDOR_ORDENES_COMPRA](
	[RUC_PROVEEDOR] [nvarchar](20) NULL,
	[CODIGO_TIPO_ORDEN] [char](1) NULL,
	[NUMERO_ORDEN] [nvarchar](20) NULL,
	[FECHA_ORDEN] [nvarchar](10) NULL,
	[CODIGOMONEDA] [nvarchar](3) NULL,
	[MONTO] [decimal](18, 2) NULL,
	[FECHA_CREACION] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_BIEN_CODIGO_IDENTIFICACION]    Script Date: 25/02/2020 17:59:11 ******/
CREATE NONCLUSTERED INDEX [IX_BIEN_CODIGO_IDENTIFICACION] ON [CTR].[BIEN]
(
	[CODIGO_IDENTIFICACION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_BIEN_MODELO_SERIE]    Script Date: 25/02/2020 17:59:11 ******/
CREATE NONCLUSTERED INDEX [IX_BIEN_MODELO_SERIE] ON [CTR].[BIEN]
(
	[MODELO] ASC,
	[NUMERO_SERIE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IND_CONTRATO_DOCUMENTO]    Script Date: 25/02/2020 17:59:11 ******/
CREATE NONCLUSTERED INDEX [IND_CONTRATO_DOCUMENTO] ON [CTR].[CONTRATO_DOCUMENTO]
(
	[CODIGO_CONTRATO] ASC,
	[INDICADOR_ACTUAL] ASC,
	[ESTADO_REGISTRO] ASC
)
INCLUDE ( 	[CONTENIDO_BUSQUEDA]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IND_CONTRATO_ESTADIO]    Script Date: 25/02/2020 17:59:11 ******/
CREATE NONCLUSTERED INDEX [IND_CONTRATO_ESTADIO] ON [CTR].[CONTRATO_ESTADIO]
(
	[CODIGO_ESTADO_CONTRATO_ESTADIO] ASC
)
INCLUDE ( 	[CODIGO_CONTRATO],
	[CODIGO_FLUJO_APROBACION_ESTADIO],
	[FECHA_CREACION]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IND_CTR_CONTRATO_PARRAFO]    Script Date: 25/02/2020 17:59:11 ******/
CREATE NONCLUSTERED INDEX [IND_CTR_CONTRATO_PARRAFO] ON [CTR].[CONTRATO_PARRAFO]
(
	[CODIGO_CONTRATO] ASC,
	[ESTADO_REGISTRO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IND_CTR_CONTRATO_PARRAFO_VARIABLE]    Script Date: 25/02/2020 17:59:11 ******/
CREATE NONCLUSTERED INDEX [IND_CTR_CONTRATO_PARRAFO_VARIABLE] ON [CTR].[CONTRATO_PARRAFO_VARIABLE]
(
	[CODIGO_CONTRATO_PARRAFO] ASC
)
INCLUDE ( 	[CODIGO_CONTRATO_PARRAFO_VARIABLE],
	[CODIGO_VARIABLE],
	[VALOR_TEXTO],
	[VALOR_NUMERO],
	[VALOR_FECHA],
	[VALOR_IMAGEN],
	[VALOR_TABLA],
	[VALOR_TABLA_EDITABLE],
	[VALOR_BIEN],
	[VALOR_BIEN_EDITABLE],
	[VALOR_FIRMANTE],
	[VALOR_FIRMANTE_EDITABLE],
	[VALOR_LISTA],
	[ESTADO_REGISTRO]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IND_FLUJO_APROBACION_PARTICIPANTE]    Script Date: 25/02/2020 17:59:11 ******/
CREATE NONCLUSTERED INDEX [IND_FLUJO_APROBACION_PARTICIPANTE] ON [CTR].[FLUJO_APROBACION_PARTICIPANTE]
(
	[CODIGO_TIPO_PARTICIPANTE] ASC,
	[ESTADO_REGISTRO] ASC
)
INCLUDE ( 	[CODIGO_FLUJO_APROBACION_ESTADIO],
	[CODIGO_TRABAJADOR]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IND_CTR_PLANTILLA_PARRAFO]    Script Date: 25/02/2020 17:59:11 ******/
CREATE NONCLUSTERED INDEX [IND_CTR_PLANTILLA_PARRAFO] ON [CTR].[PLANTILLA_PARRAFO]
(
	[CODIGO_PLANTILLA] ASC,
	[ESTADO_REGISTRO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IND_CTR_PLANTILLA_PARRAFO_VARIABLE]    Script Date: 25/02/2020 17:59:11 ******/
CREATE NONCLUSTERED INDEX [IND_CTR_PLANTILLA_PARRAFO_VARIABLE] ON [CTR].[PLANTILLA_PARRAFO_VARIABLE]
(
	[CODIGO_PLANTILLA_PARRAFO] ASC,
	[ESTADO_REGISTRO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
GO
ALTER TABLE [CTR].[AUDITORIA] ADD  CONSTRAINT [DF__AUDITORIA__ESTAD__19DFD96B]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[BIEN] ADD  CONSTRAINT [DF__BIEN__CODIGO_TIP__38A457AD]  DEFAULT ('EQP') FOR [CODIGO_TIPO_BIEN]
GO
ALTER TABLE [CTR].[BIEN] ADD  CONSTRAINT [DF__BIEN__TIEMPO_VID__39987BE6]  DEFAULT ((0)) FOR [TIEMPO_VIDA]
GO
ALTER TABLE [CTR].[BIEN] ADD  CONSTRAINT [DF__BIEN__VALOR_RESI__3A8CA01F]  DEFAULT ((0)) FOR [VALOR_RESIDUAL]
GO
ALTER TABLE [CTR].[BIEN] ADD  CONSTRAINT [DF__BIEN__CODIGO_TIP__3B80C458]  DEFAULT ('F') FOR [CODIGO_TIPO_TARIFA]
GO
ALTER TABLE [CTR].[BIEN] ADD  CONSTRAINT [DF__BIEN__CODIGO_MON__3C74E891]  DEFAULT ('USD') FOR [CODIGO_MONEDA]
GO
ALTER TABLE [CTR].[BIEN] ADD  CONSTRAINT [DF__BIEN__ESTADO_REG__3D690CCA]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[BIEN_ALQUILER] ADD  CONSTRAINT [DF__BIEN_ALQU__INDIC__41399DAE]  DEFAULT ((0)) FOR [INDICADOR_SIN_LIMITE]
GO
ALTER TABLE [CTR].[BIEN_ALQUILER] ADD  CONSTRAINT [DF__BIEN_ALQU__ESTAD__422DC1E7]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[BIEN_ALQUILER] ADD  CONSTRAINT [DF__BIEN_ALQU__MONTO__4321E620]  DEFAULT ((0)) FOR [MONTO]
GO
ALTER TABLE [CTR].[CONTRATO] ADD  CONSTRAINT [DF__CONTRATO__CODIGO__1F98B2C1]  DEFAULT ('C') FOR [CODIGO_TIPO_DOCUMENTO]
GO
ALTER TABLE [CTR].[CONTRATO] ADD  CONSTRAINT [DF__CONTRATO__FECHA___208CD6FA]  DEFAULT (getdate()) FOR [FECHA_INICIO_VIGENCIA]
GO
ALTER TABLE [CTR].[CONTRATO] ADD  CONSTRAINT [DF__CONTRATO__CODIGO__2180FB33]  DEFAULT ('USD') FOR [CODIGO_MONEDA]
GO
ALTER TABLE [CTR].[CONTRATO] ADD  CONSTRAINT [DF__CONTRATO__MONTO___22751F6C]  DEFAULT ((0)) FOR [MONTO_CONTRATO]
GO
ALTER TABLE [CTR].[CONTRATO] ADD  CONSTRAINT [DF_CONTRATO_MONTO_ACUMULADO]  DEFAULT ((0)) FOR [MONTO_ACUMULADO]
GO
ALTER TABLE [CTR].[CONTRATO] ADD  CONSTRAINT [DF__CONTRATO__CODIGO__236943A5]  DEFAULT ('C') FOR [CODIGO_ESTADO]
GO
ALTER TABLE [CTR].[CONTRATO] ADD  CONSTRAINT [DF__CONTRATO__ESTADO__245D67DE]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[CONTRATO_BIEN] ADD  CONSTRAINT [DF__CONTRATO___ESTAD__2645B050]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[CONTRATO_DOCUMENTO] ADD  CONSTRAINT [DF__CONTRATO___INDIC__282DF8C2]  DEFAULT ((1)) FOR [INDICADOR_ACTUAL]
GO
ALTER TABLE [CTR].[CONTRATO_DOCUMENTO] ADD  CONSTRAINT [DF__CONTRATO___VERSI__29221CFB]  DEFAULT ((1)) FOR [VERSION]
GO
ALTER TABLE [CTR].[CONTRATO_DOCUMENTO] ADD  CONSTRAINT [DF__CONTRATO___ESTAD__2A164134]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[CONTRATO_DOCUMENTO_ADJUNTO] ADD  CONSTRAINT [DF__CONTRATO__AD_ESTAD__2A164134]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION] ADD  CONSTRAINT [DF__CONTRATO__RESOLUCION]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[CONTRATO_ESTADIO] ADD  CONSTRAINT [DF_CONTRATO_ESTADIO_CODIGO_ESTADO_CONTRATO_ESTADIO]  DEFAULT ('I') FOR [CODIGO_ESTADO_CONTRATO_ESTADIO]
GO
ALTER TABLE [CTR].[CONTRATO_ESTADIO] ADD  CONSTRAINT [DF__CONTRATO___ESTAD__2BFE89A6]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[CONTRATO_ESTADIO_CONSULTA] ADD  CONSTRAINT [DF__CONTRATO___ESTAD__2DE6D218]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[CONTRATO_ESTADIO_OBSERVACION] ADD  CONSTRAINT [DF__CONTRATO___ESTAD__2FCF1A8A]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[CONTRATO_HITO] ADD  CONSTRAINT [DF__CONTRATO___ESTAD__31B762FC]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO] ADD  CONSTRAINT [DF__CONTRATO___ESTAD__339FAB6E]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO_VARIABLE] ADD  CONSTRAINT [DF__CONTRATO___ESTAD__3587F3E0]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO_VARIABLE_CAMPO] ADD  CONSTRAINT [DF__CONTRATO___ESTAD__37703C52]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[FLUJO_APROBACION] ADD  CONSTRAINT [DF_FLUJO_APROBACION_INDICADOR_APLICA_MONTO_MINIMO]  DEFAULT ((0)) FOR [INDICADOR_APLICA_MONTO_MINIMO]
GO
ALTER TABLE [CTR].[FLUJO_APROBACION] ADD  CONSTRAINT [DF__FLUJO_APR__ESTAD__395884C4]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[FLUJO_APROBACION_ESTADIO] ADD  CONSTRAINT [DF__FLUJO_APR__TIEMP__3B40CD36]  DEFAULT ((1)) FOR [TIEMPO_ATENCION]
GO
ALTER TABLE [CTR].[FLUJO_APROBACION_ESTADIO] ADD  CONSTRAINT [DF_FLUJO_APROBACION_ESTADIO_INDICADOR_VERSION_OFICIAL]  DEFAULT ((0)) FOR [INDICADOR_VERSION_OFICIAL]
GO
ALTER TABLE [CTR].[FLUJO_APROBACION_ESTADIO] ADD  CONSTRAINT [DF_FLUJO_APROBACION_ESTADIO_INDICADOR_PERMITE_CARGA]  DEFAULT ((0)) FOR [INDICADOR_PERMITE_CARGA]
GO
ALTER TABLE [CTR].[FLUJO_APROBACION_ESTADIO] ADD  CONSTRAINT [DF_FLUJO_APROBACION_ESTADIO_INDICADOR_NUMERO_CONTRATO]  DEFAULT ((0)) FOR [INDICADOR_NUMERO_CONTRATO]
GO
ALTER TABLE [CTR].[FLUJO_APROBACION_ESTADIO] ADD  CONSTRAINT [DF__FLUJO_APR__ESTAD__3D2915A8]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[FLUJO_APROBACION_PARTICIPANTE] ADD  CONSTRAINT [DF__FLUJO_APR__ESTAD__3F115E1A]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[PLANTILLA] ADD  CONSTRAINT [DF__PLANTILLA__CODIG__44CA3770]  DEFAULT ('C') FOR [CODIGO_TIPO_DOCUMENTO]
GO
ALTER TABLE [CTR].[PLANTILLA] ADD  CONSTRAINT [DF__PLANTILLA__CODIG__45BE5BA9]  DEFAULT ('V') FOR [CODIGO_ESTADO]
GO
ALTER TABLE [CTR].[PLANTILLA] ADD  CONSTRAINT [DF__PLANTILLA__FECHA__46B27FE2]  DEFAULT (getdate()) FOR [FECHA_INICIO_VIGENCIA]
GO
ALTER TABLE [CTR].[PLANTILLA] ADD  CONSTRAINT [DF__PLANTILLA__ESTAD__47A6A41B]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[PLANTILLA_PARRAFO] ADD  CONSTRAINT [DF__PLANTILLA__ESTAD__498EEC8D]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[PLANTILLA_PARRAFO_VARIABLE] ADD  CONSTRAINT [DF__PANTILLA___ESTAD__40F9A68C]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[PROVEEDOR] ADD  CONSTRAINT [DF__PROVEEDOR__ESTAD__4B7734FF]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[PROVEEDOR_ACUMULADO] ADD  CONSTRAINT [DF__PROVEEDOR__ESTAD__4D5F7D71]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[PROVEEDOR_ACUMULADO] ADD  CONSTRAINT [DF__PROVEEDOR__CODIG__4E53A1AA]  DEFAULT ('USD') FOR [CODIGO_MONEDA]
GO
ALTER TABLE [CTR].[PROVEEDOR_ACUMULADO] ADD  CONSTRAINT [DF__PROVEEDOR__MONTO__4F47C5E3]  DEFAULT ((0)) FOR [MONTO_ACUMULADO]
GO
ALTER TABLE [CTR].[PROVEEDOR_ACUMULADO] ADD  CONSTRAINT [DF_PROVEEDOR_ACUMULADO_INDICADOR_LIMITE_ALCANZADO]  DEFAULT ((0)) FOR [INDICADOR_LIMITE_ALCANZADO]
GO
ALTER TABLE [CTR].[PROVEEDOR_ACUMULADO] ADD  CONSTRAINT [DF_PROVEEDOR_ACUMULADO_INDICADOR_NOTIFICADO]  DEFAULT ((0)) FOR [INDICADOR_NOTIFICADO]
GO
ALTER TABLE [CTR].[VARIABLE] ADD  CONSTRAINT [DF__VARIABLE__INDICA__540C7B00]  DEFAULT ((0)) FOR [INDICADOR_VARIABLE_SISTEMA]
GO
ALTER TABLE [CTR].[VARIABLE] ADD  CONSTRAINT [DF__VARIABLE__CODIGO__51300E55]  DEFAULT ('T') FOR [CODIGO_TIPO]
GO
ALTER TABLE [CTR].[VARIABLE] ADD  CONSTRAINT [DF__VARIABLE__INDICA__5224328E]  DEFAULT ((1)) FOR [INDICADOR_GLOBAL]
GO
ALTER TABLE [CTR].[VARIABLE] ADD  CONSTRAINT [DF__VARIABLE__ESTADO__531856C7]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[VARIABLE_CAMPO] ADD  CONSTRAINT [DF__VARIABLE___ESTAD__55F4C372]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [CTR].[VARIABLE_CAMPO] ADD  CONSTRAINT [DF_VARIABLE_CAMPO_TAMANIO]  DEFAULT ((1)) FOR [TAMANIO]
GO
ALTER TABLE [HST].[BIEN_REGISTRO] ADD  CONSTRAINT [DF__BIEN_REGI__ESTAD__46F27704]  DEFAULT ('1') FOR [ESTADO_REGISTRO]
GO
ALTER TABLE [TMP].[ACUMULADO_PROVEEDOR] ADD  CONSTRAINT [DF__ACUMULADO__FECHA__76177A41]  DEFAULT (getdate()) FOR [FECHA_CREACION]
GO
ALTER TABLE [TMP].[INFORMACION_ENVIAR_CORREO] ADD  CONSTRAINT [DF__INFORMACI__FECHA__490FC9A0]  DEFAULT (getdate()) FOR [FECHA_CREACION]
GO
ALTER TABLE [TMP].[MONTO_ACUMULADO_CONTRATO] ADD  CONSTRAINT [DF__MONTO_ACU__FECHA__611C5D5B]  DEFAULT (getdate()) FOR [FECHA_CREACION]
GO
ALTER TABLE [TMP].[PROVEEDOR_ORDENES_COMPRA] ADD  CONSTRAINT [DF__PROVEEDOR__FECHA__4668671F]  DEFAULT (getdate()) FOR [FECHA_CREACION]
GO
ALTER TABLE [CTR].[BIEN_ALQUILER]  WITH CHECK ADD  CONSTRAINT [FK_BIEN_ALQUILER_BIEN] FOREIGN KEY([CODIGO_BIEN])
REFERENCES [CTR].[BIEN] ([CODIGO_BIEN])
GO
ALTER TABLE [CTR].[BIEN_ALQUILER] CHECK CONSTRAINT [FK_BIEN_ALQUILER_BIEN]
GO
ALTER TABLE [CTR].[CONTRATO]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_PLANTILLA] FOREIGN KEY([CODIGO_PLANTILLA])
REFERENCES [CTR].[PLANTILLA] ([CODIGO_PLANTILLA])
GO
ALTER TABLE [CTR].[CONTRATO] CHECK CONSTRAINT [FK_CONTRATO_PLANTILLA]
GO
ALTER TABLE [CTR].[CONTRATO]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_PROVEEDOR] FOREIGN KEY([CODIGO_PROVEEDOR])
REFERENCES [CTR].[PROVEEDOR] ([CODIGO_PROVEEDOR])
GO
ALTER TABLE [CTR].[CONTRATO] CHECK CONSTRAINT [FK_CONTRATO_PROVEEDOR]
GO
ALTER TABLE [CTR].[CONTRATO_BIEN]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_BIEN_BIEN] FOREIGN KEY([CODIGO_BIEN])
REFERENCES [CTR].[BIEN] ([CODIGO_BIEN])
GO
ALTER TABLE [CTR].[CONTRATO_BIEN] CHECK CONSTRAINT [FK_CONTRATO_BIEN_BIEN]
GO
ALTER TABLE [CTR].[CONTRATO_BIEN]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_BIEN_CONTRATO] FOREIGN KEY([CODIGO_CONTRATO])
REFERENCES [CTR].[CONTRATO] ([CODIGO_CONTRATO])
GO
ALTER TABLE [CTR].[CONTRATO_BIEN] CHECK CONSTRAINT [FK_CONTRATO_BIEN_CONTRATO]
GO
ALTER TABLE [CTR].[CONTRATO_DOCUMENTO]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_DOCUMENTO_CONTRATO] FOREIGN KEY([CODIGO_CONTRATO])
REFERENCES [CTR].[CONTRATO] ([CODIGO_CONTRATO])
GO
ALTER TABLE [CTR].[CONTRATO_DOCUMENTO] CHECK CONSTRAINT [FK_CONTRATO_DOCUMENTO_CONTRATO]
GO
ALTER TABLE [CTR].[CONTRATO_DOCUMENTO_ADJUNTO]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_DOCUMENTO_ADJUNTO_CONTRATO] FOREIGN KEY([CODIGO_CONTRATO])
REFERENCES [CTR].[CONTRATO] ([CODIGO_CONTRATO])
GO
ALTER TABLE [CTR].[CONTRATO_DOCUMENTO_ADJUNTO] CHECK CONSTRAINT [FK_CONTRATO_DOCUMENTO_ADJUNTO_CONTRATO]
GO
ALTER TABLE [CTR].[CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION_CONTRATO] FOREIGN KEY([CODIGO_CONTRATO])
REFERENCES [CTR].[CONTRATO] ([CODIGO_CONTRATO])
GO
ALTER TABLE [CTR].[CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION] CHECK CONSTRAINT [FK_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION_CONTRATO]
GO
ALTER TABLE [CTR].[CONTRATO_ESTADIO]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_ESTADIO_CONTRATO] FOREIGN KEY([CODIGO_CONTRATO])
REFERENCES [CTR].[CONTRATO] ([CODIGO_CONTRATO])
GO
ALTER TABLE [CTR].[CONTRATO_ESTADIO] CHECK CONSTRAINT [FK_CONTRATO_ESTADIO_CONTRATO]
GO
ALTER TABLE [CTR].[CONTRATO_ESTADIO]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_ESTADIO_FLUJO_APROBACION_ESTADIO] FOREIGN KEY([CODIGO_FLUJO_APROBACION_ESTADIO])
REFERENCES [CTR].[FLUJO_APROBACION_ESTADIO] ([CODIGO_FLUJO_APROBACION_ESTADIO])
GO
ALTER TABLE [CTR].[CONTRATO_ESTADIO] CHECK CONSTRAINT [FK_CONTRATO_ESTADIO_FLUJO_APROBACION_ESTADIO]
GO
ALTER TABLE [CTR].[CONTRATO_ESTADIO_CONSULTA]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_ESTADIO_CONSULTA_CONTRATO_ESTADIO] FOREIGN KEY([CODIGO_CONTRATO_ESTADIO])
REFERENCES [CTR].[CONTRATO_ESTADIO] ([CODIGO_CONTRATO_ESTADIO])
GO
ALTER TABLE [CTR].[CONTRATO_ESTADIO_CONSULTA] CHECK CONSTRAINT [FK_CONTRATO_ESTADIO_CONSULTA_CONTRATO_ESTADIO]
GO
ALTER TABLE [CTR].[CONTRATO_ESTADIO_OBSERVACION]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_ESTADIO_OBSERVACION_CONTRATO_ESTADIO] FOREIGN KEY([CODIGO_CONTRATO_ESTADIO])
REFERENCES [CTR].[CONTRATO_ESTADIO] ([CODIGO_CONTRATO_ESTADIO])
GO
ALTER TABLE [CTR].[CONTRATO_ESTADIO_OBSERVACION] CHECK CONSTRAINT [FK_CONTRATO_ESTADIO_OBSERVACION_CONTRATO_ESTADIO]
GO
ALTER TABLE [CTR].[CONTRATO_FIRMANTE]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_FIRMANTE_CONTRATO_PARRAFO_VARIABLE] FOREIGN KEY([CODIGO_CONTRATO_PARRAFO_VARIABLE])
REFERENCES [CTR].[CONTRATO_PARRAFO_VARIABLE] ([CODIGO_CONTRATO_PARRAFO_VARIABLE])
GO
ALTER TABLE [CTR].[CONTRATO_FIRMANTE] CHECK CONSTRAINT [FK_CONTRATO_FIRMANTE_CONTRATO_PARRAFO_VARIABLE]
GO
ALTER TABLE [CTR].[CONTRATO_HITO]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_HITO_CONTRATO] FOREIGN KEY([CODIGO_CONTRATO])
REFERENCES [CTR].[CONTRATO] ([CODIGO_CONTRATO])
GO
ALTER TABLE [CTR].[CONTRATO_HITO] CHECK CONSTRAINT [FK_CONTRATO_HITO_CONTRATO]
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_PARRAFO_CONTRATO] FOREIGN KEY([CODIGO_CONTRATO])
REFERENCES [CTR].[CONTRATO] ([CODIGO_CONTRATO])
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO] CHECK CONSTRAINT [FK_CONTRATO_PARRAFO_CONTRATO]
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_PARRAFO_PLANTILLA_PARRAFO] FOREIGN KEY([CODIGO_PLANTILLA_PARRAFO])
REFERENCES [CTR].[PLANTILLA_PARRAFO] ([CODIGO_PLANTILLA_PARRAFO])
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO] CHECK CONSTRAINT [FK_CONTRATO_PARRAFO_PLANTILLA_PARRAFO]
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO_VARIABLE]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_PARRAFO_VARIABLE_CONTRATO_PARRAFO] FOREIGN KEY([CODIGO_CONTRATO_PARRAFO])
REFERENCES [CTR].[CONTRATO_PARRAFO] ([CODIGO_CONTRATO_PARRAFO])
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO_VARIABLE] CHECK CONSTRAINT [FK_CONTRATO_PARRAFO_VARIABLE_CONTRATO_PARRAFO]
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO_VARIABLE]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_PARRAFO_VARIABLE_VARIABLE] FOREIGN KEY([CODIGO_VARIABLE])
REFERENCES [CTR].[VARIABLE] ([CODIGO_VARIABLE])
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO_VARIABLE] CHECK CONSTRAINT [FK_CONTRATO_PARRAFO_VARIABLE_VARIABLE]
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO_VARIABLE_CAMPO]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_PARRAFO_VARIABLE_CAMPO_CONTRATO_PARRAFO_VARIABLE] FOREIGN KEY([CODIGO_CONTRATO_PARRAFO_VARIABLE])
REFERENCES [CTR].[CONTRATO_PARRAFO_VARIABLE] ([CODIGO_CONTRATO_PARRAFO_VARIABLE])
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO_VARIABLE_CAMPO] CHECK CONSTRAINT [FK_CONTRATO_PARRAFO_VARIABLE_CAMPO_CONTRATO_PARRAFO_VARIABLE]
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO_VARIABLE_CAMPO]  WITH CHECK ADD  CONSTRAINT [FK_CONTRATO_PARRAFO_VARIABLE_CAMPO_VARIABLE_CAMPO] FOREIGN KEY([CODIGO_VARIABLE_CAMPO])
REFERENCES [CTR].[VARIABLE_CAMPO] ([CODIGO_VARIABLE_CAMPO])
GO
ALTER TABLE [CTR].[CONTRATO_PARRAFO_VARIABLE_CAMPO] CHECK CONSTRAINT [FK_CONTRATO_PARRAFO_VARIABLE_CAMPO_VARIABLE_CAMPO]
GO
ALTER TABLE [CTR].[FLUJO_APROBACION_ESTADIO]  WITH CHECK ADD  CONSTRAINT [FK_FLUJO_APROBACION_ESTADIO_FLUJO_APROBACION] FOREIGN KEY([CODIGO_FLUJO_APROBACION])
REFERENCES [CTR].[FLUJO_APROBACION] ([CODIGO_FLUJO_APROBACION])
GO
ALTER TABLE [CTR].[FLUJO_APROBACION_ESTADIO] CHECK CONSTRAINT [FK_FLUJO_APROBACION_ESTADIO_FLUJO_APROBACION]
GO
ALTER TABLE [CTR].[FLUJO_APROBACION_PARTICIPANTE]  WITH CHECK ADD  CONSTRAINT [FK_FLUJO_APROBACION_PARTICIPANTE_FLUJO_APROBACION_ESTADIO] FOREIGN KEY([CODIGO_FLUJO_APROBACION_ESTADIO])
REFERENCES [CTR].[FLUJO_APROBACION_ESTADIO] ([CODIGO_FLUJO_APROBACION_ESTADIO])
GO
ALTER TABLE [CTR].[FLUJO_APROBACION_PARTICIPANTE] CHECK CONSTRAINT [FK_FLUJO_APROBACION_PARTICIPANTE_FLUJO_APROBACION_ESTADIO]
GO
ALTER TABLE [CTR].[PLANTILLA_NOTA_PIE]  WITH CHECK ADD  CONSTRAINT [FK_PLANTILLA_NOTA_PIE_PLANTILLA] FOREIGN KEY([CODIGO_PLANTILLA])
REFERENCES [CTR].[PLANTILLA] ([CODIGO_PLANTILLA])
GO
ALTER TABLE [CTR].[PLANTILLA_NOTA_PIE] CHECK CONSTRAINT [FK_PLANTILLA_NOTA_PIE_PLANTILLA]
GO
ALTER TABLE [CTR].[PLANTILLA_PARRAFO]  WITH CHECK ADD  CONSTRAINT [FK_PLANTILLA_PARRAFO_PLANTILLA] FOREIGN KEY([CODIGO_PLANTILLA])
REFERENCES [CTR].[PLANTILLA] ([CODIGO_PLANTILLA])
GO
ALTER TABLE [CTR].[PLANTILLA_PARRAFO] CHECK CONSTRAINT [FK_PLANTILLA_PARRAFO_PLANTILLA]
GO
ALTER TABLE [CTR].[PLANTILLA_PARRAFO_VARIABLE]  WITH CHECK ADD  CONSTRAINT [FK_PANTILLA_PARRAFO_VARIABLE_PLANTILLA_PARRAFO] FOREIGN KEY([CODIGO_PLANTILLA_PARRAFO])
REFERENCES [CTR].[PLANTILLA_PARRAFO] ([CODIGO_PLANTILLA_PARRAFO])
GO
ALTER TABLE [CTR].[PLANTILLA_PARRAFO_VARIABLE] CHECK CONSTRAINT [FK_PANTILLA_PARRAFO_VARIABLE_PLANTILLA_PARRAFO]
GO
ALTER TABLE [CTR].[PLANTILLA_PARRAFO_VARIABLE]  WITH CHECK ADD  CONSTRAINT [FK_PANTILLA_PARRAFO_VARIABLE_VARIABLE] FOREIGN KEY([CODIGO_VARIABLE])
REFERENCES [CTR].[VARIABLE] ([CODIGO_VARIABLE])
GO
ALTER TABLE [CTR].[PLANTILLA_PARRAFO_VARIABLE] CHECK CONSTRAINT [FK_PANTILLA_PARRAFO_VARIABLE_VARIABLE]
GO
ALTER TABLE [CTR].[PROVEEDOR_ACUMULADO]  WITH CHECK ADD  CONSTRAINT [FK_PROVEEDOR_ACUMULADO_PROVEEDOR] FOREIGN KEY([CODIGO_PROVEEDOR])
REFERENCES [CTR].[PROVEEDOR] ([CODIGO_PROVEEDOR])
GO
ALTER TABLE [CTR].[PROVEEDOR_ACUMULADO] CHECK CONSTRAINT [FK_PROVEEDOR_ACUMULADO_PROVEEDOR]
GO
ALTER TABLE [CTR].[VARIABLE]  WITH CHECK ADD  CONSTRAINT [FK_VARIABLE_PLANTILLA] FOREIGN KEY([CODIGO_PLANTILLA])
REFERENCES [CTR].[PLANTILLA] ([CODIGO_PLANTILLA])
GO
ALTER TABLE [CTR].[VARIABLE] CHECK CONSTRAINT [FK_VARIABLE_PLANTILLA]
GO
ALTER TABLE [CTR].[VARIABLE_CAMPO]  WITH CHECK ADD  CONSTRAINT [FK_VARIABLE_CAMPO_VARIABLE] FOREIGN KEY([CODIGO_VARIABLE])
REFERENCES [CTR].[VARIABLE] ([CODIGO_VARIABLE])
GO
ALTER TABLE [CTR].[VARIABLE_CAMPO] CHECK CONSTRAINT [FK_VARIABLE_CAMPO_VARIABLE]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Actualiza los registros de proveedor acumulado una vez que fueron notificados  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ACTUALIZA_PROV_ACUMULADO_NOTIFICADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa user modifica.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ACTUALIZA_PROV_ACUMULADO_NOTIFICADO', @level2type=N'PARAMETER',@level2name=N'@USER_MODIFICA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal modifica.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ACTUALIZA_PROV_ACUMULADO_NOTIFICADO', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_MODIFICA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Aprueba los estadios de los contratos.  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_APRUEBA_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_APRUEBA_CONTRATO_ESTADIO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificacion uo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_APRUEBA_CONTRATO_ESTADIO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICACION_UO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_APRUEBA_CONTRATO_ESTADIO', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_APRUEBA_CONTRATO_ESTADIO', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtener el listado de la auditoría existente   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_AUDITORIA_EXISTE_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_AUDITORIA_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha planificada.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_AUDITORIA_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@FECHA_PLANIFICADA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtener el listado de la auditoría    ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_AUDITORIA_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo auditoria.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_AUDITORIA_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_AUDITORIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_AUDITORIA_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha planificada desde.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_AUDITORIA_SEL', @level2type=N'PARAMETER',@level2name=N'@FECHA_PLANIFICADA_DESDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha planificada hasta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_AUDITORIA_SEL', @level2type=N'PARAMETER',@level2name=N'@FECHA_PLANIFICADA_HASTA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_AUDITORIA_SEL', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Obtener campos de tabla  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_BIEN_ALQUILER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo bien.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_BIEN_ALQUILER', @level2type=N'PARAMETER',@level2name=N'@CODIGO_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Retorna todos los bienes  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_BIENALQUILER_POR_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo bien.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_BIENALQUILER_POR_BIEN', @level2type=N'PARAMETER',@level2name=N'@CODIGO_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Retorna todos los bienes  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_BIENES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_BIENES', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa tipo bien.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_BIENES', @level2type=N'PARAMETER',@level2name=N'@TIPO_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero serie.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_BIENES', @level2type=N'PARAMETER',@level2name=N'@NUMERO_SERIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa descripcion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_BIENES', @level2type=N'PARAMETER',@level2name=N'@DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa marca.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_BIENES', @level2type=N'PARAMETER',@level2name=N'@MARCA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa modelo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_BIENES', @level2type=N'PARAMETER',@level2name=N'@MODELO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa fecha desde.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_BIENES', @level2type=N'PARAMETER',@level2name=N'@FECHA_DESDE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa fecha hasta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_BIENES', @level2type=N'PARAMETER',@level2name=N'@FECHA_HASTA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa tipo tarifa.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_BIENES', @level2type=N'PARAMETER',@level2name=N'@TIPO_TARIFA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Retorna todos las observaciones por Contrato por Estadio  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_CONSULTAS_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigocontratoestadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_CONSULTAS_SEL', @level2type=N'PARAMETER',@level2name=N'@CodigoContratoEstadio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Retorna todos las contratos para la bandeja del usuario de acuerdo al perfil  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_CONTRATOS_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigoresponsable.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_CONTRATOS_SEL', @level2type=N'PARAMETER',@level2name=N'@CodigoResponsable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa unidadoperativa.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_CONTRATOS_SEL', @level2type=N'PARAMETER',@level2name=N'@UnidadOperativa'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombreproveedor.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_CONTRATOS_SEL', @level2type=N'PARAMETER',@level2name=N'@NombreProveedor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numerodocumentoprv.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_CONTRATOS_SEL', @level2type=N'PARAMETER',@level2name=N'@NumeroDocumentoPrv'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa tiposervicio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_CONTRATOS_SEL', @level2type=N'PARAMETER',@level2name=N'@TipoServicio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa tiporequerimiento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_CONTRATOS_SEL', @level2type=N'PARAMETER',@level2name=N'@TipoRequerimiento'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Retorna todos las observaciones por Contrato por Estadio  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_OBSERVACIONES_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigocontratoestadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_OBSERVACIONES_SEL', @level2type=N'PARAMETER',@level2name=N'@CodigoContratoEstadio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Retorna todos las contratos que tienen una solicitud de autoreizacion  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_SOLICITUD_CONTRATO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numerocontrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_SOLICITUD_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@NumeroContrato'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa unidadoperativa.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_SOLICITUD_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@UnidadOperativa'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombreproveedor.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_SOLICITUD_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@NombreProveedor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numerodocumentoprv.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BANDEJA_SOLICITUD_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@NumeroDocumentoPrv'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' <<No especificado>> ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_CONTRATO_RPT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_CONTRATO_RPT', @level2type=N'PARAMETER',@level2name=N'@CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo tipo bien.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_CONTRATO_RPT', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa ruc proveedor.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_CONTRATO_RPT', @level2type=N'PARAMETER',@level2name=N'@RUC_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre proveedor.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_CONTRATO_RPT', @level2type=N'PARAMETER',@level2name=N'@NOMBRE_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_CONTRATO_RPT', @level2type=N'PARAMETER',@level2name=N'@NUMERO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero serie.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_CONTRATO_RPT', @level2type=N'PARAMETER',@level2name=N'@NUMERO_SERIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' <<No especificado>> ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_DESCRIPCION_COMPLETA_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa descripcion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_DESCRIPCION_COMPLETA_SEL', @level2type=N'PARAMETER',@level2name=N'@DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Inserta Registros  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_REGISTRO_INS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa tipo contenido.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_REGISTRO_INS', @level2type=N'PARAMETER',@level2name=N'@TIPO_CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa contenido.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_REGISTRO_INS', @level2type=N'PARAMETER',@level2name=N'@CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_REGISTRO_INS', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_REGISTRO_INS', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Registra y/o actualiza información de descripción de los Bienes.  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_REGISTRO_INS_UPD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa codigo tipo contenido.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_REGISTRO_INS_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa contenido.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_REGISTRO_INS_UPD', @level2type=N'PARAMETER',@level2name=N'@CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa user create.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_REGISTRO_INS_UPD', @level2type=N'PARAMETER',@level2name=N'@USER_CREATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal create.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_BIEN_REGISTRO_INS_UPD', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' <<No especificado>> ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTENIDO_BIEN_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa codigo tipo contenido.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTENIDO_BIEN_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' <<No especificado>> ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_BIEN_INS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato bien.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_BIEN_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_BIEN_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo bien.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_BIEN_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_BIEN_INS', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_BIEN_INS', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_BIEN_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_BIEN_INS', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Inserta y actualiza registros en la tabla Contrato documento  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_INS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato documento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo archivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_ARCHIVO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa ruta archivo sharepoint.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_INS', @level2type=N'PARAMETER',@level2name=N'@RUTA_ARCHIVO_SHAREPOINT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa contenido.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_INS', @level2type=N'PARAMETER',@level2name=N'@CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador actual.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_INS', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_ACTUAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo tinyint, que representa version.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_INS', @level2type=N'PARAMETER',@level2name=N'@VERSION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_INS', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_INS', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_INS', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Retorna información de los documentos del contrato.  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_POR_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigocontrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_POR_CONTRATO', @level2type=N'PARAMETER',@level2name=N'@CodigoContrato'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado de los contratos de documento   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato documento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo archivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_ARCHIVO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa ruta archivo sharepoint.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_SEL', @level2type=N'PARAMETER',@level2name=N'@RUTA_ARCHIVO_SHAREPOINT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa contenido.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_SEL', @level2type=N'PARAMETER',@level2name=N'@CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador actual.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_SEL', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_ACTUAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo tinyint, que representa version.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_SEL', @level2type=N'PARAMETER',@level2name=N'@VERSION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa número de página de la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_SEL', @level2type=N'PARAMETER',@level2name=N'@PageNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_DOCUMENTO_SEL', @level2type=N'PARAMETER',@level2name=N'@PageSize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Inserta y actualiza registros en la tabla Contrato documento  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_INS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha ingreso.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_INGRESO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha finalizacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_FINALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo responsable.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_RESPONSABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo estado contrato estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_ESTADO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha primera notificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_PRIMERA_NOTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha ultima notificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_ULTIMA_NOTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_INS', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_INS', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_INS', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado del contrato de estadio   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha ingreso.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@FECHA_INGRESO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha finalizacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@FECHA_FINALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo responsable.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_RESPONSABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo estado contrato estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_ESTADO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha primera notificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@FECHA_PRIMERA_NOTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha ultima notificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@FECHA_ULTIMA_NOTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa número de página de la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@PageNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@PageSize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Inserta y actualiza registros en la tabla Contrato  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo proveedor.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@NUMERO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa descripcion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo tipo servicio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_SERVICIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador version oficial.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_VERSION_OFICIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha inicio vigencia.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_INICIO_VIGENCIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha fin vigencia.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_FIN_VIGENCIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa codigo moneda.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_MONEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo decimal, que representa monto contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@MONTO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo decimal, que representa monto acumulado.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@MONTO_ACUMULADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo estado.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_ESTADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PLANTILLA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato principal.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_PRINCIPAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo estado edicion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_ESTADO_EDICION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo varchar, que representa comentario modificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@COMENTARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa respuesta modificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@RESPUESTA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo estadio actual.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_ESTADIO_ACTUAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_INS', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el Monto Acumulado del Contrato Principal más sus Adendas  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_OBTENER_MONTO_ACUMULADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato principal.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_OBTENER_MONTO_ACUMULADO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_PRINCIPAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Inserta y actualiza registros en la tabla Contrato parrafo  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_INS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato parrafo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_PARRAFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla parrafo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PLANTILLA_PARRAFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa contenido.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_INS', @level2type=N'PARAMETER',@level2name=N'@CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_INS', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_INS', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_INS', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Retorna información de los documentos del contrato.  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_POR_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_POR_CONTRATO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Retorna los párrafos de un contrato.  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Inserta y actualiza registros en la tabla Contrato documento  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_VARIABLE_INS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato parrafo variable.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_VARIABLE_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_PARRAFO_VARIABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato parrafo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_VARIABLE_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_PARRAFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo variable.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_VARIABLE_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_VARIABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa valor texto.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_VARIABLE_INS', @level2type=N'PARAMETER',@level2name=N'@VALOR_TEXTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo decimal, que representa valor numero.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_VARIABLE_INS', @level2type=N'PARAMETER',@level2name=N'@VALOR_NUMERO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa valor fecha.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_VARIABLE_INS', @level2type=N'PARAMETER',@level2name=N'@VALOR_FECHA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo varbinary, que representa valor imagen.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_VARIABLE_INS', @level2type=N'PARAMETER',@level2name=N'@VALOR_IMAGEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa valor tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_VARIABLE_INS', @level2type=N'PARAMETER',@level2name=N'@VALOR_TABLA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa valor bien.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_VARIABLE_INS', @level2type=N'PARAMETER',@level2name=N'@VALOR_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_VARIABLE_INS', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_VARIABLE_INS', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_VARIABLE_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PARRAFO_VARIABLE_INS', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado del contratos principales  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PRINCIPAL_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PRINCIPAL_SEL', @level2type=N'PARAMETER',@level2name=N'@NUMERO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa descripcion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_PRINCIPAL_SEL', @level2type=N'PARAMETER',@level2name=N'@DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado del contrato   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo tipo servicio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_SERVICIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo tipo requerimiento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_REQUERIMIENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo estado.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_ESTADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@NUMERO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero documento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@NUMERO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre proveedor.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@NOMBRE_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa descripcion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa número de página de la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@PageNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@PageSize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Permite modificar un registro de un contrato   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_UPD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo estado.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_ESTADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo estado edicion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_ESTADO_EDICION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo varchar, que representa comentario modificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATO_UPD', @level2type=N'PARAMETER',@level2name=N'@COMENTARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Actualiza las notificaciones de los contratos estadios.  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_ESTADIO_NOTIFICACION_UPD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo contrato estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_ESTADIO_NOTIFICACION_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa user update.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_ESTADIO_NOTIFICACION_UPD', @level2type=N'PARAMETER',@level2name=N'@USER_UPDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal update.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_ESTADIO_NOTIFICACION_UPD', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_UPDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Aprueba los estadios de los contratos.  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_ESTADIO_RPT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_ESTADIO_RPT', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha inicio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_ESTADIO_RPT', @level2type=N'PARAMETER',@level2name=N'@FECHA_INICIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha fin.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_ESTADIO_RPT', @level2type=N'PARAMETER',@level2name=N'@FECHA_FIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Muestra los contrato pendiees eborar  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_PENDIENTES_ELABORAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa ruc proveedor.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_PENDIENTES_ELABORAR', @level2type=N'PARAMETER',@level2name=N'@RUC_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre proveedor.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_PENDIENTES_ELABORAR', @level2type=N'PARAMETER',@level2name=N'@NOMBRE_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa tipo orden.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_PENDIENTES_ELABORAR', @level2type=N'PARAMETER',@level2name=N'@TIPO_ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa periodo anio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_PENDIENTES_ELABORAR', @level2type=N'PARAMETER',@level2name=N'@PERIODO_ANIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa periodo mes.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_PENDIENTES_ELABORAR', @level2type=N'PARAMETER',@level2name=N'@PERIODO_MES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo varchar, que representa moneda.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_PENDIENTES_ELABORAR', @level2type=N'PARAMETER',@level2name=N'@MONEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Muestra el estadio actual de los contratos.  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_POR_VENCER_RPT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_POR_VENCER_RPT', @level2type=N'PARAMETER',@level2name=N'@CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha inicio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_POR_VENCER_RPT', @level2type=N'PARAMETER',@level2name=N'@FECHA_INICIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha fin.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_POR_VENCER_RPT', @level2type=N'PARAMETER',@level2name=N'@FECHA_FIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa estado.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_POR_VENCER_RPT', @level2type=N'PARAMETER',@level2name=N'@ESTADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa numdias rojo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_POR_VENCER_RPT', @level2type=N'PARAMETER',@level2name=N'@NUMDIAS_ROJO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa numdias ambar.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_POR_VENCER_RPT', @level2type=N'PARAMETER',@level2name=N'@NUMDIAS_AMBAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Web Service  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_CONTRATOS_PROVEEDOR_ORACLE_WS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Permite copiar los estadios   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_COPIAR_ESTADIOS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion origen.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_COPIAR_ESTADIOS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_ORIGEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion destino.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_COPIAR_ESTADIOS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_DESTINO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_COPIAR_ESTADIOS', @level2type=N'PARAMETER',@level2name=N'@USUARIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_COPIAR_ESTADIOS', @level2type=N'PARAMETER',@level2name=N'@TERMINAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Obtener datos de tabla  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_DATOS_CORREO_CONTRATO_RETRASADO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Retorna información de los documentos del contrato.  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_DOCUMENTO_POR_CONTRATO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigocontrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_DOCUMENTO_POR_CONTRATO_SEL', @level2type=N'PARAMETER',@level2name=N'@CodigoContrato'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Retorna el estadio anterior del Contrato por Estadio  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_ANTERIOR_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_ANTERIOR_CONTRATO_ESTADIO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_ANTERIOR_CONTRATO_ESTADIO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Permite registrar un estadio por defecto   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_POR_DEFECTO_INS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_POR_DEFECTO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_POR_DEFECTO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo tinyint, que representa orden.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_POR_DEFECTO_INS', @level2type=N'PARAMETER',@level2name=N'@ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa descripcion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_POR_DEFECTO_INS', @level2type=N'PARAMETER',@level2name=N'@DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo decimal, que representa tiempo atencion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_POR_DEFECTO_INS', @level2type=N'PARAMETER',@level2name=N'@TIEMPO_ATENCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo decimal, que representa horas atencion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_POR_DEFECTO_INS', @level2type=N'PARAMETER',@level2name=N'@HORAS_ATENCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador version oficial.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_POR_DEFECTO_INS', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_VERSION_OFICIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador permite carga.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_POR_DEFECTO_INS', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_PERMITE_CARGA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador numero contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_POR_DEFECTO_INS', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_NUMERO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_POR_DEFECTO_INS', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_POR_DEFECTO_INS', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_POR_DEFECTO_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIO_POR_DEFECTO_INS', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Retorna todos las contratos para la bandeja del usuario de acuerdo al perfil  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIOS_CONTRATO_OBSERVACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigocontratoestadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_ESTADIOS_CONTRATO_OBSERVACION', @level2type=N'PARAMETER',@level2name=N'@CodigoContratoEstadio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado de aprobación de estadio de descripción existente    ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_DESCRIPCION_EXISTE_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_DESCRIPCION_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa descripcion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_DESCRIPCION_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado del flujo de aprobación de orden existente   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_ORDEN_EXISTE_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_ORDEN_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo tinyint, que representa orden.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_ORDEN_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Reordena registros en base al parametro orden  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_PRE_INS_UDP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_PRE_INS_UDP', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_PRE_INS_UDP', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo tinyint, que representa orden.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_PRE_INS_UDP', @level2type=N'PARAMETER',@level2name=N'@ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario proceso.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_PRE_INS_UDP', @level2type=N'PARAMETER',@level2name=N'@USUARIO_PROCESO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal proceso.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_PRE_INS_UDP', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_PROCESO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa accion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_PRE_INS_UDP', @level2type=N'PARAMETER',@level2name=N'@ACCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado del flujo de aprobación de estadio   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Elimina los registros de la tabla Flujo_aprobacion_participante  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_PARTICIPANTE_DEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_PARTICIPANTE_DEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado del flujo de la aprobación   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_FLUJO_APROBACION_SEL', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Aprueba los estadios de los contratos.  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_HOJA_RUTA_RPT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha inicio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_HOJA_RUTA_RPT', @level2type=N'PARAMETER',@level2name=N'@FECHA_INICIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha fin.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_HOJA_RUTA_RPT', @level2type=N'PARAMETER',@level2name=N'@FECHA_FIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_HOJA_RUTA_RPT', @level2type=N'PARAMETER',@level2name=N'@NUMERO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Permite actualizar el indicador del número de contrato   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_INDICADOR_NUMERO_CONTRATO_UPD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_INDICADOR_NUMERO_CONTRATO_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_INDICADOR_NUMERO_CONTRATO_UPD', @level2type=N'PARAMETER',@level2name=N'@USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_INDICADOR_NUMERO_CONTRATO_UPD', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Permite actualizar el indicador de versión oficial   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_INDICADOR_VERSION_OFICIAL_UPDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_INDICADOR_VERSION_OFICIAL_UPDATE', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_INDICADOR_VERSION_OFICIAL_UPDATE', @level2type=N'PARAMETER',@level2name=N'@USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_INDICADOR_VERSION_OFICIAL_UPDATE', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Obtener registros de tabla  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_INF_NOTIFICACION_CONTRATO_ESTADIO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_INF_NOTIFICACION_CONTRATO_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa tipo notificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_INF_NOTIFICACION_CONTRATO_ESTADIO_SEL', @level2type=N'PARAMETER',@level2name=N'@TIPO_NOTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Lista unidad operativa por participante responsable  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_LISTAR_UO_POR_PARTICIPANTE_RESPONSABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo trabajador.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_LISTAR_UO_POR_PARTICIPANTE_RESPONSABLE', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TRABAJADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Notifica a los usuarios involucrados de contratos.  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_NOTIFICACION_BANDEJA_CONTRATOS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa asunto.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_NOTIFICACION_BANDEJA_CONTRATOS', @level2type=N'PARAMETER',@level2name=N'@ASUNTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa texto notificar.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_NOTIFICACION_BANDEJA_CONTRATOS', @level2type=N'PARAMETER',@level2name=N'@TEXTO_NOTIFICAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa cuenta notificar.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_NOTIFICACION_BANDEJA_CONTRATOS', @level2type=N'PARAMETER',@level2name=N'@CUENTA_NOTIFICAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa cuentas copias.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_NOTIFICACION_BANDEJA_CONTRATOS', @level2type=N'PARAMETER',@level2name=N'@CUENTAS_COPIAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa profile correo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_NOTIFICACION_BANDEJA_CONTRATOS', @level2type=N'PARAMETER',@level2name=N'@PROFILE_CORREO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Observar el contrato, generando un nuevo estadio.  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_OBSERVA_ESTADIO_CONTRATO_UPD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_OBSERVA_ESTADIO_CONTRATO_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato estadio observado.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_OBSERVA_ESTADIO_CONTRATO_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_ESTADIO_OBSERVADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_OBSERVA_ESTADIO_CONTRATO_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo estadio retorno.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_OBSERVA_ESTADIO_CONTRATO_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_ESTADIO_RETORNO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo responsable.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_OBSERVA_ESTADIO_CONTRATO_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_RESPONSABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa user creation.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_OBSERVA_ESTADIO_CONTRATO_UPD', @level2type=N'PARAMETER',@level2name=N'@USER_CREATION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creation.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_OBSERVA_ESTADIO_CONTRATO_UPD', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREATION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado de la planilla de párrafo   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_ORDEN_TITULO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_ORDEN_TITULO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PLANTILLA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo tinyint, que representa orden.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_ORDEN_TITULO_SEL', @level2type=N'PARAMETER',@level2name=N'@ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa titulo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_ORDEN_TITULO_SEL', @level2type=N'PARAMETER',@level2name=N'@TITULO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_ORDEN_TITULO_SEL', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado de la plantilla de párrafo   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla parrafo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PLANTILLA_PARRAFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PLANTILLA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo tinyint, que representa orden.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_SEL', @level2type=N'PARAMETER',@level2name=N'@ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa titulo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_SEL', @level2type=N'PARAMETER',@level2name=N'@TITULO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo varchar, que representa contenido.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_SEL', @level2type=N'PARAMETER',@level2name=N'@CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa número de página de la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_SEL', @level2type=N'PARAMETER',@level2name=N'@PageNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_SEL', @level2type=N'PARAMETER',@level2name=N'@PageSize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado de la plantilla de párrafo de variable de código de plantilla párrafo   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_VARIABLE_CODIGO_PLANTILLA_PARRAFO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla parrafo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_VARIABLE_CODIGO_PLANTILLA_PARRAFO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PLANTILLA_PARRAFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_PARRAFO_VARIABLE_CODIGO_PLANTILLA_PARRAFO_SEL', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado de la plantilla   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PLANTILLA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa descripcion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_SEL', @level2type=N'PARAMETER',@level2name=N'@DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo estado.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_ESTADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha inicio vigencia.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_SEL', @level2type=N'PARAMETER',@level2name=N'@FECHA_INICIO_VIGENCIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha fin vigencia.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_SEL', @level2type=N'PARAMETER',@level2name=N'@FECHA_FIN_VIGENCIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa número de página de la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_SEL', @level2type=N'PARAMETER',@level2name=N'@PageNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_SEL', @level2type=N'PARAMETER',@level2name=N'@PageSize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado de la plantilla tipo   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_TIPO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_TIPO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Actualiza Plantilla Vigencia  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_VIGENCIA_UPD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_VIGENCIA_UPD', @level2type=N'PARAMETER',@level2name=N'@USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_VIGENCIA_UPD', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Obtener registros de tabla  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROCESA_CONTRATOS_RETRASO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Registra un proveedor acumulado  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_ACUMULADO_INS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa ruc proveedor.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_ACUMULADO_INS', @level2type=N'PARAMETER',@level2name=N'@RUC_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo tipo orden.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_ACUMULADO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo moneda.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_ACUMULADO_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_MONEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo decimal, que representa monto acumulado.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_ACUMULADO_INS', @level2type=N'PARAMETER',@level2name=N'@MONTO_ACUMULADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_ACUMULADO_INS', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_ACUMULADO_INS', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_ACUMULADO_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_ACUMULADO_INS', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado del proveedor existente   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_EXISTE_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre comercial.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@NOMBRE_COMERCIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa tipo documento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@TIPO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero documento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@NUMERO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Registra un proveedor  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_INS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_INS', @level2type=N'PARAMETER',@level2name=N'@NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre comercial.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_INS', @level2type=N'PARAMETER',@level2name=N'@NOMBRE_COMERCIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa tipo documento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_INS', @level2type=N'PARAMETER',@level2name=N'@TIPO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero documento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_INS', @level2type=N'PARAMETER',@level2name=N'@NUMERO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_INS', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_INS', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_INS', @level2type=N'PARAMETER',@level2name=N'@FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_INS', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado del proveedor   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo proveedor.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_SEL', @level2type=N'PARAMETER',@level2name=N'@NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre comercial.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_SEL', @level2type=N'PARAMETER',@level2name=N'@NOMBRE_COMERCIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa tipo documento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_SEL', @level2type=N'PARAMETER',@level2name=N'@TIPO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero documento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_SEL', @level2type=N'PARAMETER',@level2name=N'@NUMERO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa número de página de la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_SEL', @level2type=N'PARAMETER',@level2name=N'@PageNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_PROVEEDOR_SEL', @level2type=N'PARAMETER',@level2name=N'@PageSize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Permite registrar un contrato de carga de archivo   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_REGISTRA_CONTRATODOC_CARGA_ARCHIVO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato documento.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_REGISTRA_CONTRATODOC_CARGA_ARCHIVO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_REGISTRA_CONTRATODOC_CARGA_ARCHIVO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo archivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_REGISTRA_CONTRATODOC_CARGA_ARCHIVO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_ARCHIVO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa ruta archivoshp.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_REGISTRA_CONTRATODOC_CARGA_ARCHIVO', @level2type=N'PARAMETER',@level2name=N'@RUTA_ARCHIVOSHP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa contenido.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_REGISTRA_CONTRATODOC_CARGA_ARCHIVO', @level2type=N'PARAMETER',@level2name=N'@CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa user creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_REGISTRA_CONTRATODOC_CARGA_ARCHIVO', @level2type=N'PARAMETER',@level2name=N'@USER_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_REGISTRA_CONTRATODOC_CARGA_ARCHIVO', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado de los responsables de flujo de estadio   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_RESPONSABLES_FLUJO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigoflujoaprobacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_RESPONSABLES_FLUJO_ESTADIO', @level2type=N'PARAMETER',@level2name=N'@CodigoFlujoAprobacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Actualiza registros de tabla  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_INFORMADO_UPD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo flujo aprobacion estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_INFORMADO_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo informado.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_INFORMADO_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_INFORMADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre informado.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_INFORMADO_UPD', @level2type=N'PARAMETER',@level2name=N'@NOMBRE_INFORMADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa correo informado.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_INFORMADO_UPD', @level2type=N'PARAMETER',@level2name=N'@CORREO_INFORMADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Insertar registros en tabla  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_RETRASADOS_INS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo flujo aprobacione.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_RETRASADOS_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACIONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo contrato estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_RETRASADOS_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_RETRASADOS_INS', @level2type=N'PARAMETER',@level2name=N'@NUMERO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre proveedor.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_RETRASADOS_INS', @level2type=N'PARAMETER',@level2name=N'@NOMBRE_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre responsable.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_RETRASADOS_INS', @level2type=N'PARAMETER',@level2name=N'@NOMBRE_RESPONSABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_RETRASADOS_INS', @level2type=N'PARAMETER',@level2name=N'@NOMBRE_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa correo responsable.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_RETRASADOS_INS', @level2type=N'PARAMETER',@level2name=N'@CORREO_RESPONSABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa asunto.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_RETRASADOS_INS', @level2type=N'PARAMETER',@level2name=N'@ASUNTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa contenido.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_RETRASADOS_INS', @level2type=N'PARAMETER',@level2name=N'@CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa url sistema.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_RETRASADOS_INS', @level2type=N'PARAMETER',@level2name=N'@URL_SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa profile correo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TEMP_CONTRATOS_RETRASADOS_INS', @level2type=N'PARAMETER',@level2name=N'@PROFILE_CORREO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Aprueba los estadios de los contratos.  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TIEMPOS_ATENCION_RPT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TIEMPOS_ATENCION_RPT', @level2type=N'PARAMETER',@level2name=N'@CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha inicio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TIEMPOS_ATENCION_RPT', @level2type=N'PARAMETER',@level2name=N'@FECHA_INICIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha fin.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TIEMPOS_ATENCION_RPT', @level2type=N'PARAMETER',@level2name=N'@FECHA_FIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TIEMPOS_ATENCION_RPT', @level2type=N'PARAMETER',@level2name=N'@NUMERO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Muestra el estadio actual de los contratos.  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TRAZABILIDAD_CONTRATO_RPT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TRAZABILIDAD_CONTRATO_RPT', @level2type=N'PARAMETER',@level2name=N'@CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha inicio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TRAZABILIDAD_CONTRATO_RPT', @level2type=N'PARAMETER',@level2name=N'@FECHA_INICIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo datetime, que representa fecha fin.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_TRAZABILIDAD_CONTRATO_RPT', @level2type=N'PARAMETER',@level2name=N'@FECHA_FIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Obtener registros de tabla  ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_CAMPO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo variable campo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_CAMPO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_VARIABLE_CAMPO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo variable.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_CAMPO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_VARIABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_CAMPO_SEL', @level2type=N'PARAMETER',@level2name=N'@NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo tinyint, que representa orden.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_CAMPO_SEL', @level2type=N'PARAMETER',@level2name=N'@ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtiene el listado de la variable global   ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_GLOBAL_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_GLOBAL_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PLANTILLA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_GLOBAL_SEL', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'   Obtener registros    ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo variable.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_VARIABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa identificador.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_SEL', @level2type=N'PARAMETER',@level2name=N'@IDENTIFICADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_SEL', @level2type=N'PARAMETER',@level2name=N'@NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo tipo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador global.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_SEL', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_GLOBAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PLANTILLA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador variable sistema.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'PROCEDURE',@level1name=N'USP_VARIABLE_SEL', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_VARIABLE_SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_DESCRIPCION_ESTADIO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Retorna la descripción del estadio del Flujo de aprobación' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_DESCRIPCION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_FLUJO_APROBACION_PARTICIPANTE', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa codigo tipo participante.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_FLUJO_APROBACION_PARTICIPANTE', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_PARTICIPANTE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permite retornar los flujos de participantes y la lista de aprobación' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_FLUJO_APROBACION_PARTICIPANTE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_INFORMADOS_ESTADIO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Retorna los informados del estadio del Flujo de aprobación' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_INFORMADOS_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Retorna Lista Contratos ' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_LISTA_CONTRATOS_PRV_NOTIFICAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo proveedor.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_NOMBRE_NUMDOC_PROVEEDOR', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa tipo campo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_NOMBRE_NUMDOC_PROVEEDOR', @level2type=N'PARAMETER',@level2name=N'@TIPO_CAMPO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Retorna el número de documento o nombre del proveedor por su código y un parámetro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_NOMBRE_NUMDOC_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_ORDEN_FLUJO_APROBACION_ESTADIO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permite retornar el orden de un Flujo de Aprobacion estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_ORDEN_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo flujo aprobacion estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_RESPONSABLES_ESTADIO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Retorna el responsable del estadio del Flujo de aprobación' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'FUNCTION',@level1name=N'FN_RETORNA_RESPONSABLES_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permite enviar una lista del tipo GUID' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TYPE',@level1name=N'LISTA_GUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permite enviar montos de moneda por contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TYPE',@level1name=N'LISTA_MONTOS_CONTRATO_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permite enviar una lista del tipo VARCHAR' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TYPE',@level1name=N'LISTA_TIPO_SERVICIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contiene los objetos del esquema de Contractual' , @level0type=N'SCHEMA',@level0name=N'CTR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Esquema que se usa para los objetos Historicos' , @level0type=N'SCHEMA',@level0name=N'HST'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Esquema que se usa para los objetos Temporales' , @level0type=N'SCHEMA',@level0name=N'TMP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA', @level2type=N'COLUMN',@level2name=N'CODIGO_AUDITORIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de la Unidad Operativa en la que se realiza la auditoría.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA', @level2type=N'COLUMN',@level2name=N'CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha planificada de la auditoría.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA', @level2type=N'COLUMN',@level2name=N'FECHA_PLANIFICADA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de Ejecución de la auditoría.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA', @level2type=N'COLUMN',@level2name=N'FECHA_EJECUCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cantidad de Órdenes Auditadas.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA', @level2type=N'COLUMN',@level2name=N'CANTIDAD_AUDITADAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cantidad de Órdenes Observadas.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA', @level2type=N'COLUMN',@level2name=N'CANTIDAD_OBSERVADAS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción del resultado de la auditoría.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA', @level2type=N'COLUMN',@level2name=N'RESULTADO_AUDITORIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla donde se registran los procesos de auditoría.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'AUDITORIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'CODIGO_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de tipo de bien: Por defecto equipo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Identificacion' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'CODIGO_IDENTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de serie' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'NUMERO_SERIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción del equipo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Marca del equipo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'MARCA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Modelo del equipo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'MODELO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de adquisición del equipo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'FECHA_ADQUISICION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tiempo de vida útil (en horas) del equipo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'TIEMPO_VIDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor residual (en horas) del equipo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'VALOR_RESIDUAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de tipo de tarifa: F=Fijo, E=Escalonado' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_TARIFA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de periodo de alquiler: D=Por Día, M=Por Mes, H=Por Hora' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'CODIGO_PERIODO_ALQUILER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor de alquiler cuando el tipo de alquiler es fijo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'VALOR_ALQUILER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de moneda de alquiler, viene del parámetro general moneda.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'CODIGO_MONEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mes de Inicio de Alquiler' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'MES_INICIO_ALQUILER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Anio de Inicio de Alquiler' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN', @level2type=N'COLUMN',@level2name=N'ANIO_INICIO_ALQUILER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Maestro de Bienes' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN_ALQUILER', @level2type=N'COLUMN',@level2name=N'CODIGO_BIEN_ALQUILER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del bien del que se detalla el alquiler.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN_ALQUILER', @level2type=N'COLUMN',@level2name=N'CODIGO_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica que es el rango máximo y no tiene límite.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN_ALQUILER', @level2type=N'COLUMN',@level2name=N'INDICADOR_SIN_LIMITE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Límite (cantidad máxima) que define el rango.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN_ALQUILER', @level2type=N'COLUMN',@level2name=N'CANTIDAD_LIMITE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN_ALQUILER', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN_ALQUILER', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN_ALQUILER', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN_ALQUILER', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN_ALQUILER', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN_ALQUILER', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN_ALQUILER', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto de la tarifa en el rango indicado.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN_ALQUILER', @level2type=N'COLUMN',@level2name=N'MONTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla donde se detalla el Pago de Alquiler de un Bien por rangos.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'BIEN_ALQUILER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de la Unidad Operativa' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Proveedor' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'CODIGO_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de Contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'NUMERO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción del Contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de adenda' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'NUMERO_ADENDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Tipo de Servicio' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_SERVICIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Tipo de Requerimiento' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_REQUERIMIENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Tipo de Documento: C=Contrato / A=Adenda' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicador versión oficial' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'INDICADOR_VERSION_OFICIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de Inicio del Contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'FECHA_INICIO_VIGENCIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de Finalización del Contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'FECHA_FIN_VIGENCIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de la moneda del contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'CODIGO_MONEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto del Contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'MONTO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto acumulado' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'MONTO_ACUMULADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Estado del Contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'CODIGO_ESTADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Plantilla con la cual se generó el contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'CODIGO_PLANTILLA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Contrato Principal. Aplica solo cuando es una Adenda.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_PRINCIPAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Estado de Edición: S=Solicitada, SA=Solicitud Autorizada, SD=Solicitud Denegada, E=Editada, EA=Edición Aprobada, ER=Edición Rechazada, AR=Apelar Rechazo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'CODIGO_ESTADO_EDICION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Texto en donde se explica lo que se desea modificar.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'COMENTARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Respuesta a la modificación de la solicitud' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'RESPUESTA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de flujo aprobación' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'CODIGO_FLUJO_APROBACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Estadio Actual.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'CODIGO_ESTADIO_ACTUAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla donde se almacenan los contratos' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_BIEN', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_BIEN', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del equipo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_BIEN', @level2type=N'COLUMN',@level2name=N'CODIGO_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_BIEN', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_BIEN', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_BIEN', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_BIEN', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_BIEN', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_BIEN', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_BIEN', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla detalle de Bienes por Contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Archivo en SharePoint' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'CODIGO_ARCHIVO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ruta de archivo sharepoint' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'RUTA_ARCHIVO_SHAREPOINT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contenido' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contenido' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'CONTENIDO_BUSQUEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si esta es la versión actual del contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'INDICADOR_ACTUAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de Versión del Documento' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'VERSION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de versiones de documentos generados.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_DOCUMENTO_ADJUNTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de archivo en sharePoint' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO', @level2type=N'COLUMN',@level2name=N'CODIGO_ARCHIVO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ruta de archivo sharepoint' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO', @level2type=N'COLUMN',@level2name=N'RUTA_ARCHIVO_SHAREPOINT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de documentos  generados.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de archivo en sharePoint' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION', @level2type=N'COLUMN',@level2name=N'CODIGO_ARCHIVO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ruta de archivo sharepoint' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION', @level2type=N'COLUMN',@level2name=N'RUTA_ARCHIVO_SHAREPOINT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de documentos  generados.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en que el contrato ingresa al estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'FECHA_INGRESO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en que se finaliza el estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'FECHA_FINALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de la persona que ejecutó el estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'CODIGO_RESPONSABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo de estado de contrato estadio' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'CODIGO_ESTADO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de la primera notificación' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'FECHA_PRIMERA_NOTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de la ultima notificación' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'FECHA_ULTIMA_NOTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de historia de flujo de aprobación.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_ESTADIO_CONSULTA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del estadio del contrato al que pertenece la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción de la observación.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que se registra la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'FECHA_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Párrafo Relacionado.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_PARRAFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Colaborador a quien se le envía la consulta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'DESTINATARIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción de la respuesta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'RESPUESTA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de Respuesta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'FECHA_RESPUESTA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Consultas por estadio de contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_CONSULTA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_ESTADIO_OBSERVACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del estadio del contrato al que pertenece la observación.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción de la observación.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que se registra la observación.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'FECHA_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Párrafo Relacionado' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_PARRAFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de archivo en sharePoint' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'CODIGO_ARCHIVO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ruta de archivo sharepoint' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'RUTA_ARCHIVO_SHAREPOINT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del estadio hacia donde es dirigido el contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'CODIGO_ESTADIO_RETORNO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Colaborador que realiza la observación.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'DESTINATARIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Tipo de Respuesta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_RESPUESTA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción de la respuesta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'RESPUESTA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de Respuesta.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'FECHA_RESPUESTA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Observaciones por estadio de contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_ESTADIO_OBSERVACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_HITO', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_HITO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_HITO', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Tipo de Hito' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_HITO', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_HITO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción del Hito' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_HITO', @level2type=N'COLUMN',@level2name=N'DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha límite para la ejecución del hito.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_HITO', @level2type=N'COLUMN',@level2name=N'FECHA_LIMITE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_HITO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_HITO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_HITO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_HITO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_HITO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_HITO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_HITO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de hitos por contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_HITO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_PARRAFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Párrafo de la Plantilla' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO', @level2type=N'COLUMN',@level2name=N'CODIGO_PLANTILLA_PARRAFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contenido del contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO', @level2type=N'COLUMN',@level2name=N'CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Párrafos del Contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_PARRAFO_VARIABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Contrato del Párrafo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_PARRAFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Variable' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'CODIGO_VARIABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor cuando la variable es tipo texto' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'VALOR_TEXTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor cuando la variable es tipo Número' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'VALOR_NUMERO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor cuando la variable es tipo Fecha' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'VALOR_FECHA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor cuando la variable es tipo Imagen' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'VALOR_IMAGEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor de Tabla' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'VALOR_TABLA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor de Tabla' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'VALOR_TABLA_EDITABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor de Bien' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'VALOR_BIEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor de Bien' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'VALOR_BIEN_EDITABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor Firmante' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'VALOR_FIRMANTE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor Firmante' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'VALOR_FIRMANTE_EDITABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor Lista' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'VALOR_LISTA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de variables por párrafo de contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_PARRAFO_VARIABLE_CAMPO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de la Variable del Párrafo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_PARRAFO_VARIABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Campo de la Variable' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'CODIGO_VARIABLE_CAMPO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de Fila del Campo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'NUMERO_FILA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor del campo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'VALOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de datos de campos tipo Lista' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'CONTRATO_PARRAFO_VARIABLE_CAMPO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION', @level2type=N'COLUMN',@level2name=N'CODIGO_FLUJO_APROBACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de unidad organizacional.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION', @level2type=N'COLUMN',@level2name=N'CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cabecera del Flujo de Aprobacion.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Flujo de Aprobación.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'CODIGO_FLUJO_APROBACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Orden de prioridad del estado dentro del flujo de aprobación.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción del Estadio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tiempo de atención en días' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'TIEMPO_ATENCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Horas de atención' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'HORAS_ATENCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicador de la versión oficial' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'INDICADOR_VERSION_OFICIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicador que permite la carga de archivos' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'INDICADOR_PERMITE_CARGA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicador del numero de contrato' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'INDICADOR_NUMERO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag para registrar' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO', @level2type=N'COLUMN',@level2name=N'FLAG_REGISTRAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla donde se configuran los Estadios del Flujo de Aprobación' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_PARTICIPANTE', @level2type=N'COLUMN',@level2name=N'CODIGO_FLUJO_APROBACION_PARTICIPANTE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Estadio del Flujo de Aprobación.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_PARTICIPANTE', @level2type=N'COLUMN',@level2name=N'CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Trabajador a quien se le informará sobre el flujo de aprobación.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_PARTICIPANTE', @level2type=N'COLUMN',@level2name=N'CODIGO_TRABAJADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de Participante: R=Responsable / I=Informado' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_PARTICIPANTE', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_PARTICIPANTE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_PARTICIPANTE', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_PARTICIPANTE', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_PARTICIPANTE', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_PARTICIPANTE', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_PARTICIPANTE', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_PARTICIPANTE', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_PARTICIPANTE', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Personas a quienes se les informará en el flujo de aprobaciones.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'FLUJO_APROBACION_PARTICIPANTE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA', @level2type=N'COLUMN',@level2name=N'CODIGO_PLANTILLA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción de la Plantilla' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA', @level2type=N'COLUMN',@level2name=N'DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Tipo de Servicio.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Tipo de Documento: C=Contrato / A=Adenda' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Estado de Vigencia: V=Vigente / H=Histórico.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA', @level2type=N'COLUMN',@level2name=N'CODIGO_ESTADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de Inicio de Vigencia' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA', @level2type=N'COLUMN',@level2name=N'FECHA_INICIO_VIGENCIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de Fin de Vigencia' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA', @level2type=N'COLUMN',@level2name=N'FECHA_FIN_VIGENCIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla cabecera de las plantillas de contratos.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO', @level2type=N'COLUMN',@level2name=N'CODIGO_PLANTILLA_PARRAFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de plantilla' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO', @level2type=N'COLUMN',@level2name=N'CODIGO_PLANTILLA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Orden en el que se debe colocar el párrafo en el contrato.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO', @level2type=N'COLUMN',@level2name=N'ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Título del Párrafo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO', @level2type=N'COLUMN',@level2name=N'TITULO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contenido del Párrafo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO', @level2type=N'COLUMN',@level2name=N'CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde dónde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla donde se almacenan los párrafos de las plantillas.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'CODIGO_PLANTILLA_PARRAFO_VARIABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Párrafo de la Plantilla' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'CODIGO_PLANTILLA_PARRAFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de la Variable' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'CODIGO_VARIABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Orden' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO_VARIABLE', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Variables por Párrafo de Plantilla' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PLANTILLA_PARRAFO_VARIABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'COLUMN',@level2name=N'CODIGO_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Identificación.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'COLUMN',@level2name=N'CODIGO_IDENTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'COLUMN',@level2name=N'NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre comercial (nombre corto) de la empresa.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'COLUMN',@level2name=N'NOMBRE_COMERCIAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de Documento (debe ser RUC).' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'COLUMN',@level2name=N'TIPO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de Documento (RUC).' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'COLUMN',@level2name=N'NUMERO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de proveedores que están registrados en Oracle.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'CODIGO_PROVEEDOR_ACUMULADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de proveedor' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'CODIGO_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de tipo de orden: OS / OC.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de tipo de moneda.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'CODIGO_MONEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto acumulado.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'MONTO_ACUMULADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de inicio del periodo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'FECHA_INICIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de fin del periodo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'FECHA_FIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicador limite alcanzado' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'INDICADOR_LIMITE_ALCANZADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicador notificado' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO', @level2type=N'COLUMN',@level2name=N'INDICADOR_NOTIFICADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla donde se acumula por proveedor.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ACUMULADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE', @level2type=N'COLUMN',@level2name=N'CODIGO_VARIABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la variable' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE', @level2type=N'COLUMN',@level2name=N'IDENTIFICADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de la Variable' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE', @level2type=N'COLUMN',@level2name=N'NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si se trata de una variable de sistema. Las variables del sistema están atadas a funcionalidades específicas y el usuario no las puede editar.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE', @level2type=N'COLUMN',@level2name=N'INDICADOR_VARIABLE_SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Tipo de Variable: T=Texto, N=Número, F=Fecha, I=Imagen, L=Lista, LE=Lista de Equipos.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si la variable aplica para todas las plantillas.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE', @level2type=N'COLUMN',@level2name=N'INDICADOR_GLOBAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de la plantilla a la que pertenece la variable. Solo aplica cuando el campo INDICADOR_GLOBAL = 0' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE', @level2type=N'COLUMN',@level2name=N'CODIGO_PLANTILLA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de variables de párrafos' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'CODIGO_VARIABLE_CAMPO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de variable a la que pertenece el campo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'CODIGO_VARIABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del campo' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Orden en el que se debe mostrar el campo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de alineamiento' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'TIPO_ALINEAMIENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tamanio de variable' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE_CAMPO', @level2type=N'COLUMN',@level2name=N'TAMANIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Columnas de Variables tipo Lista' , @level0type=N'SCHEMA',@level0name=N'CTR', @level1type=N'TABLE',@level1name=N'VARIABLE_CAMPO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'HST', @level1type=N'TABLE',@level1name=N'BIEN_REGISTRO', @level2type=N'COLUMN',@level2name=N'CODIGO_BIEN_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de tipo de contenido: NSR=Número de Serie, DSC=Descripción, MRC=Marca, MDL=Modelo' , @level0type=N'SCHEMA',@level0name=N'HST', @level1type=N'TABLE',@level1name=N'BIEN_REGISTRO', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contenido que se guardó como un atributo de un bien.' , @level0type=N'SCHEMA',@level0name=N'HST', @level1type=N'TABLE',@level1name=N'BIEN_REGISTRO', @level2type=N'COLUMN',@level2name=N'CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'HST', @level1type=N'TABLE',@level1name=N'BIEN_REGISTRO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'HST', @level1type=N'TABLE',@level1name=N'BIEN_REGISTRO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'HST', @level1type=N'TABLE',@level1name=N'BIEN_REGISTRO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'HST', @level1type=N'TABLE',@level1name=N'BIEN_REGISTRO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'HST', @level1type=N'TABLE',@level1name=N'BIEN_REGISTRO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'HST', @level1type=N'TABLE',@level1name=N'BIEN_REGISTRO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'HST', @level1type=N'TABLE',@level1name=N'BIEN_REGISTRO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Table que guarda el historial de descripciones de bienes registrados.' , @level0type=N'SCHEMA',@level0name=N'HST', @level1type=N'TABLE',@level1name=N'BIEN_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ruc de proveedor' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'ACUMULADO_PROVEEDOR', @level2type=N'COLUMN',@level2name=N'RUC_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código tipo de orden' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'ACUMULADO_PROVEEDOR', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de moneda' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'ACUMULADO_PROVEEDOR', @level2type=N'COLUMN',@level2name=N'CODIGO_MONEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto de proveedor' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'ACUMULADO_PROVEEDOR', @level2type=N'COLUMN',@level2name=N'MONTO_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'ACUMULADO_PROVEEDOR', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de acumulado proveedor' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'ACUMULADO_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo de unidad operativa' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATO_POR_VENCER', @level2type=N'COLUMN',@level2name=N'CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de contrato' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATO_POR_VENCER', @level2type=N'COLUMN',@level2name=N'NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de contrato' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATO_POR_VENCER', @level2type=N'COLUMN',@level2name=N'NUMERO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de documento' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATO_POR_VENCER', @level2type=N'COLUMN',@level2name=N'NUMERO_DOCUMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Proveedor de contrato' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATO_POR_VENCER', @level2type=N'COLUMN',@level2name=N'PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de vencimientó' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATO_POR_VENCER', @level2type=N'COLUMN',@level2name=N'FECHA_VENCIMIENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contenido de contrato' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATO_POR_VENCER', @level2type=N'COLUMN',@level2name=N'CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Emisor de contrato' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATO_POR_VENCER', @level2type=N'COLUMN',@level2name=N'EMISOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Asunto del contrato' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATO_POR_VENCER', @level2type=N'COLUMN',@level2name=N'ASUNTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Destinatario del contrato' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATO_POR_VENCER', @level2type=N'COLUMN',@level2name=N'DESTINATARIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Destinatario copia del contrato' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATO_POR_VENCER', @level2type=N'COLUMN',@level2name=N'DESTINATARIO_COPIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla contrato por vencer' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATO_POR_VENCER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo flujo aprobacion estadio' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_INFORMADOS', @level2type=N'COLUMN',@level2name=N'CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo de informado' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_INFORMADOS', @level2type=N'COLUMN',@level2name=N'CODIGO_INFORMADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de informado' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_INFORMADOS', @level2type=N'COLUMN',@level2name=N'NOMBRE_INFORMADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Correo de informado' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_INFORMADOS', @level2type=N'COLUMN',@level2name=N'CORREO_INFORMADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla Contratos informados' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_INFORMADOS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Row id' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_NOTIFICAR', @level2type=N'COLUMN',@level2name=N'ROW_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del proveedor' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_NOTIFICAR', @level2type=N'COLUMN',@level2name=N'NOMBRE_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del orden' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_NOTIFICAR', @level2type=N'COLUMN',@level2name=N'NOMBRE_ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de moneda' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_NOTIFICAR', @level2type=N'COLUMN',@level2name=N'NOMBRE_MONEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto de contrato' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_NOTIFICAR', @level2type=N'COLUMN',@level2name=N'MONTO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla contratos notificar' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_NOTIFICAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código flujo aprobación estadio' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_RETRASADOS', @level2type=N'COLUMN',@level2name=N'CODIGO_FLUJO_APROBACION_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código contrato estadio' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_RETRASADOS', @level2type=N'COLUMN',@level2name=N'CODIGO_CONTRATO_ESTADIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de contrato' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_RETRASADOS', @level2type=N'COLUMN',@level2name=N'NUMERO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de proveedor' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_RETRASADOS', @level2type=N'COLUMN',@level2name=N'NOMBRE_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del responsable' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_RETRASADOS', @level2type=N'COLUMN',@level2name=N'NOMBRE_RESPONSABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de unidad operativa' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_RETRASADOS', @level2type=N'COLUMN',@level2name=N'NOMBRE_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Correo del responsable' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_RETRASADOS', @level2type=N'COLUMN',@level2name=N'CORREO_RESPONSABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Asunto del contrato' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_RETRASADOS', @level2type=N'COLUMN',@level2name=N'ASUNTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contenido del contrato' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_RETRASADOS', @level2type=N'COLUMN',@level2name=N'CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Url del sistema' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_RETRASADOS', @level2type=N'COLUMN',@level2name=N'URL_SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Perfil del correo' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_RETRASADOS', @level2type=N'COLUMN',@level2name=N'PROFILE_CORREO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla contratos retrasados' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'CONTRATOS_RETRASADOS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Row id' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'INFORMACION_ENVIAR_CORREO', @level2type=N'COLUMN',@level2name=N'ROW_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Información ' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'INFORMACION_ENVIAR_CORREO', @level2type=N'COLUMN',@level2name=N'INFORMACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'INFORMACION_ENVIAR_CORREO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla Información enviar correo' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'INFORMACION_ENVIAR_CORREO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de moneda' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'MONTO_ACUMULADO_CONTRATO', @level2type=N'COLUMN',@level2name=N'CODIGO_MONEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto de contrato' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'MONTO_ACUMULADO_CONTRATO', @level2type=N'COLUMN',@level2name=N'MONTO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'MONTO_ACUMULADO_CONTRATO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla Monto acumulado de contrato' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'MONTO_ACUMULADO_CONTRATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ruc de proveedor' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ORDENES_COMPRA', @level2type=N'COLUMN',@level2name=N'RUC_PROVEEDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código tipo orden' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ORDENES_COMPRA', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de orden' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ORDENES_COMPRA', @level2type=N'COLUMN',@level2name=N'NUMERO_ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de orden' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ORDENES_COMPRA', @level2type=N'COLUMN',@level2name=N'FECHA_ORDEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de moneda' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ORDENES_COMPRA', @level2type=N'COLUMN',@level2name=N'CODIGOMONEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ORDENES_COMPRA', @level2type=N'COLUMN',@level2name=N'MONTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ORDENES_COMPRA', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla Proveedor de Ordenes de Compra' , @level0type=N'SCHEMA',@level0name=N'TMP', @level1type=N'TABLE',@level1name=N'PROVEEDOR_ORDENES_COMPRA'
GO
USE [master]
GO
ALTER DATABASE [STRACON_SGC] SET  READ_WRITE 
GO
