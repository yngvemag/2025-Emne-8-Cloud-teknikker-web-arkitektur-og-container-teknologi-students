# AWS CLI Command Cheat Sheet

This document provides a comprehensive overview of essential AWS Command Line Interface (CLI) commands, with descriptions and examples for each.

## Table of Contents

- [Installation and Setup](#installation-and-setup)
- [Configuration](#configuration)
- [Basic AWS CLI Concepts](#basic-aws-cli-concepts)
- [IAM (Identity and Access Management)](#iam-identity-and-access-management)
- [S3 (Simple Storage Service)](#s3-simple-storage-service)
- [EC2 (Elastic Compute Cloud)](#ec2-elastic-compute-cloud)
- [Lambda Functions](#lambda-functions)
- [CloudFormation](#cloudformation)
- [CloudWatch](#cloudwatch)
- [RDS (Relational Database Service)](#rds-relational-database-service)
- [DynamoDB](#dynamodb)
- [ECS (Elastic Container Service)](#ecs-elastic-container-service)
- [EKS (Elastic Kubernetes Service)](#eks-elastic-kubernetes-service)
- [API Gateway](#api-gateway)
- [SNS and SQS](#sns-and-sqs)
- [Secrets Manager](#secrets-manager)
- [Data Pipeline Commands](#data-pipeline-commands)
- [Common Options and Parameters](#common-options-and-parameters)
- [Troubleshooting](#troubleshooting)
- [Best Practices](#best-practices)

## Installation and Setup
_Install and configure AWS CLI on various operating systems._

### Installing AWS CLI

```powershell
# Install AWS CLI on Windows using MSI installer
# Download from: https://awscli.amazonaws.com/AWSCLIV2.msi
# Then run the installer

# Verify AWS CLI installation
aws --version

# Install AWS CLI using pip (alternative method)
pip install awscli

# Install AWS CLI on Linux (Amazon Linux, RHEL, CentOS)
# curl "https://awscli.amazonaws.com/awscli-exe-linux-x86_64.zip" -o "awscliv2.zip"
# unzip awscliv2.zip
# sudo ./aws/install

# Install AWS CLI on macOS
# curl "https://awscli.amazonaws.com/AWSCLIV2.pkg" -o "AWSCLIV2.pkg"
# sudo installer -pkg AWSCLIV2.pkg -target /
```
<div style="page-break-after:always;"></div>

## Configuration
_Configure AWS CLI with credentials and default settings._

### Initial Setup

```powershell
# Configure AWS CLI with your credentials (interactive)
aws configure

# Configure a named profile
aws configure --profile dev-account

# Set AWS credentials manually
$env:AWS_ACCESS_KEY_ID="your-access-key"
$env:AWS_SECRET_ACCESS_KEY="your-secret-key"
$env:AWS_DEFAULT_REGION="us-east-1"

# View current configuration
aws configure list

# View all configured profiles
aws configure list-profiles

# Check existing configuration
cat ~\.aws\config
cat ~\.aws\credentials

# Configure AWS CLI with MFA
aws configure set aws_session_token "your-session-token" --profile mfa-profile
```

### Multiple Profiles

```powershell
# Create/edit AWS config file
notepad ~\.aws\config

# Example config file content:
# [default]
# region = us-east-1
# output = json
#
# [profile dev]
# region = us-east-1
# output = json
#
# [profile prod]
# region = us-west-2
# output = json

# Use a specific profile for a command
aws s3 ls --profile dev

# List profiles with a specific default region
aws configure list | Select-String region
```
<div style="page-break-after:always;"></div>

## Basic AWS CLI Concepts
_Understand AWS CLI syntax, structure and general usage patterns._

### Command Structure

```powershell
# Basic AWS CLI command structure
# aws <service> <command> <subcommand> [options and parameters]

# Example: List S3 buckets
aws s3 ls

# Get help for a service
aws ec2 help

# Get help for a command
aws ec2 describe-instances help

# Get help for a subcommand
aws ec2 run-instances help

# Controlling output format
aws ec2 describe-instances --output json
aws ec2 describe-instances --output text
aws ec2 describe-instances --output table
aws ec2 describe-instances --output yaml

# Using query parameters to filter output
aws ec2 describe-instances --query 'Reservations[*].Instances[*].InstanceId'
aws ec2 describe-instances --query 'Reservations[*].Instances[*].[InstanceId,InstanceType]'
```

### Using AWS CLI efficiently

```powershell
# Use auto-prompt for interactive help
aws --cli-auto-prompt

# Generate CLI skeleton for complex commands
aws ec2 run-instances --generate-cli-skeleton > instance-params.json

# Use skeleton file for command input
aws ec2 run-instances --cli-input-json file://instance-params.json

# Use shorthand syntax
aws ec2 run-instances --image-id ami-12345 --count 1 --instance-type t2.micro

# Paginate results
aws s3api list-objects --bucket my-bucket --page-size 100 --max-items 500
aws s3api list-objects --bucket my-bucket --starting-token eyJNYX...
```
<div style="page-break-after:always;"></div>

## IAM (Identity and Access Management)
_Manage users, groups, roles, and permissions in AWS._

### Managing IAM Users

```powershell
# List all IAM users
aws iam list-users

# Create a new IAM user
aws iam create-user --user-name johndoe

# Delete an IAM user
aws iam delete-user --user-name johndoe

# Create access key for user
aws iam create-access-key --user-name johndoe

# List access keys for user
aws iam list-access-keys --user-name johndoe

# Delete access key
aws iam delete-access-key --user-name johndoe --access-key-id AKIAIOSFODNN7EXAMPLE

# Update user
aws iam update-user --user-name johndoe --new-user-name johndoe2

# Create login profile (console access)
aws iam create-login-profile --user-name johndoe --password "P@ssw0rd!" --password-reset-required

# Get user information
aws iam get-user --user-name johndoe
```

### Managing IAM Groups

```powershell
# Create a group
aws iam create-group --group-name Developers

# List groups
aws iam list-groups

# Add user to group
aws iam add-user-to-group --user-name johndoe --group-name Developers

# List users in group
aws iam get-group --group-name Developers

# Remove user from group
aws iam remove-user-from-group --user-name johndoe --group-name Developers

# Delete group
aws iam delete-group --group-name Developers

# List groups for user
aws iam list-groups-for-user --user-name johndoe
```
<div style="page-break-after:always;"></div>

### Managing IAM Policies

```powershell
# List all policies
aws iam list-policies

# Create policy
aws iam create-policy --policy-name S3ReadOnlyAccess --policy-document file://s3-read-policy.json

# Attach policy to user
aws iam attach-user-policy --user-name johndoe --policy-arn arn:aws:iam::aws:policy/AmazonS3ReadOnlyAccess

# Attach policy to group
aws iam attach-group-policy --group-name Developers --policy-arn arn:aws:iam::aws:policy/AmazonS3ReadOnlyAccess

# Detach policy from user
aws iam detach-user-policy --user-name johndoe --policy-arn arn:aws:iam::aws:policy/AmazonS3ReadOnlyAccess

# List user policies
aws iam list-attached-user-policies --user-name johndoe

# List group policies
aws iam list-attached-group-policies --group-name Developers

# Get policy
aws iam get-policy --policy-arn arn:aws:iam::aws:policy/AmazonS3ReadOnlyAccess

# Get policy document (policy version)
aws iam get-policy-version --policy-arn arn:aws:iam::aws:policy/AmazonS3ReadOnlyAccess --version-id v1
```

### Managing IAM Roles

```powershell
# List roles
aws iam list-roles

# Create role
aws iam create-role --role-name EC2Role --assume-role-policy-document file://ec2-trust-policy.json

# Create instance profile (for EC2)
aws iam create-instance-profile --instance-profile-name EC2Profile

# Add role to instance profile
aws iam add-role-to-instance-profile --role-name EC2Role --instance-profile-name EC2Profile

# Attach policy to role
aws iam attach-role-policy --role-name EC2Role --policy-arn arn:aws:iam::aws:policy/AmazonS3ReadOnlyAccess

# Get role
aws iam get-role --role-name EC2Role

# List role policies
aws iam list-attached-role-policies --role-name EC2Role

# Delete role
aws iam delete-role --role-name EC2Role
```
<div style="page-break-after:always;"></div>

## S3 (Simple Storage Service)
_Manage AWS S3 buckets and objects for cloud storage._

### Bucket Operations

```powershell
# List all buckets
aws s3 ls

# Create bucket
aws s3 mb s3://my-bucket

# Delete empty bucket
aws s3 rb s3://my-bucket

# Delete bucket with contents
aws s3 rb s3://my-bucket --force

# List bucket contents
aws s3 ls s3://my-bucket

# List bucket contents recursively
aws s3 ls s3://my-bucket --recursive

# Get bucket location
aws s3api get-bucket-location --bucket my-bucket

# Get bucket policy
aws s3api get-bucket-policy --bucket my-bucket

# Set bucket policy
aws s3api put-bucket-policy --bucket my-bucket --policy file://bucket-policy.json

# Enable bucket versioning
aws s3api put-bucket-versioning --bucket my-bucket --versioning-configuration Status=Enabled

# Configure bucket website hosting
aws s3 website s3://my-bucket --index-document index.html --error-document error.html
```

### Object Operations

```powershell
# Upload file to bucket
aws s3 cp myfile.txt s3://my-bucket/

# Upload file with specific storage class
aws s3 cp myfile.txt s3://my-bucket/ --storage-class GLACIER

# Download file from bucket
aws s3 cp s3://my-bucket/myfile.txt myfile.txt

# Move/rename file
aws s3 mv s3://my-bucket/myfile.txt s3://my-bucket/myfolder/newname.txt

# Copy object between buckets
aws s3 cp s3://my-bucket/myfile.txt s3://my-other-bucket/

# Delete object
aws s3 rm s3://my-bucket/myfile.txt

# Delete folder and all contents
aws s3 rm s3://my-bucket/myfolder/ --recursive

# Sync local directory to bucket
aws s3 sync ./local-folder s3://my-bucket/remote-folder

# Sync bucket to local directory
aws s3 sync s3://my-bucket/remote-folder ./local-folder

# Get object metadata
aws s3api head-object --bucket my-bucket --key myfile.txt

# Set object ACL
aws s3api put-object-acl --bucket my-bucket --key myfile.txt --acl public-read
```
<div style="page-break-after:always;"></div>

### Advanced S3 Operations

```powershell
# Enable bucket logging
aws s3api put-bucket-logging --bucket my-bucket --bucket-logging-status file://logging.json

# Configure lifecycle policy
aws s3api put-bucket-lifecycle-configuration --bucket my-bucket --lifecycle-configuration file://lifecycle.json

# Configure CORS
aws s3api put-bucket-cors --bucket my-bucket --cors-configuration file://cors.json

# Generate presigned URL (temporary access)
aws s3 presign s3://my-bucket/myfile.txt --expires-in 3600

# Enable bucket encryption
aws s3api put-bucket-encryption --bucket my-bucket --server-side-encryption-configuration file://encryption.json

# List object versions
aws s3api list-object-versions --bucket my-bucket --prefix myfile.txt

# Restore object from Glacier
aws s3api restore-object --bucket my-bucket --key myfile.txt --restore-request '{"Days":30,"GlacierJobParameters":{"Tier":"Standard"}}'
```

## EC2 (Elastic Compute Cloud)
_Manage virtual machines in the AWS cloud._

### EC2 Instance Management

```powershell
# List all instances
aws ec2 describe-instances

# List running instances
aws ec2 describe-instances --filters "Name=instance-state-name,Values=running"

# Create a new instance
aws ec2 run-instances --image-id ami-12345abcde --count 1 --instance-type t2.micro --key-name MyKeyPair --security-group-ids sg-12345

# Start instance
aws ec2 start-instances --instance-ids i-1234567890abcdef0

# Stop instance
aws ec2 stop-instances --instance-ids i-1234567890abcdef0

# Reboot instance
aws ec2 reboot-instances --instance-ids i-1234567890abcdef0

# Terminate instance
aws ec2 terminate-instances --instance-ids i-1234567890abcdef0

# Get console output
aws ec2 get-console-output --instance-id i-1234567890abcdef0

# List instance types
aws ec2 describe-instance-types

# Get instance status
aws ec2 describe-instance-status --instance-id i-1234567890abcdef0
```
<div style="page-break-after:always;"></div>

### AMIs and Snapshots

```powershell
# List all AMIs owned by you
aws ec2 describe-images --owners self

# Create AMI from instance
aws ec2 create-image --instance-id i-1234567890abcdef0 --name "My-App-AMI" --description "AMI for my application server"

# Copy AMI to another region
aws ec2 copy-image --source-region us-east-1 --source-image-id ami-12345abcde --name "My-App-AMI-Copy" --region us-west-2

# Deregister AMI
aws ec2 deregister-image --image-id ami-12345abcde

# Create snapshot
aws ec2 create-snapshot --volume-id vol-1234567890abcdef0 --description "Backup for volume"

# List snapshots
aws ec2 describe-snapshots --owner-ids self

# Delete snapshot
aws ec2 delete-snapshot --snapshot-id snap-1234567890abcdef0
```

### Security Groups

```powershell
# List security groups
aws ec2 describe-security-groups

# Create security group
aws ec2 create-security-group --group-name MySecurityGroup --description "My security group" --vpc-id vpc-1a2b3c4d

# Add inbound rule (allow SSH)
aws ec2 authorize-security-group-ingress --group-id sg-12345 --protocol tcp --port 22 --cidr 0.0.0.0/0

# Add outbound rule
aws ec2 authorize-security-group-egress --group-id sg-12345 --protocol tcp --port 443 --cidr 0.0.0.0/0

# Remove rule
aws ec2 revoke-security-group-ingress --group-id sg-12345 --protocol tcp --port 22 --cidr 0.0.0.0/0

# Delete security group
aws ec2 delete-security-group --group-id sg-12345
```

### Key Pairs

```powershell
# List key pairs
aws ec2 describe-key-pairs

# Create key pair
aws ec2 create-key-pair --key-name MyKeyPair --query 'KeyMaterial' --output text > MyKeyPair.pem

# Import key pair
aws ec2 import-key-pair --key-name ImportedKeyPair --public-key-material fileb://public-key.txt

# Delete key pair
aws ec2 delete-key-pair --key-name MyKeyPair
```
<div style="page-break-after:always;"></div>

### VPC Management

```powershell
# List VPCs
aws ec2 describe-vpcs

# Create VPC
aws ec2 create-vpc --cidr-block 10.0.0.0/16 --tag-specifications 'ResourceType=vpc,Tags=[{Key=Name,Value=MyVPC}]'

# List subnets
aws ec2 describe-subnets

# Create subnet
aws ec2 create-subnet --vpc-id vpc-1a2b3c4d --cidr-block 10.0.1.0/24 --availability-zone us-east-1a

# Create Internet Gateway
aws ec2 create-internet-gateway

# Attach Internet Gateway to VPC
aws ec2 attach-internet-gateway --internet-gateway-id igw-1a2b3c4d --vpc-id vpc-1a2b3c4d

# Create route table
aws ec2 create-route-table --vpc-id vpc-1a2b3c4d

# Create route
aws ec2 create-route --route-table-id rtb-1a2b3c4d --destination-cidr-block 0.0.0.0/0 --gateway-id igw-1a2b3c4d

# Associate subnet with route table
aws ec2 associate-route-table --route-table-id rtb-1a2b3c4d --subnet-id subnet-1a2b3c4d

# Delete VPC (must delete all dependencies first)
aws ec2 delete-vpc --vpc-id vpc-1a2b3c4d
```

## Lambda Functions
_Manage serverless functions in AWS._

### Basic Lambda Operations

```powershell
# List all Lambda functions
aws lambda list-functions

# Create function
aws lambda create-function --function-name my-function --runtime python3.9 --role arn:aws:iam::123456789012:role/lambda-role --handler lambda_function.lambda_handler --zip-file fileb://function.zip

# Update function code
aws lambda update-function-code --function-name my-function --zip-file fileb://function.zip

# Update function configuration
aws lambda update-function-configuration --function-name my-function --timeout 30 --memory-size 256

# Delete function
aws lambda delete-function --function-name my-function

# Invoke function
aws lambda invoke --function-name my-function --payload '{"key":"value"}' output.txt

# Get function configuration
aws lambda get-function-configuration --function-name my-function
```
<div style="page-break-after:always;"></div>

### Lambda Permissions and Triggers

```powershell
# Add permission (allow S3 to invoke function)
aws lambda add-permission --function-name my-function --statement-id s3-trigger --action lambda:InvokeFunction --principal s3.amazonaws.com --source-arn arn:aws:s3:::my-bucket

# Create event source mapping (for DynamoDB Streams)
aws lambda create-event-source-mapping --function-name my-function --event-source-arn arn:aws:dynamodb:us-east-1:123456789012:table/my-table/stream/2020-01-01T00:00:00.000 --batch-size 100

# List event source mappings
aws lambda list-event-source-mappings --function-name my-function

# Delete event source mapping
aws lambda delete-event-source-mapping --uuid a1b2c3d4-5678-90ab-cdef-EXAMPLE11111

# Create function URL configuration
aws lambda create-function-url-config --function-name my-function --auth-type NONE

# Get function URL configuration
aws lambda get-function-url-config --function-name my-function
```

### Lambda Layers and Versions

```powershell
# Publish layer version
aws lambda publish-layer-version --layer-name my-layer --description "My dependencies" --zip-file fileb://layer.zip --compatible-runtimes python3.9

# Add layer to function
aws lambda update-function-configuration --function-name my-function --layers arn:aws:lambda:us-east-1:123456789012:layer:my-layer:1

# List layers
aws lambda list-layers

# Publish function version
aws lambda publish-version --function-name my-function --description "Production version"

# Create alias
aws lambda create-alias --function-name my-function --name prod --function-version 1

# Update alias
aws lambda update-alias --function-name my-function --name prod --function-version 2

# Delete alias
aws lambda delete-alias --function-name my-function --name prod
```
<div style="page-break-after:always;"></div>

## CloudFormation
_Manage infrastructure as code with AWS CloudFormation._

### Stack Operations

```powershell
# List stacks
aws cloudformation list-stacks

# Create stack
aws cloudformation create-stack --stack-name my-stack --template-body file://template.yaml --parameters ParameterKey=InstanceType,ParameterValue=t2.micro

# Update stack
aws cloudformation update-stack --stack-name my-stack --template-body file://updated-template.yaml

# Delete stack
aws cloudformation delete-stack --stack-name my-stack

# Describe stack
aws cloudformation describe-stacks --stack-name my-stack

# List stack resources
aws cloudformation list-stack-resources --stack-name my-stack

# Get template
aws cloudformation get-template --stack-name my-stack

# Validate template
aws cloudformation validate-template --template-body file://template.yaml
```

### Change Sets

```powershell
# Create change set
aws cloudformation create-change-set --stack-name my-stack --template-body file://template.yaml --change-set-name my-changes

# Describe change set
aws cloudformation describe-change-set --change-set-name my-changes --stack-name my-stack

# Execute change set
aws cloudformation execute-change-set --change-set-name my-changes --stack-name my-stack

# Delete change set
aws cloudformation delete-change-set --change-set-name my-changes --stack-name my-stack
```

### Stack Sets

```powershell
# Create stack set
aws cloudformation create-stack-set --stack-set-name my-stack-set --template-body file://template.yaml

# Create stack instances
aws cloudformation create-stack-instances --stack-set-name my-stack-set --accounts 123456789012 --regions us-east-1 us-west-2

# Update stack set
aws cloudformation update-stack-set --stack-set-name my-stack-set --template-body file://template.yaml

# Delete stack instances
aws cloudformation delete-stack-instances --stack-set-name my-stack-set --accounts 123456789012 --regions us-east-1 --no-retain-stacks

# Delete stack set
aws cloudformation delete-stack-set --stack-set-name my-stack-set
```
<div style="page-break-after:always;"></div>

## CloudWatch
_Monitor AWS resources and applications._

### CloudWatch Metrics

```powershell
# List metrics
aws cloudwatch list-metrics

# Get metrics for specific namespace
aws cloudwatch list-metrics --namespace AWS/EC2

# Get metrics for specific dimension
aws cloudwatch list-metrics --namespace AWS/EC2 --dimensions Name=InstanceId,Value=i-1234567890abcdef0

# Get metric statistics
aws cloudwatch get-metric-statistics --namespace AWS/EC2 --metric-name CPUUtilization --dimensions Name=InstanceId,Value=i-1234567890abcdef0 --start-time 2023-01-01T00:00:00Z --end-time 2023-01-02T00:00:00Z --period 3600 --statistics Average

# Put custom metric data
aws cloudwatch put-metric-data --namespace MyApplication --metric-name PageViewCount --value 24 --timestamp 2023-01-01T00:00:00Z
```

### CloudWatch Alarms

```powershell
# Create alarm
aws cloudwatch put-metric-alarm --alarm-name cpu-alarm --alarm-description "Alarm when CPU exceeds 70%" --metric-name CPUUtilization --namespace AWS/EC2 --statistic Average --period 300 --threshold 70 --comparison-operator GreaterThanThreshold --dimensions Name=InstanceId,Value=i-1234567890abcdef0 --evaluation-periods 2 --alarm-actions arn:aws:sns:us-east-1:123456789012:my-topic

# List alarms
aws cloudwatch describe-alarms

# Get specific alarm
aws cloudwatch describe-alarms --alarm-names cpu-alarm

# Enable alarm actions
aws cloudwatch enable-alarm-actions --alarm-names cpu-alarm

# Disable alarm actions
aws cloudwatch disable-alarm-actions --alarm-names cpu-alarm

# Delete alarm
aws cloudwatch delete-alarms --alarm-names cpu-alarm
```

### CloudWatch Logs

```powershell
# Create log group
aws logs create-log-group --log-group-name /my-application

# Create log stream
aws logs create-log-stream --log-group-name /my-application --log-stream-name instance1

# Put log events
aws logs put-log-events --log-group-name /my-application --log-stream-name instance1 --log-events timestamp=1577836800000,message="Application started" timestamp=1577836801000,message="Processing request"

# Get log events
aws logs get-log-events --log-group-name /my-application --log-stream-name instance1

# Filter log events
aws logs filter-log-events --log-group-name /my-application --filter-pattern "ERROR"

# Delete log stream
aws logs delete-log-stream --log-group-name /my-application --log-stream-name instance1

# Delete log group
aws logs delete-log-group --log-group-name /my-application
```
<div style="page-break-after:always;"></div>

## RDS (Relational Database Service)
_Manage relational databases in AWS._

### Database Instance Operations

```powershell
# List DB instances
aws rds describe-db-instances

# Create DB instance
aws rds create-db-instance --db-instance-identifier mydb --db-instance-class db.t3.micro --engine mysql --master-username admin --master-user-password password123 --allocated-storage 20

# Modify DB instance
aws rds modify-db-instance --db-instance-identifier mydb --backup-retention-period 7 --apply-immediately

# Reboot DB instance
aws rds reboot-db-instance --db-instance-identifier mydb

# Stop DB instance
aws rds stop-db-instance --db-instance-identifier mydb

# Start DB instance
aws rds start-db-instance --db-instance-identifier mydb

# Delete DB instance
aws rds delete-db-instance --db-instance-identifier mydb --skip-final-snapshot

# Delete DB instance with final snapshot
aws rds delete-db-instance --db-instance-identifier mydb --final-db-snapshot-identifier mydb-final-snap
```

### DB Snapshots

```powershell
# Create DB snapshot
aws rds create-db-snapshot --db-snapshot-identifier mydb-snap --db-instance-identifier mydb

# List DB snapshots
aws rds describe-db-snapshots

# Copy DB snapshot
aws rds copy-db-snapshot --source-db-snapshot-identifier mydb-snap --target-db-snapshot-identifier mydb-snap-copy

# Restore from DB snapshot
aws rds restore-db-instance-from-db-snapshot --db-instance-identifier mydb-restored --db-snapshot-identifier mydb-snap

# Delete DB snapshot
aws rds delete-db-snapshot --db-snapshot-identifier mydb-snap
```

### Parameter Groups

```powershell
# List parameter groups
aws rds describe-db-parameter-groups

# Create parameter group
aws rds create-db-parameter-group --db-parameter-group-name myparamgroup --db-parameter-group-family mysql8.0 --description "My MySQL parameter group"

# Modify parameter group
aws rds modify-db-parameter-group --db-parameter-group-name myparamgroup --parameters "ParameterName=max_connections,ParameterValue=200,ApplyMethod=immediate"

# List parameters in group
aws rds describe-db-parameters --db-parameter-group-name myparamgroup

# Associate parameter group with instance
aws rds modify-db-instance --db-instance-identifier mydb --db-parameter-group-name myparamgroup --apply-immediately

# Delete parameter group
aws rds delete-db-parameter-group --db-parameter-group-name myparamgroup
```
<div style="page-break-after:always;"></div>

## DynamoDB
_Manage NoSQL database tables in AWS._

### Table Operations

```powershell
# List tables
aws dynamodb list-tables

# Create table
aws dynamodb create-table --table-name Music --attribute-definitions AttributeName=Artist,AttributeType=S AttributeName=SongTitle,AttributeType=S --key-schema AttributeName=Artist,KeyType=HASH AttributeName=SongTitle,KeyType=RANGE --provisioned-throughput ReadCapacityUnits=5,WriteCapacityUnits=5

# Describe table
aws dynamodb describe-table --table-name Music

# Update table (modify throughput)
aws dynamodb update-table --table-name Music --provisioned-throughput ReadCapacityUnits=10,WriteCapacityUnits=10

# Enable auto scaling
aws application-autoscaling register-scalable-target --service-namespace dynamodb --resource-id table/Music --scalable-dimension dynamodb:table:ReadCapacityUnits --min-capacity 5 --max-capacity 100

# Delete table
aws dynamodb delete-table --table-name Music
```

### Item Operations

```powershell
# Put item
aws dynamodb put-item --table-name Music --item '{"Artist": {"S": "No One You Know"}, "SongTitle": {"S": "Call Me Today"}, "AlbumTitle": {"S": "Somewhat Famous"}, "Year": {"N": "2015"}}'

# Get item
aws dynamodb get-item --table-name Music --key '{"Artist": {"S": "No One You Know"}, "SongTitle": {"S": "Call Me Today"}}'

# Update item
aws dynamodb update-item --table-name Music --key '{"Artist": {"S": "No One You Know"}, "SongTitle": {"S": "Call Me Today"}}' --update-expression "SET Year = :y" --expression-attribute-values '{":y": {"N": "2016"}}'

# Delete item
aws dynamodb delete-item --table-name Music --key '{"Artist": {"S": "No One You Know"}, "SongTitle": {"S": "Call Me Today"}}'

# Query items
aws dynamodb query --table-name Music --key-condition-expression "Artist = :a" --expression-attribute-values '{":a": {"S": "No One You Know"}}'

# Scan table
aws dynamodb scan --table-name Music --filter-expression "Year > :y" --expression-attribute-values '{":y": {"N": "2010"}}'
```

### Batch Operations

```powershell
# Batch write items (put & delete)
aws dynamodb batch-write-item --request-items file://batch-write.json

# Batch get items
aws dynamodb batch-get-item --request-items file://batch-get.json

# Example batch-write.json:
# {
#   "Music": [
#     {
#       "PutRequest": {
#         "Item": {
#           "Artist": {"S": "Artist1"},
#           "SongTitle": {"S": "Song1"}
#         }
#       }
#     },
#     {
#       "DeleteRequest": {
#         "Key": {
#           "Artist": {"S": "Artist2"},
#           "SongTitle": {"S": "Song2"}
#         }
#       }
#     }
#   ]
# }
```
<div style="page-break-after:always;"></div>

## ECS (Elastic Container Service)
_Manage Docker containers on AWS._

### Cluster Operations

```powershell
# List clusters
aws ecs list-clusters

# Create cluster
aws ecs create-cluster --cluster-name my-cluster

# Delete cluster
aws ecs delete-cluster --cluster my-cluster

# Describe cluster
aws ecs describe-clusters --clusters my-cluster
```

### Task Definitions

```powershell
# Register task definition
aws ecs register-task-definition --cli-input-json file://task-definition.json

# List task definitions
aws ecs list-task-definitions

# Describe task definition
aws ecs describe-task-definition --task-definition my-task:1

# Deregister task definition
aws ecs deregister-task-definition --task-definition my-task:1
```

### Service Operations

```powershell
# Create service
aws ecs create-service --cluster my-cluster --service-name my-service --task-definition my-task:1 --desired-count 2

# Update service
aws ecs update-service --cluster my-cluster --service my-service --desired-count 3

# List services
aws ecs list-services --cluster my-cluster

# Describe service
aws ecs describe-services --cluster my-cluster --services my-service

# Delete service
aws ecs delete-service --cluster my-cluster --service my-service --force
```

### Task Operations

```powershell
# Run task
aws ecs run-task --cluster my-cluster --task-definition my-task:1 --count 1

# List tasks
aws ecs list-tasks --cluster my-cluster

# Describe tasks
aws ecs describe-tasks --cluster my-cluster --tasks task-id

# Stop task
aws ecs stop-task --cluster my-cluster --task task-id
```
<div style="page-break-after:always;"></div>

## EKS (Elastic Kubernetes Service)
_Manage Kubernetes clusters on AWS._

### Cluster Operations

```powershell
# List clusters
aws eks list-clusters

# Create cluster
aws eks create-cluster --name my-cluster --role-arn arn:aws:iam::123456789012:role/eks-cluster-role --resources-vpc-config subnetIds=subnet-12345,subnet-67890,securityGroupIds=sg-12345

# Describe cluster
aws eks describe-cluster --name my-cluster

# Update cluster config
aws eks update-cluster-config --name my-cluster --logging '{"clusterLogging":[{"types":["api","audit"],"enabled":true}]}'

# Delete cluster
aws eks delete-cluster --name my-cluster
```

### Node Group Operations

```powershell
# Create node group
aws eks create-nodegroup --cluster-name my-cluster --nodegroup-name my-nodegroup --node-role arn:aws:iam::123456789012:role/eks-node-role --subnets subnet-12345 subnet-67890 --scaling-config minSize=2,maxSize=5,desiredSize=3

# List node groups
aws eks list-nodegroups --cluster-name my-cluster

# Describe node group
aws eks describe-nodegroup --cluster-name my-cluster --nodegroup-name my-nodegroup

# Update node group
aws eks update-nodegroup-config --cluster-name my-cluster --nodegroup-name my-nodegroup --scaling-config minSize=3,maxSize=6,desiredSize=4

# Delete node group
aws eks delete-nodegroup --cluster-name my-cluster --nodegroup-name my-nodegroup
```

### Kubernetes Configuration

```powershell
# Update kubeconfig for EKS cluster
aws eks update-kubeconfig --name my-cluster

# Update kubeconfig with specific role
aws eks update-kubeconfig --name my-cluster --role-arn arn:aws:iam::123456789012:role/eks-admin-role

# Get auth configuration
aws eks get-token --cluster-name my-cluster
```
<div style="page-break-after:always;"></div>

## API Gateway
_Create, publish, and manage APIs in AWS._

### API Operations

```powershell
# Create REST API
aws apigateway create-rest-api --name 'My API' --description 'My REST API'

# Get APIs
aws apigateway get-rest-apis

# Get resources
aws apigateway get-resources --rest-api-id 1234567890

# Create resource
aws apigateway create-resource --rest-api-id 1234567890 --parent-id abcdef --path-part items

# Create method
aws apigateway put-method --rest-api-id 1234567890 --resource-id ghijkl --http-method GET --authorization-type NONE

# Set integration
aws apigateway put-integration --rest-api-id 1234567890 --resource-id ghijkl --http-method GET --type AWS --integration-http-method POST --uri 'arn:aws:apigateway:us-east-1:lambda:path/2015-03-31/functions/arn:aws:lambda:us-east-1:123456789012:function:my-function/invocations'

# Deploy API
aws apigateway create-deployment --rest-api-id 1234567890 --stage-name prod

# Delete API
aws apigateway delete-rest-api --rest-api-id 1234567890
```

### API Stage Operations

```powershell
# Create stage
aws apigateway create-stage --rest-api-id 1234567890 --stage-name test --deployment-id abcdef

# List stages
aws apigateway get-stages --rest-api-id 1234567890

# Update stage
aws apigateway update-stage --rest-api-id 1234567890 --stage-name test --patch-operations op=replace,path=/cacheClusterEnabled,value=true op=replace,path=/cacheClusterSize,value=0.5

# Delete stage
aws apigateway delete-stage --rest-api-id 1234567890 --stage-name test

# Create API key
aws apigateway create-api-key --name MyAPIKey --enabled

# Create usage plan
aws apigateway create-usage-plan --name "My Usage Plan" --api-stages restApiId=1234567890,stage=prod

# Add API key to usage plan
aws apigateway create-usage-plan-key --usage-plan-id 12345 --key-type API_KEY --key-id abcde12345
```
<div style="page-break-after:always;"></div>

## SNS and SQS
_Manage messaging services in AWS._

### SNS (Simple Notification Service)

```powershell
# Create topic
aws sns create-topic --name my-topic

# List topics
aws sns list-topics

# Subscribe to topic
aws sns subscribe --topic-arn arn:aws:sns:us-east-1:123456789012:my-topic --protocol email --notification-endpoint user@example.com

# List subscriptions
aws sns list-subscriptions

# Publish message
aws sns publish --topic-arn arn:aws:sns:us-east-1:123456789012:my-topic --message "Hello World"

# Unsubscribe
aws sns unsubscribe --subscription-arn arn:aws:sns:us-east-1:123456789012:my-topic:abcdef

# Delete topic
aws sns delete-topic --topic-arn arn:aws:sns:us-east-1:123456789012:my-topic
```

### SQS (Simple Queue Service)

```powershell
# Create queue
aws sqs create-queue --queue-name my-queue

# List queues
aws sqs list-queues

# Get queue URL
aws sqs get-queue-url --queue-name my-queue

# Send message
aws sqs send-message --queue-url https://sqs.us-east-1.amazonaws.com/123456789012/my-queue --message-body "Hello World"

# Receive messages
aws sqs receive-message --queue-url https://sqs.us-east-1.amazonaws.com/123456789012/my-queue --max-number-of-messages 10

# Delete message
aws sqs delete-message --queue-url https://sqs.us-east-1.amazonaws.com/123456789012/my-queue --receipt-handle AQEB...

# Purge queue
aws sqs purge-queue --queue-url https://sqs.us-east-1.amazonaws.com/123456789012/my-queue

# Delete queue
aws sqs delete-queue --queue-url https://sqs.us-east-1.amazonaws.com/123456789012/my-queue
```
<div style="page-break-after:always;"></div>

## Secrets Manager
_Securely store and manage credentials and other sensitive information._

### Secrets Operations

```powershell
# Create secret
aws secretsmanager create-secret --name db/prod/credentials --description "Database credentials" --secret-string '{"username":"admin","password":"secret123"}'

# List secrets
aws secretsmanager list-secrets

# Get secret value
aws secretsmanager get-secret-value --secret-id db/prod/credentials

# Update secret
aws secretsmanager update-secret --secret-id db/prod/credentials --secret-string '{"username":"admin","password":"newsecret456"}'

# Rotate secret immediately
aws secretsmanager rotate-secret --secret-id db/prod/credentials

# Configure automatic rotation
aws secretsmanager rotate-secret --secret-id db/prod/credentials --rotation-lambda-arn arn:aws:lambda:us-east-1:123456789012:function:rotation-function --rotation-rules AutomaticallyAfterDays=30

# Delete secret
aws secretsmanager delete-secret --secret-id db/prod/credentials --recovery-window-in-days 7

# Delete secret without recovery
aws secretsmanager delete-secret --secret-id db/prod/credentials --force-delete-without-recovery
```

## Data Pipeline Commands
_Process and move data between different AWS services._

### Pipeline Operations

```powershell
# Create pipeline definition
aws datapipeline create-pipeline --name my-pipeline --unique-id my-unique-pipeline

# Upload pipeline definition
aws datapipeline put-pipeline-definition --pipeline-id df-1234567890ABCDEF --pipeline-definition file://pipeline-definition.json

# Activate pipeline
aws datapipeline activate-pipeline --pipeline-id df-1234567890ABCDEF

# List pipelines
aws datapipeline list-pipelines

# Get pipeline definition
aws datapipeline get-pipeline-definition --pipeline-id df-1234567890ABCDEF

# Describe pipelines
aws datapipeline describe-pipelines --pipeline-ids df-1234567890ABCDEF

# Deactivate pipeline
aws datapipeline deactivate-pipeline --pipeline-id df-1234567890ABCDEF

# Delete pipeline
aws datapipeline delete-pipeline --pipeline-id df-1234567890ABCDEF
```
<div style="page-break-after:always;"></div>

## Common Options and Parameters
_Parameter options that can be applied to most AWS CLI commands._

### Output Formatting

```powershell
# Change output format
aws ec2 describe-instances --output json
aws ec2 describe-instances --output text
aws ec2 describe-instances --output table
aws ec2 describe-instances --output yaml

# Query specific data
aws ec2 describe-instances --query 'Reservations[*].Instances[*].InstanceId'

# Filter array items
aws ec2 describe-instances --query 'Reservations[*].Instances[?State.Name==`running`].InstanceId'

# Format output with projections
aws ec2 describe-instances --query 'Reservations[*].Instances[*].[InstanceId,InstanceType,State.Name]'

# Count items
aws ec2 describe-instances --query 'length(Reservations[*].Instances[])'

# Sort output
aws ec2 describe-instances --query 'sort_by(Reservations[*].Instances[*], &LaunchTime)'
```

### Filters and Pagination

```powershell
# Use filters
aws ec2 describe-instances --filters "Name=instance-type,Values=t2.micro" "Name=availability-zone,Values=us-east-1a"

# Use pagination (reduce returned results)
aws s3api list-objects --bucket my-bucket --max-items 100

# Use pagination marker
aws s3api list-objects --bucket my-bucket --starting-token eyJNYX...

# Page size for API calls
aws ec2 describe-instances --page-size 10 --max-items 30

# Get pagination token for next page
aws ec2 describe-instances --page-size 5 --max-items 5 --query 'NextToken'
```

### Global Options

```powershell
# Use specific profile
aws s3 ls --profile production

# Use specific region
aws ec2 describe-instances --region us-west-2

# Set debug mode
aws ec2 describe-instances --debug

# Disable SSL verification (not recommended for production)
aws s3 ls --no-verify-ssl

# Set custom endpoint
aws s3api list-buckets --endpoint-url http://localhost:4572

# Set connection timeout
aws s3 ls --cli-connect-timeout 10

# Set command timeout
aws s3 ls --cli-read-timeout 30
```
<div style="page-break-after:always;"></div>

## Troubleshooting
_Diagnose and fix common AWS CLI issues._

### Common Issues

```powershell
# Check AWS CLI version
aws --version

# Check credential setup
aws configure list

# Update AWS CLI
pip install --upgrade awscli

# Enable debug mode for detailed error information
aws s3 ls --debug

# Enable verbose error messages
$env:AWS_STS_REGIONAL_ENDPOINTS = "regional"
$env:AWS_METADATA_SERVICE_TIMEOUT = "5"
$env:AWS_METADATA_SERVICE_NUM_ATTEMPTS = "10"

# Test credential provider
aws sts get-caller-identity

# Clear cached credentials
Remove-Item ~\.aws\credentials
Remove-Item ~\.aws\config

# Validate JSON input file
Get-Content template.json | ConvertFrom-Json

# Check TLS version issue
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

# Check with curl (alternative to test endpoint)
curl -v https://s3.amazonaws.com
```

### AWS CLI Error Codes

```powershell
# Common error codes and solutions:

# "ExpiredToken" - Your temporary credentials have expired
# Solution: Refresh your credentials with `aws sts get-session-token`

# "AccessDenied" - Insufficient permissions
# Solution: Check IAM policies and roles

# "ValidationError" - Invalid parameter value
# Solution: Check command syntax and parameter values

# "NoCredentialProviders" - No credentials found
# Solution: Run `aws configure` to set up credentials

# "MalformedPolicyDocument" - Invalid policy syntax
# Solution: Validate policy JSON format
```
<div style="page-break-after:always;"></div>

## Best Practices
_Guidelines for secure and efficient use of AWS CLI._

### Security Best Practices

```powershell
# Use IAM roles for EC2 instances instead of hard-coded credentials
# (No configuration needed if using instance profiles)

# Use temporary credentials with MFA
aws sts get-session-token --serial-number arn:aws:iam::123456789012:mfa/user --token-code 123456

# Store credentials securely
# Use AWS Secrets Manager or Systems Manager Parameter Store
aws secretsmanager get-secret-value --secret-id aws-cli/credentials

# Regularly rotate access keys
aws iam create-access-key --user-name user
aws iam delete-access-key --user-name user --access-key-id AKIAIOSFODNN7EXAMPLE

# Use dedicated IAM users for the CLI with least privilege
aws iam list-attached-user-policies --user-name cli-user

# Audit CLI activity with CloudTrail
aws cloudtrail lookup-events --lookup-attributes AttributeKey=Username,AttributeValue=user

# Use VPC endpoints for AWS services
aws ec2 create-vpc-endpoint --vpc-id vpc-1a2b3c4d --service-name com.amazonaws.us-east-1.s3 --route-table-ids rtb-1a2b3c4d
```

### Efficiency Best Practices

```powershell
# Use AWS CLI aliases for common commands
# In ~/.aws/cli/alias:
# [alias]
# todays-instances = ec2 describe-instances --query 'Reservations[].Instances[?LaunchTime>=`2023-01-01`]'

# Use parameter files for complex commands
aws ec2 run-instances --cli-input-json file://ec2-instance-params.json

# Use shorthand syntax for simple commands
aws s3 cp myfile.txt s3://my-bucket/ --acl public-read

# Use wait commands to wait for resources
aws ec2 run-instances --image-id ami-12345678 --instance-type t2.micro --count 1
aws ec2 wait instance-running --instance-ids i-1234567890abcdef0

# Use resource tagging consistently
aws ec2 create-tags --resources i-1234567890abcdef0 --tags Key=Environment,Value=Production Key=Owner,Value=TeamA

# Use AWS CLI profiles for different AWS accounts
aws configure --profile dev
aws configure --profile prod
aws s3 ls --profile dev

# Use AWS CLI auto-prompting for help with complex commands
aws ec2 run-instances --cli-auto-prompt
```

### Organization Best Practices

```powershell
# Script and automate common tasks
# Example script to stop all dev instances:
# $instances = aws ec2 describe-instances --filters "Name=tag:Environment,Values=Dev" --query 'Reservations[*].Instances[*].InstanceId' --output text
# foreach ($id in $instances) { aws ec2 stop-instances --instance-ids $id }

# Use consistent resource naming
aws ec2 create-tags --resources i-1234567890abcdef0 --tags Key=Name,Value=app-prod-web01

# Document CLI commands for team knowledge sharing
# Create internal wiki with example commands

# Use version control for CLI scripts
# git add deploy-script.ps1
# git commit -m "Add EC2 deployment script"

# Create pipeline helper functions
function Deploy-Stack {
    param($env, $version)
    aws cloudformation deploy --template-file template.yaml --stack-name "app-$env" --parameter-overrides Version=$version
}
```