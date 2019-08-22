using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoreBot5.CognitiveModels;
using Luis;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using Microsoft.Recognizers.Text.DataTypes.TimexExpression;

namespace CoreBot5.Dialogs
{
    public class mydialog:ComponentDialog
    {
        private readonly mainmenurecognizer _luisRecognizer;
        protected readonly ILogger Logger;
        public static int count = 1; public static int count1 = 1;
        public static int count2 = 1; public static int count3 = 1;

        // Dependency injection uses this constructor to instantiate MainDialog
        [Obsolete]
        public mydialog(mainmenurecognizer luisRecognizer, ILogger<mydialog> logger)
            : base(nameof(mydialog))
        {
            _luisRecognizer = luisRecognizer;
            Logger = logger;

            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new enterprojdialog(_luisRecognizer));
            
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                FirstStepAsync,
                ProcessStepAsync,
                EndStepAsync,
            }));

            // The initial child Dialog to run.
            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> EndStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("What else can i do for you?");
            return await stepContext.ReplaceDialogAsync(InitialDialogId,cancellationToken);
        }

        private async Task<DialogTurnResult> ProcessStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            //var luisResult = await _luisRecognizer.RecognizeAsync<mainmenu>(stepContext.Context, cancellationToken);
            Logger.LogInformation("Running dialog with Message Activity.");
            var msg = stepContext.Context.Activity.Text;

            switch (msg)
            {
                case "enterproj":
                   return await stepContext.BeginDialogAsync(nameof(enterprojdialog), null, cancellationToken);

                default:
                    await stepContext.Context.SendActivityAsync(MessageFactory.Text("Sorry please provide correct input"));
                    break;

                   
               

            }
            return await stepContext.NextAsync(null, cancellationToken);
        }

        private async Task<DialogTurnResult> FirstStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            if (!_luisRecognizer.IsConfigured)
            {
                await stepContext.Context.SendActivityAsync(
                    MessageFactory.Text("NOTE: LUIS is not configured. To enable all capabilities, add 'LuisAppId', 'LuisAPIKey' and 'LuisAPIHostName' to the appsettings.json file.", inputHint: InputHints.IgnoringInput), cancellationToken);

                return await stepContext.NextAsync(null, cancellationToken);
            }

            // Use the text provided in FinalStepAsync or the default if it is the first time.
            StringBuilder sb = new StringBuilder("I support the following queries:");
            sb.AppendLine("");
            sb.AppendLine("Enterproj");
            sb.AppendLine("VSS");
            sb.AppendLine("G-File");


            var promptMessage = MessageFactory.Text(sb.ToString(), sb.ToString(), InputHints.ExpectingInput);
            return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
        }
        //question 1 mage function
        private static Attachment getImage()
        {
            Attachment act = null;
            if (count == 1)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\MyProjects.png");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\MyProjects.png",
                    ContentType = "image/png",
                    ContentUrl = $"data:image/png;base64,{imageData}"
                };
            }
            else if (count == 2)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\PortaleProjLogin.jfif");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\PortaleProjLogin.jfif",
                    ContentType = "image/jfif",
                    ContentUrl = $"data:image/jfif;base64,{imageData}"
                };

            }
            else if (count == 3)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\PortalTrainingPage.jfif");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\PortalTrainingPage.jfif",
                    ContentType = "image/jfif",
                    ContentUrl = $"data:image/jfif;base64,{imageData}"
                };

            }
            else if (count == 4)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\ProjectActivation.jfif");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\ProjectActivation.jfif",
                    ContentType = "image/jfif",
                    ContentUrl = $"data:image/jfif;base64,{imageData}"
                };

            }

            count = count + 1;
            return act;
        }
        private static Attachment getImageQ2()
        {
            Attachment act = null;
            if (count1 == 1)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\PortaleProjLogin1.jfif");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\PortaleProjLogin1.jfif",
                    ContentType = "image/jfif",
                    ContentUrl = $"data:image/jfif;base64,{imageData}"
                };

            }
            else if (count1 == 2)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\SearchProject.jpg");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\SearchProject.jpg",
                    ContentType = "image/jpg",
                    ContentUrl = $"data:image/jpg;base64,{imageData}"
                };

            }
            else if (count1 == 3)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\AddTeamMember1.jfif");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\AddTeamMember1.jfif",
                    ContentType = "image/jfif",
                    ContentUrl = $"data:image/jfif;base64,{imageData}"
                };

            }
            else if (count1 == 4)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\AddTeamMember2.jfif");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\AddTeamMember2.jfif",
                    ContentType = "image/jfif",
                    ContentUrl = $"data:image/jfif;base64,{imageData}"
                };

            }
            else if (count1 == 5)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\PortalTrainingPage.jfif");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\PortalTrainingPage.jfif",
                    ContentType = "image/jfif",
                    ContentUrl = $"data:image/jfif;base64,{imageData}"
                };

            }
            count1 = count1 + 1;
            return act;
        }
        private static Attachment getImageQ3()
        {
            Attachment act = null;
            if (count2 == 1)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\PortaleProjLogin.jfif");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\PortalProjLogin.jfif",
                    ContentType = "image/jfif",
                    ContentUrl = $"data:image/jfif;base64,{imageData}"
                };

            }
            else if (count2 == 2)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\SearchProject.jpg");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\SearchProject.jpg",
                    ContentType = "image/jpg",
                    ContentUrl = $"data:image/jpg;base64,{imageData}"
                };

            }
            else if (count2 == 3)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\TeamMembersList.jfif");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\TeamMembersList.jfif",
                    ContentType = "image/jfif",
                    ContentUrl = $"data:image/jfif;base64,{imageData}"
                };

            }
            else if (count2 == 4)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\PortalTrainingPage.jfif");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\PortalTrainingPage.jfif",
                    ContentType = "image/jfif",
                    ContentUrl = $"data:image/jfif;base64,{imageData}"
                };

            }
            count2 = count2 + 1;
            return act;

        }
        private static Attachment getImageQ4()
        {
            Attachment act = null;
            if (count3 == 1)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\PortaleProjLogin.jfif");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\PortalProjLogin.jfif",
                    ContentType = "image/jfif",
                    ContentUrl = $"data:image/jfif;base64,{imageData}"
                };
            }
            else if (count3 == 2)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\BlankProject.jfif");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                act = new Attachment()
                {
                    Name = @"Resources\BlankProject.jfif",
                    ContentType = "image/jfif",
                    ContentUrl = $"data:image/jfif;base64,{imageData}"
                };

            }
            count3 = count3 + 1;
            return act;
        }
        private static Attachment getVid()
        {
            var vidpath = Path.Combine(Environment.CurrentDirectory, @"Resources\Hanon.mp4");
            // var vidData = Convert.ToBase64String(File.ReadAllBytes(vidpath));
            return new Attachment
            {
                Name = @"Resources\Hanon.mp4",
                ContentType = "video/mp4",
                ContentUrl = vidpath

            };
        }
    }
}
