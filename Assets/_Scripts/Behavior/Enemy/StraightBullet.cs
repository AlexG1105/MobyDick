using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : MonoBehaviour
{

    public Vector2 movement;
    private float lifeTime;

    // Use this for initialization
    void Start()
    {
        movement = new Vector2(1, 0);
        lifeTime = 15;
    }

    // Update is called once per frame
    void Update()
    {

        movement.Normalize();
        transform.Translate(movement * 10 * Time.deltaTime);
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