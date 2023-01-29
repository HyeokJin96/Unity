using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = default;

    private Rigidbody bulletRigidbody = default;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();

        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }   //  Start()

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //  ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                //  ���� PlayerController ������Ʈ�� Die() �޼��� ����
                playerController.Die();
            }   //  if : �������κ��� PlayerController ������Ʈ�� �������� �� �����ߴٸ�
        }   //  if : �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
    }   //  OnTriggerEnter()

    // Update is called once per frame
    void Update()
    {

    }   //  Update()
}
