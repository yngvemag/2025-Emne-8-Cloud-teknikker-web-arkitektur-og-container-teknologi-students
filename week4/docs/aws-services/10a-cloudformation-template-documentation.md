# AWS CloudFormation Template Documentation

## Introduksjon

Dette dokumentet forklarer hvordan CloudFormation-malen setter opp en Amazon EC2-instans med Internett-tilgang. Det inkluderer en VPC, en offentlig subnet, en Internet Gateway (IGW), en sikkerhetsgruppe, en IAM-rolle og en rute for å tillate ekstern tilkobling.

## Kommandolinje for CloudFormation

For å opprette infrastrukturen med CloudFormation, bruk følgende kommando i AWS CLI:

```sh
aws cloudformation create-stack --stack-name MyEC2Stack --template-body file://cloudformation-template.yaml --capabilities CAPABILITY_IAM
```

For å oppdatere en eksisterende stack:

```sh
aws cloudformation update-stack --stack-name MyEC2Stack --template-body file://cloudformation-template.yaml --capabilities CAPABILITY_IAM
```

For å sjekke status på stack:

```sh
aws cloudformation describe-stacks --stack-name MyEC2Stack
```

For å slette stack:

```sh
aws cloudformation delete-stack --stack-name MyEC2Stack
```

---
<br><br><br><br><br><br><br><br><br><br><br>
## Forklaring av CloudFormation-malen

### 1. **Opprettelse av en VPC**

```yaml
DefaultVPC:
  Type: AWS::EC2::VPC
  Properties:
    CidrBlock: 172.31.0.0/16
    EnableDnsSupport: true
    EnableDnsHostnames: true
    Tags:
      - Key: Name
        Value: DefaultVPC
```

- **Hva det gjør:** Oppretter en VPC med CIDR-blokken `172.31.0.0/16`.
- **Hvorfor:** Dette gir et isolert nettverksmiljø for EC2-instansen.

### 2. **Opprettelse av en offentlig subnet**

```yaml
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
```

- **Hva det gjør:** Oppretter en subnet i VPC-en som automatisk gir EC2-instansen en offentlig IP.
- **Hvorfor:** En subnet er nødvendig for å plassere EC2-instansen i et spesifikt nettverksområde.

### 3. **Opprettelse av en Internet Gateway**

```yaml
InternetGateway:
  Type: AWS::EC2::InternetGateway
  Properties:
    Tags:
      - Key: Name
        Value: DefaultInternetGateway
```

- **Hva det gjør:** Oppretter en Internet Gateway.
- **Hvorfor:** Dette kreves for at EC2-instansen skal ha Internett-tilgang.
<br><br>
### 4. **Knytter Internet Gateway til VPC**

```yaml
AttachGateway:
  Type: AWS::EC2::VPCGatewayAttachment
  Properties:
    VpcId: !Ref DefaultVPC
    InternetGatewayId: !Ref InternetGateway
```

- **Hva det gjør:** Knytter Internet Gateway til VPC-en.
- **Hvorfor:** Uten denne koblingen kan ikke trafikk gå ut til Internett.

### 5. **Opprettelse av en Route Table og rute til Internett**

```yaml
DefaultRouteTable:
  Type: AWS::EC2::RouteTable
  Properties:
    VpcId: !Ref DefaultVPC
    Tags:
      - Key: Name
        Value: DefaultRouteTable
```

```yaml
DefaultRoute:
  Type: AWS::EC2::Route
  DependsOn: AttachGateway
  Properties:
    RouteTableId: !Ref DefaultRouteTable
    DestinationCidrBlock: 0.0.0.0/0
    GatewayId: !Ref InternetGateway
```

- **Hva det gjør:** Oppretter en rute som sender all trafikk (`0.0.0.0/0`) ut gjennom Internet Gateway.
- **Hvorfor:** Dette er nødvendig for at EC2-instansen skal kunne kommunisere med eksterne tjenester.

### 6. **Knytter subnettet til Route Table**

```yaml
SubnetRouteTableAssociation:
  Type: AWS::EC2::SubnetRouteTableAssociation
  Properties:
    SubnetId: !Ref DefaultSubnet
    RouteTableId: !Ref DefaultRouteTable
```

- **Hva det gjør:** Knytter subnettet til route-tabellen slik at den bruker ruten til Internett.
- **Hvorfor:** Uten dette vil subnettet ikke kunne sende trafikk ut.
<br><br>
### 7. **Opprettelse av en sikkerhetsgruppe**

```yaml
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
```

- **Hva det gjør:** Tillater innkommende SSH (22), HTTP (80), og Docker-port (8080).
- **Hvorfor:** For å kunne koble til og hoste webapplikasjoner.

### 8. **Opprettelse av en IAM Instance Profile**

```yaml
EC2InstanceProfile:
  Type: AWS::IAM::InstanceProfile
  Properties:
    Roles:
      - !Ref EC2InstanceRole
```

- **Hva det gjør:** Gir EC2-instansen tilgang til AWS-tjenester.
- **Hvorfor:** Kan være nødvendig for fremtidige oppgaver.
<br><br><br><br><br><br><br><br><br><br><br><br><br>
### 9. **Opprettelse av en EC2-instans**

```yaml
EC2Instance:
  Type: AWS::EC2::Instance
  Properties:
    InstanceType: t3.micro
    ImageId: ami-09a9858973b288bdd
    KeyName: studentblogg-api-key
    SecurityGroupIds:
      - !Ref InstanceSecurityGroup
    SubnetId: !Ref DefaultSubnet
    IamInstanceProfile: !Ref EC2InstanceProfile
```

- **Hva det gjør:** Starter en EC2-instans i subnettet.
- **Hvorfor:** Dette er hovedkomponenten for å kjøre applikasjonen.

## **Oppsummering**

Dette CloudFormation-oppsettet gir en fullt funksjonell EC2-instans med:

- En offentlig IP-adresse
- Internett-tilgang
- Åpne porter for SSH, HTTP og Docker
- En IAM-rolle for fremtidige behov

### **Neste steg:**

1. Kjør CloudFormation-kommandoen for å opprette stacken.
2. Logg inn på EC2 med:

   ```sh
   ssh -i studentblogg-api-key.pem ubuntu@<EC2_PUBLIC_IP>
   ```

3. Test HTTP-tilkoblingen:

   ```sh
   curl http://<EC2_PUBLIC_IP>
   ```
