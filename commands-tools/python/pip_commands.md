# Pip Command Cheat Sheet

This document provides a comprehensive overview of essential Pip commands, with descriptions and examples for each.

## Table of Contents

- [Installation and Setup](#installation-and-setup)
- [Package Management](#package-management)
- [Requirements Files](#requirements-files)
- [Virtual Environments](#virtual-environments)
- [Package Information](#package-information)
- [Pip Configuration](#pip-configuration)
- [Cache Management](#cache-management)
- [Project Dependencies](#project-dependencies)
- [Development Mode](#development-mode)
- [Package Building and Publishing](#package-building-and-publishing)
- [Troubleshooting](#troubleshooting)
- [Best Practices](#best-practices)
- [Pip Workflow Examples](#pip-workflow-examples)

## Installation and Setup
_Install and configure Pip on various operating systems._

### Installing Pip

```bash
# Python 3.4+ includes pip by default
# If needed, install or upgrade pip

# On Windows
py -m ensurepip --upgrade

# On macOS/Linux
python3 -m ensurepip --upgrade

# Alternative method
curl https://bootstrap.pypa.io/get-pip.py -o get-pip.py
python get-pip.py
```

### Verifying Installation

```bash
# Check pip version
pip --version
pip3 --version

# Get help
pip help
pip help install
```

<div style="page-break-after: always;"></div>

## Package Management
_Commands for installing, updating, and removing packages._

### Installing Packages

```bash
# Install a package
pip install package_name

# Install a specific version
pip install package_name==1.2.3

# Install minimum version
pip install package_name>=1.2.3

# Install version range
pip install "package_name>=1.2.3,<2.0.0"

# Install from GitHub
pip install git+https://github.com/user/repo.git

# Install from a specific branch
pip install git+https://github.com/user/repo.git@branch_name

# Install from local directory
pip install -e path/to/directory

# Install from a specific index URL
pip install --index-url https://my.package.repo/simple package_name

# Install without dependencies
pip install --no-deps package_name

# Install ignoring installed packages
pip install --ignore-installed package_name
```

### Upgrading Packages

```bash
# Upgrade a package
pip install --upgrade package_name

# Upgrade pip itself
pip install --upgrade pip
python -m pip install --upgrade pip

# Upgrade all packages (requires pip-review)
pip install pip-review
pip-review --auto
```

### Uninstalling Packages

```bash
# Uninstall a package
pip uninstall package_name

# Uninstall without confirmation
pip uninstall -y package_name

# Uninstall multiple packages
pip uninstall package1 package2 package3
```

<div style="page-break-after: always;"></div>

## Requirements Files
_Working with requirements files to manage dependencies._

### Creating Requirements Files

```bash
# Generate requirements file from installed packages
pip freeze > requirements.txt

# Create requirements file manually
echo "package1==1.2.3\npackage2>=4.5.6\npackage3" > requirements.txt
```

### Using Requirements Files

```bash
# Install packages from requirements file
pip install -r requirements.txt

# Upgrade packages from requirements file
pip install --upgrade -r requirements.txt

# Install with constraints file
pip install -c constraints.txt package_name

# Compare installed packages against requirements
pip check
```

### Requirements File Formats

```
# Sample requirements.txt formats

# Fixed versions (most strict)
numpy==1.19.5
pandas==1.2.3
matplotlib==3.4.1

# Minimum versions (less strict)
numpy>=1.19.0
pandas>=1.2.0
matplotlib>=3.0.0

# Compatible releases (PEP 440)
numpy~=1.19.0  # equivalent to >=1.19.0,<2.0.0

# Specific source
git+https://github.com/user/package.git@master
https://example.com/package-1.0.0.tar.gz

# Extras
requests[security,socks]==2.25.1
```

<div style="page-break-after: always;"></div>

## Virtual Environments
_Using Pip with virtual environments._

### Creating Virtual Environments

```bash
# Install virtualenv
pip install virtualenv

# Create virtual environment
virtualenv venv

# Create virtual environment with specific Python version
virtualenv -p python3.9 venv

# Create environment with venv module (Python 3.3+)
python -m venv venv
```

### Activating and Deactivating Environments

```bash
# On Windows
venv\Scripts\activate

# On macOS/Linux
source venv/bin/activate

# Deactivate environment
deactivate
```

### Installing Packages in Virtual Environment

```bash
# First activate the environment, then install packages
source venv/bin/activate  # or venv\Scripts\activate on Windows
pip install package_name

# Install packages without activating
venv/bin/pip install package_name  # macOS/Linux
venv\Scripts\pip install package_name  # Windows
```

<div style="page-break-after: always;"></div>

## Package Information
_Commands for getting information about packages._

### Listing Packages

```bash
# List installed packages
pip list

# List installed packages in requirements format
pip freeze

# List outdated packages
pip list --outdated

# List packages that can be upgraded
pip list --outdated --format=freeze
```

### Package Information

```bash
# Show package details
pip show package_name

# Check for dependencies
pip check

# Show package dependencies
pip show -f package_name

# Search for packages on PyPI
pip search package_name  # Note: This feature was disabled in 2020 due to API limitations
```

### Package Verification

```bash
# Verify installed packages
pip check

# Verify integrity of packages
pip install --require-hashes -r requirements.txt

# List packages with dependencies
pip list --not-required
```

<div style="page-break-after: always;"></div>

## Pip Configuration
_Configuring Pip behavior and settings._

### Configuration Files

```bash
# Locations of pip configuration files
# Global: /etc/pip.conf (Unix) or C:\ProgramData\pip\pip.ini (Windows)
# User: ~/.pip/pip.conf (Unix) or %APPDATA%\pip\pip.ini (Windows)
# Environment variable: PIP_CONFIG_FILE

# View current configuration
pip config list

# Set global configuration value
pip config --global set global.index-url https://pypi.org/simple

# Set user configuration value
pip config --user set global.timeout 60
```

### Common Configuration Options

```ini
[global]
# Default package index
index-url = https://pypi.org/simple

# Extra package indexes
extra-index-url = https://example.com/private/simple

# Trusted hosts
trusted-host = pypi.org
               files.pythonhosted.org
               example.com

# Proxy settings
proxy = http://proxy.example.com:3128

# Timeout in seconds
timeout = 60

# Cache directory
cache-dir = /path/to/cache/directory

# Disable pip version check
disable-pip-version-check = true

[install]
# Do not install package dependencies
no-deps = yes

# User installation
user = yes

# Prefer binary packages over source packages
prefer-binary = true
```

<div style="page-break-after: always;"></div>

## Cache Management
_Commands for managing the Pip package cache._

### Cache Commands

```bash
# View pip cache info
pip cache info

# List cache contents
pip cache list

# Remove specific package from cache
pip cache remove package_name

# Remove all packages from cache
pip cache purge

# Download without installing (cache only)
pip download package_name

# Install without accessing internet (use cache only)
pip install --no-index --find-links=/path/to/download/dir package_name
```

### Cache Directory

```bash
# Show cache directory
pip cache dir

# Default cache locations
# macOS: ~/Library/Caches/pip
# Unix: ~/.cache/pip
# Windows: %LOCALAPPDATA%\pip\Cache
```

<div style="page-break-after: always;"></div>

## Project Dependencies
_Working with dependency management in Python projects._

### Dependency Resolution

```bash
# Install with dependency resolver (pip >= 20.3)
pip install --use-feature=2020-resolver package_name

# Install with updated resolver (pip >= 21.0)
pip install package_name

# Show dependency tree (requires pip-tools)
pip install pipdeptree
pipdeptree

# Show dependencies for a specific package
pipdeptree -p package_name
```

### Using pip-tools

```bash
# Install pip-tools
pip install pip-tools

# Generate requirements from setup.py
pip-compile

# Generate requirements from custom file
pip-compile requirements.in

# Update requirements
pip-compile --upgrade

# Generate requirements for specific package
pip-compile --extra=dev

# Sync environment with requirements
pip-sync requirements.txt

# Sync with multiple requirements files
pip-sync dev-requirements.txt requirements.txt
```

<div style="page-break-after: always;"></div>

## Development Mode
_Installing and developing packages in editable mode._

### Editable Installs

```bash
# Install package in development/editable mode
pip install -e path/to/package

# Install from Git repository in editable mode
pip install -e git+https://github.com/user/repo.git#egg=package_name

# Install from current directory
pip install -e .

# Install with specific extras
pip install -e ".[dev,test]"
```

### Development Workflow

```bash
# Setup project for development
git clone https://github.com/user/project.git
cd project
pip install -e ".[dev]"

# Run tests after changes
pytest

# Reinstall after structural changes
pip install -e . --force-reinstall
```

<div style="page-break-after: always;"></div>

## Package Building and Publishing
_Creating and publishing Python packages._

### Building Packages

```bash
# Install build tools
pip install build twine

# Build a source distribution
python -m build --sdist

# Build a wheel distribution
python -m build --wheel

# Build both
python -m build

# Legacy method
pip install setuptools wheel
python setup.py sdist bdist_wheel
```

### Publishing Packages

```bash
# Install twine
pip install twine

# Check distribution files
twine check dist/*

# Upload to TestPyPI
twine upload --repository-url https://test.pypi.org/legacy/ dist/*

# Upload to PyPI
twine upload dist/*
```

### Package Structure

```
project/
├── pyproject.toml
├── setup.py
├── setup.cfg
├── README.md
├── LICENSE
└── package_name/
    ├── __init__.py
    └── module.py
```

<div style="page-break-after: always;"></div>

## Troubleshooting
_Common issues and solutions for Pip._

### Common Issues

```bash
# Fix "Cannot uninstall X: It is a distutils installed project"
pip install --ignore-installed package_name

# Fix "Permission denied" errors
pip install --user package_name

# Fix SSL certificate errors
pip install --trusted-host pypi.org --trusted-host files.pythonhosted.org package_name

# Debug installation issues
pip install -v package_name

# Reinstall with force option
pip install --force-reinstall package_name

# Fix corrupted packages
pip uninstall -y package_name
pip install package_name
```

### Network Issues

```bash
# Set proxy environment variables
# On Windows
set HTTP_PROXY=http://proxy.example.com:8080
set HTTPS_PROXY=http://proxy.example.com:8080

# On macOS/Linux
export HTTP_PROXY=http://proxy.example.com:8080
export HTTPS_PROXY=http://proxy.example.com:8080

# Use pip with proxy
pip --proxy http://proxy.example.com:8080 install package_name

# Set proxies in pip.conf
pip config set global.proxy http://proxy.example.com:8080
```

### Dependency Conflicts

```bash
# Install with version constraints
pip install "package1>=1.0,<2.0" "package2>=3.0"

# Force reinstall ignoring dependencies (use with caution)
pip install --ignore-installed --no-deps package_name

# Install specific versions to resolve conflicts
pip install package1==1.2.3 package2==4.5.6

# Use virtual environments to avoid conflicts
python -m venv new_env
new_env/bin/pip install package_name
```

<div style="page-break-after: always;"></div>

## Best Practices
_Recommendations for effective Pip usage._

### Package Management

1. **Use Virtual Environments**
   ```bash
   # Create isolated environments for each project
   python -m venv myproject_env
   source myproject_env/bin/activate
   ```

2. **Pin Dependencies**
   ```bash
   # Always pin exact versions for deployments
   pip freeze > requirements.txt
   
   # Document dependencies with minimum versions for libraries
   pip install pip-tools
   pip-compile
   ```

3. **Regular Updates**
   ```bash
   # Check for updates regularly
   pip list --outdated
   
   # Update packages carefully
   pip install --upgrade package_name
   ```

### Security

1. **Verify Package Sources**
   ```bash
   # Use HTTPS and verify downloads
   pip install --require-hashes -r requirements.txt
   ```

2. **Audit Dependencies**
   ```bash
   # Install safety
   pip install safety
   
   # Check for vulnerable packages
   safety check
   ```

3. **Use Trusted Indexes**
   ```bash
   # Use official or trusted private indexes
   pip config set global.index-url https://pypi.org/simple
   ```

### Performance

1. **Use Wheels When Possible**
   ```bash
   # Prefer binary distributions over source
   pip install --prefer-binary package_name
   ```

2. **Cache Efficiency**
   ```bash
   # Use a persistent cache
   pip config set global.cache-dir /path/to/persistent/cache
   ```

3. **Minimize Environment Size**
   ```bash
   # Only install what you need
   pip install package_name --no-deps
   ```

<div style="page-break-after: always;"></div>

## Pip Workflow Examples
_Practical examples of common Pip workflows._

### Python Web Application Setup

```bash
# Create and activate virtual environment
python -m venv webapp_env
source webapp_env/bin/activate  # or webapp_env\Scripts\activate on Windows

# Install web framework and dependencies
pip install flask sqlalchemy gunicorn

# Install development tools
pip install pytest black flake8

# Freeze dependencies
pip freeze > requirements.txt

# Create production requirements (excluding dev tools)
pip install pip-tools
pip-compile --generate-hashes requirements.in
```

### Data Science Project Setup

```bash
# Create and activate environment
python -m venv datascience_env
source datascience_env/bin/activate

# Install data science packages
pip install numpy pandas matplotlib scikit-learn jupyter

# Install optional visualization packages
pip install seaborn plotly

# Save environment
pip freeze > requirements.txt
```

### Package Development Workflow

```bash
# Create development environment
python -m venv dev_env
source dev_env/bin/activate

# Install package in development mode with test dependencies
pip install -e ".[test,dev]"

# Install tools for development
pip install black isort mypy pytest

# Update dependencies after adding new ones to setup.py
pip install -e . --upgrade

# Build distributions for release
pip install build twine
python -m build
twine check dist/*
```

### CI/CD Pipeline Setup

```bash
# Requirements file with hashes for security and reproducibility
pip-compile --generate-hashes requirements.in

# Install in CI environment
pip install --require-hashes -r requirements.txt

# Run tests
pip install pytest pytest-cov
pytest --cov=mypackage

# Build package
pip install build
python -m build

# Publish if tests pass
pip install twine
twine upload --skip-existing dist/*
```