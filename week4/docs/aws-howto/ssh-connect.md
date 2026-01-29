# SSH connect

## Change mod .pem File

### Powershell

```bash
# Tilbakestiller filens Access Control List (ACL) til standard tillatelser som arves fra den overordnede mappen.
# Alle eksisterende eksplisitte rettigheter på filen blir fjernet.
# Etter denne kommandoen, arves rettighetene fra mappens ACL, med mindre arving blir deaktivert senere.
icacls .\studentblogg.pem /reset 

# Tildeler (grant) lesetilgang (r for read) til den gjeldende brukeren
# $($env:username) refererer til brukernavnet til den aktive Windows-brukeren
# :r spesifiserer at eventuelle tidligere tillatelser for denne brukeren fjernes, og kun de nye rettighetene blir brukt.
# Resultatet er at -> Kun den aktive brukeren får lesetilgang til filen.
icacls .\studentblogg.pem /grant:r "$($env:username):(r)"

# Deaktiverer arv for filen, slik at den ikke lenger arver tillatelser fra den overordnede mappen.
# Eksisterende arvede tillatelser blir fjernet, og kun eksplisitte rettigheter for filen forblir.
icacls .\studentblogg.pem /inheritance:r 

```

### Linux

```bash
# User | Group | Others
# rwx  | rwx   | rwx
# 100  | 000   | 000 -> 400
chmod 400 studentblogg.pem 

```
<div style="page-break-after:always;"></div>

## Connect to ec2 machine

### Amazon Linux

```bash
# amazon-linux (yum)
 ssh -i .\studentblogg.pem ec2-user@13.53.126.180
   ,     #_
   ~\_  ####_        Amazon Linux 2023
  ~~  \_#####\
  ~~     \###|
  ~~       \#/ ___   https://aws.amazon.com/linux/amazon-linux-2023
   ~~       V~' '->
    ~~~         /
      ~~._.   _/
         _/ _/
       _/m/'
[ec2-user@ip-10-0-10-194 ~]$ 
```

### Ubuntu
```bashsu

ssh -i .\studentblogg-ubuntu.pem ubuntu@13.48.55.93
The authenticity of host '13.48.55.93 (13.48.55.93)' can't be established.
ED25519 key fingerprint is SHA256:BteGEJSsbzZqovgMLTV5PWIoHaIDdfBjoMBY2ebNeMs.
This key is not known by any other names.
Are you sure you want to continue connecting (yes/no/[fingerprint])? yes
Warning: Permanently added '13.48.55.93' (ED25519) to the list of known hosts.
Welcome to Ubuntu 24.04.1 LTS (GNU/Linux 6.8.0-1021-aws x86_64)

 * Documentation:  https://help.ubuntu.com
 * Management:     https://landscape.canonical.com
 * Support:        https://ubuntu.com/pro

 System information as of Thu Jan 16 11:17:58 UTC 2025

  System load:  0.0               Temperature:           -273.1 C
  Usage of /:   24.9% of 6.71GB   Processes:             111
  Memory usage: 26%               Users logged in:       0
  Swap usage:   0%                IPv4 address for ens5: 10.0.15.182

Expanded Security Maintenance for Applications is not enabled.

0 updates can be applied immediately.

Enable ESM Apps to receive additional future security updates.
See https://ubuntu.com/esm or run: sudo pro status

```
#### Update ubuntu

```bash

sudo apt-get update
sudo apt-get install nginx
sudo systemctl status nginx

# restart nginx
sudo systemctl restart nginx

# reload config without stopping
sudo systemctl reload nginx

# check config file
sudo nginx -t
```


## Scp

```bash
# Kopierer fil til server
scp -i .\studentblogg-ubuntu.pem fil.txt ubuntu@13.48.55.93:~/

# Kopierer fil fra server
scp -i .\studentblogg-ubuntu.pem ubuntu@13.48.55.93:~/server-fil.txt .

# kopiere folder til server
scp -i .\studentblogg-ubuntu.pem -r local_directory ubuntu@13.48.55.93:~/

# kopiere folder fra server til lokal maskin
scp -i .\studentblogg-ubuntu.pem -r ubuntu@13.48.55.93:~/server_folder .
```