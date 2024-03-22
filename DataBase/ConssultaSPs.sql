--SELECT
--    o.name AS NombreProcedimiento,
--    o.type_desc AS Tipo,
--    m.definition AS Definicion
--FROM
--    sys.sql_modules AS m
--JOIN
--    sys.objects AS o ON m.object_id = o.object_id
--WHERE
--    o.type = 'P'
--ORDER BY
--    CHARINDEX('--Tabla:', m.definition), o.name;

CREATE PROCEDURE ActualizarMontoTotalFondo
AS
BEGIN
    DECLARE @Total DECIMAL(10, 2);
    SELECT @Total = SUM(MontoPagar) FROM Pago;
    UPDATE FONDO SET MontoTotal = @Total;
END;
GO

--public void ActualizarMontoTotalFondo()
--{
--    using (var connection = new SqlConnection(connectionString))
--    {
--        connection.Open();
--        var command = new SqlCommand("ActualizarMontoTotalFondo", connection);
--        command.CommandType = CommandType.StoredProcedure;
--        command.ExecuteNonQuery();
--    }
--}


-- Consulta de prueba para insertar un nuevo registro en la tabla Pago
INSERT INTO Pago (IdAlumno, IdEncargado, MontoPagar, Multa, TotalPagado, FechaRegistro, IdAdministrador, IdMes)
VALUES (1, 1, 100.00, 0.00, 100.00, '2024-03-08', 1, 3);

-- Verificar el contenido de la tabla FONDO después de la inserción
SELECT * FROM FONDO;



--DROP TRIGGER ActualizarMontoTotalTrigger;
--GO

--CREATE TRIGGER ActualizarMontoTotalTrigger
--ON Pago
--AFTER INSERT
--AS
--BEGIN
--    EXEC ActualizarMontoTotalFondo;
--END;
--GO
