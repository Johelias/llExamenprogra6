DROP TABLE IF EXISTS #ProductoTemp

SELECT 
IdProducto, NombreProducto, PrecioProducto INTO #ProductoTemp
FROM (
VALUES
(1, 'LAPIZ', 300),
(2, 'BORRADOR', 125),
(3, 'COLORES', 1050),
(4, 'LAPICERO', 250)

)AS TEMP (IdProducto, NombreProducto, PrecioProducto)


----ACTUALIZAR DATOS---
UPDATE P SET
  P.NombreProducto= TM.NombreProducto,
  P.PrecioProducto= TM.PrecioProducto
FROM Dbo.Producto P
INNER JOIN #ProductoTemp TM
    ON P.IdProducto= TM.IdProducto


----INSERTAR DATOS---

SET IDENTITY_INSERT dbo.Producto ON

INSERT INTO dbo.Producto(
IdProducto, NombreProducto,PrecioProducto)
SELECT
IdProducto, NombreProducto, PrecioProducto
FROM #ProductoTemp


EXCEPT
SELECT
IdProducto, NombreProducto, PrecioProducto
FROM dbo.Producto


SET IDENTITY_INSERT dbo.Producto OFF

GO