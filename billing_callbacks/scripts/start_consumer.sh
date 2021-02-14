#!/usr/bin/env bash

if [ "$#" -lt 4 ]; then
  echo "You must supply job_name and job_count to start"
  echo "./start_consumer.sh -n job_name -c job_count"
fi

while getopts n:c: flag
do 
  case "${flag}" in
    n) job_name=${OPTARG};;
    c) job_count=${OPTARG};;
  esac
done

dotnet ./bin/Debug/netcoreapp3.1/billing_callbacks.dll start $job_name $job_count