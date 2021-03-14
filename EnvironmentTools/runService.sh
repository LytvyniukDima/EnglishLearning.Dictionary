imageName="english_dictionary"
containerName="dictionary_service"
networkName="english-net"

docker kill $containerName
docker rm $containerName

docker run -p 8200:8200 \
    --name $containerName \
    --network $networkName \
    $imageName
