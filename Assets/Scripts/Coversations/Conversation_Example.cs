using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation_Example : Conversation_Main
{
    [SerializeField] List<string> messangersNames;
    [Space(20)]

    #region Story1
    [SerializeField] string[] story1; //Texts//
    [SerializeField] bool[] story1_sides; //true = left, false = right//
    [SerializeField] float[] delayBeforeAnotherMessage_1; //Leave 0 to default time//
    [Space(5)]

    #endregion Story1

    #region Story1_1
    [SerializeField] string[] story1_1; //Texts//
    [SerializeField] bool[] story1_1_sides; //true = left, false = right//
    [SerializeField] float[] delayBeforeAnotherMessage_1_1; //Leave 0 to default time//

    #endregion Sory1_1

    #region Decisons
    [Header("Decisions")]
    [SerializeField] string[] decision_1; //Id, Left, Right//

    #endregion Decision

    private void Awake()
    {
        SetConversationName_Start();
        Story_1();
    }

    #region Story 1
    void Story_1()
    {
        StartCoroutine("Story_1_Execution");
    }

    IEnumerator Story_1_Execution()
    {
        for (int i = 0; 4 > i; i++)
        {

            #region Delay Set
            float delay;

            if (delayBeforeAnotherMessage_1[i] == 0)
            {
                delay = defaultTimeBetweenNextMessage;
            }
            else
            {
                delay = delayBeforeAnotherMessage_1[i];
            }
            #endregion


            if (story1_sides[i] == true)
            {
                CreateLeftMessage(messangersNames[0], story1[i]);
            }
            else //When the other person//
            {
                CreateRightMessage(messangersNames[1], story1[i]);
            }

            yield return new WaitForSecondsRealtime(delay);
        }

        NewDecision(int.Parse(decision_1[0]), decision_1[1], decision_1[2], this.gameObject);

    }

    IEnumerator Story_1_f_Execution()
    {
        for (int i = 5; story1.Length > i; i++)
        {

            #region Delay Set
            float delay;

            if (delayBeforeAnotherMessage_1[i] == 0)
            {
                delay = defaultTimeBetweenNextMessage;
            }
            else
            {
                delay = delayBeforeAnotherMessage_1[i];
            }
            #endregion


            if (story1_sides[i] == true)
            {
                CreateLeftMessage(messangersNames[0], story1[i]);
            }
            else //When the other person//
            {
                CreateRightMessage(messangersNames[1], story1[i]);
            }

            yield return new WaitForSecondsRealtime(delay);
        }
    }


    #endregion Story 1

    #region Story 1_1
    void Story_1_1()
    {
        StartCoroutine("Story_1_1_Execution");
    }

    IEnumerator Story_1_1_Execution()
    {
        SetConversationName("AngryConversation.EXE");

        for (int i = 0; story1_1.Length > i; i++)
        {

            #region Delay Set
            float delay;

            if (delayBeforeAnotherMessage_1_1[i] == 0)
            {
                delay = defaultTimeBetweenNextMessage;
            }
            else
            {
                delay = delayBeforeAnotherMessage_1_1[i];
            }
            #endregion


            if (story1_1_sides[i] == true)
            {
                CreateLeftMessage(messangersNames[0], story1_1[i]);
            }
            else //When the other person//
            {
                CreateRightMessage(messangersNames[1], story1_1[i]);
            }

            yield return new WaitForSecondsRealtime(delay);
        }
    }

    #endregion Story 1_1

    public void DecisionSolver(int decisionID, bool decision)
    {
        switch (decisionID)
        {
            case 0: //When decision ID == 0//

                if (decision == true)
                {
                    StartCoroutine("Story_1_f_Execution");
                }
                else
                {
                    Story_1_1();
                }

                return;

            default:
                Debug.LogWarning("Something is wrong with 'DecisionSolver' ");
                return;
        }

    }

}
