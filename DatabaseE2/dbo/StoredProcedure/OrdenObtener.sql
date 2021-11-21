CREATE PROCEDURE [dbo].[OrdenObtener]
	@IdOrden int=NULL
AS BEGIN
SET NOCOUNT ON
	SELECT
		O.IdProducto,
		O.CantidadProducto,
		O.Estado,
		P.NombreProducto
	FROM [dbo].[Orden] O
	INNER JOIN [dbo].[Producto] P
	ON O.IdProducto = P.IdProducto
	WHERE
		(@IdOrden IS NULL OR IdOrden=@IdOrden)
END
GO