using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    private float lifeTime;
    private Vector2 movement;
    private object bullet;

    // Use this for initialization
    void Start()
    {

        float positionX = Movement.mousepositionX;
        float positionY = Movement.mousepositionY;

        mouseX = Input.mousePosition.x - positionX;
        mouseY = Input.mousePosition.y - positionY;

        movement = new Vector2(mouseX, mouseY);

        lifeTime = 0.7f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 19f);

        movement.Normalize();
        transform.Translate(movement * 20 * Time.deltaTime);
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
}