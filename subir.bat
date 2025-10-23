@echo off
cd /d %~dp0

:: Establece el remoto correcto por si acaso
git remote add origin https://github.com/lupuliyo/cretive.git


:: Añade todos los cambios
git add .

:: Realiza el commit
git commit -m "Auto commit desde Windows"

:: Intenta hacer push a main primero, si falla, intenta master
git push -u origin main || git push -u origin master

pause
