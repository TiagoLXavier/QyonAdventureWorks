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

CREATE TABLE [PistaCorridas] (
    [Id] int NOT NULL IDENTITY,
    [Descricao] varchar(50) NOT NULL,
    CONSTRAINT [PK_PistaCorridas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [HistoricoCorridas] (
    [Id] int NOT NULL IDENTITY,
    [CompetidorId] int NOT NULL,
    [PistaCorridaId] int NOT NULL,
    [DataCorrida] datetime2 NOT NULL,
    [TempoGasto] decimal NOT NULL,
    CONSTRAINT [PK_HistoricoCorridas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HistoricoCorridas_PistaCorridas_PistaCorridaId] FOREIGN KEY ([PistaCorridaId]) REFERENCES [PistaCorridas] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Competidores] (
    [Id] int NOT NULL IDENTITY,
    [HistoricoCorridaId] int NOT NULL,
    [Nome] varchar(150) NOT NULL,
    [Sexo] char(1) NOT NULL,
    [TemperturaMediaCorpo] decimal NOT NULL,
    [Peso] decimal NOT NULL,
    [Altura] decimal NOT NULL,
    CONSTRAINT [PK_Competidores] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Competidores_HistoricoCorridas_HistoricoCorridaId] FOREIGN KEY ([HistoricoCorridaId]) REFERENCES [HistoricoCorridas] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Competidores_HistoricoCorridaId] ON [Competidores] ([HistoricoCorridaId]);
GO

CREATE UNIQUE INDEX [IX_HistoricoCorridas_PistaCorridaId] ON [HistoricoCorridas] ([PistaCorridaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220316232839_MigracaoInicial', N'5.0.0');
GO

COMMIT;
GO

