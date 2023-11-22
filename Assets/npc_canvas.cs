using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_canvas : MonoBehaviour
{
    public GameObject character;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(character.transform);
    }
}
