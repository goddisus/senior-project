using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.UI;

public class TimerTextUpdate : MonoBehaviour
{
    public Text currentTimeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan time = TimeSpan.FromSeconds(timer.currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:ff");
    }
}
