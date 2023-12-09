SET NOCOUNT ON

SET IDENTITY_INSERT [dbo].[Movie] ON

DECLARE @mergeOutput TABLE ( [DMLAction] VARCHAR(6) );
MERGE INTO [dbo].[Movie] WITH (SERIALIZABLE) AS [Target]
USING (VALUES
  (1,'Napoleón')
 ,(2,'La Sociedad De La Nieve')
 ,(3,'Venganza Silenciosa')
 ,(4,'Wonka')
 ,(5,'Viernes Negro')
 ,(6,'El Duelo')
 ,(7,'Los Juegos Del Hambre La Balada De Pájaro')
 ,(8,'The Marvels')
 ,(9,'Saw X: El Juego Del Miedo')
 ,(10,'Five Nights At Freddy´s')
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
IF @mergeError <> 0 PRINT 'ERROR OCCURRED IN MERGE FOR [dbo].[Movie]' + CONCAT(' (SQL Server error code: ', @mergeError) + ')';
PRINT CONCAT('[dbo].[Movie] rows affected by MERGE: ', @mergeCount) + CONCAT(' (Inserted: ', @mergeCountIns) + CONCAT('; Updated: ', @mergeCountUpd) + CONCAT('; Deleted: ', @mergeCountDel) + ')';
GO



SET IDENTITY_INSERT [dbo].[Movie] OFF
SET NOCOUNT OFF
GO