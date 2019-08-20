using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AdaptiveCards;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace projectbot.Bots
{
    public class MainBot:ActivityHandler
    {
        public static int count = 1;public static int count1 = 1;
        public static int count2 = 1;public static int count3 = 1;
        public static int flag = 0;
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            await processInput(turnContext);
            if (turnContext.Activity.Text != null)
            {
                if (turnContext.Activity.Text.Equals("Yes"))
                {
                    await adaptivecard(turnContext);
                    flag = 1;
                }
                if (turnContext.Activity.Text.Equals("No"))
                {
                    var reply = MessageFactory.Text("Thank you for using the bot.");
                    await turnContext.SendActivityAsync(reply);
                    flag = 1;
                }
            }
            if (flag == 0)
            { await yesorno(turnContext); }
            else
            {
                return;
            }


        }
     [Obsolete]
        private static async Task adaptivecard(ITurnContext turnContext)
        {
            var card = new AdaptiveCard();
            List<AdaptiveChoice> Choice = new List<AdaptiveChoice>();
            AdaptiveChoice c1 = new AdaptiveChoice()
            {
                Title="How to activate project in enterproj application",
                Value = "How to activate project in enterproj application"
            };
            AdaptiveChoice c2= new AdaptiveChoice()
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
            card.Body.Add(new AdaptiveChoiceSetInput() { Id = "query", Style = AdaptiveChoiceInputStyle.Compact, Choices=Choice });
            card.Actions.Add(new AdaptiveSubmitAction() {Title="Submit"});
            var returncard=new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                    Content=card
            };
            var reply = MessageFactory.Attachment(returncard);
            
            await turnContext.SendActivityAsync(reply);


        }
        private static async Task showHeroCard(ITurnContext turnContext)
        {
            List<CardAction> cardbuttons = new List<CardAction>();
            CardAction button1 = new CardAction()
            {
                Type="imBack",
                Title= "How to Activate a project in enterProj application?",
                Value="1"
            };
            CardAction button2 = new CardAction()
            {
                Type = "imBack",
                Title = "How to Add a Team member in a Project in the enterProj Application?" ,
                Value = "2"
            };
            CardAction button3 = new CardAction()
            {
                Type = "imBack",
                Title = "How to Assign Ownership in a Project in the enterProj Application?",
                Value = "3"
            };
            CardAction button4 = new CardAction()
            {
                Type = "imBack",
                Title = "How to EnterProj New Project Creation?",
                Value = "4"
            };
            cardbuttons.Add(button1);
            cardbuttons.Add(button2);
            cardbuttons.Add(button3);
            cardbuttons.Add(button4);
            HeroCard card = new HeroCard()
            {
                Title = "Welcome",
                Buttons = cardbuttons
                
            };
            var reply = MessageFactory.Attachment(card.ToAttachment());
            await turnContext.SendActivityAsync(reply);





        }
        private static async Task yesorno(ITurnContext turnContext)
        {
            List<CardAction> cardbuttons = new List<CardAction>();
            CardAction button1 = new CardAction()
            {
                Type = "imBack",
                Title = "Yes",
                Value = "Yes"
            };
            CardAction button2 = new CardAction()
            {
                Type = "imBack",
                Title = "No",
                Value = "No"
            };
            cardbuttons.Add(button1);
            cardbuttons.Add(button2);
            HeroCard card = new HeroCard()
            {
                Title = "Do you wish to  View the Menu?",
                Buttons = cardbuttons
            };
            var reply = MessageFactory.Attachment(card.ToAttachment());
            await turnContext.SendActivityAsync(reply);
        }
        private static async Task processInput(ITurnContext turnContext)
        {
            flag = 0;//flag for displaying yes or no crad
           // IMessageActivity reply;
            var msg = turnContext.Activity.Text;
             if (turnContext.Activity.Value != null)
            {
                var m = turnContext.Activity.Value.ToString();
                string []q=m.Split(":");
               //string t=q[1].Remove(q[1].Length - 1);
               // t=q[1].Remove(q[1].Length - 1);
               // t=q[1].Remove(0);
               for(int i=0;i<q[i].Length;i++)
                {
                    q[i] = q[i].Trim();
                }

                await turnContext.SendActivityAsync(q[1].ToString());
            }
           


            /*  if (msg != null)
              {
              if (msg.Equals("1"))
                  {
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
                      await turnContext.SendActivityAsync(reply1);
                      sb.Clear();
                      sb.AppendLine("In the left Menu, Click on My Worklist->My Project");
                      sb.AppendLine("In the right pane of the window there will be list of projects which you have created and you are assigned as a team member; click on the project which needs to be activated");
                      s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments.Clear();
                      reply.Attachments.Add(getImage());
                      await turnContext.SendActivityAsync(reply);
                      sb.Clear();
                      sb.AppendLine("You will find “Please contact Project Admin to get the Project activated.” on top of the page; click on Project Admin which will in turn open a new mail in outlook as shown below");
                      s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments.Clear();
                      reply.Attachments.Add(getImage());
                      await turnContext.SendActivityAsync(reply);
                      sb.Clear();
                      sb.AppendLine("Click on Send");
                      sb.AppendLine("The Project Admin will receive this email and will activate the project");
                      sb.AppendLine("If you have more questions, please refer the training document available in Hanon Portal");
                      sb.AppendLine("Hanon Portal->Workplace->HBOS & PDS->HPDS->HPDS Training->enterProj Training Material->Module_2: Project Tab");
                      s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments.Clear();
                      reply.Attachments.Add(getImage());
                      await turnContext.SendActivityAsync(reply);
                      sb.Clear();
                      sb.AppendLine("If you have any further clarifications, please submit an request in ServiceNow Portal https://hanon.service-now.com/");
                      s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      await turnContext.SendActivityAsync(reply);

                      reply.Attachments.Clear();
                      reply = MessageFactory.Text("Video Tutorial");
                      reply.Attachments.Add(getVid());
                      await turnContext.SendActivityAsync(reply);

                  }
                  else if (msg.Equals("2"))
                  {
                      Console.WriteLine("Inside msg 2 handler");
                      count1 = 1;
                      StringBuilder sb = new StringBuilder("Login to enterProj application through the portal (http://Portal.hanonsystems.com)");
                      sb.AppendLine("");
                      sb.AppendLine("1.Enter the CDS ID – User name & Password.");
                      sb.AppendLine("2.Click “Login” button.");
                      sb.AppendLine("3.Click the enterProj link under Application Menu and click the box “Project Portfolio Management/eFIN");
                      String s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments = new List<Attachment>() { getImageQ2() };
                      var reply1 = reply;
                      await turnContext.SendActivityAsync(reply1);
                      sb.Clear();
                      sb.AppendLine("In the left Menu, Click on Search and click on the type of project which you are looking for.");
                      sb.AppendLine("1. In the right pane of the window there will be a search page which will ask for a Project number. Enter the Project number and click on Search.");
                      s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments.Clear();
                      reply.Attachments.Add(getImageQ2());
                      await turnContext.SendActivityAsync(reply);
                      sb.Clear();
                      sb.AppendLine("2.The project will be displayed; click on the project number and click on the Team tab.");
                      sb.AppendLine("3.In the Team tab you will find a link ‘Add Team Member’ click on it");
                      s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments.Clear();
                      reply.Attachments.Add(getImageQ2());
                      await turnContext.SendActivityAsync(reply);
                      sb.Clear();
                      sb.AppendLine("4. Enter the user name and click the lookup and then click Add");
                      s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments.Clear();
                      reply.Attachments.Add(getImageQ2());
                      await turnContext.SendActivityAsync(reply);
                      sb.Clear();
                      sb.AppendLine("5.Now the Team member has been added in the project");
                      sb.AppendLine("If you have more questions, please refer the training document available in Hanon Portal");
                      sb.AppendLine("Hanon Portal->Workplace->HBOS & PDS->HPDS->HPDS Training->enterProj Training Material->Module_2: Project Tab");
                      s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments.Clear();
                      reply.Attachments.Add(getImageQ2());
                      await turnContext.SendActivityAsync(reply);
                      sb.Clear();
                      reply = MessageFactory.Text("If you have any further clarifications, please submit an request in ServiceNow Portal https://hanon.service-now.com/");
                      await turnContext.SendActivityAsync(reply);
                      reply.Attachments.Clear();
                      reply = MessageFactory.Text("Video Tutorial");
                      reply.Attachments.Add(getVid());
                      await turnContext.SendActivityAsync(reply);



                  }
                  else if (msg.Equals("3"))
                  {
                      count2 = 1;
                      StringBuilder sb = new StringBuilder("Login to enterProj application through the portal (http://Portal.hanonsystems.com)");
                      sb.AppendLine("");
                      sb.AppendLine("1.Enter the CDS ID – User name & Password.");
                      sb.AppendLine("2.Click “Login” button.");
                      sb.AppendLine("3.Click the enterProj link under Application Menu and click the box “Project Portfolio Management/eFIN");
                      String s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments = new List<Attachment>() { getImageQ3() };
                      await turnContext.SendActivityAsync(reply);
                      sb.Clear();
                      sb.AppendLine("In the left Menu, Click on Search and click on the type of project which you are looking for.");
                      sb.AppendLine("In the right pane of the window there will be a search page which will ask for a Project number.");
                      sb.Append("Enter the Project number and click on Search. ");
                      s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments.Clear();
                      reply.Attachments.Add(getImageQ3());
                      await turnContext.SendActivityAsync(reply);
                      sb.Clear();
                      sb.AppendLine("The project will be displayed; click on the project number and click on the Team tab.");
                      sb.AppendLine("In the Team tab you will find the list of team members and you can search the team member whom you are going to assign the ownership");
                      sb.AppendLine("Next to the member name you will find ‘Owner’ field where you can tick the checkbox corresponding to the team member.Click Save button.");
                      s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments.Clear();
                      reply.Attachments.Add(getImageQ3());
                      await turnContext.SendActivityAsync(reply);
                      sb.Clear();
                      sb.AppendLine("Now the Team member has been assigned as an Owner for that project.");
                      sb.AppendLine("If you have more questions, please refer the training document available in Hanon Portal");
                      sb.AppendLine("Hanon Portal->Workplace->HBOS & PDS->HPDS->HPDS Training->enterProj Training Material->Module_2: Project Tab");
                      s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments.Clear();
                      reply.Attachments.Add(getImageQ3());
                      await turnContext.SendActivityAsync(reply);
                      sb.Clear();
                      sb.AppendLine("If you have any further clarifications, please submit an request in ServiceNow Portal (https://hanon.service-now.com/)");
                      s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments.Clear();
                      await turnContext.SendActivityAsync(reply);
                      reply.Attachments.Clear();
                      reply = MessageFactory.Text("Video Tutorial");
                      reply.Attachments.Add(getVid());
                      await turnContext.SendActivityAsync(reply);

                  }
                  else if (msg.Equals("4"))
                  {
                      count3 = 1;
                      StringBuilder sb = new StringBuilder("Login to enterProj application through the portal (http://Portal.hanonsystems.com)");
                      sb.AppendLine("");
                      sb.AppendLine("1.Enter the CDS ID – User name & Password.");
                      sb.AppendLine("2.Click “Login” button.");
                      sb.AppendLine("3.Click the enterProj link under Application Menu and click the box “Project Portfolio Management/eFIN");
                      String s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments = new List<Attachment>() { getImageQ4() };
                      await turnContext.SendActivityAsync(reply);
                      sb.Clear();
                      sb.AppendLine("A new blank project screen will be displayed as shown");
                      s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments.Clear();
                      reply.Attachments.Add(getImageQ4());
                      await turnContext.SendActivityAsync(reply);
                      sb.Clear();
                      sb.AppendLine("If you have any further clarifications, please submit an request in ServiceNow Portal (https://hanon.service-now.com/)");
                      s1 = sb.ToString();
                      reply = MessageFactory.Text(s1);
                      reply.Attachments.Clear();
                      await turnContext.SendActivityAsync(reply);
                      reply.Attachments.Clear();
                      reply = MessageFactory.Text("Video Tutorial");
                      reply.Attachments.Add(getVid());
                      await turnContext.SendActivityAsync(reply);


                  }
              }
              else
              {

              }*/


        }
        private static Attachment getImage()
        {
            Attachment act = null; 
            if (count == 1)
            {
                var img1_path = Path.Combine(Environment.CurrentDirectory, @"Resources\MyProjects.png");
                var imageData = Convert.ToBase64String(File.ReadAllBytes(img1_path));
                 act=new Attachment()
                {
                    Name = @"Resources\MyProjects.png",
                    ContentType = "image/png",
                    ContentUrl = $"data:image/png;base64,{imageData}"
                };
            }
            else if(count ==2)
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

            count =count+1;
            return act;
        }
        private static Attachment getImageQ2()
        {
            Attachment act = null;
            if(count1==1)
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
            else if(count1==2)
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
            if(count2==1)
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
            if(count3==1)
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
            else if(count3==2)
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

    
