imageName="english_dictionary"
nuget_pass=$NUGET_TOKEN

docker build -t $imageName --build-arg NUGET_PASS=$nuget_pass .
