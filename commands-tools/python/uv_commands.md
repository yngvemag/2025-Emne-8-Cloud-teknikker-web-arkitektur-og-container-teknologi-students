# UV Commands Cheat Sheet

This document provides a comprehensive overview of UV (Ultraviolet), a highly performant Python package installer and resolver, with descriptions and examples for each command.

## Table of Contents

- [Installation and Setup](#installation-and-setup)
- [Basic Usage](#basic-usage)
- [Package Management](#package-management)
- [Virtual Environment Management](#virtual-environment-management)
- [Project Dependency Management](#project-dependency-management)
- [Configuration](#configuration)
- [Cache Management](#cache-management)
- [Integration with Other Tools](#integration-with-other-tools)
- [Common Workflows](#common-workflows)
- [Troubleshooting](#troubleshooting)
- [Best Practices](#best-practices)

<div style="page-break-after: always;"></div>

## Installation and Setup
_Install UV on various operating systems and verify installation._

### Installing UV

```bash
# Using curl (macOS/Linux)
curl -LsSf https://astral.sh/uv/install.sh | sh

# Using PowerShell (Windows)
irm https://astral.sh/uv/install.ps1 | iex

# Using pip
pip install uv

# Using pipx
pipx install uv

# Using conda
conda install -c conda-forge uv

# Using Homebrew
brew install uv
```

### Verifying Installation

```bash
# Check UV version
uv --version

# View help
uv --help

# View help for a specific command
uv pip --help
```

<div style="page-break-after: always;"></div>

## Basic Usage

### Installing Packages

```bash
# Install a package
uv pip install numpy

# Install multiple packages
uv pip install numpy pandas matplotlib

# Install a specific version
uv pip install numpy==1.24.3

# Install with version constraints
uv pip install "numpy>=1.20,<1.25"

# Install from a GitHub repository
uv pip install git+https://github.com/numpy/numpy.git

# Install from a local directory
uv pip install -e .
```

### Uninstalling Packages

```bash
# Uninstall a package
uv pip uninstall numpy

# Uninstall multiple packages
uv pip uninstall numpy pandas

# Uninstall without confirmation
uv pip uninstall -y numpy
```

<div style="page-break-after: always;"></div>

## Package Management

### Package Listing

```bash
# List installed packages
uv pip list

# List packages in JSON format
uv pip list --format json

# List packages in a specific environment
uv pip list --venv /path/to/venv

# List outdated packages
uv pip list --outdated
```

### Package Information

```bash
# Show information about a package
uv pip show numpy

# Show verbose information
uv pip show -v numpy

# Show information about multiple packages
uv pip show numpy pandas
```

### Package Searching

```bash
# Search for packages
uv pip search numpy

# Search with a specific index
uv pip search --index-url https://pypi.org/simple/ numpy
```

<div style="page-break-after: always;"></div>

## Virtual Environment Management

### Creating Virtual Environments

```bash
# Create a virtual environment
uv venv

# Create a virtual environment with a specific name
uv venv .venv

# Create with a specific Python version
uv venv --python 3.11

# Create with system packages
uv venv --system-site-packages .venv
```

### Managing Virtual Environments

```bash
# Activate a virtual environment (PowerShell)
.\.venv\Scripts\Activate.ps1

# Activate a virtual environment (bash/zsh)
source .venv/bin/activate

# Install packages into a specific virtual environment
uv pip install --venv .venv numpy
```

<div style="page-break-after: always;"></div>

## Project Dependency Management

### Requirements Files

```bash
# Install from requirements file
uv pip install -r requirements.txt

# Generate a requirements file
uv pip freeze > requirements.txt

# Install with constraints file
uv pip install -c constraints.txt -r requirements.txt
```

### Using pyproject.toml

```bash
# Install a project and its dependencies
uv pip install .

# Install in development mode
uv pip install -e .

# Install with specific extras
uv pip install ".[dev,test]"

# Install with specific Python version
uv pip install --python 3.11 .
```

### Lock Files

```bash
# Generate a lock file
uv pip compile pyproject.toml -o requirements.lock

# Install from a lock file
uv pip install -r requirements.lock

# Update lock file with latest versions
uv pip compile --upgrade pyproject.toml -o requirements.lock
```

<div style="page-break-after: always;"></div>

## Configuration

### Configuration Files

```bash
# Generate a default configuration
uv config init

# Show current configuration
uv config show

# Set a configuration value
uv config set pip.index-url https://pypi.org/simple/

# Unset a configuration value
uv config unset pip.index-url
```

### Command-line Configuration

```bash
# Use a specific index URL
uv pip install --index-url https://pypi.org/simple/ numpy

# Add an extra index URL
uv pip install --extra-index-url https://my.index.org/simple/ numpy

# Set cache directory
uv pip install --cache-dir /path/to/cache numpy

# Disable cache
uv pip install --no-cache numpy
```

<div style="page-break-after: always;"></div>

## Cache Management

### Managing the Cache

```bash
# Show cache info
uv cache info

# Clear the entire cache
uv cache clear

# Clear specific part of the cache
uv cache clear --wheels
uv cache clear --sources
```

### Cache Configuration

```bash
# Set custom cache location
export UV_CACHE_DIR=/path/to/cache
# On Windows (PowerShell)
$env:UV_CACHE_DIR="C:\path\to\cache"

# Use temporary cache
uv pip install --cache-dir $(mktemp -d) numpy
```

<div style="page-break-after: always;"></div>

## Integration with Other Tools

### Working with pip

```bash
# Use UV as a pip replacement
uv pip

# Convert requirements.txt to pip-compatible format
uv pip compile requirements.in -o requirements.txt --generate-hashes

# Generate a pip-compatible requirements file
uv pip freeze > requirements.txt
```

### Working with Poetry

```bash
# Install from Poetry project
uv pip install .

# Install dependencies only
uv pip install --no-root .

# Generate a Poetry-compatible lock file
uv pip compile pyproject.toml --poetry -o poetry.lock
```

### Working with PDM

```bash
# Install from PDM project
uv pip install .

# Generate a PDM-compatible lock file
uv pip compile pyproject.toml --pdm -o pdm.lock
```

<div style="page-break-after: always;"></div>

## Common Workflows

### Development Setup

```bash
# Create a virtual environment and install dependencies
uv venv
uv pip install -e ".[dev]" --venv .venv
```

### CI/CD Workflow

```bash
# Install dependencies in CI
uv pip install -r requirements.txt --system

# Install with specific Python version
uv pip install --python 3.11 -r requirements.txt
```

### Production Deployment

```bash
# Install with hashes for security
uv pip install --require-hashes -r requirements.txt

# Install without dev dependencies
uv pip install --no-dev .
```

<div style="page-break-after: always;"></div>

## Troubleshooting

### Common Issues

```bash
# Show verbose output
uv pip install -v numpy

# Show debug output
uv pip install --debug numpy

# Force reinstall
uv pip install --force-reinstall numpy

# Ignore installed packages
uv pip install --ignore-installed numpy
```

### Dependency Resolution Issues

```bash
# Show reason for package inclusion
uv pip install --report numpy

# Install with relaxed constraints
uv pip install --resolution=backtracking numpy

# Install without dependencies
uv pip install --no-deps numpy
```

<div style="page-break-after: always;"></div>

## Best Practices

### Speed Optimization

```bash
# Use native wheels when possible
uv pip install --prefer-binary numpy

# Parallel downloads
uv pip install --no-build-isolation numpy pandas matplotlib

# Precompiled wheels
export UV_PRECOMPILED_WHEELS=1
# On Windows (PowerShell)
$env:UV_PRECOMPILED_WHEELS=1
```

### Security Best Practices

```bash
# Install with hash verification
uv pip install --require-hashes -r requirements.txt

# Use trusted sources
uv pip install --index-url https://pypi.org/simple/ numpy

# Audit dependencies
uv pip install --report numpy > deps_report.txt
```

### Project Organization

```bash
# Separate environment per project
uv venv .venv
uv pip install -e . --venv .venv

# Pin exact versions for reproducibility
uv pip freeze --exclude-editable > requirements.lock

# Use lockfiles for application dependencies
uv pip compile pyproject.toml -o requirements.lock --all-extras
uv pip install -r requirements.lock
```