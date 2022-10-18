using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotScript : MonoBehaviour
{
    public GameObject effectFx02;
    public GameObject effectFx03;
    public GameObject coin;
    public float speed = 8;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            AsteroidScript asteroidScript = col.GetComponent<AsteroidScript>();
            asteroidScript.hp -= 4;
            Destroy(gameObject);

            if (asteroidScript.hp < 0)
            {
                Destroy(col.gameObject);
                Vector3 coinPos = transform.position;
                coinPos.x += 1;
                Instantiate(coin, coinPos, Quaternion.identity);
                Instantiate(effectFx02, transform.position, Quaternion.identity);
            }
        }
        else if (col.gameObject.tag == "Enemy")
        {
            Enemy enemy = col.GetComponent<Enemy>();
            enemy.hp -= 4;
            Destroy(gameObject);

            if (enemy.hp < 0)
            {
                Destroy(col.gameObject);
                
                Instantiate(effectFx02, transform.position, Quaternion.identity);
            }
        }
        Instantiate(effectFx03, transform.position, Quaternion.identity);
    }
}
