@echo off
REM MicroX - Run Script
REM ---------------------
REM This script builds and runs the MicroX.API project

cd /d %~dp0

echo.
echo =====================================
echo Building and Running MicroX.API
echo =====================================
echo.

dotnet run --project .\src\MicroX.API

pause
