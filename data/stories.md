## happy path
* greet
  - utter_greet
* mood_great
  - utter_happy

## sad path 1
* greet
  - utter_greet
* mood_unhappy
  - utter_cheer_up
  - utter_did_that_help
* affirm
  - utter_happy

## sad path 2
* greet
  - utter_greet
* mood_unhappy
  - utter_cheer_up
  - utter_did_that_help
* deny
  - utter_goodbye

## say goodbye
* goodbye
  - utter_goodbye

## loop_enterproj
* intent_yes
  - action_enterproj_service
* enterproj_q1
  - action_enterproj_service_q1
  - action_viewagain



## enterproj_services_1
* greet
  - utter_greet
* enterproj_service
  - action_enterproj_service
* enterproj_q1
  - action_enterproj_service_q1
  - action_viewagain




## enterproj_services_2
* greet
  - utter_greet
* enterproj_service
  - action_enterproj_service
* enterproj_q1
  - action_enterproj_service_q1
  - action_viewagain
* intent_no
  - utter_goodbye