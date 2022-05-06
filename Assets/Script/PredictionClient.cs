using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PredictionClient : MonoBehaviour
{
    private PredictionRequester predictionRequester;

    private void Start() => InitializeServer();

    public void InitializeServer()
    {
        predictionRequester = new PredictionRequester();
        predictionRequester.Start();
        // Debug.Log("Initialize Successful");
    }

    // public void Predict(float[] input, Action<float[]> onOutputReceived, Action<Exception> fallback)
    // {
    //     // predictionRequester.SetOnTextReceivedListener(onOutputReceived, fallback);
    //     predictionRequester.SendInput(input);
    // }

    public void Predict(float[] input, Action<Exception> fallback)
    {
        // predictionRequester.SetOnTextReceivedListener(onOutputReceived, fallback);
        predictionRequester.SendInput(input);
    }
    
    // public void Predict(String input, Action<Exception> fallback)
    // {
    //     // predictionRequester.SetOnTextReceivedListener(onOutputReceived, fallback);
    //     predictionRequester.SendInput(input);
    // }

    private void OnDestroy()
    {
        predictionRequester.Stop();
    }
}