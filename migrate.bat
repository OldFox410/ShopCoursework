@echo off
chcp 65001 > nul
"Shop.Migrator/bin/Debug/net8.0/Shop.Migrator.exe" ./Migrations ./
pause