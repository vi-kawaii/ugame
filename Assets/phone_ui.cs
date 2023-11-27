using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone_ui : MonoBehaviour
{
    public GameObject chatApp;

    public void OnCameraAppClick()
    {
        Debug.Log("camera app");
    }

    public void OnTasksAppClick()
    {
        Debug.Log("tasks app");
    }

    public void OnMapAppClick()
    {
        Debug.Log("map app");
    }

    public void OnChatAppClick()
    {
        chatApp.SetActive(true);
    }

    public void OnExitClick()
    {
        Debug.Log("exit");
    }

    public void OnPauseClick()
    {
        Debug.Log("pause");
    }

    // Start is called before the first frame update
    void Start()
    {
        chatApp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
