using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullsetSpawner : MonoBehaviour
{
    public GameObject bulletPrefab = default;
    public GameObject bulletSpawnerPrefab = default;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3.0f;

    private Transform target = default;
    private float spawnRate = default;
    private float timeAfterSpawn = default;

    // Start is called before the first frame update
    void Start()
    {
        //  최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;

        //  탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        //  PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = FindObjectOfType<PlayerController>().transform;
    }   //  Start()

    // Update is called once per frame
    void Update()
    {
        //  timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            //  누적된 시간을 리셋
            timeAfterSpawn = 0f;

            //  bulletPrefab 복제본을 transform.position 위치와 transform.rotation 회전으로 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            //  생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);
            bulletSpawnerPrefab.transform.LookAt(target);
        }   //  if : 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
    }   //  Update()
}
