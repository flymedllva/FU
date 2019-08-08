#!/bin/bash

grep -m $3 $1 $2 | cat -n
