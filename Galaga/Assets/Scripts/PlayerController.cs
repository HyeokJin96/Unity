using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;

    public Rigidbody playerRigidbody;   //  이동에 사용할 Rigidbody 컴포넌트
    public float speed; //  이동 속력

    public GameObject PlayerProjectilePrefab; //  생성할 발사체의 원본 프리팹
    public int count;   //  생성할 발사체의 수
    public float fireRate = 0.1f;   //  최초 생성 주기
    public float xValue = 0f;
    public float Z_VALUE = -4.8f;

    private int currentIndex = 0;   //  현재 사용할 발사체의 순번
    private GameObject[] playerProjectiles;    //  미리 생성한 발사체들
    private Vector3 projectilePosition = new Vector3(0f, 0f, -4.2f);
    private float timeAfterSpawn = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //  게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 player꺄향body에 할당
        playerRigidbody = GetComponent<Rigidbody>();

        //  count만큼의 공간을 가지는 새로운 발사체 배열 생성
        playerProjectiles = new GameObject[count];

        //  count만큼 루프하면서 발사체 생성
        for (int i = 0; i < count; i++)
        {
            //  발사체를 poolPosition 위치에 복제 생성하여 projectile 배열에 할당
            playerProjectiles[i] = Instantiate(PlayerProjectilePrefab, projectilePosition, Quaternion.identity);
            PlayerProjectilePrefab.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        //  수평축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");

        //  실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;

        //  Vector3 속도를 (xSpeed, 0f, 0f)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, 0f);

        //  Rigidbody 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;

        timeAfterSpawn += Time.deltaTime;

        // 오른쪽 방향키 입력이 감지된 경우 x 방향으로 이동
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        //  왼쪽 방향키 입력이 감지된 경우 -x 방향으로 이동
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

    // 플레이어의 이동 제한
    private void LateUpdate()
    {
        //  플레이어 캐릭터가 화면 범위 바깥으로 나가지 못하게 함
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x), 0f, Mathf.Clamp(transform.position.z, stageData.LimitMin.z, stageData.LimitMax.z));
    }
}
