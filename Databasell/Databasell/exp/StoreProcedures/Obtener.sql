CREATE PROCEDURE [dbo].[Obtener]
	  @IdProducto int= NULL
AS BEGIN
  SET NOCOUNT ON

  SELECT 
     E.IdProducto,
     E.NombreProducto,
     E.PrecioProducto
         
    FROM dbo.Producto E
    WHERE
    (@IdProducto IS NULL OR IdProducto=@IdProducto)

END