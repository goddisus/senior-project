using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody2D rb;
    private void FixedUpdate() {
	if(transform.position.x < -8){
            	transform.position = new Vector2 (8 , transform.position.y);
        }
	//transform.Translate(new Vector2 (-1f, 0f)* Time.deltaTime);
	rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-16, 0);
    }
}
