using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChordListControl : MonoBehaviour
{
    [SerializeField]
    
    private GameObject TextTemplate;

    // private Text myText;

    // public static MusicListClass MusicListDataInJson;

    void Start()
    {
		List<string> Chord = new List<string>()
			{
				"A","B","C","D","E","F","G"
			};
		// Debug.Log(MusicListDataInJson.musicname.Count);
		for (int i = 0; i < Chord.Count; i++)
		{
			GameObject textGO = Instantiate(TextTemplate) as GameObject;
			textGO.SetActive(true);
			// button.SetActive(true);
			textGO.GetComponent<ChordListText>().SetText(Chord[i]);

			textGO.transform.SetParent(TextTemplate.transform.parent, false);
		}
    }
}
