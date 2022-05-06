using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PlayMusicSource : MonoBehaviour
{
    // public AudioSource PlayMusic;
    // public PredictionClient client;
    
    // Start is called before the first frame update
    
    // AudioSource audio = gameObject.AddComponent<AudioSource>();
    // timer timeStart;
    AudioSource audio;
    int stateMusic = 0;
    public GameObject timeStart;
    AudioClip s;
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        s = Resources.Load<AudioClip>(StaticClass.CrossSceneInformation);
        Debug.Log("Success Load");
		GameObject Timer = Instantiate(timeStart) as GameObject;
        Debug.Log(timer.currentTime);
        // Debug.Log(s.channels);
        // Debug.Log(s.frequency);
        // Debug.Log(s.length);
        // Debug.Log(s.samples);
        audio.clip = s;
        audio.time = StaticClass.TagForOpenMusic;
	    // AudioSource PlayMusic = Application.streamingAssetsPath + "/"+"StaticClass.CrossSceneInformation"+".prefab"; 
	//string jsonPath = Application.streamingAssetsPath + "/Music/" + StaticClass.CrossSceneInformation + ".json";
        //AudioSource audio = gameObject.AddComponent<AudioSource>();
        //audio.PlayOneShot (Resources.Load<AudioClip>("example"));
    }

    // Update is called once per frame
    void Update()
    {
        if (stateMusic == 0)
	    {
            // 7.5 is first bar hit at BAR
            // if(timer.currentTime > 7.48-spawn.MusicChordDataInJson.firstbeat)
            if(timer.currentTime > 7.48-StaticClass.FirstBeat)
            {
                // Debug.Log(spawn.MusicChordDataInJson.firstbeat);
                Debug.Log(7.48-StaticClass.FirstBeat);
                Debug.Log(timer.currentTime);
                // AudioSource MusicObjectPlayer = Instantiate(PlayMusic) as AudioSource;
                //MusicObjectPlayer.Play ();
                // audio.PlayOneShot (s);
                audio.Play();
                stateMusic = 1;
			    //Predict();
            }
	    }
    }

    // private void Predict()
    // {
	// 	Debug.Log("Predict Func");
    //     client.Predict("is this true?", error =>
    //     {
    //         // TODO: when i am not lazy
    //     });
    // }
}
