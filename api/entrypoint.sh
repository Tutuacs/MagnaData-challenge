#!/bin/bash
set -e

echo "Aguardando MySQL estar pronto..."
sleep 10

echo "Iniciando aplicação..."
exec dotnet api.dll
