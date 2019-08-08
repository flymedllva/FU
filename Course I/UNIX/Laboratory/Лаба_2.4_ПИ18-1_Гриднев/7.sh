#!/bin/bash

echo "Процессов пользователя: $USER"
ps -f -u $USER | wc -l | sed s/' '//g
echo "Процессов пользователя root:"
ps -f -u "root" | wc -l | sed s/' '//g