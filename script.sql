USE [master]
GO
/****** Object:  Database [HelpDesk]    Script Date: 5/20/2022 12:57:35 AM ******/
CREATE DATABASE [HelpDesk]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HelpDesk', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HelpDesk.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HelpDesk_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HelpDesk_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HelpDesk] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HelpDesk].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HelpDesk] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HelpDesk] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HelpDesk] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HelpDesk] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HelpDesk] SET ARITHABORT OFF 
GO
ALTER DATABASE [HelpDesk] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HelpDesk] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HelpDesk] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HelpDesk] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HelpDesk] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HelpDesk] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HelpDesk] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HelpDesk] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HelpDesk] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HelpDesk] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HelpDesk] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HelpDesk] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HelpDesk] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HelpDesk] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HelpDesk] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HelpDesk] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HelpDesk] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HelpDesk] SET RECOVERY FULL 
GO
ALTER DATABASE [HelpDesk] SET  MULTI_USER 
GO
ALTER DATABASE [HelpDesk] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HelpDesk] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HelpDesk] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HelpDesk] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HelpDesk] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HelpDesk] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HelpDesk', N'ON'
GO
ALTER DATABASE [HelpDesk] SET QUERY_STORE = OFF
GO
USE [HelpDesk]
GO
/****** Object:  User [edgar]    Script Date: 5/20/2022 12:57:35 AM ******/
CREATE USER [edgar] FOR LOGIN [edgar] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [drop]    Script Date: 5/20/2022 12:57:35 AM ******/
CREATE USER [drop] FOR LOGIN [drop] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 5/20/2022 12:57:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[description] [text] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comments]    Script Date: 5/20/2022 12:57:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comments](
	[comment_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[ticket_id] [int] NULL,
	[description] [text] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[deparments]    Script Date: 5/20/2022 12:57:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[deparments](
	[deparment_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[description] [text] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[deparment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[log_time]    Script Date: 5/20/2022 12:57:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[log_time](
	[log_time_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[ticket_id] [int] NULL,
	[description] [text] NULL,
	[date] [date] NULL,
	[hours] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[log_time_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[priorities]    Script Date: 5/20/2022 12:57:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[priorities](
	[priority_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[description] [text] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[priority_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[records_tickets]    Script Date: 5/20/2022 12:57:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[records_tickets](
	[record_ticket_id] [int] IDENTITY(1,1) NOT NULL,
	[ticket_id] [int] NULL,
	[description] [text] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[record_ticket_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rols]    Script Date: 5/20/2022 12:57:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rols](
	[rol_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[description] [text] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rols_users]    Script Date: 5/20/2022 12:57:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rols_users](
	[rol_user_id] [int] IDENTITY(1,1) NOT NULL,
	[rol_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[rol_user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[status]    Script Date: 5/20/2022 12:57:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[status](
	[status_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[description] [text] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tickets]    Script Date: 5/20/2022 12:57:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tickets](
	[ticket_id] [int] IDENTITY(1,1) NOT NULL,
	[description] [text] NULL,
	[case_number] [varchar](50) NULL,
	[reported_by] [int] NOT NULL,
	[assigned_to] [int] NOT NULL,
	[priority_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
	[status_id] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ticket_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 5/20/2022 12:57:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[deparment_id] [int] NOT NULL,
	[name] [varchar](50) NULL,
	[lastname] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[comments]  WITH CHECK ADD FOREIGN KEY([ticket_id])
REFERENCES [dbo].[tickets] ([ticket_id])
GO
ALTER TABLE [dbo].[comments]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[log_time]  WITH CHECK ADD FOREIGN KEY([ticket_id])
REFERENCES [dbo].[tickets] ([ticket_id])
GO
ALTER TABLE [dbo].[log_time]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[records_tickets]  WITH CHECK ADD FOREIGN KEY([ticket_id])
REFERENCES [dbo].[tickets] ([ticket_id])
GO
ALTER TABLE [dbo].[rols_users]  WITH CHECK ADD FOREIGN KEY([rol_id])
REFERENCES [dbo].[rols] ([rol_id])
GO
ALTER TABLE [dbo].[rols_users]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[tickets]  WITH CHECK ADD FOREIGN KEY([assigned_to])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[tickets]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[categories] ([category_id])
GO
ALTER TABLE [dbo].[tickets]  WITH CHECK ADD FOREIGN KEY([priority_id])
REFERENCES [dbo].[priorities] ([priority_id])
GO
ALTER TABLE [dbo].[tickets]  WITH CHECK ADD FOREIGN KEY([reported_by])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[tickets]  WITH CHECK ADD FOREIGN KEY([status_id])
REFERENCES [dbo].[status] ([status_id])
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD FOREIGN KEY([deparment_id])
REFERENCES [dbo].[deparments] ([deparment_id])
GO
USE [master]
GO
ALTER DATABASE [HelpDesk] SET  READ_WRITE 
GO
