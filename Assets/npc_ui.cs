using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_ui : MonoBehaviour
{
    public GameObject character;

    public void TakeDamage()
    {
        int childCountInContent = transform.GetChild(0).transform.childCount;
        Transform content = transform.GetChild(0).transform;
        Destroy(content.GetChild(childCountInContent - 1).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(character.transform);
    }
}
