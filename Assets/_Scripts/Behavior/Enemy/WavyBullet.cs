using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavyBullet : MonoBehaviour
{

    public Vector2 movement;
    private float lifeTime;
    private float normalX;
    private float normalY;
    private float inverseX;
    private float inverseY;
    private float counter;

    // Use this for initialization
    void Start()
    {
        normalX = 1;
        normalY = 0;
        inverseX = normalY * -1;
        inverseY = normalX;
        counter = Random.Range(1, 10);
        lifeTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = normalX + (inverseX * Mathf.Sin(counter));
        movement.y = normalY + (inverseY * Mathf.Sin(counter));
        movement.Normalize();
        transform.Translate(movement * 10 * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        counter = counter + 0.1f;
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