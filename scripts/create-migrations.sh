#!/usr/bin/env bash

# Verifica se o arquivo .env existe
if [ -f ../.env ]; then
  VALUE=$(<../.env)
 
  OS=$(awk '{print $1}' <<< $(uname -a))

  # Remove os comentarios.
  SPLIT_NOW=$(awk '{print $01}' <<< "${VALUE}" | grep -o '^[^#]*')
  
  # Percorre as linhas do arquivo e transforma o conteudo das variaveis em array.
  while read -r line; do
    SPLIT+=("$line")
  done <<< "$SPLIT_NOW"

   
  # Percorre o Array e verifica se a variavel CONTAINER_NAME_API não esta vazia.

   for ((i = 0 ; i < ${#SPLIT[@]}; i++)); do
     RESULT=$(echo "${SPLIT[$i]}" | grep CONTAINER_NAME_API |  cut -d'=' -f2)
     if [[ -n "$RESULT" ]]; then
        NODE_MODULES=$(docker exec -it "${RESULT}" pwd)
        API=$(awk '{print $NF}' <<< $(docker exec -it "${RESULT}" ls -la | grep api))
        CONTAINER_NAME_API[0]=${RESULT}
     fi
   done

  if [[ -n "$NODE_MODULES" ]]; then
    if [[ -n "$API" ]]; then
      for file in ../src/api/Database/*.cs 
      do 
          if [[ -f "${file}" ]]; then
              ARQ="${file##*/}"
              if [[ -n "$OS" ]] && [[ "$OS" == "Linux" ]]; then
                 docker exec -it "$CONTAINER_NAME_API" bash -c "cd api && dotnet ef database update --context ${ARQ%.cs}"
              else
                 eval "cd src/api && dotnet ef database update --context ${ARQ%.cs}"
              fi
          fi
      done
    fi
  fi
fi





