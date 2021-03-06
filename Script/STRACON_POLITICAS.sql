USE [master]
GO
/****** Object:  Database [STRACON_POLITICAS]    Script Date: 25/02/2020 18:01:43 ******/
CREATE DATABASE [STRACON_POLITICAS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'STRACON_POLITICAS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\STRACON_POLITICAS.mdf' , SIZE = 16384KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [FIRMAS] 
( NAME = N'STRACON_POLITICAS_FIRMAS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\STRACON_POLITICAS_FIRMAS.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'STRACON_POLITICAS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\STRACON_POLITICAS_log.ldf' , SIZE = 24384KB , MAXSIZE = 2048GB , FILEGROWTH = 1024KB )
GO
ALTER DATABASE [STRACON_POLITICAS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [STRACON_POLITICAS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [STRACON_POLITICAS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET ARITHABORT OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [STRACON_POLITICAS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [STRACON_POLITICAS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [STRACON_POLITICAS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [STRACON_POLITICAS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [STRACON_POLITICAS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [STRACON_POLITICAS] SET  MULTI_USER 
GO
ALTER DATABASE [STRACON_POLITICAS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [STRACON_POLITICAS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [STRACON_POLITICAS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [STRACON_POLITICAS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'STRACON_POLITICAS', N'ON'
GO
USE [STRACON_POLITICAS]
GO
/****** Object:  User [USR_STRACON_SGC]    Script Date: 25/02/2020 18:01:44 ******/
CREATE USER [USR_STRACON_SGC] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [USR_STRACON_SCC]    Script Date: 25/02/2020 18:01:44 ******/
CREATE USER [USR_STRACON_SCC] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [USR_STRACON_POLITICAS]    Script Date: 25/02/2020 18:01:44 ******/
CREATE USER [USR_STRACON_POLITICAS] FOR LOGIN [USR_STRACON_POLITICAS] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [user_onlyreadbusiness]    Script Date: 25/02/2020 18:01:44 ******/
CREATE USER [user_onlyreadbusiness] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [user_onlyread]    Script Date: 25/02/2020 18:01:44 ******/
CREATE USER [user_onlyread] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [USR_STRACON_SGC]
GO
ALTER ROLE [db_datareader] ADD MEMBER [USR_STRACON_SGC]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [USR_STRACON_SGC]
GO
ALTER ROLE [db_owner] ADD MEMBER [USR_STRACON_SCC]
GO
ALTER ROLE [db_owner] ADD MEMBER [USR_STRACON_POLITICAS]
GO
ALTER ROLE [db_datareader] ADD MEMBER [USR_STRACON_POLITICAS]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [USR_STRACON_POLITICAS]
GO
ALTER ROLE [db_datareader] ADD MEMBER [user_onlyreadbusiness]
GO
ALTER ROLE [db_datareader] ADD MEMBER [user_onlyread]
GO
/****** Object:  Schema [GRL]    Script Date: 25/02/2020 18:01:44 ******/
CREATE SCHEMA [GRL]
GO
/****** Object:  UserDefinedTableType [dbo].[LISTA_GUID_TYPE]    Script Date: 25/02/2020 18:01:44 ******/
CREATE TYPE [dbo].[LISTA_GUID_TYPE] AS TABLE(
	[CODIGO] [uniqueidentifier] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[LISTA_NVARCHAR_TYPE]    Script Date: 25/02/2020 18:01:44 ******/
CREATE TYPE [dbo].[LISTA_NVARCHAR_TYPE] AS TABLE(
	[VALOR] [nvarchar](max) NULL
)
GO
/****** Object:  StoredProcedure [GRL].[USP_CORREOS_SUPLENTE_DTS_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_CORREOS_SUPLENTE_DTS_SEL]
AS

/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_CORREOS_SUPLENTE_DTS_SEL
Propósito: Retorna los correos de los suplentes para el envío de la notificación
Descripción de Parámetros: 
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	DECLARE	@CODIGO_SISTEMA UNIQUEIDENTIFIER
	DECLARE @URL_SISTEMA VARCHAR(200)

		SELECT	@CODIGO_SISTEMA = CODIGO_SISTEMA
		FROM	GRL.SISTEMA
		WHERE	CODIGO_IDENTIFICADOR = 'SGC'
		AND           ESTADO_REGISTRO = '1'

		SET @URL_SISTEMA = (SELECT	VALOR
		FROM	GRL.FN_LISTAR_VALORES_PARAMETRO('STR',1,'SGC','00035',3)
		WHERE	CODIGO = 'SGC')

	DECLARE @FECHA_ACTUAL DATETIME = CAST(GETDATE() AS DATE)
    DECLARE
         @ASUNTO NVARCHAR(255) = (SELECT ASUNTO FROM GRL.PLANTILLA_NOTIFICACION WHERE CODIGO_TIPO_NOTIFICACION = '10'
		AND          CODIGO_SISTEMA = @CODIGO_SISTEMA
		AND	ESTADO_REGISTRO = '1')
       , @CONTENIDO NVARCHAR(MAX) = (SELECT CONTENIDO FROM GRL.PLANTILLA_NOTIFICACION WHERE CODIGO_TIPO_NOTIFICACION = '10'
		AND          CODIGO_SISTEMA = @CODIGO_SISTEMA
		AND	ESTADO_REGISTRO = '1')

	SELECT   
		SUPLENTE.CORREO_ELECTRONICO
		,@ASUNTO AS ASUNTO
		,REPLACE(
		 REPLACE(
		 REPLACE(
		 REPLACE(
		 REPLACE(@CONTENIDO,'@suplente',ISNULL(SUPLENTE.NOMBRE_COMPLETO,'')),
		'@trabajador',ISNULL(TRABAJADOR.NOMBRE_COMPLETO,'')),
		'@fecha_inicio',ISNULL(CONVERT(CHAR(10), TS.FECHA_INICIO, 103),'')),
		'@fecha_fin',ISNULL(CONVERT(CHAR(10), TS.FECHA_FIN, 103),'')),
		'@url_opcion_sistema',ISNULL(@URL_SISTEMA,'')) CONTENIDO
		FROM [GRL].[TRABAJADOR_SUPLENTE] TS
		INNER JOIN [GRL].TRABAJADOR TRABAJADOR ON TRABAJADOR.CODIGO_TRABAJADOR = TS.CODIGO_TRABAJADOR
		INNER JOIN [GRL].TRABAJADOR SUPLENTE ON SUPLENTE.CODIGO_TRABAJADOR = TS.CODIGO_SUPLENTE
		WHERE 
		CAST(TS.FECHA_INICIO AS DATE) <= @FECHA_ACTUAL AND CAST(FECHA_FIN AS DATE) >= @FECHA_ACTUAL AND (TS.EJECUTADO IS NULL OR TS.EJECUTADO = 0)
		AND TS.ACTIVO = 1 AND TS.ESTADO_REGISTRO = 1
END;

GO
/****** Object:  StoredProcedure [GRL].[USP_CORREOS_SUPLENTE2_DTS_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_CORREOS_SUPLENTE2_DTS_SEL]
AS

/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_CORREOS_SUPLENTE_DTS_SEL
Propósito: Retorna los correos de los suplentes para el envío de la notificación
Descripción de Parámetros: 
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
		DECLARE	@CODIGO_SISTEMA UNIQUEIDENTIFIER
		DECLARE @URL_SISTEMA VARCHAR(200)

		SELECT	@CODIGO_SISTEMA = CODIGO_SISTEMA
		FROM	GRL.SISTEMA
		WHERE	CODIGO_IDENTIFICADOR = 'SGC'
		AND           ESTADO_REGISTRO = '1'

		SET @URL_SISTEMA = (SELECT	VALOR
		FROM	GRL.FN_LISTAR_VALORES_PARAMETRO('STR',1,'SGC','00035',3)
		WHERE	CODIGO = 'SGC')

	DECLARE @FECHA_ACTUAL DATETIME = CAST(GETDATE() AS DATE)
    DECLARE
         @ASUNTO NVARCHAR(255) = (SELECT ASUNTO FROM GRL.PLANTILLA_NOTIFICACION WHERE CODIGO_TIPO_NOTIFICACION = '12'
		AND          CODIGO_SISTEMA = @CODIGO_SISTEMA
		AND	ESTADO_REGISTRO = '1')
       , @CONTENIDO NVARCHAR(MAX) = (SELECT CONTENIDO FROM GRL.PLANTILLA_NOTIFICACION WHERE CODIGO_TIPO_NOTIFICACION = '12'
		AND          CODIGO_SISTEMA = @CODIGO_SISTEMA
		AND	ESTADO_REGISTRO = '1')
	SELECT   
		SUPLENTE.CORREO_ELECTRONICO
		,@ASUNTO AS ASUNTO
		,REPLACE(
		 REPLACE(
		 REPLACE(
		 REPLACE(
		 REPLACE(@CONTENIDO,'@suplente',ISNULL(SUPLENTE.NOMBRE_COMPLETO,'')),
		'@trabajador',ISNULL(TRABAJADOR.NOMBRE_COMPLETO,'')),
		'@fecha_inicio',ISNULL(CONVERT(CHAR(10), TS.FECHA_INICIO, 103),'')),
		'@fecha_fin',ISNULL(CONVERT(CHAR(10), TS.FECHA_FIN, 103),'')),
		'@url_opcion_sistema',ISNULL(@URL_SISTEMA,'')) CONTENIDO
		FROM [GRL].[TRABAJADOR_SUPLENTE] TS
		INNER JOIN [GRL].TRABAJADOR TRABAJADOR ON TRABAJADOR.CODIGO_TRABAJADOR = TS.CODIGO_TRABAJADOR
		INNER JOIN [GRL].TRABAJADOR SUPLENTE ON SUPLENTE.CODIGO_TRABAJADOR = TS.CODIGO_SUPLENTE
		WHERE 
		CAST(FECHA_INICIO AS DATE) <= @FECHA_ACTUAL AND CAST(FECHA_FIN AS DATE) < @FECHA_ACTUAL AND EJECUTADO = 1
		--AND TS.ACTIVO = 1 
		AND TS.ESTADO_REGISTRO = 1
END;

GO
/****** Object:  StoredProcedure [GRL].[USP_CORREOS_TRABAJADOR_DTS_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_CORREOS_TRABAJADOR_DTS_SEL]
AS

/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_CORREOS_TRABAJADOR_DTS_SEL
Propósito: Retorna los correos de los trabajadores para el envío de la notificación
Descripción de Parámetros: 
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
		DECLARE	@CODIGO_SISTEMA UNIQUEIDENTIFIER
		DECLARE @URL_SISTEMA VARCHAR(200)

		SELECT	@CODIGO_SISTEMA = CODIGO_SISTEMA
		FROM	GRL.SISTEMA
		WHERE	CODIGO_IDENTIFICADOR = 'SGC'
		AND           ESTADO_REGISTRO = '1'


		SET @URL_SISTEMA = (SELECT	VALOR
		FROM	GRL.FN_LISTAR_VALORES_PARAMETRO('STR',1,'SGC','00035',3)
		WHERE	CODIGO = 'SGC')

	DECLARE @FECHA_ACTUAL DATETIME = CAST(GETDATE() AS DATE)
    DECLARE
         @ASUNTO NVARCHAR(255) = (SELECT ASUNTO FROM GRL.PLANTILLA_NOTIFICACION WHERE CODIGO_TIPO_NOTIFICACION = '09'
		AND          CODIGO_SISTEMA = @CODIGO_SISTEMA
		AND	ESTADO_REGISTRO = '1')
       , @CONTENIDO NVARCHAR(MAX) = (SELECT CONTENIDO FROM GRL.PLANTILLA_NOTIFICACION WHERE CODIGO_TIPO_NOTIFICACION = '09'
		AND          CODIGO_SISTEMA = @CODIGO_SISTEMA
		AND	ESTADO_REGISTRO = '1')

	SELECT   
		TRABAJADOR.CORREO_ELECTRONICO
		,@ASUNTO AS ASUNTO
		,REPLACE(
		 REPLACE(
		 REPLACE(
		 REPLACE(
		 REPLACE(@CONTENIDO,'@trabajador',ISNULL(TRABAJADOR.NOMBRE_COMPLETO,'')),
		'@suplente',ISNULL(SUPLENTE.NOMBRE_COMPLETO,'')),
		'@fecha_inicio',ISNULL(CONVERT(CHAR(10), TS.FECHA_INICIO, 103),'')),
		'@fecha_fin',ISNULL(CONVERT(CHAR(10), TS.FECHA_FIN, 103),'')),
		'@url_opcion_sistema',ISNULL(@URL_SISTEMA,'')) CONTENIDO
		FROM [GRL].[TRABAJADOR_SUPLENTE] TS
		INNER JOIN [GRL].TRABAJADOR TRABAJADOR ON TRABAJADOR.CODIGO_TRABAJADOR = TS.CODIGO_TRABAJADOR
		INNER JOIN [GRL].TRABAJADOR SUPLENTE ON SUPLENTE.CODIGO_TRABAJADOR = TS.CODIGO_SUPLENTE
		WHERE 
		CAST(TS.FECHA_INICIO AS DATE) <= @FECHA_ACTUAL AND CAST(FECHA_FIN AS DATE) >= @FECHA_ACTUAL AND (TS.EJECUTADO IS NULL OR TS.EJECUTADO = 0)
		AND TS.ACTIVO = 1 AND TS.ESTADO_REGISTRO = 1
END;


GO
/****** Object:  StoredProcedure [GRL].[USP_CORREOS_TRABAJADOR2_DTS_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_CORREOS_TRABAJADOR2_DTS_SEL]
AS

/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_CORREOS_TRABAJADOR_DTS_SEL
Propósito: Retorna los correos de los trabajadores para el envío de la notificación
Descripción de Parámetros: 
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	DECLARE	@CODIGO_SISTEMA UNIQUEIDENTIFIER
	DECLARE @URL_SISTEMA VARCHAR(200)

		SELECT	@CODIGO_SISTEMA = CODIGO_SISTEMA
		FROM	GRL.SISTEMA
		WHERE	CODIGO_IDENTIFICADOR = 'SGC'
		AND           ESTADO_REGISTRO = '1'

		SET @URL_SISTEMA = (SELECT	VALOR
		FROM	GRL.FN_LISTAR_VALORES_PARAMETRO('STR',1,'SGC','00035',3)
		WHERE	CODIGO = 'SGC')

	DECLARE @FECHA_ACTUAL DATETIME = CAST(GETDATE() AS DATE)
    DECLARE
         @ASUNTO NVARCHAR(255) = (SELECT ASUNTO FROM GRL.PLANTILLA_NOTIFICACION WHERE CODIGO_TIPO_NOTIFICACION = '11'
		AND          CODIGO_SISTEMA = @CODIGO_SISTEMA
		AND	ESTADO_REGISTRO = '1')
       , @CONTENIDO NVARCHAR(MAX) = (SELECT CONTENIDO FROM GRL.PLANTILLA_NOTIFICACION WHERE CODIGO_TIPO_NOTIFICACION = '11'
		AND          CODIGO_SISTEMA = @CODIGO_SISTEMA
		AND	ESTADO_REGISTRO = '1')
	SELECT   
		TRABAJADOR.CORREO_ELECTRONICO
		,@ASUNTO AS ASUNTO
		,REPLACE(
		 REPLACE(
		 REPLACE(
		 REPLACE(
		 REPLACE(@CONTENIDO,'@trabajador',ISNULL(TRABAJADOR.NOMBRE_COMPLETO,'')),
		'@suplente',ISNULL(SUPLENTE.NOMBRE_COMPLETO,'')),
		'@fecha_inicio',ISNULL(CONVERT(CHAR(10), TS.FECHA_INICIO, 103),'')),
		'@fecha_fin',ISNULL(CONVERT(CHAR(10), TS.FECHA_FIN, 103),'')),
		'@url_opcion_sistema',ISNULL(@URL_SISTEMA,'')) CONTENIDO
		FROM [GRL].[TRABAJADOR_SUPLENTE] TS
		INNER JOIN [GRL].TRABAJADOR TRABAJADOR ON TRABAJADOR.CODIGO_TRABAJADOR = TS.CODIGO_TRABAJADOR
		INNER JOIN [GRL].TRABAJADOR SUPLENTE ON SUPLENTE.CODIGO_TRABAJADOR = TS.CODIGO_SUPLENTE
		WHERE 
		CAST(FECHA_INICIO AS DATE) <= @FECHA_ACTUAL AND CAST(FECHA_FIN AS DATE) < @FECHA_ACTUAL AND EJECUTADO = 1
		--AND TS.ACTIVO = 1 
		AND TS.ESTADO_REGISTRO = 1
END;

GO
/****** Object:  StoredProcedure [GRL].[USP_ENVIO_CORREO_DTS_SUPLENTE_POR_TRABAJADOR_SUPL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--drop proc USP_ENVIO_CORREO_DTS_SUPLENTE_POR_TRABAJADOR_TRAB
CREATE PROCEDURE [GRL].[USP_ENVIO_CORREO_DTS_SUPLENTE_POR_TRABAJADOR_SUPL]
-- 1 store para envio de trabajadores
AS
BEGIN
    DECLARE @DESTINATARIO        NVARCHAR(MAX)
    DECLARE @ASUNTO                NVARCHAR(MAX)
    DECLARE @CONTENIDO            NVARCHAR(MAX)
    DECLARE @FILA                INT

    SET LANGUAGE    spanish;
    SET DATEFORMAT  dmy;

        --Creamos el rownumber para la lista de correo y lo guardamos en un temporal
            SELECT
                       ROW_NUMBER() OVER (Order by CORREO_ELECTRONICO) AS RowNumber,
                       ASUNTO,
                       CORREO_ELECTRONICO,            
                       CONTENIDO
            INTO    #TMP_DATA_CORREO
            FROM    GRL.TMP_ENVIAR_CORREOS_SUPLENTE_TRABAJADOR_SUPL

        --Declaramos las variables para recorrer la lista.
        DECLARE @LoopCounter INT = 1, @Max INT = (SELECT COUNT(RowNumber) FROM #TMP_DATA_CORREO)

        WHILE    (@LoopCounter <= @Max )
            BEGIN
                SELECT    
                        @FILA            = RowNumber,
                        @DESTINATARIO    = CORREO_ELECTRONICO,
                        @ASUNTO            = ASUNTO,
                        @CONTENIDO        = CONTENIDO
                FROM #TMP_DATA_CORREO
                WHERE RowNumber = @LoopCounter
                ORDER BY RowNumber ASC

                SET @LoopCounter = @LoopCounter + 1

                WAITFOR DELAY '00:00:05';
                EXEC    [MSDB].[DBO].[SP_SEND_DBMAIL]    @PROFILE_NAME        =  'SISTEMA SGC',
                                                        @RECIPIENTS            =  @DESTINATARIO,
                                                        @BODY                =  @CONTENIDO,
                                                        @COPY_RECIPIENTS     =  '',
                                                        @BODY_FORMAT           =  'html',
                                                        @SUBJECT            =   @ASUNTO,
                                                        @IMPORTANCE         =   'High'

            END
END
GO
/****** Object:  StoredProcedure [GRL].[USP_ENVIO_CORREO_DTS_SUPLENTE_POR_TRABAJADOR_TRAB]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [GRL].[USP_ENVIO_CORREO_DTS_SUPLENTE_POR_TRABAJADOR_TRAB] 
-- 1 store para envio de trabajadores
AS
BEGIN
    DECLARE @DESTINATARIO        NVARCHAR(MAX)
    DECLARE @ASUNTO                NVARCHAR(MAX)
    DECLARE @CONTENIDO            NVARCHAR(MAX)
    DECLARE @FILA                INT

    SET LANGUAGE    spanish;
    SET DATEFORMAT  dmy;

        --Creamos el rownumber para la lista de correo y lo guardamos en un temporal
            SELECT
                       ROW_NUMBER() OVER (Order by CORREO_ELECTRONICO) AS RowNumber,
                       ASUNTO,
                       CORREO_ELECTRONICO,            
                       CONTENIDO
            INTO    #TMP_DATA_CORREO
            FROM    GRL.TMP_ENVIAR_CORREOS_SUPLENTE_TRABAJADOR

        --Declaramos las variables para recorrer la lista.
        DECLARE @LoopCounter INT = 1, @Max INT = (SELECT COUNT(RowNumber) FROM #TMP_DATA_CORREO)

        WHILE    (@LoopCounter <= @Max )
            BEGIN
                SELECT    
                        @FILA            = RowNumber,
                        @DESTINATARIO    = CORREO_ELECTRONICO,
                        @ASUNTO            = ASUNTO,
                        @CONTENIDO        = CONTENIDO
                FROM #TMP_DATA_CORREO
                WHERE RowNumber = @LoopCounter
                ORDER BY RowNumber ASC

                SET @LoopCounter = @LoopCounter + 1

                WAITFOR DELAY '00:00:05';
                EXEC    [MSDB].[DBO].[SP_SEND_DBMAIL]    @PROFILE_NAME        =  'SISTEMA SGC',
                                                        @RECIPIENTS            =  @DESTINATARIO,
                                                        @BODY                =  @CONTENIDO,
                                                        @COPY_RECIPIENTS     =  '',
                                                        @BODY_FORMAT           =  'html',
                                                        @SUBJECT            =   @ASUNTO,
                                                        @IMPORTANCE         =   'High'

            END
END
GO
/****** Object:  StoredProcedure [GRL].[USP_ENVIO_CORREO_DTS_TRABAJADOR_POR_SUPLENTE_SUP]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_ENVIO_CORREO_DTS_TRABAJADOR_POR_SUPLENTE_SUP]
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
						ROW_NUMBER() OVER (Order by DESTINATARIO) AS RowNumber,
        				DESTINATARIO,
						ASUNTO,
						CONTENIDO
			INTO	#TMP_ENVIAR_CORREOS_TRABAJADOR_POR_SUPLENTE_SUP
			FROM    GRL.TMP_ENVIAR_CORREOS_TRABAJADOR_POR_SUPLENTE_SUP

		--Declaramos las variables para recorrer la lista.
		DECLARE @LoopCounter INT = 1, @Max INT = (SELECT COUNT(RowNumber) FROM #TMP_ENVIAR_CORREOS_TRABAJADOR_POR_SUPLENTE_SUP)

		WHILE	(@LoopCounter <= @Max )
			BEGIN
				SELECT	
						@FILA			= RowNumber,
						@DESTINATARIO	= DESTINATARIO,
						@ASUNTO			= ASUNTO,
						@CONTENIDO		= CONTENIDO
				FROM #TMP_ENVIAR_CORREOS_TRABAJADOR_POR_SUPLENTE_SUP
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
/****** Object:  StoredProcedure [GRL].[USP_ENVIO_CORREO_DTS_TRABAJADOR_POR_SUPLENTE_TRAB]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_ENVIO_CORREO_DTS_TRABAJADOR_POR_SUPLENTE_TRAB]
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
						ROW_NUMBER() OVER (Order by DESTINATARIO) AS RowNumber,
        				DESTINATARIO,
						ASUNTO,
						CONTENIDO
			INTO	#TMP_ENVIAR_CORREOS_TRABAJADOR_POR_SUPLENTE_TRAB
			FROM    GRL.TMP_ENVIAR_CORREOS_TRABAJADOR_POR_SUPLENTE_TRAB

		--Declaramos las variables para recorrer la lista.
		DECLARE @LoopCounter INT = 1, @Max INT = (SELECT COUNT(RowNumber) FROM #TMP_ENVIAR_CORREOS_TRABAJADOR_POR_SUPLENTE_TRAB)

		WHILE	(@LoopCounter <= @Max )
			BEGIN
				SELECT	
						@FILA			= RowNumber,
						@DESTINATARIO	= DESTINATARIO,
						@ASUNTO			= ASUNTO,
						@CONTENIDO		= CONTENIDO
				FROM #TMP_ENVIAR_CORREOS_TRABAJADOR_POR_SUPLENTE_TRAB
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
/****** Object:  StoredProcedure [GRL].[USP_NOTIFICAR_CALENDARIZACION]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [GRL].[USP_NOTIFICAR_CALENDARIZACION]
	@CODIGOS_TRABAJADORES	LISTA_GUID_TYPE READONLY,
	@CODIGO_NOTIFICACION	NVARCHAR(10),
	@ANIO_PERIODO			NVARCHAR(4),
	@MES_PERIODO			NVARCHAR(30),
	@NOMBRE_ACTIVIDAD		NVARCHAR(255),
	@CODIGO_SISTEMA			UNIQUEIDENTIFIER,
	@PROFILE_CORREO			NVARCHAR(100)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_NOTIFICAR_CALENDARIZACION
Propósito: Notifica Calendarizaciones
Descripción de Parámetros: 
		@CODIGOS_TRABAJADORES:	Parámetro de entrada de tipo LISTA_GUID_TYPE, que representa codigos trabajadores.
		@CODIGO_NOTIFICACION:	Parámetro de entrada de tipo nvarchar, que representa codigo notificacion.
		@ANIO_PERIODO:	Parámetro de entrada de tipo nvarchar, que representa anio periodo.
		@MES_PERIODO:	Parámetro de entrada de tipo nvarchar, que representa mes periodo.
		@NOMBRE_ACTIVIDAD:	Parámetro de entrada de tipo nvarchar, que representa nombre actividad.
		@CODIGO_SISTEMA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo sistema.
		@PROFILE_CORREO:	Parámetro de entrada de tipo nvarchar, que representa profile correo.
Creado por: GMD
Fecha. Creación: 2015-07-17
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN	
	DECLARE @Asunto				NVARCHAR(MAX), 
			@Contenido			NVARCHAR(MAX),
			@NombreParticipante NVARCHAR(255),
			@CuentaCorreo		NVARCHAR(50),
			@RowMin				SMALLINT , 
			@RowMax				SMALLINT,
			@NewContenido		NVARCHAR(MAX)

	SELECT @NOMBRE_ACTIVIDAD		=	ISNULL(@NOMBRE_ACTIVIDAD,'')

	SELECT  RowID					=	ROW_NUMBER() OVER (ORDER BY GT.CODIGO_TRABAJADOR) ,  
			NombreParticipante		=	GT.NOMBRE_COMPLETO, 
			CuentaCorreo			=	GT.CORREO_ELECTRONICO 
	INTO	#TEMP_Trabajadores_Notificar
	FROM	GRL.TRABAJADOR GT (NOLOCK) 
	INNER JOIN @CODIGOS_TRABAJADORES CT 
		ON	GT.CODIGO_TRABAJADOR	= CT.CODIGO
	WHERE	GT.ESTADO_REGISTRO		=	'1'

	SELECT	@Asunto					=	ASUNTO, 
			@Contenido				=	CONTENIDO
	FROM	GRL.PLANTILLA_NOTIFICACION (NOLOCK) 
	WHERE	CODIGO_SISTEMA			=	@CODIGO_SISTEMA 
	AND		CODIGO_TIPO_NOTIFICACION=	@CODIGO_NOTIFICACION 
	AND		ESTADO_REGISTRO			=	'1'
	
	SELECT	@RowMin = MIN(RowID), 
			@RowMax = MAX(RowID) 
	FROM	#TEMP_Trabajadores_Notificar
	
	WHILE @RowMin <= @RowMax BEGIN
			SELECT @NewContenido	= REPLACE(@Contenido,'@nombre_participante',NombreParticipante),
					@CuentaCorreo	= CuentaCorreo
			FROM	#TEMP_Trabajadores_Notificar  
			WHERE	RowID			= @RowMin
										
			SELECT @NewContenido = REPLACE(@NewContenido,'@mes_periodo',@MES_PERIODO)			
			SELECT @NewContenido = REPLACE(@NewContenido,'@anio_periodo',@ANIO_PERIODO)
			SELECT @NewContenido = REPLACE(@NewContenido,'@actividad',@NOMBRE_ACTIVIDAD)			
			--/* Prioridad: High,	Normal,Low */
			IF LEN(@CuentaCorreo)>0 AND CHARINDEX('@',@CuentaCorreo,0)>0 BEGIN
					EXEC [msdb].[dbo].[sp_send_dbmail]	@profile_name	= @PROFILE_CORREO, 
														@recipients		= @CuentaCorreo, 
														@body			= @NewContenido,
														@body_format	='html', 
														@subject		= @Asunto, 
														@importance		= 'High';				
			END
			SELECT @NewContenido='', @CuentaCorreo='', @RowMin +=1
	END	
	DROP TABLE #TEMP_Trabajadores_Notificar
	SELECT 1
END


GO
/****** Object:  StoredProcedure [GRL].[USP_PARAMETRO_SECCION_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_PARAMETRO_SECCION_SEL]
(
	@CODIGO_PARAMETRO				INT,	
	@CODIGO_SECCION					INT,
	@NOMBRE							NVARCHAR(255),
	@CODIGO_TIPO_DATO				CHAR(5),
	@INDICADOR_PERMITE_MODIFICAR	BIT,
	@INDICADOR_OBLIGATORIO			BIT,
	@INDICADOR_SISTEMA				BIT,
	@ESTADO_REGISTRO				CHAR(1)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_PARAMETRO_SECCION_SEL
Propósito: Retorna registros de la tabla Parametro_seccion
Descripción de Parámetros: 
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@CODIGO_SECCION:	Parámetro de entrada de tipo int, que representa codigo seccion.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@CODIGO_TIPO_DATO:	Parámetro de entrada de tipo char, que representa codigo tipo dato.
		@INDICADOR_PERMITE_MODIFICAR:	Parámetro de entrada de tipo bit, que representa indicador permite modificar.
		@INDICADOR_OBLIGATORIO:	Parámetro de entrada de tipo bit, que representa indicador obligatorio.
		@INDICADOR_SISTEMA:	Parámetro de entrada de tipo bit, que representa indicador sistema.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
DECLARE
@V_ESTADO_REGISTRO_RELACION			CHAR(1)

SET @V_ESTADO_REGISTRO_RELACION = '1'
BEGIN
	SELECT	PS.CODIGO_PARAMETRO							AS CodigoParametro,
			PS.CODIGO_SECCION							AS CodigoSeccion,
			PS.NOMBRE									AS Nombre,
			PS.INDICADOR_PERMITE_MODIFICAR				AS IndicadorPermiteModificar,
			PS.INDICADOR_OBLIGATORIO					AS IndicadorObligatorio,
			PS.INDICADOR_SISTEMA						AS IndicadorSistema,
			PS.CODIGO_TIPO_DATO							AS CodigoTipoDato,
			TD.NOMBRE									AS DescripcionTipoDato,
			PS.CODIGO_PARAMETRO_RELACIONADO				AS CodigoParametroRelacionado,
			PAREL.NOMBRE								AS NombreParametroRelacionado,
			PS.CODIGO_SECCION_RELACIONADO				AS CodigoSeccionRelacionado,
			PSREL.NOMBRE								AS NombreSeccionRelacionado,
			PS.CODIGO_SECCION_RELACIONADO_MOSTRAR		AS CodigoSeccionRelacionadoMostrar,
			PSRELMO.NOMBRE								AS NombreSeccionRelacionadoMostrar,
			PS.ESTADO_REGISTRO							AS EstadoRegistro
	FROM GRL.PARAMETRO_SECCION PS
	INNER JOIN GRL.PARAMETRO PA ON PS.CODIGO_PARAMETRO = PA.CODIGO_PARAMETRO AND PA.ESTADO_REGISTRO = '1'
	INNER JOIN GRL.TIPO_DATO TD ON TD.CODIGO_TIPO_DATO = PS.CODIGO_TIPO_DATO AND TD.ESTADO_REGISTRO = '1'
	LEFT JOIN GRL.PARAMETRO PAREL ON PAREL.CODIGO_PARAMETRO = PS.CODIGO_PARAMETRO_RELACIONADO AND PAREL.ESTADO_REGISTRO = '1'
	LEFT JOIN GRL.PARAMETRO_SECCION PSREL ON PSREL.CODIGO_PARAMETRO = PAREL.CODIGO_PARAMETRO AND PSREL.CODIGO_SECCION = PS.CODIGO_SECCION_RELACIONADO AND PSREL.ESTADO_REGISTRO = '1'
	LEFT JOIN GRL.PARAMETRO_SECCION PSRELMO ON PSRELMO.CODIGO_PARAMETRO = PAREL.CODIGO_PARAMETRO AND PSRELMO.CODIGO_SECCION = PS.CODIGO_SECCION_RELACIONADO_MOSTRAR AND PSRELMO.ESTADO_REGISTRO = '1'
	WHERE (@CODIGO_PARAMETRO			IS NULL		OR PA.CODIGO_PARAMETRO				= @CODIGO_PARAMETRO)	
	AND	(@CODIGO_SECCION				IS NULL		OR PS.CODIGO_SECCION				= @CODIGO_SECCION)
	AND (@NOMBRE						IS NULL		OR PS.NOMBRE						= @NOMBRE)
	AND (@CODIGO_TIPO_DATO				IS NULL		OR PS.CODIGO_TIPO_DATO				= @CODIGO_TIPO_DATO)
	AND (@INDICADOR_PERMITE_MODIFICAR	IS NULL		OR PS.INDICADOR_PERMITE_MODIFICAR	= @INDICADOR_PERMITE_MODIFICAR)
	AND (@INDICADOR_OBLIGATORIO			IS NULL		OR PS.INDICADOR_OBLIGATORIO			= @INDICADOR_OBLIGATORIO)
	AND (@INDICADOR_SISTEMA				IS NULL		OR PS.INDICADOR_SISTEMA				= @INDICADOR_SISTEMA)
	AND (@ESTADO_REGISTRO				IS NULL		OR PS.ESTADO_REGISTRO				= @ESTADO_REGISTRO)
END

GO
/****** Object:  StoredProcedure [GRL].[USP_PARAMETRO_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_PARAMETRO_SEL]
(
	@CODIGO_PARAMETRO				INT,
	@INDICADOR_EMPRESA				BIT,
	@CODIGO_EMPRESA					UNIQUEIDENTIFIER,
	@CODIGO_SISTEMA					UNIQUEIDENTIFIER,	
	@CODIGO_IDENTIFICADOR			CHAR(5),
	@TIPO_PARAMETRO					CHAR(1),	
	@NOMBRE							NVARCHAR(255),
	@DESCRIPCION					NVARCHAR(255),
	@INDICADOR_PERMITE_AGREGAR		BIT,
	@INDICADOR_PERMITE_MODIFICAR	BIT,
	@INDICADOR_PERMITE_ELIMINAR		BIT,	
	@ESTADO_REGISTRO				CHAR(1)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_PARAMETRO_SEL
Propósito: Retorna registros de la tabla Parametro
Descripción de Parámetros: 
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@INDICADOR_EMPRESA:	Parámetro de entrada de tipo bit, que representa indicador empresa.
		@CODIGO_EMPRESA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo empresa.
		@CODIGO_SISTEMA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo sistema.
		@CODIGO_IDENTIFICADOR:	Parámetro de entrada de tipo char, que representa codigo identificador.
		@TIPO_PARAMETRO:	Parámetro de entrada de tipo char, que representa tipo parametro.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
		@INDICADOR_PERMITE_AGREGAR:	Parámetro de entrada de tipo bit, que representa indicador permite agregar.
		@INDICADOR_PERMITE_MODIFICAR:	Parámetro de entrada de tipo bit, que representa indicador permite modificar.
		@INDICADOR_PERMITE_ELIMINAR:	Parámetro de entrada de tipo bit, que representa indicador permite eliminar.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
DECLARE
@V_ESTADO_REGISTRO_RELACION			CHAR(1)

SET @V_ESTADO_REGISTRO_RELACION = '1'
BEGIN
	SELECT PA.[CODIGO_PARAMETRO]				AS CodigoParametro
		  ,EM.[CODIGO_EMPRESA]					AS CodigoEmpresa
		  ,EM.[CODIGO_IDENTIFICADOR]			AS CodigoEmpresaIdentificador
		  ,EM.[NOMBRE]							AS NombreEmpresa
		  ,SI.[CODIGO_SISTEMA]					AS CodigoSistema		  
		  ,SI.[CODIGO_IDENTIFICADOR]			AS CodigoSistemaIdentificador
		  ,SI.[NOMBRE]							AS NombreSistema
		  ,PA.[CODIGO_IDENTIFICADOR]			AS CodigoIdentificador
		  ,PA.[NOMBRE]							AS Nombre
		  ,PA.[DESCRIPCION]						AS Descripcion
		  ,PA.[INDICADOR_EMPRESA]				AS IndicadorEmpresa
		  ,PA.[INDICADOR_PERMITE_AGREGAR]		AS IndicadorPermiteAgregar
		  ,PA.[INDICADOR_PERMITE_MODIFICAR]		AS IndicadorPermiteModificar
		  ,PA.[INDICADOR_PERMITE_ELIMINAR]		AS IndicadorPermiteEliminar
		  ,PA.[TIPO_PARAMETRO]					AS TipoParametro
		  ,PA.[ESTADO_REGISTRO]					AS EstadoRegistro
	FROM GRL.PARAMETRO PA
	LEFT JOIN GRL.SISTEMA SI ON SI.CODIGO_SISTEMA = PA.CODIGO_SISTEMA AND SI.ESTADO_REGISTRO = '1'
	INNER JOIN GRL.EMPRESA EM ON EM.CODIGO_EMPRESA = PA.CODIGO_EMPRESA AND EM.ESTADO_REGISTRO = '1'
	WHERE (@CODIGO_PARAMETRO			IS NULL		OR PA.CODIGO_PARAMETRO				= @CODIGO_PARAMETRO)
	AND	(@CODIGO_IDENTIFICADOR			IS NULL		OR PA.CODIGO_IDENTIFICADOR			= @CODIGO_IDENTIFICADOR)
	AND	(@CODIGO_SISTEMA				IS NULL		OR PA.INDICADOR_EMPRESA				= 1						OR PA.CODIGO_SISTEMA				= @CODIGO_SISTEMA)
	AND	(@INDICADOR_EMPRESA				IS NULL		OR PA.INDICADOR_EMPRESA				= @INDICADOR_EMPRESA)
	AND	(@TIPO_PARAMETRO				IS NULL		OR PA.TIPO_PARAMETRO				= @TIPO_PARAMETRO)	
	AND (@NOMBRE						IS NULL		OR (UPPER(PA.NOMBRE)				LIKE '%' + UPPER(@NOMBRE) + '%'))	
	AND (@DESCRIPCION					IS NULL		OR (UPPER(PA.DESCRIPCION)			LIKE '%' + UPPER(@DESCRIPCION) + '%'))		
	AND (@INDICADOR_PERMITE_AGREGAR		IS NULL		OR PA.INDICADOR_PERMITE_AGREGAR		= @INDICADOR_PERMITE_AGREGAR)
	AND (@INDICADOR_PERMITE_MODIFICAR	IS NULL		OR PA.INDICADOR_PERMITE_MODIFICAR	= @INDICADOR_PERMITE_MODIFICAR)
	AND (@INDICADOR_PERMITE_ELIMINAR	IS NULL		OR PA.INDICADOR_PERMITE_ELIMINAR	= @INDICADOR_PERMITE_ELIMINAR)
	AND (@ESTADO_REGISTRO				IS NULL		OR PA.ESTADO_REGISTRO				= @ESTADO_REGISTRO)
	ORDER BY PA.NOMBRE
END

GO
/****** Object:  StoredProcedure [GRL].[USP_PARAMETRO_VALOR_INS]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_PARAMETRO_VALOR_INS]
(
	@CODIGO_PARAMETRO		INT,
	@CODIGO_SECCION			INT,
	@CODIGO_VALOR			INT,
	@VALOR					NVARCHAR(255),
	@ESTADO_REGISTRO		CHAR(1),
	@USUARIO_CREACION		NVARCHAR(50),
	@TERMINAL_CREACION		NVARCHAR(50) 
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_PARAMETRO_VALOR_INS
Propósito: Inserta registros en la tabla Parametro_valor
Descripción de Parámetros: 
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@CODIGO_SECCION:	Parámetro de entrada de tipo int, que representa codigo seccion.
		@CODIGO_VALOR:	Parámetro de entrada de tipo int, que representa codigo valor.
		@VALOR:	Parámetro de entrada de tipo nvarchar, que representa valor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN

	INSERT INTO [GRL].[PARAMETRO_VALOR]
           ([CODIGO_PARAMETRO]
           ,[CODIGO_SECCION]
           ,[CODIGO_VALOR]
           ,[VALOR]
           ,[ESTADO_REGISTRO]
           ,[USUARIO_CREACION]
           ,[FECHA_CREACION]
           ,[TERMINAL_CREACION]
           ,[USUARIO_MODIFICACION]
           ,[FECHA_MODIFICACION]
           ,[TERMINAL_MODIFICACION])
     VALUES
           (@CODIGO_PARAMETRO
           ,@CODIGO_SECCION
           ,@CODIGO_VALOR
           ,@VALOR
           ,@ESTADO_REGISTRO
           ,@USUARIO_CREACION
           ,GETDATE()
           ,@TERMINAL_CREACION
           ,NULL
           ,NULL
           ,NULL)
END

GO
/****** Object:  StoredProcedure [GRL].[USP_PARAMETRO_VALOR_MEJORADO_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [GRL].[USP_PARAMETRO_VALOR_MEJORADO_SEL]
(
	@CODIGO_PARAMETRO				INT,
	@INDICADOR_EMPRESA				BIT,
	@CODIGO_EMPRESA					UNIQUEIDENTIFIER,
	@CODIGO_SISTEMA					UNIQUEIDENTIFIER,	
	@CODIGO_IDENTIFICADOR			CHAR(5),
	@TIPO_PARAMETRO					CHAR(1),
	@CODIGO_SECCION					INT,
	@CODIGO_VALOR					INT,
	@VALOR							NVARCHAR(255),
	@ESTADO_REGISTRO				CHAR(1)
)
AS BEGIN
DECLARE 
	@V_ESTADO_REGISTRO_RELACION			CHAR(1)
	SET @V_ESTADO_REGISTRO_RELACION = '1'

	DECLARE @columnas		VARCHAR(500)
	DECLARE @sql			NVARCHAR(MAX)
	SET @columnas = ''

	SELECT	DISTINCT ps.CODIGO_SECCION,PS.NOMBRE
	into #COLUMNAS
	FROM GRL.PARAMETRO_VALOR PV
		INNER JOIN GRL.PARAMETRO PA				
			ON PA.CODIGO_PARAMETRO		=	PV.CODIGO_PARAMETRO		
			AND PA.ESTADO_REGISTRO		=	@V_ESTADO_REGISTRO_RELACION
		INNER JOIN GRL.PARAMETRO_SECCION PS		
			ON PS.CODIGO_PARAMETRO		=	PV.CODIGO_PARAMETRO		
			AND PV.CODIGO_SECCION		=	PS.CODIGO_SECCION		
			AND	PS.ESTADO_REGISTRO		=	@ESTADO_REGISTRO
			AND PS.ESTADO_REGISTRO		=	@V_ESTADO_REGISTRO_RELACION	
		WHERE	(@CODIGO_PARAMETRO			IS NULL		OR PA.CODIGO_PARAMETRO				= @CODIGO_PARAMETRO)
		AND	(@CODIGO_IDENTIFICADOR			IS NULL		OR PA.CODIGO_IDENTIFICADOR			= @CODIGO_IDENTIFICADOR)
		AND	(@INDICADOR_EMPRESA				IS NULL		OR PA.INDICADOR_EMPRESA				= @INDICADOR_EMPRESA)
		AND	(@CODIGO_SISTEMA				IS NULL		OR PA.INDICADOR_EMPRESA				= 1						OR PA.CODIGO_SISTEMA				= @CODIGO_SISTEMA)
		AND	(@TIPO_PARAMETRO				IS NULL		OR PA.TIPO_PARAMETRO				= @TIPO_PARAMETRO)
		AND (@CODIGO_SECCION				IS NULL		OR PV.CODIGO_SECCION				= @CODIGO_SECCION)
		AND (@CODIGO_VALOR					IS NULL		OR PV.CODIGO_VALOR					= @CODIGO_VALOR)
		AND (@VALOR							IS NULL		OR PV.VALOR							= @VALOR)
		AND (@ESTADO_REGISTRO				IS NULL		OR PV.ESTADO_REGISTRO				= @ESTADO_REGISTRO)

		SELECT @columnas = COALESCE(@columnas + '[' + NOMBRE  + '],', '') FROM #COLUMNAS
		ORDER BY CODIGO_SECCION

	
 
 if len( @columnas)!=0 begin
 SET @columnas = LEFT(@columnas,LEN(@columnas)-1)
	SET @sql='SELECT '+@columnas +'
	 FROM 
	(	SELECT	DATOCODIGOVALOR	=PV.CODIGO_VALOR,
				DATOTEXTO		=PS.NOMBRE,
				DATOVALOR		=PV.VALOR 
		FROM GRL.PARAMETRO_VALOR PV
		INNER JOIN GRL.PARAMETRO PA				
			ON PA.CODIGO_PARAMETRO		=	PV.CODIGO_PARAMETRO		
			AND PA.ESTADO_REGISTRO		=	@V_ESTADO_REGISTRO_RELACION
		INNER JOIN GRL.PARAMETRO_SECCION PS		
			ON PS.CODIGO_PARAMETRO		=	PV.CODIGO_PARAMETRO		
			AND PV.CODIGO_SECCION		=	PS.CODIGO_SECCION				
			AND PS.ESTADO_REGISTRO		=	@V_ESTADO_REGISTRO_RELACION	
		WHERE	(@CODIGO_PARAMETRO			IS NULL		OR PA.CODIGO_PARAMETRO				= @CODIGO_PARAMETRO)
		AND	(@CODIGO_IDENTIFICADOR			IS NULL		OR PA.CODIGO_IDENTIFICADOR			= @CODIGO_IDENTIFICADOR)
		AND	(@INDICADOR_EMPRESA				IS NULL		OR PA.INDICADOR_EMPRESA				= @INDICADOR_EMPRESA)
		AND	(@CODIGO_SISTEMA				IS NULL		OR PA.INDICADOR_EMPRESA				= 1						OR PA.CODIGO_SISTEMA				= @CODIGO_SISTEMA)
		AND	(@TIPO_PARAMETRO				IS NULL		OR PA.TIPO_PARAMETRO				= @TIPO_PARAMETRO)
		AND (@CODIGO_SECCION				IS NULL		OR PV.CODIGO_SECCION				= @CODIGO_SECCION)
		AND (@CODIGO_VALOR					IS NULL		OR PV.CODIGO_VALOR					= @CODIGO_VALOR)
		AND (@VALOR							IS NULL		OR PV.VALOR							= @VALOR)
		AND (@ESTADO_REGISTRO				IS NULL		OR PV.ESTADO_REGISTRO				= @ESTADO_REGISTRO)
		) AS SourceTable 
	PIVOT 
	( 
	MIN(DATOVALOR) 
	FOR DATOTEXTO IN ('+@columnas+')
	) AS PivotTable; '


	DECLARE @paramDef NVARCHAR(MAX) = N'	@CODIGO_PARAMETRO				INT,
											@INDICADOR_EMPRESA				BIT,
											@CODIGO_EMPRESA					UNIQUEIDENTIFIER,
											@CODIGO_SISTEMA					UNIQUEIDENTIFIER,	
											@CODIGO_IDENTIFICADOR			CHAR(5),
											@TIPO_PARAMETRO					CHAR(1),
											@CODIGO_SECCION					INT,
											@CODIGO_VALOR					INT,
											@VALOR							NVARCHAR(255),
											@ESTADO_REGISTRO				CHAR(1),
											@V_ESTADO_REGISTRO_RELACION		CHAR(1)'    

	EXEC sys.sp_executesql @sql, @paramDef, @CODIGO_PARAMETRO,
											@INDICADOR_EMPRESA,
											@CODIGO_EMPRESA,
											@CODIGO_SISTEMA,
											@CODIGO_IDENTIFICADOR,
											@TIPO_PARAMETRO,
											@CODIGO_SECCION,
											@CODIGO_VALOR,
											@VALOR,
											@ESTADO_REGISTRO,
											@V_ESTADO_REGISTRO_RELACION		
	END
END

GO
/****** Object:  StoredProcedure [GRL].[USP_PARAMETRO_VALOR_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [GRL].[USP_PARAMETRO_VALOR_SEL]
(
	@CODIGO_PARAMETRO				INT,
	@INDICADOR_EMPRESA				BIT,
	@CODIGO_EMPRESA					UNIQUEIDENTIFIER,
	@CODIGO_SISTEMA					UNIQUEIDENTIFIER,	
	@CODIGO_IDENTIFICADOR			CHAR(5),
	@TIPO_PARAMETRO					CHAR(1),
	@CODIGO_SECCION					INT,
	@CODIGO_VALOR					INT,
	@VALOR							NVARCHAR(255),
	@ESTADO_REGISTRO				CHAR(1)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_PARAMETRO_VALOR_SEL
Propósito: Retorna registros de la tabla Parametro_valor y Parametro
Descripción de Parámetros: 
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@INDICADOR_EMPRESA:	Parámetro de entrada de tipo bit, que representa indicador empresa.
		@CODIGO_EMPRESA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo empresa.
		@CODIGO_SISTEMA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo sistema.
		@CODIGO_IDENTIFICADOR:	Parámetro de entrada de tipo char, que representa codigo identificador.
		@TIPO_PARAMETRO:	Parámetro de entrada de tipo char, que representa tipo parametro.
		@CODIGO_SECCION:	Parámetro de entrada de tipo int, que representa codigo seccion.
		@CODIGO_VALOR:	Parámetro de entrada de tipo int, que representa codigo valor.
		@VALOR:	Parámetro de entrada de tipo nvarchar, que representa valor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
DECLARE 
@V_ESTADO_REGISTRO_RELACION			CHAR(1)
SET @V_ESTADO_REGISTRO_RELACION = '1'

BEGIN 
	SELECT  PV.CODIGO_PARAMETRO						AS CodigoParametro,
			PA.CODIGO_IDENTIFICADOR					AS CodigoIdentificador,
			PA.INDICADOR_EMPRESA					AS IndicadorEmpresa,
			PA.CODIGO_EMPRESA						AS CodigoEmpresa,
			PA.CODIGO_SISTEMA						AS CodigoSistema,
			PA.TIPO_PARAMETRO						AS TipoParametro,
			PV.CODIGO_SECCION						AS CodigoSeccion,
			PV.CODIGO_VALOR							AS CodigoValor,
			PS.CODIGO_TIPO_DATO						AS CodigoTipoDato,
			PV.VALOR								AS Valor,
			PV.ESTADO_REGISTRO						AS EstadoRegistro
	FROM GRL.PARAMETRO_VALOR PV
	INNER JOIN GRL.PARAMETRO PA				ON PA.CODIGO_PARAMETRO			=	PV.CODIGO_PARAMETRO		AND PA.ESTADO_REGISTRO	= @V_ESTADO_REGISTRO_RELACION
	INNER JOIN GRL.PARAMETRO_SECCION PS		ON PS.CODIGO_PARAMETRO			=	PV.CODIGO_PARAMETRO		AND PV.CODIGO_SECCION	= PS.CODIGO_SECCION				AND PS.ESTADO_REGISTRO	=	@V_ESTADO_REGISTRO_RELACION	
	WHERE	(@CODIGO_PARAMETRO				IS NULL		OR PA.CODIGO_PARAMETRO				= @CODIGO_PARAMETRO)
		AND	(@CODIGO_IDENTIFICADOR			IS NULL		OR PA.CODIGO_IDENTIFICADOR			= @CODIGO_IDENTIFICADOR)
		AND	(@INDICADOR_EMPRESA				IS NULL		OR PA.INDICADOR_EMPRESA				= @INDICADOR_EMPRESA)
		AND	(@CODIGO_SISTEMA				IS NULL		OR PA.INDICADOR_EMPRESA				= 1						OR PA.CODIGO_SISTEMA				= @CODIGO_SISTEMA)
		AND	(@TIPO_PARAMETRO				IS NULL		OR PA.TIPO_PARAMETRO				= @TIPO_PARAMETRO)
		AND (@CODIGO_SECCION				IS NULL		OR PV.CODIGO_SECCION				= @CODIGO_SECCION)
		AND (@CODIGO_VALOR					IS NULL		OR PV.CODIGO_VALOR					= @CODIGO_VALOR)
		AND (@VALOR							IS NULL		OR PV.VALOR							= @VALOR)
		AND (@ESTADO_REGISTRO				IS NULL		OR PV.ESTADO_REGISTRO				= @ESTADO_REGISTRO)
	ORDER BY PV.CODIGO_VALOR ASC, PV.CODIGO_SECCION ASC
END

GO
/****** Object:  StoredProcedure [GRL].[USP_PARAMETRO_VALOR_UPD]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_PARAMETRO_VALOR_UPD]
(
	@CODIGO_PARAMETRO		INT,
	@CODIGO_SECCION			INT,
	@CODIGO_VALOR			INT,
	@VALOR					NVARCHAR(255),
	@ESTADO_REGISTRO		CHAR(1),
	@USUARIO_MODIFICACION	NVARCHAR(50),
	@TERMINAL_MODIFICACION	NVARCHAR(50)
)
AS 
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_PARAMETRO_VALOR_UPD
Propósito: Actualiza registros de la tabla ParametroValor
Descripción de Parámetros: 
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@CODIGO_SECCION:	Parámetro de entrada de tipo int, que representa codigo seccion.
		@CODIGO_VALOR:	Parámetro de entrada de tipo int, que representa codigo valor.
		@VALOR:	Parámetro de entrada de tipo nvarchar, que representa valor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
UPDATE [GRL].[PARAMETRO_VALOR]
   SET [VALOR]					= (CASE WHEN @VALOR IS NULL				THEN [VALOR]			ELSE @VALOR END)
      ,[ESTADO_REGISTRO]		= (CASE WHEN @ESTADO_REGISTRO IS NULL	THEN [ESTADO_REGISTRO]	ELSE @ESTADO_REGISTRO END)
      ,[USUARIO_MODIFICACION]	= @USUARIO_MODIFICACION
      ,[FECHA_MODIFICACION]		= GETDATE()
      ,[TERMINAL_MODIFICACION]	= @TERMINAL_MODIFICACION
 WHERE	CODIGO_PARAMETRO		=  @CODIGO_PARAMETRO AND
		CODIGO_SECCION			=  @CODIGO_SECCION 	AND
		CODIGO_VALOR			=  @CODIGO_VALOR

END

GO
/****** Object:  StoredProcedure [GRL].[USP_PerfilUsuarioSRA_Activar_DTS_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_PerfilUsuarioSRA_Activar_DTS_SEL]
AS
BEGIN
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_TRABAJADOR_SUPLENTE_DTS_SEL
Propósito: Retorna registros de la tabla TRABAJADOR_SUPLENTE
Descripción de Parámetros: 
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
DECLARE @FECHA_ACTUAL DATETIME = CAST(GETDATE() AS DATE)
DECLARE @RowMin INT
DECLARE @RowMax INT
DECLARE @TEXT VARCHAR(MAX)

DECLARE @TEMP_PROFILE_SRA AS TABLE
(
	ID INT
)

DECLARE @TEMP_TRABAJADOR_USUARIO AS TABLE
(
	 RowID INT
	,PERFILES_AGREGADOS VARCHAR(MAX)
)

	INSERT INTO @TEMP_TRABAJADOR_USUARIO
	SELECT 
		  ROW_NUMBER() OVER (ORDER BY PERFILES_AGREGADOS) AS RowID  
		 ,PERFILES_AGREGADOS
	--INTO ##TEMP_TRABAJADOR_USUARIO
	FROM [GRL].[TRABAJADOR_SUPLENTE]
	WHERE 
	(CAST(FECHA_INICIO AS DATE) <= @FECHA_ACTUAL AND CAST(FECHA_FIN AS DATE) >= @FECHA_ACTUAL) AND (EJECUTADO IS NULL OR EJECUTADO = 0)
	AND ESTADO_REGISTRO = 1
	AND ACTIVO = 1

	SET @RowMin = 1
	SET @RowMax = (SELECT MAX(RowID)  from @TEMP_TRABAJADOR_USUARIO)

	WHILE @RowMin <=@RowMax
	BEGIN
		SELECT 
			@TEXT = PERFILES_AGREGADOS
		FROM @TEMP_TRABAJADOR_USUARIO
		WHERE RowID = @RowMin

		INSERT INTO @TEMP_PROFILE_SRA SELECT Item FROM GRL.SplitString(@TEXT, ',')

		select @RowMin +=1
	END

	SELECT * FROM @TEMP_PROFILE_SRA

END

GO
/****** Object:  StoredProcedure [GRL].[USP_PerfilUsuarioSRA_Desactivar_DTS_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_PerfilUsuarioSRA_Desactivar_DTS_SEL]
AS
BEGIN
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_TRABAJADOR_SUPLENTE_DTS_SEL
Propósito: Retorna registros de la tabla TRABAJADOR_SUPLENTE
Descripción de Parámetros: 
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
DECLARE @FECHA_ACTUAL DATETIME = CAST(GETDATE() AS DATE)
DECLARE @RowMin INT
DECLARE @RowMax INT
DECLARE @TEXT VARCHAR(MAX)

DECLARE @TEMP_PROFILE_SRA AS TABLE
(
	ID INT
)

DECLARE @TEMP_TRABAJADOR_USUARIO AS TABLE
(
	 RowID INT
	,PERFILES_AGREGADOS VARCHAR(MAX)
)

	INSERT INTO @TEMP_TRABAJADOR_USUARIO
	SELECT 
		  ROW_NUMBER() OVER (ORDER BY PERFILES_AGREGADOS) AS RowID  
		 ,PERFILES_AGREGADOS
	FROM [GRL].[TRABAJADOR_SUPLENTE]
	WHERE 
	CAST(FECHA_INICIO AS DATE) <= @FECHA_ACTUAL AND CAST(FECHA_FIN AS DATE) < @FECHA_ACTUAL AND EJECUTADO = 1
	AND ACTIVO = 1 AND ESTADO_REGISTRO = 1

	SET @RowMin = 1
	SET @RowMax = (SELECT MAX(RowID)  from @TEMP_TRABAJADOR_USUARIO)

	WHILE @RowMin <= @RowMax
	BEGIN
		SELECT 
			@TEXT = PERFILES_AGREGADOS
		FROM @TEMP_TRABAJADOR_USUARIO
		WHERE RowID = @RowMin

		INSERT INTO @TEMP_PROFILE_SRA SELECT Item FROM GRL.SplitString(@TEXT, ',')

		select @RowMin +=1
	END

	SELECT * FROM @TEMP_PROFILE_SRA

END

GO
/****** Object:  StoredProcedure [GRL].[USP_PLANTILLA_NOTIFICACION_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_PLANTILLA_NOTIFICACION_SEL]
(
	@CODIGO_PLANTILLA_NOTIFICACION UNIQUEIDENTIFIER = NULL,
	@CODIGO_SISTEMA UNIQUEIDENTIFIER = NULL,
	@CODIGO_TIPO_NOTIFICACION NVARCHAR(5) = NULL,
	@ASUNTO NVARCHAR(255) = NULL,
	@INDICADOR_ACTIVA BIT = NULL,
	@CONTENIDO NVARCHAR(MAX) = NULL,
	@ESTADO_REGISTRO CHAR(1) = NULL,
	@PageNo		INT = 1,
	@PageSize	INT = -1
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_PLANTILLA_NOTIFICACION_SEL
Propósito:  Obtiene el listado de Plantilla Notificación
Descripción de Parámetros: 
		@CODIGO_PLANTILLA_NOTIFICACION: Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla notificación.
		@CODIGO_SISTEMA: Parámetro de entrada de tipo uniqueidentifier, que representa codigo de sistema.
		@CODIGO_TIPO_NOTIFICACION: Parámetro de entrada de tipo nvarchar, que representa codigo tipo notificacion.
		@ASUNTO: Parámetro de entrada de tipo nvarchar, que representa el asunto.
		@INDICADOR_ACTIVA: Parámetro de entrada de tipo bit, que representa el indicador activa.
		@CONTENIDO: Parámetro de entrada de tipo nvarchar, que representa el contenido.
		@ESTADO_REGISTRO: Parámetro de entrada de tipo char, que representa el estado de registro.
Creado por: GMD
Fecha. Creación: 2015-06-10
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
SET @lLAStRec = (@lPageNbr * @lPageSize + 1)

IF (@ASUNTO IS NOT NULL)
BEGIN
	SET @ASUNTO = '%' + @ASUNTO + '%'
END
IF (@CONTENIDO IS NOT NULL)
BEGIN
	SET @CONTENIDO = '%' + @CONTENIDO + '%'
END
;

WITH	CTE_Results AS (SELECT ROW_NUMBER() OVER (ORDER BY ASUNTO ASC) AS RowNumber,
        COUNT(*) OVER() AS RowsTotal,
        CONVERT(VARCHAR, COUNT(*) OVER())		AS RowId,
        CODIGO_PLANTILLA_NOTIFICACION			AS CodigoPlantillaNotificacion,
        CODIGO_SISTEMA							AS CodigoSistema,
        CODIGO_TIPO_NOTIFICACION				AS CodigoTipoNotificacion,
		ASUNTO									AS Asunto,
		INDICADOR_ACTIVA						AS IndicadorActiva,
		CODIGO_TIPO_DESTINATARIO				AS CodigoTipoDestinatario,
		DESTINATARIO							AS Destinatario,
		DESTINATARIO_COPIA						AS DestinatarioCopia,
		CONTENIDO								AS Contenido,
        ESTADO_REGISTRO							AS EstadoRegistro
FROM	GRL.PLANTILLA_NOTIFICACION (nolock)
WHERE	(CODIGO_PLANTILLA_NOTIFICACION			=		@CODIGO_PLANTILLA_NOTIFICACION		OR @CODIGO_PLANTILLA_NOTIFICACION IS NULL)
AND		(CODIGO_SISTEMA							=		@CODIGO_SISTEMA						OR @CODIGO_SISTEMA IS NULL)
AND		(CODIGO_TIPO_NOTIFICACION				=		@CODIGO_TIPO_NOTIFICACION			OR ISNULL(@CODIGO_TIPO_NOTIFICACION,'') = '')	
AND		(ASUNTO 							 LIKE		@ASUNTO								OR @ASUNTO IS NULL)
AND		(INDICADOR_ACTIVA						=		@INDICADOR_ACTIVA					OR @INDICADOR_ACTIVA IS NULL)
AND		(CONTENIDO							 LIKE		@CONTENIDO							OR @CONTENIDO IS NULL)
AND		(ESTADO_REGISTRO = '1')
)

SELECT	RowNumber,
		RowsTotal,
		RowId,
        CodigoPlantillaNotificacion,
        CodigoSistema,
        CodigoTipoNotificacion,
		Asunto,
		IndicadorActiva,
		CodigoTipoDestinatario,
		Destinatario,
		DestinatarioCopia,
		Contenido,
		EstadoRegistro
FROM    CTE_Results
WHERE   @PageSize < 0 OR ( RowNumber > @lFirstRec AND RowNumber < @lLAStRec)        
ORDER   BY Asunto
END


GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_DATOMINIMO_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [GRL].[USP_TRABAJADOR_DATOMINIMO_SEL]
(	
	@DOMINIO			nvarchar(20),
	@CODIGO_IDENTIFICACION	nvarchar(20),
	@NOMBRE_COMPLETO	nvarchar(20),
	@CORREO_ELECTRONICO	nvarchar(20) )
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_TRABAJADOR_DATOMINIMO_SEL
Propósito: Retorna registros de la tabla Trabajador
Descripción de Parámetros: 
		@DOMINIO:	Parámetro de entrada de tipo nvarchar, que representa el dominio.
		@CODIGO_IDENTIFICACION:	Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.
		@NOMBRE_COMPLETO:	Parámetro de entrada de tipo nvarchar, que representa nombre completo.
		@CORREO_ELECTRONICO:	Parámetro de entrada de tipo nvarchar, que representa correo electronico.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
		SELECT       @DOMINIO = '%'+ISNULL(@DOMINIO,'')+'%',
					 @CODIGO_IDENTIFICACION = '%'+ISNULL(@CODIGO_IDENTIFICACION,'')+'%',
					 @NOMBRE_COMPLETO = '%'+ISNULL(@NOMBRE_COMPLETO,'')+'%',
					 @CORREO_ELECTRONICO = '%'+ISNULL(@CORREO_ELECTRONICO,'')+'%'

    select TR.CODIGO_TRABAJADOR AS CodigoTrabajador,
			   TR.DOMINIO AS Dominio,
			   TR.CODIGO_IDENTIFICACION AS CodigoIdentificacion,
			   TR.NOMBRE_COMPLETO AS NombreCompleto,
			   TR.CORREO_ELECTRONICO  as CorreoElectronico,
			   TR.INDICADOR_TIENE_FOTO AS IndicadorTieneFoto,
			   TR.DEPARTAMENTO	AS Departamento,
			   TR.CARGO			AS Cargo
               FROM  GRL.TRABAJADOR TR (nolock)
				WHERE		TR.DOMINIO LIKE @DOMINIO AND
							TR.CODIGO_IDENTIFICACION LIKE @CODIGO_IDENTIFICACION AND
							TR.NOMBRE_COMPLETO LIKE @NOMBRE_COMPLETO AND
							TR.CORREO_ELECTRONICO LIKE @CORREO_ELECTRONICO 
							AND TR.ESTADO_REGISTRO='1'							 
    END

GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_FIRMA_POR_TRABAJADOR_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_TRABAJADOR_FIRMA_POR_TRABAJADOR_SEL](
    @CODIGO_TRABAJADOR UNIQUEIDENTIFIER
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_TRABAJADOR_FIRMA_POR_TRABAJADOR_SEL
Propósito: Retorna registros de la tabla Trabajador
Descripción de Parámetros: 
		@CODIGO_TRABAJADOR:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo trabajador.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
    SET NOCOUNT ON;
    SELECT TF.CODIGO_FIRMA AS CodigoTrabajadorFirma, 
           TB.CODIGO_TRABAJADOR AS CodigoTrabajador, 
           TF.FIRMA_TRABAJADOR AS FirmaTrabajador,
		   TB.NOMBRE_COMPLETO AS NombreCompleto
      FROM GRL.TRABAJADOR TB
	  LEFT JOIN GRL.TRABAJADOR_FIRMA TF ON TB.CODIGO_TRABAJADOR = TF.CODIGO_TRABAJADOR AND TF.ESTADO_REGISTRO = '1'
     WHERE TB.ESTADO_REGISTRO = '1'
       AND TB.CODIGO_TRABAJADOR = @CODIGO_TRABAJADOR;
END;

GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_INS]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_INS]    Script Date: 22/05/2015 01:26:29 a.m. ******/

CREATE PROCEDURE [GRL].[USP_TRABAJADOR_INS]
(
	@CODIGO_TRABAJADOR					UNIQUEIDENTIFIER,
    @CODIGO_IDENTIFICACION				nvarchar(50),
	@CODIGO_TIPO_DOCUMENTO_IDENTIDAD	nvarchar(5),
	@NUMERO_DOCUMENTO_IDENTIDAD			nvarchar(15),
	@APELLIDO_PATERNO					nvarchar(50),
	@APELLIDO_MATERNO					nvarchar(50),
	@NOMBRES							nvarchar(50),
	@NOMBRE_COMPLETO					nvarchar(255),
	@ORGANIZACION						nvarchar(255),
	@DEPARTAMENTO						nvarchar(255),
	@CARGO								nvarchar(255),
	@TELEFONO_TRABAJO					nvarchar(15),
	@ANEXO								nvarchar(10),
	@TELEFONO_MOVIL						nvarchar(15),
	@TELEFONO_PERSONAL					nvarchar(15),
	@CORREO_ELECTRONICO					nvarchar(50),
	@DOMINIO							nvarchar(50),
	@USUARIO_CREACION					nvarchar(50),
    @TERMINAL_CREACION					nvarchar(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_TRABAJADOR_INS
Propósito: Inserta registros en la tabla TRABAJADOR
Descripción de Parámetros: 
		@CODIGO_TRABAJADOR:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo trabajador.
		@CODIGO_IDENTIFICACION:	Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.
		@CODIGO_TIPO_DOCUMENTO_IDENTIDAD:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento identidad.
		@NUMERO_DOCUMENTO_IDENTIDAD:	Parámetro de entrada de tipo nvarchar, que representa numero documento identidad.
		@APELLIDO_PATERNO:	Parámetro de entrada de tipo nvarchar, que representa apellido paterno.
		@APELLIDO_MATERNO:	Parámetro de entrada de tipo nvarchar, que representa apellido materno.
		@NOMBRES:	Parámetro de entrada de tipo nvarchar, que representa nombres.
		@NOMBRE_COMPLETO:	Parámetro de entrada de tipo nvarchar, que representa nombre completo.
		@ORGANIZACION:	Parámetro de entrada de tipo nvarchar, que representa organizacion.
		@DEPARTAMENTO:	Parámetro de entrada de tipo nvarchar, que representa departamento.
		@CARGO:	Parámetro de entrada de tipo nvarchar, que representa cargo.
		@TELEFONO_TRABAJO:	Parámetro de entrada de tipo nvarchar, que representa telefono trabajo.
		@ANEXO:	Parámetro de entrada de tipo nvarchar, que representa anexo.
		@TELEFONO_MOVIL:	Parámetro de entrada de tipo nvarchar, que representa telefono movil.
		@TELEFONO_PERSONAL:	Parámetro de entrada de tipo nvarchar, que representa telefono personal.
		@CORREO_ELECTRONICO:	Parámetro de entrada de tipo nvarchar, que representa correo electronico.
		@DOMINIO:	Parámetro de entrada de tipo nvarchar, que representa dominio.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
        BEGIN 
            INSERT  INTO GRL.TRABAJADOR
                    ( CODIGO_TRABAJADOR ,
                      CODIGO_IDENTIFICACION ,
                      CODIGO_TIPO_DOCUMENTO_IDENTIDAD ,
                      NUMERO_DOCUMENTO_IDENTIDAD ,
                      APELLIDO_PATERNO ,
                      APELLIDO_MATERNO ,
                      NOMBRES ,
                      NOMBRE_COMPLETO ,
                      ORGANIZACION ,
                      DEPARTAMENTO ,
                      CARGO ,
                      TELEFONO_TRABAJO ,
                      ANEXO ,
                      TELEFONO_MOVIL ,
                      TELEFONO_PERSONAL ,
                      CORREO_ELECTRONICO ,
				  DOMINIO,
                      ESTADO_REGISTRO ,
                      USUARIO_CREACION ,
                      FECHA_CREACION ,
                      TERMINAL_CREACION
                    )
            VALUES  ( @CODIGO_TRABAJADOR ,
                      @CODIGO_IDENTIFICACION ,
                      @CODIGO_TIPO_DOCUMENTO_IDENTIDAD ,
                      @NUMERO_DOCUMENTO_IDENTIDAD ,
                      @APELLIDO_PATERNO ,
                      @APELLIDO_MATERNO ,
                      @NOMBRES ,
                      @NOMBRE_COMPLETO ,
                      @ORGANIZACION ,
                      @DEPARTAMENTO ,
                      @CARGO ,
                      @TELEFONO_TRABAJO ,
                      @ANEXO ,
                      @TELEFONO_MOVIL ,
                      @TELEFONO_PERSONAL ,
                      @CORREO_ELECTRONICO ,
				  @DOMINIO,
                      1 ,
                      @USUARIO_CREACION ,
                      GRL.FN_OBTENER_FECHA_SERVIDOR(NULL,NULL) ,
                      @TERMINAL_CREACION                       
                    )
			SELECT  1               					    
        END

GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_LISTA_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [GRL].[USP_TRABAJADOR_LISTA_SEL]
(
	@CODIGOS_TRABAJADORES	LISTA_GUID_TYPE READONLY
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_TRABAJADOR_LISTA_SEL
Propósito: Retorna registros de la tabla Trabajador
Descripción de Parámetros: 
		@CODIGOS_TRABAJADORES:	Parámetro de entrada de tipo LISTA_GUID_TYPE, que representa codigos trabajadores.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	SELECT	CODIGO_TRABAJADOR AS CodigoTrabajador,
			CODIGO_IDENTIFICACION AS CodigoIdentificacion,
			CODIGO_TIPO_DOCUMENTO_IDENTIDAD AS CodigoTipoDocumentoIdentidad,
			NUMERO_DOCUMENTO_IDENTIDAD AS NumeroDocumentoIdentidad,
			APELLIDO_PATERNO AS ApellidoPaterno,                     
			APELLIDO_MATERNO AS ApellidoMaterno,
			NOMBRES AS Nombres,
			NOMBRE_COMPLETO AS NombreCompleto,
			ORGANIZACION AS Organizacion,
			DEPARTAMENTO AS Departamento,
			CARGO AS Cargo,
			TELEFONO_TRABAJO AS TelefonoTrabajo,
			ANEXO AS Anexo,
			TELEFONO_MOVIL AS TelefonoMovil,
			TELEFONO_PERSONAL AS TelefonoPersonal,
			CORREO_ELECTRONICO AS CorreoElectronico
	FROM	GRL.TRABAJADOR T
	WHERE	T.ESTADO_REGISTRO = '1'
	AND		EXISTS (SELECT	1 
					FROM	@CODIGOS_TRABAJADORES CT
					WHERE	CT.CODIGO = T.CODIGO_TRABAJADOR)
END

GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_ORIGINAL_DTS_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_TRABAJADOR_ORIGINAL_DTS_SEL]
AS
BEGIN
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_TRABAJADOR_ORIGINAL_DTS_SEL
Propósito: Retorna registros de los trabajadores originales para ser reemplazados en el flujo de aprobación
Descripción de Parámetros: 
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
	DECLARE @FECHA_ACTUAL DATETIME = CAST(GETDATE() AS DATE)
	SELECT   
		CODIGO_TRABAJADOR
		, CODIGO_SUPLENTE
		, FECHA_INICIO
		, FECHA_FIN
		, PERFILES_AGREGADOS
	FROM [GRL].[TRABAJADOR_SUPLENTE]
	WHERE 
	CAST(FECHA_INICIO AS DATE) <= @FECHA_ACTUAL AND CAST(FECHA_FIN AS DATE) < @FECHA_ACTUAL AND EJECUTADO = 1
	--AND ACTIVO = 1 
	AND ESTADO_REGISTRO = 1
END

GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_TRABAJADOR_SEL] --'a1479df5-6325-414b-8dc5-0e987faceb2e',NULL,NULL,NULL,NULL,NULL,1,-1
(
    @CODIGO_TRABAJADOR				UNIQUEIDENTIFIER, 
    @CODIGO_IDENTIFICACION			NVARCHAR(50), 	
    @CODIGO_TIPO_DOCUMENTO_IDENTIDAD	NVARCHAR(5), 
	@DOMINIO						NVARCHAR(50),
    @NUMERO_DOCUMENTO_IDENTIDAD		NVARCHAR(15), 
    @NOMBRES						NVARCHAR(50), 
    @NUMERO_PAGINA					INT = 1, 
    @TAMANIO_PAGINA					INT = -1
)
AS

/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_TRABAJADOR_SEL
Propósito: Retorna registros de la tabla Trabajador
Descripción de Parámetros: 
		@CODIGO_TRABAJADOR:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo trabajador.
		@CODIGO_IDENTIFICACION:	Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.
		@DOMINIO:	Parámetro de entrada de tipo nvarchar, que representa el dominio.
		@CODIGO_TIPO_DOCUMENTO_IDENTIDAD:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento identidad.
		@NUMERO_DOCUMENTO_IDENTIDAD:	Parámetro de entrada de tipo nvarchar, que representa numero documento identidad.
		@NOMBRES:	Parámetro de entrada de tipo nvarchar, que representa nombres.
		@NUMERO_PAGINA:	Parámetro de entrada de tipo int, que representa numero pagina.
		@TAMANIO_PAGINA:	Parámetro de entrada de tipo int, que representa tamanio pagina.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
    SET NOCOUNT ON;
    DECLARE
       @lPageNbr INT, 
       @lPageSize INT, 
       @lFirstRec INT, 
       @lLAStRec INT;

    SET @lPageNbr = @NUMERO_PAGINA;
    SET @lPageSize = @TAMANIO_PAGINA;

    SET @lFirstRec = (@lPageNbr-1)*@lPageSize;
    SET @lLAStRec = @lPageNbr*@lPageSize+1;

    IF @NOMBRES IS NOT NULL
        BEGIN
            SET @NOMBRES = '%'+@NOMBRES+'%';
        END;
    IF @CODIGO_IDENTIFICACION IS NOT NULL
        BEGIN
            SET @CODIGO_IDENTIFICACION = '%'+@CODIGO_IDENTIFICACION+'%';
        END;
    IF @NUMERO_DOCUMENTO_IDENTIDAD IS NOT NULL
        BEGIN
            SET @NUMERO_DOCUMENTO_IDENTIDAD = '%'+@NUMERO_DOCUMENTO_IDENTIDAD+'%';
        END;
    IF @CODIGO_TIPO_DOCUMENTO_IDENTIDAD IS NOT NULL
        BEGIN
            SET @CODIGO_TIPO_DOCUMENTO_IDENTIDAD = '%'+@CODIGO_TIPO_DOCUMENTO_IDENTIDAD+'%';
        END;
	IF @DOMINIO IS NOT NULL
        BEGIN
            SET @DOMINIO = '%'+@DOMINIO+'%';
        END;

    WITH CTE_Results
        AS (SELECT ROW_NUMBER()OVER(ORDER BY T.CODIGO_IDENTIFICACION ASC)AS RowNumber, 
                   COUNT(*)OVER()AS RowsTotal, 
                   CONVERT(VARCHAR, COUNT(*)OVER())AS RowId, 
                   T.CODIGO_TRABAJADOR AS CodigoTrabajador, 
                   T.CODIGO_IDENTIFICACION AS CodigoIdentificacion, 
                   T.CODIGO_TIPO_DOCUMENTO_IDENTIDAD AS CodigoTipoDocumentoIdentidad, 
                   T.NUMERO_DOCUMENTO_IDENTIDAD AS NumeroDocumentoIdentidad, 
                   T.APELLIDO_PATERNO AS ApellidoPaterno, 
                   T.APELLIDO_MATERNO AS ApellidoMaterno, 
                   T.NOMBRES AS Nombres, 
                   T.NOMBRE_COMPLETO AS NombreCompleto, 
                   T.ORGANIZACION AS Organizacion, 
                   T.DEPARTAMENTO AS Departamento, 
                   T.CARGO AS Cargo, 
                   T.TELEFONO_TRABAJO AS TelefonoTrabajo, 
                   T.ANEXO AS Anexo, 
                   T.TELEFONO_MOVIL AS TelefonoMovil, 
                   T.TELEFONO_PERSONAL AS TelefonoPersonal, 
                   T.CORREO_ELECTRONICO AS CorreoElectronico,
					T.DOMINIO AS Dominio,
					T.INDICADOR_TIENE_FOTO AS IndicadorTieneFoto,
					TF.CODIGO_FIRMA AS CodigoFirma,--,
					ISNULL(T.INDICADOR_TODA_UNIDAD_OPERATIVA,0) AS IndicadorTodaUnidadOperativa,
					T.CODIGO_UNIDAD_OPERATIVA_MATRIZ AS CodigoUnidadOperativaMatriz
			    --TF.FIRMA_TRABAJADOR AS FirmaTrabajador
              FROM GRL.TRABAJADOR T LEFT JOIN GRL.TRABAJADOR_FIRMA TF 
			    ON T.CODIGO_TRABAJADOR = TF.CODIGO_TRABAJADOR AND TF.ESTADO_REGISTRO = '1'
             WHERE (@CODIGO_TRABAJADOR IS NULL 
				OR T.CODIGO_TRABAJADOR = @CODIGO_TRABAJADOR)
              AND (@CODIGO_IDENTIFICACION IS NULL
				OR T.CODIGO_IDENTIFICACION LIKE @CODIGO_IDENTIFICACION)
			  AND (@DOMINIO IS NULL
				OR T.DOMINIO LIKE @DOMINIO)
              AND (@CODIGO_TIPO_DOCUMENTO_IDENTIDAD IS NULL
				OR T.CODIGO_TIPO_DOCUMENTO_IDENTIDAD LIKE @CODIGO_TIPO_DOCUMENTO_IDENTIDAD)
              AND (@NUMERO_DOCUMENTO_IDENTIDAD IS NULL
				OR T.NUMERO_DOCUMENTO_IDENTIDAD LIKE @NUMERO_DOCUMENTO_IDENTIDAD)
              AND (@NOMBRES IS NULL
				OR T.NOMBRE_COMPLETO LIKE @NOMBRES)
              AND T.ESTADO_REGISTRO = '1'
		    )
        SELECT RowNumber, 
               RowsTotal, 
               RowId, 
               CodigoTrabajador, 
               CodigoIdentificacion, 
               CodigoTipoDocumentoIdentidad, 
               NumeroDocumentoIdentidad, 
               ApellidoPaterno, 
               ApellidoMaterno, 
               Nombres, 
               NombreCompleto, 
               Organizacion, 
               Departamento, 
               Cargo, 
               TelefonoTrabajo, 
               Anexo, 
               TelefonoMovil, 
               TelefonoPersonal, 
               CorreoElectronico,
			Dominio,
			CodigoFirma,
			IndicadorTodaUnidadOperativa,
			IndicadorTieneFoto,
			CodigoUnidadOperativaMatriz
          FROM CTE_Results R
         WHERE @TAMANIO_PAGINA < 0
            OR (RowNumber > @lFirstRec AND RowNumber < @lLAStRec) ;
END;

GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_SUPLENTE_DTS_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_TRABAJADOR_SUPLENTE_DTS_SEL]
AS
BEGIN
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_TRABAJADOR_SUPLENTE_DTS_SEL
Propósito: Retorna registros de la tabla TRABAJADOR_SUPLENTE
Descripción de Parámetros: 
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
DECLARE @FECHA_ACTUAL DATETIME = CAST(GETDATE() AS DATE)

	SELECT   
		CODIGO_TRABAJADOR
		, CODIGO_SUPLENTE
		, FECHA_INICIO
		, FECHA_FIN
		, PERFILES_AGREGADOS
	FROM [GRL].[TRABAJADOR_SUPLENTE]
	WHERE 
	(CAST(FECHA_INICIO AS DATE) <= @FECHA_ACTUAL AND CAST(FECHA_FIN AS DATE) >= @FECHA_ACTUAL) AND (EJECUTADO IS NULL OR EJECUTADO = 0)
	AND ACTIVO = 1 AND ESTADO_REGISTRO = 1
END

GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_SUPLENTE_DTS_UPD]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_TRABAJADOR_SUPLENTE_DTS_UPD]
(
	@TIPO INT
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_TRABAJADOR_SUPLENTE_DTS_UPD
Propósito: Actualiza el campo ejecutado luego de haber finalizado el reemplazo
Descripción de Parámetros: 
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
DECLARE @FECHA_ACTUAL DATETIME = CAST(GETDATE() AS DATE)

IF(@TIPO = 1)
BEGIN
	UPDATE 
    [GRL].[TRABAJADOR_SUPLENTE] 
	SET EJECUTADO = 1 
	WHERE CAST(FECHA_INICIO AS DATE) <= @FECHA_ACTUAL AND CAST(FECHA_FIN AS DATE) >= @FECHA_ACTUAL
	AND (EJECUTADO IS NULL OR EJECUTADO = 0)
	AND ACTIVO = 1 AND ESTADO_REGISTRO = 1
END
ELSE
BEGIN
	UPDATE 
    [GRL].[TRABAJADOR_SUPLENTE] 
	SET EJECUTADO = 0,
		ACTIVO = 0,
		PERFILES_AGREGADOS = NULL 
	WHERE 
	CAST(FECHA_INICIO AS DATE) <= @FECHA_ACTUAL AND CAST(FECHA_FIN AS DATE) < @FECHA_ACTUAL AND EJECUTADO = 1
	--AND ACTIVO = 1 
	AND ESTADO_REGISTRO = 1
END

END;

GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_SUPLENTE_INS]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--DROP PROC [GRL].[USP_TRABAJADOR_SUPLENTE_INS]
CREATE PROCEDURE [GRL].[USP_TRABAJADOR_SUPLENTE_INS]
(
	@CODIGO_TRABAJADOR					UNIQUEIDENTIFIER,
    @CODIGO_SUPLENTE					UNIQUEIDENTIFIER,
	@FECHA_INICIO						datetime,
	@FECHA_FIN							datetime,
	@ACTIVO								bit,
	@EJECUTADO							bit,
	@PERFILES_AGREGADOS					varchar(1000),
	@USUARIO_CREACION					nvarchar(50),
	@TERMINAL_CREACION					nvarchar(50)
)
AS
INSERT INTO [GRL].[TRABAJADOR_SUPLENTE]
           (
			[CODIGO_TRABAJADOR]
           ,[CODIGO_SUPLENTE]
           ,[FECHA_INICIO]
           ,[FECHA_FIN]
           ,[ACTIVO]
           ,[EJECUTADO]
           ,[PERFILES_AGREGADOS]
           ,[ESTADO_REGISTRO]
           ,[USUARIO_CREACION]
           ,[FECHA_CREACION]
           ,[TERMINAL_CREACION]
		   )
     VALUES
           (
		    @CODIGO_TRABAJADOR,
            @CODIGO_SUPLENTE,
            @FECHA_INICIO,
            @FECHA_FIN,
            @ACTIVO,
            @EJECUTADO,
            @PERFILES_AGREGADOS,
           '1',
            @USUARIO_CREACION,
            GETDATE(),
            @TERMINAL_CREACION
		   )

		   SELECT 1

GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_SUPLENTE_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [GRL].[USP_TRABAJADOR_SUPLENTE_SEL]
(
	@CODIGO_TRABAJADOR UNIQUEIDENTIFIER
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_USP_TRABAJADOR_SUPLENTE_SEL
Propósito: Retorna registros de la tabla TrabajadorSuplente
Descripción de Parámetros: 
		@CODIGO_TRABAJADOR:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo de trabajador.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	SELECT	
        TS.CODIGO_TRABAJADOR AS 'CodigoTrabajador'
	   ,TS.CODIGO_SUPLENTE AS 'CodigoSuplente'
	   ,TS.FECHA_INICIO AS 'FechaInicio'
	   ,TS.FECHA_FIN AS 'FechaFin'
	   ,TS.ACTIVO AS 'Activo'
	   ,TS.EJECUTADO AS 'Ejecutado'
	   ,TS.PERFILES_AGREGADOS AS 'PerfilAgregados'
	FROM	[GRL].[TRABAJADOR_SUPLENTE] TS
	WHERE	TS.CODIGO_TRABAJADOR = @CODIGO_TRABAJADOR
	AND TS.ESTADO_REGISTRO = '1'
END

GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_SUPLENTE_UPD]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- DROP PROC [GRL].[USP_TRABAJADOR_SUPLENTE_UPD]
CREATE PROC [GRL].[USP_TRABAJADOR_SUPLENTE_UPD]
(
    @CODIGO_TRABAJADOR					UNIQUEIDENTIFIER,
    @CODIGO_SUPLENTE					UNIQUEIDENTIFIER,
	@FECHA_INICIO						datetime,
	@FECHA_FIN							datetime,
	@ACTIVO								bit,
	@EJECUTADO							bit,
	@PERFILES_AGREGADOS					varchar(1000),
	@USUARIO_MODIFICACION				nvarchar(50),
    @TERMINAL_MODIFICACION				nvarchar(50)
)
AS
        BEGIN
            UPDATE  [GRL].[TRABAJADOR_SUPLENTE]
            SET     CODIGO_SUPLENTE					=	@CODIGO_SUPLENTE,
					FECHA_INICIO					=	@FECHA_INICIO,
					FECHA_FIN						=	@FECHA_FIN,
					ACTIVO							=	@ACTIVO,
					EJECUTADO						=	@EJECUTADO,
					PERFILES_AGREGADOS				=	@PERFILES_AGREGADOS,
                    USUARIO_MODIFICACION			=	@USUARIO_MODIFICACION ,
                    FECHA_MODIFICACION				=	GETDATE(),
                    TERMINAL_MODIFICACION			=	@TERMINAL_MODIFICACION
            WHERE   CODIGO_TRABAJADOR				=	@CODIGO_TRABAJADOR
            SELECT  1
        END



GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_TOTAL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [GRL].[USP_TRABAJADOR_TOTAL]
@DOMINIO			nvarchar(20),
@CODIGO_IDENTIFICACION	nvarchar(20),
@NOMBRE_COMPLETO	nvarchar(20),
@CORREO_ELECTRONICO	nvarchar(20)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_TRABAJADOR_TOTAL
Propósito: Retorna registros de la tabla Trabajador (Todos los registros)
Descripción de Parámetros: 
@DOMINIO:	Parámetro de entrada de tipo nvarchar, que representa el dominio.
@CODIGO_IDENTIFICACION:	Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.
@NOMBRE_COMPLETO:	Parámetro de entrada de tipo nvarchar, que representa nombre completo.
@CORREO_ELECTRONICO:	Parámetro de entrada de tipo nvarchar, que representa correo electronico.
Creado por: Adexus
Fecha. Creación: 2018-10-10
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
SELECT
@DOMINIO = '%'+ISNULL(@DOMINIO,'')+'%',
@CODIGO_IDENTIFICACION = '%'+ISNULL(@CODIGO_IDENTIFICACION,'')+'%',
@NOMBRE_COMPLETO = '%'+ISNULL(@NOMBRE_COMPLETO,'')+'%',
@CORREO_ELECTRONICO = '%'+ISNULL(@CORREO_ELECTRONICO,'')+'%'

SELECT
TR.CODIGO_TRABAJADOR AS CodigoTrabajador,
ISNULL(TR.DOMINIO,'') AS Dominio,
ISNULL(TR.CODIGO_IDENTIFICACION,'') AS CodigoIdentificacion,
ISNULL(TR.NOMBRE_COMPLETO,'') AS NombreCompleto,
ISNULL(TR.CORREO_ELECTRONICO,'')  as CorreoElectronico,
TR.INDICADOR_TIENE_FOTO AS IndicadorTieneFoto,
ISNULL(TR.DEPARTAMENTO,'')	AS Departamento,
ISNULL(TR.CARGO,'') AS Cargo
FROM GRL.TRABAJADOR TR (nolock)
--WHERE TR.DOMINIO LIKE @DOMINIO AND
--TR.CODIGO_IDENTIFICACION LIKE @CODIGO_IDENTIFICACION AND
--TR.NOMBRE_COMPLETO LIKE @NOMBRE_COMPLETO AND
--TR.CORREO_ELECTRONICO LIKE @CORREO_ELECTRONICO 
--AND TR.ESTADO_REGISTRO='1'							 

END
GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_UNIDAD_OPERATIVA_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [GRL].[USP_TRABAJADOR_UNIDAD_OPERATIVA_SEL]
(
	@CODIGO_UNIDAD_OPERATIVA_MATRIZ	UNIQUEIDENTIFIER,
	@CODIGO_TRABAJADOR				UNIQUEIDENTIFIER
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_USP_TRABAJADOR_UNIDAD_OPERATIVA_SEL
Propósito: Retorna registros de la tabla TrabajadorUnidadOperativa
Descripción de Parámetros: 
		@CODIGO_TRABAJADOR:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo de trabajador.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	SELECT	CODIGO_TRABAJADOR_UNIDAD_OPERATIVA	AS 'CodigoTrabajadorUnidadOperativa',
			CODIGO_UNIDAD_OPERATIVA_MATRIZ		AS 'CodigoUnidadOperativaMatriz',
			TUO.CODIGO_TRABAJADOR				AS 'CodigoTrabajador',
			TUO.CODIGO_UNIDAD_OPERATIVA			AS 'CodigoUnidadOperativa',
			UO.NOMBRE							AS 'NombreUnidadOperativa',
			TUO.ESTADO_REGISTRO					AS 'EstadoRegistro',
			TUO.FECHA_CREACION					AS 'FechaCreacion'
	FROM	[GRL].[TRABAJADOR_UNIDAD_OPERATIVA] TUO
	INNER JOIN [GRL].[UNIDAD_OPERATIVA] UO ON UO.CODIGO_UNIDAD_OPERATIVA = TUO.CODIGO_UNIDAD_OPERATIVA
	WHERE	CODIGO_UNIDAD_OPERATIVA_MATRIZ = @CODIGO_UNIDAD_OPERATIVA_MATRIZ
	AND		CODIGO_TRABAJADOR = @CODIGO_TRABAJADOR
	--AND TUO.ESTADO_REGISTRO = '1'
END

GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_UNIDAD_OPERATIVASAP_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_TRABAJADOR_UNIDAD_OPERATIVASAP_SEL]
(
	@CODIGO_UNIDAD_OPERATIVA_MATRIZ	UNIQUEIDENTIFIER,
	@CODIGO_TRABAJADOR				UNIQUEIDENTIFIER
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_USP_TRABAJADOR_UNIDAD_OPERATIVA_SEL
Propósito: Retorna registros de la tabla TrabajadorUnidadOperativa
Descripción de Parámetros: 
		@CODIGO_TRABAJADOR:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo de trabajador.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	SELECT	CODIGO_TRABAJADOR_UNIDAD_OPERATIVA	AS 'CodigoTrabajadorUnidadOperativa',
			CODIGO_UNIDAD_OPERATIVA_MATRIZ		AS 'CodigoUnidadOperativaMatriz',
			TUO.CODIGO_TRABAJADOR				AS 'CodigoTrabajador',
			TUO.CODIGO_UNIDAD_OPERATIVA			AS 'CodigoUnidadOperativa',
			UO.NOMBRE							AS 'NombreUnidadOperativa',
			TUO.ESTADO_REGISTRO					AS 'EstadoRegistro',
			TUO.FECHA_CREACION					AS 'FechaCreacion'
	FROM	[GRL].[TRABAJADOR_UNIDAD_OPERATIVA] TUO
	INNER JOIN [GRL].[UNIDAD_OPERATIVA] UO ON UO.CODIGO_UNIDAD_OPERATIVA = TUO.CODIGO_UNIDAD_OPERATIVA
	WHERE CODIGO_UNIDAD_OPERATIVA_MATRIZ = @CODIGO_UNIDAD_OPERATIVA_MATRIZ
	  AND CODIGO_TRABAJADOR = @CODIGO_TRABAJADOR
	  AND (LEN(CONVERT(VARCHAR(10),CODIGO_IDENTIFICACION))=8 OR CODIGO_IDENTIFICACION = '1867')
	--AND TUO.ESTADO_REGISTRO = '1'
END

GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_UPD]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [GRL].[USP_TRABAJADOR_UPD]    Script Date: 22/05/2015 01:28:12 a.m. ******/

CREATE PROC [GRL].[USP_TRABAJADOR_UPD]
(
    @CODIGO_TRABAJADOR					UNIQUEIDENTIFIER,
    @CODIGO_IDENTIFICACION				nvarchar(50),
	@CODIGO_TIPO_DOCUMENTO_IDENTIDAD	nvarchar(5),
	@NUMERO_DOCUMENTO_IDENTIDAD			nvarchar(15),
	@APELLIDO_PATERNO					nvarchar(50),
	@APELLIDO_MATERNO					nvarchar(50),
	@NOMBRES							nvarchar(50),
	@NOMBRE_COMPLETO					nvarchar(255),
	@ORGANIZACION						nvarchar(255),
	@DEPARTAMENTO						nvarchar(255),
	@CARGO								nvarchar(255),
	@TELEFONO_TRABAJO					nvarchar(15),
	@ANEXO								nvarchar(10),
	@TELEFONO_MOVIL						nvarchar(15),
	@TELEFONO_PERSONAL					nvarchar(15),
	@CORREO_ELECTRONICO					nvarchar(50),
	@ESTADO_REGISTRO					char(1),
	@USUARIO_MODIFICACION				nvarchar(50),
    @TERMINAL_MODIFICACION				nvarchar(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_TRABAJADOR_UPD
Propósito: Actualiza registros de la tabla Trabajador
Descripción de Parámetros: 
		@CODIGO_TRABAJADOR:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo trabajador.
		@CODIGO_IDENTIFICACION:	Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.
		@CODIGO_TIPO_DOCUMENTO_IDENTIDAD:	Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento identidad.
		@NUMERO_DOCUMENTO_IDENTIDAD:	Parámetro de entrada de tipo nvarchar, que representa numero documento identidad.
		@APELLIDO_PATERNO:	Parámetro de entrada de tipo nvarchar, que representa apellido paterno.
		@APELLIDO_MATERNO:	Parámetro de entrada de tipo nvarchar, que representa apellido materno.
		@NOMBRES:	Parámetro de entrada de tipo nvarchar, que representa nombres.
		@NOMBRE_COMPLETO:	Parámetro de entrada de tipo nvarchar, que representa nombre completo.
		@ORGANIZACION:	Parámetro de entrada de tipo nvarchar, que representa organizacion.
		@DEPARTAMENTO:	Parámetro de entrada de tipo nvarchar, que representa departamento.
		@CARGO:	Parámetro de entrada de tipo nvarchar, que representa cargo.
		@TELEFONO_TRABAJO:	Parámetro de entrada de tipo nvarchar, que representa telefono trabajo.
		@ANEXO:	Parámetro de entrada de tipo nvarchar, que representa anexo.
		@TELEFONO_MOVIL:	Parámetro de entrada de tipo nvarchar, que representa telefono movil.
		@TELEFONO_PERSONAL:	Parámetro de entrada de tipo nvarchar, que representa telefono personal.
		@CORREO_ELECTRONICO:	Parámetro de entrada de tipo nvarchar, que representa correo electronico.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
        BEGIN
            UPDATE  GRL.TRABAJADOR
            SET     CODIGO_IDENTIFICACION			=	@CODIGO_IDENTIFICACION,
					CODIGO_TIPO_DOCUMENTO_IDENTIDAD	=	@CODIGO_TIPO_DOCUMENTO_IDENTIDAD,
					NUMERO_DOCUMENTO_IDENTIDAD		=	@NUMERO_DOCUMENTO_IDENTIDAD,
					APELLIDO_PATERNO				=	@APELLIDO_PATERNO,
					APELLIDO_MATERNO				=	@APELLIDO_MATERNO,
					NOMBRES							=	@NOMBRES,
					NOMBRE_COMPLETO					=	@NOMBRE_COMPLETO,
					ORGANIZACION					=	@ORGANIZACION,
					DEPARTAMENTO					=	@DEPARTAMENTO,
					CARGO							=	@CARGO,
					TELEFONO_TRABAJO				=	@TELEFONO_TRABAJO,
					TELEFONO_PERSONAL				=	@TELEFONO_PERSONAL,
					CORREO_ELECTRONICO				=	@CORREO_ELECTRONICO,
                    ESTADO_REGISTRO					=	@ESTADO_REGISTRO ,
                    USUARIO_MODIFICACION			=	@USUARIO_MODIFICACION ,
                    FECHA_MODIFICACION				=	GRL.FN_OBTENER_FECHA_SERVIDOR(NULL,NULL),
                    TERMINAL_MODIFICACION			=	@TERMINAL_MODIFICACION
            WHERE   CODIGO_TRABAJADOR				=	@CODIGO_TRABAJADOR
            SELECT  1
        END


GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_CI_EXISTE_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_UNIDAD_OPERATIVA_CI_EXISTE_SEL]
@CODIGO_IDENTIFICACION NVARCHAR(50)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_UNIDAD_OPERATIVA_CI_EXISTE_SEL
Propósito: Retorna registro de la tabla Unidad_operativa
Descripción de Parámetros: 
		@CODIGO_IDENTIFICACION:	Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
SELECT  CODIGO_UNIDAD_OPERATIVA CodigoUnidadOperativa
FROM 	GRL.UNIDAD_OPERATIVA
WHERE   CODIGO_IDENTIFICACION = @CODIGO_IDENTIFICACION
AND		ESTADO_REGISTRO = '1'


GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_INS]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_INS]    Script Date: 22/05/2015 01:28:32 a.m. ******/

CREATE PROCEDURE [GRL].[USP_UNIDAD_OPERATIVA_INS]
(
	@CODIGO_UNIDAD_OPERATIVA		UNIQUEIDENTIFIER,
    @NOMBRE							VARCHAR(255),
    @INDICADOR_ACTIVA				bit,
	@CODIGO_NIVEL_JERARQUIA			nvarchar(5),
	@CODIGO_UNIDAD_OPERATIVA_PADRE	UNIQUEIDENTIFIER,
	@CODIGO_TIPO_UNIDAD_OPERATIVA	int,
	@CODIGO_RESPONSABLE				uniqueidentifier,
	@CODIGO_ZONA_HORARIA			uniqueidentifier,
    @USUARIO_CREACION				nvarchar(50),
    @TERMINAL_CREACION				nvarchar(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_UNIDAD_OPERATIVA_INS
Propósito: Inserta registros en la tabla Unidad_operativa
Descripción de Parámetros: 
		@CODIGO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@NOMBRE:	Parámetro de entrada de tipo varchar, que representa nombre.
		@INDICADOR_ACTIVA:	Parámetro de entrada de tipo bit, que representa indicador activa.
		@CODIGO_NIVEL_JERARQUIA:	Parámetro de entrada de tipo nvarchar, que representa codigo nivel jerarquia.
		@CODIGO_UNIDAD_OPERATIVA_PADRE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa padre.
		@CODIGO_TIPO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo int, que representa codigo tipo unidad operativa.
		@CODIGO_RESPONSABLE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo responsable.
		@CODIGO_ZONA_HORARIA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo zona horaria.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
        BEGIN 
            INSERT  INTO GRL.UNIDAD_OPERATIVA
                    ( CODIGO_UNIDAD_OPERATIVA ,
                      NOMBRE ,
                      INDICADOR_ACTIVA ,
                      CODIGO_NIVEL_JERARQUIA ,
                      CODIGO_UNIDAD_OPERATIVA_PADRE ,
                      CODIGO_TIPO_UNIDAD_OPERATIVA ,
                      CODIGO_RESPONSABLE ,
                      CODIGO_ZONA_HORARIA ,
                      ESTADO_REGISTRO ,
                      USUARIO_CREACION ,
                      FECHA_CREACION ,
                      TERMINAL_CREACION
                    )
            VALUES  ( @CODIGO_UNIDAD_OPERATIVA ,
                      @NOMBRE ,
                      @INDICADOR_ACTIVA ,
                      @CODIGO_NIVEL_JERARQUIA ,
                      @CODIGO_UNIDAD_OPERATIVA_PADRE ,
                      @CODIGO_TIPO_UNIDAD_OPERATIVA ,
                      @CODIGO_RESPONSABLE ,
                      @CODIGO_ZONA_HORARIA ,
                      1,
                      @USUARIO_CREACION ,
                      GRL.FN_OBTENER_FECHA_SERVIDOR(NULL,NULL),
                      @TERMINAL_CREACION
                    )
			SELECT  1               					    
        END
 

GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_LISTA_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [GRL].[USP_UNIDAD_OPERATIVA_LISTA_SEL]
(
	@CODIGOS_UNIDAD_OPERATIVA	LISTA_GUID_TYPE READONLY
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_UNIDAD_OPERATIVA_LISTA_SEL
Propósito: Retorna registros de la tabla Unidad_operativa
Descripción de Parámetros: 
		@CODIGOS_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo LISTA_GUID_TYPE, que representa codigos unidad operativa.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	SELECT	UO.CODIGO_UNIDAD_OPERATIVA CodigoUnidadOperativa,
			UO.NOMBRE Nombre,
			UO.INDICADOR_ACTIVA IndicadorActiva,
			UO.CODIGO_NIVEL_JERARQUIA CodigoNivelJerarquia,
			UO.CODIGO_RESPONSABLE CodigoResponsable,
			(SELECT T.NOMBRE_COMPLETO FROM GRL.TRABAJADOR T WHERE T.CODIGO_TRABAJADOR = UO.CODIGO_RESPONSABLE) NombreResponsable,
			UO.CODIGO_TIPO_UNIDAD_OPERATIVA CodigoTipoUnidadOperativa,
			UO.CODIGO_UNIDAD_OPERATIVA_PADRE CodigoUnidadOperativaPadre,
			(SELECT UOP.NOMBRE FROM GRL.UNIDAD_OPERATIVA UOP WHERE UOP.CODIGO_UNIDAD_OPERATIVA = UO.CODIGO_UNIDAD_OPERATIVA_PADRE) NombreUnidadOperativaPadre,
			UO.CODIGO_ZONA_HORARIA
	FROM	GRL.UNIDAD_OPERATIVA UO
	WHERE	UO.ESTADO_REGISTRO = '1'
	AND		EXISTS (SELECT	1 
					FROM	@CODIGOS_UNIDAD_OPERATIVA CUO
					WHERE	CUO.CODIGO = UO.CODIGO_UNIDAD_OPERATIVA)
END

GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_NOMBRE_EXISTE_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_UNIDAD_OPERATIVA_NOMBRE_EXISTE_SEL]
@NOMBRE NVARCHAR(255)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_UNIDAD_OPERATIVA_NOMBRE_EXISTE_SEL
Propósito: Retorna registros de la tabla Unidad_operativa
Descripción de Parámetros: 
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
SELECT  CODIGO_UNIDAD_OPERATIVA CodigoUnidadOperativa
FROM 	GRL.UNIDAD_OPERATIVA
WHERE   NOMBRE = @NOMBRE
AND		ESTADO_REGISTRO = '1'

GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_PADRE_POR_NIVEL_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [GRL].[USP_UNIDAD_OPERATIVA_PADRE_POR_NIVEL_SEL]
@CODIGO_UNIDAD_OPERATIVA UNIQUEIDENTIFIER,
@CODIGO_NIVEL_JERARQUIA NVARCHAR(5)
AS
BEGIN	
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_UNIDAD_OPERATIVA_PADRE_POR_NIVEL_SEL
Propósito: Obtener la unidad operativa por nivel
Descripción de Parámetros: 
		@CODIGO_UNIDAD_OPERATIVA: Código de la unidad operativa padre	
		@CODIGO_NIVEL_JERARQUIA: Código del nivel de jerarquía
Creado por: GMD
Fecha. Creación: 2016-11-04
Fecha. Actualización: 
**********************************************************************************************************************************/
DECLARE
	@CODIGO_UNIDAD_OPERATIVA_PADRE UNIQUEIDENTIFIER,
	@CODIGO_UNIDAD_OPERATIVA_MATRIZ UNIQUEIDENTIFIER,
	@CODIGO_NIVEL_JERARQUIA_EMPRESA NVARCHAR(5),
	@CODIGO_NIVEL_JERARQUIA_MATRIZ NVARCHAR(5)

	SELECT @CODIGO_UNIDAD_OPERATIVA_PADRE = CODIGO_UNIDAD_OPERATIVA_PADRE FROM [GRL].[UNIDAD_OPERATIVA]
	WHERE CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA

	SELECT @CODIGO_NIVEL_JERARQUIA_EMPRESA = VALOR FROM [GRL].[PARAMETRO_VALOR]
	WHERE CODIGO_PARAMETRO = 1 AND CODIGO_VALOR = 2 AND ESTADO_REGISTRO = 1 AND CODIGO_SECCION = 1

	SELECT @CODIGO_NIVEL_JERARQUIA_MATRIZ = VALOR FROM [GRL].[PARAMETRO_VALOR]
	WHERE CODIGO_PARAMETRO = 1 AND CODIGO_VALOR = 1 AND ESTADO_REGISTRO = 1 AND CODIGO_SECCION = 1

IF (@CODIGO_NIVEL_JERARQUIA = @CODIGO_NIVEL_JERARQUIA_EMPRESA)
BEGIN
	SELECT 
	CODIGO_UNIDAD_OPERATIVA CodigoUnidadOperativa, 
	CODIGO_IDENTIFICACION CodigoIdentificacion,
	NOMBRE Nombre, 
	INDICADOR_ACTIVA IndicadorActiva, 
	CODIGO_NIVEL_JERARQUIA CodigoNivelJerarquia, 
	CODIGO_UNIDAD_OPERATIVA_PADRE CodigoUnidadOperativaPadre,
	CODIGO_TIPO_UNIDAD_OPERATIVA CodigoTipoUnidadOperativa, 
	CODIGO_RESPONSABLE CodigoResponsable
	FROM [GRL].[UNIDAD_OPERATIVA]
	WHERE CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA_PADRE
END
IF (@CODIGO_NIVEL_JERARQUIA = @CODIGO_NIVEL_JERARQUIA_MATRIZ)
BEGIN
	
	IF (@CODIGO_NIVEL_JERARQUIA_MATRIZ = (SELECT CODIGO_NIVEL_JERARQUIA
		FROM [GRL].[UNIDAD_OPERATIVA]
		WHERE CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA_PADRE))
	
	BEGIN
		SELECT 
		CODIGO_UNIDAD_OPERATIVA CodigoUnidadOperativa, 
		CODIGO_IDENTIFICACION CodigoIdentificacion,
		NOMBRE Nombre, 
		INDICADOR_ACTIVA IndicadorActiva, 
		CODIGO_NIVEL_JERARQUIA CodigoNivelJerarquia, 
		CODIGO_UNIDAD_OPERATIVA_PADRE CodigoUnidadOperativaPadre,
		CODIGO_TIPO_UNIDAD_OPERATIVA CodigoTipoUnidadOperativa, 
		CODIGO_RESPONSABLE CodigoResponsable
		FROM [GRL].[UNIDAD_OPERATIVA]
		WHERE CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA_PADRE	
	END
	ELSE
	BEGIN	
		SELECT @CODIGO_UNIDAD_OPERATIVA_MATRIZ = CODIGO_UNIDAD_OPERATIVA_PADRE	
		FROM [GRL].[UNIDAD_OPERATIVA]
		WHERE CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA_PADRE

		SELECT 
		CODIGO_UNIDAD_OPERATIVA CodigoUnidadOperativa, 
		CODIGO_IDENTIFICACION CodigoIdentificacion,
		NOMBRE Nombre, 
		INDICADOR_ACTIVA IndicadorActiva, 
		CODIGO_NIVEL_JERARQUIA CodigoNivelJerarquia, 
		CODIGO_UNIDAD_OPERATIVA_PADRE CodigoUnidadOperativaPadre,
		CODIGO_TIPO_UNIDAD_OPERATIVA CodigoTipoUnidadOperativa, 
		CODIGO_RESPONSABLE CodigoResponsable
		FROM [GRL].[UNIDAD_OPERATIVA]
		WHERE CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA_MATRIZ	
	END
END

END

GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_PROYECTO_POR_EMPRESA_MATRIZ_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [GRL].[USP_UNIDAD_OPERATIVA_PROYECTO_POR_EMPRESA_MATRIZ_SEL] --'e3a26705-508a-4ebc-a027-0252aa9799ed'
(
	@CODIGO_UNIDAD_OPERATIVA_MATRIZ	UNIQUEIDENTIFIER
)
AS
BEGIN
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_PROYECTOS_POR_UNIDAD_OPERATIVA_MATRIZ_SEL
Propósito: Retorna todos los proyectos de la tabla Unidad Operativa que tengan el codigo de unidad matriz
Descripción de Parámetros: 
		@CODIGO_UNIDAD_OPERATIVA_MATRIZ:	Parámetro de entrada de tipo LISTA_GUID_TYPE, que representa codigos trabajadores.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/

SELECT	CODIGO_UNIDAD_OPERATIVA
INTO	#TMP_EMPRESAS
FROM	GRL.UNIDAD_OPERATIVA
WHERE	CODIGO_UNIDAD_OPERATIVA_PADRE = @CODIGO_UNIDAD_OPERATIVA_MATRIZ
AND		CODIGO_NIVEL_JERARQUIA = '02'
AND		ESTADO_REGISTRO = '1'

SELECT [CODIGO_UNIDAD_OPERATIVA]		AS CodigoUnidadOperativa
      ,[CODIGO_IDENTIFICACION]			AS CodigoIdentificacion
      ,[NOMBRE]							AS Nombre
      ,[INDICADOR_ACTIVA]				AS IndicadorActiva
      ,[CODIGO_NIVEL_JERARQUIA]			AS CodigoNivelJerarquia
      ,[CODIGO_UNIDAD_OPERATIVA_PADRE]	AS CodigoUnidadOperativaPadre
      ,[CODIGO_TIPO_UNIDAD_OPERATIVA]	AS CodigoTipoUnidadOperativa
      ,[CODIGO_RESPONSABLE]				AS CodigoResponsable
      ,[CODIGO_ZONA_HORARIA]			AS CodigoZonaHoraria
      ,[CODIGO_PRIMER_REPRESENTANTE]	AS CodigoPrimerRepresentante
      ,[CODIGO_SEGUNDO_REPRESENTANTE]	AS CodigoSegundoRepresentante
      ,[DIRECCION]						AS Direccion
FROM	GRL.UNIDAD_OPERATIVA
WHERE	CODIGO_UNIDAD_OPERATIVA_PADRE IN (SELECT CODIGO_UNIDAD_OPERATIVA FROM #TMP_EMPRESAS)
AND		ESTADO_REGISTRO = '1'

END

GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_REEMP_REPRESENTANTES_DTS_UPD]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [GRL].[USP_UNIDAD_OPERATIVA_REEMP_REPRESENTANTES_DTS_UPD] --'5A48CFD4-A508-4996-AB39-9E668BA65275', '8E6EBE57-31AE-4711-B076-6BA0BAFCDE66', 1
(
	@CODIGO_SUPLENTE				UNIQUEIDENTIFIER, 
	@CODIGO_TRABAJADOR				UNIQUEIDENTIFIER,
	@ES_REEMPLAZO					BIT
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
IF(@ES_REEMPLAZO = 1)
BEGIN
	UPDATE GRL.UNIDAD_OPERATIVA
	SET 
		CODIGO_PRIMER_REPRESENTANTE = @CODIGO_SUPLENTE
	WHERE CODIGO_PRIMER_REPRESENTANTE_ORIGINAL = @CODIGO_TRABAJADOR

	UPDATE GRL.UNIDAD_OPERATIVA
	SET 
		 CODIGO_SEGUNDO_REPRESENTANTE = @CODIGO_SUPLENTE
	WHERE CODIGO_SEGUNDO_REPRESENTANTE_ORIGINAL = @CODIGO_TRABAJADOR

	UPDATE GRL.UNIDAD_OPERATIVA
	SET 
		CODIGO_TERCER_REPRESENTANTE = @CODIGO_SUPLENTE
	WHERE CODIGO_TERCER_REPRESENTANTE_ORIGINAL = @CODIGO_TRABAJADOR

	UPDATE GRL.UNIDAD_OPERATIVA
	SET 
		CODIGO_CUARTO_REPRESENTANTE = @CODIGO_SUPLENTE
	WHERE CODIGO_CUARTO_REPRESENTANTE_ORIGINAL = @CODIGO_TRABAJADOR
END
ELSE
BEGIN
	UPDATE GRL.UNIDAD_OPERATIVA
	SET 
		CODIGO_PRIMER_REPRESENTANTE = @CODIGO_TRABAJADOR
	WHERE CODIGO_PRIMER_REPRESENTANTE_ORIGINAL = @CODIGO_TRABAJADOR

	UPDATE GRL.UNIDAD_OPERATIVA
	SET 
		 CODIGO_SEGUNDO_REPRESENTANTE = @CODIGO_TRABAJADOR
	WHERE CODIGO_SEGUNDO_REPRESENTANTE_ORIGINAL = @CODIGO_TRABAJADOR

	UPDATE GRL.UNIDAD_OPERATIVA
	SET 
		CODIGO_TERCER_REPRESENTANTE = @CODIGO_TRABAJADOR
	WHERE CODIGO_TERCER_REPRESENTANTE_ORIGINAL = @CODIGO_TRABAJADOR

	UPDATE GRL.UNIDAD_OPERATIVA
	SET 
		CODIGO_CUARTO_REPRESENTANTE = @CODIGO_TRABAJADOR
	WHERE CODIGO_CUARTO_REPRESENTANTE_ORIGINAL = @CODIGO_TRABAJADOR
END

END

GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_RESPONSABLES_POR_NIVEL_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [GRL].[USP_UNIDAD_OPERATIVA_RESPONSABLES_POR_NIVEL_SEL]
@CODIGO_UNIDAD_OPERATIVA UNIQUEIDENTIFIER = NULL,
@NOMBRE_UNIDAD_OPERATIVA NVARCHAR(200) = NULL
AS
BEGIN
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_UNIDAD_OPERATIVA_RESPONSABLES_POR_NIVEL_SEL
Propósito: Retorna los responsables de la unidad operativa y de sus niveles superiores
Descripción de Parámetros: 
	@CODIGO_UNIDAD_OPERATIVA: Código de la Unidad Operativa
	@NOMBRE_UNIDAD_OPERATIVA: Nombre de la Unidad Operativa
Creado por: GMD
Fecha. Creación: 2016-11-29
Fecha. Actualización: 
**********************************************************************************************************************************/
	
  DECLARE 
  @CODIGO_UNIDAD_OPERATIVA_N2 UNIQUEIDENTIFIER, 
  @CODIGO_UNIDAD_OPERATIVA_N3 UNIQUEIDENTIFIER, 
  @CODIGO_RESPONSABLE_N2 UNIQUEIDENTIFIER,
  @CODIGO_RESPONSABLE_N3 UNIQUEIDENTIFIER

  DECLARE @CODIGO_UNIDAD UNIQUEIDENTIFIER, 
  @CODIGO_NIVEL_JERARQUIA NVARCHAR(50),
  @CODIGO_UNIDAD_OPERATIVA_PADRE UNIQUEIDENTIFIER,
  @CODIGO_RESPONSABLE UNIQUEIDENTIFIER,
  @CODIGO_NIVEL_JERARQUIA_EMPRESA NVARCHAR(5),
  @CODIGO_NIVEL_JERARQUIA_MATRIZ NVARCHAR(5)   

  SELECT 
	  @CODIGO_UNIDAD = CODIGO_UNIDAD_OPERATIVA, 
	  @CODIGO_NIVEL_JERARQUIA = CODIGO_NIVEL_JERARQUIA, 
	  @CODIGO_UNIDAD_OPERATIVA_PADRE = CODIGO_UNIDAD_OPERATIVA_PADRE,
	  @CODIGO_RESPONSABLE = CODIGO_RESPONSABLE 
  FROM GRL.UNIDAD_OPERATIVA 
  WHERE NOMBRE = @NOMBRE_UNIDAD_OPERATIVA
		OR CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA   

  SELECT @CODIGO_NIVEL_JERARQUIA_EMPRESA = VALOR 
  FROM [GRL].[PARAMETRO_VALOR]
  WHERE CODIGO_PARAMETRO = 1 AND CODIGO_VALOR = 2 AND ESTADO_REGISTRO = 1 AND CODIGO_SECCION = 1

  SELECT @CODIGO_NIVEL_JERARQUIA_MATRIZ = VALOR 
  FROM [GRL].[PARAMETRO_VALOR]
  WHERE CODIGO_PARAMETRO = 1 AND CODIGO_VALOR = 1 AND ESTADO_REGISTRO = 1 AND CODIGO_SECCION = 1


  IF (@CODIGO_NIVEL_JERARQUIA = @CODIGO_NIVEL_JERARQUIA_MATRIZ)
	  BEGIN

	   SELECT
			@CODIGO_NIVEL_JERARQUIA 'CodigoNivelJerarquia', 
			NULL 'CodigoUnidadOperativaNivel1', 
			NULL'CodigoResponsableNivel1', 
			NULL 'CodigoUnidadOperativaNivel2', 
			NULL 'CodigoResponsableNivel2',	
			@CODIGO_UNIDAD 'CodigoUnidadOperativaNivel3', 
			@CODIGO_RESPONSABLE 'CodigoResponsableNivel3' 
  END
  
  ELSE
	  BEGIN
	  IF (@CODIGO_NIVEL_JERARQUIA = @CODIGO_NIVEL_JERARQUIA_EMPRESA)
	  BEGIN

		SELECT 
			@CODIGO_UNIDAD_OPERATIVA_N3 = CODIGO_UNIDAD_OPERATIVA, 
			@CODIGO_RESPONSABLE_N3 = CODIGO_RESPONSABLE 
		FROM GRL.UNIDAD_OPERATIVA 
		WHERE CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA_PADRE

		SELECT 
		    @CODIGO_NIVEL_JERARQUIA 'CodigoNivelJerarquia', 
			NULL 'CodigoUnidadOperativaNivel1', 
			NULL'CodigoResponsableNivel1', 
			@CODIGO_UNIDAD 'CodigoUnidadOperativaNivel2', 
			@CODIGO_RESPONSABLE 'CodigoResponsableNivel2',	
			@CODIGO_UNIDAD_OPERATIVA_N3 'CodigoUnidadOperativaNivel3', 
			@CODIGO_RESPONSABLE_N3 'CodigoResponsableNivel3'

	  END
	  ELSE
	  BEGIN

		 SELECT 
			@CODIGO_UNIDAD_OPERATIVA_N2 = CODIGO_UNIDAD_OPERATIVA, 
			@CODIGO_RESPONSABLE_N2 = CODIGO_RESPONSABLE, 
			@CODIGO_UNIDAD_OPERATIVA_PADRE = CODIGO_UNIDAD_OPERATIVA_PADRE 
		  FROM GRL.UNIDAD_OPERATIVA 
		  WHERE CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA_PADRE

		  SELECT 
				@CODIGO_UNIDAD_OPERATIVA_N3 = CODIGO_UNIDAD_OPERATIVA, 
				@CODIGO_RESPONSABLE_N3 = CODIGO_RESPONSABLE 
		  FROM GRL.UNIDAD_OPERATIVA 
		  WHERE CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA_PADRE

		  SELECT 
		    @CODIGO_NIVEL_JERARQUIA 'CodigoNivelJerarquia', 
			@CODIGO_UNIDAD 'CodigoUnidadOperativaNivel1', 
			@CODIGO_RESPONSABLE 'CodigoResponsableNivel1',
			@CODIGO_UNIDAD_OPERATIVA_N2 'CodigoUnidadOperativaNivel2', 
			@CODIGO_RESPONSABLE_N2 'CodigoResponsableNivel2',
			@CODIGO_UNIDAD_OPERATIVA_N3 'CodigoUnidadOperativaNivel3', 
			@CODIGO_RESPONSABLE_N3 'CodigoResponsableNivel3'
	  END
  END

		
END
GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [GRL].[USP_UNIDAD_OPERATIVA_SEL] 
(
	@CODIGO_UNIDAD_OPERATIVA		UNIQUEIDENTIFIER,
	@NOMBRE							nvarchar(255),
    @CODIGO_NIVEL_JERARQUIA			nvarchar(5),
	@CODIGO_UNIDAD_OPERATIVA_PADRE	UNIQUEIDENTIFIER,
	@INDICADOR_ACTIVA				nvarchar(1),
    @NUMERO_PAGINA					INT = 1 ,
    @TAMANIO_PAGINA					INT = -1
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_UNIDAD_OPERATIVA_SEL
Propósito: Retorna registros de la tabla Unidad_operativa
Descripción de Parámetros: 
		@CODIGO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@CODIGO_NIVEL_JERARQUIA:	Parámetro de entrada de tipo nvarchar, que representa codigo nivel jerarquia.
		@CODIGO_UNIDAD_OPERATIVA_PADRE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa padre.
		@INDICADOR_ACTIVA:	Parámetro de entrada de tipo nvarchar, que representa indicador activa.
		@NUMERO_PAGINA:	Parámetro de entrada de tipo int, que representa numero pagina.
		@TAMANIO_PAGINA:	Parámetro de entrada de tipo int, que representa tamanio pagina.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	
	DECLARE @lPageNbr INT
	DECLARE @lPageSize INT
	DECLARE @lFirstRec INT
	DECLARE @lLAStRec INT
	DECLARE @lActivo BIT

	SET @lPageNbr = @NUMERO_PAGINA
	SET @lPageSize = @TAMANIO_PAGINA

	SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
	SET @lLAStRec = ( @lPageNbr * @lPageSize + 1 );

	SELECT @NOMBRE =  '%' + isnull(@NOMBRE,'') + '%'
	

	SET @lActivo = NULL
	IF @INDICADOR_ACTIVA = '1' BEGIN
		SET @lActivo = 1
	END
	ELSE IF @INDICADOR_ACTIVA = '0' BEGIN
		SET @lActivo = 0
	END;

    WITH CTE_Results
		AS ( SELECT ROW_NUMBER() OVER ( ORDER BY CONVERT(INT, N.VALOR), NOMBRE ASC ) AS RowNumber ,
					COUNT(UO.CODIGO_UNIDAD_OPERATIVA) OVER ( ) AS RowsTotal ,
					CONVERT(VARCHAR, COUNT(*) OVER ( )) AS RowId ,
					CODIGO_UNIDAD_OPERATIVA AS CodigoUnidadOperativa ,
					CODIGO_IDENTIFICACION AS CodigoIdentificacion ,
					NOMBRE AS Nombre ,
					CODIGO_NIVEL_JERARQUIA AS CodigoNivelJerarquia ,
					CODIGO_UNIDAD_OPERATIVA_PADRE AS CodigoUnidadOperativaPadre ,                     
					CODIGO_TIPO_UNIDAD_OPERATIVA AS CodigoTipoUnidadOperativa ,
					INDICADOR_ACTIVA AS IndicadorActiva,
					CODIGO_RESPONSABLE AS CodigoResponsable,
					CODIGO_PRIMER_REPRESENTANTE AS CodigoPrimerRepresentante,
					CODIGO_SEGUNDO_REPRESENTANTE AS CodigoSegundoRepresentante,
					CODIGO_TERCER_REPRESENTANTE AS CodigoTercerRepresentante,
					CODIGO_CUARTO_REPRESENTANTE AS CodigoCuartoRepresentante,
					DIRECCION AS Direccion,
					LOGO_UNIDAD_OPERATIVA AS LogoUnidadOperativa
			FROM    GRL.UNIDAD_OPERATIVA UO
			INNER   JOIN GRL.FN_LISTAR_VALORES_PARAMETRO('STR', 1, NULL, '00001', 3) N
			   ON   N.CODIGO = UO.CODIGO_NIVEL_JERARQUIA
			WHERE	UO.ESTADO_REGISTRO = '1'
			AND		( @CODIGO_UNIDAD_OPERATIVA IS NULL OR CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA)
			AND		( @NOMBRE IS NULL OR NOMBRE LIKE @NOMBRE)
			AND		( @CODIGO_NIVEL_JERARQUIA IS NULL OR CODIGO_NIVEL_JERARQUIA = @CODIGO_NIVEL_JERARQUIA)
			AND		( @CODIGO_UNIDAD_OPERATIVA_PADRE IS NULL OR CODIGO_UNIDAD_OPERATIVA_PADRE = @CODIGO_UNIDAD_OPERATIVA_PADRE)
			AND		( @lActivo IS NULL OR INDICADOR_ACTIVA = @lActivo)
			)
			
	SELECT  RowNumber NumeroFila,
			RowsTotal FilasTotal,
			RowId IdentificadorFila,
			CodigoUnidadOperativa,
			CodigoIdentificacion,
			Nombre,
			CodigoNivelJerarquia,
			CodigoUnidadOperativaPadre,
			(SELECT UO.NOMBRE FROM GRL.UNIDAD_OPERATIVA UO WHERE UO.CODIGO_UNIDAD_OPERATIVA =  R.CodigoUnidadOperativaPadre AND UO.ESTADO_REGISTRO = '1') AS NombreUnidadOperativaPadre,
			CodigoTipoUnidadOperativa,
			IndicadorActiva,
			CodigoResponsable,
			(SELECT T.NOMBRE_COMPLETO FROM GRL.TRABAJADOR T WHERE T.CODIGO_TRABAJADOR = R.CodigoResponsable AND T.ESTADO_REGISTRO = '1') AS NombreResponsable,
			CodigoPrimerRepresentante,
			(SELECT T.NOMBRE_COMPLETO FROM GRL.TRABAJADOR T WHERE T.CODIGO_TRABAJADOR = R.CodigoPrimerRepresentante AND T.ESTADO_REGISTRO = '1') AS NombrePrimerRepresentante,
			CodigoSegundoRepresentante,
			(SELECT T.NOMBRE_COMPLETO FROM GRL.TRABAJADOR T WHERE T.CODIGO_TRABAJADOR = R.CodigoSegundoRepresentante AND T.ESTADO_REGISTRO = '1') AS NombreSegundoRepresentante,
			CodigoTercerRepresentante,
			(SELECT T.NOMBRE_COMPLETO FROM GRL.TRABAJADOR T WHERE T.CODIGO_TRABAJADOR = R.CodigoTercerRepresentante AND T.ESTADO_REGISTRO = '1') AS NombreTercerRepresentante,
			CodigoCuartoRepresentante,
			(SELECT T.NOMBRE_COMPLETO FROM GRL.TRABAJADOR T WHERE T.CODIGO_TRABAJADOR = R.CodigoCuartoRepresentante AND T.ESTADO_REGISTRO = '1') AS NombreCuartoRepresentante,
			Direccion,
			LogoUnidadOperativa
	  FROM  CTE_Results R
	 WHERE  @TAMANIO_PAGINA < 0
		OR  (RowNumber > @lFirstRec AND RowNumber < @lLAStRec)
END


GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_STAFF_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [GRL].[USP_UNIDAD_OPERATIVA_STAFF_SEL]
(
	@CODIGO_UNIDAD_OPERATIVA		UNIQUEIDENTIFIER,
	@NUMERO_PAGINA					INT = 1 ,
    @TAMANIO_PAGINA					INT = -1
)
AS
BEGIN
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_UNIDAD_OPERATIVA_STAFF_SEL
Propósito: Retorna registros de la tabla Unidad_Operativa_Staff
Descripción de Parámetros: 
		@CODIGO_SISTEMA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo sistema.
		@CODIGO_TRABAJADOR:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo trabajador.

Creado por: GMD
Fecha. Creación: 2016-06-23
Fecha. Actualización: 
**********************************************************************************************************************************/
	DECLARE @lPageNbr INT
	DECLARE @lPageSize INT
	DECLARE @lFirstRec INT
	DECLARE @lLAStRec INT

	SET @lPageNbr = @NUMERO_PAGINA
	SET @lPageSize = @TAMANIO_PAGINA

	SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
	SET @lLAStRec = ( @lPageNbr * @lPageSize + 1 );

	WITH CTE_Results AS(
		SELECT  ROW_NUMBER()OVER(ORDER BY UO.CODIGO_UNIDAD_OPERATIVA ASC)AS RowNumber
              ,COUNT(*)OVER()AS RowsTotal
              ,CONVERT(VARCHAR, COUNT(*)OVER())AS RowId
			  ,UO.[CODIGO_UNIDAD_OPERATIVA_STAFF] AS CodigoUnidadOperativaStaff
			  ,UO.[CODIGO_UNIDAD_OPERATIVA] AS CodigoUnidadOperativa
			  ,UO.[CODIGO_SISTEMA] AS CodigoSistema
			  ,UO.[CODIGO_TRABAJADOR] AS CodigoTrabajador
			  ,UO.[ESTADO_REGISTRO] AS EstadoRegistro
			  ,TR.NOMBRE_COMPLETO as NombreCompleto
			  ,ST.NOMBRE as NombreSistema

			FROM [GRL].[UNIDAD_OPERATIVA_STAFF] UO 
				INNER JOIN GRL.SISTEMA ST ON UO.CODIGO_SISTEMA=ST.CODIGO_SISTEMA 
				INNER JOIN GRL.TRABAJADOR TR ON UO.CODIGO_TRABAJADOR = TR.CODIGO_TRABAJADOR	
				INNER JOIN GRL.UNIDAD_OPERATIVA UN ON UO.CODIGO_UNIDAD_OPERATIVA = UN.CODIGO_UNIDAD_OPERATIVA			

			WHERE @CODIGO_UNIDAD_OPERATIVA IS NULL 
				OR UO.CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA AND UO.ESTADO_REGISTRO = 1
				)
		SELECT RowNumber, 
               RowsTotal, 
               RowId, 
               CodigoUnidadOperativaStaff, 
               CodigoUnidadOperativa, 
               CodigoSistema, 
               CodigoTrabajador, 
               EstadoRegistro,
			   NombreCompleto,
			   NombreSistema
          FROM CTE_Results R
         WHERE @TAMANIO_PAGINA < 0
            OR (RowNumber > @lFirstRec AND RowNumber < @lLAStRec)
			 ;

  END

GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_UPD]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_UPD]    Script Date: 22/05/2015 01:28:45 a.m. ******/

CREATE PROC [GRL].[USP_UNIDAD_OPERATIVA_UPD]
(
    @CODIGO_UNIDAD_OPERATIVA		UNIQUEIDENTIFIER,
    @NOMBRE							VARCHAR(255),
    @INDICADOR_ACTIVA				bit,
	@CODIGO_NIVEL_JERARQUIA			nvarchar(5),
	@CODIGO_UNIDAD_OPERATIVA_PADRE	UNIQUEIDENTIFIER,
	@CODIGO_TIPO_UNIDAD_OPERATIVA	int,
	@CODIGO_RESPONSABLE				uniqueidentifier,
	@CODIGO_ZONA_HORARIA			uniqueidentifier,
	@ESTADO_REGISTRO				char(1),
    @USUARIO_MODIFICACION			nvarchar(50),
    @TERMINAL_MODIFICACION			nvarchar(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_UNIDAD_OPERATIVA_UPD
Propósito: Actualiza los registros de la tabla Unidad_operativa
Descripción de Parámetros: 
		@CODIGO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.
		@NOMBRE:	Parámetro de entrada de tipo varchar, que representa nombre.
		@INDICADOR_ACTIVA:	Parámetro de entrada de tipo bit, que representa indicador activa.
		@CODIGO_NIVEL_JERARQUIA:	Parámetro de entrada de tipo nvarchar, que representa codigo nivel jerarquia.
		@CODIGO_UNIDAD_OPERATIVA_PADRE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa padre.
		@CODIGO_TIPO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo int, que representa codigo tipo unidad operativa.
		@CODIGO_RESPONSABLE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo responsable.
		@CODIGO_ZONA_HORARIA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo zona horaria.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
        BEGIN
            UPDATE  GRL.UNIDAD_OPERATIVA
            SET     NOMBRE							=	@NOMBRE,
					INDICADOR_ACTIVA				=	@INDICADOR_ACTIVA,
					CODIGO_NIVEL_JERARQUIA			=	@CODIGO_NIVEL_JERARQUIA,
					CODIGO_UNIDAD_OPERATIVA_PADRE	=	@CODIGO_UNIDAD_OPERATIVA_PADRE,
					CODIGO_TIPO_UNIDAD_OPERATIVA	=	@CODIGO_TIPO_UNIDAD_OPERATIVA,
					CODIGO_RESPONSABLE				=	@CODIGO_RESPONSABLE,
					CODIGO_ZONA_HORARIA				=	@CODIGO_ZONA_HORARIA,
                    ESTADO_REGISTRO					=	@ESTADO_REGISTRO ,
                    USUARIO_MODIFICACION			=	@USUARIO_MODIFICACION ,
                    FECHA_MODIFICACION				=	GRL.FN_OBTENER_FECHA_SERVIDOR(NULL,NULL),
                    TERMINAL_MODIFICACION			=	@TERMINAL_MODIFICACION
            WHERE   CODIGO_UNIDAD_OPERATIVA			=	@CODIGO_UNIDAD_OPERATIVA
            SELECT  1
        END


GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_USUARIO_CONSULTA_POR_TRABAJADOR_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [GRL].[USP_UNIDAD_OPERATIVA_USUARIO_CONSULTA_POR_TRABAJADOR_SEL]
@CODIGO_TRABAJADOR UNIQUEIDENTIFIER	
AS
BEGIN
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_UNIDAD_OPERATIVA_USUARIO_CONSULTA_POR_TRABAJADOR_SEL
Propósito: Retorna unidades operativas de consulta por trabajador
Descripción de Parámetros: 
	@CODIGO_TRABAJADOR: Código de trabajador	
Creado por: GMD
Fecha. Creación: 2016-12-01
Fecha. Actualización: 
**********************************************************************************************************************************/
	
		SELECT 
			UC.CODIGO_UNIDAD_OPERATIVA CodigoUnidadOperativa,
		    UN.NOMBRE NombreUnidadOperativa
		FROM GRL.UNIDAD_OPERATIVA_USUARIO_CONSULTA UC
		INNER JOIN GRL.UNIDAD_OPERATIVA UN ON UC.CODIGO_UNIDAD_OPERATIVA = UN.CODIGO_UNIDAD_OPERATIVA	
		WHERE CODIGO_TRABAJADOR = @CODIGO_TRABAJADOR
		AND UC.ESTADO_REGISTRO = 1
		
END

GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVA_USUARIO_CONSULTA_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [GRL].[USP_UNIDAD_OPERATIVA_USUARIO_CONSULTA_SEL]
@CODIGO_UNIDAD_OPERATIVA		UNIQUEIDENTIFIER	
AS
BEGIN
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_UNIDAD_USUARIO_CONSULTA_SEL
Propósito: Retorna los usuarios de consulta de la Unidad Operativa
Descripción de Parámetros: 
	@CODIGO_UNIDAD_OPERATIVA: Código de la Unidad Operativa	
Creado por: GMD
Fecha. Creación: 2016-11-22
Fecha. Actualización: 
**********************************************************************************************************************************/
	
		SELECT UO.[CODIGO_UNIDAD_OPERATIVA_USUARIO_CONSULTA] AS CodigoUnidadUsuarioConsulta
			  ,UO.[CODIGO_UNIDAD_OPERATIVA] AS CodigoUnidadOperativa			
			  ,UO.[CODIGO_TRABAJADOR] AS CodigoTrabajador
			  ,UO.[ESTADO_REGISTRO] AS EstadoRegistro
			  ,TR.NOMBRE_COMPLETO as NombreCompleto			
			  
			FROM [GRL].[UNIDAD_OPERATIVA_USUARIO_CONSULTA] UO 			
				INNER JOIN GRL.TRABAJADOR TR ON UO.CODIGO_TRABAJADOR = TR.CODIGO_TRABAJADOR	
				INNER JOIN GRL.UNIDAD_OPERATIVA UN ON UO.CODIGO_UNIDAD_OPERATIVA = UN.CODIGO_UNIDAD_OPERATIVA			

			WHERE @CODIGO_UNIDAD_OPERATIVA IS NULL OR UO.CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA 
			AND UO.ESTADO_REGISTRO = 1			
  END

GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDAD_OPERATIVASAP_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [GRL].[USP_UNIDAD_OPERATIVASAP_SEL] 

(

	@CODIGO_UNIDAD_OPERATIVA		UNIQUEIDENTIFIER,

	@NOMBRE							nvarchar(255),

    @CODIGO_NIVEL_JERARQUIA			nvarchar(5),

	@CODIGO_UNIDAD_OPERATIVA_PADRE	UNIQUEIDENTIFIER,

	@INDICADOR_ACTIVA				nvarchar(1),

    @NUMERO_PAGINA					INT = 1 ,

    @TAMANIO_PAGINA					INT = -1

)

AS

/**********************************************************************************************************************************

Nombre Objeto: GRL.USP_UNIDAD_OPERATIVA_SEL

Propósito: Retorna registros de la tabla Unidad_operativa

Descripción de Parámetros: 

		@CODIGO_UNIDAD_OPERATIVA:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.

		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.

		@CODIGO_NIVEL_JERARQUIA:	Parámetro de entrada de tipo nvarchar, que representa codigo nivel jerarquia.

		@CODIGO_UNIDAD_OPERATIVA_PADRE:	Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa padre.

		@INDICADOR_ACTIVA:	Parámetro de entrada de tipo nvarchar, que representa indicador activa.

		@NUMERO_PAGINA:	Parámetro de entrada de tipo int, que representa numero pagina.

		@TAMANIO_PAGINA:	Parámetro de entrada de tipo int, que representa tamanio pagina.

Creado por: GMD

Fecha. Creación: 2015-06-09

Fecha. Actualización: 

**********************************************************************************************************************************/

BEGIN

	

	DECLARE @lPageNbr INT

	DECLARE @lPageSize INT

	DECLARE @lFirstRec INT

	DECLARE @lLAStRec INT

	DECLARE @lActivo BIT



	SET @lPageNbr = @NUMERO_PAGINA

	SET @lPageSize = @TAMANIO_PAGINA



	SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize

	SET @lLAStRec = ( @lPageNbr * @lPageSize + 1 );



	SELECT @NOMBRE =  '%' + isnull(@NOMBRE,'') + '%'

	



	SET @lActivo = NULL

	IF @INDICADOR_ACTIVA = '1' BEGIN

		SET @lActivo = 1

	END

	ELSE IF @INDICADOR_ACTIVA = '0' BEGIN

		SET @lActivo = 0

	END;



    WITH CTE_Results

		AS ( SELECT ROW_NUMBER() OVER ( ORDER BY CONVERT(INT, N.VALOR), NOMBRE ASC ) AS RowNumber ,

					COUNT(UO.CODIGO_UNIDAD_OPERATIVA) OVER ( ) AS RowsTotal ,

					CONVERT(VARCHAR, COUNT(*) OVER ( )) AS RowId ,

					CODIGO_UNIDAD_OPERATIVA AS CodigoUnidadOperativa ,

					CODIGO_IDENTIFICACION AS CodigoIdentificacion ,

					NOMBRE AS Nombre ,

					CODIGO_NIVEL_JERARQUIA AS CodigoNivelJerarquia ,

					CODIGO_UNIDAD_OPERATIVA_PADRE AS CodigoUnidadOperativaPadre ,                     

					CODIGO_TIPO_UNIDAD_OPERATIVA AS CodigoTipoUnidadOperativa ,

					INDICADOR_ACTIVA AS IndicadorActiva,

					CODIGO_RESPONSABLE AS CodigoResponsable,

					CODIGO_PRIMER_REPRESENTANTE AS CodigoPrimerRepresentante,

					CODIGO_SEGUNDO_REPRESENTANTE AS CodigoSegundoRepresentante,

					CODIGO_TERCER_REPRESENTANTE AS CodigoTercerRepresentante,

					CODIGO_CUARTO_REPRESENTANTE AS CodigoCuartoRepresentante,

					DIRECCION AS Direccion,

					LOGO_UNIDAD_OPERATIVA AS LogoUnidadOperativa

			FROM    GRL.UNIDAD_OPERATIVA UO

			INNER   JOIN GRL.FN_LISTAR_VALORES_PARAMETRO('STR', 1, NULL, '00001', 3) N

			   ON   N.CODIGO = UO.CODIGO_NIVEL_JERARQUIA

			WHERE	UO.ESTADO_REGISTRO = '1'

			AND     (LEN(CONVERT(VARCHAR(10),CODIGO_IDENTIFICACION))=8 OR CODIGO_IDENTIFICACION = '1867')

			AND		( @CODIGO_UNIDAD_OPERATIVA IS NULL OR CODIGO_UNIDAD_OPERATIVA = @CODIGO_UNIDAD_OPERATIVA)

			AND		( @NOMBRE IS NULL OR NOMBRE LIKE @NOMBRE)

			AND		( @CODIGO_NIVEL_JERARQUIA IS NULL OR CODIGO_NIVEL_JERARQUIA = @CODIGO_NIVEL_JERARQUIA)

			AND		( @CODIGO_UNIDAD_OPERATIVA_PADRE IS NULL OR CODIGO_UNIDAD_OPERATIVA_PADRE = @CODIGO_UNIDAD_OPERATIVA_PADRE)

			AND		( @lActivo IS NULL OR INDICADOR_ACTIVA = @lActivo)

			)

			

	SELECT  RowNumber NumeroFila,

			RowsTotal FilasTotal,

			RowId IdentificadorFila,

			CodigoUnidadOperativa,

			CodigoIdentificacion,

			Nombre,

			CodigoNivelJerarquia,

			CodigoUnidadOperativaPadre,

			(SELECT UO.NOMBRE FROM GRL.UNIDAD_OPERATIVA UO WHERE UO.CODIGO_UNIDAD_OPERATIVA =  R.CodigoUnidadOperativaPadre AND UO.ESTADO_REGISTRO = '1') AS NombreUnidadOperativaPadre,

			CodigoTipoUnidadOperativa,

			IndicadorActiva,

			CodigoResponsable,

			(SELECT T.NOMBRE_COMPLETO FROM GRL.TRABAJADOR T WHERE T.CODIGO_TRABAJADOR = R.CodigoResponsable AND T.ESTADO_REGISTRO = '1') AS NombreResponsable,

			CodigoPrimerRepresentante,

			(SELECT T.NOMBRE_COMPLETO FROM GRL.TRABAJADOR T WHERE T.CODIGO_TRABAJADOR = R.CodigoPrimerRepresentante AND T.ESTADO_REGISTRO = '1') AS NombrePrimerRepresentante,

			CodigoSegundoRepresentante,

			(SELECT T.NOMBRE_COMPLETO FROM GRL.TRABAJADOR T WHERE T.CODIGO_TRABAJADOR = R.CodigoSegundoRepresentante AND T.ESTADO_REGISTRO = '1') AS NombreSegundoRepresentante,

			CodigoTercerRepresentante,

			(SELECT T.NOMBRE_COMPLETO FROM GRL.TRABAJADOR T WHERE T.CODIGO_TRABAJADOR = R.CodigoTercerRepresentante AND T.ESTADO_REGISTRO = '1') AS NombreTercerRepresentante,

			CodigoCuartoRepresentante,

			(SELECT T.NOMBRE_COMPLETO FROM GRL.TRABAJADOR T WHERE T.CODIGO_TRABAJADOR = R.CodigoCuartoRepresentante AND T.ESTADO_REGISTRO = '1') AS NombreCuartoRepresentante,

			Direccion,

			LogoUnidadOperativa

	  FROM  CTE_Results R

	 WHERE  @TAMANIO_PAGINA < 0

		OR  (RowNumber > @lFirstRec AND RowNumber < @lLAStRec)

END



GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDADES_OPERATIVAS_POR_RESPONSABLE_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_UNIDADES_OPERATIVAS_POR_RESPONSABLE_SEL]
(
	@CODIGO_IDENTIFICACION	NVARCHAR(50)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_UNIDADES_OPERATIVAS_POR_RESPONSABLE_SEL
Propósito: Retorna registros de la tablas  Trabajador, Unidad_operativa
Descripción de Parámetros: 
		@CODIGO_IDENTIFICACION:	Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	WITH CTE_UO
	  AS (SELECT UO.CODIGO_UNIDAD_OPERATIVA,
				 UO.NOMBRE,
				 UO.CODIGO_NIVEL_JERARQUIA
			FROM GRL.TRABAJADOR T
		   INNER JOIN GRL.UNIDAD_OPERATIVA UO
			  ON UO.CODIGO_RESPONSABLE = T.CODIGO_TRABAJADOR
			 AND UO.ESTADO_REGISTRO = '1'
			 AND UO.INDICADOR_ACTIVA = 1
		   WHERE T.CODIGO_IDENTIFICACION = @CODIGO_IDENTIFICACION
			 AND T.ESTADO_REGISTRO = '1'
		   UNION ALL
		  SELECT UO.CODIGO_UNIDAD_OPERATIVA,
				 UO.NOMBRE,
				 UO.CODIGO_NIVEL_JERARQUIA
		    FROM GRL.UNIDAD_OPERATIVA UO
		   INNER JOIN CTE_UO C
		      ON C.CODIGO_UNIDAD_OPERATIVA = UO.CODIGO_UNIDAD_OPERATIVA_PADRE
		   WHERE UO.ESTADO_REGISTRO = '1'
			 AND UO.INDICADOR_ACTIVA = 1
		 )
	
	SELECT UO.CODIGO_UNIDAD_OPERATIVA CodigoUnidadOperativa,
		   UO.NOMBRE Nombre,
		   UO.CODIGO_NIVEL_JERARQUIA CodigoNivelJerarquia,
		   N.COLUMNA2 AS DescripcionNivelJerarquia,
		   CONVERT(INT, N.COLUMNA3) AS NivelJerarquia
	  FROM CTE_UO UO
	 INNER JOIN GRL.FN_LISTAR_VALORES_PARAMETRO_MATRIZ ('STR', 1, NULL, '00001') N
	    ON N.COLUMNA1 = UO.CODIGO_NIVEL_JERARQUIA
	 GROUP BY UO.CODIGO_UNIDAD_OPERATIVA,
			  UO.NOMBRE,
			  UO.CODIGO_NIVEL_JERARQUIA,
			  N.COLUMNA2,
			  N.COLUMNA3
	 ORDER BY NivelJerarquia,
			  Nombre
END

GO
/****** Object:  StoredProcedure [GRL].[USP_UNIDADES_OPERATIVAS_SUPERIORES_SEL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GRL].[USP_UNIDADES_OPERATIVAS_SUPERIORES_SEL]
(
    @CODIGO_NIVEL_JERARQUIA		nvarchar(5)
)
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.USP_UNIDADES_OPERATIVAS_SUPERIORES_SEL
Propósito: Retorna registros de las tabla de Unidad_operativa
Descripción de Parámetros: 
		@CODIGO_NIVEL_JERARQUIA:	Parámetro de entrada de tipo nvarchar, que representa codigo nivel jerarquia.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	DECLARE @NIVEL INT

	SELECT @NIVEL = CONVERT(INT, VALOR) - 1
	  FROM GRL.FN_LISTAR_VALORES_PARAMETRO('STR', 1, NULL, '00001', 3)
	 WHERE CODIGO = @CODIGO_NIVEL_JERARQUIA

	SELECT UO.CODIGO_UNIDAD_OPERATIVA as CodigoUnidadOperativa,
	       UO.NOMBRE as Nombre
	  FROM GRL.UNIDAD_OPERATIVA UO
	 INNER JOIN GRL.FN_LISTAR_VALORES_PARAMETRO('STR', 1, NULL, '00001', 3) N
	    ON N.CODIGO = UO.CODIGO_NIVEL_JERARQUIA
	 WHERE UO.ESTADO_REGISTRO = '1'
	   AND CONVERT(INT, N.VALOR) = @NIVEL
	 ORDER BY UO.NOMBRE
END

GO
/****** Object:  UserDefinedFunction [GRL].[FN_LISTAR_VALORES_PARAMETRO]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [GRL].[FN_LISTAR_VALORES_PARAMETRO] (
	@CODIGO_IDENTIFICADOR_EMPRESA NVARCHAR(5),
	@INDICADOR_EMPRESA BIT,
	@CODIGO_IDENTIFICADOR_SISTEMA NVARCHAR(5),
	@CODIGO_IDENTIFICADOR_PARAMETRO NVARCHAR(5),
	@CODIGO_SECCION INT
)


RETURNS @VALORES TABLE(CODIGO NVARCHAR(255), VALOR  NVARCHAR(255))
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.FN_LISTAR_VALORES_PARAMETRO
Propósito: Lista los valores del parametro
Descripción de Parámetros: 
			@CODIGO_IDENTIFICADOR_EMPRESA Parámetro de entrada de tipo nvarchar, que representa codigo identificador de empresa.
			@INDICADOR_EMPRESA Parámetro de entrada de tipo bit, que representa indicador de empresa.
			@CODIGO_IDENTIFICADOR_SISTEMA Parámetro de entrada de tipo nvarchar, que representa codigo identificador sistema.
			@CODIGO_IDENTIFICADOR_PARAMETRO Parámetro de entrada de tipo nvarchar, que representa codigo identificador parametro.
			@CODIGO_SECCION Parámetro de entrada de tipo int, que representa codigo seccion.
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	DECLARE @CODIGO_EMPRESA UNIQUEIDENTIFIER
	DECLARE @CODIGO_SISTEMA UNIQUEIDENTIFIER

	SELECT @CODIGO_EMPRESA = E.CODIGO_EMPRESA
	  FROM GRL.EMPRESA E
	 WHERE E.CODIGO_IDENTIFICADOR = @CODIGO_IDENTIFICADOR_EMPRESA
	   AND E.ESTADO_REGISTRO  ='1'

	SELECT @CODIGO_SISTEMA = S.CODIGO_SISTEMA
	  FROM GRL.SISTEMA S
	 WHERE S.CODIGO_EMPRESA = @CODIGO_EMPRESA
	   AND S.CODIGO_IDENTIFICADOR = @CODIGO_IDENTIFICADOR_SISTEMA
	   AND S.ESTADO_REGISTRO  ='1'

	INSERT INTO @VALORES (CODIGO, VALOR)
    SELECT CODIGO, DESCRIPCION
	  FROM (SELECT PV.CODIGO_VALOR, (CASE PV.CODIGO_SECCION WHEN 1 THEN 'CODIGO' ELSE 'DESCRIPCION' END) AS COLUMNA, PV.VALOR
			  FROM GRL.PARAMETRO_VALOR PV
			 INNER JOIN GRL.PARAMETRO P
			    ON P.CODIGO_PARAMETRO = PV.CODIGO_PARAMETRO
			   AND P.ESTADO_REGISTRO = '1'
			 WHERE P.CODIGO_EMPRESA = @CODIGO_EMPRESA
			   AND P.INDICADOR_EMPRESA = @INDICADOR_EMPRESA
			   AND (@INDICADOR_EMPRESA = 1 OR P.CODIGO_SISTEMA = @CODIGO_SISTEMA)
			   AND P.CODIGO_IDENTIFICADOR = @CODIGO_IDENTIFICADOR_PARAMETRO
			   AND PV.CODIGO_SECCION IN (1, @CODIGO_SECCION)
			   AND PV.ESTADO_REGISTRO = '1') AS ORIGEN
	 PIVOT (MAX(VALOR) FOR COLUMNA IN (CODIGO, DESCRIPCION)) AS TABLA_PIVOTE
	RETURN
END

GO
/****** Object:  UserDefinedFunction [GRL].[FN_LISTAR_VALORES_PARAMETRO_BUSQUEDA]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [GRL].[FN_LISTAR_VALORES_PARAMETRO_BUSQUEDA] (
	@CODIGO_IDENTIFICADOR_EMPRESA NVARCHAR(5),
	@INDICADOR_EMPRESA BIT,
	@CODIGO_IDENTIFICADOR_SISTEMA NVARCHAR(5),
	@CODIGO_IDENTIFICADOR_PARAMETRO NVARCHAR(5),
	@CODIGO_SECCION_MOSTRAR INT,
	@CODIGO_SECCION_BUSCAR INT,
	@OPERADOR NVARCHAR(5),
	@VALOR_BUSCAR NVARCHAR(255)
)
RETURNS @VALORES TABLE(CODIGO NVARCHAR(255), VALOR  NVARCHAR(255))
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.FN_LISTAR_VALORES_PARAMETRO_BUSQUEDA
Propósito: Lista valores de parametro de busqueda
Descripción de Parámetros: 
			@CODIGO_IDENTIFICADOR_EMPRESA Parámetro de entrada de tipo nvarchar, que representa codigo identificador de empresa.
			@INDICADOR_EMPRESA Parámetro de entrada de tipo bit, que representa indicador de empresa
			@CODIGO_IDENTIFICADOR_SISTEMA Parámetro de entrada de tipo nvarchar, que representa codigo identificador de sistema
			@CODIGO_IDENTIFICADOR_PARAMETRO Parámetro de entrada de tipo nvarchar, que representa codigo identificador de parametro
			@CODIGO_SECCION_MOSTRAR Parámetro de entrada de tipo int, que representa codigo seccion mostrar
			@CODIGO_SECCION_BUSCAR Parámetro de entrada de tipo int, que representa codigo seccion buscar
			@OPERADOR Parámetro de entrada de tipo nvarchar, que representa operador
			@VALOR_BUSCAR Parámetro de entrada de tipo nvarchar, que representa valor buscar
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	DECLARE @CODIGO_PARAMETRO INT
	DECLARE @FILAS TABLE(CODIGO_VALOR INT)
	DECLARE @CODIGO_EMPRESA UNIQUEIDENTIFIER
	DECLARE @CODIGO_SISTEMA UNIQUEIDENTIFIER

	SELECT @CODIGO_EMPRESA = E.CODIGO_EMPRESA
	  FROM GRL.EMPRESA E
	 WHERE E.CODIGO_IDENTIFICADOR = @CODIGO_IDENTIFICADOR_EMPRESA
	   AND E.ESTADO_REGISTRO  ='1'

	SELECT @CODIGO_SISTEMA = S.CODIGO_SISTEMA
	  FROM GRL.SISTEMA S
	 WHERE S.CODIGO_EMPRESA = @CODIGO_EMPRESA
	   AND S.CODIGO_IDENTIFICADOR = @CODIGO_IDENTIFICADOR_SISTEMA
	   AND S.ESTADO_REGISTRO  ='1'


	SELECT @CODIGO_PARAMETRO = P.CODIGO_PARAMETRO
	  FROM GRL.PARAMETRO P
	 WHERE P.ESTADO_REGISTRO = '1'
	   AND P.CODIGO_EMPRESA = @CODIGO_EMPRESA
	   AND P.INDICADOR_EMPRESA = @INDICADOR_EMPRESA
	   AND P.CODIGO_IDENTIFICADOR = @CODIGO_IDENTIFICADOR_PARAMETRO
	   AND (@INDICADOR_EMPRESA = 1 OR P.CODIGO_SISTEMA = @CODIGO_SISTEMA)

	INSERT INTO @FILAS (CODIGO_VALOR)
	SELECT CASE 
			WHEN @OPERADOR = '=' AND PVB.VALOR = @VALOR_BUSCAR THEN PVB.CODIGO_VALOR
			WHEN @OPERADOR = '>' AND PVB.VALOR > @VALOR_BUSCAR THEN PVB.CODIGO_VALOR
			WHEN @OPERADOR = '<' AND PVB.VALOR < @VALOR_BUSCAR THEN PVB.CODIGO_VALOR
			WHEN @OPERADOR = '<>' AND PVB.VALOR <> @VALOR_BUSCAR THEN PVB.CODIGO_VALOR
			WHEN @OPERADOR = '>=' AND PVB.VALOR >= @VALOR_BUSCAR THEN PVB.CODIGO_VALOR
			WHEN @OPERADOR = '<=' AND PVB.VALOR <= @VALOR_BUSCAR THEN PVB.CODIGO_VALOR
		   END
	  FROM GRL.PARAMETRO_VALOR PVB
	 WHERE PVB.CODIGO_PARAMETRO = @CODIGO_PARAMETRO
	   AND PVB.CODIGO_SECCION = @CODIGO_SECCION_BUSCAR
	   AND PVB.ESTADO_REGISTRO = '1'

	INSERT INTO @VALORES (CODIGO, VALOR)
    SELECT CODIGO, DESCRIPCION
	  FROM (SELECT PV.CODIGO_VALOR, (CASE PV.CODIGO_SECCION WHEN 1 THEN 'CODIGO' ELSE 'DESCRIPCION' END) AS COLUMNA, PV.VALOR
			  FROM GRL.PARAMETRO_VALOR PV
			 WHERE PV.CODIGO_PARAMETRO = @CODIGO_PARAMETRO
			   AND PV.CODIGO_SECCION IN (1, @CODIGO_SECCION_MOSTRAR)
			   AND PV.ESTADO_REGISTRO = '1'
			   AND PV.CODIGO_VALOR IN (SELECT F.CODIGO_VALOR FROM @FILAS F)
			) AS ORIGEN
	 PIVOT (MAX(VALOR) FOR COLUMNA IN (CODIGO, DESCRIPCION)) AS TABLA_PIVOTE
	RETURN
END

GO
/****** Object:  UserDefinedFunction [GRL].[FN_LISTAR_VALORES_PARAMETRO_MATRIZ]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [GRL].[FN_LISTAR_VALORES_PARAMETRO_MATRIZ] (
	@CODIGO_IDENTIFICADOR_EMPRESA NVARCHAR(5),
	@INDICADOR_EMPRESA BIT,
	@CODIGO_IDENTIFICADOR_SISTEMA NVARCHAR(5),
	@CODIGO_IDENTIFICADOR_PARAMETRO NVARCHAR(5)
)
RETURNS @VALORES TABLE(COLUMNA1 NVARCHAR(255), COLUMNA2 NVARCHAR(255), COLUMNA3 NVARCHAR(255), COLUMNA4 NVARCHAR(255), COLUMNA5 NVARCHAR(255), COLUMNA6 NVARCHAR(255), COLUMNA7 NVARCHAR(255), COLUMNA8 NVARCHAR(255), COLUMNA9 NVARCHAR(255), COLUMNA10 NVARCHAR(255))
AS
/**********************************************************************************************************************************
Nombre Objeto: GRL.FN_LISTAR_VALORES_PARAMETRO_MATRIZ
Propósito: Listar valores de parametro matriz
Descripción de Parámetros: 
        @CODIGO_IDENTIFICADOR_EMPRESA Parámetro de entrada de tipo nvarchar, que representa codigo_identificador_empresa
		@INDICADOR_EMPRESA Parámetro de entrada de tipo bit, que representa indicador_empresa
		@CODIGO_IDENTIFICADOR_SISTEMA Parámetro de entrada de tipo nvarchar, que representa codigo_identificador_sistema
		@CODIGO_IDENTIFICADOR_PARAMETRO Parámetro de entrada de tipo nvarchar, que representa codigo_identificador_parametro
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	DECLARE @CODIGO_EMPRESA UNIQUEIDENTIFIER
	DECLARE @CODIGO_SISTEMA UNIQUEIDENTIFIER

	SELECT @CODIGO_EMPRESA = E.CODIGO_EMPRESA
	  FROM GRL.EMPRESA E
	 WHERE E.CODIGO_IDENTIFICADOR = @CODIGO_IDENTIFICADOR_EMPRESA
	   AND E.ESTADO_REGISTRO  ='1'

	SELECT @CODIGO_SISTEMA = S.CODIGO_SISTEMA
	  FROM GRL.SISTEMA S
	 WHERE S.CODIGO_EMPRESA = @CODIGO_EMPRESA
	   AND S.CODIGO_IDENTIFICADOR = @CODIGO_IDENTIFICADOR_SISTEMA
	   AND S.ESTADO_REGISTRO  ='1'
	
	INSERT INTO @VALORES
    SELECT COLUMNA1, COLUMNA2, COLUMNA3, COLUMNA4, COLUMNA5, COLUMNA6, COLUMNA7, COLUMNA8, COLUMNA9, COLUMNA10
	  FROM (SELECT PV.CODIGO_VALOR, 'COLUMNA' + CONVERT(VARCHAR, PV.CODIGO_SECCION) AS COLUMNA, PV.VALOR
			  FROM GRL.PARAMETRO_VALOR PV
			 INNER JOIN GRL.PARAMETRO P
			    ON P.CODIGO_PARAMETRO = PV.CODIGO_PARAMETRO
			   AND P.ESTADO_REGISTRO = '1'
			 WHERE P.CODIGO_EMPRESA = @CODIGO_EMPRESA
			   AND P.INDICADOR_EMPRESA = @INDICADOR_EMPRESA
			   AND (@INDICADOR_EMPRESA = 1 OR P.CODIGO_SISTEMA = @CODIGO_SISTEMA)
			   AND P.CODIGO_IDENTIFICADOR = @CODIGO_IDENTIFICADOR_PARAMETRO
			   AND PV.ESTADO_REGISTRO = '1') AS ORIGEN
	 PIVOT (MAX(VALOR) FOR COLUMNA IN (COLUMNA1, COLUMNA2, COLUMNA3, COLUMNA4, COLUMNA5, COLUMNA6, COLUMNA7, COLUMNA8, COLUMNA9, COLUMNA10)) AS TABLA_PIVOTE
	RETURN
END

GO
/****** Object:  UserDefinedFunction [GRL].[FN_OBTENER_FECHA_SERVIDOR]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [GRL].[FN_OBTENER_FECHA_SERVIDOR]
(@PAIS CHAR(3), @HORA_UTC INT) 
RETURNS DATETIME
AS 
/**********************************************************************************************************************************
Nombre Objeto: GRL.FN_OBTENER_FECHA_SERVIDOR
Propósito: Obtener fecha del servidor
Descripción de Parámetros: 
         @PAIS CHAR(3)  Parámetro de entrada de tipo char, que representa el pais
		 @HORA_UTC INT  Parámetro de entrada de tipo int, que representa la hora
Creado por: GMD
Fecha. Creación: 2015-06-09
Fecha. Actualización: 
**********************************************************************************************************************************/
BEGIN
	
	DECLARE @F DATETIME 
	SET @F = GETDATE()	
	RETURN @F

END

GO
/****** Object:  UserDefinedFunction [GRL].[SplitString]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [GRL].[SplitString]
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
/****** Object:  Table [GRL].[DEPARTAMENTO]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[DEPARTAMENTO](
	[CODIGO_DEPARTAMENTO] [int] NOT NULL,
	[CODIGO_PAIS] [char](3) NULL,
	[CODIGO_UBIGEO] [nvarchar](5) NULL,
	[NOMBRE] [nvarchar](255) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_DEPARTAMENTO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_DEPARTAMENTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[DISTRITO]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[DISTRITO](
	[CODIGO_DISTRITO] [int] NOT NULL,
	[CODIGO_PROVINCIA] [int] NULL,
	[CODIGO_UBIGEO] [nvarchar](20) NULL,
	[NOMBRE] [nvarchar](255) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_DISTRITO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_DISTRITO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[EMPRESA]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[EMPRESA](
	[CODIGO_EMPRESA] [uniqueidentifier] NOT NULL,
	[CODIGO_IDENTIFICADOR] [nvarchar](5) NOT NULL,
	[NOMBRE] [nvarchar](255) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_EMPRESA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_EMPRESA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[MONEDA]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[MONEDA](
	[CODIGO_MONEDA] [char](3) NOT NULL,
	[NOMBRE] [nvarchar](255) NULL,
	[SIMBOLO] [nvarchar](5) NULL,
	[MOTIVO_MODIFICACION] [nvarchar](255) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_MONEDA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_MONEDA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[PAIS]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[PAIS](
	[CODIGO_PAIS] [char](3) NOT NULL,
	[NOMBRE] [nvarchar](255) NULL,
	[CODIGO_SECUNDARIO] [char](2) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_PAIS] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PAIS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[PARAMETRO]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[PARAMETRO](
	[CODIGO_PARAMETRO] [int] NOT NULL,
	[CODIGO_EMPRESA] [uniqueidentifier] NOT NULL,
	[CODIGO_SISTEMA] [uniqueidentifier] NULL,
	[CODIGO_IDENTIFICADOR] [nvarchar](50) NOT NULL,
	[NOMBRE] [nvarchar](255) NOT NULL,
	[DESCRIPCION] [nvarchar](255) NOT NULL,
	[INDICADOR_EMPRESA] [bit] NOT NULL,
	[INDICADOR_PERMITE_AGREGAR] [bit] NOT NULL,
	[INDICADOR_PERMITE_MODIFICAR] [bit] NOT NULL,
	[INDICADOR_PERMITE_ELIMINAR] [bit] NOT NULL,
	[TIPO_PARAMETRO] [char](1) NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[PARAMETRO_SECCION]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[PARAMETRO_SECCION](
	[CODIGO_PARAMETRO] [int] NOT NULL,
	[CODIGO_SECCION] [int] NOT NULL,
	[NOMBRE] [nvarchar](255) NOT NULL,
	[CODIGO_TIPO_DATO] [char](3) NOT NULL,
	[INDICADOR_PERMITE_MODIFICAR] [bit] NOT NULL,
	[INDICADOR_OBLIGATORIO] [bit] NOT NULL,
	[INDICADOR_SISTEMA] [bit] NOT NULL,
	[CODIGO_PARAMETRO_RELACIONADO] [int] NULL,
	[CODIGO_SECCION_RELACIONADO] [int] NULL,
	[CODIGO_SECCION_RELACIONADO_MOSTRAR] [int] NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[PARAMETRO_VALOR]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[PARAMETRO_VALOR](
	[CODIGO_PARAMETRO] [int] NOT NULL,
	[CODIGO_SECCION] [int] NOT NULL,
	[CODIGO_VALOR] [int] NOT NULL,
	[VALOR] [nvarchar](max) NULL,
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
/****** Object:  Table [GRL].[PLANTILLA_NOTIFICACION]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[PLANTILLA_NOTIFICACION](
	[CODIGO_PLANTILLA_NOTIFICACION] [uniqueidentifier] NOT NULL,
	[CODIGO_SISTEMA] [uniqueidentifier] NOT NULL,
	[CODIGO_TIPO_NOTIFICACION] [nvarchar](5) NOT NULL,
	[ASUNTO] [nvarchar](255) NOT NULL,
	[CONTENIDO] [nvarchar](max) NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
	[INDICADOR_ACTIVA] [bit] NOT NULL,
	[CODIGO_TIPO_DESTINATARIO] [nvarchar](5) NOT NULL,
	[DESTINATARIO] [nvarchar](max) NULL,
	[DESTINATARIO_COPIA] [nvarchar](max) NULL,
 CONSTRAINT [PK_PLANTILLA_NOTIFICACION] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PLANTILLA_NOTIFICACION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[PROVINCIA]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[PROVINCIA](
	[CODIGO_PROVINCIA] [int] NOT NULL,
	[CODIGO_DEPARTAMENTO] [int] NULL,
	[CODIGO_UBIGEO] [nvarchar](10) NULL,
	[NOMBRE] [nvarchar](255) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_PROVINCIA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_PROVINCIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[SISTEMA]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[SISTEMA](
	[CODIGO_SISTEMA] [uniqueidentifier] NOT NULL,
	[CODIGO_EMPRESA] [uniqueidentifier] NOT NULL,
	[CODIGO_IDENTIFICADOR] [nvarchar](5) NOT NULL,
	[NOMBRE] [nvarchar](255) NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_SISTEMA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_SISTEMA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[TIPO_DATO]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[TIPO_DATO](
	[CODIGO_TIPO_DATO] [char](3) NOT NULL,
	[NOMBRE] [nvarchar](255) NULL,
	[DESCRIPCION] [nvarchar](255) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_TIPO_DATO] PRIMARY KEY CLUSTERED 
(
	[CODIGO_TIPO_DATO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[TMP_ENVIAR_CORREOS_SUPLENTE_TRABAJADOR]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[TMP_ENVIAR_CORREOS_SUPLENTE_TRABAJADOR](
	[CORREO_ELECTRONICO] [varchar](max) NULL,
	[ASUNTO] [varchar](max) NULL,
	[CONTENIDO] [varchar](max) NULL,
	[EMISOR] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[TMP_ENVIAR_CORREOS_SUPLENTE_TRABAJADOR_SUPL]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[TMP_ENVIAR_CORREOS_SUPLENTE_TRABAJADOR_SUPL](
	[CORREO_ELECTRONICO] [varchar](max) NULL,
	[ASUNTO] [varchar](max) NULL,
	[CONTENIDO] [varchar](max) NULL,
	[EMISOR] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[TMP_ENVIAR_CORREOS_TRABAJADOR_POR_SUPLENTE_SUP]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[TMP_ENVIAR_CORREOS_TRABAJADOR_POR_SUPLENTE_SUP](
	[DESTINATARIO] [varchar](max) NULL,
	[ASUNTO] [varchar](max) NULL,
	[CONTENIDO] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[TMP_ENVIAR_CORREOS_TRABAJADOR_POR_SUPLENTE_TRAB]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[TMP_ENVIAR_CORREOS_TRABAJADOR_POR_SUPLENTE_TRAB](
	[DESTINATARIO] [varchar](max) NULL,
	[ASUNTO] [varchar](max) NULL,
	[CONTENIDO] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[TRABAJADOR]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[TRABAJADOR](
	[CODIGO_TRABAJADOR] [uniqueidentifier] NOT NULL,
	[DOMINIO] [nvarchar](50) NULL,
	[CODIGO_IDENTIFICACION] [nvarchar](50) NULL,
	[CODIGO_TIPO_DOCUMENTO_IDENTIDAD] [nvarchar](5) NULL,
	[NUMERO_DOCUMENTO_IDENTIDAD] [nvarchar](15) NULL,
	[APELLIDO_PATERNO] [nvarchar](50) NULL,
	[APELLIDO_MATERNO] [nvarchar](50) NULL,
	[NOMBRES] [nvarchar](50) NULL,
	[NOMBRE_COMPLETO] [nvarchar](255) NULL,
	[ORGANIZACION] [nvarchar](255) NULL,
	[DEPARTAMENTO] [nvarchar](255) NULL,
	[CARGO] [nvarchar](255) NULL,
	[TELEFONO_TRABAJO] [nvarchar](50) NULL,
	[ANEXO] [nvarchar](10) NULL,
	[TELEFONO_MOVIL] [nvarchar](50) NULL,
	[TELEFONO_PERSONAL] [nvarchar](50) NULL,
	[CORREO_ELECTRONICO] [nvarchar](50) NULL,
	[INDICADOR_TODA_UNIDAD_OPERATIVA] [bit] NOT NULL,
	[CODIGO_UNIDAD_OPERATIVA_MATRIZ] [uniqueidentifier] NULL,
	[INDICADOR_TIENE_FOTO] [bit] NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_TRABAJADOR] PRIMARY KEY CLUSTERED 
(
	[CODIGO_TRABAJADOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[TRABAJADOR_FIRMA]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[TRABAJADOR_FIRMA](
	[CODIGO_FIRMA] [uniqueidentifier] NOT NULL,
	[CODIGO_TRABAJADOR] [uniqueidentifier] NOT NULL,
	[FIRMA_TRABAJADOR] [varbinary](max) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_TRABAJADOR_FIRMA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_FIRMA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FIRMAS]
) ON [FIRMAS] TEXTIMAGE_ON [FIRMAS]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[TRABAJADOR_SUPLENTE]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[TRABAJADOR_SUPLENTE](
	[CODIGO_TRABAJADOR] [uniqueidentifier] NOT NULL,
	[CODIGO_SUPLENTE] [uniqueidentifier] NOT NULL,
	[FECHA_INICIO] [datetime] NOT NULL,
	[FECHA_FIN] [datetime] NOT NULL,
	[ACTIVO] [bit] NOT NULL,
	[EJECUTADO] [bit] NULL,
	[PERFILES_AGREGADOS] [varchar](1000) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NULL,
	[FECHA_CREACION] [datetime] NULL,
	[TERMINAL_CREACION] [nvarchar](50) NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_TRABAJADOR_SUPLENTE] PRIMARY KEY CLUSTERED 
(
	[CODIGO_TRABAJADOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[TRABAJADOR_UNIDAD_OPERATIVA]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[TRABAJADOR_UNIDAD_OPERATIVA](
	[CODIGO_TRABAJADOR_UNIDAD_OPERATIVA] [uniqueidentifier] NOT NULL,
	[CODIGO_UNIDAD_OPERATIVA_MATRIZ] [uniqueidentifier] NULL,
	[CODIGO_TRABAJADOR] [uniqueidentifier] NOT NULL,
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NULL,
	[FECHA_CREACION] [datetime] NULL,
	[TERMINAL_CREACION] [nvarchar](50) NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_TRABAJADOR_UNIDAD_OPERATIVA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_TRABAJADOR_UNIDAD_OPERATIVA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[UNIDAD_OPERATIVA]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[UNIDAD_OPERATIVA](
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NOT NULL,
	[CODIGO_IDENTIFICACION] [nvarchar](50) NULL,
	[NOMBRE] [nvarchar](255) NULL,
	[INDICADOR_ACTIVA] [bit] NULL,
	[CODIGO_NIVEL_JERARQUIA] [nvarchar](5) NULL,
	[CODIGO_UNIDAD_OPERATIVA_PADRE] [uniqueidentifier] NULL,
	[CODIGO_TIPO_UNIDAD_OPERATIVA] [nvarchar](5) NULL,
	[CODIGO_RESPONSABLE] [uniqueidentifier] NULL,
	[CODIGO_ZONA_HORARIA] [uniqueidentifier] NULL,
	[CODIGO_PRIMER_REPRESENTANTE] [uniqueidentifier] NULL,
	[CODIGO_SEGUNDO_REPRESENTANTE] [uniqueidentifier] NULL,
	[CODIGO_TERCER_REPRESENTANTE] [uniqueidentifier] NULL,
	[CODIGO_CUARTO_REPRESENTANTE] [uniqueidentifier] NULL,
	[CODIGO_PRIMER_REPRESENTANTE_ORIGINAL] [uniqueidentifier] NULL,
	[CODIGO_SEGUNDO_REPRESENTANTE_ORIGINAL] [uniqueidentifier] NULL,
	[CODIGO_TERCER_REPRESENTANTE_ORIGINAL] [uniqueidentifier] NULL,
	[CODIGO_CUARTO_REPRESENTANTE_ORIGINAL] [uniqueidentifier] NULL,
	[DIRECCION] [nvarchar](255) NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
	[LOGO_UNIDAD_OPERATIVA] [nvarchar](max) NULL,
 CONSTRAINT [PK_UNIDAD_ORGANIZACIONAL] PRIMARY KEY CLUSTERED 
(
	[CODIGO_UNIDAD_OPERATIVA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[UNIDAD_OPERATIVA_STAFF]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[UNIDAD_OPERATIVA_STAFF](
	[CODIGO_UNIDAD_OPERATIVA_STAFF] [uniqueidentifier] NOT NULL,
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NOT NULL,
	[CODIGO_SISTEMA] [uniqueidentifier] NOT NULL,
	[CODIGO_TRABAJADOR] [uniqueidentifier] NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_UNIDAD_OPERATIVA_STAFF] PRIMARY KEY CLUSTERED 
(
	[CODIGO_UNIDAD_OPERATIVA_STAFF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[UNIDAD_OPERATIVA_USUARIO_CONSULTA]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[UNIDAD_OPERATIVA_USUARIO_CONSULTA](
	[CODIGO_UNIDAD_OPERATIVA_USUARIO_CONSULTA] [uniqueidentifier] NOT NULL,
	[CODIGO_UNIDAD_OPERATIVA] [uniqueidentifier] NOT NULL,
	[CODIGO_TRABAJADOR] [uniqueidentifier] NOT NULL,
	[ESTADO_REGISTRO] [char](1) NOT NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [nvarchar](50) NULL,
 CONSTRAINT [PK_UNIDAD_OPERATIVA_RESPONSABLE] PRIMARY KEY CLUSTERED 
(
	[CODIGO_UNIDAD_OPERATIVA_USUARIO_CONSULTA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [GRL].[ZONA_HORARIA]    Script Date: 25/02/2020 18:01:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [GRL].[ZONA_HORARIA](
	[CODIGO_ZONA_HORARIA] [uniqueidentifier] NOT NULL,
	[HORA_UTC] [smallint] NULL,
	[MINUTO_UTC] [smallint] NULL,
	[DESCRIPCION] [nvarchar](255) NULL,
	[ESTADO_REGISTRO] [char](1) NULL,
	[USUARIO_CREACION] [nvarchar](50) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[TERMINAL_CREACION] [nvarchar](50) NOT NULL,
	[USUARIO_MODIFICACION] [nvarchar](50) NULL,
	[FECHA_MODIFICACION] [datetime] NULL,
	[TERMINAL_MODIFICACION] [datetime] NULL,
 CONSTRAINT [PK_ZONA_HORARIA] PRIMARY KEY CLUSTERED 
(
	[CODIGO_ZONA_HORARIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [GRL].[PLANTILLA_NOTIFICACION] ADD  CONSTRAINT [DF_PLANTILLA_NOTIFICACION_INDICADOR_ACTIVA]  DEFAULT ((1)) FOR [INDICADOR_ACTIVA]
GO
ALTER TABLE [GRL].[PLANTILLA_NOTIFICACION] ADD  CONSTRAINT [DF_PLANTILLA_NOTIFICACION_INDICADOR_TIPO_DESTINATARIO]  DEFAULT ('U') FOR [CODIGO_TIPO_DESTINATARIO]
GO
ALTER TABLE [GRL].[DEPARTAMENTO]  WITH CHECK ADD  CONSTRAINT [FK_DEPARTAMENTO_PAIS] FOREIGN KEY([CODIGO_PAIS])
REFERENCES [GRL].[PAIS] ([CODIGO_PAIS])
GO
ALTER TABLE [GRL].[DEPARTAMENTO] CHECK CONSTRAINT [FK_DEPARTAMENTO_PAIS]
GO
ALTER TABLE [GRL].[DISTRITO]  WITH CHECK ADD  CONSTRAINT [FK_DISTRITO_PROVINCIA] FOREIGN KEY([CODIGO_PROVINCIA])
REFERENCES [GRL].[PROVINCIA] ([CODIGO_PROVINCIA])
GO
ALTER TABLE [GRL].[DISTRITO] CHECK CONSTRAINT [FK_DISTRITO_PROVINCIA]
GO
ALTER TABLE [GRL].[PROVINCIA]  WITH CHECK ADD  CONSTRAINT [FK_PROVINCIA_DEPARTAMENTO] FOREIGN KEY([CODIGO_DEPARTAMENTO])
REFERENCES [GRL].[DEPARTAMENTO] ([CODIGO_DEPARTAMENTO])
GO
ALTER TABLE [GRL].[PROVINCIA] CHECK CONSTRAINT [FK_PROVINCIA_DEPARTAMENTO]
GO
ALTER TABLE [GRL].[SISTEMA]  WITH CHECK ADD  CONSTRAINT [FK_SISTEMA_EMPRESA] FOREIGN KEY([CODIGO_EMPRESA])
REFERENCES [GRL].[EMPRESA] ([CODIGO_EMPRESA])
GO
ALTER TABLE [GRL].[SISTEMA] CHECK CONSTRAINT [FK_SISTEMA_EMPRESA]
GO
ALTER TABLE [GRL].[TRABAJADOR_FIRMA]  WITH CHECK ADD  CONSTRAINT [FK_TRABAJADOR_FIRMA_TRABAJADOR] FOREIGN KEY([CODIGO_TRABAJADOR])
REFERENCES [GRL].[TRABAJADOR] ([CODIGO_TRABAJADOR])
GO
ALTER TABLE [GRL].[TRABAJADOR_FIRMA] CHECK CONSTRAINT [FK_TRABAJADOR_FIRMA_TRABAJADOR]
GO
ALTER TABLE [GRL].[UNIDAD_OPERATIVA]  WITH CHECK ADD  CONSTRAINT [FK_UNIDAD_OPERATIVA_UNIDAD_OPERATIVA] FOREIGN KEY([CODIGO_UNIDAD_OPERATIVA_PADRE])
REFERENCES [GRL].[UNIDAD_OPERATIVA] ([CODIGO_UNIDAD_OPERATIVA])
GO
ALTER TABLE [GRL].[UNIDAD_OPERATIVA] CHECK CONSTRAINT [FK_UNIDAD_OPERATIVA_UNIDAD_OPERATIVA]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Notifica Calendarizaciones' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_NOTIFICAR_CALENDARIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo LISTA_GUID_TYPE, que representa codigos trabajadores.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_NOTIFICAR_CALENDARIZACION', @level2type=N'PARAMETER',@level2name=N'@CODIGOS_TRABAJADORES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo notificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_NOTIFICAR_CALENDARIZACION', @level2type=N'PARAMETER',@level2name=N'@CODIGO_NOTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa anio periodo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_NOTIFICAR_CALENDARIZACION', @level2type=N'PARAMETER',@level2name=N'@ANIO_PERIODO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa mes periodo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_NOTIFICAR_CALENDARIZACION', @level2type=N'PARAMETER',@level2name=N'@MES_PERIODO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre actividad.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_NOTIFICAR_CALENDARIZACION', @level2type=N'PARAMETER',@level2name=N'@NOMBRE_ACTIVIDAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo sistema.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_NOTIFICAR_CALENDARIZACION', @level2type=N'PARAMETER',@level2name=N'@CODIGO_SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa profile correo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_NOTIFICAR_CALENDARIZACION', @level2type=N'PARAMETER',@level2name=N'@PROFILE_CORREO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Retorna registros de la tabla Parametro_seccion ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SECCION_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo parametro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SECCION_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PARAMETRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo seccion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SECCION_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_SECCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SECCION_SEL', @level2type=N'PARAMETER',@level2name=N'@NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa codigo tipo dato.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SECCION_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_DATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador permite modificar.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SECCION_SEL', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_PERMITE_MODIFICAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador obligatorio.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SECCION_SEL', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_OBLIGATORIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador sistema.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SECCION_SEL', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SECCION_SEL', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Retorna registros de la tabla Parametro ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo parametro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PARAMETRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador empresa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SEL', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_EMPRESA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo empresa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_EMPRESA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo sistema.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa codigo identificador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa tipo parametro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SEL', @level2type=N'PARAMETER',@level2name=N'@TIPO_PARAMETRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SEL', @level2type=N'PARAMETER',@level2name=N'@NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa descripcion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SEL', @level2type=N'PARAMETER',@level2name=N'@DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador permite agregar.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SEL', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_PERMITE_AGREGAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador permite modificar.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SEL', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_PERMITE_MODIFICAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador permite eliminar.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SEL', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_PERMITE_ELIMINAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_SEL', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Inserta registros en la tabla Parametro_valor ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_INS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo parametro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PARAMETRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo seccion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_SECCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo valor.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_VALOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa valor.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_INS', @level2type=N'PARAMETER',@level2name=N'@VALOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_INS', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_INS', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_INS', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Retorna registros de la tabla Parametro_valor y Parametro ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo parametro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PARAMETRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador empresa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_SEL', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_EMPRESA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo empresa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_EMPRESA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo sistema.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa codigo identificador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa tipo parametro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_SEL', @level2type=N'PARAMETER',@level2name=N'@TIPO_PARAMETRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo seccion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_SECCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo valor.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_VALOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa valor.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_SEL', @level2type=N'PARAMETER',@level2name=N'@VALOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_SEL', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Actualiza registros de la tabla ParametroValor ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_UPD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo parametro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PARAMETRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo seccion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_SECCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo valor.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_VALOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa valor.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_UPD', @level2type=N'PARAMETER',@level2name=N'@VALOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_UPD', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_UPD', @level2type=N'PARAMETER',@level2name=N'@USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PARAMETRO_VALOR_UPD', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'  Obtiene el listado de Plantilla Notificación ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_NOTIFICACION_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo plantilla notificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_NOTIFICACION_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_PLANTILLA_NOTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo sistema.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_NOTIFICACION_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo tipo notificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_NOTIFICACION_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_NOTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa asunto.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_NOTIFICACION_SEL', @level2type=N'PARAMETER',@level2name=N'@ASUNTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador activa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_NOTIFICACION_SEL', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_ACTIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa contenido.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_NOTIFICACION_SEL', @level2type=N'PARAMETER',@level2name=N'@CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_NOTIFICACION_SEL', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_PLANTILLA_NOTIFICACION_SEL', @level2type=N'PARAMETER',@level2name=N'@PageSize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Retorna registros de la tabla Trabajador ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_DATOMINIMO_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_DATOMINIMO_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre completo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_DATOMINIMO_SEL', @level2type=N'PARAMETER',@level2name=N'@NOMBRE_COMPLETO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa correo electronico.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_DATOMINIMO_SEL', @level2type=N'PARAMETER',@level2name=N'@CORREO_ELECTRONICO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Retorna registros de la tabla Trabajador ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_FIRMA_POR_TRABAJADOR_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo trabajador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_FIRMA_POR_TRABAJADOR_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TRABAJADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Inserta registros en la tabla TRABAJADOR ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo trabajador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TRABAJADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento identidad.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_DOCUMENTO_IDENTIDAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero documento identidad.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@NUMERO_DOCUMENTO_IDENTIDAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa apellido paterno.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@APELLIDO_PATERNO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa apellido materno.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@APELLIDO_MATERNO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombres.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@NOMBRES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre completo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@NOMBRE_COMPLETO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa organizacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@ORGANIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa departamento.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@DEPARTAMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa cargo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@CARGO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa telefono trabajo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@TELEFONO_TRABAJO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa anexo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@ANEXO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa telefono movil.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@TELEFONO_MOVIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa telefono personal.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@TELEFONO_PERSONAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa correo electronico.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@CORREO_ELECTRONICO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa dominio.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@DOMINIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_INS', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Retorna registros de la tabla Trabajador ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_LISTA_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo LISTA_GUID_TYPE, que representa codigos trabajadores.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_LISTA_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGOS_TRABAJADORES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Retorna registros de la tabla Trabajador ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo trabajador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TRABAJADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento identidad.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_DOCUMENTO_IDENTIDAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero documento identidad.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_SEL', @level2type=N'PARAMETER',@level2name=N'@NUMERO_DOCUMENTO_IDENTIDAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombres.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_SEL', @level2type=N'PARAMETER',@level2name=N'@NOMBRES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa numero pagina.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_SEL', @level2type=N'PARAMETER',@level2name=N'@NUMERO_PAGINA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa tamanio pagina.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_SEL', @level2type=N'PARAMETER',@level2name=N'@TAMANIO_PAGINA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Actualiza registros de la tabla Trabajador ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo trabajador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TRABAJADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo tipo documento identidad.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_DOCUMENTO_IDENTIDAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa numero documento identidad.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@NUMERO_DOCUMENTO_IDENTIDAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa apellido paterno.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@APELLIDO_PATERNO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa apellido materno.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@APELLIDO_MATERNO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombres.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@NOMBRES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre completo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@NOMBRE_COMPLETO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa organizacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@ORGANIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa departamento.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@DEPARTAMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa cargo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@CARGO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa telefono trabajo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@TELEFONO_TRABAJO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa anexo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@ANEXO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa telefono movil.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@TELEFONO_MOVIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa telefono personal.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@TELEFONO_PERSONAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa correo electronico.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@CORREO_ELECTRONICO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_TRABAJADOR_UPD', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Retorna registro de la tabla Unidad_operativa ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_CI_EXISTE_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_CI_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Inserta registros en la tabla Unidad_operativa ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_INS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo varchar, que representa nombre.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_INS', @level2type=N'PARAMETER',@level2name=N'@NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador activa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_INS', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_ACTIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo nivel jerarquia.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_NIVEL_JERARQUIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa padre.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_UNIDAD_OPERATIVA_PADRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo tipo unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo responsable.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_RESPONSABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo zona horaria.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_INS', @level2type=N'PARAMETER',@level2name=N'@CODIGO_ZONA_HORARIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_INS', @level2type=N'PARAMETER',@level2name=N'@USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_INS', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Retorna registros de la tabla Unidad_operativa ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_LISTA_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo LISTA_GUID_TYPE, que representa codigos unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_LISTA_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGOS_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Retorna registros de la tabla Unidad_operativa ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_NOMBRE_EXISTE_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_NOMBRE_EXISTE_SEL', @level2type=N'PARAMETER',@level2name=N'@NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Retorna registros de la tabla Unidad_operativa ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa nombre.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_SEL', @level2type=N'PARAMETER',@level2name=N'@NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo nivel jerarquia.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_NIVEL_JERARQUIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa padre.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_UNIDAD_OPERATIVA_PADRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa indicador activa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_SEL', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_ACTIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa numero pagina.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_SEL', @level2type=N'PARAMETER',@level2name=N'@NUMERO_PAGINA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa tamanio pagina.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_SEL', @level2type=N'PARAMETER',@level2name=N'@TAMANIO_PAGINA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Actualiza los registros de la tabla Unidad_operativa ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_UPD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo varchar, que representa nombre.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_UPD', @level2type=N'PARAMETER',@level2name=N'@NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador activa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_UPD', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_ACTIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo nivel jerarquia.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_NIVEL_JERARQUIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo unidad operativa padre.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_UNIDAD_OPERATIVA_PADRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo tipo unidad operativa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_TIPO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo responsable.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_RESPONSABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo uniqueidentifier, que representa codigo zona horaria.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_UPD', @level2type=N'PARAMETER',@level2name=N'@CODIGO_ZONA_HORARIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa estado registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_UPD', @level2type=N'PARAMETER',@level2name=N'@ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_UPD', @level2type=N'PARAMETER',@level2name=N'@USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDAD_OPERATIVA_UPD', @level2type=N'PARAMETER',@level2name=N'@TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Retorna registros de la tablas  Trabajador, Unidad_operativa ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDADES_OPERATIVAS_POR_RESPONSABLE_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificacion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDADES_OPERATIVAS_POR_RESPONSABLE_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Retorna registros de las tabla de Unidad_operativa ' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDADES_OPERATIVAS_SUPERIORES_SEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo nivel jerarquia.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'PROCEDURE',@level1name=N'USP_UNIDADES_OPERATIVAS_SUPERIORES_SEL', @level2type=N'PARAMETER',@level2name=N'@CODIGO_NIVEL_JERARQUIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificador empresa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICADOR_EMPRESA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador empresa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_EMPRESA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificador sistema.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICADOR_SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificador parametro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICADOR_PARAMETRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo seccion.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO', @level2type=N'PARAMETER',@level2name=N'@CODIGO_SECCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Lista los valores del parametro' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificador empresa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO_BUSQUEDA', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICADOR_EMPRESA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador empresa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO_BUSQUEDA', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_EMPRESA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificador sistema.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO_BUSQUEDA', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICADOR_SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificador parametro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO_BUSQUEDA', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICADOR_PARAMETRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo seccion mostrar.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO_BUSQUEDA', @level2type=N'PARAMETER',@level2name=N'@CODIGO_SECCION_MOSTRAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa codigo seccion buscar.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO_BUSQUEDA', @level2type=N'PARAMETER',@level2name=N'@CODIGO_SECCION_BUSCAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa operador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO_BUSQUEDA', @level2type=N'PARAMETER',@level2name=N'@OPERADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa valor buscar.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO_BUSQUEDA', @level2type=N'PARAMETER',@level2name=N'@VALOR_BUSCAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Lista valores de parametro de busqueda' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO_BUSQUEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificador empresa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO_MATRIZ', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICADOR_EMPRESA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo bit, que representa indicador empresa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO_MATRIZ', @level2type=N'PARAMETER',@level2name=N'@INDICADOR_EMPRESA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificador sistema.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO_MATRIZ', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICADOR_SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo nvarchar, que representa codigo identificador parametro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO_MATRIZ', @level2type=N'PARAMETER',@level2name=N'@CODIGO_IDENTIFICADOR_PARAMETRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Listar valores de parametro matriz' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_LISTAR_VALORES_PARAMETRO_MATRIZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo char, que representa pais.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_OBTENER_FECHA_SERVIDOR', @level2type=N'PARAMETER',@level2name=N'@PAIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parámetro de entrada de tipo int, que representa hora utc.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_OBTENER_FECHA_SERVIDOR', @level2type=N'PARAMETER',@level2name=N'@HORA_UTC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Obtener fecha del servidor' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'FUNCTION',@level1name=N'FN_OBTENER_FECHA_SERVIDOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permite enviar codigos tipo Gui a la base de datos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TYPE',@level1name=N'LISTA_GUID_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Lista para pasar codigos de unidades operativas calendarizadas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TYPE',@level1name=N'LISTA_NVARCHAR_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contiene los objetos del esquema General ' , @level0type=N'SCHEMA',@level0name=N'GRL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DEPARTAMENTO', @level2type=N'COLUMN',@level2name=N'CODIGO_DEPARTAMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del País al que pertenece el departamento.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DEPARTAMENTO', @level2type=N'COLUMN',@level2name=N'CODIGO_PAIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Ubigeo del Departamento' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DEPARTAMENTO', @level2type=N'COLUMN',@level2name=N'CODIGO_UBIGEO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DEPARTAMENTO', @level2type=N'COLUMN',@level2name=N'NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DEPARTAMENTO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DEPARTAMENTO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DEPARTAMENTO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DEPARTAMENTO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DEPARTAMENTO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DEPARTAMENTO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DEPARTAMENTO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Departamentos. Nivel 1 del Ubigeo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DEPARTAMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DISTRITO', @level2type=N'COLUMN',@level2name=N'CODIGO_DISTRITO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de la Provincia a la que pertenece el Distrito.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DISTRITO', @level2type=N'COLUMN',@level2name=N'CODIGO_PROVINCIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código Ubigeo del Distrito.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DISTRITO', @level2type=N'COLUMN',@level2name=N'CODIGO_UBIGEO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DISTRITO', @level2type=N'COLUMN',@level2name=N'NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DISTRITO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DISTRITO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DISTRITO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DISTRITO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DISTRITO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DISTRITO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DISTRITO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Distrito. Nivel 3 del Ubigeo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'DISTRITO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'EMPRESA', @level2type=N'COLUMN',@level2name=N'CODIGO_EMPRESA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código Identificador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'EMPRESA', @level2type=N'COLUMN',@level2name=N'CODIGO_IDENTIFICADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'EMPRESA', @level2type=N'COLUMN',@level2name=N'NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'EMPRESA', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'EMPRESA', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'EMPRESA', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'EMPRESA', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'EMPRESA', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'EMPRESA', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'EMPRESA', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla maestra de empresas.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'EMPRESA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla, sigue el estándar ISO 4217.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'MONEDA', @level2type=N'COLUMN',@level2name=N'CODIGO_MONEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de la Moneda.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'MONEDA', @level2type=N'COLUMN',@level2name=N'NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Símbolo de la moneda.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'MONEDA', @level2type=N'COLUMN',@level2name=N'SIMBOLO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Motivo de la última modificación del registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'MONEDA', @level2type=N'COLUMN',@level2name=N'MOTIVO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'MONEDA', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'MONEDA', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'MONEDA', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'MONEDA', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'MONEDA', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'MONEDA', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'MONEDA', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla Maestra de Monedas.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'MONEDA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla. El formato sigue el estándar ISO 3166-1 alfa-3.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PAIS', @level2type=N'COLUMN',@level2name=N'CODIGO_PAIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PAIS', @level2type=N'COLUMN',@level2name=N'NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código según el estándar ISO 3166-1 alfa-2.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PAIS', @level2type=N'COLUMN',@level2name=N'CODIGO_SECUNDARIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PAIS', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PAIS', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PAIS', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PAIS', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PAIS', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PAIS', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PAIS', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla maestra de Países.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PAIS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'CODIGO_PLANTILLA_NOTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del sistema al que pertenece la plantilla' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'CODIGO_SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del tipo de notificación' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_NOTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Asunto' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'ASUNTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Texto de la plantilla' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'CONTENIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicador activa de notificación' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'INDICADOR_ACTIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo tipo destinatario' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_DESTINATARIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Destinatario de plantilla notificación' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'DESTINATARIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Destinatario copia de plantilla notificación' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION', @level2type=N'COLUMN',@level2name=N'DESTINATARIO_COPIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla donde se alamacenan las plantillas de notificaciones' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PLANTILLA_NOTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PROVINCIA', @level2type=N'COLUMN',@level2name=N'CODIGO_PROVINCIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Departamento al que pertenece la Provincia.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PROVINCIA', @level2type=N'COLUMN',@level2name=N'CODIGO_DEPARTAMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código Ubigeo de la Provincia.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PROVINCIA', @level2type=N'COLUMN',@level2name=N'CODIGO_UBIGEO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PROVINCIA', @level2type=N'COLUMN',@level2name=N'NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PROVINCIA', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PROVINCIA', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PROVINCIA', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PROVINCIA', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PROVINCIA', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PROVINCIA', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PROVINCIA', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Provincias. Nivel 2 del Ubigeo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'PROVINCIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'SISTEMA', @level2type=N'COLUMN',@level2name=N'CODIGO_SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de empresa a la que pertenece el sistema.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'SISTEMA', @level2type=N'COLUMN',@level2name=N'CODIGO_EMPRESA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de Identificación del Sistema' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'SISTEMA', @level2type=N'COLUMN',@level2name=N'CODIGO_IDENTIFICADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del sistema' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'SISTEMA', @level2type=N'COLUMN',@level2name=N'NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = activo / 0 = inactivo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'SISTEMA', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'SISTEMA', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'SISTEMA', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'SISTEMA', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'SISTEMA', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'SISTEMA', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'SISTEMA', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla maestra de sistemas' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'SISTEMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TIPO_DATO', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_DATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TIPO_DATO', @level2type=N'COLUMN',@level2name=N'NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TIPO_DATO', @level2type=N'COLUMN',@level2name=N'DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TIPO_DATO', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TIPO_DATO', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TIPO_DATO', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TIPO_DATO', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TIPO_DATO', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TIPO_DATO', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TIPO_DATO', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla maestra de los tipos de datos que puede almacenar una sección.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TIPO_DATO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'CODIGO_TRABAJADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dominio de trabajador' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'DOMINIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código con el cual se identifica al registro en AD.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'CODIGO_IDENTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Tipo de Documento de Identidad. Viene de parámetros generales.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_DOCUMENTO_IDENTIDAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número del documento de identidad.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'NUMERO_DOCUMENTO_IDENTIDAD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apellido Paterno del Trabajador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'APELLIDO_PATERNO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apellido Materno del Trabajador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'APELLIDO_MATERNO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombres del Trabajador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'NOMBRES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre Completo del Trabajador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'NOMBRE_COMPLETO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Organización a la que pertenece el trabajador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'ORGANIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Departamento en el que labora el trabajador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'DEPARTAMENTO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cargo del trabajador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'CARGO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Teléfono del Trabajo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'TELEFONO_TRABAJO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Anexo de Trabajo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'ANEXO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de celular del trabajador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'TELEFONO_MOVIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Número de Teléfono Particular del Trabajador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'TELEFONO_PERSONAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dirección de correo electronico del trabajador,' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'CORREO_ELECTRONICO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Trabajadores.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR_FIRMA', @level2type=N'COLUMN',@level2name=N'CODIGO_FIRMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del trabajador al que pertenece la firma.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR_FIRMA', @level2type=N'COLUMN',@level2name=N'CODIGO_TRABAJADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Firma del trabajador.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR_FIRMA', @level2type=N'COLUMN',@level2name=N'FIRMA_TRABAJADOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR_FIRMA', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR_FIRMA', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR_FIRMA', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR_FIRMA', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR_FIRMA', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR_FIRMA', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR_FIRMA', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que guarda las firmas de los trabajadores.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'TRABAJADOR_FIRMA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'CODIGO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de identificación' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'CODIGO_IDENTIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de la Unidad Organizacional.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'NOMBRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indica si la Unidad Organizacional se encuentra Activa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'INDICADOR_ACTIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del nivel de jerarquia de la Unidad Operativa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'CODIGO_NIVEL_JERARQUIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código de la Unidad Operativa a la que Pertenece esta.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'CODIGO_UNIDAD_OPERATIVA_PADRE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Tipo de Unidad Operativa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'CODIGO_TIPO_UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Trabajador Responsable de la Unidad Organizacional.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'CODIGO_RESPONSABLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código del Horario UTC de la Zona en donde se encuentra la Unidad Operativa.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'CODIGO_ZONA_HORARIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'DIRECCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de Unidades Operativas.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'UNIDAD_OPERATIVA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Llave principal de la tabla.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'ZONA_HORARIA', @level2type=N'COLUMN',@level2name=N'CODIGO_ZONA_HORARIA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Hora UTC.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'ZONA_HORARIA', @level2type=N'COLUMN',@level2name=N'HORA_UTC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Minuto UTC.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'ZONA_HORARIA', @level2type=N'COLUMN',@level2name=N'MINUTO_UTC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción del Horario.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'ZONA_HORARIA', @level2type=N'COLUMN',@level2name=N'DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado lógico del registro. 1 = Activo / 0 = Inactivo.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'ZONA_HORARIA', @level2type=N'COLUMN',@level2name=N'ESTADO_REGISTRO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'ZONA_HORARIA', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'ZONA_HORARIA', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se creó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'ZONA_HORARIA', @level2type=N'COLUMN',@level2name=N'TERMINAL_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de usuario que modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'ZONA_HORARIA', @level2type=N'COLUMN',@level2name=N'USUARIO_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y Hora en la que se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'ZONA_HORARIA', @level2type=N'COLUMN',@level2name=N'FECHA_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Terminal desde donde se modificó el registro.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'ZONA_HORARIA', @level2type=N'COLUMN',@level2name=N'TERMINAL_MODIFICACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla de zonas horarias.' , @level0type=N'SCHEMA',@level0name=N'GRL', @level1type=N'TABLE',@level1name=N'ZONA_HORARIA'
GO
USE [master]
GO
ALTER DATABASE [STRACON_POLITICAS] SET  READ_WRITE 
GO
