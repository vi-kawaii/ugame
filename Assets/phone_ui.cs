using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone_ui : MonoBehaviour
{
    public GameObject chatApp;
    public GameObject tasksApp;
    public GameObject mapApp;
    public GameObject close;

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
        close.SetActive(false);
        chatApp.SetActive(false);
        mapApp.SetActive(false);
        tasksApp.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        chatApp.SetActive(false);
        tasksApp.SetActive(false);
        mapApp.SetActive(false);
        close.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
