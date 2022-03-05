#!/bin/sh

set -x;
echo $USER

echo "#### docker-compose down -v"
docker-compose -p meu_atelie_docs -f ./docker-comp-docs.yml down