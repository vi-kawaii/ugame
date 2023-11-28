using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class chat_handler : MonoBehaviour, IPointerClickHandler
{
    private phone_ui script;
    private TextMeshProUGUI personName;
    private TextMeshProUGUI personMessage;

    void Awake()
    {
        personName = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        personMessage = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    public void SetParams(GameObject phone, string person, string message)
    {
        script = phone.GetComponent<phone_ui>();
        personName.text = person;
        personMessage.text = message;
    }

    public void OnPointerClick(PointerEventData e)
    {
        script.OnOpenChatClick();
    }
}
