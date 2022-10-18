using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManagerScript gameManager;
    public Transform shotPostr;
    public GameObject shot;
    public GameObject destroyEffect;
    public GameObject shootEffect;
    public GameObject shootSmokeEffect;

    public float speed = 6;
    float time = 0;
    public float shotMax = 0.1f;
    public List<Sprite> sprites;
    float rotate = 0.0f;
    Vector3 colSize;
    Vector3 chrSize;

    void Start()
    {
        //Vector3 pos1=Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        colSize = GetComponent<Collider2D>().bounds.size;
        chrSize = new Vector3(colSize.x / 2, colSize.y / 2);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        
    }

    void Update()
    {
        float w = Input.GetAxisRaw("Horizontal");
        float h = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(w, h, 0).normalized;

        transform.position += dir * Time.deltaTime * speed;
        Vector3 pos = transform.position;

        // 최소 최대 범위 설정
        pos.x=Mathf.Clamp(pos.x, -8 + chrSize.x, 8 - chrSize.x);
        pos.y=Mathf.Clamp(pos.y, -4.5f + chrSize.y, 4.5f - chrSize.y);

        transform.position = pos;
        time += Time.deltaTime;

        if (time > shotMax && Input.GetButton("Fire1"))
        {
            // 리스트로 스프라이트렌더러를 받아서 총알 객체를 생성한다음 이미지를 바꿔준다
            GameObject obj = Instantiate(shot, shotPostr.position, Quaternion.identity);
            obj.GetComponent<SpriteRenderer>().sprite = sprites[1];

            GameObject shotEffect = Instantiate(shootEffect, shotPostr.position, Quaternion.identity);

            Vector3 shotSmokePostr = shotPostr.position;
            shotSmokePostr.x -= 0.5f;
            GameObject shotSmokeEffect = Instantiate(shootSmokeEffect, shotSmokePostr, Quaternion.identity);
            shotEffect.transform.parent = transform;
            shotSmokeEffect.transform.parent = transform;
            time = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Asteroid" || other.gameObject.tag == "Enemy")
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

            GameManagerScript.instance.gameOverPanel.SetActive(true);
        }

        if (other.gameObject.tag == "Item")
        {
            ItemScript itemScript = other.GetComponent<ItemScript>();
            GameManagerScript.instance.coin += itemScript.amount;
            GameManagerScript.instance.coinText.text = GameManagerScript.instance.coin.ToString();
            Destroy(other.gameObject);

            for (float d=3.5f;d>-4.5 ;d--)
            {
                Instantiate(shot, new Vector3(-8, d), Quaternion.identity);
            }
        }
    }
}
