if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)) {
    Start-Process PowerShell -Verb RunAs "-NoProfile -ExecutionPolicy Bypass -Command `"cd '$pwd'; & '$PSCommandPath';`"";
    exit;
}

PNPUtil.exe /add-driver ".\rpi_code\RNDIS.inf" /install 
.\arduino_code\arduino-cli.exe core install arduino:avr 
.\arduino_code\arduino-cli.exe core install arduino:samd
