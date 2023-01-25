using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public float speed; //  발사체의 속도
    private Rigidbody projectileRigidbody;  //  이동에 사용할 Rigidbody 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        //  게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        projectileRigidbody = GetComponent<Rigidbody>();

        //  Rigidbody의 속도 = 앞쪽 방향 * 속도
        projectileRigidbody.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
