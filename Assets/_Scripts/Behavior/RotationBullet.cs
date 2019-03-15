using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBullet : MonoBehaviour
{

    float mouseX;
    float mouseY;
    Vector2 mouseDirection;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        float positionX = Movement.mousepositionX;
        float positionY = Movement.mousepositionY;

        mouseX = Input.mousePosition.x - positionX;
        mouseY = Input.mousePosition.y - positionY;

        mouseDirection = new Vector2(mouseX, mouseY);

        if (Vector2.Angle(new Vector2(0, 1), mouseDirection) < 90f)
        {
            sprite.transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(new Vector2(1, 0), mouseDirection));
        }
        else
        {
            sprite.transform.rotation = Quaternion.Euler(0, 0, 360 - Vector2.Angle(new Vector2(1, 0), mouseDirection));
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}