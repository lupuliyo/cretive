@echo off
cd /d %~dp0

:: Establece el remoto correcto por si acaso
git remote set-url master https://github.com/lupuliyo/cretive

:: Añade todos los cambios
git add .

:: Realiza el commit
git commit -m "Auto commit desde Windows"

:: Intenta hacer push a main primero, si falla, intenta master
git push origin main || git push origin master

pause
