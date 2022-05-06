using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using UnityEngine;
using UnityEngine.UI;

public class checkresult : MonoBehaviour
{
    // Start is called before the first frame update
    int CountCheckResult;
    int TrueChord = 0;
    int FalseChord = 0;
    public Text resultPercentage;

    // public Text TrueAresultPercentage;
    // public Text TrueCresultPercentage;
    // public Text TrueDresultPercentage;
    // public Text TrueEresultPercentage;
    // public Text TrueFresultPercentage;
    // public Text TrueGresultPercentage;
    
    // public Text FalseAresultPercentage;
    // public Text FalseCresultPercentage;
    // public Text FalseDresultPercentage;
    // public Text FalseEresultPercentage;
    // public Text FalseFresultPercentage;
    // public Text FalseGresultPercentage;

    
    [SerializeField]
    private GameObject TrueTextTemplate;
    
    [SerializeField]
    private GameObject FalseTextTemplate;

    int[] Chord;
    int[] PredictTrueChord;
    int[] PredictFalseChord;
    void Start()
    {
        // Debug.Log(StaticClass.CrossSceneInformation);
        
        // Debug.Log(StaticClass.CrossScenePredictInformation);
        CountCheckResult = StaticClass.FirstRoom*4;
        Debug.Log(CountCheckResult);
        string[] listStrLineElements = StaticClass.CrossScenePredictInformation.Split(' ');
        // Debug.Log(StaticClass.CrossSceneTrueInformation.Count);
		Chord = new int[7]{0,0,0,0,0,0,0};
		PredictTrueChord = new int[7]{0,0,0,0,0,0,0};
		PredictFalseChord = new int[7]{0,0,0,0,0,0,0};
        List<string> ChordList = new List<string>(){"A","Am","B","C","D","E","Em","F","G"};
        List<string> RealChord = new List<string>(){"A","B","C","D","E","Em","F","G","X"};
        List<string> NRealChord = new List<string>(){"A","B","C","D","E","F","G"};
		// for(int i = 0; i < 6; i++)
		// {
		// 	Chord[i] = 0;
		// 	PredictTrueChord[i] = 0;
		// 	PredictFalseChord[i] = 0;
		// }

        int [][] confused_mat = new int[8][];

        for (int i = 0  ; i < RealChord.Count ; i++)
        {
            // if (RealChord.IndexOf(ChordList[i]) == -1)
            // {
            //     continue;
            // }
            int CountCh = StaticClass.FirstRoom*4;
            int [] pre_confused = new int[7]{0,0,0,0,0,0,0};
            foreach (var chord in listStrLineElements)
            {
                if(chord == RealChord[i])
                {
                    if(RealChord.IndexOf(StaticClass.CrossSceneTrueInformation[CountCh]) == -1)
                    {
                        // if(ChordList.IndexOf(StaticClass.CrossSceneTrueInformation[CountCh]) != -1)
                        // {
                        //     pre_confused[(ChordList.IndexOf(StaticClass.CrossSceneTrueInformation[CountCh]))-1] = pre_confused[(ChordList.IndexOf(StaticClass.CrossSceneTrueInformation[CountCh]))-1] + 1;
                        // }
                        if(ChordList.IndexOf(StaticClass.CrossSceneTrueInformation[CountCh]) == 1)
                        {
                            pre_confused[0] = pre_confused[0] + 1;
                        }
                        else if(ChordList.IndexOf(StaticClass.CrossSceneTrueInformation[CountCh]) == 6)
                        {
                            pre_confused[4] = pre_confused[4] + 1;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if(RealChord.IndexOf(StaticClass.CrossSceneTrueInformation[CountCh]) > 4)
                        {
                            pre_confused[RealChord.IndexOf(StaticClass.CrossSceneTrueInformation[CountCh])-1] = pre_confused[RealChord.IndexOf(StaticClass.CrossSceneTrueInformation[CountCh])-1] + 1;
                        }
                        else
                        {
                            pre_confused[RealChord.IndexOf(StaticClass.CrossSceneTrueInformation[CountCh])] = pre_confused[RealChord.IndexOf(StaticClass.CrossSceneTrueInformation[CountCh])] + 1;
                        }
                    }
                }
                CountCh += 1;
                if(CountCh == (StaticClass.HowManyRoom*4)+(StaticClass.FirstRoom*4))
                {
                    break;
                }
            }
            if(i == 5)
            {
                for(int j = 0; j < 7; j++)
                {
                    confused_mat[4][j] += pre_confused[j];
                }
            }
            else if(i > 4)
            {
                confused_mat[i-1] = pre_confused;
            }
            else
            {
                confused_mat[i] = pre_confused;
            }
        }
        Debug.Log("Finist Calculate Confused Matrix");
        foreach (var chord in listStrLineElements)
        {
            if(chord == "")
            {
                // Debug.Log(chord);
                continue;
            }
            if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == chord)
            {
                TrueChord += 1;
                if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "A")
                {
                    Chord[0] = Chord[0] + 1;
                    PredictTrueChord[0] = PredictTrueChord[0] + 1;
                }
                else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "Am")
                {
                    Chord[0] = Chord[0] + 1;
                    PredictTrueChord[0] = PredictTrueChord[0] + 1;
                }
                else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "B")
                {
                    Chord[1] = Chord[1] + 1;
                    PredictTrueChord[1] = PredictTrueChord[1] + 1;
                }
                else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "C")
                {
                    Chord[2] = Chord[2] + 1;
                    PredictTrueChord[2] = PredictTrueChord[2] + 1;
                }
                else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "D")
                {
                    Chord[3] = Chord[3] + 1;
                    PredictTrueChord[3] = PredictTrueChord[3] + 1;
                }
                else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "E")
                {
                    Chord[4] = Chord[4] + 1;
                    PredictTrueChord[4] = PredictTrueChord[4] + 1;
                }
                else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "Em")
                {
                    Chord[4] = Chord[4] + 1;
                    PredictTrueChord[4] = PredictTrueChord[4] + 1;
                }
                else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "F")
                {
                    Chord[5] = Chord[5] + 1;
                    PredictTrueChord[5] = PredictTrueChord[5] + 1;
                }
                else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "G")
                {
                    Chord[6] = Chord[6] + 1;
                    PredictTrueChord[6] = PredictTrueChord[6] + 1;
                }
            }
            else
            {
                if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "E" & chord == "Em")
                {
                    TrueChord += 1;
                    Chord[4] = Chord[4] + 1;
                    PredictTrueChord[4] = PredictTrueChord[4] + 1;
                }
                else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "Em" & chord == "E")
                {
                    TrueChord += 1;
                    Chord[4] = Chord[4] + 1;
                    PredictTrueChord[4] = PredictTrueChord[4] + 1;
                }
                else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "A" & chord == "Am")
                {
                    TrueChord += 1;
                    Chord[0] = Chord[0] + 1;
                    PredictTrueChord[0] = PredictTrueChord[0] + 1;
                }
                else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "Am" & chord == "A")
                {
                    TrueChord += 1;
                    Chord[0] = Chord[0] + 1;
                    PredictTrueChord[0] = PredictTrueChord[0] + 1;
                }
                else
                {
                    FalseChord += 1;
                    if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "A")
                    {
                        Chord[0] = Chord[0] + 1;
                        PredictFalseChord[0] = PredictFalseChord[0] + 1;
                    }
                    else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "Am")
                    {
                        Chord[0] = Chord[0] + 1;
                        PredictFalseChord[0] = PredictFalseChord[0] + 1;
                    }
                    else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "B")
                    {
                        Chord[1] = Chord[1] + 1;
                        PredictFalseChord[1] = PredictFalseChord[1] + 1;
                    }
                    else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "C")
                    {
                        Chord[2] = Chord[2] + 1;
                        PredictFalseChord[2] = PredictFalseChord[2] + 1;
                    }
                    else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "D")
                    {
                        Chord[3] = Chord[3] + 1;
                        PredictFalseChord[3] = PredictFalseChord[3] + 1;
                    }
                    else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "E")
                    {
                        Chord[4] = Chord[4] + 1;
                        PredictFalseChord[4] = PredictFalseChord[4] + 1;
                    }
                    else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "Em")
                    {
                        Chord[4] = Chord[4] + 1;
                        PredictFalseChord[4] = PredictFalseChord[4] + 1;
                    }
                    else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "F")
                    {
                        Chord[5] = Chord[5] + 1;
                        PredictFalseChord[5] = PredictFalseChord[5] + 1;
                    }
                    else if(StaticClass.CrossSceneTrueInformation[CountCheckResult] == "G")
                    {
                        Chord[6] = Chord[6] + 1;
                        PredictFalseChord[6] = PredictFalseChord[6] + 1;
                    }
                }
            }
            CountCheckResult += 1;
            if(CountCheckResult == (StaticClass.HowManyRoom*4)+(StaticClass.FirstRoom*4))
            {
                break;
            }
        }
        // for(int i = 0 ; i < 6; i++)
        // {
        //     Debug.Log(Math.Round(((float) confused_mat[i][i]/Chord[i])*100,2));
        // }

        StaticClass.ChordCount = Chord;
        StaticClass.ConfusedMatrix = confused_mat;

        Debug.Log(TrueChord);
        Debug.Log(FalseChord);
        Debug.Log(CountCheckResult);
        float totalresult = TrueChord/CountCheckResult;
        Debug.Log((float) TrueChord/CountCheckResult*100);
        Debug.Log(totalresult*100);
        double percentageResult = Math.Round(((float) TrueChord/(StaticClass.HowManyRoom*4)*100),2);
        string gradeResult;
        if (percentageResult >= 90)
        {
            gradeResult = "S";
        }
        else if(percentageResult >= 80)
        {
            gradeResult = "A";
        }
        else if(percentageResult >= 70)
        {
            gradeResult = "B";
        }
        else if(percentageResult >= 60)
        {
            gradeResult = "C";
        }
        else if(percentageResult >= 50)
        {
            gradeResult = "D";
        }
        else
        {
            gradeResult = "F";
        }
        // resultPercentage.text = (Math.Round(((float) TrueChord/CountCheckResult*100),2)).ToString()+"%";
        resultPercentage.text = gradeResult;

        if(StaticClass.PlayMode == 0)
        {
            int MusicSelected = Int32.Parse(StaticClass.CrossSceneInformation)-1;
            float OldRecord = float.Parse(StaticClass.RecordInformation[MusicSelected]);

            
            if (percentageResult > OldRecord)
            {
                string jsonPath = Application.streamingAssetsPath + "/musiclistrecord.json";
            // read file as text
                string jsonStr = File.ReadAllText(jsonPath); // using System;
                MusicListRecordClass MusicListRecordDataInJson;

                MusicListRecordDataInJson = JsonUtility.FromJson<MusicListRecordClass>(jsonStr);

                MusicListRecordDataInJson.record[MusicSelected] = percentageResult.ToString();
                // WRITE TO JSON FILE TO SAVE NEW RECORD !!!

                // Serialize the object into JSON and save string.
                string jsonString = JsonUtility.ToJson(MusicListRecordDataInJson);

                // Write JSON to file.
                File.WriteAllText(Application.streamingAssetsPath + "/musiclistrecord.json", jsonString);
            }
        }

        // TRUE CASE
        for (int i = 0 ; i < 7 ; i++)
        {
            GameObject TruetextGO = Instantiate(TrueTextTemplate) as GameObject;
            GameObject FalsetextGO = Instantiate(FalseTextTemplate) as GameObject;

            TruetextGO.SetActive(true);
            FalsetextGO.SetActive(true);

            // TruetextGO.GetComponent<TrueChordListText>().SetText(Chord[i]);
            // FalsetextGO.GetComponent<FalseChordListText>().SetText(Chord[i]);

            TruetextGO.transform.SetParent(TrueTextTemplate.transform.parent, false);
            FalsetextGO.transform.SetParent(FalseTextTemplate.transform.parent, false);

            if(Chord[i] != 0)
            {
                // TrueAresultPercentage.text = (Math.Round(((float) PredictTrueChord[0]/Chord[0]*100),2)).ToString()+"%";
                // FalseAresultPercentage.text = (Math.Round(((float) PredictFalseChord[0]/Chord[0]*100),2)).ToString()+"%";

                TruetextGO.GetComponent<TrueChordListText>().SetText((Math.Round(((float) PredictTrueChord[i]/Chord[i]*100),2)).ToString()+"%");
                FalsetextGO.GetComponent<FalseChordListText>().SetText((Math.Round(((float) PredictFalseChord[i]/Chord[i]*100),2)).ToString()+"%");
            }
            else
            {
                TruetextGO.GetComponent<TrueChordListText>().SetText("-");
                FalsetextGO.GetComponent<FalseChordListText>().SetText("-");
            }
            // if(Chord[1] != 0)
            // {
            //     // TrueCresultPercentage.text = (Math.Round(((float) PredictTrueChord[1]/Chord[1]*100),2)).ToString()+"%";
            //     // FalseCresultPercentage.text = (Math.Round(((float) PredictFalseChord[1]/Chord[1]*100),2)).ToString()+"%";

            //     TruetextGO.GetComponent<TrueChordListText>().SetText((Math.Round(((float) PredictTrueChord[1]/Chord[1]*100),2)).ToString()+"%");
            //     FalsetextGO.GetComponent<FalseChordListText>().SetText((Math.Round(((float) PredictFalseChord[1]/Chord[1]*100),2)).ToString()+"%");
            // }
            // else
            // {
            //     TruetextGO.GetComponent<TrueChordListText>().SetText("-");
            //     FalsetextGO.GetComponent<FalseChordListText>().SetText("-");
            // }
            // if(Chord[2] != 0)
            // {
            //     // TrueDresultPercentage.text = (Math.Round(((float) PredictTrueChord[2]/Chord[2]*100),2)).ToString()+"%";
            //     // FalseDresultPercentage.text = (Math.Round(((float) PredictFalseChord[2]/Chord[2]*100),2)).ToString()+"%";

            //     TruetextGO.GetComponent<TrueChordListText>().SetText((Math.Round(((float) PredictTrueChord[2]/Chord[2]*100),2)).ToString()+"%");
            //     FalsetextGO.GetComponent<FalseChordListText>().SetText((Math.Round(((float) PredictFalseChord[2]/Chord[2]*100),2)).ToString()+"%");
            // }
            // else
            // {
            //     TruetextGO.GetComponent<TrueChordListText>().SetText("-");
            //     FalsetextGO.GetComponent<FalseChordListText>().SetText("-");
            // }
            // if(Chord[3] != 0)
            // {
            //     // TrueEresultPercentage.text = (Math.Round(((float) PredictTrueChord[3]/Chord[3]*100),2)).ToString()+"%";
            //     // FalseEresultPercentage.text = (Math.Round(((float) PredictFalseChord[3]/Chord[3]*100),2)).ToString()+"%";

            //     TruetextGO.GetComponent<TrueChordListText>().SetText((Math.Round(((float) PredictTrueChord[3]/Chord[3]*100),2)).ToString()+"%");
            //     FalsetextGO.GetComponent<FalseChordListText>().SetText((Math.Round(((float) PredictFalseChord[3]/Chord[3]*100),2)).ToString()+"%");
            // }
            // else
            // {
            //     TruetextGO.GetComponent<TrueChordListText>().SetText("-");
            //     FalsetextGO.GetComponent<FalseChordListText>().SetText("-");
            // }
            // if(Chord[4] != 0)
            // {
            //     // TrueFresultPercentage.text = (Math.Round(((float) PredictTrueChord[4]/Chord[4]*100),2)).ToString()+"%";
            //     // FalseFresultPercentage.text = (Math.Round(((float) PredictFalseChord[4]/Chord[4]*100),2)).ToString()+"%";

            //     TruetextGO.GetComponent<TrueChordListText>().SetText((Math.Round(((float) PredictTrueChord[4]/Chord[4]*100),2)).ToString()+"%");
            //     FalsetextGO.GetComponent<FalseChordListText>().SetText((Math.Round(((float) PredictFalseChord[4]/Chord[4]*100),2)).ToString()+"%");
            // }
            // else
            // {
            //     TruetextGO.GetComponent<TrueChordListText>().SetText("-");
            //     FalsetextGO.GetComponent<FalseChordListText>().SetText("-");
            // }
            // if(Chord[5] != 0)
            // {
            //     // TrueGresultPercentage.text = (Math.Round(((float) PredictTrueChord[5]/Chord[5]*100),2)).ToString()+"%";
            //     // FalseGresultPercentage.text = (Math.Round(((float) PredictFalseChord[5]/Chord[5]*100),2)).ToString()+"%";

            //     TruetextGO.GetComponent<TrueChordListText>().SetText((Math.Round(((float) PredictTrueChord[5]/Chord[5]*100),2)).ToString()+"%");
            //     FalsetextGO.GetComponent<FalseChordListText>().SetText((Math.Round(((float) PredictFalseChord[5]/Chord[5]*100),2)).ToString()+"%");
            // }
            // else
            // {
            //     TruetextGO.GetComponent<TrueChordListText>().SetText("-");
            //     FalsetextGO.GetComponent<FalseChordListText>().SetText("-");
            // }

        }
        // FALSE CASE

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
