# Conda Command Cheat Sheet

This document provides a comprehensive overview of essential Conda commands, with descriptions and examples for each.

## Table of Contents

- [Installation and Setup](#installation-and-setup)
- [Environment Management](#environment-management)
- [Package Management](#package-management)
- [Environment Configuration](#environment-configuration)
- [Channels Management](#channels-management)
- [Conda Information](#conda-information)
- [Environment Variables](#environment-variables)
- [Exporting and Importing](#exporting-and-importing)
- [Cleaning and Maintenance](#cleaning-and-maintenance)
- [Advanced Usage](#advanced-usage)
- [Conda with Jupyter](#conda-with-jupyter)
- [Troubleshooting](#troubleshooting)
- [Best Practices](#best-practices)
- [Conda Workflow Examples](#conda-workflow-examples)

## Installation and Setup
_Install and configure Conda on various operating systems._

### Installing Conda

```bash
# Download Miniconda installer
## For Windows
# Download the .exe installer from https://docs.conda.io/en/latest/miniconda.html

## For macOS
curl -O https://repo.anaconda.com/miniconda/Miniconda3-latest-MacOSX-x86_64.sh
bash Miniconda3-latest-MacOSX-x86_64.sh

## For Linux
curl -O https://repo.anaconda.com/miniconda/Miniconda3-latest-Linux-x86_64.sh
bash Miniconda3-latest-Linux-x86_64.sh
```

### Verifying Installation

```bash
# Check Conda version
conda --version

# Initialize conda for your shell
conda init [shell_name]  # e.g., conda init bash, conda init zsh, conda init powershell
```

<div style="page-break-after: always;"></div>

## Environment Management
_Commands for creating and managing Conda environments._

### Creating Environments

```bash
# Create a new environment with the latest Python version
conda create --name myenv

# Create an environment with a specific Python version
conda create --name myenv python=3.9

# Create an environment with specific packages
conda create --name myenv python=3.9 numpy pandas matplotlib

# Create an environment from a YAML file
conda env create -f environment.yml

# Create an environment in a specific location
conda create --prefix ./envs/myenv python=3.9
```

### Activating and Deactivating Environments

```bash
# Activate an environment
conda activate myenv

# Deactivate current environment and return to base
conda deactivate
```

### Listing Environments

```bash
# List all environments
conda env list
conda info --envs

# List all packages in current environment
conda list
```

### Removing Environments

```bash
# Remove an environment
conda env remove --name myenv

# Remove an environment at a specific path
conda env remove --prefix ./envs/myenv
```

### Renaming Environments

```bash
# Rename an environment (requires two steps)
# 1. Clone existing environment with new name
conda create --name new_name --clone old_name

# 2. Delete the old environment
conda env remove --name old_name
```

<div style="page-break-after: always;"></div>

## Package Management
_Commands for installing, updating, and removing packages._

### Installing Packages

```bash
# Install a package in the current environment
conda install package_name

# Install a specific version of a package
conda install package_name=1.2.3

# Install multiple packages
conda install package1 package2 package3

# Install a package from a specific channel
conda install --channel conda-forge package_name

# Install packages without asking for confirmation
conda install --yes package_name

# Install a pip package when no conda package exists
pip install package_name
```

### Updating Packages

```bash
# Update a specific package
conda update package_name

# Update all packages in the current environment
conda update --all

# Update conda itself
conda update conda

# Update anaconda metapackage (if installed)
conda update anaconda
```

### Removing Packages

```bash
# Remove a package
conda remove package_name

# Remove multiple packages
conda remove package1 package2

# Remove a package and its dependencies not used by other packages
conda remove --all package_name
```

### Searching for Packages

```bash
# Search for a package
conda search package_name

# Search for a package with a specific version
conda search package_name=1.2.3

# Search for a package in a specific channel
conda search --channel conda-forge package_name

# Get detailed information about a package
conda search --info package_name
```

<div style="page-break-after: always;"></div>

## Environment Configuration
_Commands for configuring and customizing Conda environments._

### Configuration Settings

```bash
# Show all configuration settings
conda config --show

# Show a specific configuration setting
conda config --show channels

# Get configuration value
conda config --get channels

# Set a configuration option
conda config --set always_yes True

# Add a channel to the top of the channel list
conda config --add channels conda-forge

# Remove a configuration option
conda config --remove-key always_yes
```

### Common Configuration Options

```bash
# Always say yes to installation prompts
conda config --set always_yes True

# Use strict channel priority
conda config --set channel_priority strict

# Automatically activate base environment
conda config --set auto_activate_base True

# Disable automatically activating base environment
conda config --set auto_activate_base False

# Disable showing channel URLs when displaying what is going to be downloaded
conda config --set show_channel_urls False
```

### Environment Variables

```bash
# Set environment variables in activate scripts
mkdir -p $CONDA_PREFIX/etc/conda/activate.d
echo 'export MY_VAR=my_value' > $CONDA_PREFIX/etc/conda/activate.d/env_vars.sh

# Unset environment variables in deactivate scripts
mkdir -p $CONDA_PREFIX/etc/conda/deactivate.d
echo 'unset MY_VAR' > $CONDA_PREFIX/etc/conda/deactivate.d/env_vars.sh
```

<div style="page-break-after: always;"></div>

## Channels Management
_Commands for managing Conda package channels._

### Managing Channels

```bash
# List currently configured channels
conda config --show channels

# Add a channel to the bottom of the channel list
conda config --append channels conda-forge

# Add a channel to the top of the channel list
conda config --prepend channels conda-forge

# Remove a channel
conda config --remove channels conda-forge

# Set default channels
conda config --set channels defaults

# Disable a channel
conda config --set channels --system
```

### Popular Conda Channels

```bash
# Add the conda-forge channel (community-maintained packages)
conda config --add channels conda-forge

# Add the bioconda channel (bioinformatics packages)
conda config --add channels bioconda

# Add the pytorch channel
conda config --add channels pytorch

# Add the r channel (R packages)
conda config --add channels r

# Add the nvidia channel (CUDA, GPU libraries)
conda config --add channels nvidia
```

<div style="page-break-after: always;"></div>

## Conda Information
_Commands for getting information about Conda and environments._

### System Information

```bash
# Show information about current conda installation
conda info

# Show information about current environment
conda info --envs

# Show information about dependencies
conda info package_name

# Show installed packages
conda list

# Show packages that depend on a specific package
conda list --explicit
```

### Environment Information

```bash
# List all environments
conda info --envs

# List packages in current environment
conda list

# List packages in specific environment
conda list --name myenv

# List packages installed in a specific environment
conda list --prefix /path/to/env

# Show environment locations
conda info --locations

# List packages not in a conda channel
conda list --show-channel-urls
```

### Dependency Information

```bash
# Check dependency conflicts
conda search --info package_name

# Find packages depending on a specific package
conda search --reverse-dependency package_name

# Check package availability and versions
conda search package_name

# List all revisions made to the current environment
conda list --revisions
```

<div style="page-break-after: always;"></div>

## Exporting and Importing
_Commands for sharing and reproducing Conda environments._

### Exporting Environments

```bash
# Export environment to YAML file
conda env export > environment.yml

# Export environment with only explicitly installed packages
conda env export --from-history > environment.yml

# Export environment with exact platform-specific builds
conda env export --explicit > spec-file.txt

# Export with no builds (more cross-platform compatible)
conda env export --no-builds > environment.yml
```

### Importing Environments

```bash
# Create environment from YAML file
conda env create -f environment.yml

# Create environment from explicit spec file
conda create --name myenv --file spec-file.txt

# Update existing environment from YAML file
conda env update --name myenv --file environment.yml

# Update current environment from YAML file
conda env update --file environment.yml
```

### Sharing Environments

```bash
# Clone an environment
conda create --clone source_env --name target_env

# Create environment from another user's exported file
conda env create -f https://path/to/environment.yml

# Create environment from a specific environment on Anaconda.org
conda env create username/env_name
```

<div style="page-break-after: always;"></div>

## Cleaning and Maintenance
_Commands for maintaining and optimizing Conda installations._

### Cleaning Conda

```bash
# Remove unused packages and caches
conda clean --all

# Remove index cache
conda clean --index-cache

# Remove tarballs
conda clean --tarballs

# Remove unused packages
conda clean --packages

# Clean all with yes to all prompts
conda clean --all --yes
```

### Storage Optimization

```bash
# Check size of environments and packages
du -sh ~/miniconda3/envs/*

# Find the largest packages
conda list --explicit | grep -v "#" | xargs -n1 du -sh | sort -hr | head

# Use hard links between environments to save space
conda create --clone base --name new_env --hard-link
```

### Environment Revisions

```bash
# List all revisions made to the current environment
conda list --revisions

# Restore environment to a previous revision
conda install --revision=REVNUM

# Delete an environment revision
conda remove --revision=REVNUM
```

<div style="page-break-after: always;"></div>

## Advanced Usage
_Advanced Conda features and workflows._

### Pinning Package Versions

```bash
# Create a pinning file
mkdir -p $CONDA_PREFIX/conda-meta
echo "numpy 1.19.*" > $CONDA_PREFIX/conda-meta/pinned

# Multiple pinned packages example
cat << EOF > $CONDA_PREFIX/conda-meta/pinned
numpy 1.19.*
scipy 1.5.*
pandas 1.*
EOF
```

### Offline Mode

```bash
# Use conda in offline mode
conda install --offline package_name

# Download packages without installing
conda install --download-only package_name

# Create a local Conda package cache
conda create -n offline_env --download-only python=3.9 numpy pandas
```

### Creating Custom Channels

```bash
# Install conda-build
conda install conda-build

# Build a package from a recipe
conda build path/to/recipe

# Convert a package for other platforms
conda convert --platform all package.tar.bz2 -o outputdir/

# Upload a package to Anaconda.org
anaconda upload /path/to/package.tar.bz2
```

### Conda Development

```bash
# Install conda-develop
pip install conda-develop

# Install local package in development mode
conda develop /path/to/local/package

# Create conda development environment
conda create -n dev python=3.9 conda-build anaconda-client
```

<div style="page-break-after: always;"></div>

## Conda with Jupyter
_Managing Jupyter notebooks with Conda environments._

### Installing Jupyter

```bash
# Install Jupyter in base environment
conda install -n base jupyter

# Install Jupyter in current environment
conda install jupyter

# Install JupyterLab
conda install -c conda-forge jupyterlab
```

### Managing Jupyter Kernels

```bash
# Install ipykernel in an environment
conda install -n myenv ipykernel

# Register the environment as a Jupyter kernel
conda activate myenv
python -m ipykernel install --user --name myenv --display-name "Python (myenv)"

# List available Jupyter kernels
jupyter kernelspec list

# Remove a Jupyter kernel
jupyter kernelspec uninstall myenv
```

### Jupyter Extensions

```bash
# Install notebook extensions
conda install -c conda-forge jupyter_contrib_nbextensions

# Enable extensions configuration
jupyter contrib nbextension install --user

# Install JupyterLab extensions
conda install -c conda-forge jupyter_nbextensions_configurator

# Install widget extensions
conda install -c conda-forge ipywidgets
jupyter nbextension enable --py widgetsnbextension
```

<div style="page-break-after: always;"></div>

## Troubleshooting
_Commands and techniques for resolving Conda issues._

### Common Issues

```bash
# Fix broken environment
conda update --all

# Reset environment when packages are in an inconsistent state
conda env export --no-builds > saved_env.yml
conda deactivate
conda env remove -n myenv
conda env create -f saved_env.yml

# Fix "RemoveError: Cannot remove entries from root environment"
conda clean --all
conda update -n base conda
```

### Package Conflicts

```bash
# Install a package with conflict resolution
conda install --strict-channel-priority package_name

# Force reinstall a package
conda install --force-reinstall package_name

# Get detailed info about why a package can't be installed
conda search --info package_name

# Check package dependencies
conda search --info --reverse-dependency package_name

# Install specific build of a package
conda install package_name=1.2.3=h12345_0
```

### Connection Issues

```bash
# Test connection
conda search numpy

# Use alternative channels when default is unavailable
conda install -c conda-forge package_name

# Set proxy settings
conda config --set proxy_servers.http http://user:pass@corp.com:8080
conda config --set proxy_servers.https https://user:pass@corp.com:8080
```

<div style="page-break-after: always;"></div>

## Best Practices
_Recommendations for effective Conda usage._

### Environment Organization

1. **Create Separate Environments for Projects**
   ```bash
   # Create project-specific environments
   conda create -n project_name python=3.9 package1 package2
   ```

2. **Use Environment Files for Reproducibility**
   ```bash
   # Export environment
   conda env export --from-history > environment.yml
   
   # Create from file
   conda env create -f environment.yml
   ```

3. **Standardize Naming Conventions**
   ```bash
   # Example naming convention
   conda create -n project_python39_gpu python=3.9 tensorflow-gpu
   ```

### Package Management

1. **Prefer Conda Packages Over Pip**
   ```bash
   # First try conda install
   conda install package_name
   
   # Only use pip if not available in conda
   pip install package_name
   ```

2. **Update Regularly But Cautiously**
   ```bash
   # Update non-critical environments regularly
   conda update --all
   
   # Pin critical dependencies
   echo "numpy 1.19.*" > $CONDA_PREFIX/conda-meta/pinned
   ```

3. **Use Conda-Forge for Broader Package Availability**
   ```bash
   # Add conda-forge and use strict priority
   conda config --add channels conda-forge
   conda config --set channel_priority strict
   ```

### Performance and Storage

1. **Clean Unused Packages and Caches**
   ```bash
   # Regular maintenance
   conda clean --all
   ```

2. **Use Hard Links to Save Space**
   ```bash
   # Use hard links when cloning environments
   conda create --clone base --name new_env --hard-link
   ```

3. **Minimize Base Environment Size**
   ```bash
   # Keep base minimal and create specific environments
   conda create -n data_science numpy pandas matplotlib scikit-learn
   ```

<div style="page-break-after: always;"></div>

## Conda Workflow Examples
_Practical examples of common Conda workflows._

### Data Science Project Setup

```bash
# Create a new environment for data science
conda create -n data_science python=3.9

# Activate the environment
conda activate data_science

# Install common data science packages
conda install numpy pandas matplotlib scikit-learn jupyter

# Install additional packages from conda-forge
conda install -c conda-forge plotly lightgbm

# Setup Jupyter kernel
python -m ipykernel install --user --name data_science --display-name "Python (Data Science)"

# Export environment for reproducibility
conda env export --from-history > environment.yml
```

### Deep Learning Environment

```bash
# Create a TensorFlow environment
conda create -n tensorflow python=3.9
conda activate tensorflow
conda install tensorflow matplotlib pandas jupyter

# Create a PyTorch environment
conda create -n pytorch python=3.9
conda activate pytorch
conda install pytorch torchvision torchaudio cudatoolkit=11.3 -c pytorch
conda install matplotlib pandas jupyter

# Setup Jupyter kernels for both
conda activate tensorflow
python -m ipykernel install --user --name tensorflow --display-name "Python (TensorFlow)"

conda activate pytorch
python -m ipykernel install --user --name pytorch --display-name "Python (PyTorch)"
```

### Python Web Development Environment

```bash
# Create a web development environment
conda create -n web_dev python=3.9
conda activate web_dev

# Install web development packages
conda install flask sqlalchemy
conda install -c conda-forge fastapi uvicorn

# Install additional tools
pip install pytest-cov flake8 black

# Export environment
conda env export --from-history > web_dev_environment.yml
```

### Scientific Computing with R and Python

```bash
# Create an environment with both Python and R
conda create -n science python=3.9 r-base r-essentials

# Activate environment
conda activate science

# Install Python scientific packages
conda install numpy scipy pandas matplotlib statsmodels seaborn

# Install R packages via conda
conda install r-ggplot2 r-dplyr r-tidyr r-caret

# Install R packages via R (if not available in conda)
R -e "install.packages('specialized_package', repos='http://cran.r-project.org')"

# Install Jupyter with R and Python support
conda install jupyter r-irkernel

# Export environment
conda env export > science_environment.yml
```