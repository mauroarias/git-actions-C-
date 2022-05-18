#! /bin/bash

source scripts/CommonLib.sh

# wait
sleep 20

# Loading db schema
loadPostgresSchema

waitServerUp "http://mock:80/__admin/mappings" "mock" "20"

# Loading mock stubs
initMockStubs "http://mock:80"
