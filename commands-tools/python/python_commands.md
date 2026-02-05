# Python Commands Cheat Sheet

This document provides a comprehensive overview of essential Python commands, tools, and patterns with descriptions and examples for each.

## Table of Contents

- [Installation and Setup](#installation-and-setup)
- [Python Interpreter Commands](#python-interpreter-commands)
- [Running Python Scripts](#running-python-scripts)
- [Virtual Environments](#virtual-environments)
- [Interactive Mode and REPL](#interactive-mode-and-repl)
- [Module and Package Management](#module-and-package-management)
- [Python Development Tools](#python-development-tools)
- [Debugging](#debugging)
- [Testing](#testing)
- [Performance Profiling](#performance-profiling)
- [Code Quality and Style](#code-quality-and-style)
- [Documentation](#documentation)
- [Common Python Workflows](#common-python-workflows)
- [Troubleshooting](#troubleshooting)
- [Best Practices](#best-practices)

<div style="page-break-after: always;"></div>

## Installation and Setup
_Install Python and set up a development environment._

### Installing Python

```bash
# Ubuntu/Debian
sudo apt update
sudo apt install python3 python3-pip python3-venv

# Fedora/RHEL/CentOS
sudo dnf install python3 python3-pip

# macOS (using Homebrew)
brew install python

# Windows
# Download installer from https://www.python.org/downloads/
# Be sure to check "Add Python to PATH" during installation
```

### Verify Installation

```bash
# Check Python version
python --version
# or
python3 --version

# Check pip version
pip --version
# or
pip3 --version
```

<div style="page-break-after: always;"></div>

## Python Interpreter Commands

### Basic Command Line Options

```bash
# Run a Python script
python script.py

# Run module as a script
python -m module_name [args]

# Run command as a string
python -c "print('Hello, World!')"

# Launch interactive mode after running script
python -i script.py

# Show Python version
python -V

# Show detailed help
python --help
```

### Environment Variables

```bash
# Set Python path
export PYTHONPATH=/path/to/directories

# Ignore environment variables
python -E script.py

# Isolate mode (ignores PYTHON* env vars and user site-packages)
python -I script.py

# Debug mode
python -d script.py

# Optimize bytecode (removes assert statements)
python -O script.py

# Verbose mode (trace import statements)
python -v script.py
```

<div style="page-break-after: always;"></div>

## Running Python Scripts

### Basic Script Execution

```bash
# Run a Python script
python script.py

# Pass command line arguments to script
python script.py arg1 arg2

# Use shebang line in script
#!/usr/bin/env python3
# Then make executable and run
chmod +x script.py
./script.py
```

### Module Execution

```bash
# Run a module as script
python -m module_name

# Common examples
python -m http.server 8080
python -m json.tool file.json
python -m venv my_env
python -m pip install package_name
python -m unittest discover
```

### Code Execution from Shell

```bash
# Execute Python code directly
python -c "print('Hello, World!')"

# Complex example
python -c "import sys; print(sys.path)"

# Process data with Python one-liner
cat file.txt | python -c "import sys; print(sum(int(l) for l in sys.stdin))"
```

<div style="page-break-after: always;"></div>

## Virtual Environments

### Creating and Managing Virtual Environments

```bash
# Create virtual environment
python -m venv my_env

# Create with specific Python version
python3.9 -m venv my_env

# Activate virtual environment
# On Windows
my_env\Scripts\activate
# On macOS/Linux
source my_env/bin/activate

# Deactivate virtual environment
deactivate

# Create environment with access to system packages
python -m venv my_env --system-site-packages
```

<div style="page-break-after: always;"></div>

## Interactive Mode and REPL

### Python REPL Commands

```python
# Get help on a module, function, class, or method
help(object)

# Get info on an object
dir(object)

# Show names in the current namespace
dir()

# Import a module
import module_name

# Exit the interpreter
exit()  # or quit() or Ctrl+D (Unix) or Ctrl+Z+Enter (Windows)

# Execute a statement from the shell and enter interactive mode
python -i script.py
```

### IPython Commands

```bash
# Install IPython
pip install ipython

# Start IPython
ipython

# Load a script and stay in interactive mode
ipython -i script.py
```

### Common IPython Magic Commands

```python
# Timing code execution
%time statement
%timeit statement

# Running shell commands
!command

# Running a script
%run script.py

# Load external modules
%load module_name

# Display history
%history
```

<div style="page-break-after: always;"></div>

## Module and Package Management

### Importing Modules

```python
# Basic import
import module_name

# Import specific items
from module_name import function, Class, CONSTANT

# Import with alias
import module_name as alias

# Import all (not recommended)
from module_name import *

# Relative imports (inside packages)
from . import module  # import from same package
from .. import module  # import from parent package
```

### Module Path Management

```python
# Show module search path
import sys
print(sys.path)

# Add directory to module search path
import sys
sys.path.append('/path/to/directory')

# Use PYTHONPATH environment variable
# On Windows
set PYTHONPATH=c:\path\to\directory
# On macOS/Linux
export PYTHONPATH=/path/to/directory
```

<div style="page-break-after: always;"></div>

## Python Development Tools

### Python Code Analysis

```bash
# Install pylint
pip install pylint

# Analyze code with pylint
pylint script.py

# Generate a pylint configuration file
pylint --generate-rcfile > .pylintrc
```

### Code Formatting

```bash
# Install black formatter
pip install black

# Format a file
black script.py

# Format an entire directory
black my_project/

# Format with specific line length
black --line-length 79 script.py
```

### Type Checking

```bash
# Install mypy
pip install mypy

# Check types in a file
mypy script.py

# Check with stricter rules
mypy --strict script.py
```

<div style="page-break-after: always;"></div>

## Debugging

### Using pdb (Python Debugger)

```python
# Add breakpoint in code
import pdb; pdb.set_trace()

# In Python 3.7+
breakpoint()

# Running a script under the debugger
python -m pdb script.py
```

### Common pdb Commands

```
# pdb commands (enter at pdb prompt)
h(elp)          # Show help
n(ext)          # Execute current line
s(tep)          # Step into a function call
r(eturn)        # Continue execution until return
c(ontinue)      # Continue execution until next breakpoint
l(ist)          # List source code
p expression    # Print expression value
q(uit)          # Quit debugger
b(reak)         # Set breakpoint
```

<div style="page-break-after: always;"></div>

## Testing

### Running Tests with unittest

```bash
# Run all tests in a module
python -m unittest test_module

# Run all tests in a directory
python -m unittest discover

# Run specific test class
python -m unittest test_module.TestClass

# Run specific test method
python -m unittest test_module.TestClass.test_method

# Run with verbose output
python -m unittest -v test_module
```

### Running Tests with pytest

```bash
# Install pytest
pip install pytest

# Run all tests
pytest

# Run specific test file
pytest test_file.py

# Run specific test
pytest test_file.py::test_function

# Run with verbose output
pytest -v

# Show stdout/stderr
pytest -s

# Show test duration
pytest --durations=0
```

<div style="page-break-after: always;"></div>

## Performance Profiling

### Using cProfile

```bash
# Profile a script
python -m cProfile script.py

# Sort by cumulative time
python -m cProfile -s cumtime script.py

# Save profile results to file
python -m cProfile -o output.prof script.py

# Visualize profile with snakeviz
pip install snakeviz
snakeviz output.prof
```

### Using timeit

```bash
# Time a short code snippet from command line
python -m timeit "'-'.join(str(n) for n in range(100))"

# Compare different implementations
python -m timeit "'-'.join(str(n) for n in range(100))"
python -m timeit "'-'.join(map(str, range(100)))"
```

<div style="page-break-after: always;"></div>

## Code Quality and Style

### Using Flake8

```bash
# Install flake8
pip install flake8

# Check a file
flake8 script.py

# Check with specific config
flake8 --max-line-length=100 script.py

# Ignore specific errors
flake8 --ignore=E203,W503 script.py
```

### Using isort

```bash
# Install isort
pip install isort

# Sort imports
isort script.py

# Check if imports are sorted
isort --check script.py

# Sort recursively
isort .
```

<div style="page-break-after: always;"></div>

## Documentation

### Using pydoc

```bash
# Show documentation for a module
python -m pydoc module_name

# Show documentation for a function/class
python -m pydoc module_name.function_or_class

# Start documentation server
python -m pydoc -p 8080

# Generate HTML documentation
python -m pydoc -w module_name
```

### Generating Documentation with Sphinx

```bash
# Install Sphinx
pip install sphinx

# Initialize Sphinx documentation
sphinx-quickstart

# Build HTML documentation
sphinx-build -b html sourcedir builddir

# Build PDF documentation
sphinx-build -b latex sourcedir builddir
cd builddir
make
```

<div style="page-break-after: always;"></div>

## Common Python Workflows

### Basic Project Setup

```bash
# Create project structure
mkdir my_project
cd my_project
python -m venv venv
source venv/bin/activate  # On Windows: venv\Scripts\activate
pip install --upgrade pip

# Create basic files
mkdir my_project/src
touch my_project/src/__init__.py
touch setup.py
touch README.md
```

### Package Installation for Development

```bash
# Install package in development mode
pip install -e .

# Install development dependencies
pip install -e ".[dev]"
```

### Project Release Workflow

```bash
# Install build tools
pip install build

# Build project
python -m build

# Upload to PyPI (requires twine)
pip install twine
twine upload dist/*
```

<div style="page-break-after: always;"></div>

## Troubleshooting

### Common Issues and Solutions

```bash
# Module not found errors
# 1. Check if package is installed
pip list | grep package_name

# 2. Check Python path
python -c "import sys; print(sys.path)"

# 3. Install missing package
pip install package_name

# 4. Check for typos in import statement
```

### Dependency Conflicts

```bash
# Show dependency tree
pip install pipdeptree
pipdeptree

# Install specific version
pip install package_name==1.2.3

# Force reinstall
pip install --force-reinstall package_name
```

<div style="page-break-after: always;"></div>

## Best Practices

### Code Organization

```python
# Standard import order
# 1. Standard library imports
import os
import sys

# 2. Third-party imports
import numpy as np
import pandas as pd

# 3. Local application imports
from mypackage import mymodule
```

### Project Structure

```
my_project/
├── LICENSE
├── README.md
├── requirements.txt
├── setup.py
├── docs/
├── src/
│   └── my_package/
│       ├── __init__.py
│       └── module.py
└── tests/
    ├── __init__.py
    └── test_module.py
```

### Virtual Environment Management

```bash
# Use dedicated environment per project
python -m venv .venv

# Save dependencies
pip freeze > requirements.txt

# Install from requirements
pip install -r requirements.txt
```

### Error Handling

```python
# Use specific exceptions
try:
    # code that might raise an exception
except ValueError as e:
    # handle value error
except OSError as e:
    # handle OS error
except Exception as e:
    # handle any other exception
    # (use sparingly)
finally:
    # cleanup code that always runs
```

### Version Compatibility

```python
# Check Python version
import sys
if sys.version_info < (3, 8):
    raise RuntimeError("Python 3.8 or newer required")

# Handle incompatible features
import sys
if sys.version_info >= (3, 10):
    # Use Python 3.10+ features
else:
    # Use compatible alternative
```