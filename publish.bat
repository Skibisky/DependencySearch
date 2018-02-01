@echo off
nuget.exe setApiKey <KEY>
nuget.exe push %1 -Source https://nuget.org
pause