using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Message_Controller : MonoBehaviour
{
    #region Variables
    [Header("Text Fields")]
    [SerializeField] TextMeshProUGUI authorsName;
    [SerializeField] TextMeshProUGUI messageText;

    [Header("Message Delays")]
    float delayBeforeMessage;
 
    #endregion Variables

    public void UpdateTexts(string author, string message, float delay) //Default Delay is 2, you can overwrite it by function//
    {
        delayBeforeMessage = delay; //Updates Delay Before Message//

        authorsName.SetText(author);
        StartCoroutine("messageDelay", message);
    }

    IEnumerator messageDelay(string message)
    {
        #region Dot animation
        messageText.SetText(".");
        yield return new WaitForSeconds(0.2f);
        messageText.SetText("..");
        yield return new WaitForSeconds(0.2f);
        messageText.SetText("...");
        yield return new WaitForSeconds(delayBeforeMessage);
        #endregion Dot animation

        messageText.SetText(message);
    }
}
