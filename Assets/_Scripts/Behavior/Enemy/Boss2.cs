using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
	public GameObject RegularBullet;
	public GameObject Explosion;
	public Vector2 movement;

	private float timeElapsed;
	private float timer;



    // Start is called before the first frame update
    void Start()
    {
    	timeElapsed = 0;
        timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	timer -= Time.deltaTime;
        timeElapsed += Time.deltaTime;
        if(timeElapsed <3) {

        }

        if (timeElapsed > 180) {
        	Instantiate(Explosion, transform.position, Quaternion.Euler(0,0,Random.Range(0,360)));
        }

        else {
        	movement.x = Movement.positionX - transform.position.x;
        	movement.y = Movement.positionY - transform.position.y;
        	movement.Normalize();
     		transform.Translate(movement * 2 * Time.deltaTime);
     		if(timer<0) {
	     		if(Mathf.Abs(Movement.positionX - transform.position.x) < .5  || Mathf.Abs(Movement.positionY - transform.position.y) < .5) {
	     			Instantiate(Explosion, transform.position, Quaternion.identity);
	     			Instantiate(RegularBullet, transform.position, Quaternion.identity);
	     			timer = 0.4f;
	     		}
	     		else{
	     			Instantiate(RegularBullet, transform.position, Quaternion.identity);
	     			timer = .18f;
	     		}   			
     		}

        }
    }
}
