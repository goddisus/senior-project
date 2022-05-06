using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MicInput : MonoBehaviour
{
    public string microphoneName;
    float[] samples;
    AudioClip clip;
    // Start is called before the first frame update
    // float oldBuffer = 0;
    // float oldFirstBuffer = 0;
    // float currentTime;
    float[] oldsamples;
    //float[] inputArray;
	
    public PredictionClient client;
	int stateUpdate = 0;
	int bufferSize = 44100;

    void Start()
    {
        //currentTime = 0;

		// foreach (var device in Microphone.devices)
		// {
		// 	Debug.Log(device);
		// }
		
		clip = Microphone.Start(microphoneName, true, 2, 22050);
		//Debug.Log(Microphone.GetPosition(microphoneName));
		//Debug.Log(clip.channels);	
		samples = new float[bufferSize * clip.channels];
		oldsamples = new float[bufferSize * clip.channels];
		for(int i = 0; i < bufferSize; i++)
		{
			samples[i] = 0;
		}
		//oldsamples = samples.ToList();
		samples.CopyTo(oldsamples,0);
		//StartCoroutine(MyFunction());
		//Debug.Log(timer.currentTime);
    }

    //Update is called once per frame
    void Update()
    {
        if (stateUpdate == 0)
	    {
            // 7.5 is first bar hit at BAR
            if(timer.currentTime > 7.5)
            {
				var FirstinputArray = new float[50];
				for(int i = 0; i< 50; i++)
				{
					FirstinputArray[i] = i;
				}
				// FirstinputArray[0] = spawn.MusicChordDataInJson.range;
				FirstinputArray[0] = StaticClass.MusicRangeSample;

				// float[] testlist;
				// testlist = new float[7000000];
				// System.Random rand = new System.Random();
				// for(int i = 0;i < 7000000; i++)
				// {
				// 	testlist[i] = (float)rand.NextDouble();
				// }
				
				client.Predict(FirstinputArray, error =>
				{
					// TODO: when i am not lazy
				});
				StartCoroutine(MyFunction());
                stateUpdate = 1;
			    //Predict();
            }
	    }
    }

	IEnumerator MyFunction(){
		int FirstStateCheck = 0;
		// from spawn.cs stop loop when loop == room
		// while(spawn.CountLoop < spawn.MusicChordDataInJson.room+2){
		while(spawn.CountLoop < StaticClass.LastRoom+2){
			if (FirstStateCheck == 0)
			{
				clip.GetData(samples, 0); 
				samples.CopyTo(oldsamples,0);
				FirstStateCheck = 1; 
			} 
			clip.GetData(samples, 0);      
			//Debug.Log(samples[22049]);
			if(samples != oldsamples)
			{
				//Debug.Log(samples);
			}
			if (true) 
			{
				int sameValueNumber = 0;
				int firstSameValue = -1;
				int secondSameValue = -1;
				int LastSameValue = 0;
				int mostSame = 0;
				int realfirst = 0;
				int reallast = 0;
				int secMostSame = 0;
				int secrealfirst = 0;
				int secreallast = 0;
				for(int i = 0; i < bufferSize; i++)
				{
					//Debug.Log("Count is "+i);
					if(oldsamples[i]==samples[i])
					{
						if (firstSameValue == -1)
						{
							firstSameValue = i;
						}
						else if (secondSameValue == -1)
						{
							secondSameValue = i;
						}
						LastSameValue = i;
						sameValueNumber += 1;
					}
					else
					{
						if (sameValueNumber>mostSame)
						{
							if (mostSame != 0)
							{
								secMostSame = mostSame;
								secrealfirst = realfirst;
								secreallast = reallast;
							}
							mostSame = sameValueNumber;
							realfirst = firstSameValue;
							reallast = LastSameValue;
						}
						else
						{
							if (sameValueNumber>secMostSame)
							{
								secMostSame = sameValueNumber;
								secrealfirst = firstSameValue;
								secreallast = LastSameValue;
							}
						}
						sameValueNumber = 0;
						firstSameValue = -1;
						secondSameValue = -1;
						LastSameValue = 0;
					}
				}
				
				if (sameValueNumber>mostSame)
				{
					if (mostSame != 0)
					{
						secMostSame = mostSame;
						secrealfirst = realfirst;
						secreallast = reallast;
					}
					mostSame = sameValueNumber;
					realfirst = firstSameValue;
					reallast = LastSameValue;
				}
				else
				{
					if (sameValueNumber>secMostSame)
					{
						secMostSame = sameValueNumber;
						secrealfirst = firstSameValue;
						secreallast = LastSameValue;
					}
				}
				if(mostSame == bufferSize);
				
				// why not use 1
				// use 3 because may be noise can same value tid gun more than 1

				else if (secMostSame <= 3)
				{
					// Debug.Log("FIRST :" + realfirst);
					// Debug.Log("LAST :" + reallast);
					// Debug.Log("COUNT :" + mostSame);


					// Debug.Log("From :" + (reallast+1));
					// Debug.Log("To :" + (realfirst-1));
					// Debug.Log("Range :" + (bufferSize-mostSame));
					// Debug.Log("CASE 1");
					// Debug.Log(timer.currentTime);


					// Debug.Log(samples[reallast+1]);

					var inputArray = new float[(bufferSize-mostSame) * clip.channels];
					for(int i = 0; i < bufferSize-(reallast+1); i++)
					{
						inputArray[i] = samples[i+reallast+1];
					}
					for(int i = bufferSize-(reallast+1); i < (bufferSize-(reallast+1))+realfirst; i++)
					{
						inputArray[i] = samples[i-(bufferSize-(reallast+1))];
					}


					// Debug.Log(inputArray[0]);
					// Debug.Log(inputArray.Length);
					// Debug.Log(22050-mostSame-1);
					// Debug.Log(inputArray[22050-mostSame-1]);


					// Debug.Log(bufferSize-mostSame);

					client.Predict(inputArray, error =>
						{
							// TODO: when i am not lazy
						});
					// client.Predict(inputArray);

				}
				else
				{
					if (realfirst > secrealfirst)
					{
						// Debug.Log("FIRST :" + realfirst);
						// Debug.Log("LAST :" + secreallast);
						// Debug.Log("COUNT :" + (mostSame+secMostSame));


						// Debug.Log("From :" + (secreallast+1));
						// Debug.Log("To :" + (realfirst-1));
						// Debug.Log("Range :" + (bufferSize-(mostSame+secMostSame)));
						// Debug.Log("CASE 2");
						// Debug.Log(timer.currentTime);


						var inputArray = new float[(bufferSize-(mostSame+secMostSame)) * clip.channels];
						for(int i = 0; i < bufferSize-(mostSame+secMostSame); i++)
						{
							inputArray[i] = samples[i+secreallast+1];
						}


						// Debug.Log(inputArray[0]);
						// Debug.Log(inputArray.Length);
						// Debug.Log(22050-(mostSame+secMostSame)-1);
						// Debug.Log(inputArray[22050-(mostSame+secMostSame)-1]);


						// Debug.Log(bufferSize-(mostSame+secMostSame));

						client.Predict(inputArray, error =>
							{
								// TODO: when i am not lazy
							});

					}
					else
					{
						
						// Debug.Log("FIRST :" + secrealfirst);
						// Debug.Log("LAST :" + reallast);
						// Debug.Log("COUNT :" + (mostSame+secMostSame));


						// Debug.Log("From :" + (reallast+1));
						// Debug.Log("To :" + (secrealfirst-1));
						// Debug.Log("Range :" + (bufferSize-(mostSame+secMostSame)));
						// Debug.Log("CASE 3");
						// Debug.Log("Second Array Range :" + secMostSame);

						// Debug.Log(timer.currentTime);
						

						var inputArray = new float[(bufferSize-(mostSame+secMostSame)) * clip.channels];
						for(int i = 0; i < (bufferSize-(mostSame+secMostSame)); i++)
						{
							inputArray[i] = samples[i+reallast+1];
						}
						
						// Debug.Log(inputArray[0]);
						// Debug.Log(inputArray.Length);
						// Debug.Log(22050-(mostSame+secMostSame)-1);
						// Debug.Log(inputArray[22050-(mostSame+secMostSame)-1]);
						// Debug.Log(bufferSize-(mostSame+secMostSame));
						client.Predict(inputArray, error =>
							{
								// TODO: when i am not lazy
							});
						// Debug.Log("CASE 3");
						// client.Predict(inputArray);

					}
				}
				// Debug.Log("################################################");
				samples.CopyTo(oldsamples,0);
			}
			yield return new WaitForSeconds(1);
		}
		var LastinputArray = new float[100];
		for(int i = 0; i < 100; i++)
		{
			LastinputArray[i] = i;
		}
		client.Predict(LastinputArray, error => {});
		Debug.Log("CHECK FOR LAST SEND");
		spawn.CountLoop = StaticClass.FirstRoom;
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene("Result");
	}
}
