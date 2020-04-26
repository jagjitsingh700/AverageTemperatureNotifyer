# AverageTemperatureNotifyer

Basic POC of Azure Notification Hub where app consumers will get the average temperature notified on a weather app running on their mobile phones based on subscribed area. 

# Technology Overview

Azure Notification Hubs provides an easy-to-use and scaled-out push engine that allows you to send notifications to any platform (iOS, Android, Windows, Kindle, Baidu, etc) from any backend(cloud or on-premises). 

# Architecture

In this case "AverageTemperatureNotifyer" will get weather data from "Metrologisk Institutt" and send a notification to Azure Notification Hub which again will send to respective platforms in form of notifications. The architecture can be splitted in two parts, one is the sending of notifications(Will be covered in this POC) and the other part is receiving in mobile & desktop apps (Will not be covered in this POC). 

NB! In this example an actual implementation to get weather data from "Metrologisk Institut" will not be created. We will mock that part. 

# Getting Started

1. First of all create a "Notification Namespace" and "Notification Hub" in Azure with following commands(Included in POC):

```
#1. Login To Your Azure Environment
az login

#2. Install the Azure CLI Extension For Notification Hub To Run Related Commands
az extension add --name notification-hub

#3. Create A Resource Group 
az group create --name AverageTemperatureNotifyer --location northeurope

#4. Before Creating A Namespace For The Hub We Want To Check The Availability
az notification-hub namespace check-availability --name AverageTemperatureContainer

#5. Next Command Is To Create The Namespace Itself Which Will Act As A Container Containing 1 Or More Hubs. 
az notification-hub namespace create --resource-group AverageTemperatureNotifyer --name AverageTemperatureContainer --location northeurope --sku Free

#6. An Access Policy Named RootManageSharedAccessKey Is Automatically Created. List Keys And Connection Strings For Your Namespace Access Policy
az notification-hub namespace authorization-rule list-keys --resource-group AverageTemperatureNotifyer --namespace-name AverageTemperatureContainer --name RootManageSharedAccessKey

#7 Create Your First Notification Hub
az notification-hub create --resource-group  AverageTemperatureNotifyer --namespace-name AverageTemperatureContainer --name AverageTemperatureHub1 --location northeurope --sku Free
```

2. Implement "Console" application for sending area wise template notifications for the average temperature each day. This application will only send a template notification targeting all PNS(Platform Notfication Service), like APNS, GCM/FCM, WNS, and MPNS template registrations. In order words only one notficiation template is needed to be sent out from console application and that same template notfication will by Notfication Hub be sent to all different platforms through their PNS. (Part of POC)

# Extension of POC

Extended Setup For Having A Fully Working Concept (Not Part of POC): 

3 Go to the "Notification Hub" and further to "Settings" in order to do needed setup for your application to receive notifications from the hub. (This part is not included in this POC, but is a further natural extension of POC)

4 Create a mobile application or desktop application which should get the notification. That application need to register their "Channel URI" in the "Notification Hub" in order to receive a notification. That application also need to use "Tag" for letting "Notification Hub" know when to receive a message. In this example the "Tag" could be "Oslo", now they will only get notification for updates on the average temperature in "Oslo". (This part is not included in this POC, but is a further natural extension of POC)
