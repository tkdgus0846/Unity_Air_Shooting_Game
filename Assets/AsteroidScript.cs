using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    Vector3 angle = Vector3.zero;
    public float rotSpeed = 10;
    public float speed = 3;
    public int hp = 10;
    public int asteroidNum=1;

    void Start()
    {
        //소행성의 색깔을 SpriteRenderer 컴포넌트로 받아서 빨간색으로 정해줌.
        GetComponent<SpriteRenderer>().material.color = Color.red;
    }

    void Update()
    {
        //부모 자식 관계일 경우에, 자식은 로컬 좌표계를 사용한다.
        //Space.World= 월드 좌표계, Space.Self= 로컬 좌표계 사용
        //Translate 메소드는 default로 월드 좌표계 사용
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotSpeed*20));
      }

    private void OnBecameInvisible() // scene 뷰에서 사라져야 없어지는걸로 보임
    {
        Destroy(gameObject);
    }
}
