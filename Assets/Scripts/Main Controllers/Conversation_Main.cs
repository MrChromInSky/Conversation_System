using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Conversation_Main : MonoBehaviour
{
    #region Variables
    [Header("Conversation UI")]
    public GameObject conversationObject; //Object of particular conversation//
    [Space]
    [SerializeField] GameObject messageWindow; //Window with messages//
    [SerializeField] ScrollRect messageScrollRect; //For scrolling down to new message//

    [Header("Conversation Name")]
    [SerializeField] TextMeshProUGUI conversationName;
    [SerializeField] float timeBeforeChangeConversationName;
    [SerializeField] string actualConversationName;
    [Space]

    [Header("Message Objects")]
    [SerializeField] GameObject leftMessage;
    [SerializeField] GameObject rightMessage;

    [Header("Decision making Objects")]
    [SerializeField] GameObject decisionWindow;
    [SerializeField] GameObject decisionObject;

    [Header("Message Properties")]
    public float defaultTimeBetweenNextMessage;


    #endregion Variables

    private void Awake()
    {
        conversationObject = this.gameObject; //Auto set gameobject connected with script//
    }

    #region Functions

    #region Conversation Name
    //Set name on start//
    public void SetConversationName_Start()
    {
        conversationName.SetText(actualConversationName);
    }

    //Set New Name//
    public void SetConversationName(string newConversationName)
    {
        StartCoroutine("SetNewConversationName", newConversationName);

    }

    IEnumerator SetNewConversationName(string newConversationName)
    {
        actualConversationName = newConversationName; //Setup new name//       
        conversationName.SetText("-----"); //Time placeholder
        yield return new WaitForSeconds(timeBeforeChangeConversationName); //Wait time
        conversationName.SetText(actualConversationName);//Set final name//
    }

    #endregion Conversation Name

    #region Create New Message
    public void CreateLeftMessage(string author, string message, float delay = 2)//Default Delay is 2, you can overwrite it by function//
    {
        GameObject LeftMessage = Instantiate(leftMessage, Vector2.zero, Quaternion.identity) as GameObject; //Create new gameobject
        LeftMessage.transform.SetParent(messageWindow.transform, false); // Set Parent for new gameobject
        LeftMessage.GetComponent<RectTransform>().pivot = new Vector2(0, 1); //For any case set pivot to left-up

        LeftMessage.GetComponent<Message_Controller>().UpdateTexts(author, message, delay); //Updates Texts//

        //Scroll Down//
        ScrollDown();
    }

    public void CreateRightMessage(string author, string message, float delay = 2) //Default Delay is 2, you can overwrite it by function//
    {
        GameObject RightMessage = Instantiate(rightMessage, Vector2.zero, Quaternion.identity) as GameObject; //Create new gameobject
        RightMessage.transform.SetParent(messageWindow.transform, false); // Set Parent for new gameobject
        RightMessage.GetComponent<RectTransform>().pivot = new Vector2(0, 1); //For any case set pivot to left-up

        RightMessage.GetComponent<Message_Controller>().UpdateTexts(author, message, delay); //Updates Texts//

        //Scroll Down//
        ScrollDown();
    }

    #endregion Create New Message

    #region Decision
    public void NewDecision(int decisionID, string leftDecision, string rightDecision, GameObject conversationObject)
    {
        //Creating New Decision window//
        GameObject DecisionWindow = Instantiate(decisionObject, Vector2.zero, Quaternion.identity) as GameObject;
        DecisionWindow.transform.SetParent(decisionWindow.transform, false); // Set Parent for new gameobject
        DecisionWindow.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);


        //Setting Text's to buttons//
        DecisionWindow.GetComponent<Decision_Controller>().OnStartDecision(decisionID, leftDecision, rightDecision, conversationObject);



    }

    #endregion Decision

    public void ScrollDown()
    {
        Canvas.ForceUpdateCanvases();
        messageScrollRect.verticalNormalizedPosition = 0;
    }

    #endregion Functions
}
