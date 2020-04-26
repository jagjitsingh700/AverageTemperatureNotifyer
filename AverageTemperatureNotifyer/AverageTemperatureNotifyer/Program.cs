using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;

namespace AverageTemperatureNotifyer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static async void SendTemplateNotificationAsync()
        {
            // Define the notification hub.
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString("<connection string with full access>", "<hub name>");

            // Apple requires the apns-push-type header for all requests
            var headers = new Dictionary<string, string> { { "apns-push-type", "alert" } };

            // Create an array of different areas the average temperature notficiations should go for.
            var areas = new string[] { "Oslo", "Stockholm", "Copenhagen"};

            // Send the notification as a template notification. All template registrations that contain
            // "messageParam" and the proper tags will receive the notifications.
            // This includes APNS, GCM/FCM, WNS, and MPNS template registrations.

            Dictionary<string, string> templateParams = new Dictionary<string, string>();

            foreach (var area in areas)
            {
                templateParams["messageParam"] = "Area " + area + " Temperature Update!";
                await hub.SendTemplateNotificationAsync(templateParams, area);
            }
        }
    }
}
