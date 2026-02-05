# Ruff Commands Cheat Sheet

This document provides a comprehensive overview of Ruff, an extremely fast Python linter and code formatter, with descriptions and examples for each command.

## Table of Contents

- [Installation and Setup](#installation-and-setup)
- [Basic Usage](#basic-usage)
- [Linting Commands](#linting-commands)
- [Formatting Commands](#formatting-commands)
- [Rule Configuration](#rule-configuration)
- [Ignoring Rules](#ignoring-rules)
- [Project Configuration](#project-configuration)
- [IDE Integration](#ide-integration)
- [CI/CD Integration](#cicd-integration)
- [Advanced Usage](#advanced-usage)
- [Upgrading Ruff](#upgrading-ruff)
- [Troubleshooting](#troubleshooting)
- [Best Practices](#best-practices)

<div style="page-break-after: always;"></div>

## Installation and Setup
_Install and configure Ruff for your Python projects._

### Installing Ruff

```bash
# Using pip
pip install ruff

# Using pip with extras (includes preview features)
pip install "ruff[d]"

# Using conda
conda install -c conda-forge ruff

# Using brew (macOS)
brew install ruff

# Check installation
ruff --version
```

### Initial Setup

```bash
# Generate a default configuration file
ruff init

# Install pre-commit hook
pip install pre-commit
cat > .pre-commit-config.yaml << 'EOF'
repos:
-   repo: https://github.com/astral-sh/ruff-pre-commit
    rev: v0.1.8
    hooks:
    -   id: ruff
        args: [ --fix ]
    -   id: ruff-format
EOF
pre-commit install
```

<div style="page-break-after: always;"></div>

## Basic Usage

### Linting Files

```bash
# Lint a file
ruff check file.py

# Lint multiple files
ruff check file1.py file2.py

# Lint a directory
ruff check .
ruff check path/to/directory

# Lint with automatic fixes
ruff check --fix file.py
```

### Formatting Files

```bash
# Format a file
ruff format file.py

# Format multiple files
ruff format file1.py file2.py

# Format a directory
ruff format .
ruff format path/to/directory

# Check formatting without modifying files
ruff format --check file.py
```

<div style="page-break-after: always;"></div>

## Linting Commands

### Basic Linting Options

```bash
# Show line numbers
ruff check --show-source file.py

# Show detailed rule explanations
ruff check --explain file.py

# Show statistics
ruff check --statistics file.py

# Lint with different rules (select only specific rules)
ruff check --select E,F,W file.py

# Exclude specific rules
ruff check --ignore E203,E501 file.py

# Set line-length
ruff check --line-length 100 file.py

# Watch for changes
ruff check --watch file.py
```

### Advanced Linting Options

```bash
# Auto-fix safe violations
ruff check --fix file.py

# Auto-fix all violations (including potentially unsafe ones)
ruff check --fix-only file.py

# Exclude specific files or directories
ruff check --exclude tests/,__pycache__/ .

# Use specific Python version
ruff check --target-version py310 file.py

# Show unsafe fixes
ruff check --show-fixes file.py

# Fix only specific rule violations
ruff check --fix --select E501 file.py
```

<div style="page-break-after: always;"></div>

## Formatting Commands

### Basic Formatting Options

```bash
# Format files in place
ruff format file.py

# Check if files are properly formatted (without modifying)
ruff format --check file.py

# Format and show diff
ruff format --diff file.py

# Respect gitignore
ruff format --respect-gitignore .

# Process multiple files in parallel
ruff format --num-jobs 4 directory/
```

### Advanced Formatting Options

```bash
# Format with specific line length
ruff format --line-length 100 file.py

# Format with specific Python target version
ruff format --target-version py310 file.py

# Format except specified paths
ruff format --exclude tests/ .

# Force formatting with changes
ruff format --force file.py
```

<div style="page-break-after: always;"></div>

## Rule Configuration

### Working with Rules

```bash
# List all available rules
ruff rule --all

# Show details for a specific rule
ruff rule F401

# Show examples for a rule
ruff rule --examples F401

# Show detailed rule information with examples
ruff rule --explain F401
```

### Common Rule Sets

```
# Common rule prefixes:
E, F        - pyflakes and pycodestyle errors
W           - pycodestyle warnings
I           - isort
N           - pep8-naming
D           - pydocstyle
UP          - pyupgrade
B           - flake8-bugbear
C4          - flake8-comprehensions
PTH         - flake8-use-pathlib
S           - flake8-bandit
PIE         - flake8-pie
T10         - flake8-debugger
ANN         - flake8-annotations
PT          - flake8-pytest-style
RET         - flake8-return
SIM         - flake8-simplify
TRY         - tryceratops
PLW         - pylint
```

<div style="page-break-after: always;"></div>

## Ignoring Rules

### Inline Ignoring Rules

```python
# Ignore a rule for a single line
x = 1  # noqa: F841

# Ignore multiple rules for a single line
x = 1 + 2  # noqa: F841, E501

# Ignore a rule for a block of code
# fmt: off
multi_line = [
    1, 2, 3,
    4, 5, 6,
]
# fmt: on

# Ignore all rules for a line
some_code()  # noqa
```

### File-level Ignoring Rules

```python
# Ignore specific rules for an entire file (at the top of the file)
# ruff: noqa: E501, F401
import sys
```

<div style="page-break-after: always;"></div>

## Project Configuration

### Configuration File

```toml
# pyproject.toml
[tool.ruff]
# Enable flake8-bugbear (`B`) rules.
select = ["E", "F", "B"]

# Never enforce `E501` (line length violations).
ignore = ["E501"]

# Allow lines to be as long as 120 characters.
line-length = 120

# Allow unused variables when they start with an underscore.
dummy-variable-rgx = "^(_+|(_+[a-zA-Z0-9_]*[a-zA-Z0-9]+?))$"

# Target Python 3.10.
target-version = "py310"

[tool.ruff.format]
# Like Black, use double quotes for strings.
quote-style = "double"

# Like Black, indent with spaces, rather than tabs.
indent-style = "space"

# Like Black, respect magic trailing commas.
skip-magic-trailing-comma = false

# Like Black, automatically detect the appropriate line ending.
line-ending = "auto"
```

### Additional Configuration Options

```toml
# pyproject.toml
[tool.ruff]
# Configure rule sets
extend-select = ["C4", "I"]
extend-ignore = ["E203"]

# Configure isort
[tool.ruff.isort]
known-third-party = ["numpy", "pandas"]
section-order = ["future", "standard-library", "third-party", "first-party", "local-folder"]

# Configure flake8-quotes
[tool.ruff.flake8-quotes]
docstring-quotes = "double"
inline-quotes = "single"

# Configure flake8-import-conventions
[tool.ruff.flake8-import-conventions.aliases]
numpy = "np"
pandas = "pd"
matplotlib = "plt"
```

<div style="page-break-after: always;"></div>

## IDE Integration

### VS Code Integration

```json
// settings.json
{
  "editor.formatOnSave": true,
  "editor.codeActionsOnSave": {
    "source.fixAll.ruff": true,
    "source.organizeImports.ruff": true
  },
  "python.analysis.fixAll": ["source.fixAll.ruff", "source.organizeImports.ruff"],
  "[python]": {
    "editor.defaultFormatter": "charliermarsh.ruff"
  }
}
```

### PyCharm Integration

```
# Install the "Ruff" plugin from JetBrains Marketplace
# Settings > Tools > Ruff > Enable Ruff
```

<div style="page-break-after: always;"></div>

## CI/CD Integration

### GitHub Actions

```yaml
# .github/workflows/ruff.yml
name: Ruff
on: [push, pull_request]
jobs:
  ruff:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3
      - uses: chartboost/ruff-action@v1
        with:
          version: 0.1.8
```

### Pre-commit Configuration

```yaml
# .pre-commit-config.yaml
repos:
-   repo: https://github.com/astral-sh/ruff-pre-commit
    rev: v0.1.8
    hooks:
    -   id: ruff
        args: [ --fix ]
    -   id: ruff-format
```

<div style="page-break-after: always;"></div>

## Advanced Usage

### Caching

```bash
# Enable cache
ruff check --cache file.py

# Disable cache
ruff check --no-cache file.py

# Set custom cache directory
ruff check --cache-dir .ruff_cache file.py
```

### Performance Optimizations

```bash
# Run with multiple processes
ruff check --num-jobs 4 directory/

# Show performance statistics
ruff check --statistics file.py

# Verbose mode with timing details
ruff check --verbose file.py
```

<div style="page-break-after: always;"></div>

## Upgrading Ruff

### Upgrade Commands

```bash
# Upgrade using pip
pip install --upgrade ruff

# Upgrade with extras
pip install --upgrade "ruff[d]"

# Upgrade using conda
conda update -c conda-forge ruff

# Upgrade using brew
brew upgrade ruff
```

### Migration Between Versions

```bash
# Show current version
ruff --version

# Modify rule selections for compatibility with newer versions
# Check release notes: https://github.com/astral-sh/ruff/releases
```

<div style="page-break-after: always;"></div>

## Troubleshooting

### Common Issues

```bash
# Debugging flag
ruff check --verbose file.py

# Export diagnostics to JSON
ruff check --output-format=json file.py > diagnostics.json

# Test specific rule behavior
ruff check --select=E501 file.py
```

### Resolving Conflicts

```bash
# Override global configs for a specific run
ruff check --config=/path/to/config.toml file.py

# Ignore specific configuration files
ruff check --isolated file.py
```

<div style="page-break-after: always;"></div>

## Best Practices

### Code Organization

```bash
# Run linting and formatting in one command
ruff check --fix file.py && ruff format file.py

# Create an alias for commonly used options
alias ruffcheck="ruff check --fix --select=E,F,I"
```

### Team Workflow

```
# Recommended workflow:
1. Add ruff to your project's dev dependencies
2. Create a pyproject.toml with agreed-upon settings
3. Set up pre-commit hooks
4. Configure CI to enforce rules
5. Use the same settings across IDE configurations
```

### Incremental Adoption

```bash
# Start with minimal rule selection
ruff check --select=E,F file.py

# Gradually add more rules as codebase improves
ruff check --select=E,F,I,B file.py

# Fix violations one category at a time
ruff check --select=E --fix file.py
ruff check --select=I --fix file.py
```

### Integration with Other Tools

```bash
# Use with pytest
python -m pytest --ruff

# Combine with other tools in CI
ruff check --output-format=github .
```