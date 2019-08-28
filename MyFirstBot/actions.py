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


class enterprojq1(Action):
    def name(self):
        return "action_enterproj_service_q1"

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
        s = "https://rasa.com/static/facebook-og-06cd09bc2e9b9a2c2b0bbc1ee3dfad8f.png"
        dispatcher.utter_image_url(s)
        message = {
            "type": "video",
            "title": "https://www.youtube.com/watch?v=f3EbDbm8XqY",
            "url": "https://www.youtube.com/watch?v=f3EbDbm8XqY"
        }



        dispatcher.utter_attachment(message)
        message1 = {
            "attachment": {
                "type": "video",
                "payload": {
                    "url": "https://www.youtube.com/watch?v=f3EbDbm8XqY",

                }
            }
        }
        dispatcher.utter_custom_json(message1)
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
        s = """I support the following enterproj services:
               1.How to activate project in enterproj application
               2.How to Add a team member in enterproj application
               3.How to assign ownership in enterproj application
               4.How to create new project in enterproj application"""
        dispatcher.utter_message(s)
        buttons = []
        buttons.append({"title": "How to activate project in enterproj application", "payload": "/enterproj_q1"})
        buttons.append({"title": "How to Add a team member in enterproj application", "payload": "/Add a team member"})
        dispatcher.utter_button_message("I support the following enterproj services:", buttons)

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
        dispatcher.utter_button_message("Do you want to go back enterproj menu?", buttons)

        return []
