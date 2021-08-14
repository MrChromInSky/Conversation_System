using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Decision_Controller : MonoBehaviour
{ 

    [Header("Conversation Controller")]
    [SerializeField] GameObject conversationObject;
    [SerializeField] string conversationScriptName;

    [Header("ID")]
    public int decisionID;

    [Header("Buttons And texts")]
    public Button leftButton;
    public Button rightButton;
    [Space]
    [SerializeField] TextMeshProUGUI leftButtonText;
    [SerializeField] TextMeshProUGUI rightButtonText;

    void Awake()
    {
        leftButton.onClick.AddListener(LeftDecision);
        rightButton.onClick.AddListener(RightDecision);
    }

    public void OnStartDecision(int ID, string leftText, string rightText, GameObject conversation)
    {
        conversationObject = conversation;
        decisionID = ID;

        leftButtonText.SetText(leftText);
        rightButtonText.SetText(rightText);
    }


    void LeftDecision()
    {
        if(conversationObject.GetComponent<Conversation_Example>() != null) //If There is a component with that script//
        {
            conversationObject.GetComponent<Conversation_Example>().DecisionSolver(decisionID, true);
        }
        else if(conversationObject.GetComponent<Conversation_Jax>() != null) ///check for other scenario
        {
            conversationObject.GetComponent<Conversation_Jax>().DecisionSolver(decisionID, true);
        }

        Destroy(this.gameObject);
    }

    void RightDecision()
    {
        if (conversationObject.GetComponent<Conversation_Example>() != null) //If There is a component with that script//
        {
            conversationObject.GetComponent<Conversation_Example>().DecisionSolver(decisionID, false);
        }
        else if (conversationObject.GetComponent<Conversation_Jax>() != null) //check for other scenario
        {
            conversationObject.GetComponent<Conversation_Jax>().DecisionSolver(decisionID, false);
        }


        Destroy(this.gameObject);
    }



}
