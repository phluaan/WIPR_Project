USE [master]
GO
/****** Object:  Database [QLyViecLam]    Script Date: 5/12/2024 3:19:24 PM ******/
CREATE DATABASE [QLyViecLam]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLyViecLam', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LUAAN\MSSQL\DATA\QLyViecLam.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLyViecLam_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LUAAN\MSSQL\DATA\QLyViecLam_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QLyViecLam] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLyViecLam].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLyViecLam] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLyViecLam] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLyViecLam] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLyViecLam] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLyViecLam] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLyViecLam] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLyViecLam] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLyViecLam] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLyViecLam] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLyViecLam] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLyViecLam] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLyViecLam] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLyViecLam] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLyViecLam] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLyViecLam] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLyViecLam] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLyViecLam] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLyViecLam] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLyViecLam] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLyViecLam] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLyViecLam] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLyViecLam] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLyViecLam] SET RECOVERY FULL 
GO
ALTER DATABASE [QLyViecLam] SET  MULTI_USER 
GO
ALTER DATABASE [QLyViecLam] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLyViecLam] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLyViecLam] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLyViecLam] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLyViecLam] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLyViecLam] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLyViecLam', N'ON'
GO
ALTER DATABASE [QLyViecLam] SET QUERY_STORE = OFF
GO
USE [QLyViecLam]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/12/2024 3:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] NOT NULL,
	[userAccount] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
	[userRole] [nvarchar](100) NULL,
	[idInforUser] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[busyDate]    Script Date: 5/12/2024 3:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[busyDate](
	[id] [int] NOT NULL,
	[idUser] [int] NULL,
	[userRole] [nvarchar](100) NULL,
	[userBusyDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dateWork]    Script Date: 5/12/2024 3:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dateWork](
	[id] [int] NOT NULL,
	[idTho] [int] NULL,
	[idNguoiDung] [int] NULL,
	[idEvaluation] [int] NULL,
	[progress] [nvarchar](100) NULL,
	[job] [nvarchar](100) NULL,
	[dateWork] [int] NULL,
	[price] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evaluation]    Script Date: 5/12/2024 3:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluation](
	[id] [int] NOT NULL,
	[idTho] [int] NULL,
	[idNguoiDung] [int] NULL,
	[numOfStar] [decimal](3, 2) NULL,
	[userEvaluation] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favourite]    Script Date: 5/12/2024 3:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favourite](
	[id] [int] NOT NULL,
	[idBaiViet] [int] NULL,
	[idNguoiDung] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InforPostNguoiDung]    Script Date: 5/12/2024 3:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InforPostNguoiDung](
	[id] [int] NOT NULL,
	[idNguoiDung] [int] NULL,
	[job] [nvarchar](100) NULL,
	[experience] [nvarchar](100) NULL,
	[price] [nvarchar](100) NULL,
	[idPosts] [int] NULL,
	[note] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InforPostTho]    Script Date: 5/12/2024 3:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InforPostTho](
	[id] [int] NOT NULL,
	[idTho] [int] NULL,
	[job] [nvarchar](100) NULL,
	[experience] [nvarchar](100) NULL,
	[price] [nvarchar](100) NULL,
	[idPosts] [int] NULL,
	[note] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InforUser]    Script Date: 5/12/2024 3:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InforUser](
	[id] [int] NOT NULL,
	[name] [nvarchar](100) NULL,
	[birthDate] [date] NULL,
	[email] [nvarchar](100) NULL,
	[phone] [nvarchar](100) NULL,
	[gender] [nvarchar](100) NULL,
	[address] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 5/12/2024 3:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[id] [int] NOT NULL,
	[createDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestUser]    Script Date: 5/12/2024 3:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestUser](
	[id] [int] NOT NULL,
	[idTho] [int] NULL,
	[idNguoiDung] [int] NULL,
	[idPost] [int] NULL,
	[sendFrom] [nvarchar](100) NULL,
	[dateWork] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([id], [userAccount], [password], [userRole], [idInforUser]) VALUES (0, N'ND', N'ND', N'NguoiDung', 0)
INSERT [dbo].[Account] ([id], [userAccount], [password], [userRole], [idInforUser]) VALUES (1, N'T', N'T', N'Tho', 1)
INSERT [dbo].[Account] ([id], [userAccount], [password], [userRole], [idInforUser]) VALUES (2, N'ND1', N'ND1', N'NguoiDung', 2)
INSERT [dbo].[Account] ([id], [userAccount], [password], [userRole], [idInforUser]) VALUES (3, N'T1', N'T1', N'Tho', 3)
INSERT [dbo].[Account] ([id], [userAccount], [password], [userRole], [idInforUser]) VALUES (4, N'T2', N'T2', N'Tho', 4)
INSERT [dbo].[Account] ([id], [userAccount], [password], [userRole], [idInforUser]) VALUES (5, N'T5', N'T5', N'Tho', 5)
GO
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (0, 1, N'Tho', CAST(N'2024-04-05' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (1, 0, N'NguoiDung', CAST(N'2024-04-05' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (2, 1, N'Tho', CAST(N'2024-04-05' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (3, 0, N'NguoiDung', CAST(N'2024-04-05' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (4, 1, N'Tho', CAST(N'2024-04-05' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (5, 0, N'NguoiDung', CAST(N'2024-04-05' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (6, 1, N'Tho', CAST(N'2024-04-05' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (7, 0, N'NguoiDung', CAST(N'2024-04-05' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (8, 0, N'NguoiDung', CAST(N'2024-04-16' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (9, 0, N'NguoiDung', CAST(N'2024-04-24' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (10, 0, N'NguoiDung', CAST(N'2024-04-27' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (11, 0, N'NguoiDung', CAST(N'2024-04-30' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (12, 0, N'NguoiDung', CAST(N'2024-04-29' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (13, 0, N'NguoiDung', CAST(N'2024-04-28' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (14, 0, N'NguoiDung', CAST(N'2024-04-23' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (15, 0, N'NguoiDung', CAST(N'2024-04-25' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (16, 1, N'Tho', CAST(N'2024-04-13' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (17, 0, N'NguoiDung', CAST(N'2024-04-13' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (18, 1, N'Tho', CAST(N'2024-04-19' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (19, 0, N'NguoiDung', CAST(N'2024-04-19' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (20, 1, N'Tho', CAST(N'2024-04-05' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (21, 2, N'NguoiDung', CAST(N'2024-04-05' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (22, 1, N'Tho', CAST(N'2024-04-30' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (23, 0, N'NguoiDung', CAST(N'2024-04-30' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (24, 3, N'Tho', CAST(N'2024-05-03' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (25, 0, N'NguoiDung', CAST(N'2024-05-03' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (26, 1, N'Tho', CAST(N'2024-04-05' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (27, 2, N'NguoiDung', CAST(N'2024-04-05' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (28, 1, N'Tho', CAST(N'2024-04-12' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (29, 0, N'NguoiDung', CAST(N'2024-04-12' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (30, 1, N'Tho', CAST(N'2024-04-26' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (31, 0, N'NguoiDung', CAST(N'2024-04-26' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (32, 1, N'Tho', CAST(N'2024-05-30' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (33, 0, N'NguoiDung', CAST(N'2024-05-30' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (34, 0, N'', CAST(N'2024-05-21' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (35, 0, N'', CAST(N'2024-05-22' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (36, 0, N'', CAST(N'2024-05-23' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (37, 0, N'', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (38, 1, N'Tho', CAST(N'2024-05-31' AS Date))
INSERT [dbo].[busyDate] ([id], [idUser], [userRole], [userBusyDate]) VALUES (39, 0, N'NguoiDung', CAST(N'2024-05-31' AS Date))
GO
INSERT [dbo].[dateWork] ([id], [idTho], [idNguoiDung], [idEvaluation], [progress], [job], [dateWork], [price]) VALUES (2, 1, 0, 2, N'DaHoanThanh', N'Gia su', 0, N'100000')
INSERT [dbo].[dateWork] ([id], [idTho], [idNguoiDung], [idEvaluation], [progress], [job], [dateWork], [price]) VALUES (3, 1, 0, 0, N'DaHoanThanh', N'Gia su', 2, N'200000')
INSERT [dbo].[dateWork] ([id], [idTho], [idNguoiDung], [idEvaluation], [progress], [job], [dateWork], [price]) VALUES (4, 1, 0, 5, N'DaHoanThanh', N'Gia su', 4, N'300000')
INSERT [dbo].[dateWork] ([id], [idTho], [idNguoiDung], [idEvaluation], [progress], [job], [dateWork], [price]) VALUES (5, 1, 0, 0, N'DaHoanThanh', N'Gia su', 6, N'400000')
INSERT [dbo].[dateWork] ([id], [idTho], [idNguoiDung], [idEvaluation], [progress], [job], [dateWork], [price]) VALUES (6, 1, 0, 4, N'DaHoanThanh', N'Gia su', 16, N'500000')
INSERT [dbo].[dateWork] ([id], [idTho], [idNguoiDung], [idEvaluation], [progress], [job], [dateWork], [price]) VALUES (7, 1, 0, 0, N'DaHoanThanh', N'Gia su', 18, N'675000')
INSERT [dbo].[dateWork] ([id], [idTho], [idNguoiDung], [idEvaluation], [progress], [job], [dateWork], [price]) VALUES (8, 1, 2, 0, N'DaHoanThanh', N'Gia su', 20, N'1000000')
INSERT [dbo].[dateWork] ([id], [idTho], [idNguoiDung], [idEvaluation], [progress], [job], [dateWork], [price]) VALUES (9, 1, 0, 0, N'DaHoanThanh', N'Gia su', 22, N'800000')
INSERT [dbo].[dateWork] ([id], [idTho], [idNguoiDung], [idEvaluation], [progress], [job], [dateWork], [price]) VALUES (10, 3, 0, 0, N'ChuaBatDau', N'Gia su', 24, N'500.000 - 1.000.000')
INSERT [dbo].[dateWork] ([id], [idTho], [idNguoiDung], [idEvaluation], [progress], [job], [dateWork], [price]) VALUES (11, 1, 2, 0, N'ChuaBatDau', N'Gia su', 26, N'Dưới 200.000')
INSERT [dbo].[dateWork] ([id], [idTho], [idNguoiDung], [idEvaluation], [progress], [job], [dateWork], [price]) VALUES (12, 1, 0, 0, N'ChuaBatDau', N'Gia su', 28, N'Dưới 200.000')
INSERT [dbo].[dateWork] ([id], [idTho], [idNguoiDung], [idEvaluation], [progress], [job], [dateWork], [price]) VALUES (13, 1, 0, 0, N'DaHoanThanh', N'Gia su', 30, N'100000')
INSERT [dbo].[dateWork] ([id], [idTho], [idNguoiDung], [idEvaluation], [progress], [job], [dateWork], [price]) VALUES (14, 1, 0, 6, N'DaHoanThanh', N'Tho sua ong nuoc', 32, N'500000')
INSERT [dbo].[dateWork] ([id], [idTho], [idNguoiDung], [idEvaluation], [progress], [job], [dateWork], [price]) VALUES (15, 1, 0, 0, N'DaHoanThanh', N'Bảo trì thiết bị', 38, N'500000')
GO
INSERT [dbo].[Evaluation] ([id], [idTho], [idNguoiDung], [numOfStar], [userEvaluation]) VALUES (0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Evaluation] ([id], [idTho], [idNguoiDung], [numOfStar], [userEvaluation]) VALUES (1, 1, 0, CAST(3.75 AS Decimal(3, 2)), N'Thay giao day hay, de hieu')
INSERT [dbo].[Evaluation] ([id], [idTho], [idNguoiDung], [numOfStar], [userEvaluation]) VALUES (2, 1, 1, CAST(4.25 AS Decimal(3, 2)), N'Giao vien day gioi')
INSERT [dbo].[Evaluation] ([id], [idTho], [idNguoiDung], [numOfStar], [userEvaluation]) VALUES (3, 1, 0, CAST(4.25 AS Decimal(3, 2)), N'Thầy giáo dạy giỏi, tuy nhiên hay trễ giờ')
INSERT [dbo].[Evaluation] ([id], [idTho], [idNguoiDung], [numOfStar], [userEvaluation]) VALUES (4, 1, 0, CAST(5.00 AS Decimal(3, 2)), N'Tốt')
INSERT [dbo].[Evaluation] ([id], [idTho], [idNguoiDung], [numOfStar], [userEvaluation]) VALUES (5, 1, 0, CAST(4.25 AS Decimal(3, 2)), N'Thầy giáo dạy giỏi, tuy nhiên hay trễ giờ')
INSERT [dbo].[Evaluation] ([id], [idTho], [idNguoiDung], [numOfStar], [userEvaluation]) VALUES (6, 1, 0, CAST(3.75 AS Decimal(3, 2)), N'Sửa tốt nhưng đi trễ')
GO
INSERT [dbo].[Favourite] ([id], [idBaiViet], [idNguoiDung]) VALUES (2, 5, 0)
INSERT [dbo].[Favourite] ([id], [idBaiViet], [idNguoiDung]) VALUES (4, 3, 0)
INSERT [dbo].[Favourite] ([id], [idBaiViet], [idNguoiDung]) VALUES (5, 1, 0)
INSERT [dbo].[Favourite] ([id], [idBaiViet], [idNguoiDung]) VALUES (6, 8, 0)
INSERT [dbo].[Favourite] ([id], [idBaiViet], [idNguoiDung]) VALUES (7, 4, 0)
INSERT [dbo].[Favourite] ([id], [idBaiViet], [idNguoiDung]) VALUES (9, 6, 0)
GO
INSERT [dbo].[InforPostNguoiDung] ([id], [idNguoiDung], [job], [experience], [price], [idPosts], [note]) VALUES (0, 0, N'Bao tri thiet bi', N'Dưới 1 năm', N'Trên 3.000.000', 1, NULL)
INSERT [dbo].[InforPostNguoiDung] ([id], [idNguoiDung], [job], [experience], [price], [idPosts], [note]) VALUES (1, 0, N'Bao tri thiet bi', N'1 - 2 năm', N'Trên 3.000.000', 2, NULL)
INSERT [dbo].[InforPostNguoiDung] ([id], [idNguoiDung], [job], [experience], [price], [idPosts], [note]) VALUES (2, 2, N'Gia su', N'3 - 4 năm', N'Dưới 200.000', 5, NULL)
INSERT [dbo].[InforPostNguoiDung] ([id], [idNguoiDung], [job], [experience], [price], [idPosts], [note]) VALUES (3, 2, N'Gia su', N'Trên 5 năm', N'500.000 - 1.000.000', 6, NULL)
INSERT [dbo].[InforPostNguoiDung] ([id], [idNguoiDung], [job], [experience], [price], [idPosts], [note]) VALUES (4, 2, N'Gia su', N'1 - 2 năm', N'500.000 - 1.000.000', 7, NULL)
INSERT [dbo].[InforPostNguoiDung] ([id], [idNguoiDung], [job], [experience], [price], [idPosts], [note]) VALUES (5, 0, N'Bao tri thiet bi', N'3 - 4 năm', N'Dưới 200.000', 18, NULL)
INSERT [dbo].[InforPostNguoiDung] ([id], [idNguoiDung], [job], [experience], [price], [idPosts], [note]) VALUES (6, 0, N'Bao tri thiet bi', N'Dưới 1 năm', N'500.000 - 1.000.000', 19, NULL)
INSERT [dbo].[InforPostNguoiDung] ([id], [idNguoiDung], [job], [experience], [price], [idPosts], [note]) VALUES (7, 0, N'Bao tri thiet bi', N'1 - 2 năm', N'Trên 3.000.000', 20, NULL)
INSERT [dbo].[InforPostNguoiDung] ([id], [idNguoiDung], [job], [experience], [price], [idPosts], [note]) VALUES (8, 0, N'Bao tri thiet bi', N'Dưới 1 năm', N'Trên 3.000.000', 21, NULL)
INSERT [dbo].[InforPostNguoiDung] ([id], [idNguoiDung], [job], [experience], [price], [idPosts], [note]) VALUES (9, 0, N'Bao tri thiet bi', N'3 - 4 năm', N'Dưới 200.000', 22, NULL)
INSERT [dbo].[InforPostNguoiDung] ([id], [idNguoiDung], [job], [experience], [price], [idPosts], [note]) VALUES (10, 0, N'Bao tri thiet bi', N'1 - 2 năm', N'Trên 3.000.000', 24, NULL)
INSERT [dbo].[InforPostNguoiDung] ([id], [idNguoiDung], [job], [experience], [price], [idPosts], [note]) VALUES (11, 0, N'Bao tri thiet bi', N'Dưới 1 năm', N'Trên 3.000.000', 26, N'Hư máy lạnh, cần người sửa gấp!')
INSERT [dbo].[InforPostNguoiDung] ([id], [idNguoiDung], [job], [experience], [price], [idPosts], [note]) VALUES (12, 0, N'Bảo trì thiết bị', N'3 - 4 năm', N'2.000.000 - 2.500.000', 27, NULL)
INSERT [dbo].[InforPostNguoiDung] ([id], [idNguoiDung], [job], [experience], [price], [idPosts], [note]) VALUES (13, 0, N'Bảo trì thiết bị', N'2 - 3 năm', N'Dưới 200.000', 28, N'Máy lạnh hư, cần sửa gấp')
GO
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (0, 1, N'Thợ sửa ống nước', N'Dưới 1 năm', N'Dưới 200.000', 0, N'')
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (1, 3, N'Gia sư', N'1 - 2 năm', N'Trên 3.000.000', 3, N'12345')
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (2, 1, N'Gia sư', N'2 - 3 năm', N'500.000 - 1.000.000', 4, NULL)
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (3, 3, N'Gia sư', N'1 - 2 năm', N'Trên 3.000.000', 8, N'abcdf')
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (4, 3, N'Gia sư', N'3 - 4 năm', N'2.000.000 - 2.500.000', 9, NULL)
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (5, 3, N'Gia sư', N'1 - 2 năm', N'Dưới 200.000', 10, NULL)
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (6, 1, N'Thợ sửa ống nước', N'4 - 5 năm', N'Trên 3.000.000', 11, N'kmnoq')
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (7, 1, N'Thợ sửa ống nước', N'1 - 2 năm', N'500.000 - 1.000.000', 12, NULL)
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (8, 1, N'Thợ sửa ống nước', N'Trên 5 năm', N'Dưới 200.000', 13, NULL)
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (9, 1, N'Thợ sửa ống nước', N'1 - 2 năm', N'500.000 - 1.000.000', 14, NULL)
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (10, 1, N'Thợ sửa ống nước', N'1 - 2 năm', N'Dưới 200.000', 15, NULL)
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (11, 1, N'Thợ sửa ống nước', N'1 - 2 năm', N'500.000 - 1.000.000', 16, NULL)
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (12, 1, N'Thợ sửa điện', N'1 - 2 năm', N'Dưới 200.000', 17, NULL)
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (13, 1, N'Bảo trì thiết bị', N'Trên 5 năm', N'2.000.000 - 2.500.000', 23, NULL)
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (14, 1, N'Bảo trì thiết bị', N'Dưới 1 năm', N'500.000 - 1.000.000', 25, N'Tuy chỉ mới làm việc 1 năm nhưng tôi đã dành thời gian học hỏi nhiều năm')
INSERT [dbo].[InforPostTho] ([id], [idTho], [job], [experience], [price], [idPosts], [note]) VALUES (15, 1, N'Bảo trì thiết bị', N'4 - 5 năm', N'2.500.000 - 3.000.000', 29, N'Cam kết 100% mọi thiết bị đều có thể hoạt động!')
GO
INSERT [dbo].[InforUser] ([id], [name], [birthDate], [email], [phone], [gender], [address]) VALUES (0, N'Do Phu Luan', CAST(N'2004-11-08' AS Date), N'luandophu8114@gmail.com', N'0862267674', N'Nam', N'Quận 1')
INSERT [dbo].[InforUser] ([id], [name], [birthDate], [email], [phone], [gender], [address]) VALUES (1, N'Huynh Minh Man', CAST(N'2004-04-04' AS Date), N'huynhminhman444@gmail.com', N'0987654321', N'Nam', N'Quận 2')
INSERT [dbo].[InforUser] ([id], [name], [birthDate], [email], [phone], [gender], [address]) VALUES (2, N'Nguyen Van A', CAST(N'2004-04-03' AS Date), N'nguyenvana434@gmail.com', N'0123456789', N'Nam', N'Quận 3')
INSERT [dbo].[InforUser] ([id], [name], [birthDate], [email], [phone], [gender], [address]) VALUES (3, N'Nguyen Thi B', CAST(N'2004-01-01' AS Date), N'nguyenthib114@gmail.com', N'0897654321', N'Nữ', N'Quận 4')
INSERT [dbo].[InforUser] ([id], [name], [birthDate], [email], [phone], [gender], [address]) VALUES (4, N'Nguyen Thi Chim Se', CAST(N'2001-03-28' AS Date), N'ChimSe@gmail.com', N'0987654331', N'Nữ', N'Quận 5')
INSERT [dbo].[InforUser] ([id], [name], [birthDate], [email], [phone], [gender], [address]) VALUES (5, N'Nguyen Van Nam', CAST(N'2024-05-16' AS Date), N'Nam5@gmail.com', N'555555555', N'Nam', N'Quận 5')
GO
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (0, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (1, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (2, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (3, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (4, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (5, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (6, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (7, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (8, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (9, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (10, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (11, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (12, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (13, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (14, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (15, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (16, CAST(N'2024-04-03' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (17, CAST(N'2024-04-05' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (18, CAST(N'2024-04-05' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (19, CAST(N'2024-04-05' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (20, CAST(N'2024-04-05' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (21, CAST(N'2024-04-26' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (22, CAST(N'2024-04-26' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (23, CAST(N'2024-05-09' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (24, CAST(N'2024-05-09' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (25, CAST(N'2024-05-09' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (26, CAST(N'2024-05-09' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (27, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (28, CAST(N'2024-05-10' AS Date))
INSERT [dbo].[Posts] ([id], [createDate]) VALUES (29, CAST(N'2024-05-12' AS Date))
GO
INSERT [dbo].[RequestUser] ([id], [idTho], [idNguoiDung], [idPost], [sendFrom], [dateWork]) VALUES (6, 1, 0, 0, N'Tho', CAST(N'2024-04-05' AS Date))
INSERT [dbo].[RequestUser] ([id], [idTho], [idNguoiDung], [idPost], [sendFrom], [dateWork]) VALUES (7, 1, 0, 0, N'Tho', CAST(N'2024-04-05' AS Date))
INSERT [dbo].[RequestUser] ([id], [idTho], [idNguoiDung], [idPost], [sendFrom], [dateWork]) VALUES (10, 1, 0, 0, N'Tho', CAST(N'2024-04-19' AS Date))
INSERT [dbo].[RequestUser] ([id], [idTho], [idNguoiDung], [idPost], [sendFrom], [dateWork]) VALUES (11, 1, 0, 0, N'Tho', CAST(N'2024-04-30' AS Date))
INSERT [dbo].[RequestUser] ([id], [idTho], [idNguoiDung], [idPost], [sendFrom], [dateWork]) VALUES (14, 1, 0, 0, N'Tho', CAST(N'2024-04-18' AS Date))
INSERT [dbo].[RequestUser] ([id], [idTho], [idNguoiDung], [idPost], [sendFrom], [dateWork]) VALUES (15, 1, 0, 0, N'Tho', CAST(N'2024-04-20' AS Date))
INSERT [dbo].[RequestUser] ([id], [idTho], [idNguoiDung], [idPost], [sendFrom], [dateWork]) VALUES (16, 1, 0, 0, N'Tho', CAST(N'2024-04-26' AS Date))
INSERT [dbo].[RequestUser] ([id], [idTho], [idNguoiDung], [idPost], [sendFrom], [dateWork]) VALUES (17, 1, 0, 0, N'Tho', CAST(N'2024-04-26' AS Date))
INSERT [dbo].[RequestUser] ([id], [idTho], [idNguoiDung], [idPost], [sendFrom], [dateWork]) VALUES (19, 1, 0, 9, N'Tho', CAST(N'2024-05-04' AS Date))
INSERT [dbo].[RequestUser] ([id], [idTho], [idNguoiDung], [idPost], [sendFrom], [dateWork]) VALUES (20, 1, 0, 0, N'NguoiDung', CAST(N'2024-05-04' AS Date))
INSERT [dbo].[RequestUser] ([id], [idTho], [idNguoiDung], [idPost], [sendFrom], [dateWork]) VALUES (22, 1, 0, 10, N'Tho', CAST(N'2024-05-25' AS Date))
INSERT [dbo].[RequestUser] ([id], [idTho], [idNguoiDung], [idPost], [sendFrom], [dateWork]) VALUES (23, 1, 0, 0, N'NguoiDung', CAST(N'2024-05-19' AS Date))
INSERT [dbo].[RequestUser] ([id], [idTho], [idNguoiDung], [idPost], [sendFrom], [dateWork]) VALUES (24, 1, 0, 2, N'NguoiDung', CAST(N'2024-05-24' AS Date))
INSERT [dbo].[RequestUser] ([id], [idTho], [idNguoiDung], [idPost], [sendFrom], [dateWork]) VALUES (25, 1, 0, 2, N'NguoiDung', CAST(N'2024-05-20' AS Date))
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_InforUser] FOREIGN KEY([idInforUser])
REFERENCES [dbo].[InforUser] ([id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_InforUser]
GO
ALTER TABLE [dbo].[busyDate]  WITH CHECK ADD  CONSTRAINT [FK_busyDate_InforUser] FOREIGN KEY([idUser])
REFERENCES [dbo].[InforUser] ([id])
GO
ALTER TABLE [dbo].[busyDate] CHECK CONSTRAINT [FK_busyDate_InforUser]
GO
ALTER TABLE [dbo].[dateWork]  WITH CHECK ADD  CONSTRAINT [FK_dateWork_busyDate] FOREIGN KEY([dateWork])
REFERENCES [dbo].[busyDate] ([id])
GO
ALTER TABLE [dbo].[dateWork] CHECK CONSTRAINT [FK_dateWork_busyDate]
GO
ALTER TABLE [dbo].[dateWork]  WITH CHECK ADD  CONSTRAINT [FK_dateWork_Evaluation] FOREIGN KEY([idEvaluation])
REFERENCES [dbo].[Evaluation] ([id])
GO
ALTER TABLE [dbo].[dateWork] CHECK CONSTRAINT [FK_dateWork_Evaluation]
GO
ALTER TABLE [dbo].[dateWork]  WITH CHECK ADD  CONSTRAINT [FK_dateWork_InforUserNguoiDung] FOREIGN KEY([idNguoiDung])
REFERENCES [dbo].[InforUser] ([id])
GO
ALTER TABLE [dbo].[dateWork] CHECK CONSTRAINT [FK_dateWork_InforUserNguoiDung]
GO
ALTER TABLE [dbo].[dateWork]  WITH CHECK ADD  CONSTRAINT [FK_dateWork_InforUserTho] FOREIGN KEY([idTho])
REFERENCES [dbo].[InforUser] ([id])
GO
ALTER TABLE [dbo].[dateWork] CHECK CONSTRAINT [FK_dateWork_InforUserTho]
GO
ALTER TABLE [dbo].[Evaluation]  WITH CHECK ADD  CONSTRAINT [FK_Evaluation_InforUserNguoiDung] FOREIGN KEY([idNguoiDung])
REFERENCES [dbo].[InforUser] ([id])
GO
ALTER TABLE [dbo].[Evaluation] CHECK CONSTRAINT [FK_Evaluation_InforUserNguoiDung]
GO
ALTER TABLE [dbo].[Evaluation]  WITH CHECK ADD  CONSTRAINT [FK_Evaluation_InforUserTho] FOREIGN KEY([idTho])
REFERENCES [dbo].[InforUser] ([id])
GO
ALTER TABLE [dbo].[Evaluation] CHECK CONSTRAINT [FK_Evaluation_InforUserTho]
GO
ALTER TABLE [dbo].[Favourite]  WITH CHECK ADD  CONSTRAINT [FK_Favourite_InforPostTho] FOREIGN KEY([idBaiViet])
REFERENCES [dbo].[InforPostTho] ([id])
GO
ALTER TABLE [dbo].[Favourite] CHECK CONSTRAINT [FK_Favourite_InforPostTho]
GO
ALTER TABLE [dbo].[Favourite]  WITH CHECK ADD  CONSTRAINT [FK_Favourite_InforUserNguoiDung] FOREIGN KEY([idNguoiDung])
REFERENCES [dbo].[InforUser] ([id])
GO
ALTER TABLE [dbo].[Favourite] CHECK CONSTRAINT [FK_Favourite_InforUserNguoiDung]
GO
ALTER TABLE [dbo].[InforPostNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_InforPostNguoiDung_InforUser] FOREIGN KEY([idNguoiDung])
REFERENCES [dbo].[InforUser] ([id])
GO
ALTER TABLE [dbo].[InforPostNguoiDung] CHECK CONSTRAINT [FK_InforPostNguoiDung_InforUser]
GO
ALTER TABLE [dbo].[InforPostNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_InforPostNguoiDung_Posts] FOREIGN KEY([idPosts])
REFERENCES [dbo].[Posts] ([id])
GO
ALTER TABLE [dbo].[InforPostNguoiDung] CHECK CONSTRAINT [FK_InforPostNguoiDung_Posts]
GO
ALTER TABLE [dbo].[InforPostTho]  WITH CHECK ADD  CONSTRAINT [FK_InforPostTho_InforUser] FOREIGN KEY([idTho])
REFERENCES [dbo].[InforUser] ([id])
GO
ALTER TABLE [dbo].[InforPostTho] CHECK CONSTRAINT [FK_InforPostTho_InforUser]
GO
ALTER TABLE [dbo].[InforPostTho]  WITH CHECK ADD  CONSTRAINT [FK_InforPostTho_Posts] FOREIGN KEY([idPosts])
REFERENCES [dbo].[Posts] ([id])
GO
ALTER TABLE [dbo].[InforPostTho] CHECK CONSTRAINT [FK_InforPostTho_Posts]
GO
ALTER TABLE [dbo].[RequestUser]  WITH CHECK ADD  CONSTRAINT [FK_RequestUser_InforUserNguoiDung] FOREIGN KEY([idNguoiDung])
REFERENCES [dbo].[InforUser] ([id])
GO
ALTER TABLE [dbo].[RequestUser] CHECK CONSTRAINT [FK_RequestUser_InforUserNguoiDung]
GO
ALTER TABLE [dbo].[RequestUser]  WITH CHECK ADD  CONSTRAINT [FK_RequestUser_InforUserTho] FOREIGN KEY([idTho])
REFERENCES [dbo].[InforUser] ([id])
GO
ALTER TABLE [dbo].[RequestUser] CHECK CONSTRAINT [FK_RequestUser_InforUserTho]
GO
ALTER TABLE [dbo].[RequestUser]  WITH CHECK ADD  CONSTRAINT [FK_RequestUser_Posts] FOREIGN KEY([idPost])
REFERENCES [dbo].[Posts] ([id])
GO
ALTER TABLE [dbo].[RequestUser] CHECK CONSTRAINT [FK_RequestUser_Posts]
GO
USE [master]
GO
ALTER DATABASE [QLyViecLam] SET  READ_WRITE 
GO
