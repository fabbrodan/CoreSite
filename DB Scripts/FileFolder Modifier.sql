CREATE TABLE [Folders] (
FolderId int not null identity(0,1),
FolderName nvarchar(50) not null);

ALTER TABLE [Folders]
ADD CONSTRAINT [PK_Folder]
PRIMARY KEY CLUSTERED (FolderId);

ALTER TABLE [Files]
DROP COLUMN FolderName;

ALTER TABLE [Files]
ADD [FolderId] int not null;

ALTER TABLE [Files]
ADD CONSTRAINT [FK1_Files]
FOREIGN KEY ([FolderId])
REFERENCES [Folders] ([FolderId]);