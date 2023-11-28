using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

class ChatMessage
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
    public GameObject personPrefab;
    public GameObject tasksApp;
    public GameObject mapApp;
    public GameObject close;

    private List<ChatMessage> chatMessages;

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

        chatMessages.ForEach(m =>
        {
            var x = Instantiate(personPrefab, chatContent.transform);
            var s = x.GetComponent<chat_handler>();
            s.SetParams(phoneUi, m.Person, m.Message);
        });
    }

    public void OnOpenChatClick()
    {
        chat.SetActive(true);
    }

    public void OnExitClick()
    {
        Debug.Log("exit");
    }

    public void OnPauseClick()
    {
        Debug.Log("pause");
    }

    public void OnCloseClick()
    {
        if (chat.activeSelf)
        {
            chat.SetActive(false);
            return;
        }

        close.SetActive(false);
        chatApp.SetActive(false);
        mapApp.SetActive(false);
        tasksApp.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        chatApp.SetActive(false);
        chat.SetActive(false);
        tasksApp.SetActive(false);
        mapApp.SetActive(false);
        close.SetActive(false);

        chatMessages = new List<ChatMessage>
        {
            new ChatMessage{ Person="first", Message="Hello world from first" },
            new ChatMessage{ Person="second", Message="Hello world from second" },
            new ChatMessage{ Person="trird", Message="Hello world from third" },
            new ChatMessage{ Person="fourth", Message="Hello world from fourth" },
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
