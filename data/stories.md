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

## greeting
* greet
  - utter_greet

## enterproj_service_direct
* enterproj_service
  - action_enterproj_service

## enterproj_q1_direct
* enterproj_q1
  - action_enterproj_service_q1
  - action_viewagain

## enterproj_q2_direct
* enterproj_q2
  - action_enterproj_service_q2
  - action_viewagain

## enterproj_q3_direct
* enterproj_q3
  - action_enterproj_service_q3
  - action_viewagain

## enterproj_q4_direct
* enterproj_q4
  - action_enterproj_service_q4
  - action_viewagain


## loop_enterproj
* intent_yes
  - action_enterproj_service

## enterproj_services_1
* greet
  - utter_greet
* enterproj_service
  - action_enterproj_service


## no_story
* intent_no
  - utter_goodbye

