FROM mysql:latest

# root password
ENV MYSQL_ROOT_PASSWORD=gokstad

COPY gokstad-base.sql /docker-entrypoint-initdb.d/
COPY user_privileges.sql /docker-entrypoint-initdb.d/

EXPOSE 3306