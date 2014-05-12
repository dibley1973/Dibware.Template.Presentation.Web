----------------------------------
-- DW: 11/04/2011
-- This script will build a class file with 
-- private fields and public properties from
-- the table specified in the @TableName variable.
----------------------------------

DECLARE @TableName varchar(50);
DECLARE @IsVisualBasic varchar(10);
DECLARE @IsCSharp varchar(10);
DECLARE @Language varchar(10);

SET @IsVisualBasic = 'Visual Basic';
SET @IsCSharp = 'C Sharp';

SET @Language = @IsCSharp; -- @IsVisualBasic;
SET @TableName = 'Membership';

IF @Language = @IsVisualBasic
	BEGIN
		PRINT ''' ---  ' + @Language + ' ---'
	END
ELSE
	BEGIN
		PRINT '// ---  ' + @Language + ' ---'	
	END

SET NOCOUNT ON; -- Hide row count so printed output is not affected

DECLARE @DataTypeName varchar(50)
DECLARE @NewLine char
DECLARE @ColumnName varchar(50)
DECLARE @DataType varchar(50)
DECLARE @FieldName varchar(50)

SET @NewLine = char(13)

-- Start Output
IF @Language = @IsVisualBasic
	BEGIN
		PRINT 'Public Class ' + Replace(@TableName, 'tbl', '');
		PRINT '';
		PRINT '#Region "Declarations"';
		PRINT '';
	END
ELSE
	BEGIN
		PRINT 'public class ' + Replace(@TableName, 'tbl', '');
		PRINT '{';
		PRINT '';
		PRINT '#region "Declarations"';
		PRINT '';
	END

-- Declarations
DECLARE DeclarationCursor CURSOR SCROLL FOR 
	SELECT
		columns.name [ColumnName],
		CASE @Language
			WHEN @IsVisualBasic THEN
				CASE 
					WHEN columns.system_type_id = 34    THEN 'Byte[]'
					WHEN columns.system_type_id = 35    THEN 'String'
					WHEN columns.system_type_id = 36    THEN 'System.Guid'
					WHEN columns.system_type_id = 48    THEN 'Byte'
					WHEN columns.system_type_id = 52    THEN 'Short'
					WHEN columns.system_type_id = 56    THEN 'Integer'
					WHEN columns.system_type_id = 58    THEN 'System.DateTime'
					WHEN columns.system_type_id = 59    THEN 'float'
					WHEN columns.system_type_id = 60    THEN 'Decimal'
					WHEN columns.system_type_id = 61    THEN 'System.DateTime'
					WHEN columns.system_type_id = 62    THEN 'double'
					WHEN columns.system_type_id = 98    THEN 'Object'
					WHEN columns.system_type_id = 99    THEN 'String'
					WHEN columns.system_type_id = 104   THEN 'Boolean'
					WHEN columns.system_type_id = 106   THEN 'Decimal'
					WHEN columns.system_type_id = 108   THEN 'Decimal'
					WHEN columns.system_type_id = 122   THEN 'Decimal'
					WHEN columns.system_type_id = 127   THEN 'long'
					WHEN columns.system_type_id = 165   THEN 'Byte[]'
					WHEN columns.system_type_id = 167   THEN 'String'
					WHEN columns.system_type_id = 173   THEN 'Byte[]'
					WHEN columns.system_type_id = 175   THEN 'string'
					WHEN columns.system_type_id = 189   THEN 'Long'
					WHEN columns.system_type_id = 231   THEN 'String'
					WHEN columns.system_type_id = 239   THEN 'String'
					WHEN columns.system_type_id = 241   THEN 'String'
					WHEN columns.system_type_id = 241   THEN 'String'
				END --[DataType]
			ELSE
				CASE 
					WHEN columns.system_type_id = 34    THEN 'Byte[]'
					WHEN columns.system_type_id = 35    THEN 'String'
					WHEN columns.system_type_id = 36    THEN 'System.Guid'
					WHEN columns.system_type_id = 48    THEN 'Byte'
					WHEN columns.system_type_id = 52    THEN 'Int16'
					WHEN columns.system_type_id = 56    THEN 'Int32'
					WHEN columns.system_type_id = 58    THEN 'System.DateTime'
					WHEN columns.system_type_id = 59    THEN 'Single'
					WHEN columns.system_type_id = 60    THEN 'Decimal'
					WHEN columns.system_type_id = 61    THEN 'System.DateTime'
					WHEN columns.system_type_id = 62    THEN 'Double'
					WHEN columns.system_type_id = 98    THEN 'Object'
					WHEN columns.system_type_id = 99    THEN 'String'
					WHEN columns.system_type_id = 104   THEN 'Boolean'
					WHEN columns.system_type_id = 106   THEN 'Decimal'
					WHEN columns.system_type_id = 108   THEN 'Decimal'
					WHEN columns.system_type_id = 122   THEN 'Decimal'
					WHEN columns.system_type_id = 127   THEN 'Int64'
					WHEN columns.system_type_id = 165   THEN 'Byte[]'
					WHEN columns.system_type_id = 167   THEN 'String'
					WHEN columns.system_type_id = 173   THEN 'Byte[]'
					WHEN columns.system_type_id = 175   THEN 'String'
					WHEN columns.system_type_id = 189   THEN 'Int64'
					WHEN columns.system_type_id = 231   THEN 'String'
					WHEN columns.system_type_id = 239   THEN 'String'
					WHEN columns.system_type_id = 241   THEN 'String'
					WHEN columns.system_type_id = 241   THEN 'String'
				END --[DataType]
	END [DataType]

FROM              sys.tables tables
    INNER JOIN    sys.schemas schemas ON (tables.schema_id = schemas.schema_id )
    INNER JOIN    sys.columns columns ON (columns.object_id = tables.object_id) 
WHERE
	tables.name = @TableName
ORDER BY 
	columns.object_id ASC;


OPEN DeclarationCursor;

FETCH NEXT FROM DeclarationCursor 
INTO @ColumnName, @DataType;

WHILE @@FETCH_STATUS = 0
BEGIN
	SET @FieldName = '_' + LOWER(SUBSTRING(@ColumnName, 1,1)) + SUBSTRING(@ColumnName, 2, LEN(@ColumnName)-1)

IF @Language = @IsVisualBasic
	BEGIN
		 PRINT '    Private ' + @FieldName + ' As ' + @DataType;
	END
--ELSE
--	BEGIN
--		PRINT '    private ' + @DataType + ' '+ @FieldName + ';' ;
--	END

	FETCH NEXT FROM DeclarationCursor 
	INTO @ColumnName, @DataType;
END

IF @Language = @IsVisualBasic
	BEGIN
		PRINT ''; 
		PRINT '#End Region';
		PRINT ''; 
		PRINT '#Region "Properties"';
		PRINT '';
	END
ELSE
	BEGIN
		PRINT ''; 
		PRINT '#endregion';
		PRINT ''; 
		PRINT '#region "Properties"';
		PRINT '';
	END

FETCH FIRST FROM DeclarationCursor 
INTO @ColumnName, @DataType;

WHILE @@FETCH_STATUS = 0
BEGIN
	SET @FieldName = '_' + LOWER(SUBSTRING(@ColumnName, 1,1)) + SUBSTRING(@ColumnName, 2, LEN(@ColumnName)-1)

	IF @Language = @IsVisualBasic
		BEGIN
			PRINT '    Public Property ' + @ColumnName + ' As ' + @DataType;
			PRINT '        Get';
			PRINT '            Return ' + @FieldName;
			PRINT '        End Get';
			PRINT '        Set';
			PRINT '            ' + @FieldName + ' = value';
			PRINT '        End Set';
			PRINT '    End Property';
			PRINT ''; 
		END
	ELSE
		BEGIN
			PRINT '    public ' + @DataType + ' ' + @ColumnName + ' { get; set; }';
			PRINT ''; 
		END

	FETCH NEXT FROM DeclarationCursor 
	INTO @ColumnName, @DataType;
END

IF @Language = @IsVisualBasic
	BEGIN
		PRINT ''; 
		PRINT '#End Region';
		PRINT ''; 
	END
ELSE
	BEGIN
		PRINT ''; 
		PRINT '#endregion';
		PRINT ''; 
	END

DECLARE @FIELDS varchar(max)
SET @FIELDS = ''

FETCH FIRST FROM DeclarationCursor 
INTO @ColumnName, @DataType;

WHILE @@FETCH_STATUS = 0
BEGIN
	SET @FieldName = LOWER(SUBSTRING(@ColumnName, 1,1)) + SUBSTRING(@ColumnName, 2, LEN(@ColumnName)-1)
	IF @Language = @IsVisualBasic
		BEGIN
			SET @FIELDS = @FIELDS + 'byval ' + @FieldName + ' as ' + @DataType + ', '
		END
	ELSE
		BEGIN
			SET @FIELDS = @FIELDS + @DataType + ' ' + @FieldName + ', '
		END
	FETCH NEXT FROM DeclarationCursor 
	INTO @ColumnName, @DataType;
END

SET @FIELDS = SUBSTRING(@FIELDS, 1, (LEN(@FIELDS) - 1))

IF @Language = @IsVisualBasic
	BEGIN
		PRINT '#Region "Constructors"';
		PRINT '';
		PRINT '    '''''' <summary>'
		PRINT '    '''''' Initializes a new instance of the <see cref="' + @TableName + '"/> class.'
		PRINT '    '''''' </summary>'
		PRINT '    Public Sub New()';
		PRINT '        MyBase.New()';
		PRINT '    End Sub';
		PRINT '';
		PRINT '    '''''' <summary>'
		PRINT '    '''''' Initializes a new instance of the <see cref="' + @TableName + '"/> class.'
		PRINT '    '''''' </summary>'
		PRINT '    Public Sub New(' + @FIELDS + ')'
		PRINT '        Me.New()';
	END
ELSE
	BEGIN
		PRINT '#region "Constructors"';
		PRINT '';
		
		PRINT '    /// <summary>'
		PRINT '    /// Initializes a new instance of the <see cref="' + @TableName + '"/> class.'
		PRINT '    /// </summary>'
		PRINT '    public ' + @TableName + '() : base()';
		PRINT '    {';
		PRINT '        ';
		PRINT '    }';
		PRINT '';
		PRINT '    /// <summary>'
		PRINT '    /// Initializes a new instance of the <see cref="' + @TableName + '"/> class.'
		PRINT '    /// </summary>'
		PRINT '    public ' + @TableName + '(' + @FIELDS + ') : this()'
		PRINT '    {';
	END

-- Now add Assignments
FETCH FIRST FROM DeclarationCursor 
INTO @ColumnName, @DataType;

WHILE @@FETCH_STATUS = 0
BEGIN

	SET @FieldName = LOWER(SUBSTRING(@ColumnName, 1,1)) + SUBSTRING(@ColumnName, 2, LEN(@ColumnName)-1)
	IF @Language = @IsVisualBasic
		BEGIN
			PRINT '        Me._' + @FieldName + ' = ' + @FieldName;
		END
	ELSE
		BEGIN
			PRINT '        this._' + @FieldName + ' = ' + @FieldName + ';';
		END

	FETCH NEXT FROM DeclarationCursor 
	INTO @ColumnName, @DataType;
END

IF @Language = @IsVisualBasic
	BEGIN
		PRINT '    End Sub';
		PRINT '';
		PRINT '#End Region';
		PRINT ''; 
	END
ELSE
	BEGIN
		PRINT '    }';
		PRINT '';
		PRINT '#endregion';
		PRINT ''; 
	END

CLOSE DeclarationCursor;
DEALLOCATE DeclarationCursor;

-- End of class
IF @Language = @IsVisualBasic
	BEGIN
		PRINT 'End Class';
	END
ELSE
	BEGIN
		PRINT '}';
	END