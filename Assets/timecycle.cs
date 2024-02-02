using UnityEngine;
using TMPro;

public class timecycle : MonoBehaviour
{
    int minutes = 0;
    public GameObject Light;
    public TextMeshProUGUI Text;

    void Start()
    {
        InvokeRepeating("UpdateCurrentTime", 0f, 0.02f);
    }

    void UpdateCurrentTime()
    {
        minutes += 1;
        if (minutes == 60 * 24)
        {
            minutes = 0;
        }
    }

    void Update()
    {
        float rotationDegrees = TimeToDegrees(minutes);
        Light.transform.rotation = Quaternion.Euler(rotationDegrees + 90f + 180f, 0f, 0f);
        Text.text = ConvertToTime(minutes);
    }

    string ConvertToTime(int minutes)
    {
        int hours = minutes / 60;
        int remainingMinutes = minutes % 60;

        string formattedTime = string.Format("{0:D2}:{1:D2}", hours, remainingMinutes);

        return formattedTime;
    }

    float TimeToDegrees(int time)
    {
        float degreesPerMinute = 360f / (27 * 60);
        float rotationDegrees = minutes * degreesPerMinute;

        return rotationDegrees;
    }
}
