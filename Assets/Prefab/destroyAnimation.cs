using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destroyAnimation : MonoBehaviour {
    float timeCheck;
    // Use this for initialization
    void Start () {
        timeCheck = timer.currentTime;
	//Debug.Log((float) screenBounds.x*-2);
    }

    // Update is called once per frame
    void Update () {
        if(timer.currentTime-timeCheck > 0.5)
        {
            Destroy(this.gameObject);
        }
    }
}