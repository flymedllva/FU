#!/bin/bash

echo "Каталоги: "
ls -l | grep ^d
echo "Обычные файлы: "
ls -l | grep ^-
echo "Символьные ссылки: "
ls -l | grep ^l
echo "Символьные устройства: "
ls -l | grep ^c
echo "Блочные устройства: "
ls -l | grep ^b

