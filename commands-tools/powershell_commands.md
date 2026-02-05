# PowerShell Command Cheat Sheet

This document provides a comprehensive overview of essential PowerShell commands, with descriptions and examples for each.

## Table of Contents

- [Getting Started](#getting-started)
- [Basic Commands](#basic-commands)
- [Variables and Data Types](#variables-and-data-types)
- [Flow Control](#flow-control)
- [Functions and Scripts](#functions-and-scripts)
- [File System Operations](#file-system-operations)
- [Process Management](#process-management)
- [Modules and Package Management](#modules-and-package-management)
- [Network Commands](#network-commands)
- [System Administration](#system-administration)
- [Advanced Topics](#advanced-topics)
- [PowerShell Workflow Examples](#powershell-workflow-examples)
- [Best Practices](#best-practices)

## Getting Started
_Learn PowerShell basics including execution policy, version information, and help system to get comfortable with the PowerShell environment._

### PowerShell Environment

```powershell
# Check PowerShell version
$PSVersionTable

# Get execution policy
Get-ExecutionPolicy

# Set execution policy
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser

# List PowerShell drives
Get-PSDrive

# Show current location
Get-Location
# or alias
pwd
```
<div style="page-break-after:always;"></div>

### Getting Help

```powershell
# Get help for a command
Get-Help Get-Process

# Get detailed help with examples
Get-Help Get-Process -Detailed
Get-Help Get-Process -Examples

# Get full help documentation
Get-Help Get-Process -Full

# Find commands by name
Get-Command *process*

# Find commands by verb
Get-Command -Verb Get

# Find commands by noun
Get-Command -Noun Process

# Update help files
Update-Help
```

## Basic Commands
_Essential commands for navigating, getting information, and performing basic operations in PowerShell._

### Navigation and Information

```powershell
# Change directory
Set-Location C:\Windows
# or alias
cd C:\Windows

# List directory contents
Get-ChildItem
# or aliases
dir
ls

# List with hidden items
Get-ChildItem -Hidden
Get-ChildItem -Force  # Shows all items

# List directory contents with details
Get-ChildItem -Force | Format-Table -Property Name, Length, LastWriteTime -AutoSize
```
<div style="page-break-after:always;"></div>

### Formatting Output

```powershell
# Display as a formatted list
Get-Process | Format-List

# Display as a formatted table
Get-Process | Format-Table

# Display specific properties as a table
Get-Process | Format-Table -Property ID, Name, CPU

# Format with auto-sized columns
Get-Process | Format-Table -AutoSize

# Group output
Get-Process | Group-Object -Property PriorityClass | Format-Table

# Sort output
Get-Process | Sort-Object -Property CPU -Descending | Format-Table
```

### Filtering and Selecting

```powershell
# Filter objects using Where-Object
Get-Process | Where-Object { $_.CPU -gt 10 }
# Simplified syntax
Get-Process | Where-Object CPU -gt 10

# Select specific properties
Get-Process | Select-Object -Property Name, ID, CPU

# Select top N items
Get-Process | Sort-Object CPU -Descending | Select-Object -First 5

# Select unique values
Get-Service | Select-Object -Property Status -Unique
```
<div style="page-break-after:always;"></div>

## Variables and Data Types
_Work with different types of data in PowerShell, from simple variables to complex structured data._

### Working with Variables

```powershell
# Create and assign a variable
$name = "PowerShell"
$count = 5

# Display variable content
$name
Write-Output $name

# Check variable type
$name.GetType().FullName

# Type casting
$number = [int]"42"
$date = [datetime]"2025-06-03"

# Constants and read-only variables
Set-Variable -Name MaxSize -Value 100 -Option Constant
New-Variable -Name MinSize -Value 10 -Option ReadOnly
```

### Data Types

```powershell
# String operations
$message = "Hello, World!"
$message.ToUpper()
$message.Length
$message.Replace("Hello", "Hi")

# Numbers
$sum = 10 + 20
$product = 5 * 7
$power = [Math]::Pow(2, 3)  # 2^3 = 8
$rounded = [Math]::Round(3.75, 1)

# Date and time
$now = Get-Date
$today = (Get-Date).Date
$tomorrow = (Get-Date).AddDays(1)
$formatDate = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
```
<div style="page-break-after:always;"></div>

### Collections and Arrays

```powershell
# Create an array
$fruits = @("Apple", "Banana", "Cherry")

# Access array elements
$fruits[0]  # First element
$fruits[-1]  # Last element

# Array length
$fruits.Count

# Add to an array
$fruits += "Date"

# Create a hashtable (dictionary)
$person = @{
    Name = "John";
    Age = 30;
    City = "New York"
}

# Access hashtable elements
$person["Name"]
$person.Age

# Add or update hashtable elements
$person["Email"] = "john@example.com"
$person.Phone = "555-1234"
```

## Flow Control
_Control the execution flow in scripts using conditions, loops, and switches._

### Conditional Statements

```powershell
# If statement
$temperature = 75
if ($temperature -gt 80) {
    "It's hot outside!"
} elseif ($temperature -lt 60) {
    "It's cold outside!"
} else {
    "The weather is pleasant."
}

# Comparison operators
# -eq (equal), -ne (not equal), -gt (greater than), -lt (less than)
# -ge (greater or equal), -le (less or equal), -like (wildcard comparison)
if ($name -eq "PowerShell") { "Name matches" }
if ($count -gt 0) { "Count is positive" }
```
<div style="page-break-after:always;"></div>

### Looping Constructs

```powershell
# ForEach loop
$numbers = 1..5
foreach ($number in $numbers) {
    "Number: $number"
}

# ForEach-Object (pipeline)
1..5 | ForEach-Object { "Number: $_" }

# For loop
for ($i = 0; $i -lt 5; $i++) {
    "Index: $i"
}

# While loop
$counter = 0
while ($counter -lt 5) {
    "Counter: $counter"
    $counter++
}

# Do-While loop (runs at least once)
$counter = 0
do {
    "Counter: $counter"
    $counter++
} while ($counter -lt 5)

# Do-Until loop (runs at least once)
$counter = 0
do {
    "Counter: $counter"
    $counter++
} until ($counter -ge 5)
```

### Switch Statement

```powershell
# Basic switch
$color = "Red"
switch ($color) {
    "Red" { "Color is Red" }
    "Blue" { "Color is Blue" }
    "Green" { "Color is Green" }
    default { "Unknown color" }
}

# Switch with patterns
$text = "Start-123"
switch -Wildcard ($text) {
    "Start*" { "Starts with 'Start'" }
    "*123" { "Ends with '123'" }
    "Start-*-End" { "Has specific pattern" }
}

# Switch with regex
$code = "ABC-123"
switch -Regex ($code) {
    "^[A-Z]{3}" { "Starts with 3 uppercase letters" }
    "[0-9]{3}$" { "Ends with 3 digits" }
    "^([A-Z]{3})-([0-9]{3})$" { "Matches the exact pattern" }
}
```
<div style="page-break-after:always;"></div>

## Functions and Scripts
_Create reusable code blocks with functions and develop scripts for automation._

### Writing Functions

```powershell
# Basic function
function Say-Hello {
    Write-Output "Hello, World!"
}
Say-Hello

# Function with parameters
function Greet-User {
    param (
        [string]$Name = "Guest"
    )
    Write-Output "Hello, $Name!"
}
Greet-User -Name "John"

# Advanced function with parameter validation
function Add-Numbers {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [int]$FirstNumber,
        
        [Parameter(Mandatory = $true)]
        [int]$SecondNumber
    )
    
    return $FirstNumber + $SecondNumber
}
Add-Numbers -FirstNumber 5 -SecondNumber 7
```

### Script Files

```powershell
# Create a script file (.ps1)
# hello.ps1 content:
# ------------------
# param (
#     [string]$Name = "World"
# )
# Write-Output "Hello, $Name!"
# ------------------

# Run a script
.\hello.ps1
.\hello.ps1 -Name "PowerShell"

# Working with script scope
# scope.ps1 content:
# ------------------
# $scriptVar = "Script level"
# function Test-Scope {
#     $localVar = "Function level"
#     Write-Output "Inside function: $scriptVar, $localVar"
# }
# Test-Scope
# Write-Output "Outside function: $scriptVar"
# ------------------
```
<div style="page-break-after:always;"></div>

## File System Operations
_Work with files and directories using PowerShell's file system cmdlets._

### File Management

```powershell
# Create a new file
New-Item -Path "C:\temp\test.txt" -ItemType File
# or
"Content" | Out-File -FilePath "C:\temp\test.txt"

# Add content to a file
Add-Content -Path "C:\temp\test.txt" -Value "New line of text"
"Another line" | Add-Content -Path "C:\temp\test.txt"

# Read file content
Get-Content -Path "C:\temp\test.txt"

# Read specific lines
Get-Content -Path "C:\temp\test.txt" -TotalCount 5  # First 5 lines
Get-Content -Path "C:\temp\test.txt" -Tail 5  # Last 5 lines

# Copy a file
Copy-Item -Path "C:\temp\test.txt" -Destination "C:\temp\backup.txt"

# Move/rename a file
Move-Item -Path "C:\temp\test.txt" -Destination "C:\temp\moved.txt"

# Delete a file
Remove-Item -Path "C:\temp\test.txt"
```

### Directory Management

```powershell
# Create directory
New-Item -Path "C:\temp\new_folder" -ItemType Directory
# or
mkdir "C:\temp\another_folder"

# Copy directory
Copy-Item -Path "C:\temp\source" -Destination "C:\temp\destination" -Recurse

# Move/rename directory
Move-Item -Path "C:\temp\old_folder" -Destination "C:\temp\new_folder"

# Delete directory
Remove-Item -Path "C:\temp\folder_to_delete" -Recurse

# Check if file/directory exists
Test-Path -Path "C:\temp\file.txt"
```
<div style="page-break-after:always;"></div>

### File System Navigation

```powershell
# Get current directory
Get-Location
# or 
pwd

# Change directory
Set-Location -Path "C:\Windows"
# or
cd "C:\Windows"

# Navigate to parent directory
Set-Location ..

# Get parent directory path
Split-Path -Path (Get-Location) -Parent

# Get file name from path
Split-Path -Path "C:\temp\file.txt" -Leaf

# Join paths
Join-Path -Path "C:\temp" -ChildPath "file.txt"

# Resolve relative path to absolute
Resolve-Path -Path ".\file.txt"
```

## Process Management
_Monitor, start, and manage processes running on the system._

### Process Information

```powershell
# Get all processes
Get-Process

# Get process by name
Get-Process -Name "explorer"

# Get process by ID
Get-Process -Id 1234

# Get most resource-intensive processes
Get-Process | Sort-Object -Property CPU -Descending | Select-Object -First 5

# Get specific process properties
Get-Process | Select-Object -Property Name, ID, CPU, WorkingSet
```
<div style="page-break-after:always;"></div>

### Process Control

```powershell
# Start a process
Start-Process -FilePath "notepad.exe"

# Start a process with arguments
Start-Process -FilePath "powershell.exe" -ArgumentList "-NoProfile -Command Get-Date"

# Start a process as admin
Start-Process -FilePath "notepad.exe" -Verb RunAs

# Wait for a process to complete
Start-Process -FilePath "notepad.exe" -Wait

# Stop a process by name
Stop-Process -Name "notepad"

# Stop a process by ID
Stop-Process -Id 1234

# Stop a process and force it to close
Stop-Process -Name "notepad" -Force

# Check if a process is running
$processName = "notepad"
$isRunning = Get-Process -Name $processName -ErrorAction SilentlyContinue
if ($isRunning) { "Process is running" } else { "Process is not running" }
```

## Modules and Package Management
_Use PowerShell modules to extend functionality and manage packages using PowerShellGet._

### Module Management

```powershell
# List available modules
Get-Module -ListAvailable

# List loaded modules
Get-Module

# Import a module
Import-Module -Name Microsoft.PowerShell.Management

# Get commands from a module
Get-Command -Module Microsoft.PowerShell.Management

# Find module info
Get-Module -Name Microsoft.PowerShell.Management | Format-List

# Remove a module
Remove-Module -Name Microsoft.PowerShell.Management
```
<div style="page-break-after:always;"></div>

### PowerShellGet

```powershell
# Find modules in PowerShell Gallery
Find-Module -Name "*Azure*"

# Install a module from PowerShell Gallery
Install-Module -Name Az -Scope CurrentUser

# Update a module
Update-Module -Name Az

# Uninstall a module
Uninstall-Module -Name Az

# Find scripts in PowerShell Gallery
Find-Script -Name "*Backup*"

# Install a script
Install-Script -Name Get-WindowsAutoPilotInfo -Scope CurrentUser

# Save a module without installing
Save-Module -Name PSScriptAnalyzer -Path C:\Temp
```

## Network Commands
_Manage network connections, test connectivity, and work with network resources._

### Network Information

```powershell
# Get network adapters
Get-NetAdapter

# Get IP addresses
Get-NetIPAddress

# Get network configuration
Get-NetIPConfiguration

# Get DNS client settings
Get-DnsClientServerAddress

# Get network statistics
Get-NetAdapterStatistics

# Get network connections
Get-NetTCPConnection

# Test network connection
Test-NetConnection -ComputerName google.com

# Detailed connection test
Test-NetConnection -ComputerName google.com -TraceRoute

# Test on specific port
Test-NetConnection -ComputerName google.com -Port 443
```
<div style="page-break-after:always;"></div>

### Network Operations

```powershell
# Ping a host
Test-Connection -TargetName google.com

# Ping with count
Test-Connection -TargetName google.com -Count 3

# Resolve DNS name
Resolve-DnsName -Name google.com

# Check for specific DNS record type
Resolve-DnsName -Name google.com -Type MX

# Download a file
Invoke-WebRequest -Uri "https://example.com/file.txt" -OutFile "C:\temp\file.txt"

# Get web content
$response = Invoke-WebRequest -Uri "https://example.com"
$response.Content

# Make a REST API call
$response = Invoke-RestMethod -Uri "https://api.github.com/users/microsoft"
$response.name
```

## System Administration
_Manage Windows systems, services, and perform administrative tasks._

### Services Management

```powershell
# Get all services
Get-Service

# Get specific service
Get-Service -Name "wuauserv"  # Windows Update service

# Get running services
Get-Service | Where-Object { $_.Status -eq "Running" }

# Start a service
Start-Service -Name "wuauserv"

# Stop a service
Stop-Service -Name "wuauserv"

# Restart a service
Restart-Service -Name "wuauserv"

# Set service startup type
Set-Service -Name "wuauserv" -StartupType Automatic
```
<div style="page-break-after:always;"></div>

### Event Logs

```powershell
# List event logs
Get-EventLog -List

# Get events from log
Get-EventLog -LogName System -Newest 10

# Get errors from log
Get-EventLog -LogName System -EntryType Error -Newest 10

# Get events by source
Get-EventLog -LogName System -Source "Service Control Manager" -Newest 10

# Get events in a time range
$start = Get-Date -Date "2025-06-01"
$end = Get-Date -Date "2025-06-03"
Get-EventLog -LogName System -After $start -Before $end

# Use newer command (PowerShell 3.0+)
Get-WinEvent -LogName System -MaxEvents 10

# Filter events using XML query
Get-WinEvent -FilterXml @'
<QueryList>
  <Query Id="0" Path="System">
    <Select Path="System">*[System[(Level=2)]]</Select>
  </Query>
</QueryList>
'@
```

### User and Group Management

```powershell
# Get local users
Get-LocalUser

# Create a local user
New-LocalUser -Name "JohnDoe" -Description "Regular User Account" -NoPassword

# Set user password
$Password = Read-Host -AsSecureString
Set-LocalUser -Name "JohnDoe" -Password $Password

# Enable/disable user account
Disable-LocalUser -Name "JohnDoe"
Enable-LocalUser -Name "JohnDoe"

# Get local groups
Get-LocalGroup

# Create a local group
New-LocalGroup -Name "Developers" -Description "Development team"

# Add user to group
Add-LocalGroupMember -Group "Developers" -Member "JohnDoe"

# Get group members
Get-LocalGroupMember -Group "Administrators"
```
<div style="page-break-after:always;"></div>

### Registry Operations

```powershell
# Navigate registry paths
Set-Location HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion

# Get registry values
Get-ItemProperty -Path HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion -Name ProgramFilesDir

# Create a registry key
New-Item -Path HKCU:\Software -Name MyCompany

# Set a registry value
Set-ItemProperty -Path HKCU:\Software\MyCompany -Name Version -Value "1.0"
New-ItemProperty -Path HKCU:\Software\MyCompany -Name Status -Value "Active" -PropertyType String

# Remove a registry value
Remove-ItemProperty -Path HKCU:\Software\MyCompany -Name Status

# Remove a registry key
Remove-Item -Path HKCU:\Software\MyCompany -Recurse
```

## Advanced Topics
_Explore advanced PowerShell concepts for more powerful scripting and automation._

### Error Handling

```powershell
# Basic try-catch
try {
    Get-Content -Path "C:\NonExistentFile.txt" -ErrorAction Stop
} catch {
    "An error occurred: $_"
}

# Catch specific errors
try {
    Get-Content -Path "C:\NonExistentFile.txt" -ErrorAction Stop
} catch [System.IO.FileNotFoundException] {
    "File not found"
} catch {
    "Another error occurred: $_"
}

# Finally block
try {
    # Code that might cause an error
} catch {
    # Error handling
} finally {
    # Code that always runs
}

# ErrorAction parameters
Get-Content -Path "C:\NonExistentFile.txt" -ErrorAction SilentlyContinue
Get-Content -Path "C:\NonExistentFile.txt" -ErrorAction Continue
Get-Content -Path "C:\NonExistentFile.txt" -ErrorAction Stop
```
<div style="page-break-after:always;"></div>

### Jobs and Background Tasks

```powershell
# Start a background job
Start-Job -ScriptBlock { Get-Process }

# Get all jobs
Get-Job

# Get job results
Receive-Job -Id 1

# Get job results and keep them
Receive-Job -Id 1 -Keep

# Remove a job
Remove-Job -Id 1

# Wait for a job to complete
Wait-Job -Id 2

# Stop a job
Stop-Job -Id 3

# Run command on remote computer as a background job
Invoke-Command -ComputerName Server01 -ScriptBlock { Get-Process } -AsJob

# Use ThrottleLimit to run multiple jobs with controlled parallelism
1..10 | ForEach-Object -ThrottleLimit 5 -Parallel {
    Start-Sleep -Seconds 2
    "Job $_ completed"
}
```

### Working with XML and JSON

```powershell
# Convert string to XML
[xml]$xml = @"
<Root>
  <User Name="John" Age="30">
    <Role>Admin</Role>
  </User>
</Root>
"@

# Access XML elements
$xml.Root.User.Name
$xml.Root.User.Role

# Find XML elements
$xml.SelectNodes("//User")
$xml.SelectSingleNode("//User[@Name='John']")

# Convert PS object to JSON
$person = @{
    Name = "John"
    Age = 30
    Roles = @("Developer", "Admin")
}
$json = $person | ConvertTo-Json

# Convert JSON to PS object
$person = $json | ConvertFrom-Json
$person.Name
$person.Roles[0]
```
<div style="page-break-after:always;"></div>

### PowerShell Classes

```powershell
# Define a class
class Person {
    # Properties
    [string]$Name
    [int]$Age
    
    # Constructor
    Person([string]$name, [int]$age) {
        $this.Name = $name
        $this.Age = $age
    }
    
    # Method
    [string]Introduce() {
        return "Hi, I'm $($this.Name) and I'm $($this.Age) years old."
    }
    
    # Static method
    static [Person]CreateAdult([string]$name) {
        return [Person]::new($name, 18)
    }
}

# Use the class
$person = [Person]::new("John", 30)
$person.Introduce()

# Use static method
$adult = [Person]::CreateAdult("Jane")
$adult.Age  # Returns 18
```

## PowerShell Workflow Examples
_Common patterns and procedures for using PowerShell effectively in different scenarios._

### File Processing Workflow

```powershell
# Example: Process all log files in a directory
$logPath = "C:\Logs"
$archivePath = "C:\LogArchive"

# Create archive directory if it doesn't exist
if (-not (Test-Path -Path $archivePath)) {
    New-Item -Path $archivePath -ItemType Directory
}

# Get log files older than 7 days
$cutoffDate = (Get-Date).AddDays(-7)
$oldLogs = Get-ChildItem -Path $logPath -Filter "*.log" | 
           Where-Object { $_.LastWriteTime -lt $cutoffDate }

# Process each log file
foreach ($log in $oldLogs) {
    # Create archive filename with date
    $archiveFile = Join-Path -Path $archivePath -ChildPath ("$($log.BaseName)_$(Get-Date -Format 'yyyyMMdd')$($log.Extension)")
    
    # Compress and move the log
    Compress-Archive -Path $log.FullName -DestinationPath "$archiveFile.zip" -Force
    
    # Remove original file after successful compression
    if (Test-Path -Path "$archiveFile.zip") {
        Remove-Item -Path $log.FullName
        Write-Output "Archived and removed: $($log.Name)"
    }
}
```
<div style="page-break-after:always;"></div>

### System Maintenance Script

```powershell
# Example: Basic system maintenance script
function Perform-SystemMaintenance {
    param (
        [string]$ComputerName = $env:COMPUTERNAME,
        [switch]$CleanTemp,
        [switch]$CheckDisk,
        [switch]$UpdateHelp
    )
    
    Write-Output "Starting system maintenance on $ComputerName..."
    
    # Clean temporary files
    if ($CleanTemp) {
        $tempFolders = @(
            "$env:TEMP",
            "$env:WINDIR\Temp",
            "$env:WINDIR\Prefetch"
        )
        
        foreach ($folder in $tempFolders) {
            Write-Output "Cleaning $folder..."
            Get-ChildItem -Path $folder -File -Force -ErrorAction SilentlyContinue | 
            Where-Object { $_.LastWriteTime -lt (Get-Date).AddDays(-7) } | 
            Remove-Item -Force -ErrorAction SilentlyContinue
        }
    }
    
    # Check disk
    if ($CheckDisk) {
        Write-Output "Checking disk status..."
        Get-Volume | Where-Object { $_.DriveLetter -ne $null } | 
        Select-Object DriveLetter, FileSystemLabel, Size, SizeRemaining, 
        @{Name="PercentFree";Expression={"{0:P2}" -f ($_.SizeRemaining / $_.Size)}}
    }
    
    # Update PowerShell help
    if ($UpdateHelp) {
        Write-Output "Updating PowerShell help..."
        Update-Help -ErrorAction SilentlyContinue
    }
    
    Write-Output "Maintenance complete!"
}

# Usage:
# Perform-SystemMaintenance -CleanTemp -CheckDisk -UpdateHelp
```
<div style="page-break-after:always;"></div>

## Best Practices
_Guidelines for writing efficient, secure, and maintainable PowerShell code._

### Coding Style

```powershell
# Use proper casing
# - PascalCase for function names and parameters
# - camelCase for variables

# Good function naming
function Get-UserStatus {
    param (
        [string]$UserName,
        [int]$DaysInactive
    )
    
    $lastLoginDate = Get-Date # Get actual value in real script
    # ...
}

# Include comment-based help
function Set-UserPermission {
    <#
    .SYNOPSIS
    Sets permissions for a user.
    
    .DESCRIPTION
    This function sets specified permissions for a user on a resource.
    
    .PARAMETER UserName
    The username to set permissions for.
    
    .PARAMETER ResourceName
    The resource to apply permissions to.
    
    .EXAMPLE
    Set-UserPermission -UserName "John" -ResourceName "FileShare" -Permission "Read"
    #>
    param (
        [string]$UserName,
        [string]$ResourceName,
        [string]$Permission
    )
    
    # Function implementation
}
```

### Security Practices

```powershell
# Use secure string for passwords
$securePassword = Read-Host -AsSecureString "Enter Password"

# Never store passwords in plain text
$credential = Get-Credential

# Use HTTPS for web requests
Invoke-RestMethod -Uri "https://api.example.com" -UseBasicParsing

# Always validate input
function Get-FileContent {
    param (
        [Parameter(Mandatory = $true)]
        [ValidateScript({
            if (Test-Path -Path $_ -PathType Leaf) { $true }
            else { throw "File $_ does not exist." }
        })]
        [string]$Path
    )
    
    Get-Content -Path $Path
}
```
<div style="page-break-after:always;"></div>

### Performance Tips

```powershell
# Avoid using Select-Object in loops
# Bad:
foreach ($item in $items) {
    $item | Select-Object -Property Name, Value
}

# Good:
$items | ForEach-Object {
    [PSCustomObject]@{
        Name = $_.Name
        Value = $_.Value
    }
}

# Use filter left, format right
# Good:
Get-Process | Where-Object { $_.CPU -gt 10 } | Sort-Object CPU -Descending | Format-Table

# Avoid unnecessary type conversions
# Faster:
[int[]]$numbers = 1..10000

# Use appropriate data structures
# Hashtable for lookups:
$userLookup = @{}
foreach ($user in $users) {
    $userLookup[$user.ID] = $user
}
$userLookup["12345"]  # Fast lookup
```

### Script Structure

```powershell
# Template for well-structured scripts
<#
.SYNOPSIS
    Brief description of the script.
.DESCRIPTION
    Detailed description of the script.
.PARAMETER ParameterName
    Description of the parameter.
.EXAMPLE
    Usage example.
.NOTES
    Additional information.
#>
[CmdletBinding()]
param (
    [Parameter(Mandatory = $true)]
    [string]$RequiredParam,
    
    [Parameter(Mandatory = $false)]
    [string]$OptionalParam = "Default"
)

# Initialize variables
$ErrorActionPreference = "Stop"
$VerbosePreference = "Continue"

# Define functions
function Test-Something {
    param ($Param)
    # Implementation
}

# Main script execution
try {
    # Main code here
} catch {
    Write-Error "Error: $_"
} finally {
    # Cleanup code
}
```