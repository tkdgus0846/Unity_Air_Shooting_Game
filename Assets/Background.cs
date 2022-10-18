using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    SpriteRenderer spr;
    float sizeHalfX;
    public float speed=3;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        sizeHalfX = spr.bounds.size.x / 2;
    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
        Vector3 pos = transform.position;
        if (pos.x + sizeHalfX < -8)
        {
            pos.x += sizeHalfX * 4;
        }
        transform.position=pos;
    }
}
