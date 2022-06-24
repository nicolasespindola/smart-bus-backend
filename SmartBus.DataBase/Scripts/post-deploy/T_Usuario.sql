MERGE [dbo].[Usuario] t
USING 
(
    SELECT  *
    FROM 
    (
        VALUES
        ( 'nespindola@lightercapital.com', '$2a$11$iyx6mEJTMdAqjPoh42L5jufeH2tIcKG8UV47mdVW96Me0h4GZ6X5S', '0'),
        ( 'string', '$2a$11$DHpVOp.G5h82iZLJ8QqFlul8bcLmxYp/DGxMtvS6sxtyGAwUIpDAO', '0')

    ) i ([Email], [Contraseña], [Eliminado])
) ii ON ( ii.[Email] = t.[Email])

WHEN MATCHED THEN UPDATE SET 
    t.[Email] = ii.[Email],
    t.[Contraseña] = ii.[Contraseña],
    t.[Eliminado] = ii.[Eliminado]

WHEN NOT MATCHED BY TARGET THEN INSERT
    ([Email], [Contraseña], [Eliminado])
    VALUES 
    (ii.[Email], ii.[Contraseña], ii.[Eliminado])

WHEN NOT MATCHED BY SOURCE THEN DELETE;
