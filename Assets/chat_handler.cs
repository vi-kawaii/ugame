using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class chat_handler : MonoBehaviour, IPointerClickHandler
{
    public GameObject phone;
    private phone_ui script;

    void Start()
    {
        script = phone.GetComponent<phone_ui>();
    }

    public void OnPointerClick(PointerEventData e)
    {
        script.OnOpenChatClick();
    }
}
