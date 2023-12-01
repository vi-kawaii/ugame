using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_ui : MonoBehaviour
{
    public GameObject character;

    public void TakeDamage()
    {
        Transform content = transform.GetChild(0).transform;
        Destroy(content.GetChild(0).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(character.transform);
    }
}
