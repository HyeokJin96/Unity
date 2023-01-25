using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;

    public Rigidbody playerRigidbody;   //  �̵��� ����� Rigidbody ������Ʈ
    public float speed; //  �̵� �ӷ�

    public GameObject PlayerProjectilePrefab; //  ������ �߻�ü�� ���� ������
    public int count;   //  ������ �߻�ü�� ��
    public float fireRate = 0.1f;   //  ���� ���� �ֱ�
    public float xValue = 0f;
    public float Z_VALUE = -4.8f;

    private int currentIndex = 0;   //  ���� ����� �߻�ü�� ����
    private GameObject[] playerProjectiles;    //  �̸� ������ �߻�ü��
    private Vector3 projectilePosition = new Vector3(0f, 0f, -4.2f);
    private float timeAfterSpawn = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //  ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� player����body�� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>();

        //  count��ŭ�� ������ ������ ���ο� �߻�ü �迭 ����
        playerProjectiles = new GameObject[count];

        //  count��ŭ �����ϸ鼭 �߻�ü ����
        for (int i = 0; i < count; i++)
        {
            //  �߻�ü�� poolPosition ��ġ�� ���� �����Ͽ� projectile �迭�� �Ҵ�
            playerProjectiles[i] = Instantiate(PlayerProjectilePrefab, projectilePosition, Quaternion.identity);
            PlayerProjectilePrefab.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        //  �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");

        //  ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;

        //  Vector3 �ӵ��� (xSpeed, 0f, 0f)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, 0f);

        //  Rigidbody �ӵ��� newVelocity �Ҵ�
        playerRigidbody.velocity = newVelocity;

        timeAfterSpawn += Time.deltaTime;

        // ������ ����Ű �Է��� ������ ��� x �������� �̵�
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        //  ���� ����Ű �Է��� ������ ��� -x �������� �̵�
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fireRate <= timeAfterSpawn)
            {
                timeAfterSpawn = 0f;

                if (currentIndex >= count)
                {
                    currentIndex = 0;
                }

                xValue = gameObject.transform.position.x;

                playerProjectiles[currentIndex].transform.position = new Vector3(xValue - 0.15f, 0, Z_VALUE);
                playerProjectiles[currentIndex].transform.rotation = Quaternion.Euler(90, 0, 0);
                playerProjectiles[currentIndex].SetActive(true);
                currentIndex++;

                playerProjectiles[currentIndex].transform.position = new Vector3(xValue + 0.15f, 0, Z_VALUE);
                playerProjectiles[currentIndex].transform.rotation = Quaternion.Euler(90, 0, 0);
                playerProjectiles[currentIndex].SetActive(true);

                currentIndex++;
            }
        }
    }

    // �÷��̾��� �̵� ����
    private void LateUpdate()
    {
        //  �÷��̾� ĳ���Ͱ� ȭ�� ���� �ٱ����� ������ ���ϰ� ��
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x), 0f, Mathf.Clamp(transform.position.z, stageData.LimitMin.z, stageData.LimitMax.z));
    }
}
