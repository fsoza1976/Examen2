CREATE PROCEDURE [dbo].[OrdenObtener]
	@IdOrden int=NULL
AS BEGIN
SET NOCOUNT ON
	SELECT
		O.IdOrden,
		O.IdProducto,
		O.CantidadProducto,
		O.Estado,

		P.NombreProducto
	FROM [dbo].[Orden] O
	LEFT JOIN [dbo].[Producto] P
	ON O.IdProducto = P.IdProducto
	WHERE
		(@IdOrden IS NULL OR IdOrden=@IdOrden)
END
GO