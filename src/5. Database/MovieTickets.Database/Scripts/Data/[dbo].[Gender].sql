SET NOCOUNT ON

SET IDENTITY_INSERT [dbo].[Gender] ON

DECLARE @mergeOutput TABLE ( [DMLAction] VARCHAR(6) );
MERGE INTO [dbo].[Gender] WITH (SERIALIZABLE) AS [Target]
USING (VALUES
  (1,'Comedia')
 ,(2,'Drama')
 ,(3,'Acción')
 ,(4,'Thriller')
 ,(5,'Aventura')
 ,(6,'Documental')
 ,(7,'Infantil')
 ,(8,'Animación')
 ,(9,'Ciencia Ficción')
 ,(10,'Terror')
 ,(11,'Musical')
 ,(12,'Eventos')
) AS [Source] ([Id],[Name])
ON ([Target].[Id] = [Source].[Id])
WHEN MATCHED AND EXISTS (SELECT [Source].[Name]
                 EXCEPT  SELECT [Target].[Name]) THEN
 UPDATE SET
  [Target].[Name] = [Source].[Name]
WHEN NOT MATCHED BY TARGET THEN
 INSERT([Id],[Name])
 VALUES([Source].[Id],[Source].[Name])
WHEN NOT MATCHED BY SOURCE THEN 
 DELETE
OUTPUT $action INTO @mergeOutput;

DECLARE @mergeError INT = @@ERROR, @mergeCount INT = (SELECT COUNT(1) FROM @mergeOutput), @mergeCountIns INT = (SELECT COUNT(1) FROM @mergeOutput WHERE [DMLAction] = 'INSERT'), @mergeCountUpd INT = (SELECT COUNT(1) FROM @mergeOutput WHERE [DMLAction] = 'UPDATE'), @mergeCountDel INT = (SELECT COUNT(1) FROM @mergeOutput WHERE [DMLAction] = 'DELETE');
IF @mergeError <> 0 PRINT 'ERROR OCCURRED IN MERGE FOR [dbo].[Gender]' + CONCAT(' (SQL Server error code: ', @mergeError) + ')';
PRINT CONCAT('[dbo].[Gender] rows affected by MERGE: ', @mergeCount) + CONCAT(' (Inserted: ', @mergeCountIns) + CONCAT('; Updated: ', @mergeCountUpd) + CONCAT('; Deleted: ', @mergeCountDel) + ')';
GO

SET IDENTITY_INSERT [dbo].[Gender] OFF
SET NOCOUNT OFF
GO
