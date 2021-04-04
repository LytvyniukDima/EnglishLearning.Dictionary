imageName="english_dictionary"
nuget_pass=$NUGET_TOKEN
wordapi=$WORDAPI_TOKEN

docker build -t $imageName --build-arg NUGET_PASS=$nuget_pass \
    --build-arg WORDAPI=$wordapi \
    --build-arg TEXT_SPEECH=$text_speech_token \
    --build-arg TEXT_REGION=$text_region .
