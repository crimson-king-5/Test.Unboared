using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTime(float time)
    {
        int minuts = (int)(time / 60f);
        int seconds = (int)(time % 60f);

        text.text = minuts.ToString() + ":" + seconds.ToString("00");
    }



}
