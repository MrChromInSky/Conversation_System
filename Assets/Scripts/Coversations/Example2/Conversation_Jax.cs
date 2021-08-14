using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation_Jax : Conversation_Main
{
    [SerializeField] List<string> messangersNames;
    [Space(20)]

    #region Story1 - Hello
    [SerializeField] string[] story1; //Texts//
    [SerializeField] bool[] story1_sides; //true = left, false = right//
    [SerializeField] float[] delayBeforeAnotherMessage_1; //Leave 0 to default time//
    [Space(5)]
    #endregion Story1

    #region Decisons
    [Header("Decisions")]
    [SerializeField] string[] decision_1; //Id, Left, Right//
    #endregion Decision

    private void Awake()
    {
        SetConversationName_Start();
        StoryStart();
    }

    #region Part 1
    void StoryStart()
    {
        StartCoroutine("Story1");
    }

    IEnumerator Story1()
    {
        for (int i = 0; 3 > i; i++)
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

    IEnumerator Story1_1()
    {
        for (int i = 4; 7 > i; i++)
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

    IEnumerator Story1_d1()
    {
        for (int i = 7; story1.Length > i; i++)
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
    #endregion


    public void DecisionSolver(int decisionID, bool decision)
    {
        switch (decisionID)
        {
            case 0: //When decision ID == 0//

                if (decision == true)
                {
                    StopAllCoroutines();
                    StartCoroutine("Story1_1");
                }
                else
                {
                    StopAllCoroutines();
                    StartCoroutine("Story1_d1");
                }

                return;

            default:
                Debug.LogWarning("Something is wrong with 'DecisionSolver' ");
                return;
        }
    }
}
