USE MASTER
GO

/*
Ref:
    http://www.msbiguide.com/2012/11/how-to-raise-custom-errors-in-sql-server-using-raiserror/c
    http://technet.microsoft.com/en-us/library/ms178649.aspx

SQL SERVER languages
╔════════╦═════════════════════╗
║ LANGID ║        ALIAS        ║
╠════════╬═════════════════════╣
║      0 ║ English             ║
║      1 ║ German              ║
║      2 ║ French              ║
║      3 ║ Japanese            ║
║      4 ║ Danish              ║
║      5 ║ Spanish             ║
║      6 ║ Italian             ║
║      7 ║ Dutch               ║
║      8 ║ Norwegian           ║
║      9 ║ Portuguese          ║
║     10 ║ Finnish             ║
║     11 ║ Swedish             ║
║     12 ║ Czech               ║
║     13 ║ Hungarian           ║
║     14 ║ Polish              ║
║     15 ║ Romanian            ║
║     16 ║ Croatian            ║
║     17 ║ Slovak              ║
║     18 ║ Slovenian           ║
║     19 ║ Greek               ║
║     20 ║ Bulgarian           ║
║     21 ║ Russian             ║
║     22 ║ Turkish             ║
║     23 ║ British English     ║
║     24 ║ Estonian            ║
║     25 ║ Latvian             ║
║     26 ║ Lithuanian          ║
║     27 ║ Brazilian           ║
║     28 ║ Traditional Chinese ║
║     29 ║ Korean              ║
║     30 ║ Simplified Chinese  ║
║     31 ║ Arabic              ║
║     32 ║ Thai                ║
║     33 ║ Bokmål              ║
╚════════╩═════════════════════╝
*/

-- Username already exists in the system
IF EXISTS (SELECT 1 FROM sys.messages WHERE message_id = 50001) BEGIN
    EXEC    sp_dropmessage @msgnum = 50001, @lang = 'all'
END
EXEC    sp_addmessage
    @msgnum = 50001,
    @severity = 16, 
    @msgtext = N'Username %s already exists in the system. Please choose another username. ', 
    @lang = 'us_english';
EXEC    sp_addmessage 
    @msgnum = 50001, 
    @severity = 16, 
    @msgtext = N'Nom d''utilisateur %s existe déjà dans le système. S''il vous plaît choisir un autre nom d''utilisateur. ', 
    @lang = 'French';
EXEC    sp_addmessage 
    @msgnum = 50001, 
    @severity = 16, 
    @msgtext = N'Nombre de usuario %s ya existe en el sistema. Por favor, elija otro nombre de usuario. ', 
    @lang = 'Spanish';


-- Email address already exists in system
IF EXISTS (SELECT 1 FROM sys.messages WHERE message_id = 50002) BEGIN
    EXEC    sp_dropmessage @msgnum = 50002, @lang = 'all'
END
EXEC    sp_addmessage 
    @msgnum = 50002, 
    @severity =16, 
    @msgtext = 'Email address %s already exists in the system. Please choose another email address. ', 
    @lang = 'us_english'
EXEC    sp_addmessage 
    @msgnum = 50002, 
    @severity =16, 
    @msgtext = 'Adresse e-mail %s existe déjà dans le système. S''il vous plaît choisir une autre adresse e-mail. ', 
    @lang = 'French'
EXEC    sp_addmessage 
    @msgnum = 50002, 
    @severity =16, 
    @msgtext = 'Dirección de correo electrónico %s ya existe en el sistema. Por favor elija otra dirección de correo electrónico. ', 
    @lang = 'Spanish'



-- Membership is already confirmed in system
IF EXISTS (SELECT 1 FROM sys.messages WHERE message_id = 50003) BEGIN
    EXEC    sp_dropmessage @msgnum = 50003, @lang = 'all'
END
EXEC    sp_addmessage 
    @msgnum = 50003, 
    @severity =16, 
    @msgtext = 'Membership has already been confirmed. ', 
    @lang = 'us_english'
