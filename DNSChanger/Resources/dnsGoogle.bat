@echo off
netsh interface ip add dns name="Bezdr�tov� p�ipojen� k s�ti" addr=8.8.8.8 index=1
netsh interface ip add dns name="Bezdr�tov� p�ipojen� k s�ti" addr=8.8.4.4 index=2
netsh interface ip add dns name="P�ipojen� k m�stn� s�ti" addr=8.8.8.8 index=1
netsh interface ip add dns name="P�ipojen� k m�stn� s�ti" addr=8.8.4.4 index=2