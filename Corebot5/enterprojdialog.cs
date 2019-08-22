using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AdaptiveCards;
using CoreBot5.CognitiveModels;
using Luis;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using Microsoft.Recognizers.Text.DataTypes.TimexExpression;
using Newtonsoft.Json;

namespace CoreBot5.Dialogs
{
    public class enterprojdialog:ComponentDialog
    {
        private readonly mainmenurecognizer _luisRecognizer1;
        protected readonly ILogger Logger;

         public static int count = 1; public static int count1 = 1;
        public static int count2 = 1; public static int count3 = 1;

        // Dependency injection uses this constructor to instantiate MainDialog
        [Obsolete]
        public enterprojdialog(mainmenurecognizer luisRecognizer)
            : base(nameof(enterprojdialog))
        {
           _luisRecognizer1 = luisRecognizer;
            //Logger = logger;

            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new ConfirmPrompt(nameof(ConfirmPrompt)));

            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                FirstStepAsync,
              
                ProcessStepAsync,
                EndStepAsync,
            }));

            // The initial child Dialog to run.
            InitialDialogId = nameof(WaterfallDialog);
        }

       

        [Obsolete]
        private async Task<DialogTurnResult> FirstStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            await adaptivecard(stepContext.Context);

            //handling result from adaptive card
            var opts = new PromptOptions
            {
                Prompt = new Activity
                {
                    
                    Type = ActivityTypes.Message,
                    //Text = "waiting for user input...", // You can comment this out if you don't want to display any text. Still works.
                }
            };

            
            return await stepContext.PromptAsync(nameof(TextPrompt), opts,cancellationToken);
        }
        private async Task<DialogTurnResult> ProcessStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var luisResult = await _luisRecognizer1.RecognizeAsync<mainmenu>(stepContext.Context, cancellationToken);
            switch(luisResult.TopIntent().intent)
            {
                case mainmenu.Intent.activate:
                    IMessageActivity reply = null;
                    count = 1;
                    StringBuilder sb = new StringBuilder("Login to enterProj application through the portal (http://Portal.hanonsystems.com)");
                    sb.AppendLine("");
                    sb.AppendLine("Enter the CDS ID – User name & Password.");
                    sb.AppendLine("Click “Login” button.");
                    sb.AppendLine(" Click the enterProj link under Application Menu and click the box “Project Portfolio Management/eFIN");
                    String s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments = new List<Attachment>() { getImage() };
                    var reply1 = reply;
                    await stepContext.Context.SendActivityAsync(reply1);
                    sb.Clear();
                    sb.AppendLine("In the left Menu, Click on My Worklist->My Project");
                    sb.AppendLine("In the right pane of the window there will be list of projects which you have created and you are assigned as a team member; click on the project which needs to be activated");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments.Clear();
                    reply.Attachments.Add(getImage());
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();
                    sb.AppendLine("You will find “Please contact Project Admin to get the Project activated.” on top of the page; click on Project Admin which will in turn open a new mail in outlook as shown below");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments.Clear();
                    reply.Attachments.Add(getImage());
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();
                    sb.AppendLine("Click on Send");
                    sb.AppendLine("The Project Admin will receive this email and will activate the project");
                    sb.AppendLine("If you have more questions, please refer the training document available in Hanon Portal");
                    sb.AppendLine("Hanon Portal->Workplace->HBOS & PDS->HPDS->HPDS Training->enterProj Training Material->Module_2: Project Tab");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments.Clear();
                    reply.Attachments.Add(getImage());
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();
                    sb.AppendLine("If you have any further clarifications, please submit an request in ServiceNow Portal https://hanon.service-now.com/");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    await stepContext.Context.SendActivityAsync(reply);

                    reply.Attachments.Clear();
                    reply = MessageFactory.Text("Video Tutorial");
                    reply.Attachments.Add(getVid());
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();
                    break;
                case mainmenu.Intent.Add_a_team_member:
                    count1 = 1;

                    sb = new StringBuilder("Login to enterProj application through the portal (http://Portal.hanonsystems.com)");
                    sb.AppendLine("");
                    sb.AppendLine("1.Enter the CDS ID – User name & Password.");
                    sb.AppendLine("2.Click “Login” button.");
                    sb.AppendLine("3.Click the enterProj link under Application Menu and click the box “Project Portfolio Management/eFIN");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments = new List<Attachment>() { getImageQ2() };
                    reply1 = reply;
                    await stepContext.Context.SendActivityAsync(reply1);
                    sb.Clear();
                    sb.AppendLine("In the left Menu, Click on Search and click on the type of project which you are looking for.");
                    sb.AppendLine("1. In the right pane of the window there will be a search page which will ask for a Project number. Enter the Project number and click on Search.");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments.Clear();
                    reply.Attachments.Add(getImageQ2());
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();
                    sb.AppendLine("2.The project will be displayed; click on the project number and click on the Team tab.");
                    sb.AppendLine("3.In the Team tab you will find a link ‘Add Team Member’ click on it");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments.Clear();
                    reply.Attachments.Add(getImageQ2());
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();
                    sb.AppendLine("4. Enter the user name and click the lookup and then click Add");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments.Clear();
                    reply.Attachments.Add(getImageQ2());
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();
                    sb.AppendLine("5.Now the Team member has been added in the project");
                    sb.AppendLine("If you have more questions, please refer the training document available in Hanon Portal");
                    sb.AppendLine("Hanon Portal->Workplace->HBOS & PDS->HPDS->HPDS Training->enterProj Training Material->Module_2: Project Tab");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments.Clear();
                    reply.Attachments.Add(getImageQ2());
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();
                    reply = MessageFactory.Text("If you have any further clarifications, please submit an request in ServiceNow Portal https://hanon.service-now.com/");
                    await stepContext.Context.SendActivityAsync(reply);
                    reply.Attachments.Clear();
                    reply = MessageFactory.Text("Video Tutorial");
                    reply.Attachments.Add(getVid());
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();

                    break;
                case mainmenu.Intent.Assign_Ownership:
                    count2 = 1;
                    sb = new StringBuilder("Login to enterProj application through the portal (http://Portal.hanonsystems.com)");
                    sb.AppendLine("");
                    sb.AppendLine("1.Enter the CDS ID – User name & Password.");
                    sb.AppendLine("2.Click “Login” button.");
                    sb.AppendLine("3.Click the enterProj link under Application Menu and click the box “Project Portfolio Management/eFIN");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments = new List<Attachment>() { getImageQ3() };
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();
                    sb.AppendLine("In the left Menu, Click on Search and click on the type of project which you are looking for.");
                    sb.AppendLine("In the right pane of the window there will be a search page which will ask for a Project number.");
                    sb.Append("Enter the Project number and click on Search. ");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments.Clear();
                    reply.Attachments.Add(getImageQ3());
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();
                    sb.AppendLine("The project will be displayed; click on the project number and click on the Team tab.");
                    sb.AppendLine("In the Team tab you will find the list of team members and you can search the team member whom you are going to assign the ownership");
                    sb.AppendLine("Next to the member name you will find ‘Owner’ field where you can tick the checkbox corresponding to the team member.Click Save button.");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments.Clear();
                    reply.Attachments.Add(getImageQ3());
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();
                    sb.AppendLine("Now the Team member has been assigned as an Owner for that project.");
                    sb.AppendLine("If you have more questions, please refer the training document available in Hanon Portal");
                    sb.AppendLine("Hanon Portal->Workplace->HBOS & PDS->HPDS->HPDS Training->enterProj Training Material->Module_2: Project Tab");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments.Clear();
                    reply.Attachments.Add(getImageQ3());
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();
                    sb.AppendLine("If you have any further clarifications, please submit an request in ServiceNow Portal (https://hanon.service-now.com/)");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments.Clear();
                    await stepContext.Context.SendActivityAsync(reply);
                    reply.Attachments.Clear();
                    reply = MessageFactory.Text("Video Tutorial");
                    reply.Attachments.Add(getVid());
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();

                    break;
                case mainmenu.Intent.New_Project_Creation:
                    count3 = 1;
                    sb = new StringBuilder("Login to enterProj application through the portal (http://Portal.hanonsystems.com)");
                    sb.AppendLine("");
                    sb.AppendLine("1.Enter the CDS ID – User name & Password.");
                    sb.AppendLine("2.Click “Login” button.");
                    sb.AppendLine("3.Click the enterProj link under Application Menu and click the box “Project Portfolio Management/eFIN");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments = new List<Attachment>() { getImageQ4() };
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();
                    sb.AppendLine("A new blank project screen will be displayed as shown");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments.Clear();
                    reply.Attachments.Add(getImageQ4());
                    await stepContext.Context.SendActivityAsync(reply);
                    sb.Clear();
                    sb.AppendLine("If you have any further clarifications, please submit an request in ServiceNow Portal (https://hanon.service-now.com/)");
                    s1 = sb.ToString();
                    reply = MessageFactory.Text(s1);
                    reply.Attachments.Clear();
                    await stepContext.Context.SendActivityAsync(reply);
                    reply.Attachments.Clear();
                    reply = MessageFactory.Text("Video Tutorial");
                    reply.Attachments.Add(getVid());
                    await stepContext.Context.SendActivityAsync(reply);
                    break;
                case mainmenu.Intent.None:
                    var didntUnderstandMessageText = $"Sorry, I didn't get that. Please try asking in a different way (intent was {luisResult.TopIntent().intent})";
                    var didntUnderstandMessage = MessageFactory.Text(didntUnderstandMessageText, didntUnderstandMessageText, InputHints.IgnoringInput);
                    await stepContext.Context.SendActivityAsync(didntUnderstandMessage, cancellationToken);
                    break;

               
                    
                
            }
            var messageText = $"Do you wish go back to enterproj menu?";
            var promptMessage = MessageFactory.Text(messageText, messageText, InputHints.ExpectingInput);

            return await stepContext.PromptAsync(nameof(ConfirmPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
        }

        private async Task<DialogTurnResult> EndStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var msg = stepContext.Context.Activity.Text;
            if (string.Equals(msg, "yes",StringComparison.CurrentCultureIgnoreCase))
            {
                return await stepContext.ReplaceDialogAsync(nameof(enterprojdialog), null, cancellationToken);
            }
            if(string.Equals(msg,"no",StringComparison.CurrentCultureIgnoreCase))
            {
                return await stepContext.EndDialogAsync(null, cancellationToken);
            }
            return await stepContext.EndDialogAsync(null, cancellationToken);
        }
        [Obsolete]
        private static async Task adaptivecard(ITurnContext turnContext)
        {
            var card = new AdaptiveCard();
            List<AdaptiveChoice> Choice = new List<AdaptiveChoice>();
            AdaptiveChoice c1 = new AdaptiveChoice()
            {
                Title = "How to activate project in enterproj application",
                Value = "How to activate project in enterproj application"
            };
            AdaptiveChoice c2 = new AdaptiveChoice()
            {
                Title = "How to Add a team member in enterproj application",
                Value = "How to Add a team member in enterproj application"
            };
            AdaptiveChoice c3 = new AdaptiveChoice()
            {
                Title = "How to assign ownership in enterproj application",
                Value = "How to assign ownership in enterproj application"
            };
            AdaptiveChoice c4 = new AdaptiveChoice()
            {
                Title = "How to create new project in enterproj application",
                Value = "How to create new project in enterproj application"

            };
            Choice.Add(c1); Choice.Add(c2); Choice.Add(c3); Choice.Add(c4);

            card.Body.Add(new AdaptiveTextBlock() { Text = "Select an enterproj query", Size = AdaptiveTextSize.Medium, Weight = AdaptiveTextWeight.Bolder });
            card.Body.Add(new AdaptiveChoiceSetInput() { Id = "query", Style = AdaptiveChoiceInputStyle.Compact, Choices = Choice });
            card.Actions.Add(new AdaptiveSubmitAction() { Title = "Submit" });
            var returncard = new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
            var reply = MessageFactory.Attachment(returncard);

            await turnContext.SendActivityAsync(reply);


        }
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
