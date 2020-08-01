using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock : MonoBehaviour
{
    public Transform hoursTransform, minutesTransform, secondsTransform;
    const float degreesPerHour = 30f, degreesPerMinute = 6f, degreesPerSecond = 6f;
    public bool continuous;
    void UpdateContinuous()
    {
        Debug.Log("continous");
        TimeSpan time = DateTime.Now.TimeOfDay;
        //Debug.Log("span" + (float)time.TotalHours);
        hoursTransform.localRotation =
            Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);

        Debug.Log(hoursTransform.localRotation + "hoursTransform");

        minutesTransform.localRotation =
            Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
        Debug.Log("minutes" + minutesTransform.localRotation);

        secondsTransform.localRotation =
            Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
        Debug.Log("seconds" + secondsTransform.localRotation);

    }

    void UpdateDiscrete()
    {
        Debug.Log("Dicrete");
        DateTime time = DateTime.Now;
        hoursTransform.localRotation =
            Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
        Debug.Log(hoursTransform.localRotation + "hoursTransform");
        minutesTransform.localRotation =
            Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
        Debug.Log("minutes" + minutesTransform.localRotation);
        secondsTransform.localRotation =
            Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
        Debug.Log("seconds" + secondsTransform.localRotation);
    }
    public void Update()
    {
        Debug.Log("Update");
        if (continuous)
        {
            UpdateContinuous();
        }
        else
        {
            UpdateDiscrete();
        }
    }
}
