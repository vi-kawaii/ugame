using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_handler : MonoBehaviour
{
    private bool isMenu = false;
    public GameObject phone;
    public GameObject cam;
    private camera cameraScript;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        phone.SetActive(false);
        cameraScript = cam.GetComponent<camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("tab") && isMenu)
        {
            phone.SetActive(false);
            cameraScript.enabled = true;
            isMenu = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            return;
        }

        if (Input.GetKeyUp("tab") && !isMenu)
        {
            phone.SetActive(true);
            cameraScript.enabled = false;
            isMenu = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
