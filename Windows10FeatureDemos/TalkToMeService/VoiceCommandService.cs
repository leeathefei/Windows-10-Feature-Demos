using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.VoiceCommands;

namespace TalkToMeService
{
    public sealed class TalkToMeVoiceCommandService : IBackgroundTask
    {
        private BackgroundTaskDeferral serviceDeferral;
        VoiceCommandServiceConnection voiceServiceConnection;


        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            this.serviceDeferral = taskInstance.GetDeferral();

            taskInstance.Canceled += OnTaskCanceled;

            var triggerDetails = taskInstance.TriggerDetails as AppServiceTriggerDetails;

            if (triggerDetails != null &&
              triggerDetails.Name == "TalkToMeVoiceCommandService")
            {
                try
                {
                    voiceServiceConnection = VoiceCommandServiceConnection.FromAppServiceTriggerDetails(triggerDetails);
                    voiceServiceConnection.VoiceCommandCompleted += VoiceCommandCompleted;

                    VoiceCommand voiceCommand = await voiceServiceConnection.GetVoiceCommandAsync();

                    switch (voiceCommand.CommandName)
                    {
                        case "startMyPresentation":
                            ShowStartMyPresentation();
                            break;

                        case "endMyPresentation":
                            ShowEndMyPresentation();
                            break;

                        case "bankBalance":
                            SendCompletionMessageForBankAccount();
                            break;

                        case "whatDoYouThinkAbout":
                            var name = voiceCommand.Properties["name"][0];
                            SendCompletionMessageForName(name);
                            break;

                        case "birthday":
                            var birthdayName = voiceCommand.Properties["name"][0];
                            SingABirthdaySong(birthdayName);
                            break;

                        default:
                            LaunchAppInForeground();
                            break;
                    }
                }
                finally
                {
                    if (this.serviceDeferral != null)
                    {
                        //Complete the service deferral
                        this.serviceDeferral.Complete();
                    }
                }
            }

        }

        private async void ShowEndMyPresentation()
        {
            var userMessage = new VoiceCommandUserMessage();

            string message = "Oliver, du solltest langsam zum Schluß kommen. Die Zuschauer brauchen jetzt dringend eine Bio-Pause.";
            userMessage.SpokenMessage = message;
            userMessage.DisplayMessage = message;

            var response = VoiceCommandResponse.CreateResponse(userMessage);
            await voiceServiceConnection.ReportSuccessAsync(response);
        }

        private async void ShowStartMyPresentation()
        {
            var userMessage = new VoiceCommandUserMessage();

            string message = "Okay Oliver, ich starte deine Präsentation mit dem Namen Smart Life - Was bringt das Internet der Dinge?";
            userMessage.SpokenMessage = message;
            userMessage.DisplayMessage = message;

            var response = VoiceCommandResponse.CreateResponse(userMessage);
            await voiceServiceConnection.ReportSuccessAsync(response);
        }

        private async void SingABirthdaySong(string birthdayName)
        {
            var userMessage = new VoiceCommandUserMessage();

            userMessage.SpokenMessage = "Liebe " + birthdayName
                + ", Zum Geburtstag viel Glück! "
                + " Zum Geburtstag viel Glück!"
                + " Zum Geburtstag liebe " + birthdayName
                + " Zum Geburtstag viel Glück!";

            var response = VoiceCommandResponse.CreateResponse(userMessage);
            await voiceServiceConnection.ReportSuccessAsync(response);

        }

        private async void SendCompletionMessageForName(string name)
        {
            var userMessage = new VoiceCommandUserMessage();

            switch (name.ToLower())
            {
                case "dennis":
                    userMessage.DisplayMessage = "Das ist ein ziemlicher Vollpfosten.";
                    break;

                case "markus":
                    userMessage.DisplayMessage = "Der blöde Gladbach-Fan? Naja, Grammatik kann er.";
                    break;

                case "holzi":
                    userMessage.DisplayMessage = "Coole Sau.";
                    break;

                case "oliver":
                    userMessage.DisplayMessage = "Der Oliver? Der Oliver ist ein Programmiergott.";
                    break;

                case "marco":
                    userMessage.DisplayMessage = "Marco? Geiler Typ. Ist nur ein bisschen klein für sein Ego.";
                    break;

                case "robert":
                    userMessage.DisplayMessage = "Super Typ. Gehst am Samstag abend mit ihm Radeln.";
                    break;
            }

            userMessage.SpokenMessage = userMessage.DisplayMessage;

            var response = VoiceCommandResponse.CreateResponse(userMessage);
            await voiceServiceConnection.ReportSuccessAsync(response);

        }

        private void OnTaskCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
        }

        private void VoiceCommandCompleted(VoiceCommandServiceConnection sender, VoiceCommandCompletedEventArgs args)
        {
            if (this.serviceDeferral != null)
            {
                // Insert your code here
                //Complete the service deferral
                this.serviceDeferral.Complete();
            }
        }

        //private async void SendCompletionMessageForDestination(string destination)

        private async void SendCompletionMessageForBankAccount()
        {
            var userMessage = new VoiceCommandUserMessage();
            userMessage.DisplayMessage = "Du bist ziemlich pleite.";
            userMessage.SpokenMessage = "Das sieht gar nicht gut aus. Willst du mehr wissen?";

            //var taskTiles = new List<VoiceCommandContentTile>();

            //var taskTile = new VoiceCommandContentTile();
            //taskTile.ContentTileType = VoiceCommandContentTileType.TitleWith68x68IconAndText;
            //// The user can tap on the visual content to launch the app. 
            //// Pass in a launch argument to enable the app to deep link to a 
            //// page relevant to the item displayed on the content tile.
            ////taskTile.AppLaunchArgument = string.Format("action={0}", "Account");
            //taskTile.Title = "Ja";
            //taskTile.TextLine1 = "prüfen";
            //taskTiles.Add(taskTile);

            ////// Create the VoiceCommandResponse from the userMessage and list    
            ////// of content tiles.
            //var response = VoiceCommandResponse.CreateResponse(userMessage, taskTiles);

            ////// Cortana will present a “Go to app_name” link that the user 
            ////// can tap to launch the app. 
            ////// Pass in a launch to enable the app to deep link to a page 
            ////// relevant to the voice command.
            //////response.AppLaunchArgument = string.Format("action={0}", "Account");

            ////// Ask Cortana to display the user message and content tile and 
            ////// also speak the user message.
            //await voiceServiceConnection.ReportSuccessAsync(response);

            var response = VoiceCommandResponse.CreateResponse(userMessage);
            await voiceServiceConnection.ReportSuccessAsync(response);





            //// Take action and determine when the next trip to destination
            //// Inset code here

            //// Replace the hardcoded strings used here with strings 
            //// appropriate for your application.

            //// First, create the VoiceCommandUserMessage with the strings 
            //// that Cortana will show and speak.
            //var userMessage = new VoiceCommandUserMessage();
            //userMessage.DisplayMessage = "Here’s your trip.";
            //userMessage.SpokenMessage = "Your trip to Vegas is on August 3rd.";

            //// Optionally, present visual information about the answer.
            //// For this example, create a VoiceCommandContentTile with an 
            //// icon and a string.
            //var destinationsContentTiles = new List<VoiceCommandContentTile>();

            //var destinationTile = new VoiceCommandContentTile();
            //destinationTile.ContentTileType = VoiceCommandContentTileType.TitleWith68x68IconAndText;
            //// The user can tap on the visual content to launch the app. 
            //// Pass in a launch argument to enable the app to deep link to a 
            //// page relevant to the item displayed on the content tile.
            //destinationTile.AppLaunchArgument = string.Format("destination={0}”, “Las Vegas");
            //destinationTile.Title = "Las Vegas";
            //destinationTile.TextLine1 = "August 3rd 2015";
            //destinationsContentTiles.Add(destinationTile);

            //// Create the VoiceCommandResponse from the userMessage and list    
            //// of content tiles.
            //var response = VoiceCommandResponse.CreateResponse(userMessage, destinationsContentTiles);

            //// Cortana will present a “Go to app_name” link that the user 
            //// can tap to launch the app. 
            //// Pass in a launch to enable the app to deep link to a page 
            //// relevant to the voice command.
            //response.AppLaunchArgument = string.Format("destination={0}”, “Las Vegas");

            //// Ask Cortana to display the user message and content tile and 
            //// also speak the user message.
            //await voiceServiceConnection.ReportSuccessAsync(response);
        }

        private async void LaunchAppInForeground()
        {
            var userMessage = new VoiceCommandUserMessage();
            userMessage.SpokenMessage = "Launching Adventure Works";

            var response = VoiceCommandResponse.CreateResponse(userMessage);

            // When launching the app in the foreground, pass an app 
            // specific launch parameter to indicate what page to show.
            response.AppLaunchArgument = "showAllTrips=true";

            await voiceServiceConnection.RequestAppLaunchAsync(response);
        }
    }

}
