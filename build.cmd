call npm i
call node build 
IF %ERRORLEVEL% NEQ 0 (
  exit /b %errorlevel%
)
