using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    void Start()
    {
        System.Diagnostics.Process.Start("explorer");
    }

    void Update()
    {
        var x = System.Diagnostics.Process.GetProcessesByName("notepad");
        string y = x.Length != 0 ? "" : "не ";
	Debug.Log($"Блокнот {y}запущен");
    }
}
