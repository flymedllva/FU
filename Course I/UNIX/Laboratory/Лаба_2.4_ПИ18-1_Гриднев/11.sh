#!/bin/bash

echo $(date '+Дата: %m/%d/%y%nВремя: %H:%M:%S') >> /tmp/run.log
echo "Hello, колличество запусков:" $(cat /tmp/run.log | wc -l)