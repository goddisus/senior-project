using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class JSONReader : MonoBehaviour
{
    // Start is called before the first frame update
    //public TextAsset jsonFile;
 
    void Start()
    {
	    // load file from the path
        string jsonPath = Application.streamingAssetsPath + "/Music/" + StaticClass.CrossSceneInformation + ".json";
        // read file as text
        string jsonStr = File.ReadAllText(jsonPath); // using System;
        MusicChordClass MusicChordDataInJson = JsonUtility.FromJson<MusicChordClass>(jsonStr);
 	    //Debug.Log(MusicChordDataInJson.tempo);
        //foreach (string chord in MusicChordDataInJson.beats)
        //{
            //Debug.Log(chord);
        //}
    }
}
