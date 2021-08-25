setx  PATH=%PATH%;%CD%/obs_test.exe
echo %PATH%
timeout 10
start obs_test.exe
timeout 10
runemacs.exe