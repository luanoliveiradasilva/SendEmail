@echo off
cd %cd%
dotnet test --collect "Xplat Code Coverage"
timeout /t 5
dir
cd %cd%\TestResults
set dirTestResult=%cd%
echo %dirTestResult%
dir
set /p diretorio=informe o nome do diretorio:
cd %dirTestResult%\%diretorio%
dir
set diretorioCompleto=%dirTestResult%\%diretorio%
dir
echo %diretorioCompleto%
reportgenerator "-reports:"%diretorioCompleto%"\coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html
timeout /t 5
dir
cd %cd%\coveragereport
index.html