using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputText: MonoBehaviour{


    // [SerializeField]
    
    // private Text myText;
    public GameObject InvalidInput;

    public SelectMusicRange SelectMusicRangeObj = null;

    int[] numbers = new int[10]{0,1,2,3,4,5,6,7,8,9};
    void Start ()
    {
	    gameObject.GetComponent<InputField>().onValueChanged.AddListener(delegate {ValueChanged(); });
	    // gameObject.GetComponent<Button>().onClick.AddListener(ValueChanged);
		// ATextGO.SetActive(true);

    }

    void Update () 
    {

    }

    private void ValueChanged()
    {
        // Debug.Log(gameObject.GetComponent<InputField>().text.Length);
        if(gameObject.GetComponent<InputField>().text.Length > 0)
        {
            try
            {
                int s = (Int32.Parse(gameObject.GetComponent<InputField>().text));
                InvalidInput.SetActive(false);
                SelectMusicRangeObj.ValidateInput();
            }
            catch (Exception e)
            {
                // Debug.Log("Invalid Input");
                InvalidInput.SetActive(true);
                SelectMusicRangeObj.ValidateInput();
            }
        }
        else
        {
            InvalidInput.SetActive(false);
            SelectMusicRangeObj.ValidateInput();
        }
    }
}