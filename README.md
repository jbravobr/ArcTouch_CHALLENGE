# ArcTouch Demo App

This is the App created for the MOBILE DEV CODE CHALLENGE.

![alt text](https://github.com/jbravobr/ArcTouch_DemoApp/blob/master/screenshots/android/android1.png?raw=true "Android's capture")
![alt text](https://github.com/jbravobr/ArcTouch_DemoApp/blob/master/screenshots/ios/iphone1.png?raw=true "iOS's capture")

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

## Installing 

```
Clone this repository and open the solution using either Xamarin Studio (preferably) or Visual Studio 2017 or 2109 (both with the Xamarin tools installed and updated by the STABLE channel)
```
## Show some screens

![alt text](https://github.com/jbravobr/ArcTouch_DemoApp/blob/master/screenshots/android/android2.png?raw=true  "Android's capture")

![alt text](https://github.com/jbravobr/ArcTouch_DemoApp/blob/master/screenshots/ios/iphone2.png?raw=true "iOS's capture")

## Third-party components (plug-ins via nuget and direct install)

These were the main plug-ins used

| Plug-ins|
| ------------------- |
|SyncFusion Rating Control|
|SyncFusion ListView Control|
|Prism Library|
|FFImageLoading|
|Xamarin Connectivity Plugin|
|PropertyChanged|
|Acr UserDialogs|

### SyncFusion Rating Control & SyncFusion ListView Control

Syncfusion provides a range of controls for Xamarin. For this App we use the rating control, in the format of stars to display the average rating of the movies
[For more information access here](https://help.syncfusion.com/xamarin/sfrating/overview)

### Prism Library

We used the Prism library to improve the native MVVM features of the Xamarin Forms library and have better control and performance over the navigation within the App. In addition to decreasing the coupling in the App, allowing us greater testability
[For more information access here](https://github.com/PrismLibrary/Prism)

### FFImageLoading

We use the FFImageLoading plug-in for greater agility and flexibility in working with images, allowing us to treat simpler blur and the possibility of working with cache
[For more information access here](https://github.com/luberda-molinet/FFImageLoading)

### Xamarin Connectivity Plugin

We use the Xamarin Connectivity Plugin plug-in to give us the flexibility to access the connectivity features of both platforms via PCL
[For more information access here](https://github.com/jamesmontemagno/ConnectivityPlugin)

### PropertyChanged (Fody)

We use the PropertyChanged plug-in to make it easier to use "Auto-observable" properties through the INotifyPropertyChanged interface and thus keep the MVVM standard more fluid
[For more information access here](https://github.com/Fody/PropertyChanged)

### Acr UserDialogs

We use the Acr UserDialogs plug-in to work with displaying alerts and personalized messages in a simple way through the PCL project
[For more information access here](https://github.com/aritchie/userdialogs)

## Built With

* [Xamarin Forms](https://www.nuget.org/packages/Xamarin.Forms/) - Xamarin Forms (Last Stable Version)
* [Mono](https://www.mono-project.com/docs/about-mono/releases/5.18.0/) - Mono (Last Stable Version)

## Authors

* **Rodrigo Amaro**

## License

This project is licensed under the MIT License 