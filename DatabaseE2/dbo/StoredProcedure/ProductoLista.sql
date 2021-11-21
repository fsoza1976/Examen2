CREATE PROCEDURE [dbo].[ProductoLista]
	
AS 

BEGIN

	SET NOCOUNT ON

	SELECT  IdProducto
			,NombreProducto
	FROM [dbo].[Producto]
	
END
