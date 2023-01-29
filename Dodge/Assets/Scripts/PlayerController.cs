using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody = default;

    public float speed = default;

    // Start is called before the first frame update
    void Start()
    {
        //  게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }   //  Start()

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }   //  if : 위쪽 방향키 입력이 감지된 경우 z 방향 힘 주기
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }   //  if : 아래쪽 방향키 입력이 감지된 경우 -z 방향 힘 주기
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }   //  if : 오른쪽 방향키 입력이 감지된 경우 x 방향 힘 주기
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }   //  if : 왼쪽 방향키 입력이 감지된 경우 -x 방향 힘 주기

        //  수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //  실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //  Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;
    }   //  Update()

    public void Die()
    {
        //  자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        //  씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();

        //  가져온 GameManager 오브젝트의 EndGame() 메서드 실행
        gameManager.EndGame();
    }   //  Die()
}
