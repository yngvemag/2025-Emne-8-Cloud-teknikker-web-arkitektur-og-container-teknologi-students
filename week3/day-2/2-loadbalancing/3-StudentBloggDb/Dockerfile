FROM mysql:8.0.33

# root password
# docker run --name studentblogg-db --env-file .env -p 4444:3306 -d studentblogg-db

COPY studentblogg-dump.sql /docker-entrypoint-initdb.d/
COPY ga_setup_user_privileges.sql /docker-entrypoint-initdb.d/

EXPOSE 3306