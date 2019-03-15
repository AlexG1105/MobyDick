using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBomb : MonoBehaviour
{
    public GameObject fragment;
    public Vector2 movement;
    private float lifeTime;

    // Use this for initialization
    void Start()
    {
        lifeTime = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Movement.positionX - transform.position.x;
        movement.y = Movement.positionY - transform.position.y;

        movement.Normalize();
        transform.Translate(movement * 4 * Time.deltaTime);
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            for (int i = 0; i < 360; i += Random.Range(20, 40))
            {
                Instantiate(fragment, transform.position, Quaternion.Euler(0, 0, i));
            }

            Destroy(gameObject);
        }
    }
}