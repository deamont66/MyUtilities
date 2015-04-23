@echo off
sc interrogate uxsms | find "1062"
if %errorlevel%==0 goto :sc_start
sc stop uxsms
exit

:sc_start
sc start uxsms
exit