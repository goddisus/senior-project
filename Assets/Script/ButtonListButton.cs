using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    
    private Text myText;

    [SerializeField]
    
    private Text myTextRecord;

    // [SerializeField]
    
    // private Text GradeRecord;

    private string hello = "Click";
    
    void Start()
    {
	    gameObject.GetComponent<Button>().onClick.AddListener(isClickOrNot);
    }

    public void SetText(string textString)
    {
        hello = textString;
        int x = int.Parse(textString);
        string musicName = ButtonListControl.MusicListDataInJson.musicname[x-1] + " - " + ButtonListControl.MusicListDataInJson.artistname[x-1];
	    myText.text = musicName;
        // myTextRecord.text = StaticClass.RecordInformation[x-1]
        float percentageResult = float.Parse(StaticClass.RecordInformation[x-1]);
        if (percentageResult >= 90)
        {
            myTextRecord.text = "S - " + StaticClass.RecordInformation[x-1];
            // GradeRecord.text = "S";
        }
        else if(percentageResult >= 80)
        {
            myTextRecord.text = "A - " + StaticClass.RecordInformation[x-1];
            // GradeRecord.text = "A";
        }
        else if(percentageResult >= 70)
        {
            myTextRecord.text = "B - " + StaticClass.RecordInformation[x-1];
            // GradeRecord.text = "B";
        }
        else if(percentageResult >= 60)
        {
            myTextRecord.text = "C - " + StaticClass.RecordInformation[x-1];
            // GradeRecord.text = "C";
        }
        else if(percentageResult >= 50)
        {
            myTextRecord.text = "D - " + StaticClass.RecordInformation[x-1];
            // GradeRecord.text = "D";
        }
        else if(percentageResult != 0)
        {
            myTextRecord.text = "F - " + StaticClass.RecordInformation[x-1];
            // GradeRecord.text = "F";
        }
        else
        {
            myTextRecord.text = "-";
            // GradeRecord.text = "";
        }
    }

    private void isClickOrNot()
    {
	    StaticClass.CrossSceneInformation = hello;
        SceneManager.LoadScene("SelectMusicRange");
	    Debug.Log(hello);
    }
}
