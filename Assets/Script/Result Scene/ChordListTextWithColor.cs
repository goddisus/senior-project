using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChordListTextWithColor : MonoBehaviour
{
    [SerializeField]
    
    private Text myText;

    
    void Start()
    {
    }

    public void SetText(string textString, string textColor)
    {
        // hello = textString;
        // int x = int.Parse(textString);
        // string musicName = ButtonListControl.MusicListDataInJson.musicname[x-1] + " - " + ButtonListControl.MusicListDataInJson.artistname[x-1];
	    myText.text = textString;
        if(textColor == "green")
        {
            myText.color = Color.green;
        }
        else if(textColor == "red")
        {
            myText.color = Color.red;
        }
        else
        {
            //
        }
    }
}
