#!/bin/bash

date '+Дата: %m/%d/%y%nВремя: %H:%M:%S'
compgen -u | sort -u
uptime | cut -d"," -f1