using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Ionic.Zip;

public class script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string remoteVersion = PlayerPrefs.GetString("remoteVersion");
        using (ZipFile zip = ZipFile.Read($".\\{remoteVersion}.zip"))
        {
            zip.ExtractAll($".\\{remoteVersion}");
        }
        PlayerPrefs.SetString("extractingFinished", "true");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
