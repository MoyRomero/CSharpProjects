IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230522220303_Inicial')
BEGIN
    CREATE TABLE [Actores] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(120) NOT NULL,
        [FechaNacimiento] datetime2 NOT NULL,
        [Foto] nvarchar(max) NULL,
        CONSTRAINT [PK_Actores] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230522220303_Inicial')
BEGIN
    CREATE TABLE [Generos] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(40) NOT NULL,
        CONSTRAINT [PK_Generos] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230522220303_Inicial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230522220303_Inicial', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230523005100_Peliculas')
BEGIN
    CREATE TABLE [Peliculas] (
        [Id] int NOT NULL IDENTITY,
        [Titulo] nvarchar(200) NOT NULL,
        [EnCines] bit NOT NULL,
        [FechaEstreno] datetime2 NOT NULL,
        [Poster] nvarchar(max) NULL,
        CONSTRAINT [PK_Peliculas] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230523005100_Peliculas')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230523005100_Peliculas', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230523231321_PeliculasActores_PeliculasGeneros')
BEGIN
    CREATE TABLE [PeliculasActores] (
        [ActorId] int NOT NULL,
        [PeliculaId] int NOT NULL,
        [Personaje] nvarchar(max) NULL,
        [Orden] int NOT NULL,
        CONSTRAINT [PK_PeliculasActores] PRIMARY KEY ([ActorId], [PeliculaId]),
        CONSTRAINT [FK_PeliculasActores_Actores_ActorId] FOREIGN KEY ([ActorId]) REFERENCES [Actores] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_PeliculasActores_Peliculas_PeliculaId] FOREIGN KEY ([PeliculaId]) REFERENCES [Peliculas] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230523231321_PeliculasActores_PeliculasGeneros')
BEGIN
    CREATE TABLE [PeliculasGeneros] (
        [PeliculaId] int NOT NULL,
        [GeneroId] int NOT NULL,
        [Id] int NOT NULL,
        CONSTRAINT [PK_PeliculasGeneros] PRIMARY KEY ([GeneroId], [PeliculaId]),
        CONSTRAINT [FK_PeliculasGeneros_Generos_GeneroId] FOREIGN KEY ([GeneroId]) REFERENCES [Generos] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_PeliculasGeneros_Peliculas_PeliculaId] FOREIGN KEY ([PeliculaId]) REFERENCES [Peliculas] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230523231321_PeliculasActores_PeliculasGeneros')
BEGIN
    CREATE INDEX [IX_PeliculasActores_PeliculaId] ON [PeliculasActores] ([PeliculaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230523231321_PeliculasActores_PeliculasGeneros')
BEGIN
    CREATE INDEX [IX_PeliculasGeneros_PeliculaId] ON [PeliculasGeneros] ([PeliculaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230523231321_PeliculasActores_PeliculasGeneros')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230523231321_PeliculasActores_PeliculasGeneros', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526233312_TablasSalasDeCine')
BEGIN
    CREATE TABLE [SalasDeCine] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(120) NOT NULL,
        CONSTRAINT [PK_SalasDeCine] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526233312_TablasSalasDeCine')
BEGIN
    CREATE TABLE [PeliculasSalasDeCines] (
        [PeliculaId] int NOT NULL,
        [SalaDeCineId] int NOT NULL,
        CONSTRAINT [PK_PeliculasSalasDeCines] PRIMARY KEY ([PeliculaId], [SalaDeCineId]),
        CONSTRAINT [FK_PeliculasSalasDeCines_Peliculas_PeliculaId] FOREIGN KEY ([PeliculaId]) REFERENCES [Peliculas] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_PeliculasSalasDeCines_SalasDeCine_SalaDeCineId] FOREIGN KEY ([SalaDeCineId]) REFERENCES [SalasDeCine] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526233312_TablasSalasDeCine')
BEGIN
    CREATE INDEX [IX_PeliculasSalasDeCines_SalaDeCineId] ON [PeliculasSalasDeCines] ([SalaDeCineId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230526233312_TablasSalasDeCine')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230526233312_TablasSalasDeCine', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230527200116_SalaDeCineUbicacion')
BEGIN
    ALTER TABLE [SalasDeCine] ADD [Ubicacion] geography NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230527200116_SalaDeCineUbicacion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230527200116_SalaDeCineUbicacion', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530000343_SistemaUsuarios')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230530000343_SistemaUsuarios', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530001011_AdminUser')
BEGIN
    BEGIN TRANSACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530001011_AdminUser')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N'5efebc3e-7ecb-487d-bc59-2a2b72a7095e', NULL, N'Admin', N'Admin');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530001011_AdminUser')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES (N'ad59c5be-4cfb-4302-8cc2-9f416a7e61e2', 0, N'c067d7bc-9140-4b3f-b1b7-267ed50e8929', N'moyromero.1695@gmail.com', CAST(0 AS bit), CAST(0 AS bit), NULL, N'moyromero.1695@gmail.com', N'moyromero.1695@gmail.com', N'AQAAAAIAAYagAAAAEPly5l9G0AjoLKJirjecryQ8WXePBnQJxtPaL2BddPwKrTVNwpYTW5diDStvEh/H4w==', NULL, CAST(0 AS bit), N'6f3c2202-56c1-4852-9778-3c1f0c224abe', CAST(0 AS bit), N'moyromero.1695@gmail.com');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530001011_AdminUser')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClaimType', N'ClaimValue', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserClaims]'))
        SET IDENTITY_INSERT [AspNetUserClaims] ON;
    INSERT INTO [AspNetUserClaims] ([Id], [ClaimType], [ClaimValue], [UserId])
    VALUES (1, N'http://schemas.microsoft.com/ws/2008/06/identity/claims/role', N'Admin', N'ad59c5be-4cfb-4302-8cc2-9f416a7e61e2');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ClaimType', N'ClaimValue', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserClaims]'))
        SET IDENTITY_INSERT [AspNetUserClaims] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530001011_AdminUser')
BEGIN
    COMMIT;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530001011_AdminUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230530001011_AdminUser', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530012745_Reviews')
BEGIN
    CREATE TABLE [Reviews] (
        [Id] int NOT NULL IDENTITY,
        [Comientario] nvarchar(max) NULL,
        [Puntuacion] int NOT NULL,
        [PeliculaId] int NOT NULL,
        [UsuarioId] nvarchar(450) NULL,
        CONSTRAINT [PK_Reviews] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Reviews_AspNetUsers_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Reviews_Peliculas_PeliculaId] FOREIGN KEY ([PeliculaId]) REFERENCES [Peliculas] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530012745_Reviews')
BEGIN
    CREATE INDEX [IX_Reviews_PeliculaId] ON [Reviews] ([PeliculaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530012745_Reviews')
BEGIN
    CREATE INDEX [IX_Reviews_UsuarioId] ON [Reviews] ([UsuarioId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230530012745_Reviews')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230530012745_Reviews', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602011724_MigracionInicialAzure')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230602011724_MigracionInicialAzure', N'7.0.5');
END;
GO

COMMIT;
GO

