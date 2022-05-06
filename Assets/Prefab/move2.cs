using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move2 : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public float speed = 10.0f;


    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb.velocity = new Vector2(screenBounds.x*-0.4f, 0);
	//Debug.Log((float) screenBounds.x*-2);
    }

    // Update is called once per frame
    void Update () {
        if(transform.position.x < screenBounds.x * -2){
            Destroy(this.gameObject);
        }
        // if(transform.position.x < -7){
        //     Debug.Log(timer.currentTime);
        //     spawn.CountLoop = 0;
        //     timer.currentTime = 0;
	    //     SceneManager.LoadScene("select");
        // }
    }
}