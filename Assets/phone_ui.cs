using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

[System.Serializable]
public class ChatMessage
{
    public string Person;
    public string Message;
}

public class phone_ui : MonoBehaviour
{
    public GameObject phoneUi;
    public GameObject chatApp;
    public GameObject chat;
    public GameObject chatContent;
    public GameObject chatForPersonContent;
    public GameObject chatForPersonTitle;
    public GameObject personPrefab;
    public GameObject messagePrefab;
    public GameObject tasksApp;
    public GameObject mapApp;
    public GameObject close;

    public List<ChatMessage> chatMessages;

    public void OnCameraAppClick()
    {
        Debug.Log("camera app");
    }

    public void OnTasksAppClick()
    {
        tasksApp.SetActive(true);
        close.SetActive(true);
    }

    public void OnMapAppClick()
    {
        mapApp.SetActive(true);
        close.SetActive(true);
    }

    public void OnChatAppClick()
    {
        chatApp.SetActive(true);
        close.SetActive(true);

        string currentPerson = "";

        chatMessages.ForEach(m =>
        {
            if (m.Person == currentPerson)
            {
                return;
            }

            currentPerson = m.Person;

            var x = Instantiate(personPrefab, chatContent.transform);
            var s = x.GetComponent<chat_handler>();
            s.SetParams(phoneUi, m.Person, m.Message);
        });
    }

    public void OnOpenChatClick(string person)
    {
        chat.SetActive(true);

        chatForPersonTitle.GetComponent<TextMeshProUGUI>().text = person;

        chatMessages.Where(m => m.Person == person).ToList().ForEach(m =>
        {
            var x = Instantiate(messagePrefab, chatForPersonContent.transform);
            var s = x.GetComponent<chat_for_person_handler>();
            s.SetParams(m.Message);
        });
    }

    public void OnExitClick()
    {
        Debug.Log("exit");
    }

    public void OnUpdateClick()
    {
        Debug.Log("update");
    }

    public void OnPauseClick()
    {
        Debug.Log("pause");
    }

    public void OnCloseClick()
    {
        if (chat.activeSelf)
        {
            foreach (Transform c in chatForPersonContent.transform)
            {
                Destroy(c.gameObject);
            }

            chat.SetActive(false);
            return;
        }

        close.SetActive(false);
        chatApp.SetActive(false);
        mapApp.SetActive(false);
        tasksApp.SetActive(false);
    }

    // Start is called before the first frame update
    public void Awake()
    {
        chatApp.SetActive(false);
        chat.SetActive(false);
        tasksApp.SetActive(false);
        mapApp.SetActive(false);
        close.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
