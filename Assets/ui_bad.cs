using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_bad : MonoBehaviour
{
    public GameObject enemy;
    public GameObject character;
    public Camera camera;
    public RectTransform rt;

    // Update is called once per frame
    void Update()
    {
        var leftBottomPoint = camera.WorldToScreenPoint(enemy.transform.position);
        var centerPoint = leftBottomPoint - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        rt.anchoredPosition = centerPoint;
        // rt.anchoredPosition = camera.WorldToScreenPoint(targPos);
    }
}
