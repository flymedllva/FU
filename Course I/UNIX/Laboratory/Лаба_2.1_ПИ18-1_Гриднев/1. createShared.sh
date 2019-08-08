#!/bin/bash
#
#	Создание каталога с правами rwxrwxrwx (777)
#
# 	В качестве аргумента можно задать путь(в том числе и относительный), если его не будет, по умолчанию "/tmp/shared"
#
# 	Example:
#	bash $filename /tmp/shared/test
#
if [ -z "$1" ]; then
	path=/tmp/shared
else
	path=$1
fi
if ! [ -d $path ]; then
	mkdir -p $path
	if [ -d $path ]; then
		echo "Директория '$path' успешно создана"
		successful=1
	else
		echo "Ошибка при создании директории '$path'"
		successful=0
	fi
else
	echo "Директория '$path' уже сущетвует"
	successful=1
fi

if [ "$successful" -eq "1" ]; then
	chmod -R 777 $path
fi