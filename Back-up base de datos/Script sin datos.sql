USE [VTSystemDatabase]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Customers]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Damages]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Damages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Inspection_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Damages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flows]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flows](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EncodedSubzoneNames] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Flows] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageElements]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageElements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataInformation] [nvarchar](max) NULL,
	[ImageData] [varbinary](max) NULL,
	[Damage_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ImageElements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inspections]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inspections](
	[Id] [uniqueidentifier] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[VehicleVIN] [nvarchar](max) NULL,
	[Location_Id] [int] NULL,
	[Responsible_Id] [int] NOT NULL,
	[ProcessData_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Inspections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoggingRecords]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoggingRecords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResponsiblesUsername] [nvarchar](max) NULL,
	[ActionPerformed] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.LoggingRecords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lots]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lots](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[AssociatedTransport_Id] [int] NULL,
	[Creator_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Lots] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movements]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Arrival_Id] [int] NULL,
	[Departure_Id] [int] NULL,
	[Responsible_Id] [int] NULL,
	[ProcessData_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Movements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessDatas]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessDatas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CurrentStage] [int] NOT NULL,
	[LastDateTimeToValidate] [datetime] NULL,
	[PortLot_Id] [uniqueidentifier] NULL,
	[SaleRecord_Id] [int] NULL,
	[TransportData_Id] [int] NULL,
	[YardCurrentLocation_Id] [int] NULL,
 CONSTRAINT [PK_dbo.ProcessDatas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[Id] [int] NOT NULL,
	[VehicleVIN] [nvarchar](max) NULL,
	[SellingPrice] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Sales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subzones]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subzones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Capacity] [int] NOT NULL,
	[Container_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Subzones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transports]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDateTime] [datetime] NULL,
	[EndDateTime] [datetime] NULL,
	[Transporter_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Transports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WasRemoved] [bit] NOT NULL,
	[Role] [int] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[Id] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Brand] [nvarchar](max) NULL,
	[Model] [nvarchar](max) NULL,
	[Year] [smallint] NOT NULL,
	[Color] [nvarchar](max) NULL,
	[VIN] [nvarchar](max) NULL,
	[Subzone_Id] [int] NULL,
	[Lot_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Vehicles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zones]    Script Date: 23-Nov-17 4:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Capacity] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Zones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Damages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damages_dbo.Inspections_Inspection_Id] FOREIGN KEY([Inspection_Id])
REFERENCES [dbo].[Inspections] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Damages] CHECK CONSTRAINT [FK_dbo.Damages_dbo.Inspections_Inspection_Id]
GO
ALTER TABLE [dbo].[ImageElements]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ImageElements_dbo.Damages_Damage_Id] FOREIGN KEY([Damage_Id])
REFERENCES [dbo].[Damages] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageElements] CHECK CONSTRAINT [FK_dbo.ImageElements_dbo.Damages_Damage_Id]
GO
ALTER TABLE [dbo].[Inspections]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Inspections_dbo.Locations_Location_Id] FOREIGN KEY([Location_Id])
REFERENCES [dbo].[Locations] ([Id])
GO
ALTER TABLE [dbo].[Inspections] CHECK CONSTRAINT [FK_dbo.Inspections_dbo.Locations_Location_Id]
GO
ALTER TABLE [dbo].[Inspections]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Inspections_dbo.ProcessDatas_ProcessData_Id] FOREIGN KEY([ProcessData_Id])
REFERENCES [dbo].[ProcessDatas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inspections] CHECK CONSTRAINT [FK_dbo.Inspections_dbo.ProcessDatas_ProcessData_Id]
GO
ALTER TABLE [dbo].[Inspections]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Inspections_dbo.Users_Responsible_Id] FOREIGN KEY([Responsible_Id])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inspections] CHECK CONSTRAINT [FK_dbo.Inspections_dbo.Users_Responsible_Id]
GO
ALTER TABLE [dbo].[Lots]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Lots_dbo.Transports_AssociatedTransport_Id] FOREIGN KEY([AssociatedTransport_Id])
REFERENCES [dbo].[Transports] ([Id])
GO
ALTER TABLE [dbo].[Lots] CHECK CONSTRAINT [FK_dbo.Lots_dbo.Transports_AssociatedTransport_Id]
GO
ALTER TABLE [dbo].[Lots]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Lots_dbo.Users_Creator_Id] FOREIGN KEY([Creator_Id])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lots] CHECK CONSTRAINT [FK_dbo.Lots_dbo.Users_Creator_Id]
GO
ALTER TABLE [dbo].[Movements]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Movements_dbo.ProcessDatas_ProcessData_Id] FOREIGN KEY([ProcessData_Id])
REFERENCES [dbo].[ProcessDatas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movements] CHECK CONSTRAINT [FK_dbo.Movements_dbo.ProcessDatas_ProcessData_Id]
GO
ALTER TABLE [dbo].[Movements]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Movements_dbo.Subzones_Arrival_Id] FOREIGN KEY([Arrival_Id])
REFERENCES [dbo].[Subzones] ([Id])
GO
ALTER TABLE [dbo].[Movements] CHECK CONSTRAINT [FK_dbo.Movements_dbo.Subzones_Arrival_Id]
GO
ALTER TABLE [dbo].[Movements]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Movements_dbo.Subzones_Departure_Id] FOREIGN KEY([Departure_Id])
REFERENCES [dbo].[Subzones] ([Id])
GO
ALTER TABLE [dbo].[Movements] CHECK CONSTRAINT [FK_dbo.Movements_dbo.Subzones_Departure_Id]
GO
ALTER TABLE [dbo].[Movements]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Movements_dbo.Users_Responsible_Id] FOREIGN KEY([Responsible_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Movements] CHECK CONSTRAINT [FK_dbo.Movements_dbo.Users_Responsible_Id]
GO
ALTER TABLE [dbo].[ProcessDatas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProcessDatas_dbo.Lots_PortLot_Id] FOREIGN KEY([PortLot_Id])
REFERENCES [dbo].[Lots] ([Id])
GO
ALTER TABLE [dbo].[ProcessDatas] CHECK CONSTRAINT [FK_dbo.ProcessDatas_dbo.Lots_PortLot_Id]
GO
ALTER TABLE [dbo].[ProcessDatas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProcessDatas_dbo.Sales_SaleRecord_Id] FOREIGN KEY([SaleRecord_Id])
REFERENCES [dbo].[Sales] ([Id])
GO
ALTER TABLE [dbo].[ProcessDatas] CHECK CONSTRAINT [FK_dbo.ProcessDatas_dbo.Sales_SaleRecord_Id]
GO
ALTER TABLE [dbo].[ProcessDatas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProcessDatas_dbo.Subzones_YardCurrentLocation_Id] FOREIGN KEY([YardCurrentLocation_Id])
REFERENCES [dbo].[Subzones] ([Id])
GO
ALTER TABLE [dbo].[ProcessDatas] CHECK CONSTRAINT [FK_dbo.ProcessDatas_dbo.Subzones_YardCurrentLocation_Id]
GO
ALTER TABLE [dbo].[ProcessDatas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProcessDatas_dbo.Transports_TransportData_Id] FOREIGN KEY([TransportData_Id])
REFERENCES [dbo].[Transports] ([Id])
GO
ALTER TABLE [dbo].[ProcessDatas] CHECK CONSTRAINT [FK_dbo.ProcessDatas_dbo.Transports_TransportData_Id]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Sales_dbo.Customers_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_dbo.Sales_dbo.Customers_Id]
GO
ALTER TABLE [dbo].[Subzones]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Subzones_dbo.Zones_Container_Id] FOREIGN KEY([Container_Id])
REFERENCES [dbo].[Zones] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subzones] CHECK CONSTRAINT [FK_dbo.Subzones_dbo.Zones_Container_Id]
GO
ALTER TABLE [dbo].[Transports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Transports_dbo.Users_Transporter_Id] FOREIGN KEY([Transporter_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Transports] CHECK CONSTRAINT [FK_dbo.Transports_dbo.Users_Transporter_Id]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Vehicles_dbo.Lots_Lot_Id] FOREIGN KEY([Lot_Id])
REFERENCES [dbo].[Lots] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_dbo.Vehicles_dbo.Lots_Lot_Id]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Vehicles_dbo.ProcessDatas_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[ProcessDatas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_dbo.Vehicles_dbo.ProcessDatas_Id]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Vehicles_dbo.Subzones_Subzone_Id] FOREIGN KEY([Subzone_Id])
REFERENCES [dbo].[Subzones] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_dbo.Vehicles_dbo.Subzones_Subzone_Id]
GO
