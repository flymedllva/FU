#!/bin/bash

find ~ -maxdepth 1 -name "*.txt" | wc -l | sed s/' '//g
