# SSH Command Cheat Sheet

This document provides a comprehensive overview of essential SSH (Secure Shell) commands, with descriptions and examples for each.

## Table of Contents

- [Installation and Setup](#installation-and-setup)
- [Basic SSH Commands](#basic-ssh-commands)
- [Authentication Methods](#authentication-methods)
- [SSH Configuration](#ssh-configuration)
- [Port Forwarding and Tunneling](#port-forwarding-and-tunneling)
- [File Transfer with SSH](#file-transfer-with-ssh)
- [Remote Command Execution](#remote-command-execution)
- [SSH Keys Management](#ssh-keys-management)
- [SSH Agent](#ssh-agent)
- [SSH Security](#ssh-security)
- [Advanced SSH Features](#advanced-ssh-features)
- [SSH Server Management](#ssh-server-management)
- [Troubleshooting](#troubleshooting)
- [SSH Workflow Examples](#ssh-workflow-examples)
- [Best Practices](#best-practices)

## Installation and Setup
_Install and configure SSH clients and servers on various operating systems._

### Installing SSH

```powershell
# Windows: Install OpenSSH Client using PowerShell (Windows 10 1809+)
Add-WindowsCapability -Online -Name OpenSSH.Client~~~~0.0.1.0

# Windows: Install OpenSSH Server using PowerShell (optional)
Add-WindowsCapability -Online -Name OpenSSH.Server~~~~0.0.1.0

# Check SSH version
ssh -V

# Linux/Ubuntu install SSH client
# sudo apt update
# sudo apt install openssh-client

# Linux/Ubuntu install SSH server
# sudo apt update
# sudo apt install openssh-server

# Linux check SSH service status
# sudo systemctl status ssh
```
<div style="page-break-after:always;"></div>

### Initial Setup

```powershell
# Windows: Start SSH service
Start-Service sshd

# Windows: Configure SSH service to start automatically
Set-Service -Name sshd -StartupType 'Automatic'

# Windows: Check firewall rule for SSH
Get-NetFirewallRule -Name *ssh*

# Windows: Add SSH firewall rule if needed
New-NetFirewallRule -Name sshd -DisplayName 'OpenSSH Server (sshd)' -Enabled True -Direction Inbound -Protocol TCP -Action Allow -LocalPort 22

# Generate SSH key pair (interactive)
ssh-keygen

# Generate SSH key with specific type and bits
ssh-keygen -t ed25519 -C "your_email@example.com"
ssh-keygen -t rsa -b 4096 -C "your_email@example.com"
```

## Basic SSH Commands
_Connect to remote servers and manage SSH connections._

### Connecting to Servers

```powershell
# Basic SSH connection
ssh username@hostname

# Connect to specific port
ssh username@hostname -p 2222

# Connect with specific identity file (private key)
ssh -i C:\Users\username\.ssh\id_rsa username@hostname

# Connect with verbose output for debugging
ssh -v username@hostname
ssh -vv username@hostname  # More verbose
ssh -vvv username@hostname  # Most verbose

# Connect with compression
ssh -C username@hostname

# Connect with specific cipher
ssh -c aes128-ctr username@hostname
```
<div style="page-break-after:always;"></div>

### SSH Session Management

```powershell
# Keep SSH connection alive
ssh -o ServerAliveInterval=60 username@hostname

# Disconnect from SSH session
# Press Enter, then ~, then .

# Background the current session
# Press Enter, then ~, then z

# List SSH sessions
# Press Enter, then ~, then #

# Switch to next session
# Press Enter, then ~, then n

# Reconnect to a session after network issue
ssh -o ConnectionAttempts=10 -o ConnectTimeout=30 username@hostname
```

## Authentication Methods
_Different ways to authenticate with SSH servers._

### Password Authentication

```powershell
# Default password authentication
ssh username@hostname
# You will be prompted for password

# Disable password authentication
ssh -o PasswordAuthentication=no username@hostname

# Connect with keyboard-interactive authentication
ssh -o PreferredAuthentications=keyboard-interactive username@hostname
```
<div style="page-break-after:always;"></div>

### Key-based Authentication

```powershell
# Generate a new key pair
ssh-keygen -t ed25519

# Copy public key to server (interactive method)
ssh-copy-id username@hostname

# Manual method if ssh-copy-id is not available (Windows)
# 1. Display your public key
cat C:\Users\username\.ssh\id_ed25519.pub

# 2. Copy the output and add it to ~/.ssh/authorized_keys on remote server
# Example command to run on server:
# mkdir -p ~/.ssh && chmod 700 ~/.ssh
# echo "ssh-ed25519 AAAA..." >> ~/.ssh/authorized_keys
# chmod 600 ~/.ssh/authorized_keys

# Connect using key authentication
ssh -i C:\Users\username\.ssh\id_ed25519 username@hostname
```

## SSH Configuration
_Configure SSH client and server settings for easier and more secure connections._

### Client Configuration File

```powershell
# Create/edit SSH config file
notepad C:\Users\username\.ssh\config

# Example SSH config file content
# Host example
#   HostName example.com
#   User username
#   Port 22
#   IdentityFile C:\Users\username\.ssh\id_rsa
#   ForwardX11 no
#   ServerAliveInterval 60

# Example with hostname aliases
# Host dev
#   HostName 192.168.1.100
#   User developer
#   Port 2222
#   IdentityFile C:\Users\username\.ssh\dev_key

# Host pattern example
# Host *.example.com
#   User admin
#   IdentityFile C:\Users\username\.ssh\example_key
```
<div style="page-break-after:always;"></div>

### Server Configuration

```powershell
# Windows: Edit SSH server config
notepad C:\ProgramData\ssh\sshd_config

# Linux/macOS: Edit SSH server config
# sudo nano /etc/ssh/sshd_config

# Important server configuration options
# Port 22
# PasswordAuthentication yes
# PermitRootLogin no
# PubkeyAuthentication yes
# X11Forwarding no
# MaxAuthTries 6
# ClientAliveInterval 300
# ClientAliveCountMax 3

# Windows: Restart SSH server after config changes
Restart-Service sshd

# Linux: Restart SSH server after config changes
# sudo systemctl restart sshd
```

## Port Forwarding and Tunneling
_Create secure tunnels for accessing remote services and bypassing network restrictions._

### Local Port Forwarding

```powershell
# Forward local port to remote server
# Makes remote-host:3000 available at localhost:8080
ssh -L 8080:remote-host:3000 username@ssh-server

# Forward local port to remote server in background
ssh -fN -L 8080:remote-host:3000 username@ssh-server

# Forward multiple ports
ssh -L 8080:remote-host:80 -L 8443:remote-host:443 username@ssh-server

# Forward with specific binding address (only localhost can connect)
ssh -L localhost:8080:remote-host:80 username@ssh-server

# Forward with any interface binding (other machines can connect to your forwarded port)
ssh -L 0.0.0.0:8080:remote-host:80 username@ssh-server
```
<div style="page-break-after:always;"></div>

### Remote Port Forwarding

```powershell
# Forward remote port to local server
# Makes localhost:3000 available at ssh-server:8080
ssh -R 8080:localhost:3000 username@ssh-server

# Forward remote port in background
ssh -fN -R 8080:localhost:3000 username@ssh-server

# Forward remote port with binding to all interfaces on server
# Requires 'GatewayPorts yes' in sshd_config
ssh -R 0.0.0.0:8080:localhost:3000 username@ssh-server

# Forward multiple remote ports
ssh -R 8080:localhost:3000 -R 8443:localhost:3001 username@ssh-server
```

### Dynamic Port Forwarding (SOCKS Proxy)

```powershell
# Create a SOCKS proxy on port 1080
ssh -D 1080 username@ssh-server

# Create SOCKS proxy in background
ssh -fN -D 1080 username@ssh-server

# Create SOCKS proxy with specific binding address
ssh -D localhost:1080 username@ssh-server

# Create SOCKS proxy with compression
ssh -C -D 1080 username@ssh-server

# Create SOCKS5 proxy
ssh -D 1080 -N username@ssh-server
```
<div style="page-break-after:always;"></div>

## File Transfer with SSH
_Transfer files securely between local and remote systems using SSH protocols._

### SCP (Secure Copy)

```powershell
# Copy local file to remote server
scp C:\local\path\file.txt username@hostname:/remote/path/

# Copy remote file to local machine
scp username@hostname:/remote/path/file.txt C:\local\path\

# Copy multiple files
scp file1.txt file2.txt username@hostname:/remote/path/

# Copy directory recursively
scp -r C:\local\directory username@hostname:/remote/path/

# Copy with different port
scp -P 2222 file.txt username@hostname:/remote/path/

# Copy with verbose output
scp -v file.txt username@hostname:/remote/path/

# Copy with specific identity file
scp -i C:\Users\username\.ssh\id_rsa file.txt username@hostname:/remote/path/
```

### SFTP (SSH File Transfer Protocol)

```powershell
# Start SFTP session
sftp username@hostname

# SFTP with different port
sftp -P 2222 username@hostname

# SFTP commands (after connection)
# pwd         # Print remote working directory
# lpwd        # Print local working directory
# ls          # List remote files
# lls         # List local files
# cd dir      # Change remote directory
# lcd dir     # Change local directory
# get file    # Download file
# put file    # Upload file
# mget *.txt  # Download multiple files
# mput *.txt  # Upload multiple files
# exit        # Exit SFTP session
```
<div style="page-break-after:always;"></div>

### RSYNC over SSH (Linux/macOS)

```powershell
# Windows: Use Linux subsystem or Git Bash for rsync
# Basic rsync over SSH
# rsync -av -e ssh /local/path/ username@hostname:/remote/path/

# Rsync with compression
# rsync -avz -e ssh /local/path/ username@hostname:/remote/path/

# Rsync with progress display
# rsync -avP -e ssh /local/path/ username@hostname:/remote/path/

# Rsync with custom port
# rsync -av -e "ssh -p 2222" /local/path/ username@hostname:/remote/path/

# Rsync dry run (test without transferring)
# rsync -avzn -e ssh /local/path/ username@hostname:/remote/path/

# Rsync with deletion (make destination match source)
# rsync -avz --delete -e ssh /local/path/ username@hostname:/remote/path/
```

## Remote Command Execution
_Run commands on remote servers without opening a full SSH session._

### Simple Command Execution

```powershell
# Execute single command
ssh username@hostname "ls -la"

# Execute multiple commands
ssh username@hostname "cd /var/log && ls -la | grep error"

# Execute with sudo (will prompt for password)
ssh username@hostname "sudo systemctl restart nginx"

# Execute with sudo (with password in line, less secure)
ssh username@hostname "echo 'password' | sudo -S systemctl restart nginx"

# Execute command with specific environment variables
ssh username@hostname "export PATH=/usr/local/bin:\$PATH && node -v"
```
<div style="page-break-after:always;"></div>

### Command Execution with Options

```powershell
# Execute with pseudo-terminal allocation
ssh -t username@hostname "top"

# Execute without pseudo-terminal allocation
ssh -T username@hostname "ls -la > file_list.txt"

# Execute with X11 forwarding
ssh -X username@hostname "gedit"

# Execute in background
ssh -f username@hostname "sleep 60 && echo done > /tmp/done.txt"

# Execute with timeout
ssh -o ConnectTimeout=10 username@hostname "long-running-command"
```

## SSH Keys Management
_Create, manage, and secure SSH key pairs for authentication._

### Key Generation

```powershell
# Generate default RSA key pair
ssh-keygen

# Generate Ed25519 key (recommended for new keys)
ssh-keygen -t ed25519 -C "comment or email"

# Generate RSA key with 4096 bits
ssh-keygen -t rsa -b 4096 -C "comment or email"

# Generate key with specific filename
ssh-keygen -f C:\Users\username\.ssh\custom_key

# Generate key with no passphrase (less secure)
ssh-keygen -t ed25519 -N "" -C "comment"

# Generate key with custom comment
ssh-keygen -t ed25519 -C "username@project-deploy-key"
```
<div style="page-break-after:always;"></div>

### Key Management

```powershell
# List public keys
ls C:\Users\username\.ssh\*.pub

# Display public key content
cat C:\Users\username\.ssh\id_ed25519.pub

# Format conversion (OpenSSH to PEM)
ssh-keygen -e -m PEM -f C:\Users\username\.ssh\id_rsa > C:\Users\username\.ssh\id_rsa.pem

# Format conversion (PEM to OpenSSH)
ssh-keygen -i -m PEM -f C:\Users\username\.ssh\id_rsa.pem > C:\Users\username\.ssh\id_rsa

# Change key passphrase
ssh-keygen -p -f C:\Users\username\.ssh\id_ed25519

# Verify key fingerprint
ssh-keygen -l -f C:\Users\username\.ssh\id_ed25519.pub

# Show visual art representation of key (useful for verification)
ssh-keygen -lv -f C:\Users\username\.ssh\id_ed25519.pub
```

## SSH Agent
_Use SSH agent to securely store and manage private keys for authentication._

### SSH Agent Basics

```powershell
# Start SSH agent in PowerShell
Start-Service ssh-agent
Get-Service ssh-agent

# Add key to agent
ssh-add C:\Users\username\.ssh\id_ed25519

# List keys in agent
ssh-add -l

# List keys with fingerprints
ssh-add -L

# Remove specific key from agent
ssh-add -d C:\Users\username\.ssh\id_ed25519

# Remove all keys from agent
ssh-add -D

# Lock agent with password
ssh-add -x

# Unlock agent
ssh-add -X
```
<div style="page-break-after:always;"></div>

### Agent Forwarding

```powershell
# Connect with agent forwarding
ssh -A username@hostname

# Enable agent forwarding in config file
# Host example.com
#   ForwardAgent yes

# Connect to host1 and then host2 using forwarded key
ssh -A username@host1
# Then from host1:
# ssh username@host2
```

## SSH Security
_Security settings and practices for SSH connections._

### Security Settings

```powershell
# Use only specific authentication methods
ssh -o PreferredAuthentications=publickey,keyboard-interactive username@hostname

# Disable host key checking (INSECURE - use with caution)
ssh -o StrictHostKeyChecking=no username@hostname

# Check host key before connecting
ssh-keygen -F hostname

# Remove old host key
ssh-keygen -R hostname

# Use stronger ciphers
ssh -c aes256-gcm@openssh.com username@hostname

# Use trusted X11 forwarding (more secure)
ssh -Y username@hostname

# Disable X11 forwarding
ssh -x username@hostname

# Connect with specific security level
ssh -o MACs=hmac-sha2-512 username@hostname
```
<div style="page-break-after:always;"></div>

### Managing Known Hosts

```powershell
# View known hosts file
cat C:\Users\username\.ssh\known_hosts

# Clear all known hosts
del C:\Users\username\.ssh\known_hosts
# or
echo $null > C:\Users\username\.ssh\known_hosts

# Scan and add host key
ssh-keyscan -t rsa hostname >> C:\Users\username\.ssh\known_hosts

# Verify host key fingerprint
ssh-keygen -lf C:\Users\username\.ssh\known_hosts -F hostname

# Add visual fingerprint of host key (more secure for verification)
ssh-keyscan hostname | ssh-keygen -lv -f -
```

## Advanced SSH Features
_Advanced features and shortcuts for power users._

### Advanced Connection Options

```powershell
# SSH multiplexing - create control socket
ssh -M -S C:\Users\username\.ssh\controlmaster-%r@%h:%p username@hostname

# Use existing control socket
ssh -S C:\Users\username\.ssh\controlmaster-%r@%h:%p username@hostname

# Check control socket status
ssh -O check -S C:\Users\username\.ssh\controlmaster-%r@%h:%p username@hostname

# Exit multiplexing session
ssh -O exit -S C:\Users\username\.ssh\controlmaster-%r@%h:%p username@hostname

# Configure multiplexing in config file
# ControlMaster auto
# ControlPath C:\Users\username\.ssh\cm-%r@%h:%p
# ControlPersist 10m

# Escape characters during session
# ~? - List all escape sequences
# ~. - Disconnect
# ~^Z - Background session
# ~# - List forwardings
# ~& - Background ssh at logout
# ~B - Send BREAK
```
<div style="page-break-after:always;"></div>

### Advanced Port Forwarding

```powershell
# X11 forwarding (for GUI applications)
ssh -X username@hostname

# Secure X11 forwarding (trusted)
ssh -Y username@hostname

# Escape character forwarding (useful for telnet/ssh inside ssh)
ssh -e ^ username@hostname

# X11 and agent forwarding
ssh -XA username@hostname

# VNC display forwarding
ssh -L 5901:localhost:5900 username@hostname

# Forward web traffic through SOCKS proxy
# 1. Set up proxy:
ssh -D 8080 username@hostname
# 2. Configure browser to use SOCKS proxy localhost:8080
```

## SSH Server Management
_Configure, secure, and manage SSH servers._

### Server Configuration

```powershell
# Windows: Edit SSH server configuration
notepad C:\ProgramData\ssh\sshd_config

# Windows: Restart SSH service after config changes
Restart-Service sshd

# Common server config options (Linux):
# Port 22
# PermitRootLogin no
# PasswordAuthentication no
# PubkeyAuthentication yes
# MaxAuthTries 6
# MaxStartups 10:30:100
# AllowUsers user1 user2
# DenyUsers user3 user4
# AuthorizedKeysFile .ssh/authorized_keys
```
<div style="page-break-after:always;"></div>

### Server Management Commands (Windows)

```powershell
# Start SSH server
Start-Service sshd

# Stop SSH server
Stop-Service sshd

# Check SSH server status
Get-Service sshd

# Configure SSH server to start automatically
Set-Service -Name sshd -StartupType 'Automatic'

# Check firewall rules
Get-NetFirewallRule -Name *ssh*

# Enable SSH in firewall
New-NetFirewallRule -Name sshd -DisplayName 'OpenSSH Server (sshd)' -Enabled True -Direction Inbound -Protocol TCP -Action Allow -LocalPort 22

# View SSH server event logs
Get-WinEvent -LogName Microsoft-Windows-SSHd/Operational
```

## Troubleshooting
_Diagnose and fix common SSH connection and authentication problems._

### Connection Issues

```powershell
# Debug connection with verbose output
ssh -v username@hostname
ssh -vv username@hostname  # More verbose
ssh -vvv username@hostname  # Most verbose

# Check if port is open
Test-NetConnection -ComputerName hostname -Port 22

# Test connection without executing commands
ssh -T username@hostname

# Test with different key exchange algorithms
ssh -o KexAlgorithms=diffie-hellman-group14-sha1 username@hostname

# Test with different ciphers
ssh -o Ciphers=aes128-ctr username@hostname

# Test with TCP keepalives
ssh -o TCPKeepAlive=yes username@hostname

# Specify connection timeout
ssh -o ConnectTimeout=10 username@hostname
```
<div style="page-break-after:always;"></div>

### Authentication Issues

```powershell
# Check permission on private key (Linux/macOS)
# chmod 600 ~/.ssh/id_rsa

# Debug authentication issues
ssh -v username@hostname

# Check public key on server
# Server command: grep "$(cat ~/.ssh/id_ed25519.pub)" ~/.ssh/authorized_keys

# Try with keyboard-interactive auth only
ssh -o PreferredAuthentications=keyboard-interactive username@hostname

# Try with password auth only
ssh -o PreferredAuthentications=password username@hostname

# Try with publickey auth only
ssh -o PreferredAuthentications=publickey username@hostname

# Test specific identity file
ssh -v -i C:\Users\username\.ssh\id_ed25519 username@hostname

# Check for certificate based problems
Get-AuthenticodeSignature C:\Windows\System32\OpenSSH\ssh.exe
```

## SSH Workflow Examples
_Common patterns and procedures for using SSH effectively in different scenarios._

### Web Server Management Workflow

```powershell
# Create shortcut to server in SSH config
# In C:\Users\username\.ssh\config:
# Host webserver
#   HostName example.com
#   User admin
#   Port 22
#   IdentityFile C:\Users\username\.ssh\webserver_key

# Connect to server
ssh webserver

# Deploy code with single command
ssh webserver "cd /var/www/site && git pull origin main && systemctl restart nginx"

# Edit config file remotely with local editor
ssh -t webserver "nano /etc/nginx/sites-available/default"

# Backup remote config to local machine
scp webserver:/etc/nginx/nginx.conf C:\backups\nginx-$(Get-Date -Format "yyyyMMdd").conf

# Monitor logs remotely
ssh -t webserver "tail -f /var/log/nginx/error.log"
```
<div style="page-break-after:always;"></div>

### Database Access Through SSH Tunnel

```powershell
# Create SSH tunnel for MySQL
ssh -L 3306:localhost:3306 username@db-server -N

# Now connect MySQL client to localhost:3306

# Create SSH tunnel for PostgreSQL
ssh -L 5432:localhost:5432 username@db-server -N

# Create SSH tunnel through jump host
ssh -L 3306:db-internal:3306 username@jump-server -N

# Create multiple tunnels in background
ssh -fN -L 3306:db1:3306 -L 5432:db2:5432 username@jump-server

# Kill background SSH session
Get-Process -Name ssh | Where-Object { $_.CommandLine -like "*jump-server*" } | Stop-Process
```

### Automated Deployments with SSH Keys

```powershell
# Generate deployment key (no passphrase for automation)
ssh-keygen -t ed25519 -f C:\deployment\deploy_key -N "" -C "deployment@example.com"

# Add deployment key to server
ssh-copy-id -i C:\deployment\deploy_key.pub username@hostname

# Create script to deploy with key
$deployScript = @"
ssh -i C:\deployment\deploy_key username@hostname "
  cd /var/www/app && 
  git pull origin main && 
  npm ci && 
  npm run build && 
  pm2 restart app
"
"@

# Save and run deployment script
$deployScript | Out-File -FilePath C:\deployment\deploy.ps1
```
<div style="page-break-after:always;"></div>

## Best Practices
_Guidelines for secure and efficient SSH usage._

### Security Best Practices

```powershell
# Use SSH key authentication instead of passwords

# Generate strong keys using Ed25519 or RSA 4096 bits
ssh-keygen -t ed25519 -C "your_email@example.com"
ssh-keygen -t rsa -b 4096 -C "your_email@example.com"

# Use passphrase to protect private keys

# Set secure permissions on SSH folders and keys
# Linux/macOS:
# chmod 700 ~/.ssh
# chmod 600 ~/.ssh/id_ed25519
# chmod 644 ~/.ssh/id_ed25519.pub
# chmod 600 ~/.ssh/config

# Disable unused authentication methods in SSH server
# PasswordAuthentication no
# ChallengeResponseAuthentication no
# KbdInteractiveAuthentication no

# Configure SSH to use only strong algorithms
# In ssh_config or at connection time:
# Ciphers aes256-gcm@openssh.com,aes128-gcm@openssh.com,aes256-ctr,aes192-ctr,aes128-ctr
# MACs hmac-sha2-512-etm@openssh.com,hmac-sha2-256-etm@openssh.com,hmac-sha2-512,hmac-sha2-256
# KexAlgorithms curve25519-sha256@libssh.org,diffie-hellman-group-exchange-sha256

# Use key rotation for important systems
```
<div style="page-break-after:always;"></div>

### Efficiency Best Practices

```powershell
# Configure SSH config file for frequent connections
# Host *
#   ServerAliveInterval 60
#   ServerAliveCountMax 5
#   ControlMaster auto
#   ControlPath ~/.ssh/control-%r@%h:%p
#   ControlPersist 10m

# Use aliases for common commands
function ssh-tunnel-db { ssh -L 3306:localhost:3306 username@dbserver -N }
# Now just run ssh-tunnel-db

# Keep SSH agent running to avoid multiple passphrase entries
# For Windows PowerShell profile:
if (!(Get-Service ssh-agent -ErrorAction SilentlyContinue).Status -eq 'Running') {
    Start-Service ssh-agent
}

# Use aliases in SSH config file
# Host dev
#   HostName dev-server.example.com
#   User developer
#   Port 22
#   IdentityFile ~/.ssh/dev_key
```

### Organization Best Practices

```powershell
# Use separate keys for different purposes
ssh-keygen -t ed25519 -f C:\Users\username\.ssh\personal_key -C "personal@email.com"
ssh-keygen -t ed25519 -f C:\Users\username\.ssh\work_key -C "work@company.com"
ssh-keygen -t ed25519 -f C:\Users\username\.ssh\github_key -C "github@email.com"

# Configure keys in SSH config file
# Host github.com
#   IdentityFile ~/.ssh/github_key
# Host *.work.com
#   IdentityFile ~/.ssh/work_key

# Label keys with useful comments for identification
ssh-keygen -t ed25519 -C "username@project-deploy-key"

# Keep backup of important SSH keys
# (Store securely, e.g. encrypted USB drive)
# Copy C:\Users\username\.ssh\* to secure backup

# Document your SSH infrastructure
# Create internal wiki with SSH access patterns, jump hosts, etc.
```
