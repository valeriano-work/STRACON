USE [master]
GO
/****** Object:  Database [STRACON_SGP]    Script Date: 25/02/2020 18:03:46 ******/
CREATE DATABASE [STRACON_SGP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'STRACON_SGP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\STRACON_SGP.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'STRACON_SGP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\STRACON_SGP_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [STRACON_SGP] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [STRACON_SGP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [STRACON_SGP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [STRACON_SGP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [STRACON_SGP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [STRACON_SGP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [STRACON_SGP] SET ARITHABORT OFF 
GO
ALTER DATABASE [STRACON_SGP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [STRACON_SGP] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [STRACON_SGP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [STRACON_SGP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [STRACON_SGP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [STRACON_SGP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [STRACON_SGP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [STRACON_SGP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [STRACON_SGP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [STRACON_SGP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [STRACON_SGP] SET  ENABLE_BROKER 
GO
ALTER DATABASE [STRACON_SGP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [STRACON_SGP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [STRACON_SGP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [STRACON_SGP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [STRACON_SGP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [STRACON_SGP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [STRACON_SGP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [STRACON_SGP] SET RECOVERY FULL 
GO
ALTER DATABASE [STRACON_SGP] SET  MULTI_USER 
GO
ALTER DATABASE [STRACON_SGP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [STRACON_SGP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [STRACON_SGP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [STRACON_SGP] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'STRACON_SGP', N'ON'
GO
USE [STRACON_SGP]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 25/02/2020 18:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Area](
	[Area_ID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[Area_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Area_Descripcion] UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Concepto]    Script Date: 25/02/2020 18:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Concepto](
	[Concepto_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cuenta] [varchar](50) NULL,
	[Descripcion] [varchar](200) NULL,
	[Categoria] [varchar](200) NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_Concepto] PRIMARY KEY CLUSTERED 
(
	[Concepto_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Control_Gerencia]    Script Date: 25/02/2020 18:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Control_Gerencia](
	[Control_Gerencia_ID] [int] IDENTITY(1,1) NOT NULL,
	[Area_ID] [int] NULL,
	[Rubro_ID] [int] NULL,
	[Concepto_ID] [int] NULL,
	[Proveedor] [varchar](200) NULL,
	[Bien_Servicio] [varchar](200) NULL,
	[Precio] [decimal](18, 2) NULL,
	[Cantidad] [decimal](18, 2) NULL,
	[Enero] [decimal](18, 2) NULL,
	[Febrero] [decimal](18, 2) NULL,
	[Marzo] [decimal](18, 2) NULL,
	[Abril] [decimal](18, 2) NULL,
	[Mayo] [decimal](18, 2) NULL,
	[Junio] [decimal](18, 2) NULL,
	[Julio] [decimal](18, 2) NULL,
	[Agosto] [decimal](18, 2) NULL,
	[Septiembre] [decimal](18, 2) NULL,
	[Octubre] [decimal](18, 2) NULL,
	[Noviembre] [decimal](18, 2) NULL,
	[Diciembre] [decimal](18, 2) NULL,
	[Monto_Total] [decimal](18, 2) NULL,
	[Tipo_Presupuesto] [int] NOT NULL,
	[Presupuesto_ID] [int] NOT NULL,
 CONSTRAINT [PK_Control_Gerencia_ID] PRIMARY KEY CLUSTERED 
(
	[Control_Gerencia_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Control_Recursos_Humanos]    Script Date: 25/02/2020 18:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Control_Recursos_Humanos](
	[Control_Recursos_Humanos_ID] [int] IDENTITY(1,1) NOT NULL,
	[Trabajador_ID] [int] NULL,
	[Enero] [int] NULL,
	[Febrero] [int] NULL,
	[Marzo] [int] NULL,
	[Abril] [int] NULL,
	[Mayo] [int] NULL,
	[Junio] [int] NULL,
	[Julio] [int] NULL,
	[Agosto] [int] NULL,
	[Septiembre] [int] NULL,
	[Octubre] [int] NULL,
	[Noviembre] [int] NULL,
	[Diciembre] [int] NULL,
	[Asignacion_Familiar] [int] NULL,
	[Presupuesto_ID] [int] NOT NULL,
 CONSTRAINT [PK_Control_Recursos_Humanos_ID] PRIMARY KEY CLUSTERED 
(
	[Control_Recursos_Humanos_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gerencia]    Script Date: 25/02/2020 18:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Gerencia](
	[Gerencia_ID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Gerencia_ID] PRIMARY KEY CLUSTERED 
(
	[Gerencia_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Gerencia_Descripcion] UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Presupuesto]    Script Date: 25/02/2020 18:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Presupuesto](
	[Presupuesto_ID] [int] IDENTITY(1,1) NOT NULL,
	[Presupuesto_Year] [int] NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Presupuesto_ID] PRIMARY KEY CLUSTERED 
(
	[Presupuesto_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Presupuesto_Descripcion] UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Puesto]    Script Date: 25/02/2020 18:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Puesto](
	[Puesto_ID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Puesto_ID] PRIMARY KEY CLUSTERED 
(
	[Puesto_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Puesto_Descripcion] UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rubro]    Script Date: 25/02/2020 18:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rubro](
	[Rubro_ID] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_Rubro] PRIMARY KEY CLUSTERED 
(
	[Rubro_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Rubro_Descripcion] UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Trabajador]    Script Date: 25/02/2020 18:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Trabajador](
	[Trabajador_ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](200) NOT NULL,
	[Paterno] [varchar](200) NOT NULL,
	[Materno] [varchar](200) NOT NULL,
	[Puesto_ID] [int] NOT NULL,
	[Area_ID] [int] NOT NULL,
	[Gerencia_ID] [int] NOT NULL,
	[Sueldo] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Trabajador_ID] PRIMARY KEY CLUSTERED 
(
	[Trabajador_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Control_Gerencia]  WITH CHECK ADD  CONSTRAINT [FK_Area] FOREIGN KEY([Area_ID])
REFERENCES [dbo].[Area] ([Area_ID])
GO
ALTER TABLE [dbo].[Control_Gerencia] CHECK CONSTRAINT [FK_Area]
GO
ALTER TABLE [dbo].[Control_Gerencia]  WITH CHECK ADD  CONSTRAINT [FK_Concepto] FOREIGN KEY([Concepto_ID])
REFERENCES [dbo].[Concepto] ([Concepto_ID])
GO
ALTER TABLE [dbo].[Control_Gerencia] CHECK CONSTRAINT [FK_Concepto]
GO
ALTER TABLE [dbo].[Control_Gerencia]  WITH CHECK ADD  CONSTRAINT [FK_Control_Gerencia_Presupuesto] FOREIGN KEY([Presupuesto_ID])
REFERENCES [dbo].[Presupuesto] ([Presupuesto_ID])
GO
ALTER TABLE [dbo].[Control_Gerencia] CHECK CONSTRAINT [FK_Control_Gerencia_Presupuesto]
GO
ALTER TABLE [dbo].[Control_Gerencia]  WITH CHECK ADD  CONSTRAINT [FK_Rubro] FOREIGN KEY([Rubro_ID])
REFERENCES [dbo].[Rubro] ([Rubro_ID])
GO
ALTER TABLE [dbo].[Control_Gerencia] CHECK CONSTRAINT [FK_Rubro]
GO
ALTER TABLE [dbo].[Control_Recursos_Humanos]  WITH CHECK ADD  CONSTRAINT [FK_Control_Recursos_Humanos_Presupuesto] FOREIGN KEY([Presupuesto_ID])
REFERENCES [dbo].[Presupuesto] ([Presupuesto_ID])
GO
ALTER TABLE [dbo].[Control_Recursos_Humanos] CHECK CONSTRAINT [FK_Control_Recursos_Humanos_Presupuesto]
GO
ALTER TABLE [dbo].[Control_Recursos_Humanos]  WITH CHECK ADD  CONSTRAINT [FK_Control_Recursos_Humanos_Trabajador] FOREIGN KEY([Trabajador_ID])
REFERENCES [dbo].[Trabajador] ([Trabajador_ID])
GO
ALTER TABLE [dbo].[Control_Recursos_Humanos] CHECK CONSTRAINT [FK_Control_Recursos_Humanos_Trabajador]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Puesto] FOREIGN KEY([Puesto_ID])
REFERENCES [dbo].[Puesto] ([Puesto_ID])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Puesto]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_Area] FOREIGN KEY([Area_ID])
REFERENCES [dbo].[Area] ([Area_ID])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_Area]
GO
ALTER TABLE [dbo].[Trabajador]  WITH CHECK ADD  CONSTRAINT [FK_Trabajador_Gerencia] FOREIGN KEY([Gerencia_ID])
REFERENCES [dbo].[Gerencia] ([Gerencia_ID])
GO
ALTER TABLE [dbo].[Trabajador] CHECK CONSTRAINT [FK_Trabajador_Gerencia]
GO
USE [master]
GO
ALTER DATABASE [STRACON_SGP] SET  READ_WRITE 
GO
