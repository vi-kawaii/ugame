using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class script : MonoBehaviour
{
    string version;

    void Start()
    {
        version = File.ReadAllText("version.txt");
    }

    void Update()
    {
        if (System.Diagnostics.Process.GetProcessesByName("game").Length > 0)
        {
            return;
        }

        //System.Diagnostics.Process.Start(version + "\\game.exe");

        var dirs = Directory.GetDirectories(".", "????-??-??");
        foreach (var dir in dirs)
        {
            if (dir == ".\\" + version)
            {
                continue;
            }
            Directory.Delete(dir, true);
        }

        File.Delete($"{version}.zip");

        //Application.Quit();
    }
}
