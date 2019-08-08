#!/bin/bash
text="$USER $HOME"
echo -n $text ""
echo -n $text | wc -c | sed s/' '//g 

