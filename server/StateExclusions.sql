
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/23/2022 06:49:28
-- Generated from EDMX file: C:\Users\lu_sk\source\repos\AngularDemoDatabase\AngularDemoDatabase\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StateExclusions];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StateExcl_State'
CREATE TABLE [dbo].[StateExcl_State] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StateName] nvarchar(max)  NOT NULL,
    [StateAbbreviation] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StateExcl_StateExclusion'
CREATE TABLE [dbo].[StateExcl_StateExclusion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StateExcl_StateId] int  NOT NULL,
    [StateExcl_ExclusionId] int  NOT NULL
);
GO

-- Creating table 'StateExcl_Exclusion'
CREATE TABLE [dbo].[StateExcl_Exclusion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ExclusionName] nvarchar(max)  NOT NULL,
    [ExclusionDescription] nvarchar(max)  NULL
);
GO

-- Creating table 'StateExcl_ExclusionDate'
CREATE TABLE [dbo].[StateExcl_ExclusionDate] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ExclusionDate] datetime  NOT NULL,
    [StateExcl_ExclusionId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'StateExcl_State'
ALTER TABLE [dbo].[StateExcl_State]
ADD CONSTRAINT [PK_StateExcl_State]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StateExcl_StateExclusion'
ALTER TABLE [dbo].[StateExcl_StateExclusion]
ADD CONSTRAINT [PK_StateExcl_StateExclusion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StateExcl_Exclusion'
ALTER TABLE [dbo].[StateExcl_Exclusion]
ADD CONSTRAINT [PK_StateExcl_Exclusion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StateExcl_ExclusionDate'
ALTER TABLE [dbo].[StateExcl_ExclusionDate]
ADD CONSTRAINT [PK_StateExcl_ExclusionDate]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StateExcl_StateId] in table 'StateExcl_StateExclusion'
ALTER TABLE [dbo].[StateExcl_StateExclusion]
ADD CONSTRAINT [FK_StateExcl_StateStateExcl_StateExclusion]
    FOREIGN KEY ([StateExcl_StateId])
    REFERENCES [dbo].[StateExcl_State]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StateExcl_StateStateExcl_StateExclusion'
CREATE INDEX [IX_FK_StateExcl_StateStateExcl_StateExclusion]
ON [dbo].[StateExcl_StateExclusion]
    ([StateExcl_StateId]);
GO

-- Creating foreign key on [StateExcl_ExclusionId] in table 'StateExcl_StateExclusion'
ALTER TABLE [dbo].[StateExcl_StateExclusion]
ADD CONSTRAINT [FK_StateExcl_ExclusionStateExcl_StateExclusion]
    FOREIGN KEY ([StateExcl_ExclusionId])
    REFERENCES [dbo].[StateExcl_Exclusion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StateExcl_ExclusionStateExcl_StateExclusion'
CREATE INDEX [IX_FK_StateExcl_ExclusionStateExcl_StateExclusion]
ON [dbo].[StateExcl_StateExclusion]
    ([StateExcl_ExclusionId]);
GO

-- Creating foreign key on [StateExcl_ExclusionId] in table 'StateExcl_ExclusionDate'
ALTER TABLE [dbo].[StateExcl_ExclusionDate]
ADD CONSTRAINT [FK_StateExcl_ExclusionStateExcl_ExclusionDate]
    FOREIGN KEY ([StateExcl_ExclusionId])
    REFERENCES [dbo].[StateExcl_Exclusion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StateExcl_ExclusionStateExcl_ExclusionDate'
CREATE INDEX [IX_FK_StateExcl_ExclusionStateExcl_ExclusionDate]
ON [dbo].[StateExcl_ExclusionDate]
    ([StateExcl_ExclusionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------