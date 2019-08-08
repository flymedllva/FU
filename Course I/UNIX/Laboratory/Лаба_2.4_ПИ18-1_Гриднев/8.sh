#!/bin/bash

ps axo rss,comm | awk '{ list[$2] += $1; } END { for (item in list) { printf("%d\t%s\n", list[item], item); }}' | sort -n | tail -n 5 | sort -rn | awk '{$1/=1024;printf "%.0fMB\t",$1}{print $2}'