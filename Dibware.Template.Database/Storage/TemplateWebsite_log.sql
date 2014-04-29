ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [TemplateWebsite_log], FILENAME = 'F:\Databases\TemplateWebsite_log.ldf', SIZE = 1024 KB, MAXSIZE = 2097152 MB, FILEGROWTH = 10 %);

