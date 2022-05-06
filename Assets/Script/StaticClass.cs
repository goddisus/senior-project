using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticClass : MonoBehaviour
{
    // Start is called before the first frame update
    public static string CrossSceneInformation {get; set;}
    
    public static List<string> CrossSceneTrueInformation {get; set;}
    
    public static string CrossScenePredictInformation {get; set;}

    public static List<string> RecordInformation {get; set;}
    
    public static int[] ChordCount {get; set;}
    
    public static int[][] ConfusedMatrix {get; set;}

    public static int PlayMode {get;set;}

    public static float FirstBeat {get;set;}

    public static int FirstRoom {get;set;}

    public static int LastRoom {get;set;}

    public static int HowManyRoom {get;set;}

    public static float MusicTempo {get;set;}

    public static int TagForOpenMusic {get;set;}

    public static int MusicRangeSample {get;set;}
    
    public static int CallPythonScriptState {get;set;}
}
