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

        //  { scrollingPool을 생성해서 주어진 수만큼 초기화 }
        GameObject tempObj = default;
        if (scrollingPool.Count <= 0)
        {
            for (int i = 0; i < scrollingObjCount; i++)
            {
                tempObj = Instantiate(objPrefab, objPrefab.transform.position, objPrefab.transform.rotation, transform);

                scrollingPool.Add(tempObj);
                tempObj = default;
            }   //  loop : scrolling object를 주어진 수만큼 초기화
        }   //  if : scrollingPool을 초기화
        objPrefab.SetActive(false);
        //  { scrollingPool을 생성해서 주어진 수만큼 초기화 }

        //  생성한 오브젝트의 위치를 설정
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
