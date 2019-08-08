#!/bin/bash

echo "Домашний каталог пользователя $USER"
echo "содержит обычных файлов:"
find $HOME -type f -maxdepth 1 | grep -v '/\.' | wc -l | sed s/' '//g
echo "скрытых файлов:"
find $HOME -type f -name ".*" -maxdepth 1 -print | wc -l | sed s/' '//g
