#!/usr/bin/bash

function helPanel(){

      cat <<-!

        Available flags:

        -c Number of cores to stress.
        -t Duration of stress test (in seconds). 
        -h Show this Help Panel.

        Example:

        $0 -c 2 -t 300
!

}
function stress(){

  for ((cont=0; $cont<$cores; cont++)){
    echo 'scale=100000;pi=4*a(1);0' | bc -l &
  }
  sleep $timeout
  killall bc
}

function __main__(){

  declare -i params=0
  local OPTIND

  while getopts c:t:h args; do 
    case $args in
      c) cores=${OPTARG};let params++ ;;
      t) timeout=${OPTARG}; let params++ ;;
      h) helPanel; exit 0 ;;
      ?) helPanel; exit 1 ;;
    esac
  done

  [[ $params -ne 2 ]] && { printf 'Error: -c and -t are required.\n'; helPanel ;} || { stress ;}

}

__main__ "$@"
