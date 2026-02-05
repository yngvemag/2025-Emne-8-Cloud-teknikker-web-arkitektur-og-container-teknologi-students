# Git Command Line Manual

This manual provides a comprehensive overview of Git commands, their syntax, and available flags. It is structured as a Markdown table for clarity.

## Table of Contents

- [Git Command Line Manual](#git-command-line-manual)
  - [Table of Contents](#table-of-contents)
  - [Git Configuration](#git-configuration)
  - [Repository Management](#repository-management)
  - [Basic Snapshotting](#basic-snapshotting)
  - [Branching \& Merging](#branching--merging)
  - [Remote Repositories](#remote-repositories)
  - [Stashing \& Cleaning](#stashing--cleaning)
  - [Inspection \& Comparison](#inspection--comparison)
  - [Patching](#patching)
  - [Debugging](#debugging)
  - [Advanced Operations](#advanced-operations)
- [Git Command Examples](#git-command-examples)
  - [Git Configuration](#git-configuration-1)
  - [Repository Management](#repository-management-1)
  - [Repository Management](#repository-management-2)
  - [Basic Snapshotting](#basic-snapshotting-1)
  - [Branching \& Merging](#branching--merging-1)
  - [Remote Repositories](#remote-repositories-1)
  - [Stashing \& Cleaning](#stashing--cleaning-1)
  - [Inspection \& Comparison](#inspection--comparison-1)
  - [Patching](#patching-1)
  - [Debugging](#debugging-1)
  - [Advanced Operations](#advanced-operations-1)
  - [Branching \& Merging](#branching--merging-2)
  - [Remote Repositories](#remote-repositories-2)
  - [Stashing \& Cleaning](#stashing--cleaning-2)
  - [Inspection \& Comparison](#inspection--comparison-2)
  - [Patching](#patching-2)
  - [Debugging](#debugging-2)
  - [Advanced Operations](#advanced-operations-2)

## Git Configuration

| Command | Description | Common Flags |
|---------|-------------|--------------|
| `git config` | Get and set repository or global options | `--global`, `--system`, `--local`, `--list`, `--edit` |

## Repository Management

| Command | Description | Common Flags |
|---------|-------------|--------------|
| `git init` | Initialize a new Git repository | `--bare`, `--template=<dir>` |
| `git clone <repo>` | Clone a repository into a new directory | `--depth <n>`, `--branch <name>`, `--recurse-submodules` |

## Basic Snapshotting

| Command | Description | Common Flags |
|---------|-------------|--------------|
| `git add <file>` | Add file contents to the index | `-A`, `-u`, `.` |
| `git status` | Show the working tree status | `-s`, `--short`, `--porcelain` |
| `git commit` | Record changes to the repository | `-m <msg>`, `--amend`, `--no-edit`, `-a` |
| `git rm` | Remove files from working tree and index | `--cached`, `-r` |
| `git mv` | Move or rename a file, directory, or symlink | _No flags_ |

## Branching & Merging

| Command | Description | Common Flags |
|---------|-------------|--------------|
| `git branch` | List, create, or delete branches | `-d`, `-D`, `-a`, `-r`, `--merged`, `--no-merged` |
| `git checkout` | Switch branches or restore files | `-b`, `--track`, `--detach` |
| `git switch` | Switch branches | `-c`, `--create`, `--detach` |
| `git merge` | Join two or more development histories | `--no-ff`, `--squash`, `--abort` |
| `git rebase` | Reapply commits on top of another base tip | `-i`, `--continue`, `--abort`, `--skip` |

## Remote Repositories

| Command | Description | Common Flags |
|---------|-------------|--------------|
| `git remote` | Manage set of tracked repositories | `-v`, `add`, `remove`, `rename` |
| `git fetch` | Download objects and refs from another repository | `--all`, `--prune`, `--depth` |
| `git pull` | Fetch from and integrate with another repository or branch | `--rebase`, `--no-commit`, `--ff-only` |
| `git push` | Update remote refs along with associated objects | `--force`, `--tags`, `--delete`, `--set-upstream` |

## Stashing & Cleaning

| Command | Description | Common Flags |
|---------|-------------|--------------|
| `git stash` | Stash the changes in a dirty working directory | `save`, `pop`, `apply`, `list`, `drop`, `clear` |
| `git clean` | Remove untracked files from the working tree | `-f`, `-d`, `-n`, `-x`, `-X` |

## Inspection & Comparison

| Command | Description | Common Flags |
|---------|-------------|--------------|
| `git log` | Show commit logs | `--oneline`, `--graph`, `--decorate`, `--stat` |
| `git show` | Show various types of objects | `--name-only`, `--name-status` |
| `git diff` | Show changes between commits, commit and working tree, etc. | `--staged`, `--cached`, `--name-only`, `--color` |
| `git blame` | Show what revision and author last modified each line of a file | `-L`, `--show-name`, `--date` |

## Patching

| Command | Description | Common Flags |
|---------|-------------|--------------|
| `git apply` | Apply a patch to files and/or to the index | `--stat`, `--check`, `--reverse`, `--index` |
| `git format-patch` | Prepare patches for e-mail submission | `-n`, `--stdout`, `--cover-letter` |

## Debugging

| Command | Description | Common Flags |
|---------|-------------|--------------|
| `git bisect` | Find the commit that introduced a bug by binary search | `start`, `bad`, `good`, `reset`, `visualize` |
| `git grep` | Print lines matching a pattern | `-n`, `--color`, `--heading`, `--break`, `--cached` |

## Advanced Operations

| Command | Description | Common Flags |
|---------|-------------|--------------|
| `git reflog` | Show history of HEAD or refs | _No flags_ |
| `git cherry-pick` | Apply the changes introduced by some existing commits | `-n`, `--edit`, `--signoff`, `--strategy` |
| `git revert` | Revert some existing commits | `--no-edit`, `--mainline` |
| `git submodule` | Initialize, update or inspect submodules | `add`, `init`, `update`, `status`, `sync` |

---


# Git Command Examples

This document provides practical examples of commonly used Git commands grouped by category.

## Git Configuration
```bash
git config --global user.name "Your Name"
git config --global user.email "your.email@example.com"
git config --list

# Automatically push the current branch to a remote branch of the same name
git config --global push.default current
```

## Repository Management
```bash
git init myproject
cd myproject
git clone https://github.com/user/repo.git# Git Command Examples

This document provides practical examples of commonly used Git commands grouped by category.

## Git Configuration
```bash
git config --global user.name "Your Name"
git config --global user.email "your.email@example.com"
git config --list
```

## Repository Management
```bash
git init myproject
cd myproject
git clone https://github.com/user/repo.git
```

## Basic Snapshotting
```bash
touch file.txt
git add file.txt
git status
git commit -m "Add file.txt"
git rm file.txt
git mv oldname.txt newname.txt
```

## Branching & Merging
```bash
git branch feature-xyz
git checkout feature-xyz
git switch -c feature-abc
git merge main
git rebase main
```

## Remote Repositories
```bash
git remote add origin https://github.com/user/repo.git
git fetch origin
git pull origin main
git push origin main
git push --set-upstream origin feature-xyz
```

## Stashing & Cleaning
```bash
git stash
git stash list
git stash apply
git stash pop
git clean -n       # dry run
git clean -f       # force delete untracked files
```

## Inspection & Comparison
```bash
git log --oneline --graph
git show HEAD
git diff
git diff --staged
git blame file.txt
```

## Patching
```bash
git diff > changes.patch
git apply changes.patch
git format-patch -1 HEAD
```

## Debugging
```bash
git bisect start
git bisect bad
git bisect good <commit>
git bisect reset
git grep TODO
```

## Advanced Operations
```bash
git reflog
git cherry-pick <commit>
git revert <commit>
git submodule add https://github.com/user/submodule.git path/to/submodule
git submodule update --init
```

---
Let me know if you’d like each example paired with an explanation or visual flow diagrams for these workflows.

```

## Basic Snapshotting
```bash
touch file.txt
git add file.txt
git status
git commit -m "Add file.txt"
git rm file.txt
git mv oldname.txt newname.txt
```

## Branching & Merging
```bash
git branch feature-xyz
git checkout feature-xyz
git switch -c feature-abc
git merge main
git rebase main
```

## Remote Repositories
```bash
git remote add origin https://github.com/user/repo.git
git fetch origin
git pull origin main
git push origin main
git push --set-upstream origin feature-xyz
```

## Stashing & Cleaning
```bash
git stash
git stash list
git stash apply
git stash pop
git clean -n       # dry run
git clean -f       # force delete untracked files
```

## Inspection & Comparison
```bash
git log --oneline --graph
git show HEAD
git diff
git diff --staged
git blame file.txt
```

## Patching
```bash
git diff > changes.patch
git apply changes.patch
git format-patch -1 HEAD
```

## Debugging
```bash
git bisect start
git bisect bad
git bisect good <commit>
git bisect reset
git grep TODO
```

## Advanced Operations
```bash
git reflog
git cherry-pick <commit>
git revert <commit>
git submodule add https://github.com/user/submodule.git path/to/submodule
git submodule update --init
```

---
Let me know if you’d like each example paired with an explanation or visual flow diagrams for these workflows.


