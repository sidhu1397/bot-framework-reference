# This files contains your custom actions which can be used to run
# custom Python code.
#
# See this guide on how to implement these action:
# https://rasa.com/docs/rasa/core/actions/#custom-actions/


# This is a simple example for a custom action which utters "Hello World!"

# from typing import Any, Text, Dict, List
#
# from rasa_sdk import Action, Tracker
# from rasa_sdk.executor import CollectingDispatcher
#
#
# class ActionHelloWorld(Action):
#
#     def name(self) -> Text:
#         return "action_hello_world"
#
#     def run(self, dispatcher: CollectingDispatcher,
#             tracker: Tracker,
#             domain: Dict[Text, Any]) -> List[Dict[Text, Any]]:
#
#         dispatcher.utter_message("Hello World!")
#
#         return []

from typing import Any, Text, Dict, List

import json

from jsonpickle import json
from rasa_sdk import Action, Tracker
from rasa_sdk.executor import CollectingDispatcher
from sanic import request


class enterprojq1(Action):
    def name(self):
        return "action_enterproj_service_q1"

    def run(
            self,
            dispatcher,  # type: CollectingDispatcher
            tracker,  # type: Tracker
            domain,  # type:  Dict[Text, Any]
    ):  # type: (...) -> List[Dict[Text, Any]]

        print("-------------------payload from slack-------------------------------")
        print(tracker.latest_message["text"])
        print("-------------------payload from slack-------------------------------")

        s = """Login to enterProj application through the portal (https://Portal.hanonsystems.com)
                             Enter the CDS ID – User name & Password.
                             Click “Login” button.
                             Click the enterProj link under Application Menu and click the box “Project Portfolio Management/eFIN """
        dispatcher.utter_message(s)
        s = "https://rasabot.s3.us-east-2.amazonaws.com/PortaleProjLogin.jpg"
        dispatcher.utter_image_url(s)

        s = """In the left Menu, Click on My Worklist->My Projects In the right pane of the window there will be 
            list of projects which you have created and you are assigned as a team member; click on the project which 
            needs to be activated """
        dispatcher.utter_message(s)
        dispatcher.utter_image_url("https://rasabot.s3.us-east-2.amazonaws.com/MyProjects.jpg")
        s = """You will find “Please contact Project Admin to get the Project activated.” on top of the page; click 
            on Project Admin which will in turn open a new mail in outlook as shown below """
        dispatcher.utter_message(s)
        dispatcher.utter_image_url("https://rasabot.s3.us-east-2.amazonaws.com/ProjectActivation.jpg")
        s = """Click on Send
                   The Project Admin will receive this email and will activate the project
                   If you have more questions, please refer the training document available in Hanon Portal
                   Hanon Portal -> Workplace-> HBOS & PDS-> HPDS-> HPDS Training-> enterProj Training Material-> Module_2: Project Tab"""
        dispatcher.utter_message(s)
        dispatcher.utter_image_url("https://rasabot.s3.us-east-2.amazonaws.com/PortalTrainingPage.jpg")
        s = """If you have any further clarifications, please submit an request in ServiceNow Portal
                 https://hanon.service-now.com/"""
        dispatcher.utter_message(s)
        link = {

            "text": "https://rasabot.s3.us-east-2.amazonaws.com/Hanon.mp4"

        }
        dispatcher.utter_custom_json(link)

        return []


class enterprojq2(Action):
    def name(self):  # type: () -> Text
        return "action_enterproj_service_q2"

    def run(
            self,
            dispatcher,  # type: CollectingDispatcher
            tracker,  # type: Tracker
            domain,  # type:  Dict[Text, Any]
    ):  # type: (...) -> List[Dict[Text, Any]]
        s = """Login to enterProj application through the portal (https://Portal.hanonsystems.com)
                                    Enter the CDS ID – User name & Password.
                                    Click “Login” button.
                                    Click the enterProj link under Application Menu and click the box “Project Portfolio Management/eFIN """
        dispatcher.utter_message(s)
        s = "https://rasabot.s3.us-east-2.amazonaws.com/PortaleProjLogin.jpg"
        dispatcher.utter_image_url(s)
        s = """In the left Menu, Click on Search and click on the type of project which you are looking for. In the 
        right pane of the window there will be a search page which will ask for a Project number. Enter the Project 
        number and click on Search. """
        dispatcher.utter_message(s)
        dispatcher.utter_image_url("https://rasabot.s3.us-east-2.amazonaws.com/SearchProject.jpg")
        s = """The project will be displayed; click on the project number and click on the Team tab. 
               In the Team tab you will find a link ‘Add Team Member’ click on it"""
        dispatcher.utter_message(s)
        dispatcher.utter_image_url("https://rasabot.s3.us-east-2.amazonaws.com/AddTeamMember1.jpg")
        s = """Enter the user name and click the lookup and then click Add"""
        dispatcher.utter_message(s)
        dispatcher.utter_image_url("https://rasabot.s3.us-east-2.amazonaws.com/AddTeamMember2.jpg")
        s = """Now the Team member has been added in the project If you have more questions, please refer the 
        training document available in Hanon Portal Hanon Portal -> Workplace-> HBOS & PDS-> HPDS-> HPDS Training-> 
        enterProj Training Material-> Module_2: Project Tab """
        dispatcher.utter_message(s)
        dispatcher.utter_image_url("https://rasabot.s3.us-east-2.amazonaws.com/PortalTrainingPage.jpg")
        s = """If you have any further clarifications, please submit an request in ServiceNow Portal
                         https://hanon.service-now.com/"""
        dispatcher.utter_message(s)
        link = {

            "text": "https://rasabot.s3.us-east-2.amazonaws.com/Hanon.mp4"

        }
        dispatcher.utter_custom_json(link)

        return []


class enterprojq3(Action):
    def name(self):  # type: () -> Text
        return "action_enterproj_service_q3"

    def run(
            self,
            dispatcher,  # type: CollectingDispatcher
            tracker,  # type: Tracker
            domain,  # type:  Dict[Text, Any]
    ):  # type: (...) -> List[Dict[Text, Any]]
        s = """Login to enterProj application through the portal (https://Portal.hanonsystems.com)
                 Enter the CDS ID – User name & Password.
                 Click “Login” button.
                 Click the enterProj link under Application Menu and click the box “Project Portfolio Management/eFIN """
        dispatcher.utter_message(s)
        s = "https://rasabot.s3.us-east-2.amazonaws.com/PortaleProjLogin.jpg"
        dispatcher.utter_image_url(s)
        s = """In the left Menu, Click on Search and click on the type of project which you are looking for. 
               In the right pane of the window there will be a search page which will ask for a Project number. 
               Enter the Project number and click on Search."""
        dispatcher.utter_message(s)
        dispatcher.utter_image_url("https://rasabot.s3.us-east-2.amazonaws.com/SearchProject.jpg")
        s = """The project will be displayed; click on the project number and click on the Team tab. 
              In the Team tab you will find the list of team members and you can search the team member whom you are 
              going to assign the ownership
              Next to the member name you will find ‘Owner’ field where you can tick the checkbox corresponding to the 
              team member. Click Save button."""
        dispatcher.utter_message(s)
        dispatcher.utter_image_url("https://rasabot.s3.us-east-2.amazonaws.com/TeamMembersList.jpg")
        s = """Now the Team member has been assigned as an Owner for that project.
             If you have more questions, please refer the training document available in Hanon Portal
             Hanon Portal -> Workplace-> HBOS & PDS-> HPDS-> HPDS Training-> enterProj Training Material-> Module_2: Project Tab"""
        dispatcher.utter_image_url("https://rasabot.s3.us-east-2.amazonaws.com/PortalTrainingPage.jpg")
        s = """If you have any further clarifications, please submit an request in ServiceNow Portal
                                https://hanon.service-now.com/"""
        dispatcher.utter_message(s)
        link = {

            "text": "https://rasabot.s3.us-east-2.amazonaws.com/Hanon.mp4"

        }
        dispatcher.utter_custom_json(link)
        return []


class enterprojq4(Action):
    def name(self):  # type: () -> Text
        return "action_enterproj_service_q4"

    def run(
            self,
            dispatcher,  # type: CollectingDispatcher
            tracker,  # type: Tracker
            domain,  # type:  Dict[Text, Any]
    ):  # type: (...) -> List[Dict[Text, Any]]
        s = """Login to enterProj application through the portal (https://Portal.hanonsystems.com)
                 Enter the CDS ID – User name & Password.
                 Click “Login” button.
                 Click the enterProj link under Application Menu and click the box “Project Portfolio Management/eFIN """
        dispatcher.utter_message(s)
        s = "https://rasabot.s3.us-east-2.amazonaws.com/PortaleProjLogin.jpg"
        dispatcher.utter_image_url(s)
        dispatcher.utter_message("A new blank project screen will be displayed as shown")
        dispatcher.utter_image_url("https://rasabot.s3.us-east-2.amazonaws.com/BlankProject.jpg")
        s = """If you have any further clarifications, please submit an request in ServiceNow Portal
                                https://hanon.service-now.com/"""
        dispatcher.utter_message(s)
        return []


class mainmenu(Action):
    def name(self):  # type: () -> Text
        return "action_enterproj_service"

    def run(
            self,
            dispatcher,  # type: CollectingDispatcher
            tracker,  # type: Tracker
            domain,  # type:  Dict[Text, Any]
    ):  # type: (...) -> List[Dict[Text, Any]]
        # s = """I support the following enterproj services:
        #        1.How to activate project in enterproj application
        #        2.How to Add a team member in enterproj application
        #        3.How to assign ownership in enterproj application
        #        4.How to create new project in enterproj application"""
        # dispatcher.utter_message(s)
        # buttons = []
        # buttons.append({"title": "How to activate project in enterproj application", "payload": "/enterproj_q1"})
        # buttons.append({"title": "How to Add a team member in enterproj application", "payload": "/Add a team member"})
        # dispatcher.utter_button_message("I support the following enterproj services:", buttons)
        select_menu = {
            "text": "Welcome to enterproj serrivces",

            "attachments": [
                {
                    "text": "Choose an enterproj serice",
                    "fallback": "If you could read this message, you'd be choosing something fun to do right now.",
                    "color": "#3AA3E3",
                    "attachment_type": "default",
                    "callback_id": "enterproj_service_selection",
                    "actions": [
                        {
                            "name": "enterproj_list",
                            "text": "Pick an enteproj serice",
                            "type": "select",
                            "options": [
                                {
                                    "text": "Activate a project",
                                    "value": "activate a project in enterproj application"
                                },
                                {
                                    "text": "Add a team member",
                                    "value": "Add a team member in enterproj application"
                                },
                                {
                                    "text": "Assign ownership",
                                    "value": "Assign ownership in enter proj application"
                                },
                                {
                                    "text": "Create new project",
                                    "value": "Create new project in enterproj application"
                                }
                            ]
                        }
                    ]
                }
            ]
        }
        dispatcher.utter_custom_json(select_menu)

        return []


class yesorno(Action):
    def name(self):  # type: () -> Text
        return "action_viewagain"

    def run(
            self,
            dispatcher,  # type: CollectingDispatcher
            tracker,  # type: Tracker
            domain,  # type:  Dict[Text, Any]
    ):  # type: (...) -> List[Dict[Text, Any]]
        buttons = []
        buttons.append({"title": "Yes", "payload": "/intent_yes"})
        buttons.append({"title": "No", "payload": "/intent_no"})
        dispatcher.utter_button_message("Do you want to go back enterproj menu?", buttons, button_type="custom")

        return []
