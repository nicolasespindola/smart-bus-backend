MERGE [dbo].[Usuario] t
USING 
(
    SELECT  *
    FROM 
    (
        VALUES
        ( 'Nicolas', 'Espindola', 'nespindola@lightercapital.com', '$2a$11$iyx6mEJTMdAqjPoh42L5jufeH2tIcKG8UV47mdVW96Me0h4GZ6X5S', 1, '0'),
        ( 'stringo', 'stringer', 'stringo@gmail,com', '$2a$11$DHpVOp.G5h82iZLJ8QqFlul8bcLmxYp/DGxMtvS6sxtyGAwUIpDAO', 1, '0')

    ) i ([Nombre], [Apellido], [Email], [Contraseña], [IdTipoDeUsuario], [Eliminado])
) ii ON ( ii.[Email] = t.[Email])

WHEN MATCHED THEN UPDATE SET
    t.[Nombre] = ii.[Nombre],
    t.[Apellido] = ii.[Apellido],
    t.[Email] = ii.[Email],
    t.[Contraseña] = ii.[Contraseña],
    t.[IdTipoDeUsuario] = ii.[IdTipoDeUsuario],
    t.[Eliminado] = ii.[Eliminado]

WHEN NOT MATCHED BY TARGET THEN INSERT
    ([Nombre], [Apellido], [Email], [Contraseña], [IdTipoDeUsuario], [Eliminado])
    VALUES 
    (ii.[Nombre], ii.[Apellido], ii.[Email], ii.[Contraseña], [IdTipoDeUsuario], ii.[Eliminado])

WHEN NOT MATCHED BY SOURCE THEN DELETE;
