#!/usr/bin/env bash

wget https://dist.nuget.org/win-x86-commandline/v5.10.0/nuget.exe
ln -s /Library/Frameworks/Mono.framework/Versions/Current/Commands/nuget nuget

#!/usr/bin/env bash

# Download Mono 6.12.0.145
wget https://download.mono-project.com/archive/6.12.0/macos-10-universal/MonoFramework-MDK-6.12.0.145.macos10.xamarin.universal.pkg

# Add execution permission
sudo chmod +x MonoFramework-MDK-6.12.0.145.macos10.xamarin.universal.pkg

# Install Mono 6.12.0.145
sudo installer -pkg MonoFramework-MDK-6.12.0.145.macos10.xamarin.universal.pkg -target /  

echo "MSBuild restore start"
MSBuild /Users/runner/work/1/s/NeilvynSampleBlueprint.Mobile.App/NeilvynSampleBlueprint.Mobile.App.Android/NeilvynSampleBlueprint.Mobile.App.Android.csproj -t:restore
echo "MSBuild restore finish"


CONSTANTS_FILE=$APPCENTER_SOURCE_DIRECTORY/NeilvynSampleBlueprint.Mobile.App.Common/Constants/AppConstants.cs

if [ -e "$CONSTANTS_FILE" ]
then
    if [ -z "$APP_ANDROID_SECRET" ]
    then
        echo "To use this APPCENTER KEY, define APP_ANDROID_SECRET in App Center build settings portal under environment variables"
    else
        echo "Updating AppCenterAndroidKey to $APP_ANDROID_SECRET in AppConstants.cs"
        sed -i '' 's#AppCenterAndroidKey = "[-A-Za-z0-9]*"#AppCenterAndroidKey = "'$APP_ANDROID_SECRET'"#' $CONSTANTS_FILE

        echo "File content:"
        cat $CONSTANTS_FILE
    fi

    if [ -z "$APP_IOS_SECRET" ]
    then
        echo "To use this APPCENTER KEY, define APP_IOS_SECRET in App Center build settings portal under environment variables"
    else
        echo "Updating AppCenterIosKey to $APP_IOS_SECRET in AppConstants.cs"
        sed -i '' 's#AppCenterIosKey = "[-A-Za-z0-9]*"#AppCenterIosKey = "'$APP_IOS_SECRET'"#' $CONSTANTS_FILE

        echo "File content:"
        cat $CONSTANTS_FILE
    fi

    if [ -z "$DISABLE_DEV_FEATURES" ]
    then
        echo "To use this Dev Features, define DISABLE_DEV_FEATURES in App Center build settings portal under environment variables"
    else
        echo "Updating DisableDevFeatures to $DISABLE_DEV_FEATURES in AppConstants.cs"
        sed -i '' 's#DisableDevFeatures = [A-Za-z]*#DisableDevFeatures = '$DISABLE_DEV_FEATURES'#' $CONSTANTS_FILE

        echo "File content:"
        cat $CONSTANTS_FILE
    fi
fi

SERVER_FILE=$APPCENTER_SOURCE_DIRECTORY/NeilvynSampleBlueprint.Mobile.App.Common/Constants/Server.cs

if [ -e "$SERVER_FILE" ]
then
    echo "Updating ApiBaseAddress to API_BASE_ADDRESS in Server.cs"
    sed -i '' 's#ApiBaseAddress = "[-A-Za-z0-9:_./]*"#ApiBaseAddress = "'$API_BASE_ADDRESS'"#' $SERVER_FILE

    echo "File content:"
    cat $SERVER_FILE
fi

if [ -z "$VERSION_MAJOR_MINOR" ]
then
	echo "To use this script, define VERSION_MAJOR_MINOR in App Center build settings portal under environment variables"
	exit
fi

if [ -z "$PACKAGE_NAME" ]
then
	echo "To use this script, define PACKAGE_NAME in App Center build settings portal under environment variables"
	exit
fi

ANDROID_MANIFEST_FILE=$APPCENTER_SOURCE_DIRECTORY/NeilvynSampleBlueprint.Mobile.App/NeilvynSampleBlueprint.Mobile.App.Android/Properties/AndroidManifest.xml
INFO_PLIST_FILE=$APPCENTER_SOURCE_DIRECTORY/NeilvynSampleBlueprint.Mobile.App/NeilvynSampleBlueprint.Mobile.App.iOS/Info.plist

if [ -z "$BUILD_NUMBER_ADJUSTMENT" ]
then
    PADDED_BUILD_NUMBER=$APPCENTER_BUILD_ID
else
    PADDED_BUILD_NUMBER=$((APPCENTER_BUILD_ID+BUILD_NUMBER_ADJUSTMENT))
fi

if [ -e "$ANDROID_MANIFEST_FILE" ]
then
    echo "Updating package name to $PACKAGE_NAME in AndroidManifest.xml"
    sed -i '' 's/package="[^"]*"/package="'$PACKAGE_NAME'"/' $ANDROID_MANIFEST_FILE
    sed -i '' "s/label=\"[-a-zA-Z0-9_ ]*\"/label=\"HermaRus$APP_BUILD_SUFFIX\"/" $ANDROID_MANIFEST_FILE
    sed -i '' 's/versionName="[0-9.]*"/versionName="'$VERSION_MAJOR_MINOR.$PADDED_BUILD_NUMBER'"/' $ANDROID_MANIFEST_FILE
    sed -i '' 's/versionCode="[0-9.]*"/versionCode="'$PADDED_BUILD_NUMBER'"/' $ANDROID_MANIFEST_FILE

    echo "File content:"
    cat $ANDROID_MANIFEST_FILE
fi


if [ -e "$INFO_PLIST_FILE" ]
then
    echo "Updating Version to $VERSION_MAJOR_MINOR.$PADDED_BUILD_NUMBER in Info.plist"
    plutil -replace CFBundleShortVersionString -string "$VERSION_MAJOR_MINOR" $INFO_PLIST_FILE
    plutil -replace CFBundleVersion -string "$VERSION_MAJOR_MINOR.$PADDED_BUILD_NUMBER" $INFO_PLIST_FILE

    echo "Updating package name to $PACKAGE_NAME in Info.plist"
    plutil -replace CFBundleIdentifier -string $PACKAGE_NAME $INFO_PLIST_FILE
    plutil -replace CFBundleDisplayName -string "HermaRus$APP_BUILD_SUFFIX" $INFO_PLIST_FILE

    echo "File content:"
    cat $INFO_PLIST_FILE
fi