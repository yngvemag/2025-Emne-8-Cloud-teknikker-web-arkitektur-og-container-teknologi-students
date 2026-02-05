# Linux Command Cheat Sheet

This document provides a comprehensive overview of essential Linux commands, with descriptions and examples for each.

## Table of Contents

- [Getting Started](#getting-started)
- [File System Navigation](#file-system-navigation)
- [File Operations](#file-operations)
- [Text Processing](#text-processing)
- [User Management](#user-management)
- [Permissions](#permissions)
- [Process Management](#process-management)
- [System Information](#system-information)
- [Package Management](#package-management)
- [Network Operations](#network-operations)
- [Compression and Archives](#compression-and-archives)
- [Searching and Finding](#searching-and-finding)
- [Advanced Shell Features](#advanced-shell-features)
- [Shell Scripting](#shell-scripting)
- [Linux Workflow Examples](#linux-workflow-examples)
- [Best Practices](#best-practices)

## Getting Started
_Learn the basics of the Linux command line interface, access help, and understand how to work with commands efficiently._

### Basic Terminal Usage

```bash
# Get current date and time
date

# Display calendar
cal
cal 2025
cal 6 2025  # June 2025

# Clear the terminal screen
clear

# Display manual page for a command
man ls
man grep

# Get help for built-in commands
help cd
help alias

# Display command information
whatis ls
whatis grep

# Display command location
which python
which npm
```
<div style="page-break-after:always;"></div>

### Terminal Shortcuts

```bash
# Command history
history
!42      # Run command number 42 from history
!!       # Repeat the last command
!string  # Run the most recent command starting with "string"
!?string # Run the most recent command containing "string"

# Navigation shortcuts
Ctrl+A   # Move cursor to beginning of line
Ctrl+E   # Move cursor to end of line
Alt+F    # Move cursor forward one word
Alt+B    # Move cursor backward one word

# Editing shortcuts
Ctrl+U   # Cut text from cursor to beginning of line
Ctrl+K   # Cut text from cursor to end of line
Ctrl+Y   # Paste previously cut text
Ctrl+W   # Cut the word before the cursor
Alt+D    # Delete the word after the cursor

# Control shortcuts
Ctrl+C   # Interrupt (kill) the current command
Ctrl+Z   # Suspend the current command
Ctrl+D   # Exit the current shell
Ctrl+L   # Clear the screen (same as 'clear' command)
Ctrl+R   # Search command history
```

## File System Navigation
_Navigate through the Linux file system, locate files, and understand directory structures._

### Basic Navigation

```bash
# Display current directory
pwd

# List files and directories
ls
ls -l     # Long format
ls -a     # Show hidden files
ls -lh    # Human-readable file sizes
ls -la    # Long format with hidden files
ls -ltr   # Sort by time (oldest first)
ls -lS    # Sort by size (largest first)
ls -R     # Recursive listing

# Change directory
cd /path/to/directory
cd ~      # Go to home directory
cd -      # Go to previous directory
cd ..     # Go up one directory
cd ../..  # Go up two directories

# Display directory tree
tree
tree -L 2  # Limit to 2 levels deep
tree -d    # Show directories only
```
<div style="page-break-after:always;"></div>

### Working with Paths

```bash
# Absolute vs. relative paths
cd /var/log          # Absolute path
cd ../lib            # Relative path

# Special path references
.       # Current directory
..      # Parent directory
~       # Home directory
~user   # Home directory of specified user

# See where a symbolic link points
readlink filename
readlink -f filename  # Show full path

# Get the absolute path
realpath relative/path

# Create a symbolic link
ln -s target_file link_name
```

## File Operations
_Create, modify, copy, move, and remove files and directories in the Linux file system._

### File Creation and Viewing

```bash
# Create an empty file
touch file.txt

# Create a new file with content
echo "Hello World" > file.txt
echo "Append this line" >> file.txt

# Create multiple files
touch file1.txt file2.txt file3.txt

# View file content
cat file.txt
more file.txt
less file.txt      # More features, navigable
head file.txt      # Show first 10 lines
head -n 5 file.txt # Show first 5 lines
tail file.txt      # Show last 10 lines
tail -n 5 file.txt # Show last 5 lines
tail -f file.txt   # Follow file as it grows
```
<div style="page-break-after:always;"></div>

### Directory Operations

```bash
# Create directory
mkdir directory_name
mkdir -p parent/child/grandchild  # Create parent directories if needed

# Remove empty directory
rmdir directory_name

# Create nested directories
mkdir -p path/to/directory

# Remove directory and contents
rm -r directory_name
rm -rf directory_name  # Force removal without prompting
```

### Copy, Move, and Remove Files

```bash
# Copy files
cp source.txt destination.txt
cp file.txt directory/
cp -r source_dir/ destination_dir/  # Copy directory recursively

# Move or rename files
mv old_name.txt new_name.txt
mv file.txt directory/

# Move multiple files to a directory
mv file1.txt file2.txt directory/

# Remove files
rm file.txt
rm file1.txt file2.txt
rm -f file.txt  # Force removal without confirmation
rm -i file.txt  # Interactive mode, prompt before removing

# Safely remove files (move to trash)
# Requires trash-cli package
trash file.txt
trash-list  # List trashed files
trash-restore  # Restore from trash
```
<div style="page-break-after:always;"></div>

## Text Processing
_Manipulate and analyze text data using Linux command line tools._

### Basic Text Editing

```bash
# Create/edit files with text editors
nano file.txt       # Simple editor
vim file.txt        # Advanced editor
emacs file.txt      # Full-featured editor

# Count lines, words, characters
wc file.txt
wc -l file.txt      # Lines only
wc -w file.txt      # Words only
wc -c file.txt      # Characters only

# Display file type
file file.txt
file image.jpg
file /bin/bash
```

### Text Processing Tools

```bash
# Filter and transform text
grep "pattern" file.txt      # Search for pattern
grep -i "pattern" file.txt   # Case-insensitive search
grep -r "pattern" directory/ # Recursive search
grep -v "pattern" file.txt   # Inverse match (lines without pattern)
grep -n "pattern" file.txt   # Show line numbers

# Search and replace text
sed 's/old/new/' file.txt         # Replace first occurrence in each line
sed 's/old/new/g' file.txt        # Replace all occurrences
sed -i 's/old/new/g' file.txt     # Replace in file (in-place)
sed '1,5s/old/new/g' file.txt     # Replace in lines 1-5 only

# Extract and process text data
awk '{print $1}' file.txt         # Print first column
awk '{print $1, $3}' file.txt     # Print columns 1 and 3
awk -F: '{print $1}' /etc/passwd  # Use custom field separator
awk '{sum += $1} END {print sum}' # Calculate sum of first column

# Sort text
sort file.txt                # Sort alphabetically
sort -r file.txt             # Reverse sort
sort -n file.txt             # Numerical sort
sort -u file.txt             # Sort and remove duplicates
sort -k2 file.txt            # Sort by second column

# Remove duplicate lines
uniq file.txt
sort file.txt | uniq
sort file.txt | uniq -c      # Count occurrences
```
<div style="page-break-after:always;"></div>

### Text Filtering and Manipulation

```bash
# Extract columns from text
cut -d, -f1,3 file.csv       # Extract columns 1 and 3 from CSV
cut -c1-5 file.txt           # Extract characters 1-5 from each line

# Join files
join file1.txt file2.txt     # Join on common field

# Compare files
diff file1.txt file2.txt
diff -u file1.txt file2.txt  # Unified format
diff -y file1.txt file2.txt  # Side by side

# Translate characters
tr 'a-z' 'A-Z' < file.txt    # Convert lowercase to uppercase
tr -d '\r' < file.txt        # Remove carriage returns

# Split files
split -l 100 file.txt prefix # Split by lines
split -b 1M file.txt prefix  # Split by size

# Combine files
cat file1.txt file2.txt > combined.txt
cat *.txt > all.txt
```

## User Management
_Create, modify, and manage users and groups in Linux._

### User Information and Management

```bash
# Display current user
whoami

# Show user ID and groups
id
id username

# List logged-in users
who
w

# Show last logins
last
lastlog

# Change user password
passwd
passwd username  # As root
```
<div style="page-break-after:always;"></div>

### User Administration

```bash
# Create a new user
useradd username
useradd -m -s /bin/bash username  # Create home dir and set shell

# Create a new user interactively
adduser username

# Modify user account
usermod -L username       # Lock account
usermod -U username       # Unlock account
usermod -G group username # Set primary group
usermod -aG group username # Add to supplementary group

# Delete user
userdel username
userdel -r username  # Remove home directory too

# Switch user
su - username
su -                # Switch to root

# Run command as another user
sudo command
sudo -u username command
```

### Group Management

```bash
# List groups
groups
groups username

# Create a new group
groupadd groupname

# Modify group
groupmod -n newname oldname

# Delete group
groupdel groupname

# Add user to group
gpasswd -a username groupname

# Remove user from group
gpasswd -d username groupname
```
<div style="page-break-after:always;"></div>

## Permissions
_Understand and manage file system permissions and ownership in Linux._

### Basic Permissions

```bash
# Change file permissions
chmod 755 file.txt      # Using octal notation
chmod u+x file.txt      # Add execute permission for user
chmod g+w file.txt      # Add write permission for group
chmod o-r file.txt      # Remove read permission for others
chmod a+x file.txt      # Add execute permission for all

# Change ownership
chown user file.txt
chown user:group file.txt
chown -R user:group directory/  # Recursive

# Change group
chgrp group file.txt
chgrp -R group directory/  # Recursive

# Display file permissions
ls -l file.txt
```

### Special Permissions

```bash
# Set SUID (run as owner)
chmod u+s file
chmod 4755 file

# Set SGID (run as group/inherit group)
chmod g+s file
chmod g+s directory/ # New files inherit directory's group
chmod 2755 file

# Set sticky bit (restrict deletion)
chmod +t directory/
chmod 1777 directory/

# Set default permissions
umask 022  # Results in 755 for directories, 644 for files
```
<div style="page-break-after:always;"></div>

### Advanced Permissions

```bash
# Access control lists (ACLs)
getfacl file.txt
setfacl -m u:username:rwx file.txt  # Add user with permissions
setfacl -m g:groupname:rx file.txt  # Add group with permissions
setfacl -x u:username file.txt      # Remove user ACL
setfacl -b file.txt                 # Remove all ACLs

# Preserve permissions when copying
cp -p source.txt destination.txt
cp --preserve=mode,ownership,timestamps source.txt destination.txt
```

## Process Management
_Monitor, control, and manage running processes in Linux._

### Viewing Processes

```bash
# List processes
ps
ps aux          # Detailed view of all processes
ps -ef          # Full listing
ps --forest     # Show process tree

# Dynamic process monitoring
top
htop    # Enhanced version (might need installation)

# Show process tree
pstree
pstree -p   # Show PIDs

# List processes by a specific user
ps -u username
top -u username
```
<div style="page-break-after:always;"></div>

### Process Control

```bash
# Run command in background
command &
nohup command &   # Immune to hangups

# Job control
jobs              # List background jobs
fg                # Bring most recent job to foreground
fg %2             # Bring job #2 to foreground
bg                # Continue job in background
bg %2             # Continue job #2 in background
Ctrl+Z            # Suspend current process

# Kill processes
kill PID
kill -9 PID       # Force kill
killall process_name
pkill process_name
pkill -u username # Kill all processes by user

# Process priority
nice -n 10 command        # Run with lower priority
renice -n 10 -p PID      # Change priority of running process
```

### Monitoring Resource Usage

```bash
# Monitor memory usage
free
free -h           # Human readable
free -m           # In megabytes

# Check system load
uptime

# I/O statistics
iostat
iostat 2          # Update every 2 seconds

# Virtual memory statistics
vmstat
vmstat 2          # Update every 2 seconds

# Extended process monitoring
pidstat
pidstat -d 2      # Monitor disk I/O every 2 seconds

# Process resource usage
time command      # Measure execution time
```
<div style="page-break-after:always;"></div>

## System Information
_View and manage system resources, hardware, and configuration._

### System and Hardware Info

```bash
# System information
uname -a

# Hardware info
lshw
lshw -short

# CPU info
lscpu
cat /proc/cpuinfo

# Memory information
cat /proc/meminfo
free -h

# Disk and storage information
lsblk
df -h
du -h path/to/directory
du -sh path/to/directory    # Summary only
fdisk -l                    # List disk partitions

# PCI devices
lspci
lspci -v    # Verbose

# USB devices
lsusb
lsusb -v    # Verbose

# Block devices
blkid       # List block device attributes
```

### System Monitoring

```bash
# System uptime and load
uptime

# Current date and time
date

# System boot time
who -b

# System logging
dmesg
dmesg | grep -i error
dmesg -H    # Human readable with colors

# Load average graph
tload

# Check disk usage
df -h
df -i       # Check inodes usage

# Check directory size
du -h --max-depth=1 /path/to/directory
ncdu        # Interactive disk usage explorer (might need installation)
```
<div style="page-break-after:always;"></div>

### System Logs

```bash
# View system logs
cat /var/log/syslog
cat /var/log/messages

# View authentication logs
cat /var/log/auth.log
cat /var/log/secure      # RHEL/CentOS

# Kernel ring buffer
dmesg
dmesg -T    # Show human readable timestamps

# View boot logs
journalctl -b

# System journal (systemd)
journalctl
journalctl -u service_name
journalctl --since "2025-06-01"
journalctl --since "1 hour ago"

# Live log monitoring
tail -f /var/log/syslog
journalctl -f
```

## Package Management
_Install, update, and manage software packages on different Linux distributions._

### APT (Debian/Ubuntu)

```bash
# Update package lists
apt update

# Upgrade installed packages
apt upgrade
apt full-upgrade       # May remove packages if needed

# Search for a package
apt search package_name

# Show package information
apt show package_name

# Install a package
apt install package_name

# Remove a package
apt remove package_name
apt purge package_name     # Remove with config files

# Clean package cache
apt clean
apt autoclean

# List installed packages
apt list --installed
dpkg -l
```
<div style="page-break-after:always;"></div>

### YUM/DNF (RHEL/Fedora/CentOS)

```bash
# Update package lists and upgrade
dnf update
yum update      # Older versions

# Search for a package
dnf search package_name
yum search package_name

# Install a package
dnf install package_name
yum install package_name

# Remove a package
dnf remove package_name
yum remove package_name

# List installed packages
dnf list installed
yum list installed

# List available package groups
dnf group list
yum grouplist

# Clean package cache
dnf clean all
yum clean all
```

### Pacman (Arch Linux)

```bash
# Update package database and upgrade
pacman -Syu

# Search for a package
pacman -Ss package_name

# Install a package
pacman -S package_name

# Remove a package
pacman -R package_name
pacman -Rs package_name   # With dependencies

# List installed packages
pacman -Q
pacman -Qe    # Explicitly installed

# Clean package cache
pacman -Sc
```
<div style="page-break-after:always;"></div>

### Universal Package Management

```bash
# Flatpak
flatpak list
flatpak install <application>
flatpak update
flatpak uninstall <application>

# Snap
snap list
snap find <application>
snap install <application>
snap refresh <application>
snap remove <application>

# AppImage
# Make AppImage executable and run
chmod +x application.AppImage
./application.AppImage
```

## Network Operations
_Configure network interfaces, test connectivity, and diagnose network issues._

### Network Configuration

```bash
# Show network interfaces
ip a
ifconfig    # Legacy command

# Show routing table
ip route
route       # Legacy command

# Configure interface
ip addr add 192.168.1.10/24 dev eth0
ip addr del 192.168.1.10/24 dev eth0

# Bring interface up/down
ip link set eth0 up
ip link set eth0 down

# Configure DNS
cat /etc/resolv.conf
echo "nameserver 8.8.8.8" > /etc/resolv.conf

# Show network statistics
ip -s link
netstat -i
```
<div style="page-break-after:always;"></div>

### Network Testing and Diagnostics

```bash
# Test connectivity
ping google.com
ping -c 4 google.com    # Limit to 4 packets

# Trace route
traceroute google.com
tracepath google.com

# DNS lookup
dig google.com
dig google.com +short
nslookup google.com
host google.com

# Network scanning
nmap 192.168.1.0/24
nmap -p 22,80,443 192.168.1.1

# Check listening ports
netstat -tuln
ss -tuln
lsof -i    # List open Internet sockets

# Test port connectivity
nc -zv host.example.com 80
telnet host.example.com 80

# Download files
wget https://example.com/file.txt
curl -O https://example.com/file.txt
```

### Firewall Management (iptables/nftables)

```bash
# List firewall rules
iptables -L
iptables -L -n -v    # Numeric with details
nft list ruleset     # nftables

# Add rule to allow SSH
iptables -A INPUT -p tcp --dport 22 -j ACCEPT

# Block IP address
iptables -A INPUT -s 10.0.0.5 -j DROP

# Save iptables rules
iptables-save > /etc/iptables/rules.v4

# Restore iptables rules
iptables-restore < /etc/iptables/rules.v4
```
<div style="page-break-after:always;"></div>

## Compression and Archives
_Create, extract, and manage compressed files and archives in various formats._

### Basic Archive Operations

```bash
# Create tar archive
tar -cf archive.tar files/
tar -cf archive.tar file1 file2 dir1/

# List contents of tar archive
tar -tf archive.tar

# Extract tar archive
tar -xf archive.tar
tar -xf archive.tar -C /path/to/extract/

# Extract specific files
tar -xf archive.tar file1 file2
```

### Compression

```bash
# Create gzipped tar archive
tar -czf archive.tar.gz files/
tar -czf archive.tgz files/    # Alternative extension

# Create bzip2 tar archive
tar -cjf archive.tar.bz2 files/

# Create xz tar archive
tar -cJf archive.tar.xz files/

# Extract compressed archives
tar -xzf archive.tar.gz
tar -xjf archive.tar.bz2
tar -xJf archive.tar.xz

# Zip compression
zip -r archive.zip directory/
zip archive.zip file1 file2

# Unzip
unzip archive.zip
unzip archive.zip -d /path/to/extract/

# Create password-protected zip
zip -er archive.zip directory/
```
<div style="page-break-after:always;"></div>

### Other Archive Formats

```bash
# 7zip (requires p7zip package)
7z a archive.7z files/
7z x archive.7z

# RAR (requires rar/unrar package)
rar a archive.rar files/
unrar x archive.rar

# Create .gz file (single file)
gzip file.txt       # Creates file.txt.gz, removes original
gzip -k file.txt    # Keeps original file

# Decompress .gz file
gunzip file.txt.gz
gzip -d file.txt.gz

# Create .bz2 file
bzip2 file.txt
bzip2 -k file.txt   # Keeps original file

# Decompress .bz2 file
bunzip2 file.txt.bz2
bzip2 -d file.txt.bz2
```

## Searching and Finding
_Locate files and content in the Linux file system efficiently._

### Finding Files

```bash
# Find files by name
find /path -name "filename"
find /path -name "*.txt"
find /path -iname "*.TXT"    # Case insensitive

# Find by type
find /path -type f    # Regular files
find /path -type d    # Directories
find /path -type l    # Symbolic links

# Find by size
find /path -size +10M    # Larger than 10MB
find /path -size -1M     # Smaller than 1MB
find /path -size 5M      # Exactly 5MB

# Find by time
find /path -mtime -7     # Modified less than 7 days ago
find /path -atime +30    # Accessed more than 30 days ago
find /path -ctime 0      # Created/changed today
```
<div style="page-break-after:always;"></div>

### Advanced Finding

```bash
# Find and execute
find /path -name "*.log" -exec rm {} \;
find /path -name "*.txt" -exec grep "pattern" {} \;
find /path -name "*.txt" -exec cp {} /backup/ \;

# Find and execute with confirmation
find /path -name "*.tmp" -ok rm {} \;

# Find by permissions
find /path -perm 644
find /path -perm -u+x    # Executable by owner

# Find by owner/group
find /path -user username
find /path -group groupname

# Find empty files/directories
find /path -type f -empty
find /path -type d -empty

# Locate files (uses database)
locate filename
updatedb    # Update locate database
```

### Finding Content in Files

```bash
# Basic grep search
grep "pattern" file.txt
grep "pattern" file1.txt file2.txt
grep "pattern" *.txt

# Recursive grep search
grep -r "pattern" /path
grep -r --include="*.c" "main(" /path

# Case insensitive search
grep -i "pattern" file.txt

# Show context around matches
grep -C 3 "pattern" file.txt    # 3 lines before and after
grep -B 3 "pattern" file.txt    # 3 lines before
grep -A 3 "pattern" file.txt    # 3 lines after

# Count matches
grep -c "pattern" file.txt

# Show only filenames
grep -l "pattern" *.txt
```
<div style="page-break-after:always;"></div>

## Advanced Shell Features
_Take advantage of powerful shell capabilities to enhance your Linux command line experience._

### Redirections and Pipes

```bash
# Redirect stdout to file
command > file.txt      # Overwrite
command >> file.txt     # Append

# Redirect stderr
command 2> error.txt

# Redirect stdout and stderr to different files
command > output.txt 2> error.txt

# Redirect stdout and stderr to same file
command > all.txt 2>&1
command &> all.txt      # Shorthand

# Redirect stdin
command < input.txt

# Pipe output to another command
command1 | command2
ls | grep ".txt"
cat file.txt | grep "pattern" | sort

# Multiple commands
command1 && command2    # Run command2 if command1 succeeds
command1 || command2    # Run command2 if command1 fails
command1 ; command2     # Run command1 then command2

# Discard output
command > /dev/null
```

### Command Substitution

```bash
# Use command output in another command
echo "Today is $(date)"
files=$(ls)

# Alternative syntax (legacy)
echo "Today is `date`"

# Use in variable assignment
current_users=$(who | wc -l)
echo "There are $current_users users logged in."

# Use in loops
for file in $(find . -name "*.txt"); do
    echo "Processing $file"
done
```
<div style="page-break-after:always;"></div>

### Expansions and Substitutions

```bash
# Brace expansion
echo file{1,2,3}.txt    # file1.txt file2.txt file3.txt
echo file{1..5}.txt     # file1.txt file2.txt file3.txt file4.txt file5.txt
echo {a..e}             # a b c d e
echo {01..10}           # 01 02 03 04 05 06 07 08 09 10
mkdir -p project/{src,doc,bin}

# Parameter expansion
echo ${HOME}
echo ${PATH}
echo ${NAME:-default}   # Use default if NAME not set
echo ${NAME:=default}   # Set NAME to default if not set and use it
echo ${NAME:+alternative}  # Use alternative if NAME is set
echo ${NAME:0:5}        # Extract first 5 characters

# Pattern matching
echo ${filename%.txt}   # Remove .txt extension
echo ${filename#prefix} # Remove prefix from start
```

### Aliases and Functions

```bash
# Create aliases
alias ll='ls -la'
alias cls='clear'
alias grep='grep --color=auto'

# List all aliases
alias

# Remove alias
unalias ll

# Create functions
mcd() {
    mkdir -p "$1" && cd "$1"
}

extract() {
    if [ -f "$1" ]; then
        case $1 in
            *.tar.bz2)  tar xjf $1   ;;
            *.tar.gz)   tar xzf $1   ;;
            *.bz2)      bunzip2 $1   ;;
            *.rar)      unrar x $1   ;;
            *.gz)       gunzip $1    ;;
            *.tar)      tar xf $1    ;;
            *.tbz2)     tar xjf $1   ;;
            *.tgz)      tar xzf $1   ;;
            *.zip)      unzip $1     ;;
            *.Z)        uncompress $1;;
            *)          echo "'$1' cannot be extracted" ;;
        esac
    else
        echo "'$1' is not a valid file"
    fi
}
```
<div style="page-break-after:always;"></div>

## Shell Scripting
_Create and execute scripts to automate tasks in Linux._

### Basic Scripting

```bash
# Simple script example (myscript.sh)
#!/bin/bash
# My first script
echo "Hello, world!"
echo "Current date is $(date)"
echo "User: $USER"
echo "Working directory: $PWD"

# Make script executable
chmod +x myscript.sh

# Run script
./myscript.sh
bash myscript.sh
```

### Variables and Parameters

```bash
# Variable declaration and usage
NAME="Linux"
echo "Hello, $NAME"

# Script parameters
# In myscript.sh:
#!/bin/bash
echo "Script name: $0"
echo "First parameter: $1"
echo "Second parameter: $2"
echo "All parameters: $@"
echo "Number of parameters: $#"

# Reading input
read -p "Enter your name: " USERNAME
echo "Hello, $USERNAME"

# Command substitution
USERS=$(who | wc -l)
echo "Number of users: $USERS"

# Arithmetic
RESULT=$((5 + 3))
echo "5 + 3 = $RESULT"
```
<div style="page-break-after:always;"></div>

### Control Structures

```bash
# Conditional statements
if [ "$1" = "hello" ]; then
    echo "Hello to you too!"
elif [ "$1" = "bye" ]; then
    echo "Goodbye!"
else
    echo "I don't understand."
fi

# File conditions
if [ -f /etc/passwd ]; then
    echo "File exists"
fi
if [ -d /etc ]; then
    echo "Directory exists"
fi

# String comparisons
if [ "$STR1" = "$STR2" ]; then
    echo "Strings are equal"
fi
if [ -z "$STR" ]; then
    echo "String is empty"
fi

# Numeric comparisons
if [ "$NUM1" -eq "$NUM2" ]; then
    echo "Numbers are equal"
fi
if [ "$NUM1" -gt "$NUM2" ]; then
    echo "NUM1 is greater than NUM2"
fi
```

### Loops

```bash
# For loop
for i in 1 2 3 4 5; do
    echo "Number: $i"
done

# For loop with range
for i in {1..5}; do
    echo "Number: $i"
done

# C-style for loop
for ((i=0; i<5; i++)); do
    echo "Count: $i"
done

# While loop
count=0
while [ $count -lt 5 ]; do
    echo "Count: $count"
    ((count++))
done

# Until loop
count=5
until [ $count -lt 1 ]; do
    echo "Countdown: $count"
    ((count--))
done

# Loop with break and continue
for i in {1..10}; do
    if [ $i -eq 3 ]; then
        continue
    elif [ $i -eq 8 ]; then
        break
    fi
    echo "Number: $i"
done
```
<div style="page-break-after:always;"></div>

### Functions

```bash
# Define function
function greet {
    echo "Hello, $1!"
}

# Alternative syntax
say_bye() {
    echo "Goodbye, $1!"
}

# Call functions
greet "World"
say_bye "User"

# Function with return value
is_even() {
    if [ $(($1 % 2)) -eq 0 ]; then
        return 0  # True
    else
        return 1  # False
    fi
}

# Use function return value
if is_even 4; then
    echo "4 is even"
fi

# Function with output
get_square() {
    echo $(($1 * $1))
}

# Capture function output
result=$(get_square 5)
echo "5 squared is $result"
```

## Linux Workflow Examples
_Common patterns and procedures for efficient system administration and development with Linux commands._

### File Processing Workflow

```bash
#!/bin/bash
# Process log files workflow

# Set variables
LOG_DIR="/var/log"
ARCHIVE_DIR="/var/archive/logs"
DATE=$(date +%Y%m%d)

# Create archive directory if it doesn't exist
mkdir -p "$ARCHIVE_DIR"

# Find log files older than 7 days
find "$LOG_DIR" -name "*.log" -type f -mtime +7 | while read -r logfile; do
    # Get just the filename
    filename=$(basename "$logfile")
    
    # Compress the log file
    gzip -c "$logfile" > "$ARCHIVE_DIR/${filename}_${DATE}.gz"
    
    # Verify the archive was created successfully
    if [ $? -eq 0 ]; then
        echo "Successfully archived: $logfile"
        # Truncate the original log file
        cat /dev/null > "$logfile"
    else
        echo "Failed to archive: $logfile"
    fi
done

# Remove archives older than 90 days
find "$ARCHIVE_DIR" -name "*.gz" -type f -mtime +90 -delete
```
<div style="page-break-after:always;"></div>

### System Monitoring Script

```bash
#!/bin/bash
# System resource monitoring script

# Output file
OUTFILE="/tmp/system_health_$(date +%Y%m%d).log"

# Header
echo "System Health Check - $(date)" > "$OUTFILE"
echo "=================================" >> "$OUTFILE"

# System uptime
echo -e "\n--- System Uptime ---" >> "$OUTFILE"
uptime >> "$OUTFILE"

# Memory usage
echo -e "\n--- Memory Usage ---" >> "$OUTFILE"
free -h >> "$OUTFILE"

# Disk usage
echo -e "\n--- Disk Usage ---" >> "$OUTFILE"
df -h | grep -v "tmpfs" >> "$OUTFILE"

# Most resource-intensive processes
echo -e "\n--- Top CPU Processes ---" >> "$OUTFILE"
ps aux --sort=-%cpu | head -11 >> "$OUTFILE"

echo -e "\n--- Top Memory Processes ---" >> "$OUTFILE"
ps aux --sort=-%mem | head -11 >> "$OUTFILE"

# Recent logins
echo -e "\n--- Recent Logins ---" >> "$OUTFILE"
last | head -10 >> "$OUTFILE"

# Check load average
LOAD=$(uptime | awk -F'load average:' '{print $2}' | cut -d, -f1 | tr -d ' ')
LOAD_INT=${LOAD%.*}

if [ "$LOAD_INT" -gt 2 ]; then
    echo -e "\n!!! HIGH SYSTEM LOAD ALERT !!!" >> "$OUTFILE"
    echo "Current load: $LOAD" >> "$OUTFILE"
fi

echo -e "\nReport completed at $(date)" >> "$OUTFILE"

# Optionally email the report
# mail -s "System Health Check" admin@example.com < "$OUTFILE"

echo "Report saved to $OUTFILE"
```
<div style="page-break-after:always;"></div>

### Backup Script

```bash
#!/bin/bash
# Simple backup script

# Configuration
SRC_DIR="/home/user/important_data"
BACKUP_DIR="/mnt/backup"
BACKUP_FILE="backup_$(date +%Y%m%d_%H%M%S).tar.gz"
LOG_FILE="/var/log/backup.log"

# Ensure backup directory exists
mkdir -p "$BACKUP_DIR"

# Start logging
echo "Backup started: $(date)" >> "$LOG_FILE"

# Create the backup
echo "Creating backup of $SRC_DIR..." >> "$LOG_FILE"
tar -czf "$BACKUP_DIR/$BACKUP_FILE" -C "$(dirname "$SRC_DIR")" "$(basename "$SRC_DIR")" 2>> "$LOG_FILE"

# Check if backup was successful
if [ $? -eq 0 ]; then
    echo "Backup completed successfully: $BACKUP_DIR/$BACKUP_FILE" >> "$LOG_FILE"
    echo "Backup size: $(du -h "$BACKUP_DIR/$BACKUP_FILE" | cut -f1)" >> "$LOG_FILE"
    
    # Remove backups older than 30 days
    echo "Removing old backups..." >> "$LOG_FILE"
    find "$BACKUP_DIR" -name "backup_*.tar.gz" -type f -mtime +30 -delete
    find "$BACKUP_DIR" -name "backup_*.tar.gz" -type f -mtime +30 -exec echo "Removed: {}" \; >> "$LOG_FILE"
else
    echo "ERROR: Backup failed!" >> "$LOG_FILE"
    # Notify administrator about failure
    # mail -s "Backup Failed" admin@example.com < "$LOG_FILE"
fi

echo "Backup process finished: $(date)" >> "$LOG_FILE"
echo "----------------------------------------" >> "$LOG_FILE"
```

## Best Practices
_Guidelines for efficient and secure Linux command line usage._

### Security Best Practices

```bash
# Set secure permissions
chmod 600 ~/.ssh/id_rsa        # Private key
chmod 700 ~/.ssh               # SSH directory
chmod 644 ~/public_html/*.html # Web files

# Check open ports
ss -tuln
netstat -tuln

# Monitor login attempts
lastb         # Failed login attempts
grep "Failed password" /var/log/auth.log

# Set up SSH key authentication
ssh-keygen -t ed25519 -C "your_email@example.com"
ssh-copy-id user@remote-host

# Use sudo instead of root login
sudo command
sudo -i   # Interactive root shell if needed

# Check for rootkits (requires installation)
rkhunter --check
chkrootkit
```
<div style="page-break-after:always;"></div>

### Performance Optimization

```bash
# Find largest files/directories
du -h --max-depth=1 /path | sort -hr

# Find processes using most CPU
ps aux --sort=-%cpu | head

# Find processes using most memory
ps aux --sort=-%mem | head

# Check I/O usage
iotop     # May need installation
iostat 2  # Update every 2 seconds

# Clear cache
echo 3 | sudo tee /proc/sys/vm/drop_caches  # Free page cache, dentries and inodes

# Limit process resources
nice -n 19 command        # Run with lowest priority
cpulimit -p 1234 -l 50    # Limit process to 50% CPU

# For fast file search
find / -name "*.log" -type f 2>/dev/null      # Suppress errors
locate "*.log" | grep "myapp"                 # Pre-indexed search
```

### Command Line Efficiency

```bash
# History navigation
Ctrl+R         # Search command history
!123           # Run command number 123
!string        # Run last command starting with "string"
!!             # Repeat last command
!$             # Last argument of previous command
Alt+.          # Insert last argument of previous command

# Directory navigation
cd -           # Go to previous directory
pushd /path    # Push directory to stack and go to it
popd           # Pop directory from stack and go to it
dirs           # Show directory stack

# Command shortcuts
alias ll='ls -la'
alias ..='cd ..'
alias ...='cd ../..'
alias update='sudo apt update && sudo apt upgrade -y'

# Use wildcards efficiently
ls *.{jpg,png}     # Match multiple extensions
rm file[0-9].txt   # Match range of numbers
mv file?.txt dir/  # Match single character
```