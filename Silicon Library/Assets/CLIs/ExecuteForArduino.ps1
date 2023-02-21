Set-Variable -Name ArduinoStatus "FALSE"
Get-CimInstance -ClassName Win32_PnPEntity | Where-Object {$_.Name -like "Arduino*(COM*)*"} | ForEach-Object name | select-string \d+ | ForEach-Object { $_.matches.value }| Set-Variable -Name "ArduinoPortNo"
if($ArduinoPortNo){Set-Variable -Name ArduinoStatus "TRUE"}
.\arduino_code\arduino-cli.exe upload ".\arduino_code\arduino-code.ino" -b arduino:avr:uno -p COM$ArduinoPortNo --input-dir ".\arduino_code" 
.\arduino_code\arduino-cli.exe monitor -p COM$ArduinoPortNo | Out-File -FilePath .\TerminalLog.json 