using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public float amount = 2;
    public float speed = 5;

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
