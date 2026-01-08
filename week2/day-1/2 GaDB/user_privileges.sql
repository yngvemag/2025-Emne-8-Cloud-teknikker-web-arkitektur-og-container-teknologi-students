# create user
CREATE USER IF NOT EXISTS 'ga-app'@'ga_emne7_avansert' IDENTIFIED BY 'ga-5ecret-%';
CREATE USER IF NOT EXISTS 'ga-app'@'%' IDENTIFIED BY 'ga-5ecret-%';

GRANT ALL privileges ON ga_emne7_avansert.* TO 'ga-app'@'%';
GRANT ALL privileges ON ga_emne7_avansert.* TO 'ga-app'@'ga_emne7_avansert';

FLUSH PRIVILEGES;
