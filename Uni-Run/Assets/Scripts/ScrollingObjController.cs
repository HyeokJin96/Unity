using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string prefabName = default;
    public int scrollingObjCount = default;

    private GameObject objPrefab = default;
    private Vector2 objPrefabSize = default;
    private List<GameObject> scrollingPool = default;

    // Start is called before the first frame update
    void Start()
    {
        objPrefab = gameObject.FindChildObj(prefabName);
        scrollingPool = new List<GameObject>();
        GFunc.Assert(objPrefab != null || objPrefab != default);

        objPrefabSize = objPrefab.GetRectSizeDelta();

        //  { scrollingPool�� �����ؼ� �־��� ����ŭ �ʱ�ȭ }
        GameObject tempObj = default;
        if (scrollingPool.Count <= 0)
        {
            for (int i = 0; i < scrollingObjCount; i++)
            {
                tempObj = Instantiate(objPrefab, objPrefab.transform.position, objPrefab.transform.rotation, transform);

                scrollingPool.Add(tempObj);
                tempObj = default;
            }   //  loop : scrolling object�� �־��� ����ŭ �ʱ�ȭ
        }   //  if : scrollingPool�� �ʱ�ȭ
        objPrefab.SetActive(false);
        //  { scrollingPool�� �����ؼ� �־��� ����ŭ �ʱ�ȭ }

        //  ������ ������Ʈ�� ��ġ�� ����
        int scrollCountIndex = scrollingObjCount - 1;
        float horizonPos = objPrefabSize.x * (scrollingObjCount - 1) * (-1) * 0.5f;
        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].SetLocalPos(horizonPos, 0f, 0f);
            horizonPos = horizonPos + objPrefabSize.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
