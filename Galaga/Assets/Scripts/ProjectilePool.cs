using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public GameObject projectilePrefab; //  생성할 발사체의 원본 프리팹
    public int count;   //  생성할 발사체의 수
    private int currentIndex = 0;   //  현재 사용할 발사체의 순번
    private GameObject[] projectiles;    //  미리 생성한 발사체들
    public float attackRate;    //  공격 속도
    private Vector3 poolPosition = new Vector3(0f, 0f, -4.85f); //  위치

    // Start is called before the first frame update
    public void Start()
    {
        //  count만큼의 공간을 가지는 새로운 발사체 배열 생성
        projectiles = new GameObject[count];

        //  count만큼 루프하면서 발사체 생성
        for (int i = 0; i < count; i++ )
        {
            //  발사체를 poolPosition 위치에 복제 생성하여 projectile 배열에 할당
            projectiles[i] = Instantiate(projectilePrefab, poolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        projectiles[currentIndex].SetActive(false);
        projectiles[currentIndex].SetActive(true);

        projectiles[currentIndex].transform.position = poolPosition;

        currentIndex++;

        if (currentIndex >= count)
        {
            currentIndex = 0;
        }
    }
}
