MERGE [dbo].[TipoDeUsuario] t
USING 
(
    SELECT  *
    FROM 
    (
        VALUES
        ('Chofer'),
        ('Tutor'),
        ('Escuela')
    ) i ([Descripcion])
) ii ON ( ii.[Descripcion] = t.[Descripcion])

WHEN MATCHED THEN UPDATE SET 
    t.[Descripcion] = ii.[Descripcion]

WHEN NOT MATCHED BY TARGET THEN INSERT
    ([Descripcion])
    VALUES 
    (ii.[Descripcion])

WHEN NOT MATCHED BY SOURCE THEN DELETE;
