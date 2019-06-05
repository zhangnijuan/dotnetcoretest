IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [UserInfo] (
    [Id] int NOT NULL IDENTITY,
    [IsDelete] bit NOT NULL,
    [CreateTime] datetime2 NOT NULL,
    [UserName] NVARCHAR NOT NULL,
    [PassWord] NVARCHAR NOT NULL,
    [Name] NVARCHAR NOT NULL,
    [Phone] VARCHAR NOT NULL,
    CONSTRAINT [PK_UserInfo] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190528025221_test', N'2.2.4-servicing-10062');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInfo]') AND [c].[name] = N'CreateTime');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [UserInfo] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [UserInfo] ALTER COLUMN [CreateTime] datetime NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190528025702_test1', N'2.2.4-servicing-10062');

GO

