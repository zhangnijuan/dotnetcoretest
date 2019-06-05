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

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInfo]') AND [c].[name] = N'UserName');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [UserInfo] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [UserInfo] ALTER COLUMN [UserName] nvarchar NOT NULL;

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInfo]') AND [c].[name] = N'Phone');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [UserInfo] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [UserInfo] ALTER COLUMN [Phone] varchar NOT NULL;

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInfo]') AND [c].[name] = N'PassWord');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [UserInfo] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [UserInfo] ALTER COLUMN [PassWord] nvarchar NOT NULL;

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInfo]') AND [c].[name] = N'Name');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [UserInfo] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [UserInfo] ALTER COLUMN [Name] nvarchar NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190528030850_test2', N'2.2.4-servicing-10062');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190528031608_test3', N'2.2.4-servicing-10062');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190528031908_test4', N'2.2.4-servicing-10062');

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInfo]') AND [c].[name] = N'UserName');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [UserInfo] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [UserInfo] ALTER COLUMN [UserName] nvarchar(24) NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190528032120_test5', N'2.2.4-servicing-10062');

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInfo]') AND [c].[name] = N'Phone');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [UserInfo] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [UserInfo] ALTER COLUMN [Phone] nvarchar(16) NOT NULL;

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInfo]') AND [c].[name] = N'PassWord');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [UserInfo] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [UserInfo] ALTER COLUMN [PassWord] nvarchar(24) NOT NULL;

GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInfo]') AND [c].[name] = N'Name');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [UserInfo] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [UserInfo] ALTER COLUMN [Name] nvarchar(8) NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190528032239_test6', N'2.2.4-servicing-10062');

GO

CREATE TABLE [Role] (
    [Id] int NOT NULL IDENTITY,
    [IsDelete] bit NOT NULL,
    [CreateTime] datetime2 NOT NULL,
    [RoleName] nvarchar(16) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [UserRole] (
    [UserId] int NOT NULL,
    [RoleId] int NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRole_UserInfo_UserId] FOREIGN KEY ([UserId]) REFERENCES [UserInfo] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_UserRole_RoleId] ON [UserRole] ([RoleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190604011536_test7', N'2.2.4-servicing-10062');

GO

