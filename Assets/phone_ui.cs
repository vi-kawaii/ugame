using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.Networking;
using Ionic.Zip;

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
    public GameObject progressText;

    public List<ChatMessage> chatMessages;

    private string remoteVersion;

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
        progressText.SetActive(true);
        StartCoroutine(DownloadZip());
    }

    IEnumerator ProgressBar(UnityWebRequestAsyncOperation operation)
    {
        while (!operation.isDone)
        {
            progressText.GetComponent<TextMeshProUGUI>().text = operation.progress.ToString() + "%";
            yield return null;
        }
    }

    IEnumerator DownloadZip()
    {
        var u = new UnityWebRequest($"https://vi-kawaii.github.io/ugame/{remoteVersion}.zip");
        u.downloadHandler = new DownloadHandlerFile($".\\{remoteVersion}.zip");
        var operation = u.SendWebRequest();

        yield return StartCoroutine(ProgressBar(operation));

        if (u.isNetworkError || u.isHttpError)
        {
            progressText.GetComponent<TextMeshProUGUI>().text = u.error;
        }
        else
        {
            progressText.GetComponent<TextMeshProUGUI>().text = "Распаковка архива начата";
            using (ZipFile zip = ZipFile.Read($".\\{remoteVersion}.zip"))
            {
                progressText.GetComponent<TextMeshProUGUI>().text = "Мы внутри распаковки";
                zip.ExtractAll($".\\{remoteVersion}");
            }
            progressText.GetComponent<TextMeshProUGUI>().text = "Архив распакован";
            PlayerPrefs.SetString("version", remoteVersion);
        }
    }

    public void SetVersion(string v)
    {
        remoteVersion = v;
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
