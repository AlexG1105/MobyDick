using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnipeBullet : MonoBehaviour
{

    public Vector2 movement;
    private float lifeTime;

    // Use this for initialization
    void Start()
    {
        movement.x = Movement.positionX - transform.position.x;
        movement.y = Movement.positionY - transform.position.y;
        lifeTime = 10;
    }

    // Update is called once per frame
    void Update()
    {

        movement.Normalize();
        transform.Translate(movement * 14 * Time.deltaTime);
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
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

