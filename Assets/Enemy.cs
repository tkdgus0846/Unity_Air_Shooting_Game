using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int type;
    public float hp = 5;
    public float speed = 3;
    void Start()
    {
       switch(type)
        {
            case 0:
                speed = 3; hp = 50;
                break;
            case 1:
                speed = 4; hp = 40;
                break;
            case 2:
                speed = 5; hp = 30;
                break;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
