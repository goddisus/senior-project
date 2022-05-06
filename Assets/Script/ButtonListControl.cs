using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    
    private GameObject buttonTemplate;

    public static MusicListClass MusicListDataInJson;

    public static MusicListRecordClass MusicListRecordDataInJson;

    void Start()
    {
		string jsonPath = Application.streamingAssetsPath + "/musiclist.json";
		// read file as text
		string jsonStr = File.ReadAllText(jsonPath); // using System;
        MusicListDataInJson = JsonUtility.FromJson<MusicListClass>(jsonStr);
		
		jsonPath = Application.streamingAssetsPath + "/musiclistrecord.json";
		// read file as text
		jsonStr = File.ReadAllText(jsonPath); // using System;
        MusicListRecordDataInJson = JsonUtility.FromJson<MusicListRecordClass>(jsonStr);

	    StaticClass.RecordInformation = MusicListRecordDataInJson.record;

		Debug.Log(MusicListDataInJson.musicname.Count);
		for (int i = 0; i < MusicListDataInJson.musicname.Count; i++)
		{
			GameObject button = Instantiate(buttonTemplate) as GameObject;
			button.SetActive(true);

			button.GetComponent<ButtonListButton>().SetText(MusicListDataInJson.musicfilename[i]);

			button.transform.SetParent(buttonTemplate.transform.parent, false);
		}
    }
}
