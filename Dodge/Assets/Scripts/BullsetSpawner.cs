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
        //  �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;

        //  ź�� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        //  PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        target = FindObjectOfType<PlayerController>().transform;
    }   //  Start()

    // Update is called once per frame
    void Update()
    {
        //  timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            //  ������ �ð��� ����
            timeAfterSpawn = 0f;

            //  bulletPrefab �������� transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            //  ������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);
            bulletSpawnerPrefab.transform.LookAt(target);
        }   //  if : �ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
    }   //  Update()
}
