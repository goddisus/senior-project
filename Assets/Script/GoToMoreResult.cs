using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToMoreResult : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
	    gameObject.GetComponent<Button>().onClick.AddListener(isClickOrNot);
    }

    private void isClickOrNot()
    {
        SceneManager.LoadScene("MoreResult");
    }
}
