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
        //  ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� playerRigidbody�� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>();
    }   //  Start()

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }   //  if : ���� ����Ű �Է��� ������ ��� z ���� �� �ֱ�
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }   //  if : �Ʒ��� ����Ű �Է��� ������ ��� -z ���� �� �ֱ�
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }   //  if : ������ ����Ű �Է��� ������ ��� x ���� �� �ֱ�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }   //  if : ���� ����Ű �Է��� ������ ��� -x ���� �� �ֱ�

        //  ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //  ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //  Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;
    }   //  Update()

    public void Die()
    {
        //  �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        //  ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager = FindObjectOfType<GameManager>();

        //  ������ GameManager ������Ʈ�� EndGame() �޼��� ����
        gameManager.EndGame();
    }   //  Die()
}
