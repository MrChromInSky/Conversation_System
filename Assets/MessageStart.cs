using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageStart : MonoBehaviour
{
    #region Variables
    [Header("Text fields")]
    [SerializeField] TextMeshProUGUI messengersName;
    [Space]
    [SerializeField] TextMeshProUGUI messageText;

    [Header("Start Delay")]
    [SerializeField] float delayBeforeMessage;

    [Header("Content")]
    public string username;
    public string message;

    #endregion Variables

    public void UpdateTexts(string text, string reci_name)
    {
        //Update Recivers Name//
        username = reci_name;

        //Update Text//
        message = text;

        this.gameObject.SetActive(true);

        messengersName.SetText(username);
        StartCoroutine("messageDelay");
    }

    #region Start Corutines
    IEnumerator messageDelay()
    {
        messageText.SetText(" ");
        yield return new WaitForSecondsRealtime(0.4f);
        messageText.SetText(".");
        yield return new WaitForSecondsRealtime(0.15f);
        messageText.SetText("..");
        yield return new WaitForSecondsRealtime(0.15f);
        messageText.SetText("...");
        yield return new WaitForSecondsRealtime(delayBeforeMessage);
        messageText.SetText(message);
    }


    #endregion Start Corutines
}
