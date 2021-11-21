DROP TABLE IF EXISTS #OrdenTemp

SELECT 
IdOrden, IdProducto, CantidadProducto  INTO #OrdenTemp
FROM (
VALUES
(1,1,3),(2,2,2),(3,3,8),(4,4,3)
)AS TEMP (IdOrden, IdProducto, CantidadProducto )


----ACTUALIZAR DATOS---
UPDATE P SET
  P.IdProducto= TM.IdProducto,
  P.CantidadProducto= TM.CantidadProducto
FROM Dbo.Orden P
INNER JOIN #OrdenTemp TM
    ON P.IdOrden= TM.IdOrden


----INSERTAR DATOS---

SET IDENTITY_INSERT dbo.Orden ON

INSERT INTO dbo.Orden(
IdOrden, IdProducto,CantidadProducto )
SELECT
IdOrden, IdProducto,CantidadProducto
FROM #OrdenTemp


EXCEPT
SELECT
IdOrden, IdProducto,CantidadProducto
FROM dbo.Orden


SET IDENTITY_INSERT dbo.Orden OFF

GO