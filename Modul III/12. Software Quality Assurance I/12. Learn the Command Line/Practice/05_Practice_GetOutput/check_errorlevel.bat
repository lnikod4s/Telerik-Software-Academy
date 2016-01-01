@echo off
findstr "Parameter" output.txt | findstr "2"
if %ERRORLEVEL% EQU 0 echo "Hello"
else echo "Bye"