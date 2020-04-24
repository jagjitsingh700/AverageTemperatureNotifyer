# AverageTemperatureNotifyer
Basic POC of Azure Notification Hub where app consumers will get the average temperature notified on their mobile phones each day. 

# Technology Overview

Azure Notification Hubs provides an easy-to-use and scaled-out push engine that allows you to send notifications to any platform (iOS, Android, Windows, Kindle, Baidu, etc) from any backend(cloud or on-premises). 

# Architecture

In this case "AverageTemperatureNotifyer" will get weather data from Metrologisk Institutt and push it to Azure Notification Hub which again will send to respective platforms in form of notifications. 

# Getting Started

1. First of all create a "Notification Namespace" and "Notification Hub" with following commands: 

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



