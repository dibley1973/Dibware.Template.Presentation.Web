ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [TemplateWebsite], FILENAME = 'F:\Databases\TemplateWebsite.mdf', SIZE = 4096 KB, FILEGROWTH = 1024 KB) TO FILEGROUP [PRIMARY];

