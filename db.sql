USE [master]
GO
/****** Object:  Database [PRN212]    Script Date: 28/10/2024 5:41:59 CH ******/
CREATE DATABASE [PRN212]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRN212', FILENAME = N'E:\SQL\MSSQL15.MSSQLSERVER1\MSSQL\DATA\PRN212.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRN212_log', FILENAME = N'E:\SQL\MSSQL15.MSSQLSERVER1\MSSQL\DATA\PRN212_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PRN212] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN212].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN212] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN212] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN212] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN212] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN212] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN212] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRN212] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN212] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN212] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN212] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN212] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN212] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN212] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN212] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN212] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PRN212] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN212] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN212] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN212] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN212] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN212] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN212] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN212] SET RECOVERY FULL 
GO
ALTER DATABASE [PRN212] SET  MULTI_USER 
GO
ALTER DATABASE [PRN212] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN212] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN212] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN212] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRN212] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRN212] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PRN212', N'ON'
GO
ALTER DATABASE [PRN212] SET QUERY_STORE = OFF
GO
USE [PRN212]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 28/10/2024 5:41:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[TripId] [int] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 28/10/2024 5:41:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trip]    Script Date: 28/10/2024 5:41:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trip](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[pickUpLocationId] [int] NULL,
	[dropOffLocationId] [int] NULL,
	[MaxPerson] [int] NULL,
	[MinPerson] [int] NULL,
	[BookingDate] [date] NULL,
	[HourInDay] [time](7) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 28/10/2024 5:41:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[PhoneNumber] [nvarchar](255) NULL,
	[Password] [nvarchar](255) NULL,
	[DateOfBirth] [date] NULL,
	[CreatedAt] [datetime] NULL,
	[Role] [nvarchar](255) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([Id], [Name], [Status]) VALUES (1, N'Toa S5.01 - Vinhome', 1)
INSERT [dbo].[Location] ([Id], [Name], [Status]) VALUES (2, N'Toa S2.02 - Vinhome', 1)
INSERT [dbo].[Location] ([Id], [Name], [Status]) VALUES (3, N'Toa S6.01 - Vinhome', 1)
INSERT [dbo].[Location] ([Id], [Name], [Status]) VALUES (4, N'Toa S8.01 - Vinhome', 1)
INSERT [dbo].[Location] ([Id], [Name], [Status]) VALUES (5, N'Toa S10.01 - Vinhome', 1)
INSERT [dbo].[Location] ([Id], [Name], [Status]) VALUES (6, N'Cong Chinh - ÐH FPT', 3)
INSERT [dbo].[Location] ([Id], [Name], [Status]) VALUES (7, N'Cong Phu - ÐH FPT', 3)
INSERT [dbo].[Location] ([Id], [Name], [Status]) VALUES (8, N'Cong vao nha van hoa - NHVSV', 2)
INSERT [dbo].[Location] ([Id], [Name], [Status]) VALUES (9, N'Cong nha van hoa - NHVSV', 2)
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
SET IDENTITY_INSERT [dbo].[Trip] ON 

INSERT [dbo].[Trip] ([Id], [pickUpLocationId], [dropOffLocationId], [MaxPerson], [MinPerson], [BookingDate], [HourInDay], [Status]) VALUES (1, 1, 6, 4, 2, CAST(N'2024-11-15' AS Date), CAST(N'14:00:00' AS Time), 1)
INSERT [dbo].[Trip] ([Id], [pickUpLocationId], [dropOffLocationId], [MaxPerson], [MinPerson], [BookingDate], [HourInDay], [Status]) VALUES (2, 1, 6, 4, 2, CAST(N'2024-10-17' AS Date), CAST(N'14:00:00' AS Time), 1)
INSERT [dbo].[Trip] ([Id], [pickUpLocationId], [dropOffLocationId], [MaxPerson], [MinPerson], [BookingDate], [HourInDay], [Status]) VALUES (3, 7, 2, 4, 2, CAST(N'2024-10-17' AS Date), CAST(N'08:00:00' AS Time), 1)
INSERT [dbo].[Trip] ([Id], [pickUpLocationId], [dropOffLocationId], [MaxPerson], [MinPerson], [BookingDate], [HourInDay], [Status]) VALUES (4, 3, 8, 1, 1, CAST(N'2024-10-18' AS Date), CAST(N'09:00:00' AS Time), 1)
INSERT [dbo].[Trip] ([Id], [pickUpLocationId], [dropOffLocationId], [MaxPerson], [MinPerson], [BookingDate], [HourInDay], [Status]) VALUES (5, 8, 1, 4, 3, CAST(N'2024-09-24' AS Date), CAST(N'09:00:00' AS Time), 1)
INSERT [dbo].[Trip] ([Id], [pickUpLocationId], [dropOffLocationId], [MaxPerson], [MinPerson], [BookingDate], [HourInDay], [Status]) VALUES (6, 8, 2, 4, 2, CAST(N'2024-09-24' AS Date), CAST(N'08:00:00' AS Time), 1)
INSERT [dbo].[Trip] ([Id], [pickUpLocationId], [dropOffLocationId], [MaxPerson], [MinPerson], [BookingDate], [HourInDay], [Status]) VALUES (7, 4, 8, 3, 2, CAST(N'2024-06-15' AS Date), CAST(N'06:30:00' AS Time), 1)
INSERT [dbo].[Trip] ([Id], [pickUpLocationId], [dropOffLocationId], [MaxPerson], [MinPerson], [BookingDate], [HourInDay], [Status]) VALUES (8, 4, 9, 4, 2, CAST(N'2024-10-15' AS Date), CAST(N'06:30:00' AS Time), 1)
SET IDENTITY_INSERT [dbo].[Trip] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Email], [PhoneNumber], [Password], [DateOfBirth], [CreatedAt], [Role], [Status]) VALUES (1, N'Nguyen Van Phuc', N'nguyenvanphuc@gmail.com', N'0868355460', N'Phucnv38', CAST(N'2004-03-08' AS Date), CAST(N'1894-07-01T00:00:00.000' AS DateTime), N'admin', 1)
INSERT [dbo].[User] ([Id], [Name], [Email], [PhoneNumber], [Password], [DateOfBirth], [CreatedAt], [Role], [Status]) VALUES (2, N'Tran Thi Dung', N'tranthidung@gmail.com', N'0912345679', N'Dungtt239', CAST(N'2004-08-25' AS Date), CAST(N'1894-07-01T00:00:00.000' AS DateTime), N'staff', 1)
INSERT [dbo].[User] ([Id], [Name], [Email], [PhoneNumber], [Password], [DateOfBirth], [CreatedAt], [Role], [Status]) VALUES (3, N'Le Van Cuong', N'levancuong@gmail.com', N'0912345680', N'Cuonglv220', CAST(N'2002-02-20' AS Date), CAST(N'1894-07-01T00:00:00.000' AS DateTime), N'user', 1)
INSERT [dbo].[User] ([Id], [Name], [Email], [PhoneNumber], [Password], [DateOfBirth], [CreatedAt], [Role], [Status]) VALUES (4, N'Pham Thi Hoa', N'phamthihoa@gmail.com', N'0912345681', N'Hoapt1214', CAST(N'2003-12-14' AS Date), CAST(N'1894-07-01T00:00:00.000' AS DateTime), N'user', 1)
INSERT [dbo].[User] ([Id], [Name], [Email], [PhoneNumber], [Password], [DateOfBirth], [CreatedAt], [Role], [Status]) VALUES (5, N'Hoang Minh Tri', N'hoangminhtri@gmail.com', N'0912345682', N'Trihm79', CAST(N'2004-07-09' AS Date), CAST(N'1894-07-01T00:00:00.000' AS DateTime), N'user', 1)
INSERT [dbo].[User] ([Id], [Name], [Email], [PhoneNumber], [Password], [DateOfBirth], [CreatedAt], [Role], [Status]) VALUES (6, N'Vu Hong Phuc', N'vuhongphuc@gmail.com', N'0912345683', N'Phucvh330', CAST(N'2003-03-30' AS Date), CAST(N'1894-07-01T00:00:00.000' AS DateTime), N'user', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([TripId])
REFERENCES [dbo].[Trip] ([Id])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD  CONSTRAINT [FK_Trip_dropOffLocation] FOREIGN KEY([dropOffLocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Trip] CHECK CONSTRAINT [FK_Trip_dropOffLocation]
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD  CONSTRAINT [FK_Trip_pickUpLocation] FOREIGN KEY([pickUpLocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Trip] CHECK CONSTRAINT [FK_Trip_pickUpLocation]
GO
USE [master]
GO
ALTER DATABASE [PRN212] SET  READ_WRITE 
GO
