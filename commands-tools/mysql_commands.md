# MySQL Client Command Cheat Sheet

This document provides a comprehensive overview of essential MySQL client commands, with descriptions and examples for each.

## Table of Contents

- [Installation and Setup](#installation-and-setup)
- [Basic MySQL Client Usage](#basic-mysql-client-usage)
- [Database and Table Management](#database-and-table-management)
- [User Management and Security](#user-management-and-security)
- [Data Manipulation](#data-manipulation)
- [Data Querying](#data-querying)
- [Transactions](#transactions)
- [Import and Export](#import-and-export)
- [Performance and Optimization](#performance-and-optimization)
- [MySQL Client Programs](#mysql-client-programs)
- [MySQL Configuration](#mysql-configuration)
- [Backup and Recovery](#backup-and-recovery)
- [Troubleshooting](#troubleshooting)
- [MySQL Workflow Examples](#mysql-workflow-examples)
- [Best Practices](#best-practices)

## Installation and Setup
_Install and configure MySQL client on various operating systems._

### Installing MySQL Client

```bash
# Ubuntu/Debian
sudo apt update
sudo apt install mysql-client

# Red Hat/CentOS/Fedora
sudo dnf install mysql

# macOS with Homebrew
brew install mysql-client

# Windows
# Download and install MySQL installer from https://dev.mysql.com/downloads/installer/
```

### Verifying Installation

```bash
# Check MySQL client version
mysql --version
```

<div style="page-break-after: always;"></div>

## Basic MySQL Client Usage
_Essential commands for connecting to and interacting with MySQL servers._

### Connecting to MySQL Server

```bash
# Basic connection to local server
mysql -u username -p

# Connect to specific host
mysql -h hostname -u username -p

# Connect to specific host and port
mysql -h hostname -P port_number -u username -p

# Connect to specific database
mysql -u username -p database_name

# Connect with password in command (not recommended for security)
mysql -u username -pYourPassword

# Connect using defaults file
mysql --defaults-file=/path/to/my.cnf
```

### Command Line Options

| Option | Description |
|--------|-------------|
| -h, --host=name | Connect to host |
| -P, --port=# | Port number to use for connection |
| -u, --user=name | User for login |
| -p, --password[=name] | Password to use when connecting |
| -D, --database=name | Database to use |
| -e, --execute=name | Execute command and quit |
| --ssl | Enable SSL for connection |
| --compress | Use compression in server/client protocol |
| --show-warnings | Show warnings after each statement |
| --safe-updates | Allow only those UPDATE and DELETE statements with keys |
| -A, --no-auto-rehash | No automatic rehashing |
| -B, --batch | Don't use history file, disable interactive behavior |

### MySQL Client Prompt Commands

```sql
-- Help
help;
\h

-- Display current status
status;
\s

-- Clear the current input statement
\c

-- Use a specific database
use database_name;

-- Exit MySQL client
exit;
quit;
\q

-- Edit command with editor
\e

-- Execute system shell command
\! command
system command

-- Show warnings
\w

-- Show current database
select database();
```

<div style="page-break-after: always;"></div>

## Database and Table Management
_Commands for creating, altering, and managing databases and tables._

### Database Operations

```sql
-- List all databases
SHOW DATABASES;

-- Create a new database
CREATE DATABASE database_name;
CREATE DATABASE database_name CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Select a database to use
USE database_name;

-- Drop (delete) a database
DROP DATABASE database_name;
DROP DATABASE IF EXISTS database_name;

-- Get current database
SELECT DATABASE();

-- Show database create statement
SHOW CREATE DATABASE database_name;

-- Alter database character set/collation
ALTER DATABASE database_name CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
```

### Table Operations

```sql
-- List all tables in the current database
SHOW TABLES;

-- List tables in specific database
SHOW TABLES FROM database_name;

-- Show table structure
DESCRIBE table_name;
DESC table_name;
SHOW COLUMNS FROM table_name;
SHOW FIELDS FROM table_name;

-- Create table
CREATE TABLE table_name (
    column1 datatype constraints,
    column2 datatype constraints,
    ...
    table_constraints
);

-- Example: Create users table
CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    email VARCHAR(100) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Show create table statement
SHOW CREATE TABLE table_name;

-- Drop table
DROP TABLE table_name;
DROP TABLE IF EXISTS table_name;

-- Truncate table (remove all data but keep structure)
TRUNCATE TABLE table_name;

-- Rename table
RENAME TABLE old_table_name TO new_table_name;
ALTER TABLE old_table_name RENAME TO new_table_name;

-- Copy table structure
CREATE TABLE new_table LIKE original_table;

-- Copy table structure and data
CREATE TABLE new_table AS SELECT * FROM original_table;
```

### Table Modification

```sql
-- Add column
ALTER TABLE table_name ADD column_name datatype constraints;
ALTER TABLE table_name ADD column_name datatype constraints AFTER existing_column;
ALTER TABLE table_name ADD column_name datatype constraints FIRST;

-- Modify column
ALTER TABLE table_name MODIFY column_name new_datatype new_constraints;

-- Change column (rename and modify)
ALTER TABLE table_name CHANGE old_column_name new_column_name new_datatype new_constraints;

-- Drop column
ALTER TABLE table_name DROP COLUMN column_name;

-- Add index
CREATE INDEX index_name ON table_name (column_name);
ALTER TABLE table_name ADD INDEX index_name (column_name);

-- Add unique index
CREATE UNIQUE INDEX index_name ON table_name (column_name);
ALTER TABLE table_name ADD UNIQUE index_name (column_name);

-- Add foreign key
ALTER TABLE table_name ADD CONSTRAINT constraint_name 
FOREIGN KEY (column_name) REFERENCES referenced_table(referenced_column);

-- Drop index
DROP INDEX index_name ON table_name;
ALTER TABLE table_name DROP INDEX index_name;

-- Drop foreign key
ALTER TABLE table_name DROP FOREIGN KEY constraint_name;

-- Show indexes
SHOW INDEX FROM table_name;
```

<div style="page-break-after: always;"></div>

## User Management and Security
_Commands for creating and managing MySQL users and their privileges._

### User Management

```sql
-- Create new user
CREATE USER 'username'@'host' IDENTIFIED BY 'password';
CREATE USER 'john'@'localhost' IDENTIFIED BY 'secret_password';
CREATE USER 'app_user'@'%' IDENTIFIED BY 'app_password'; -- % means any host

-- List users
SELECT user, host FROM mysql.user;

-- Change user password
ALTER USER 'username'@'host' IDENTIFIED BY 'new_password';
SET PASSWORD FOR 'username'@'host' = PASSWORD('new_password'); -- For MySQL < 5.7

-- Remove user
DROP USER 'username'@'host';
```

### Privilege Management

```sql
-- Grant privileges
GRANT privilege_type ON database_name.table_name TO 'username'@'host';

-- Grant multiple privileges
GRANT SELECT, INSERT, UPDATE ON database_name.table_name TO 'username'@'host';

-- Grant all privileges on database
GRANT ALL PRIVILEGES ON database_name.* TO 'username'@'host';

-- Grant all privileges on all databases
GRANT ALL PRIVILEGES ON *.* TO 'username'@'host';

-- Grant with GRANT OPTION
GRANT ALL PRIVILEGES ON database_name.* TO 'username'@'host' WITH GRANT OPTION;

-- Show grants for current user
SHOW GRANTS;

-- Show grants for specific user
SHOW GRANTS FOR 'username'@'host';

-- Revoke privileges
REVOKE privilege_type ON database_name.table_name FROM 'username'@'host';

-- Revoke all privileges
REVOKE ALL PRIVILEGES, GRANT OPTION FROM 'username'@'host';

-- Apply privilege changes
FLUSH PRIVILEGES;
```

### Common Privilege Types

| Privilege | Description |
|-----------|-------------|
| SELECT | Read data from tables |
| INSERT | Insert data into tables |
| UPDATE | Update existing data |
| DELETE | Delete data from tables |
| CREATE | Create new tables or databases |
| DROP | Delete tables or databases |
| ALTER | Modify table structure |
| INDEX | Create or drop indexes |
| REFERENCES | Create foreign keys |
| CREATE TEMPORARY TABLES | Create temporary tables |
| EXECUTE | Execute stored procedures |
| LOCK TABLES | Lock tables |
| CREATE VIEW | Create views |
| SHOW VIEW | View definitions of views |
| CREATE ROUTINE | Create stored procedures/functions |
| ALTER ROUTINE | Alter stored procedures/functions |
| TRIGGER | Create triggers |
| EVENT | Create events |
| SUPER | Administrative privileges |
| PROCESS | View server processes |
| RELOAD | Reload server settings |
| FILE | Read/write files on server |
| GRANT OPTION | Grant privileges to other users |

<div style="page-break-after: always;"></div>

## Data Manipulation
_Commands for inserting, updating, and deleting data._

### Insert Data

```sql
-- Basic insert
INSERT INTO table_name (column1, column2, column3)
VALUES (value1, value2, value3);

-- Insert multiple rows
INSERT INTO table_name (column1, column2)
VALUES 
    (value1, value2),
    (value3, value4),
    (value5, value6);

-- Insert with expressions
INSERT INTO table_name (name, created_date)
VALUES ('New Record', NOW());

-- Insert with SELECT
INSERT INTO target_table (column1, column2)
SELECT column_a, column_b FROM source_table WHERE condition;

-- Insert or update (upsert) using ON DUPLICATE KEY UPDATE
INSERT INTO table_name (id, name, count)
VALUES (1, 'Product', 10)
ON DUPLICATE KEY UPDATE count = count + 10;

-- Insert ignore (skip errors)
INSERT IGNORE INTO table_name (id, name)
VALUES (1, 'Already exists');
```

### Update Data

```sql
-- Basic update
UPDATE table_name
SET column1 = value1, column2 = value2
WHERE condition;

-- Update with expressions
UPDATE users
SET last_login = NOW(), login_count = login_count + 1
WHERE id = 123;

-- Update with JOIN
UPDATE table1 t1
JOIN table2 t2 ON t1.id = t2.id
SET t1.column1 = t2.column2
WHERE t2.status = 'active';

-- Update multiple tables
UPDATE table1, table2
SET table1.column1 = value1, table2.column2 = value2
WHERE table1.id = table2.id AND table1.status = 'pending';

-- Update with subquery
UPDATE products
SET price = price * 1.1
WHERE category_id IN (SELECT id FROM categories WHERE name = 'Electronics');

-- Update with LIMIT
UPDATE users
SET status = 'inactive'
WHERE last_login < DATE_SUB(NOW(), INTERVAL 1 YEAR)
ORDER BY last_login
LIMIT 100;
```

### Delete Data

```sql
-- Basic delete
DELETE FROM table_name WHERE condition;

-- Delete all rows
DELETE FROM table_name;

-- Delete with JOIN
DELETE t1
FROM table1 t1
JOIN table2 t2 ON t1.id = t2.ref_id
WHERE t2.status = 'expired';

-- Delete with subquery
DELETE FROM orders
WHERE customer_id IN (
    SELECT id FROM customers WHERE status = 'inactive'
);

-- Delete with LIMIT
DELETE FROM logs
WHERE created_at < DATE_SUB(NOW(), INTERVAL 30 DAY)
ORDER BY created_at
LIMIT 1000;

-- Delete multiple tables
DELETE t1, t2
FROM table1 t1
JOIN table2 t2 ON t1.id = t2.id
WHERE t1.status = 'inactive';
```

<div style="page-break-after: always;"></div>

## Data Querying
_Commands for querying and retrieving data._

### Basic Queries

```sql
-- Select all columns from a table
SELECT * FROM table_name;

-- Select specific columns
SELECT column1, column2 FROM table_name;

-- Select with condition
SELECT * FROM table_name WHERE condition;

-- Select with multiple conditions
SELECT * FROM users WHERE status = 'active' AND role = 'admin';

-- Select with OR condition
SELECT * FROM products WHERE category = 'Electronics' OR category = 'Computers';

-- Select with LIKE (pattern matching)
SELECT * FROM customers WHERE name LIKE 'Jo%';  -- Names starting with "Jo"
SELECT * FROM products WHERE description LIKE '%phone%';  -- Contains "phone"
SELECT * FROM codes WHERE code LIKE '_A%';  -- Second character is "A"

-- Select with IN operator
SELECT * FROM products WHERE category_id IN (1, 2, 5);
SELECT * FROM orders WHERE status IN ('shipped', 'delivered');

-- Select with NOT IN
SELECT * FROM products WHERE category_id NOT IN (3, 4);

-- Select with BETWEEN
SELECT * FROM products WHERE price BETWEEN 10 AND 50;
SELECT * FROM orders WHERE order_date BETWEEN '2023-01-01' AND '2023-06-30';

-- Select with IS NULL / IS NOT NULL
SELECT * FROM customers WHERE phone IS NULL;
SELECT * FROM users WHERE email IS NOT NULL;

-- Select with Regular Expressions
SELECT * FROM products WHERE name REGEXP '^[A-Z]';  -- Names starting with uppercase
SELECT * FROM customers WHERE phone REGEXP '^[0-9]{3}-[0-9]{3}-[0-9]{4}$';  -- Phone format xxx-xxx-xxxx
```

### Sorting and Limiting Results

```sql
-- Sort results (ORDER BY)
SELECT * FROM products ORDER BY price;  -- Ascending (default)
SELECT * FROM products ORDER BY price DESC;  -- Descending
SELECT * FROM users ORDER BY last_name ASC, first_name ASC;  -- Multiple columns

-- Limit results
SELECT * FROM products LIMIT 10;  -- First 10 records
SELECT * FROM products LIMIT 10, 5;  -- 5 records starting from the 11th
SELECT * FROM products LIMIT 5 OFFSET 10;  -- Same as above
```

### Aggregation and Grouping

```sql
-- Aggregate functions
SELECT COUNT(*) FROM users;
SELECT COUNT(DISTINCT country) FROM customers;
SELECT SUM(amount) FROM orders;
SELECT AVG(price) FROM products;
SELECT MAX(price) FROM products;
SELECT MIN(price) FROM products;

-- Group By
SELECT category, COUNT(*) AS product_count 
FROM products 
GROUP BY category;

SELECT customer_id, SUM(amount) AS total_spent
FROM orders
GROUP BY customer_id;

-- Having (filtering for groups)
SELECT category, COUNT(*) AS product_count 
FROM products 
GROUP BY category
HAVING product_count > 5;

SELECT customer_id, SUM(amount) AS total_spent
FROM orders
GROUP BY customer_id
HAVING total_spent > 1000;

-- Group by multiple columns
SELECT category, status, COUNT(*) AS product_count
FROM products
GROUP BY category, status;
```

### JOINs

```sql
-- INNER JOIN
SELECT orders.id, orders.amount, customers.name
FROM orders
INNER JOIN customers ON orders.customer_id = customers.id;

-- Using table aliases
SELECT o.id, o.amount, c.name
FROM orders o
INNER JOIN customers c ON o.customer_id = c.id;

-- LEFT JOIN
SELECT c.name, o.id
FROM customers c
LEFT JOIN orders o ON c.id = o.customer_id;

-- RIGHT JOIN
SELECT c.name, o.id
FROM orders o
RIGHT JOIN customers c ON o.customer_id = c.id;

-- Multiple joins
SELECT o.id, o.order_date, c.name, p.name AS product_name
FROM orders o
JOIN customers c ON o.customer_id = c.id
JOIN order_items oi ON o.id = oi.order_id
JOIN products p ON oi.product_id = p.id;

-- Self JOIN
SELECT e1.name AS employee, e2.name AS manager
FROM employees e1
LEFT JOIN employees e2 ON e1.manager_id = e2.id;

-- CROSS JOIN
SELECT c.name, p.name
FROM categories c
CROSS JOIN products p;
```

### Subqueries

```sql
-- Subquery in WHERE clause
SELECT name 
FROM products 
WHERE category_id IN (SELECT id FROM categories WHERE active = 1);

-- Subquery in SELECT
SELECT p.name, 
       (SELECT COUNT(*) FROM order_items WHERE product_id = p.id) AS times_ordered
FROM products p;

-- Subquery with EXISTS
SELECT c.name 
FROM customers c
WHERE EXISTS (
    SELECT 1 FROM orders o WHERE o.customer_id = c.id AND o.status = 'completed'
);

-- Subquery in FROM clause
SELECT avg_price_by_category.category, avg_price_by_category.avg_price
FROM (
    SELECT category, AVG(price) as avg_price
    FROM products
    GROUP BY category
) AS avg_price_by_category
WHERE avg_price_by_category.avg_price > 100;
```

### Common Table Expressions (CTE)

```sql
-- Basic CTE
WITH cte_name AS (
    SELECT column1, column2
    FROM table_name
    WHERE condition
)
SELECT * FROM cte_name;

-- Example: Find customers with high-value orders
WITH high_value_orders AS (
    SELECT customer_id, SUM(amount) AS total
    FROM orders
    GROUP BY customer_id
    HAVING total > 1000
)
SELECT c.name, hvo.total
FROM customers c
JOIN high_value_orders hvo ON c.id = hvo.customer_id
ORDER BY hvo.total DESC;

-- Multiple CTEs
WITH 
inactive_users AS (
    SELECT id FROM users WHERE last_login < DATE_SUB(NOW(), INTERVAL 1 YEAR)
),
inactive_orders AS (
    SELECT o.* FROM orders o
    JOIN inactive_users iu ON o.user_id = iu.id
)
SELECT COUNT(*) FROM inactive_orders;
```

<div style="page-break-after: always;"></div>

## Transactions
_Commands for managing data consistency with transactions._

### Basic Transaction Control

```sql
-- Start a transaction
START TRANSACTION;
BEGIN;

-- Commit a transaction
COMMIT;

-- Rollback a transaction
ROLLBACK;

-- Savepoints
SAVEPOINT savepoint_name;
ROLLBACK TO SAVEPOINT savepoint_name;
RELEASE SAVEPOINT savepoint_name;
```

### Transaction Example

```sql
-- Transfer money between accounts
START TRANSACTION;

-- Deduct from account 1
UPDATE accounts SET balance = balance - 100 WHERE id = 1;

-- Add to account 2
UPDATE accounts SET balance = balance + 100 WHERE id = 2;

-- Check if any errors occurred
-- If everything is good, commit:
COMMIT;
-- Otherwise rollback:
-- ROLLBACK;
```

### Transaction Isolation Levels

```sql
-- Set session isolation level
SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
SET SESSION TRANSACTION ISOLATION LEVEL READ COMMITTED;
SET SESSION TRANSACTION ISOLATION LEVEL REPEATABLE READ;  -- Default for MySQL
SET SESSION TRANSACTION ISOLATION LEVEL SERIALIZABLE;

-- Set next transaction isolation level
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

-- Check current isolation level
SELECT @@transaction_isolation;
```

<div style="page-break-after: always;"></div>

## Import and Export
_Commands for importing and exporting data._

### Export Data (from MySQL Client)

```sql
-- Export table to CSV
SELECT * FROM table_name
INTO OUTFILE '/path/to/file.csv'
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n';

-- Export query results to file
SELECT column1, column2
FROM table_name
WHERE condition
INTO OUTFILE '/path/to/file.txt';

-- Export with header
SELECT 'column1', 'column2'
UNION ALL
SELECT column1, column2 FROM table_name
INTO OUTFILE '/path/to/file.csv'
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n';
```

### Import Data (from MySQL Client)

```sql
-- Import CSV into table
LOAD DATA INFILE '/path/to/file.csv'
INTO TABLE table_name
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
IGNORE 1 ROWS;  -- Skip header row

-- Import with column specification
LOAD DATA INFILE '/path/to/file.csv'
INTO TABLE table_name
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
(column1, column2, @dummy, column3);  -- Map columns, skip one
```

### Using mysqlimport Command

```bash
# Basic import
mysqlimport -u username -p database_name /path/to/file.txt

# Import with options
mysqlimport --user=username --password \
  --fields-terminated-by=',' \
  --fields-enclosed-by='"' \
  --lines-terminated-by='\n' \
  --ignore-lines=1 \
  database_name /path/to/file.csv
```

### Using mysqldump Command

```bash
# Dump entire database
mysqldump -u username -p database_name > backup.sql

# Dump specific tables
mysqldump -u username -p database_name table1 table2 > backup.sql

# Dump structure only (no data)
mysqldump -u username -p --no-data database_name > schema.sql

# Dump data only (no create statements)
mysqldump -u username -p --no-create-info database_name > data.sql

# Dump with compression
mysqldump -u username -p database_name | gzip > backup.sql.gz

# Dump from remote server
mysqldump -h hostname -u username -p database_name > backup.sql

# Dump and exclude certain tables
mysqldump -u username -p database_name --ignore-table=database.table1 --ignore-table=database.table2 > backup.sql
```

### Import Dump Files

```bash
# Import SQL dump
mysql -u username -p database_name < backup.sql

# Import compressed dump
gunzip < backup.sql.gz | mysql -u username -p database_name

# Import and show progress (with pv - pipe viewer)
pv backup.sql | mysql -u username -p database_name
```

<div style="page-break-after: always;"></div>

## Performance and Optimization
_Commands for monitoring and improving MySQL performance._

### Query Optimization

```sql
-- Explain query execution plan
EXPLAIN SELECT * FROM table_name WHERE condition;

-- Analyze tables (update statistics)
ANALYZE TABLE table_name;

-- Check for slow queries
SHOW VARIABLES LIKE 'slow_query%';
SHOW VARIABLES LIKE 'long_query_time';

-- Set slow query log
SET GLOBAL slow_query_log = 'ON';
SET GLOBAL long_query_time = 2;  -- Log queries taking more than 2 seconds
```

### Index Management

```sql
-- Show indexes for a table
SHOW INDEX FROM table_name;

-- Create index
CREATE INDEX index_name ON table_name (column_name);

-- Create composite index
CREATE INDEX index_name ON table_name (column1, column2);

-- Create unique index
CREATE UNIQUE INDEX index_name ON table_name (column_name);

-- Create fulltext index
CREATE FULLTEXT INDEX index_name ON table_name (column_name);

-- Drop index
DROP INDEX index_name ON table_name;
ALTER TABLE table_name DROP INDEX index_name;
```

### Status and Variables

```sql
-- Check system variables
SHOW VARIABLES;
SHOW VARIABLES LIKE 'max_connections';

-- Check status variables
SHOW STATUS;
SHOW STATUS LIKE 'Threads_connected';

-- Check engine status
SHOW ENGINE INNODB STATUS\G

-- Get information about processes
SHOW PROCESSLIST;

-- Kill a process
KILL process_id;

-- Check table status
SHOW TABLE STATUS;
SHOW TABLE STATUS LIKE 'table_name'\G
```

<div style="page-break-after: always;"></div>

## MySQL Client Programs
_Overview of MySQL command-line client programs._

### mysql Client

```bash
# Basic connection
mysql -u username -p

# Execute SQL from command line
mysql -u username -p -e "SELECT * FROM database.table LIMIT 5"

# Batch mode (non-interactive)
mysql -u username -p --batch < script.sql

# Vertical output format
mysql -u username -p -e "SELECT * FROM users WHERE id=1\G"

# Execute commands from file
mysql -u username -p database < script.sql

# Set maximum allowed packet size
mysql --max_allowed_packet=32M -u username -p
```

### mysqldump

```bash
# Basic backup
mysqldump -u username -p database_name > backup.sql

# Options summary
# --all-databases           Dump all databases
# --databases db1 db2       Dump specific databases
# --tables table1 table2    Dump specific tables
# --no-data                 Dump only structure
# --no-create-info          Dump only data
# --triggers                Include triggers
# --routines                Include stored procedures and functions
# --events                  Include events
# --single-transaction      Consistent backup without locking tables
# --skip-extended-insert    One INSERT statement per row (easier to edit)
# --add-drop-table          Add DROP TABLE statements before CREATE statements
# --add-drop-database       Add DROP DATABASE statements
# --where="condition"       Export only rows that match a condition
```

### mysqlimport

```bash
# Basic import
mysqlimport -u username -p database_name datafile.txt

# Options summary
# --local                   Read input files locally from the client host
# --replace                 Replace existing rows
# --ignore                  Ignore rows that duplicate existing rows
# --fields-terminated-by    Field separator character
# --fields-enclosed-by      Character used to enclose field values
# --fields-escaped-by       Character for escaping special characters
# --lines-terminated-by     Line separator character
# --ignore-lines            Number of initial lines to skip
```

### Other MySQL Utilities

#### mysqlcheck

```bash
# Check tables in a database
mysqlcheck -u username -p database_name

# Repair tables
mysqlcheck -u username -p --repair database_name

# Analyze tables
mysqlcheck -u username -p --analyze database_name

# Optimize tables
mysqlcheck -u username -p --optimize database_name

# Check all databases
mysqlcheck -u username -p --all-databases
```

#### mysqlshow

```bash
# Show databases
mysqlshow -u username -p

# Show tables in a database
mysqlshow -u username -p database_name

# Show columns in a table
mysqlshow -u username -p database_name table_name

# Show table status
mysqlshow -u username -p --status database_name
```

#### mysqlbinlog

```bash
# Display binary log file
mysqlbinlog binlog.000001

# Display specific range of events
mysqlbinlog --start-datetime="2023-01-01 00:00:00" --stop-datetime="2023-01-02 00:00:00" binlog.000001

# Convert binary log to SQL statements
mysqlbinlog binlog.000001 > recovery.sql
```

<div style="page-break-after: always;"></div>

## MySQL Configuration
_Commands for viewing and managing MySQL configuration._

### Server Configuration

```sql
-- Show variables
SHOW VARIABLES;
SHOW VARIABLES LIKE 'max_connections';
SHOW VARIABLES LIKE '%buffer%';

-- Set global variable (persists until server restart)
SET GLOBAL max_connections = 500;

-- Set session variable (affects current connection only)
SET SESSION sort_buffer_size = 10485760;
```

### Common Configuration Parameters

| Parameter | Description | Example Setting |
|-----------|-------------|----------------|
| max_connections | Maximum simultaneous client connections | 500 |
| innodb_buffer_pool_size | Memory allocated to InnoDB buffer pool | 4G |
| key_buffer_size | Buffer for MyISAM indexes | 256M |
| max_allowed_packet | Maximum packet/blob size | 64M |
| thread_cache_size | Cache for reusing threads | 32 |
| query_cache_size | Size of query cache | 32M |
| tmp_table_size | Maximum size for in-memory temporary tables | 64M |
| innodb_file_per_table | Store each InnoDB table in separate file | ON |
| character_set_server | Server default character set | utf8mb4 |
| collation_server | Server default collation | utf8mb4_unicode_ci |

### Configuration File Locations

```
# Linux/Unix
/etc/my.cnf
/etc/mysql/my.cnf
/usr/etc/my.cnf
~/.my.cnf

# Windows
C:\ProgramData\MySQL\MySQL Server X.Y\my.ini
C:\Windows\my.ini
```

### Sample Configuration File

```ini
[mysqld]
# Network
port = 3306
bind-address = 127.0.0.1

# Basic settings
user = mysql
pid-file = /var/run/mysqld/mysqld.pid
socket = /var/run/mysqld/mysqld.sock
basedir = /usr
datadir = /var/lib/mysql
tmpdir = /tmp

# Character set
character-set-server = utf8mb4
collation-server = utf8mb4_unicode_ci

# InnoDB settings
innodb_buffer_pool_size = 2G
innodb_log_file_size = 512M
innodb_file_per_table = 1
innodb_flush_log_at_trx_commit = 1

# MyISAM settings
key_buffer_size = 128M

# Connection settings
max_connections = 300
max_allowed_packet = 64M

# Query cache
query_cache_type = 1
query_cache_size = 32M

# Logs
log_error = /var/log/mysql/error.log
slow_query_log = 1
slow_query_log_file = /var/log/mysql/slow.log
long_query_time = 2

[mysql]
default-character-set = utf8mb4

[client]
default-character-set = utf8mb4
```

<div style="page-break-after: always;"></div>

## Backup and Recovery
_Commands for backing up and restoring MySQL databases._

### Backup Strategies

#### Logical Backups

```bash
# Full database backup
mysqldump -u username -p --all-databases > full_backup.sql

# Backup specific databases
mysqldump -u username -p --databases db1 db2 > selected_dbs.sql

# Backup with options for consistent backup
mysqldump -u username -p --single-transaction --quick \
  --lock-tables=false database_name > backup.sql

# Backup with compression
mysqldump -u username -p database_name | gzip > backup.sql.gz

# Scheduled backups with timestamp
mysqldump -u username -p database_name | gzip > backup_$(date +%Y%m%d_%H%M%S).sql.gz
```

#### Physical Backups

```bash
# Stop MySQL server
sudo systemctl stop mysql

# Copy data directory
sudo cp -R /var/lib/mysql /backup/mysql_data

# Start MySQL server
sudo systemctl start mysql

# Using Percona XtraBackup
xtrabackup --backup --target-dir=/backup/mysql
xtrabackup --prepare --target-dir=/backup/mysql
```

### Recovery Strategies

#### Restoring Logical Backups

```bash
# Restore a full backup
mysql -u username -p < full_backup.sql

# Restore specific database
mysql -u username -p database_name < backup.sql

# Restore compressed backup
gunzip < backup.sql.gz | mysql -u username -p database_name

# Restore with progress info
pv backup.sql | mysql -u username -p database_name
```

#### Restoring Physical Backups

```bash
# Stop MySQL server
sudo systemctl stop mysql

# Move data directory
sudo mv /var/lib/mysql /var/lib/mysql.bak

# Copy backup to data directory
sudo cp -R /backup/mysql /var/lib/mysql

# Set proper ownership
sudo chown -R mysql:mysql /var/lib/mysql

# Start MySQL server
sudo systemctl start mysql

# Using Percona XtraBackup
xtrabackup --copy-back --target-dir=/backup/mysql
```

### Point-in-Time Recovery

```bash
# Enable binary logging in my.cnf
# [mysqld]
# log-bin = /var/log/mysql/mysql-bin.log
# binlog_format = ROW
# server-id = 1

# Restore base backup
mysql -u username -p < full_backup.sql

# Apply binary logs up to specific time
mysqlbinlog --stop-datetime="2023-07-15 14:30:00" \
  /var/log/mysql/mysql-bin.000001 | mysql -u username -p
```

<div style="page-break-after: always;"></div>

## Troubleshooting
_Commands and techniques for identifying and resolving MySQL issues._

### Checking Server Status

```bash
# Check if MySQL is running
sudo systemctl status mysql

# Check MySQL error log
sudo tail -f /var/log/mysql/error.log

# Check system resource usage
top
vmstat 1
iostat -x 1
```

### Common MySQL Issues and Solutions

#### Connection Problems

```sql
-- Check max connections
SHOW VARIABLES LIKE 'max_connections';

-- Check current connections
SHOW STATUS LIKE 'Threads_connected';
SHOW PROCESSLIST;

-- Check connection errors
SHOW GLOBAL STATUS LIKE '%connection%';

-- Check access privileges
SELECT user, host FROM mysql.user;
```

#### Performance Issues

```sql
-- Identify slow queries
SHOW VARIABLES LIKE 'slow_query%';
SHOW VARIABLES LIKE 'long_query_time';

-- Enable slow query log
SET GLOBAL slow_query_log = 'ON';
SET GLOBAL long_query_time = 2;

-- Check query cache
SHOW STATUS LIKE 'Qcache%';

-- Check buffer sizes
SHOW VARIABLES LIKE '%buffer%';

-- Check table storage engines
SELECT table_name, engine FROM information_schema.tables
WHERE table_schema = 'database_name';

-- Optimize tables
OPTIMIZE TABLE table_name;
```

#### Storage Issues

```sql
-- Check database sizes
SELECT table_schema "Database Name", 
       ROUND(SUM(data_length + index_length) / (1024 * 1024), 2) "Size (MB)"
FROM information_schema.tables
GROUP BY table_schema;

-- Check table sizes
SELECT table_name, 
       ROUND((data_length + index_length) / (1024 * 1024), 2) "Size (MB)"
FROM information_schema.tables
WHERE table_schema = 'database_name'
ORDER BY (data_length + index_length) DESC;

-- Check disk space
df -h

-- Find large tables
SELECT table_name, table_rows, data_length, index_length,
       round(((data_length + index_length) / 1024 / 1024),2) "Size in MB"
FROM information_schema.tables
WHERE table_schema = 'database_name'
ORDER BY (data_length + index_length) DESC
LIMIT 10;
```

#### Lock Issues

```sql
-- Check for locks
SHOW OPEN TABLES WHERE in_use > 0;

-- Show innodb status
SHOW ENGINE INNODB STATUS\G

-- Show processlist to identify blocking queries
SHOW FULL PROCESSLIST;

-- Kill a blocking process
KILL process_id;
```

<div style="page-break-after: always;"></div>

## MySQL Workflow Examples
_Practical examples of common MySQL workflows._

### Database Setup for a Web Application

```sql
-- Create database
CREATE DATABASE webapp CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE webapp;

-- Create users table
CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    email VARCHAR(100) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    active TINYINT(1) DEFAULT 1,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    UNIQUE INDEX idx_email (email),
    INDEX idx_name (last_name, first_name)
);

-- Create products table
CREATE TABLE products (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description TEXT,
    price DECIMAL(10, 2) NOT NULL,
    stock INT NOT NULL DEFAULT 0,
    category_id INT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_category (category_id),
    INDEX idx_price (price)
);

-- Create categories table
CREATE TABLE categories (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL UNIQUE,
    parent_id INT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    INDEX idx_parent (parent_id)
);

-- Create orders table
CREATE TABLE orders (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    status ENUM('pending', 'processing', 'shipped', 'delivered', 'cancelled') NOT NULL DEFAULT 'pending',
    total_amount DECIMAL(10, 2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_user (user_id),
    INDEX idx_status (status),
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE
);

-- Create order items table
CREATE TABLE order_items (
    id INT AUTO_INCREMENT PRIMARY KEY,
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    INDEX idx_order (order_id),
    INDEX idx_product (product_id),
    FOREIGN KEY (order_id) REFERENCES orders(id) ON DELETE CASCADE,
    FOREIGN KEY (product_id) REFERENCES products(id)
);

-- Add foreign key to products table
ALTER TABLE products
ADD CONSTRAINT fk_category
FOREIGN KEY (category_id) REFERENCES categories(id) ON DELETE SET NULL;

-- Create application user
CREATE USER 'webapp_user'@'localhost' IDENTIFIED BY 'password';
GRANT SELECT, INSERT, UPDATE, DELETE ON webapp.* TO 'webapp_user'@'localhost';
FLUSH PRIVILEGES;
```

### Data Analysis Example

```sql
-- Find top spending customers
SELECT 
    u.id, 
    CONCAT(u.first_name, ' ', u.last_name) AS customer_name,
    COUNT(o.id) AS order_count,
    SUM(o.total_amount) AS total_spent
FROM 
    users u
JOIN 
    orders o ON u.id = o.user_id
WHERE 
    o.status = 'delivered'
GROUP BY 
    u.id
ORDER BY 
    total_spent DESC
LIMIT 10;

-- Find best selling products
SELECT 
    p.id,
    p.name,
    SUM(oi.quantity) AS units_sold,
    SUM(oi.quantity * oi.price) AS revenue
FROM 
    products p
JOIN 
    order_items oi ON p.id = oi.product_id
JOIN 
    orders o ON oi.order_id = o.id
WHERE 
    o.status IN ('shipped', 'delivered')
    AND o.created_at BETWEEN '2023-01-01' AND '2023-12-31'
GROUP BY 
    p.id
ORDER BY 
    units_sold DESC
LIMIT 20;

-- Find category performance
SELECT 
    c.name AS category,
    COUNT(DISTINCT p.id) AS product_count,
    SUM(oi.quantity) AS units_sold,
    SUM(oi.quantity * oi.price) AS revenue,
    AVG(p.price) AS avg_price
FROM 
    categories c
LEFT JOIN 
    products p ON c.id = p.category_id
LEFT JOIN 
    order_items oi ON p.id = oi.product_id
LEFT JOIN 
    orders o ON oi.order_id = o.id AND o.status IN ('shipped', 'delivered')
GROUP BY 
    c.id
ORDER BY 
    revenue DESC;

-- Monthly sales report
SELECT 
    DATE_FORMAT(o.created_at, '%Y-%m') AS month,
    COUNT(DISTINCT o.id) AS order_count,
    COUNT(DISTINCT o.user_id) AS customer_count,
    SUM(o.total_amount) AS total_revenue,
    AVG(o.total_amount) AS avg_order_value
FROM 
    orders o
WHERE 
    o.status IN ('shipped', 'delivered')
    AND o.created_at >= DATE_SUB(CURRENT_DATE(), INTERVAL 12 MONTH)
GROUP BY 
    month
ORDER BY 
    month;
```

<div style="page-break-after: always;"></div>

## Best Practices
_Recommendations for effective MySQL database usage._

### Security Best Practices

1. **Use Strong Passwords**
   ```sql
   -- Use strong passwords with strict policy
   CREATE USER 'username'@'host' IDENTIFIED BY 'StrongP@ssw0rd!';
   ```

2. **Implement Least Privilege Principle**
   ```sql
   -- Grant only required privileges
   GRANT SELECT, INSERT ON database.table TO 'app_user'@'localhost';
   ```

3. **Use Connection Encryption**
   ```sql
   -- Force SSL connections
   CREATE USER 'username'@'%' IDENTIFIED BY 'password' REQUIRE SSL;
   -- Or update existing user
   ALTER USER 'username'@'%' REQUIRE SSL;
   ```

4. **Regularly Rotate Credentials**
   ```sql
   -- Change passwords regularly
   ALTER USER 'username'@'host' IDENTIFIED BY 'New$trongP@ssw0rd!';
   ```

5. **Remove Anonymous Users and Test Databases**
   ```sql
   -- Remove default anonymous users
   DROP USER ''@'localhost';
   DROP USER ''@'host_name';
   
   -- Remove test database
   DROP DATABASE test;
   ```

6. **Audit User Privileges Regularly**
   ```sql
   -- Review user privileges
   SELECT user, host FROM mysql.user;
   SHOW GRANTS FOR 'username'@'host';
   ```

### Performance Best Practices

1. **Use Appropriate Indexes**
   ```sql
   -- Create indexes for frequently queried columns
   CREATE INDEX idx_last_name ON users(last_name);
   
   -- Use composite indexes for multiple column conditions
   CREATE INDEX idx_name_email ON users(last_name, first_name, email);
   ```

2. **Optimize Queries**
   ```sql
   -- Use EXPLAIN to analyze query execution
   EXPLAIN SELECT * FROM users WHERE last_name = 'Smith';
   
   -- Use specific columns instead of SELECT *
   SELECT id, username, email FROM users WHERE active = 1;
   ```

3. **Use Connection Pooling**
   - Implement connection pooling in application code
   - Avoid creating new connections for each request

4. **Regular Maintenance**
   ```sql
   -- Analyze tables to update statistics
   ANALYZE TABLE table_name;
   
   -- Optimize tables to reclaim space
   OPTIMIZE TABLE table_name;
   ```

5. **Configure Server Settings Appropriately**
   - Adjust buffer sizes based on available memory
   - Configure query cache appropriately
   - Set appropriate timeout values

### Database Design Best Practices

1. **Normalize Data Properly**
   - Follow normalization rules to reduce redundancy
   - Consider denormalization only for specific performance needs

2. **Use Appropriate Data Types**
   ```sql
   -- Use efficient data types
   -- Use VARCHAR instead of CHAR for variable length strings
   -- Use INT for IDs instead of VARCHAR when appropriate
   -- Use TIMESTAMP instead of DATETIME if timezone awareness needed
   ```

3. **Implement Foreign Keys**
   ```sql
   -- Maintain referential integrity with foreign keys
   ALTER TABLE orders ADD CONSTRAINT fk_user
   FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE;
   ```

4. **Use Consistent Naming Conventions**
   - Use consistent naming for tables, columns, indexes
   - Follow a pattern like snake_case or camelCase consistently

5. **Document Your Schema**
   ```sql
   -- Add comments to tables and columns
   ALTER TABLE users COMMENT 'Stores user account information';
   ALTER TABLE users MODIFY COLUMN status VARCHAR(10) COMMENT 'User account status';
   ```

### Backup Best Practices

1. **Regular Backups**
   - Schedule automated backups
   - Use a combination of full and incremental backups

2. **Test Restores**
   - Regularly test backup restoration
   - Verify data integrity after restoration

3. **Multiple Backup Locations**
   - Store backups in multiple physical locations
   - Use both on-site and off-site storage

4. **Monitor Backup Process**
   - Set up alerts for backup failures
   - Monitor backup size and timing trends

5. **Document Backup and Recovery Procedures**
   - Create clear documentation for backup processes
   - Document step-by-step recovery procedures