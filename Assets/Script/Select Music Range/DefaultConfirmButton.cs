using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefaultConfirmButton : MonoBehaviour
{
    [SerializeField]
    
    private Text myText;

    private string hello = "Click";

    public SelectMusicRange SelectMusicRangeObj = null;
    
    void Start()
    {
	    gameObject.GetComponent<Button>().onClick.AddListener(isClickOrNot);
    }

    public void SetText(string textString)
    {
        Debug.Log("Helli");
    }

    private void isClickOrNot()
    {
        // gameObject.GetComponent<SelectMusicRange>().CallByButtonConFirm();
	    // SelectMusicRange.ValueChanged();
        if (SelectMusicRangeObj != null)
        {
            SelectMusicRangeObj.CallByDefaultConfirmButton();
        }
    }
}
