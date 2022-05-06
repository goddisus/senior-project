using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.UI;

public class timer: MonoBehaviour
{
    public static float currentTime;
    // public Text currentTimeText;
    // Start is called before the first frame update
    public void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        // TimeSpan time = TimeSpan.FromSeconds(currentTime);
        // currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }
}
