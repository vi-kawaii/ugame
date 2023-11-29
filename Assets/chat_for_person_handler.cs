using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class chat_for_person_handler : MonoBehaviour
{
    private TextMeshProUGUI personMessage;

    void Awake()
    {
        personMessage = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void SetParams(string message)
    {
        personMessage.text = message;
    }
}
