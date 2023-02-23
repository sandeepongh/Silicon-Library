function Get-ScriptDirectory { Split-Path $MyInvocation.ScriptName }
$cli = Join-Path (Get-ScriptDirectory) '\arduino_code\arduino-cli.exe'
$sh = Join-Path (Get-ScriptDirectory) '\arduino_code\arduino-code.ino'
$shdir = Join-Path (Get-ScriptDirectory) '\arduino_code'
Set-Variable -Name ArduinoStatus "FALSE"
Get-CimInstance -ClassName Win32_PnPEntity | Where-Object {$_.Name -like "Arduino*(COM*)*"} | ForEach-Object name | select-string \d+ | ForEach-Object { $_.matches.value }| Set-Variable -Name "ArduinoPortNo"
if($ArduinoPortNo){Set-Variable -Name ArduinoStatus "TRUE"}
& $cli upload "$sh" -b arduino:avr:uno -p COM$ArduinoPortNo --input-dir $shdir 
& $cli monitor -p COM$ArduinoPortNo -l serial