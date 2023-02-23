function Get-ScriptDirectory { Split-Path $MyInvocation.ScriptName }
$cli = Join-Path (Get-ScriptDirectory) '\rpi_code\plink.exe'
$sh = Join-Path (Get-ScriptDirectory) '\rpi_code\pitest.sh'
& $cli -ssh pitest@pitest.local -pw pitest -m $sh

