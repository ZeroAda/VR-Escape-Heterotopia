using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    // Start is called before the first frame update
    private float remainingTime2;
    void Start()
    {
        remainingTime2 = remainingTime;
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        
        if (remainingTime <= 0)
        {
            // reset the timer
            remainingTime = remainingTime2;

        }
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
