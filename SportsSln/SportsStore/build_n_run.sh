#!/bin/bash

dotnet publish -c Release
docker-compose build
docker-compose up