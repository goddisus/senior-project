using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoReplayFromResult : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
	    gameObject.GetComponent<Button>().onClick.AddListener(isClickOrNot);
    }

    private void isClickOrNot()
    {
		// spawn.CountLoop = 0;
        timer.currentTime = 0;

        SceneManager.LoadScene("PlayingScene");
    }
}
