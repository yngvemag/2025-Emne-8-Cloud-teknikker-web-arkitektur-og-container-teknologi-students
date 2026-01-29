# AWS CloudFormation for EC2 with Docker og Docker Compose i en Default VPC

## Hvordan fungerer det?

1. **Oppretter en EC2-instans** i AWS Default VPC via CloudFormation.
2. **Oppretter et standard public subnet** for EC2-instansen.
3. **Installerer Docker** ved hjelp av `UserData`.
4. **Installerer Docker Compose**.
5. **Henter og kjører en `docker-compose.yml`-fil** fra en GitHub-repo.
6. **Starter tjenestene automatisk**.

## CloudFormation-template for EC2 med Docker og Docker Compose i en Default VPC

```yaml
AWSTemplateFormatVersion: '2010-09-09'

Resources:
  DefaultVPC:
    Type: AWS::EC2::VPC
    Properties:
      CidrBlock: 172.31.0.0/16
      EnableDnsSupport: true
      EnableDnsHostnames: true
      Tags:
        - Key: Name
          Value: DefaultVPC

  DefaultSubnet:
    Type: AWS::EC2::Subnet
    Properties:
      VpcId: !Ref DefaultVPC
      CidrBlock: 172.31.1.0/24
      MapPublicIpOnLaunch: true
      AvailabilityZone: !Select [ 0, !GetAZs "" ]
      Tags:
        - Key: Name
          Value: DefaultPublicSubnet

  InstanceSecurityGroup:
    Type: AWS::EC2::SecurityGroup
    Properties:
      GroupDescription: Allow SSH, HTTP, and Docker traffic
      VpcId: !Ref DefaultVPC
      SecurityGroupIngress:
        - IpProtocol: tcp
          FromPort: 22
          ToPort: 22
          CidrIp: 0.0.0.0/0
        - IpProtocol: tcp
          FromPort: 80
          ToPort: 80
          CidrIp: 0.0.0.0/0
        - IpProtocol: tcp
          FromPort: 8080
          ToPort: 8080
          CidrIp: 0.0.0.0/0

  EC2InstanceProfile:
    Type: AWS::IAM::InstanceProfile
    Properties:
      Roles:
        - !Ref EC2InstanceRole

  EC2InstanceRole:
    Type: AWS::IAM::Role
    Properties:
      AssumeRolePolicyDocument:
        Version: '2012-10-17'
        Statement:
          - Effect: Allow
            Principal:
              Service: [ec2.amazonaws.com]
            Action: sts:AssumeRole
      ManagedPolicyArns:
        - arn:aws:iam::aws:policy/AmazonEC2FullAccess

  EC2Instance:
    Type: AWS::EC2::Instance
    Properties:
      InstanceType: t3.micro
      ImageId: ami-09a9858973b288bdd  # Ubuntu 22.04 LTS Free Tier AMI
      KeyName: studentblogg-api-key
      SecurityGroupIds:
        - !Ref InstanceSecurityGroup
      SubnetId: !Ref DefaultSubnet
      IamInstanceProfile: !Ref EC2InstanceProfile
      NetworkInterfaces:
        - AssociatePublicIpAddress: true
          DeviceIndex: 0
      UserData:
        Fn::Base64: |
          #!/bin/bash
          apt update -y
          apt install -y docker.io
          systemctl start docker
          systemctl enable docker
          usermod -aG docker ubuntu
          newgrp docker
          
          # Installer Docker Compose
          curl -L "https://github.com/docker/compose/releases/latest/download/docker-compose-linux-x86_64" -o /usr/local/bin/docker-compose
          chmod +x /usr/local/bin/docker-compose

          # Hent docker-compose.yml fra GitHub
          curl -o /home/ubuntu/docker-compose.yml https://raw.githubusercontent.com/yngvemag/docker-compose-student-blogg-api-2025/master/docker-compose.yml
          
          # Sjekk at filen ble lastet ned
          if [ ! -f /home/ubuntu/docker-compose.yml ]; then
              echo "Docker Compose file not found!"
              exit 1
          fi
          
          # Start Docker Compose
          cd /home/ubuntu
          docker-compose up -d
      Tags:
        - Key: Name
          Value: EC2WithDocker
```

## Hvordan fungerer denne CloudFormation-malen?

1. **Oppretter en ny Default VPC** med et CIDR-nettverk `172.31.0.0/16`.
2. **Oppretter et public subnet** som automatisk tildeler offentlige IP-adresser.
3. **Oppretter en Security Group** som tillater SSH (22), HTTP (80), og applikasjoner på port 8080.
4. **Oppretter en EC2-instans** som:
   - Installerer Docker og Docker Compose
   - Henter og starter en Docker Compose-applikasjon fra GitHub
   - Kjøres i det opprettede public subnettet med offentlig IP

## Deploying CloudFormation-stacken

For å opprette denne infrastrukturen, bruk følgende AWS CLI-kommando:

```bash
aws cloudformation create-stack --stack-name EC2WithDocker \
    --template-body file://cloudformation.yml \
    --capabilities CAPABILITY_NAMED_IAM
```

### Forklaring av kommandoen

- **`aws cloudformation create-stack`** → Oppretter en ny CloudFormation-stack.
- **`--stack-name EC2WithDocker`** → Navn på stacken (brukes for å identifisere den i AWS Console eller via CLI).
- **`--template-body file://cloudformation.yml`** → Refererer til CloudFormation-malen som definerer infrastrukturen. `file://` indikerer at malen er en lokal fil.
- **`--capabilities CAPABILITY_NAMED_IAM`** → Kreves når malen inkluderer opprettelse av IAM-roller.

## Slik sjekker du status for stacken

For å sjekke status:

```bash
aws cloudformation describe-stacks --stack-name EC2WithDocker
```

Hvis du trenger å fjerne stacken og alle ressurser, bruk:

```bash
aws cloudformation delete-stack --stack-name EC2WithDocker
```

## Fordeler med å bruke Default VPC

- **Automatisk oppsett**: Ingen behov for å definere eksisterende VPC eller subnett.
- **Rask testing**: Passer for enkle EC2-installasjoner som krever offentlig IP.
- **Sikkerhet**: Kan fortsatt bruke Security Groups for tilgangsbegrensning.

Med denne tilnærmingen kan du enkelt sette opp en EC2-instans med Docker og Docker Compose i en AWS Default VPC! 🚀
