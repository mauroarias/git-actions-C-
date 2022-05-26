#! /bin/bash

#----------------------------------------------------------------------
# AREA 51 :P, FRAMEWORK vars area PLEASE BE careful.
#----------------------------------------------------------------------

#----------------------------------------------------------------------
# Developer Area, please put here your vars.
#----------------------------------------------------------------------
POSTGRES_DB=db
POSTGRES_USER=user
POSTGRES_PASSWORD=password
CONNECTION="Server=postgres;Port=5432;Database=${POSTGRES_DB};User Id=${POSTGRES_USER};Password=${POSTGRES_PASSWORD}"

export POSTGRES_DB=$POSTGRES_DB
export POSTGRES_USER=$POSTGRES_USER
export POSTGRES_PASSWORD=$POSTGRES_PASSWORD 