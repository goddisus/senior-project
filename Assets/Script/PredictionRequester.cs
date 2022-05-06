using System;
using AsyncIO;
using NetMQ;
using NetMQ.Sockets;
using UnityEngine;

public class PredictionRequester : RunAbleThread
{
    private RequestSocket client;

    // private Action<float[]> onOutputReceived;
    private Action<Exception> onFail;
    
    protected override void Run()
    {
        ForceDotNet.Force(); // this line is needed to prevent unity freeze after one use, not sure why yet
        using (RequestSocket client = new RequestSocket())
        {
            this.client = client;
            client.Connect("tcp://localhost:60000");
            // Debug.Log("CHECK 1");
            while (Running)
            {
                // Debug.Log("CHECK 2");
                //byte[] outputBytes = new byte[0];
                string message = null;
                bool gotMessage = false;
                while (Running)
                {
                    try
                    {
                        // gotMessage = client.TryReceiveFrameBytes(out message); // this returns true if it's successful
                        gotMessage = client.TryReceiveFrameString(out message); // this returns true if it's successful
                        if (gotMessage) break;
                    }
                    catch (Exception e)
                    {
                    }
                }
                // Debug.Log("???????????");
                if (gotMessage)
                {
                    // var output = new float[outputBytes.Length / 4];
                    // Buffer.BlockCopy(outputBytes, 0, output, 0, outputBytes.Length);
                    // onOutputReceived?.Invoke(output);
                    Debug.Log("Received " + message);
                    if (message != "World")
                    {
                        StaticClass.CrossScenePredictInformation = message;
                    }
                }
            }
            
        }

        // Debug.Log("IS IT CLOSE?");
        NetMQConfig.Cleanup(); // this line is needed to prevent unity freeze after one use, not sure why yet
    }

    public void SendInput(float[] input)
    {
        try
        {
            // Debug.Log("SEND?");
            // Debug.Log(client);
            var byteArray = new byte[input.Length * 4];
            Buffer.BlockCopy(input, 0, byteArray, 0, byteArray.Length);
            client.SendFrame(byteArray);
            // client.SendFrame(input);
            Debug.Log("SUCCESS");
        }
        catch (Exception e)
        {
            Debug.Log("FAIL");
            string message = null;
            bool gotMessage = false;
            gotMessage = client.TryReceiveFrameString(out message); // this returns true if it's successful
            // onFail(e);
        }
    }

    // public void SetOnTextReceivedListener(Action<float[]> onOutputReceived, Action<Exception> fallback)
    // {
    //     this.onOutputReceived = onOutputReceived;
    //     onFail = fallback;
    // }
}