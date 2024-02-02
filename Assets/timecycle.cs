using UnityEngine;
using TMPro;

public class timecycle : MonoBehaviour
{
    int minutes = 0;
    public GameObject Light;
    public TextMeshProUGUI Text;

    void Start()
    {
        InvokeRepeating("UpdateCurrentTime", 0f, 0.2f);
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
        Light.transform.rotation = Quaternion.Euler(rotationDegrees, 0f, 0f);
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
        int hours = minutes / 60;
        int remainingMinutes = minutes % 60;

        float totalMinutes = hours * 60 + minutes;
        float degreesPerMinute = 360f / (12 * 60);
        float rotationDegrees = totalMinutes * degreesPerMinute;

        return rotationDegrees;
    }
}
