using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : MonoBehaviour
{
	public Vector2 movement;
    private float lifeTime;
    private float randomNumber;
    // Start is called before the first frame update
    void Start()
    {
    	randomNumber = Random.Range(-3.0f, 3);
        lifeTime = 10;
        movement.x = Movement.positionX - transform.position.x + randomNumber;
        movement.y = Movement.positionY - transform.position.y + randomNumber;
    }

    // Update is called once per frame
    void Update()
    {
    	movement.Normalize();
    	transform.Translate(movement * Random.Range(17,20) * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if(lifeTime<0) {
        	Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //ExitDoor.updatedLevel;

        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().hurtPlayer(2);
            Destroy(gameObject);
        }
        if (other.tag == "boundary")
        {
            Destroy(gameObject);
        }
    }    
}
