
/****** Object:  Database [TechnicalInstance]    Script Date: 3/18/2024 2:41:04 AM ******/
CREATE DATABASE [TechnicalInstance]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TechnicalInstance', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TechnicalInstance.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TechnicalInstance_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TechnicalInstance_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TechnicalInstance] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TechnicalInstance].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TechnicalInstance] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TechnicalInstance] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TechnicalInstance] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TechnicalInstance] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TechnicalInstance] SET ARITHABORT OFF 
GO
ALTER DATABASE [TechnicalInstance] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TechnicalInstance] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TechnicalInstance] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TechnicalInstance] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TechnicalInstance] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TechnicalInstance] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TechnicalInstance] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TechnicalInstance] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TechnicalInstance] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TechnicalInstance] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TechnicalInstance] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TechnicalInstance] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TechnicalInstance] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TechnicalInstance] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TechnicalInstance] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TechnicalInstance] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TechnicalInstance] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TechnicalInstance] SET RECOVERY FULL 
GO
ALTER DATABASE [TechnicalInstance] SET  MULTI_USER 
GO
ALTER DATABASE [TechnicalInstance] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TechnicalInstance] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TechnicalInstance] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TechnicalInstance] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TechnicalInstance] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TechnicalInstance] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TechnicalInstance', N'ON'
GO
ALTER DATABASE [TechnicalInstance] SET QUERY_STORE = ON
GO
ALTER DATABASE [TechnicalInstance] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TechnicalInstance]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 3/18/2024 2:41:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] NOT NULL,
	[Title] [varchar](250) NOT NULL,
	[OriginalTitle] [varchar](250) NOT NULL,
	[OverView] [varchar](max) NOT NULL,
	[ReleaseDate] [datetime] NULL,
	[VoteCount] [int] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/18/2024 2:41:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PasswordHash] [varbinary](150) NOT NULL,
	[PasswordSalt] [varbinary](150) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [TechnicalInstance] SET  READ_WRITE 
GO
