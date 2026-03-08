@echo off
REM ============================================================================
REM DefaultDocumentation - Documentation Generation Script
REM ============================================================================
REM
REM This script generates markdown documentation for ErrorOrResult
REM using DefaultDocumentation.Console (dotnet tool)
REM
REM Prerequisites:
REM   - .NET SDK installed
REM   - DefaultDocumentation.Console tool installed globally
REM
REM To install the tool:
REM   dotnet tool install DefaultDocumentation.Console -g
REM
REM ============================================================================

echo.
echo ============================================================================
echo DefaultDocumentation - Documentation Generation
echo ============================================================================
echo.

REM Check if the tool is installed
where defaultdocumentation >nul 2>nul
if %ERRORLEVEL% NEQ 0 (
    echo [ERROR] DefaultDocumentation.Console is not installed!
    echo.
    echo To install it, run:
    echo   dotnet tool install DefaultDocumentation.Console -g
    echo.
    echo Alternatively, update an existing installation:
    echo   dotnet tool update DefaultDocumentation.Console -g
    echo.
    pause
    exit /b 1
)

REM Set paths
set PROJECT_DIR=%~dp0
set SRC_DIR=%PROJECT_DIR%src\ErrorOrResult
set BIN_DIR=%SRC_DIR%\bin\Release\net10.0
set ASSEMBLY_PATH=%BIN_DIR%\ErrorOrResult.dll
set XML_PATH=%BIN_DIR%\ErrorOrResult.xml
set OUTPUT_DIR=%PROJECT_DIR%docs\api-generated
set CONFIG_FILE=%PROJECT_DIR%DefaultDocumentation.json

echo [INFO] Project directory: %PROJECT_DIR%
echo [INFO] Source directory: %SRC_DIR%
echo [INFO] Assembly path: %ASSEMBLY_PATH%
echo [INFO] XML documentation: %XML_PATH%
echo [INFO] Output directory: %OUTPUT_DIR%
echo.

REM Check if assembly exists
if not exist "%ASSEMBLY_PATH%" (
    echo [WARNING] Assembly not found. Building project...
    echo.
    dotnet build "%SRC_DIR%\ErrorOrResult.csproj" --configuration Release
    if %ERRORLEVEL% NEQ 0 (
        echo [ERROR] Build failed!
        pause
        exit /b 1
    )
    echo.
)

REM Check if XML documentation exists
if not exist "%XML_PATH%" (
    echo [ERROR] XML documentation file not found: %XML_PATH%
    echo.
    echo Make sure GenerateDocumentationFile is set to true in your .csproj:
    echo   ^<GenerateDocumentationFile^>true^</GenerateDocumentationFile^>
    echo.
    pause
    exit /b 1
)

REM Create output directory if it doesn't exist
if not exist "%OUTPUT_DIR%" (
    echo [INFO] Creating output directory: %OUTPUT_DIR%
    mkdir "%OUTPUT_DIR%"
)

REM Generate documentation
echo [INFO] Generating documentation...
echo.

REM Check if configuration file exists
if exist "%CONFIG_FILE%" (
    echo [INFO] Using configuration file: %CONFIG_FILE%
    defaultdocumentation ^
        --ConfigurationFilePath "%CONFIG_FILE%" ^
        --AssemblyFilePath "%ASSEMBLY_PATH%" ^
        --DocumentationFilePath "%XML_PATH%" ^
        --OutputDirectoryPath "%OUTPUT_DIR%" ^
        --ProjectDirectoryPath "%SRC_DIR%" ^
        --LogLevel Information
) else (
    echo [INFO] No configuration file found. Using default settings.
    defaultdocumentation ^
        --AssemblyFilePath "%ASSEMBLY_PATH%" ^
        --DocumentationFilePath "%XML_PATH%" ^
        --OutputDirectoryPath "%OUTPUT_DIR%" ^
        --ProjectDirectoryPath "%SRC_DIR%" ^
        --AssemblyPageName index ^
        --GeneratedPages "Namespaces,Types,Members" ^
        --GeneratedAccessModifiers Api ^
        --LogLevel Information
)

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ============================================================================
    echo [SUCCESS] Documentation generated successfully!
    echo ============================================================================
    echo.
    echo Documentation location: %OUTPUT_DIR%
    echo.
) else (
    echo.
    echo ============================================================================
    echo [ERROR] Documentation generation failed!
    echo ============================================================================
    echo.
    echo Error level: %ERRORLEVEL%
    echo.
    echo Common issues:
    echo   1. DefaultDocumentation.Console not installed or outdated
    echo   2. Assembly or XML file not found
    echo   3. Invalid configuration file
    echo   4. .NET 10 compatibility issues
    echo.
    pause
    exit /b 1
)

pause