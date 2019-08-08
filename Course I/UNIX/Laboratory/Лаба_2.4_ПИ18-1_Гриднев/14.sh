#!/bin/bash
path="/tmp/big.txt"
find $HOME -maxdepth 1 -name "*.txt" > $path
cat $path
TEMP=( $( ls -ln $path ) )
SIZE=${TEMP[4]}
LEN=$( cat $path | wc -l | sed s/' '//g )
echo "Файл $path, размер: $SIZE байт, строк: $LEN"
rm $path