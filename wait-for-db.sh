#!/bin/sh

# until we can connect to the database server we will keep waiting
until nc -z -v -w30 $DB_HOST $DB_PORT
do
  echo "Waiting for database connection..."
  sleep 1
done

echo "Database is up - executing command"
exec "$@"