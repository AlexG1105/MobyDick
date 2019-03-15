using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBomb : MonoBehaviour
{

    public Vector2 movement;
    private float lifeTime;
    public float speed;
    public GameObject fragments;

    // Use this for initialization
    void Start()
    {
        float randomNumber = Random.Range(-2.0f, 2.0f);
        movement.x = Movement.positionX - transform.position.x + randomNumber;
        movement.y = Movement.positionY - transform.position.y + randomNumber;
        lifeTime = 0.8f;
        speed = Random.Range(11f, 13f);
    }

    // Update is called once per frame
    void Update()
    {

        movement.Normalize();
        transform.Translate(movement * speed * Time.deltaTime);
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            for (int i = 0; i < 360; i += Random.Range(20, 35))
            {
                Instantiate(fragments, transform.position, Quaternion.Euler(0, 0, i));
            }
            Destroy(gameObject);
        }
    }
}
