#!/bin/bash

sh 15.sh $@
for i in $@
do
	sh 15.sh i
done

# Не особо понял, что надо, но либо так
# Либо просто так
# sh 15.sh $@
# sh 15.sh "$*"