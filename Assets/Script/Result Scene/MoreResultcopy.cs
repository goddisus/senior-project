using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using UnityEngine;
using UnityEngine.UI;

public class MoreResultcopy : MonoBehaviour
{
    
    [SerializeField]
    private GameObject VerticalTextTemplate;

    [SerializeField]
    private GameObject HorizontalTextTemplate;

    [SerializeField]
    private GameObject TextTemplateA;
    
    [SerializeField]
    private GameObject TextTemplateC;
    
    [SerializeField]
    private GameObject TextTemplateD;
    
    [SerializeField]
    private GameObject TextTemplateE;
    
    [SerializeField]
    private GameObject TextTemplateF;
    
    [SerializeField]
    private GameObject TextTemplateG;


    List<string> Chord = new List<string>(){"A","C","D","E","F","G"};
    void Start()
    {
        // Debug.Log(Chord.IndexOf("Z"));
		for (int i = 0; i < Chord.Count; i++)
		{
			GameObject VerticalTextGO = Instantiate(VerticalTextTemplate) as GameObject;
			GameObject HorizontalTextGO = Instantiate(HorizontalTextTemplate) as GameObject;

			VerticalTextGO.SetActive(true);
			HorizontalTextGO.SetActive(true);
			// button.SetActive(true);
			VerticalTextGO.GetComponent<ChordListText>().SetText(Chord[i]);
			HorizontalTextGO.GetComponent<ChordListText>().SetText(Chord[i]);

			VerticalTextGO.transform.SetParent(VerticalTextTemplate.transform.parent, false);
			HorizontalTextGO.transform.SetParent(HorizontalTextTemplate.transform.parent, false);
		}
        for(int i = 0; i < Chord.Count; i++)
        {
			GameObject ATextGO = Instantiate(TextTemplateA) as GameObject;
			GameObject CTextGO = Instantiate(TextTemplateC) as GameObject;
			GameObject DTextGO = Instantiate(TextTemplateD) as GameObject;
			GameObject ETextGO = Instantiate(TextTemplateE) as GameObject;
			GameObject FTextGO = Instantiate(TextTemplateF) as GameObject;
			GameObject GTextGO = Instantiate(TextTemplateG) as GameObject;

			ATextGO.SetActive(true);
			CTextGO.SetActive(true);
			DTextGO.SetActive(true);
			ETextGO.SetActive(true);
			FTextGO.SetActive(true);
			GTextGO.SetActive(true);

            // Debug.Log(Math.Round(((float) confused_mat[i][i]/Chord[i])*100,2));
            // Math.Round(((float) StaticClass.ConfusedMatrix[0][i]/StaticClass.ChordCount[i])*100,2)
            if(StaticClass.ChordCount[i] != 0)
            {
                if(i == 0)
                {
                    ATextGO.GetComponent<ChordListTextWithColor>().SetText((Math.Round(((float) StaticClass.ConfusedMatrix[0][i]/StaticClass.ChordCount[i])*100,2)).ToString()+"%","green");
                }
                else
                {
                    ATextGO.GetComponent<ChordListTextWithColor>().SetText((Math.Round(((float) StaticClass.ConfusedMatrix[0][i]/StaticClass.ChordCount[i])*100,2)).ToString()+"%","red");
                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                if(i == 1)
                {
			        CTextGO.GetComponent<ChordListTextWithColor>().SetText((Math.Round(((float) StaticClass.ConfusedMatrix[1][i]/StaticClass.ChordCount[i])*100,2)).ToString()+"%","green");
                }
                else
                {
			        CTextGO.GetComponent<ChordListTextWithColor>().SetText((Math.Round(((float) StaticClass.ConfusedMatrix[1][i]/StaticClass.ChordCount[i])*100,2)).ToString()+"%","red");
                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                if(i == 2)
                {
			        DTextGO.GetComponent<ChordListTextWithColor>().SetText((Math.Round(((float) StaticClass.ConfusedMatrix[2][i]/StaticClass.ChordCount[i])*100,2)).ToString()+"%","green");
                }
                else
                {
			        DTextGO.GetComponent<ChordListTextWithColor>().SetText((Math.Round(((float) StaticClass.ConfusedMatrix[2][i]/StaticClass.ChordCount[i])*100,2)).ToString()+"%","red");
                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                if(i == 3)
                {
			        ETextGO.GetComponent<ChordListTextWithColor>().SetText((Math.Round(((float) StaticClass.ConfusedMatrix[3][i]/StaticClass.ChordCount[i])*100,2)).ToString()+"%","green");
                }
                else
                {
			        ETextGO.GetComponent<ChordListTextWithColor>().SetText((Math.Round(((float) StaticClass.ConfusedMatrix[3][i]/StaticClass.ChordCount[i])*100,2)).ToString()+"%","red");
                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                if(i == 4)
                {
			        FTextGO.GetComponent<ChordListTextWithColor>().SetText((Math.Round(((float) StaticClass.ConfusedMatrix[4][i]/StaticClass.ChordCount[i])*100,2)).ToString()+"%","green");
                }
                else
                {
			        FTextGO.GetComponent<ChordListTextWithColor>().SetText((Math.Round(((float) StaticClass.ConfusedMatrix[4][i]/StaticClass.ChordCount[i])*100,2)).ToString()+"%","red");
                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                if(i == 5)
                {
			        GTextGO.GetComponent<ChordListTextWithColor>().SetText((Math.Round(((float) StaticClass.ConfusedMatrix[5][i]/StaticClass.ChordCount[i])*100,2)).ToString()+"%","green");
                }
                else
                {
			        GTextGO.GetComponent<ChordListTextWithColor>().SetText((Math.Round(((float) StaticClass.ConfusedMatrix[5][i]/StaticClass.ChordCount[i])*100,2)).ToString()+"%","red");
                }
            }
            else
            {
                //
            }

			ATextGO.transform.SetParent(TextTemplateA.transform.parent, false);
			CTextGO.transform.SetParent(TextTemplateC.transform.parent, false);
			DTextGO.transform.SetParent(TextTemplateD.transform.parent, false);
			ETextGO.transform.SetParent(TextTemplateE.transform.parent, false);
			FTextGO.transform.SetParent(TextTemplateF.transform.parent, false);
			GTextGO.transform.SetParent(TextTemplateG.transform.parent, false);
        }
    }

    void Update()
    {

    }
}
