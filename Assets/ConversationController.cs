using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ConversationController : MonoBehaviour
{
    [Header("Message Container")]
    public GameObject messageContainer;

    [SerializeField] ScrollRect sRect; //Object with scrollrect over our conversation//

    [Header("Conversation Name")]
    public string conversationName;
    [SerializeField] TextMeshProUGUI conversationName_Text;

    [Header("Message Objects")]
    [SerializeField] GameObject leftMessage;
    [Space]
    [SerializeField] GameObject rightMessage;

    [Header("Messengers")]
    [SerializeField] string[] messengerNames = new string[] { "DavidIsKoX1234", "Alexxx" };


    [Header("Messeges")]
    [SerializeField] string[] messegesTexts;
    [SerializeField] int actualMessageState;
    [SerializeField] bool[] whosMessage; //True = left, False = Right//

    private void OnEnable()
    {
        conversationName_Text.SetText(conversationName);
        StartCoroutine("TestDialogue");
    }

    IEnumerator TestDialogue()
    {
        yield return new WaitForSecondsRealtime(1f);
        CreateRight("Have you used up all our tactical toilet paper supply!", messengerNames[0]);
        sRect.verticalNormalizedPosition = 0;
        yield return new WaitForSecondsRealtime(3f);
        CreateLeft("No I DIDNT!!!", messengerNames[1]);
        sRect.verticalNormalizedPosition = 0;
        yield return new WaitForSecondsRealtime(3f);
        CreateRight("Then who the hell did, you're the only person besides me who had access to it.", messengerNames[0]);
        sRect.verticalNormalizedPosition = 0;
        yield return new WaitForSecondsRealtime(2f);

        for(int actualMessage = 0; actualMessage < messegesTexts.Length; actualMessage++)
        {
            actualMessageState++;

            if(whosMessage[actualMessage] == true)
            {
                CreateLeft(messegesTexts[actualMessage], messengerNames[1]);
            }
            else //When the other person//
            {
                CreateRight(messegesTexts[actualMessage], messengerNames[0]);
            }

            yield return new WaitForSecondsRealtime(2f);
        }
        
    }

    void CreateLeft(string text, string user)
    {
        GameObject NewLeftMessage = Instantiate(leftMessage, Vector2.zero, Quaternion.identity) as GameObject;
        NewLeftMessage.transform.SetParent(messageContainer.transform, false);
        NewLeftMessage.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
        //  NewLeftMessage.GetComponent<MessageStart>().message = "Stakataka";

        NewLeftMessage.GetComponent<MessageStart>().UpdateTexts(text, user);
        
        Canvas.ForceUpdateCanvases();
        sRect.verticalNormalizedPosition = 0;
    }

    void CreateRight(string text, string user)
    {
        GameObject NewLeftMessage = Instantiate(rightMessage, Vector2.zero, Quaternion.identity) as GameObject;
        NewLeftMessage.transform.SetParent(messageContainer.transform, false);
        NewLeftMessage.GetComponent<RectTransform>().pivot = new Vector2(1, 1);


        NewLeftMessage.GetComponent<MessageStart>().UpdateTexts(text, user);
        
        Canvas.ForceUpdateCanvases();
        sRect.verticalNormalizedPosition = 0;
    }


}
