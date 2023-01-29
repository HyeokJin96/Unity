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
            //  상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                //  상대방 PlayerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();
            }   //  if : 상대방으로부터 PlayerController 컴포넌트를 가져오는 데 성공했다면
        }   //  if : 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
    }   //  OnTriggerEnter()

    // Update is called once per frame
    void Update()
    {

    }   //  Update()
}
