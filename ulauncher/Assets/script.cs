using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    void Start()
    {
        System.IO.File.WriteAllText(Application.dataPath + "\\helloworld.txt", "Hello world");
        Application.Quit();
    }
}
