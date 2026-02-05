# Vim / Vi Editor – Comprehensive Documentation

This document provides a **practical and comprehensive guide to the Vi/Vim editor**, inspired by CLI-style documentation.  
It is suitable as a **reference, teaching aid, and daily cheat sheet**.

---

## Table of Contents

- [What is Vim?](#what-is-vim)
- [Starting Vim](#starting-vim)
- [Vim Modes](#vim-modes)
- [Basic Navigation](#basic-navigation)
- [Editing Text](#editing-text)
- [Deleting Text](#deleting-text)
- [Undo, Redo, Copy & Paste](#undo-redo-copy--paste)
- [Searching in Vim](#searching-in-vim)
- [Replacing Text](#replacing-text)
- [Working with Files](#working-with-files)
- [Visual Mode](#visual-mode)
- [Useful Vim Settings](#useful-vim-settings)
- [SED – Search, Edit & Delete from Command Line](#sed--search-edit--delete-from-command-line)
- [Vim Cheat Sheet](#vim-cheat-sheet)

---

## What is Vim?

**Vim (Vi IMproved)** is a powerful, modal text editor commonly used in:
- Linux / Unix environments
- Server administration
- Programming and scripting
- SSH / terminal-based workflows

Vim is fast, keyboard-driven, and highly configurable.

---

## Starting Vim

```bash
vim filename.txt
vi filename.txt
```

Open multiple files:

```bash
vim file1.txt file2.txt
```

Open at a specific line:

```bash
vim +42 filename.txt
```

---

## Vim Modes

| Mode | Description |
|----|----|
| Normal | Default mode for navigation and commands |
| Insert | Used to insert text |
| Visual | Select text |
| Command | Execute commands (`:`) |

### Switching Modes

| Action | Command |
|----|----|
| Insert mode | `i`, `a`, `o` |
| Normal mode | `Esc` |
| Visual mode | `v`, `V`, `Ctrl+v` |
| Command mode | `:` |

---

## Basic Navigation

| Command | Action |
|----|----|
| `h` | Left |
| `j` | Down |
| `k` | Up |
| `l` | Right |
| `0` | Start of line |
| `$` | End of line |
| `w` | Next word |
| `b` | Previous word |
| `gg` | Top of file |
| `G` | Bottom of file |
| `:42` | Go to line 42 |

---

## Editing Text

### Insert Commands

| Command | Description |
|----|----|
| `i` | Insert before cursor |
| `a` | Insert after cursor |
| `o` | New line below |
| `O` | New line above |

---

## Deleting Text

| Command | Description |
|----|----|
| `x` | Delete character |
| `dw` | Delete word |
| `dd` | Delete line |
| `D` | Delete to end of line |
| `d$` | Delete to end of line |
| `d0` | Delete to start of line |
| `5dd` | Delete 5 lines |

---

## Undo, Redo, Copy & Paste

| Command | Action |
|----|----|
| `u` | Undo |
| `Ctrl+r` | Redo |
| `yy` | Copy line |
| `5yy` | Copy 5 lines |
| `p` | Paste below |
| `P` | Paste above |

---

## Searching in Vim

### Forward Search

```vim
/pattern
```

### Backward Search

```vim
?pattern
```

| Key | Action |
|----|----|
| `n` | Next match |
| `N` | Previous match |
| `*` | Search word under cursor |
| `#` | Backward search word |

---

## Replacing Text

### Replace in Line

```vim
:s/old/new/
```

### Replace All in File

```vim
:%s/old/new/g
```

### Replace with Confirmation

```vim
:%s/old/new/gc
```

---

## Working with Files

| Command | Action |
|----|----|
| `:w` | Save |
| `:q` | Quit |
| `:wq` | Save & quit |
| `:q!` | Quit without saving |
| `:e filename` | Open file |
| `:r filename` | Insert file content |

---

## Visual Mode

| Command | Description |
|----|----|
| `v` | Character selection |
| `V` | Line selection |
| `Ctrl+v` | Block selection |
| `y` | Copy selection |
| `d` | Delete selection |

---

## Useful Vim Settings

Enable line numbers:

```vim
:set number
```

Enable syntax highlighting:

```vim
:syntax on
```

Persistent settings (`~/.vimrc`):

```vim
set number
set tabstop=4
set shiftwidth=4
set expandtab
syntax on
```

---

## SED – Search, Edit & Delete from Command Line

`sed` is a **stream editor** for modifying files without opening an editor.

### Search

```bash
sed -n '/pattern/p' file.txt
```

### Replace

```bash
sed 's/old/new/' file.txt
```

Replace globally:

```bash
sed 's/old/new/g' file.txt
```

In-place replace:

```bash
sed -i 's/old/new/g' file.txt
```

### Delete Lines

Delete matching lines:

```bash
sed '/pattern/d' file.txt
```

Delete line number:

```bash
sed '5d' file.txt
```

Delete range:

```bash
sed '5,10d' file.txt
```

---

## Vim Cheat Sheet

| Task | Command |
|----|----|
| Save | `:w` |
| Quit | `:q` |
| Force quit | `:q!` |
| Undo | `u` |
| Redo | `Ctrl+r` |
| Search | `/text` |
| Replace all | `:%s/a/b/g` |
| Delete line | `dd` |
| Copy line | `yy` |
| Paste | `p` |

---

## Final Notes

- Vim is **modal** – always know your mode.
- Learn small commands incrementally.
- Combine commands for powerful workflows.

> *“Vim is not hard – it’s just honest.”*
