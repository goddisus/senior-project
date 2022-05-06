using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CallPythonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (StaticClass.CallPythonScriptState == 0)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = Application.streamingAssetsPath + "/test.exe";
            // start.Arguments = string.Format("{0} {1}", cmd, args);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using(Process process = Process.Start(start))
            {
                // using(StreamReader reader = process.StandardOutput)
                // {
                //     string result = reader.ReadToEnd();
                //     Console.Write(result);
                // }
            }
            StaticClass.CallPythonScriptState = 1;
        }
    }

}
