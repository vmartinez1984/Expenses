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

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Period] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [DateStart] datetime2 NOT NULL,
    [DateStop] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Period] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Entry] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Amount] int NOT NULL,
    [DateRegister] datetime2 NOT NULL,
    [PeriodId] int NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Entry] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Entry_Period_PeriodId] FOREIGN KEY ([PeriodId]) REFERENCES [Period] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Expense] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Amount] int NOT NULL,
    [CategoryId] int NOT NULL,
    [PeriodId] int NOT NULL,
    [DateRegister] datetime2 NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Expense] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Expense_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Expense_Period_PeriodId] FOREIGN KEY ([PeriodId]) REFERENCES [Period] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Entry_PeriodId] ON [Entry] ([PeriodId]);
GO

CREATE INDEX [IX_Expense_CategoryId] ON [Expense] ([CategoryId]);
GO

CREATE INDEX [IX_Expense_PeriodId] ON [Expense] ([PeriodId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220308013029_v1', N'5.0.14');
GO

COMMIT;
GO

