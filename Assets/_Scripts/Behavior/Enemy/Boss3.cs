using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
	public GameObject RegularBullet;
	public GameObject StraightBullet;
    public GameObject rotationBullet;
	public GameObject Explosion;
	public Vector2 movement;

    public GameObject attachedbullet;
    public float timeElapsed;
    Vector3 instantiatePos;	
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
        else if(timeElapsed%10 < .5) {
        	GameObject[] objects = GameObject.FindGameObjectsWithTag("rotate");
        	for (int i=0; i<objects.Length; i++){
    			Destroy(objects[i]);
			}
        }

        else if (timeElapsed%20<10 && timeElapsed>0){
        	movement.x = Movement.positionX - transform.position.x;
        	movement.y = Movement.positionY - transform.position.y;
        	movement.Normalize();
     		transform.Translate(movement * 1 * Time.deltaTime);
        	instantiatePos = transform.position + Vector3.right * 5;
            attachedbullet = Instantiate(rotationBullet, instantiatePos, Quaternion.identity);
            attachedbullet.transform.parent = transform;
            if(timeElapsed%1<.5) {
            	Instantiate(StraightBullet, transform.position, Quaternion.Euler(0,0,Random.Range(0,360)));
                Instantiate(RegularBullet, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            }


        }

        else {
        	movement.x = Movement.positionX - transform.position.x;
        	movement.y = Movement.positionY - transform.position.y;
        	movement.Normalize();
     		transform.Translate(movement * 3 * Time.deltaTime);
     		if(timer<0) {
	     		Instantiate(RegularBullet, transform.position, Quaternion.identity);
	     		Instantiate(Explosion, transform.position, Quaternion.Euler(0,0,Random.Range(0,360)));
	     			timer = .5f;			
     		}

        }
    }
}
