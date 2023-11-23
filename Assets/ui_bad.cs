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
        var pointInsideScreen = new Vector3(
            Mathf.Clamp(centerPoint.x, 0 - Screen.width / 2, Screen.width / 2),
            Mathf.Clamp(centerPoint.y, 0 - Screen.height / 2, Screen.height / 2),
            centerPoint.z
        );

        if (pointInsideScreen.z < 0)
        {
            pointInsideScreen = new Vector3(
                pointInsideScreen.x < 0 ? Screen.width / 2 : 0 - Screen.width / 2,
                pointInsideScreen.y < 0 ? 0 - Screen.height / 2 : Screen.height / 2,
                // Mathf.Clamp(pointInsideScreen.y - Screen.height, 0 - Screen.height / 2, Screen.height / 2),
                pointInsideScreen.z
            );
        }

        Debug.Log(pointInsideScreen);

        rt.anchoredPosition = pointInsideScreen;
    }
}
