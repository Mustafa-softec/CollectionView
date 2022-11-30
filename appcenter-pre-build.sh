#!/usr/bin/env bash
if [ -z "$API_URL" ]; then
    echo "You need define the API_URL variable in App Center"
    exit
fi

APP_CONSTANT_FILE=$APPCENTER_SOURCE_DIRECTORY/Core/AppConstant.cs

if [ -e "$APP_CONSTANT_FILE" ]; then
    echo "Updating ApiUrl to $API_URL in AppConstant.cs"
    sed -i '' 's#ApiUrl = "[-A-Za-z0-9:_./]*"#ApiUrl = "'$API_URL'"#' $APP_CONSTANT_FILE

    echo "File content:"
    cat $APP_CONSTANT_FILE
fi