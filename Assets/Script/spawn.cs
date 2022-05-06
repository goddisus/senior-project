using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using UnityEngine;
using UnityEngine.SceneManagement;

public class spawn: MonoBehaviour {
    public GameObject Bar;
    public GameObject asteroidPrefabA;
    public GameObject asteroidPrefabB;
    public GameObject asteroidPrefabC;
    public GameObject asteroidPrefabD;
    public GameObject asteroidPrefabE;
    public GameObject asteroidPrefabF;
    public GameObject asteroidPrefabG;
    public float respawnTime = 1;
    public static float CountLoop;
    private Vector2 screenBounds;
    public static MusicChordClass MusicChordDataInJson;
    int stateMusic = 0;
    // Use this for initialization
    void Start () 
	{
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		CountLoop = StaticClass.FirstRoom;
        // string jsonPath = Application.streamingAssetsPath + "/Music/" + StaticClass.CrossSceneInformation + ".json";
		// // read file as text
		// string jsonStr = File.ReadAllText(jsonPath); // using System;
        // MusicChordDataInJson = JsonUtility.FromJson<MusicChordClass>(jsonStr);
		// StaticClass.CrossSceneTrueInformation = MusicChordDataInJson.beats;
    }

    void Update()
    {
        if (stateMusic == 0)
	    {
            if(timer.currentTime > 3)
            {
				Debug.Log("StartCoroutine");
				Debug.Log(timer.currentTime);
				StartCoroutine(asteroidWave());
				// Debug.Log("tempo :" + ((float) 240/MusicChordDataInJson.tempo).ToString());
				// Debug.Log(screenBounds.x);
				// Debug.Log(CountLoop);
				// Debug.Log(MusicChordDataInJson.room);
                stateMusic = 1;
			    //Predict();
            }
	    }
    }

    private void spawnEnemy(){
		//Debug.Log(MusicChordDataInJson.beats[(int)(CountLoop*4)]);
		//Debug.Log(MusicChordDataInJson.beats[(int)(CountLoop*4)+1]);
		//Debug.Log(MusicChordDataInJson.beats[(int)(CountLoop*4)+2]);
		//Debug.Log(MusicChordDataInJson.beats[(int)(CountLoop*4)+3]);
		//int x = UnityEngine.Random.Range(0,7);
		string x = StaticClass.CrossSceneTrueInformation[(int)(CountLoop*4)];
		if (x=="A"){
			GameObject a = Instantiate(asteroidPrefabA) as GameObject;
			GameObject b = Instantiate(Bar) as GameObject;
			b.transform.position = new Vector2(screenBounds.x, -0.4997f);
			a.transform.position = new Vector2(((float) (screenBounds.x))+((float) (b.transform.localScale.x)/2)+((float) (a.transform.localScale.x)), 0);
		}
		else if (x=="Am"){
			GameObject a = Instantiate(asteroidPrefabA) as GameObject;
			GameObject b = Instantiate(Bar) as GameObject;
			b.transform.position = new Vector2(screenBounds.x, -0.4997f);
			a.transform.position = new Vector2(((float) (screenBounds.x))+((float) (b.transform.localScale.x)/2)+((float) (a.transform.localScale.x)), 0.5f);
		}
		else if (x=="B"){
			GameObject a = Instantiate(asteroidPrefabB) as GameObject;
			GameObject b = Instantiate(Bar) as GameObject;
			b.transform.position = new Vector2(screenBounds.x, -0.4997f);
			a.transform.position = new Vector2(((float) (screenBounds.x))+((float) (b.transform.localScale.x)/2)+((float) (a.transform.localScale.x)), 0.5f);
		}
		else if (x=="C"){
			GameObject a = Instantiate(asteroidPrefabC) as GameObject;
			GameObject b = Instantiate(Bar) as GameObject;	
			b.transform.position = new Vector2(screenBounds.x, -0.4997f);
			a.transform.position = new Vector2(((float) (screenBounds.x))+((float) (b.transform.localScale.x)/2)+((float) (a.transform.localScale.x)), 0);
		}
		else if (x=="D"){
			GameObject a = Instantiate(asteroidPrefabD) as GameObject;
			GameObject b = Instantiate(Bar) as GameObject;
			b.transform.position = new Vector2(screenBounds.x, -0.4997f);
			a.transform.position = new Vector2(((float) (screenBounds.x))+((float) (b.transform.localScale.x)/2)+((float) (a.transform.localScale.x)), 0.5f);
		}
		else if (x=="E"){
			GameObject a = Instantiate(asteroidPrefabE) as GameObject;
			GameObject b = Instantiate(Bar) as GameObject;
			b.transform.position = new Vector2(screenBounds.x, -0.4997f);
			a.transform.position = new Vector2(((float) (screenBounds.x))+((float) (b.transform.localScale.x)/2)+((float) (a.transform.localScale.x)), -0.5f);
		}
		else if (x=="Em"){
			GameObject a = Instantiate(asteroidPrefabE) as GameObject;
			GameObject b = Instantiate(Bar) as GameObject;
			b.transform.position = new Vector2(screenBounds.x, -0.4997f);
			a.transform.position = new Vector2(((float) (screenBounds.x))+((float) (b.transform.localScale.x)/2)+((float) (a.transform.localScale.x)), -0.5f);
		}
		else if (x=="F"){
			GameObject a = Instantiate(asteroidPrefabF) as GameObject;
			GameObject b = Instantiate(Bar) as GameObject;
			b.transform.position = new Vector2(screenBounds.x, -0.4997f);
			a.transform.position = new Vector2(((float) (screenBounds.x))+((float) (b.transform.localScale.x)/2)+((float) (a.transform.localScale.x)), 0.5f);
		}
		else if (x=="G"){
			GameObject a = Instantiate(asteroidPrefabG) as GameObject;
			GameObject b = Instantiate(Bar) as GameObject;
			b.transform.position = new Vector2(screenBounds.x, -0.4997f);
			a.transform.position = new Vector2(((float) (screenBounds.x))+((float) (b.transform.localScale.x)/2)+((float) (a.transform.localScale.x)), -0.5f);
		}
    }
    IEnumerator asteroidWave(){
        while(CountLoop < StaticClass.LastRoom+2)
		{
			if(CountLoop < StaticClass.LastRoom)
			{
	    		spawnEnemy();
			}
            // yield return new WaitForSeconds((float) 240/MusicChordDataInJson.tempo);
			yield return new WaitForSeconds(StaticClass.MusicTempo);
            CountLoop = CountLoop + 1;
	    //Debug.Log(timer.currentTime);
        }
    }
}