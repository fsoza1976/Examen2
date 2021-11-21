﻿CREATE TABLE [dbo].[Producto]
(
	[IdProducto] INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Producto PRIMARY KEY CLUSTERED([IdProducto]), 
    [NombreProducto] VARCHAR(250) NOT NULL, 
    [PrecioProducto] INT NOT NULL
)WITH (DATA_COMPRESSION = PAGE)
GO
