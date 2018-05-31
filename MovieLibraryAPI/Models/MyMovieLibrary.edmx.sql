
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/31/2018 15:53:21
-- Generated from EDMX file: C:\Users\Spodesta\Documents\Projects\MovieLibraryAPI\MovieLibraryAPI\Models\MyMovieLibrary.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyMovieLibrary];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Rel_User___IdMov__114A936A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rel_User_Movie] DROP CONSTRAINT [FK__Rel_User___IdMov__114A936A];
GO
IF OBJECT_ID(N'[dbo].[FK__Rel_User___IdUse__10566F31]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rel_User_Movie] DROP CONSTRAINT [FK__Rel_User___IdUse__10566F31];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Movies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movies];
GO
IF OBJECT_ID(N'[dbo].[Rel_User_Movie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rel_User_Movie];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Email] varchar(255)  NOT NULL,
    [Password] varchar(255)  NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [Last_name] varchar(255)  NOT NULL,
    [IdCountry] int  NOT NULL
);
GO

-- Creating table 'Movies'
CREATE TABLE [dbo].[Movies] (
    [Id] int  NOT NULL,
    [Title] varchar(255)  NOT NULL,
    [ImagePath] varchar(255)  NULL
);
GO

-- Creating table 'Rel_User_Movie'
CREATE TABLE [dbo].[Rel_User_Movie] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdUser] int  NOT NULL,
    [IdMovie] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [PK_Movies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rel_User_Movie'
ALTER TABLE [dbo].[Rel_User_Movie]
ADD CONSTRAINT [PK_Rel_User_Movie]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdMovie] in table 'Rel_User_Movie'
ALTER TABLE [dbo].[Rel_User_Movie]
ADD CONSTRAINT [FK__Rel_User___IdMov__114A936A]
    FOREIGN KEY ([IdMovie])
    REFERENCES [dbo].[Movies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Rel_User___IdMov__114A936A'
CREATE INDEX [IX_FK__Rel_User___IdMov__114A936A]
ON [dbo].[Rel_User_Movie]
    ([IdMovie]);
GO

-- Creating foreign key on [IdUser] in table 'Rel_User_Movie'
ALTER TABLE [dbo].[Rel_User_Movie]
ADD CONSTRAINT [FK__Rel_User___IdUse__10566F31]
    FOREIGN KEY ([IdUser])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Rel_User___IdUse__10566F31'
CREATE INDEX [IX_FK__Rel_User___IdUse__10566F31]
ON [dbo].[Rel_User_Movie]
    ([IdUser]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------