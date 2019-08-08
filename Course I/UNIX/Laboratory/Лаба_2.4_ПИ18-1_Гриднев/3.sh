#!/bin/bash
# Good morning

echo "Доброе утро $USER"
date +"Текущее время: %T.
Текущая дата: %d %B %Y"
printf "\n"
cal
echo "Список дел: "
while read -r i
do
	echo "•" $i
done < ~/TODO