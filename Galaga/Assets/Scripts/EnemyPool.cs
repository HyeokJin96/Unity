using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject GalaxianPrefab;
    public int count;
    public float spawnRate = 0.1f;
    public float Z_VALUE = 0f;

    private int currentIndex = 0;
    private GameObject[] enemmys;
    private Vector3 enemyPosition = new Vector3(0f, 0f, 4.2f);

    private float timeAfterSpawn = 0f;

    // Start is called before the first frame update
    void Start()
    {
        enemmys = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            enemmys[i] = Instantiate(GalaxianPrefab, enemyPosition, Quaternion.identity);
            GalaxianPrefab.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
