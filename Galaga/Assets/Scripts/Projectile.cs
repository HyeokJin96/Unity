using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public float speed; //  �߻�ü�� �ӵ�
    private Rigidbody projectileRigidbody;  //  �̵��� ����� Rigidbody ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        //  ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        projectileRigidbody = GetComponent<Rigidbody>();

        //  Rigidbody�� �ӵ� = ���� ���� * �ӵ�
        projectileRigidbody.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
