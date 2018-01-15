CREATE TABLE [dbo].[Accounts] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [Name]     NCHAR (10) NULL,
    [Password] NCHAR (10) NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED ([Id] ASC)
);

