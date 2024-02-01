using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Diagnostics;

public class python_server : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeRequest());
    }

    IEnumerator MakeRequest()
    {
        string msg = "fuck you";

        // Specify the URL you want to request
        string url = $"http://localhost:5000?msg=\"{msg}\"";

        // Create a UnityWebRequest object
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Send the request and wait for a response
            yield return webRequest.SendWebRequest();

            textMeshPro.text = $"Response: {webRequest.downloadHandler.text}";
        }
    }

    void OnApplicationQuit()
    {
        foreach (var process in Process.GetProcessesByName("app"))
        {
            process.Kill();
        }
    }
}
