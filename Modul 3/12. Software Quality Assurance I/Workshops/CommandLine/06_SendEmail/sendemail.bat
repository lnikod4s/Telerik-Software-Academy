set SERVER=127.0.0.1:1099
set USER=workshopcommandline@gmail.com
set /p PW=<password.txt
set FROMNAME=workshopcommandline@gmail.com
set TO=""
set SUBJECT="Command Line WorkShop"
set BODY="Send from the command line. Download zip file containing all materials for the workshop here {URL}"
blat -server %SERVER% -f %FROMNAME% -u %USER% -pw %PW% -to %TO% -subject %SUBJECT% -body %BODY%
