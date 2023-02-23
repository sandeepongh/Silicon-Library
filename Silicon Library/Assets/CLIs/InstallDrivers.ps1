if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)) {
    Start-Process PowerShell -Verb RunAs "-NoProfile -ExecutionPolicy Bypass -Command `"cd '$pwd'; & '$PSCommandPath';`"";
    exit;
}

function Get-ScriptDirectory { Split-Path $MyInvocation.ScriptName }
$arduinodir = Join-Path (Get-ScriptDirectory) '\arduino_code\arduino-cli.exe'
$raspberry = Join-Path (Get-ScriptDirectory) '\rpi_code\RNDIS.inf"'

Write-Output "Installing Drivers"
Write-Output "------------------"
PNPUtil.exe /add-driver $raspberry /install 
& $arduinodir core install arduino:avr 
