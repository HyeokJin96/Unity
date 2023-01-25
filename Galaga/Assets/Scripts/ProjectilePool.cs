using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public GameObject projectilePrefab; //  ������ �߻�ü�� ���� ������
    public int count;   //  ������ �߻�ü�� ��
    private int currentIndex = 0;   //  ���� ����� �߻�ü�� ����
    private GameObject[] projectiles;    //  �̸� ������ �߻�ü��
    public float attackRate;    //  ���� �ӵ�
    private Vector3 poolPosition = new Vector3(0f, 0f, -4.85f); //  ��ġ

    // Start is called before the first frame update
    public void Start()
    {
        //  count��ŭ�� ������ ������ ���ο� �߻�ü �迭 ����
        projectiles = new GameObject[count];

        //  count��ŭ �����ϸ鼭 �߻�ü ����
        for (int i = 0; i < count; i++ )
        {
            //  �߻�ü�� poolPosition ��ġ�� ���� �����Ͽ� projectile �迭�� �Ҵ�
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
