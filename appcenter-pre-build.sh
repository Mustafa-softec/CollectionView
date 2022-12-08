#!/usr/bin/env bash
#
# For Xamarin, change some constants located in some class of the app.
# In this sample, suppose we have an AppConstant.cs class in shared folder with follow content:
#
# namespace Core
# {
#     public class AppConstant
#     {
#         public const string ApiUrl = "https://CMS_MyApp-Eur01.com/api";
#     }
# }
# 
# Suppose in our project exists two branches: master and develop. 
# We can release app for production API in master branch and app for test API in develop branch. 
# We just need configure this behaviour with environment variable in each branch :)
# 
# The same thing can be perform with any class of the app.
#
# AN IMPORTANT THING: FOR THIS SAMPLE YOU NEED DECLARE API_URL ENVIRONMENT VARIABLE IN APP CENTER BUILD CONFIGURATION.

if [ -z "$API_URL" ]
then
    echo "You need define the API_URL variable in App Center"
    exit
fi

if [ -z "$APS_ENVIRONMENT" ]
then
    echo "You need define the APS_ENVIRONMENT variable in App Center"
    exit
fi

ENTITLEMENTS_PLIST_FILE=$APPCENTER_SOURCE_DIRECTORY/Cura/Entitlements.plist

if [ -e "$ENTITLEMENTS_PLIST_FILE" ]
then
    echo "Updating aps-environment to $APS_ENVIRONMENT in Entitlements.plist"
    plutil -replace aps-environment -string $APS_ENVIRONMENT $ENTITLEMENTS_PLIST_FILE

    echo "File content:"
    cat $ENTITLEMENTS_PLIST_FILE
else
     echo "Fail to update aps-environment"
    exit
fi


APP_CONSTANT_FILE=$APPCENTER_SOURCE_DIRECTORY/Core/AppConstant.cs

if [ -e "$APP_CONSTANT_FILE" ]
then
    echo "Updating ApiUrl to $API_URL in AppConstant.cs"
    sed -i '' 's#ApiUrl = "[-A-Za-z0-9:_./]*"#ApiUrl = "'$API_URL'"#' $APP_CONSTANT_FILE

    echo "File content:"
    cat $APP_CONSTANT_FILE
fi
