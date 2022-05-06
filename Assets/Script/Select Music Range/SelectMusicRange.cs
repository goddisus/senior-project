using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMusicRange: MonoBehaviour{

    public static MusicChordClass MusicChordDataInJson;

    public Text myText;

    public GameObject StartInputOutOfRange;
    public GameObject StopInputOutOfRange;
    
    public GameObject AlertCustomConfirm1;
    public GameObject AlertCustomConfirm2;
    public GameObject AlertCustomConfirm3;

    public InputField StartMin;
    public InputField StartSec;
    public InputField StopMin;
    public InputField StopSec;

    float RoomPerSec;
    int minMusic = 0;
    int secMusic = 0;

    // FOR ValidateInput() Only
    int StartMinState = 0;
    int StartSecState = 0;
    int StopMinState = 0;
    int StopSecState = 0;
    int StartMinute = 0;
    int StartSecond = 0;
    int StopMinute = 0;
    int StopSecond = 0;
    // FOR ValidateInput() Only

    void Start ()
    {
        string jsonPath = Application.streamingAssetsPath + "/Music/" + StaticClass.CrossSceneInformation + ".json";
		// read file as text
		string jsonStr = File.ReadAllText(jsonPath); // using System;
        MusicChordDataInJson = JsonUtility.FromJson<MusicChordClass>(jsonStr);
		StaticClass.CrossSceneTrueInformation = MusicChordDataInJson.beats;
        RoomPerSec = 240/MusicChordDataInJson.tempo;
        Debug.Log("Room per second : " + RoomPerSec);
        float HowLong = (RoomPerSec * MusicChordDataInJson.room) + MusicChordDataInJson.firstbeat;
        Debug.Log("Long : " + HowLong);
		// StaticClass.CrossSceneTrueInformation = MusicChordDataInJson.beats;
	    // gameObject.GetComponent<Button>().onValueChanged.AddListener(ValueChanged);
        // int minMusic = 0;
        while (HowLong >= 60)
        {
            HowLong = HowLong - 60;
            minMusic = minMusic + 1;
        }

        secMusic = (int) HowLong;
        // Debug.Log(minMusic);
        // Debug.Log(secMusic);
        myText.text = "0 : 00 - 0" + minMusic.ToString() + " : " + (secMusic).ToString();
        
	    // StartMin.onValueChanged.AddListener(delegate {ValueChanged(); });
	    // StartSec.onValueChanged.AddListener(delegate {ValueChanged(); });
	    // StopMin.onValueChanged.AddListener(delegate {ValueChanged(); });
	    // StopSec.onValueChanged.AddListener(delegate {ValueChanged(); });
        // Debug.Log(StartMin.text);
    }

    void Update () 
    {

    }

    public void CallByDefaultConfirmButton()
    {
        StaticClass.PlayMode = 0;
        StaticClass.TagForOpenMusic = 0;
        StaticClass.FirstBeat = MusicChordDataInJson.firstbeat;
        StaticClass.FirstRoom = 0;
        StaticClass.LastRoom = MusicChordDataInJson.room;
        StaticClass.HowManyRoom = MusicChordDataInJson.room;
        StaticClass.MusicTempo = RoomPerSec;
        StaticClass.MusicRangeSample = MusicChordDataInJson.range;
		SceneManager.LoadScene("PlayingScene");
    }

    public void CallByCustomButtonConFirm()
    {
        if(StartMinState == 1 && StartSecState == 1 && StopMinState == 1 && StopSecState == 1)
        {
            int StartTotalSecond = (StartMinute*60) + StartSecond ;
            int StopTotalSecond = (StopMinute*60) + StopSecond ;
            if(StartTotalSecond > StopTotalSecond)
            {
                // Debug.Log("Start cannot less than Stop");
                AlertCustomConfirm1.SetActive(false);
                AlertCustomConfirm2.SetActive(true);
                AlertCustomConfirm3.SetActive(false);
            }
            else if(StopTotalSecond - StartTotalSecond < 30)
            {
                // Debug.Log("Pls select more than 30s");
                AlertCustomConfirm1.SetActive(false);
                AlertCustomConfirm2.SetActive(false);
                AlertCustomConfirm3.SetActive(true);
            }
            else
            {
                // Debug.Log("CUSTOM SUCCESS !!");
                AlertCustomConfirm1.SetActive(false);
                AlertCustomConfirm2.SetActive(false);
                AlertCustomConfirm3.SetActive(false);
                float FindFirstRoom = MusicChordDataInJson.firstbeat;
                float FindLastRoom = MusicChordDataInJson.firstbeat;
                int StartAtRoom = 0;
                int EndAtRoom = 0;
                while(StartTotalSecond-FindFirstRoom > RoomPerSec)
                {
                    FindFirstRoom += RoomPerSec;
                    StartAtRoom += 1;
                }
                while(StopTotalSecond-FindLastRoom > RoomPerSec)
                {
                    FindLastRoom += RoomPerSec;
                    EndAtRoom += 1;
                }
                EndAtRoom += 1;
                Debug.Log(EndAtRoom);
                StartAtRoom = StartAtRoom - 4;
                // Debug.Log(StartAtRoom);
                if(StartAtRoom <= 0)
                {
                    //
                    StaticClass.PlayMode = 1;
                    StaticClass.TagForOpenMusic = 0;
                    StaticClass.FirstBeat = MusicChordDataInJson.firstbeat;
                    StaticClass.FirstRoom = 0;
                    StaticClass.LastRoom = EndAtRoom;
                    StaticClass.HowManyRoom = EndAtRoom - 0;
                    StaticClass.MusicTempo = RoomPerSec;
                    StaticClass.MusicRangeSample = MusicChordDataInJson.range;
		            SceneManager.LoadScene("PlayingScene");
                }
                else
                {
                    // Debug.Log((StartAtRoom*RoomPerSec)+MusicChordDataInJson.firstbeat);
                    // Debug.Log(Math.Floor((StartAtRoom*RoomPerSec)+MusicChordDataInJson.firstbeat));
                    float customFirstBeat = (StartAtRoom*RoomPerSec)+MusicChordDataInJson.firstbeat;
                    float newFirstBeat = (float) customFirstBeat - (int) Math.Floor(customFirstBeat);
                    Debug.Log(StartAtRoom);
                    Debug.Log(newFirstBeat);
                    StaticClass.PlayMode = 1;
                    StaticClass.TagForOpenMusic = (int) Math.Floor(customFirstBeat);
                    StaticClass.FirstBeat = newFirstBeat;
                    StaticClass.FirstRoom = StartAtRoom;
                    StaticClass.LastRoom = EndAtRoom;
                    StaticClass.HowManyRoom = EndAtRoom - StartAtRoom;
                    StaticClass.MusicTempo = RoomPerSec;
                    StaticClass.MusicRangeSample = MusicChordDataInJson.range;
                    Debug.Log(StaticClass.HowManyRoom);
		            SceneManager.LoadScene("PlayingScene");
                }
            }
        }
        else
        {
            // Debug.Log("Something went wrong !");
            AlertCustomConfirm1.SetActive(true);
            AlertCustomConfirm2.SetActive(false);
            AlertCustomConfirm3.SetActive(false);
        }
    }

    // private void testSomething()
    // {
    //     Debug.Log("hello");
    // }

    public void ValidateInput()
    {
        // Debug.Log("Call by Input Field");
        // testSomething();
        if(StartMin.text.Length > 0)
        {
            try
            {
                StartMinute = Int32.Parse(StartMin.text);
                if (StartMinute > minMusic)
                {
                    StartMinState = 0;
                    // SHOW SOMETHING (TEXT - INPUT OUT OF RANGE)
                }
                else
                {
                    StartMinState = 1;
                }
            }
            catch (Exception e)
            {
                StartMinState = 0;
                // Debug.Log("Invalid Input");
                // InvalidInput.SetActive(true);
            }
        }
        if(StartSec.text.Length > 0)
        {
            try
            {
                StartSecond = Int32.Parse(StartSec.text);
                // Debug.Log(StartSec > secMusic);
                if(StartSecond >= 60)
                {
                    StartSecState = 0;
                }
                else if (StartSecond > secMusic)
                {
                    if(StartMinute >= minMusic)
                    {
                        StartSecState = 0;
                    }
                    else if(StartMinute < minMusic)
                    {
                        StartSecState = 1;
                    }
                    // SHOW SOMETHING (TEXT - INPUT OUT OF RANGE)
                }
                else
                {
                    StartSecState = 1;
                }
            }
            catch (Exception e)
            {
                StartSecState = 0;
                // Debug.Log("Invalid Input");
                // InvalidInput.SetActive(true);
            }
        }
        if(StartMinState == 1 && StartSecState == 1)
        {
            StartInputOutOfRange.SetActive(false);
        }
        else
        {
            StartInputOutOfRange.SetActive(true);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        if(StopMin.text.Length > 0)
        {
            try
            {
                StopMinute = Int32.Parse(StopMin.text);
                if (StopMinute > minMusic)
                {
                    StopMinState = 0;
                    // SHOW SOMETHING (TEXT - INPUT OUT OF RANGE)
                }
                else
                {
                    StopMinState = 1;
                }
            }
            catch (Exception e)
            {
                StopMinState = 0;
                // Debug.Log("Invalid Input");
                // InvalidInput.SetActive(true);
            }
        }
        if(StopSec.text.Length > 0)
        {
            try
            {
                StopSecond = Int32.Parse(StopSec.text);
                // Debug.Log(StartSec > secMusic);
                if(StopSecond >= 60)
                {
                    StopSecState = 0;
                }
                else if (StopSecond > secMusic)
                {
                    if(StopMinute >= minMusic)
                    {
                        StopSecState = 0;
                    }
                    else if(StopMinute < minMusic)
                    {
                        StopSecState = 1;
                    }
                    // SHOW SOMETHING (TEXT - INPUT OUT OF RANGE)
                }
                else
                {
                    StopSecState = 1;
                }
            }
            catch (Exception e)
            {
                StopSecState = 0;
                // Debug.Log("Invalid Input");
                // InvalidInput.SetActive(true);
            }
        }
        if(StopMinState == 1 && StopSecState == 1)
        {
            StopInputOutOfRange.SetActive(false);
        }
        else
        {
            StopInputOutOfRange.SetActive(true);
        }
    }

    // private void ValueChanged()
    // {
    //     Debug.Log(myText.text);
    // }
}