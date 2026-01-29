# S3 Commands

```bash

# liste buckets og filer
aws s3 ls
aws s3 ls s3://my-bucket
aws s3 ls s3://my-bucket/folder/

# last opp filer
aws s3 cp file.txt s3://my-bucket/file.txt
aws s3 cp file.txt s3://my-bucket/folder/file.txt

# upload mappe (rekursiv)
aws s3 cp ./local-folder s3://my-bucket/folder --recursive

# last ned filer
aws s3 cp s3://my-bucket/file.txt .
aws s3 cp s3://my-bucket/folder ./folder --recursive

# synkronisering
aws s3 sync ./local-folder s3://my-bucket
aws s3 sync s3://my-bucket ./local-folder


# flytte filer
aws s3 rm s3://my-bucket/file.txt
aws s3 rm s3://my-bucket/folder/ --recursive

# .. med sletting
aws s3 sync ./local s3://my-bucket --delete


# slette filer
aws s3 rm s3://my-bucket/file.txt
aws s3 rm s3://my-bucket/folder/ --recursive

# flytte filer
aws s3 mv file.txt s3://my-bucket/file.txt
aws s3 mv s3://my-bucket/old.txt s3://my-bucket/new.txt

# lage og slette buckets
aws s3 mb s3://my-bucket --region eu-north-1
aws s3 rb s3://my-bucket
aws s3 rb s3://my-bucket --force

# nyttige flag


```