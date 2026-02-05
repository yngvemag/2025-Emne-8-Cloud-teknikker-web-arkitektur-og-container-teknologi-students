# Windows Command Line Tools Cheat Sheet

This document provides a comprehensive overview of essential Windows command line tools for administrative tasks, with descriptions and examples for each.

## Table of Contents

- [Command Prompt vs PowerShell](#command-prompt-vs-powershell)
- [System Management](#system-management)
- [User and Group Management](#user-and-group-management)
- [File System Management](#file-system-management)
- [Network Management](#network-management)
- [Services and Processes](#services-and-processes)
- [Disk and Storage Management](#disk-and-storage-management)
- [Security and Permissions](#security-and-permissions)
- [Scheduled Tasks](#scheduled-tasks)
- [Windows Updates](#windows-updates)
- [Remote Management](#remote-management)
- [System Information](#system-information)
- [Common Administrative Tasks](#common-administrative-tasks)
- [PowerShell Scripting Basics](#powershell-scripting-basics)
- [Troubleshooting](#troubleshooting)
- [Best Practices](#best-practices)

<div style="page-break-after: always;"></div>

## Command Prompt vs PowerShell
_Understanding the two main command-line interfaces in Windows._

### Command Prompt (cmd.exe)

```cmd
# Launch Command Prompt
cmd

# Launch Command Prompt as administrator
runas /user:Administrator cmd.exe

# Run Command Prompt with specific options
cmd /c command   # Run command and terminate
cmd /k command   # Run command and keep window open
cmd /q           # Turn off echo
```

### PowerShell

```powershell
# Launch PowerShell
powershell

# Launch PowerShell as administrator
Start-Process powershell -Verb RunAs

# Check PowerShell version
$PSVersionTable

# Set execution policy
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
```

<div style="page-break-after: always;"></div>

## System Management

### System Information

```powershell
# System information (Command Prompt)
systeminfo

# System information (PowerShell)
Get-ComputerInfo

# OS information 
Get-CimInstance Win32_OperatingSystem | Select-Object Caption, Version, OSArchitecture

# Hardware information
Get-CimInstance Win32_ComputerSystem
```

### System Control

```powershell
# Restart computer
shutdown /r /t 0  # Command Prompt
Restart-Computer   # PowerShell

# Shutdown computer
shutdown /s /t 0   # Command Prompt
Stop-Computer      # PowerShell

# Log off current user
shutdown /l        # Command Prompt
logoff             # Command Prompt
```

### Date and Time

```powershell
# Display current date and time
date /t & time /t  # Command Prompt
Get-Date           # PowerShell

# Change system date
date 06-03-25      # Command Prompt
Set-Date "2025-06-03"  # PowerShell

# Set time zone
tzutil /s "Pacific Standard Time"  # Command Prompt
Set-TimeZone -Id "Pacific Standard Time"  # PowerShell
```

<div style="page-break-after: always;"></div>

## User and Group Management

### User Accounts

```powershell
# List all users
net user                      # Command Prompt
Get-LocalUser                 # PowerShell

# Create a new user
net user username password /add  # Command Prompt
New-LocalUser -Name "username" -Password (ConvertTo-SecureString "password" -AsPlainText -Force)  # PowerShell

# Delete a user
net user username /delete     # Command Prompt
Remove-LocalUser -Name "username"  # PowerShell

# Change user password
net user username newpassword  # Command Prompt
$Password = ConvertTo-SecureString "newpassword" -AsPlainText -Force
Set-LocalUser -Name "username" -Password $Password  # PowerShell
```

### User Groups

```powershell
# List all groups
net localgroup               # Command Prompt
Get-LocalGroup               # PowerShell

# Create a new group
net localgroup groupname /add  # Command Prompt
New-LocalGroup -Name "groupname"  # PowerShell

# Delete a group
net localgroup groupname /delete  # Command Prompt
Remove-LocalGroup -Name "groupname"  # PowerShell

# Add user to a group
net localgroup groupname username /add  # Command Prompt
Add-LocalGroupMember -Group "groupname" -Member "username"  # PowerShell

# Remove user from a group
net localgroup groupname username /delete  # Command Prompt
Remove-LocalGroupMember -Group "groupname" -Member "username"  # PowerShell
```

<div style="page-break-after: always;"></div>

## File System Management

### File Operations

```powershell
# List files and directories
dir                           # Command Prompt
Get-ChildItem                 # PowerShell (alias: ls, dir)

# Create a directory
mkdir directory_name          # Command Prompt
New-Item -ItemType Directory -Name "directory_name"  # PowerShell

# Copy files
copy source destination       # Command Prompt
Copy-Item -Path "source" -Destination "destination"  # PowerShell

# Move/rename files
move source destination       # Command Prompt
Move-Item -Path "source" -Destination "destination"  # PowerShell

# Delete files
del filename                  # Command Prompt
Remove-Item -Path "filename"  # PowerShell

# Delete directory and contents
rmdir /s /q directory_name    # Command Prompt
Remove-Item -Path "directory_name" -Recurse  # PowerShell
```

### File Attributes and Permissions

```powershell
# Display file attributes
attrib filename               # Command Prompt
Get-ItemProperty -Path "filename"  # PowerShell

# Make file read-only
attrib +r filename            # Command Prompt
Set-ItemProperty -Path "filename" -Name IsReadOnly -Value $true  # PowerShell

# Remove read-only attribute
attrib -r filename            # Command Prompt
Set-ItemProperty -Path "filename" -Name IsReadOnly -Value $false  # PowerShell

# Take ownership of a file
takeown /f filename           # Command Prompt
$acl = Get-Acl "filename"
$user = [System.Security.Principal.WindowsIdentity]::GetCurrent().Name
$acl.SetOwner([System.Security.Principal.NTAccount]$user)
Set-Acl -Path "filename" -AclObject $acl  # PowerShell
```

<div style="page-break-after: always;"></div>

## Network Management

### Network Configuration

```powershell
# Display IP configuration
ipconfig                      # Basic info
ipconfig /all                 # Detailed info
Get-NetIPConfiguration        # PowerShell

# Release DHCP lease
ipconfig /release             # Command Prompt
Get-NetAdapter | Where-Object Status -eq "Up" | ForEach-Object { Remove-NetIPAddress -InterfaceAlias $_.Name -Confirm:$false }  # PowerShell

# Renew DHCP lease
ipconfig /renew               # Command Prompt
Get-NetAdapter | Where-Object Status -eq "Up" | ForEach-Object { Invoke-DhcpRequest -InterfaceAlias $_.Name }  # PowerShell

# Flush DNS cache
ipconfig /flushdns            # Command Prompt
Clear-DnsClientCache          # PowerShell
```

### Network Connectivity

```powershell
# Test network connectivity
ping hostname                 # Command Prompt
Test-Connection hostname      # PowerShell

# Trace route to a host
tracert hostname              # Command Prompt
Test-NetConnection hostname -TraceRoute  # PowerShell

# Network statistics
netstat                       # Command Prompt
Get-NetTCPConnection          # PowerShell

# Check open ports
netstat -an | findstr "PORT"  # Command Prompt
Get-NetTCPConnection | Where-Object LocalPort -eq PORT  # PowerShell
```

### Network Shares

```powershell
# List network shares
net share                     # Command Prompt
Get-SmbShare                  # PowerShell

# Create a network share
net share sharename=C:\path /grant:everyone,full  # Command Prompt
New-SmbShare -Name "sharename" -Path "C:\path" -FullAccess "Everyone"  # PowerShell

# Remove a network share
net share sharename /delete   # Command Prompt
Remove-SmbShare -Name "sharename" -Force  # PowerShell

# Connect to a network share
net use X: \\server\share     # Command Prompt
New-PSDrive -Name X -PSProvider FileSystem -Root "\\server\share"  # PowerShell
```

<div style="page-break-after: always;"></div>

## Services and Processes

### Service Management

```powershell
# List all services
sc query                      # Command Prompt
Get-Service                   # PowerShell

# Start a service
sc start servicename          # Command Prompt
Start-Service -Name "servicename"  # PowerShell

# Stop a service
sc stop servicename           # Command Prompt
Stop-Service -Name "servicename"  # PowerShell

# Change service startup type
sc config servicename start= auto  # Command Prompt (note: space after =)
Set-Service -Name "servicename" -StartupType Automatic  # PowerShell

# Create a new service
sc create servicename binPath= "\"C:\path\to\executable.exe\""  # Command Prompt
New-Service -Name "servicename" -BinaryPathName "C:\path\to\executable.exe"  # PowerShell

# Delete a service
sc delete servicename         # Command Prompt
Remove-Service -Name "servicename"  # PowerShell
```

### Process Management

```powershell
# List running processes
tasklist                      # Command Prompt
Get-Process                   # PowerShell

# Kill a process by name
taskkill /IM process.exe      # Command Prompt
Stop-Process -Name "process"  # PowerShell

# Kill a process by ID
taskkill /PID processID       # Command Prompt
Stop-Process -Id processID    # PowerShell

# Force kill a process
taskkill /F /IM process.exe   # Command Prompt
Stop-Process -Name "process" -Force  # PowerShell

# Start a new process
start program.exe             # Command Prompt
Start-Process -FilePath "program.exe"  # PowerShell
```

<div style="page-break-after: always;"></div>

## Disk and Storage Management

### Disk Utilities

```powershell
# List disk information
diskpart
> list disk                   # Command Prompt
Get-Disk                      # PowerShell

# Check disk for errors
chkdsk C:                     # Command Prompt
Repair-Volume -DriveLetter C  # PowerShell

# Format a drive
format D: /fs:NTFS /q         # Command Prompt (Quick format)
Format-Volume -DriveLetter D -FileSystem NTFS -Confirm:$false  # PowerShell

# List partition information
diskpart
> list partition              # Command Prompt
Get-Partition                 # PowerShell
```

### Disk Space

```powershell
# Display free disk space
dir C:                        # Command Prompt
Get-Volume -DriveLetter C    # PowerShell

# Display folder sizes (PowerShell)
Get-ChildItem -Path "C:\path" -Directory | 
    ForEach-Object {
        $size = (Get-ChildItem -Path $_.FullName -Recurse -File | Measure-Object -Property Length -Sum).Sum
        [PSCustomObject]@{
            Name = $_.Name
            Size = "{0:N2} MB" -f ($size / 1MB)
        }
    }
```

### Disk Cleanup

```powershell
# Run disk cleanup utility
cleanmgr                      # Command Prompt

# Clean up system files (PowerShell)
Start-Process -FilePath cleanmgr -ArgumentList "/sagerun:1" -Wait

# Clean Windows Update files
dism /online /cleanup-image /startcomponentcleanup  # Command Prompt
```

<div style="page-break-after: always;"></div>

## Security and Permissions

### File and Folder Permissions

```powershell
# Display file permissions
icacls filename               # Command Prompt
Get-Acl -Path "filename" | Format-List  # PowerShell

# Grant permissions
icacls filename /grant username:F  # Command Prompt (F=Full control)
$acl = Get-Acl -Path "filename"
$permission = "username","FullControl","Allow"
$accessRule = New-Object System.Security.AccessControl.FileSystemAccessRule $permission
$acl.SetAccessRule($accessRule)
Set-Acl -Path "filename" -AclObject $acl  # PowerShell

# Remove permissions
icacls filename /remove username  # Command Prompt
$acl = Get-Acl -Path "filename"
$accessRule = $acl.Access | Where-Object { $_.IdentityReference -eq "username" }
$acl.RemoveAccessRule($accessRule)
Set-Acl -Path "filename" -AclObject $acl  # PowerShell
```

### Security Policy

```powershell
# Open Local Security Policy editor
secpol.msc                    # Command Prompt

# Export security policy
secedit /export /cfg C:\temp\secpol.cfg  # Command Prompt

# Import security policy
secedit /configure /db %windir%\security\local.sdb /cfg C:\temp\secpol.cfg  # Command Prompt
```

### Firewall Management

```powershell
# Display firewall status
netsh advfirewall show allprofiles  # Command Prompt
Get-NetFirewallProfile              # PowerShell

# Enable firewall
netsh advfirewall set allprofiles state on  # Command Prompt
Set-NetFirewallProfile -Profile Domain,Public,Private -Enabled True  # PowerShell

# Disable firewall (not recommended)
netsh advfirewall set allprofiles state off  # Command Prompt
Set-NetFirewallProfile -Profile Domain,Public,Private -Enabled False  # PowerShell

# Add firewall rule
netsh advfirewall firewall add rule name="Allow Port 80" dir=in action=allow protocol=TCP localport=80  # Command Prompt
New-NetFirewallRule -DisplayName "Allow Port 80" -Direction Inbound -Action Allow -Protocol TCP -LocalPort 80  # PowerShell
```

<div style="page-break-after: always;"></div>

## Scheduled Tasks

### Task Management

```powershell
# List scheduled tasks
schtasks /query               # Command Prompt
Get-ScheduledTask             # PowerShell

# Create a scheduled task
schtasks /create /tn "TaskName" /tr "C:\path\to\program.exe" /sc daily /st 09:00  # Command Prompt
$action = New-ScheduledTaskAction -Execute "C:\path\to\program.exe"
$trigger = New-ScheduledTaskTrigger -Daily -At 9am
Register-ScheduledTask -TaskName "TaskName" -Action $action -Trigger $trigger  # PowerShell

# Delete a scheduled task
schtasks /delete /tn "TaskName" /f  # Command Prompt
Unregister-ScheduledTask -TaskName "TaskName" -Confirm:$false  # PowerShell

# Run a scheduled task
schtasks /run /tn "TaskName"  # Command Prompt
Start-ScheduledTask -TaskName "TaskName"  # PowerShell

# Stop a running scheduled task
schtasks /end /tn "TaskName"  # Command Prompt
Stop-ScheduledTask -TaskName "TaskName"  # PowerShell
```

<div style="page-break-after: always;"></div>

## Windows Updates

### Update Management

```powershell
# Check for updates (PowerShell)
(New-Object -ComObject Microsoft.Update.Session).CreateUpdateSearcher().Search("IsInstalled=0").Updates

# Install updates (PowerShell)
$UpdateSession = New-Object -ComObject Microsoft.Update.Session
$UpdateSearcher = $UpdateSession.CreateUpdateSearcher()
$SearchResult = $UpdateSearcher.Search("IsInstalled=0")
$UpdatesToInstall = New-Object -ComObject Microsoft.Update.UpdateColl
foreach ($Update in $SearchResult.Updates) {
    $UpdatesToInstall.Add($Update)
}
$Installer = $UpdateSession.CreateUpdateInstaller()
$Installer.Updates = $UpdatesToInstall
$Result = $Installer.Install()

# View update history
wmic qfe list                 # Command Prompt
Get-HotFix                    # PowerShell
```

### Windows Update Settings

```powershell
# Windows Update settings (GUI)
control /name Microsoft.WindowsUpdate  # Command Prompt

# Enable automatic updates
reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update" /v AUOptions /t REG_DWORD /d 4 /f  # Command Prompt
```

<div style="page-break-after: always;"></div>

## Remote Management

### Remote Desktop

```powershell
# Enable Remote Desktop
reg add "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Terminal Server" /v fDenyTSConnections /t REG_DWORD /d 0 /f  # Command Prompt
Set-ItemProperty -Path 'HKLM:\System\CurrentControlSet\Control\Terminal Server' -Name "fDenyTSConnections" -Value 0  # PowerShell

# Configure Remote Desktop firewall rule
netsh advfirewall firewall set rule group="remote desktop" new enable=yes  # Command Prompt
Enable-NetFirewallRule -DisplayGroup "Remote Desktop"  # PowerShell

# Connect to Remote Desktop
mstsc /v:hostname            # Command Prompt
```

### WMI and Remote Commands

```powershell
# Execute command on remote computer (PowerShell)
Invoke-Command -ComputerName hostname -ScriptBlock { Get-Process }

# Get WMI information
wmic cpu get name            # Command Prompt
Get-CimInstance -ClassName Win32_Processor | Select-Object Name  # PowerShell

# Remote WMI query
wmic /node:"hostname" cpu get name  # Command Prompt
Get-CimInstance -ComputerName hostname -ClassName Win32_Processor | Select-Object Name  # PowerShell
```

<div style="page-break-after: always;"></div>

## System Information

### Hardware Information

```powershell
# CPU information
wmic cpu get name,maxclockspeed,currentclockspeed  # Command Prompt
Get-CimInstance Win32_Processor | Select-Object Name, MaxClockSpeed, CurrentClockSpeed  # PowerShell

# Memory information
wmic memorychip get capacity,speed  # Command Prompt
Get-CimInstance Win32_PhysicalMemory | Select-Object Capacity, Speed  # PowerShell

# Disk information
wmic diskdrive get model,size,mediatype  # Command Prompt
Get-PhysicalDisk | Select-Object FriendlyName, Size, MediaType  # PowerShell

# BIOS information
wmic bios get manufacturer,version  # Command Prompt
Get-CimInstance Win32_BIOS | Select-Object Manufacturer, SMBIOSBIOSVersion  # PowerShell
```

### System Diagnostics

```powershell
# Event Log information
wevtutil qe System /c:5 /rd:true /f:text  # Command Prompt (5 most recent System events)
Get-WinEvent -LogName System -MaxEvents 5  # PowerShell

# System File Checker
sfc /scannow                 # Command Prompt

# DISM system repair
dism /online /cleanup-image /restorehealth  # Command Prompt
Repair-WindowsImage -Online -RestoreHealth  # PowerShell
```

<div style="page-break-after: always;"></div>

## Common Administrative Tasks

### Environment Variables

```powershell
# List all environment variables
set                          # Command Prompt
Get-ChildItem Env:           # PowerShell

# Set environment variable (session only)
set variable=value           # Command Prompt
$env:variable = "value"      # PowerShell

# Set permanent environment variable
setx variable value          # Command Prompt (User)
setx variable value /M       # Command Prompt (System)
[Environment]::SetEnvironmentVariable("variable", "value", "User")    # PowerShell (User)
[Environment]::SetEnvironmentVariable("variable", "value", "Machine") # PowerShell (System)
```

### Registry Management

```powershell
# Query registry value
reg query "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion" /v ProgramFilesDir  # Command Prompt
Get-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion" -Name ProgramFilesDir  # PowerShell

# Add/modify registry value
reg add "HKLM\SOFTWARE\Test" /v TestValue /t REG_SZ /d "Value" /f  # Command Prompt
Set-ItemProperty -Path "HKLM:\SOFTWARE\Test" -Name TestValue -Value "Value"  # PowerShell

# Delete registry value
reg delete "HKLM\SOFTWARE\Test" /v TestValue /f  # Command Prompt
Remove-ItemProperty -Path "HKLM:\SOFTWARE\Test" -Name TestValue  # PowerShell

# Export registry key
reg export "HKLM\SOFTWARE\Test" C:\temp\test.reg  # Command Prompt
```

<div style="page-break-after: always;"></div>

## PowerShell Scripting Basics

### Script Execution

```powershell
# Run a PowerShell script
powershell -File script.ps1

# Run script with parameters
powershell -File script.ps1 -Param1 Value1 -Param2 Value2

# Run script with elevated privileges
powershell -Command "Start-Process PowerShell -ArgumentList '-File script.ps1' -Verb RunAs"

# Load script but don't execute
powershell -NoExit -Command ". .\script.ps1"
```

### Basic Script Structure

```powershell
# Example script structure
Param(
    [Parameter(Mandatory=$true)]
    [string]$ComputerName,
    
    [Parameter(Mandatory=$false)]
    [switch]$Force
)

# Import modules
Import-Module ActiveDirectory

# Functions
function Get-ServiceStatus {
    param($service)
    return (Get-Service -Name $service).Status
}

# Main script
try {
    $status = Get-ServiceStatus -service "spooler"
    Write-Output "Service status: $status"
} catch {
    Write-Error "An error occurred: $_"
} finally {
    # Cleanup code
}
```

<div style="page-break-after: always;"></div>

## Troubleshooting

### Common Issues

```powershell
# Event Viewer
eventvwr                     # Command Prompt

# Reliability Monitor
perfmon /rel                 # Command Prompt

# Resource Monitor
resmon                       # Command Prompt

# Performance Monitor
perfmon                      # Command Prompt

# Check system file integrity
sfc /scannow                 # Command Prompt
```

### Network Troubleshooting

```powershell
# Reset TCP/IP stack
netsh int ip reset           # Command Prompt

# Reset Winsock catalog
netsh winsock reset          # Command Prompt

# Display network statistics
netstat -ano                 # Command Prompt
Get-NetTCPConnection | Sort-Object State, LocalPort  # PowerShell

# Check DNS resolution
nslookup domain.com          # Command Prompt
Resolve-DnsName domain.com   # PowerShell
```

### System Restore

```powershell
# Create restore point
wmic.exe /Namespace:\\root\default Path SystemRestore Call CreateRestorePoint "Manual Restore Point", 100, 7  # Command Prompt
Checkpoint-Computer -Description "Manual Restore Point" -RestorePointType "MODIFY_SETTINGS"  # PowerShell

# List restore points
vssadmin list shadowstorage  # Command Prompt
Get-ComputerRestorePoint     # PowerShell
```

<div style="page-break-after: always;"></div>

## Best Practices

### Security

```powershell
# Always run administrative commands in an elevated prompt
# Verify command syntax before execution
# Use specific rather than broad permissions
```

### Performance

```powershell
# Restart services instead of rebooting when possible
# Schedule resource-intensive tasks during off-hours
# Use PowerShell remoting instead of RDP when feasible
```

### Automation

```powershell
# Script repetitive tasks
# Use parameter validation in scripts
# Log all administrative actions
# Test scripts in non-production environments first
```

### Backup

```powershell
# Backup system state before major changes
wbadmin start systemstatebackup -backupTarget:E:  # Command Prompt

# Export settings before modification
reg export HKLM\path\to\key backup.reg  # Command Prompt
```

### Maintenance Schedule

```powershell
# Weekly tasks:
# - Windows Updates
# - Disk cleanup
# - Event log review

# Monthly tasks:
# - Service account password rotation
# - Security policy review
# - System state backup
```