using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class chat_handler : MonoBehaviour, IPointerClickHandler
{
    public GameObject Phone;
    public string Person;
    public string Message;
    public GameObject Name;
    public GameObject Msg;
    private phone_ui script;

    void Start()
    {
        script = Phone.GetComponent<phone_ui>();
        Name.GetComponent<Text>().text = Person;
        Msg.GetComponent<Text>().text = Message;
    }

    public void OnPointerClick(PointerEventData e)
    {
        script.OnOpenChatClick();
    }
}
