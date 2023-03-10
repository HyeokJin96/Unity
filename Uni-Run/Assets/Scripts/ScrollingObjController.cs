using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string prefabName = default;
    public int scrollingObjCount = default;

    public float speed = default;

    protected GameObject objPrefab = default;
    protected Vector2 objPrefabSize = default;
    protected List<GameObject> scrollingPool = default;
    protected float prefabYPos = default;
    

    // Start is called before the first frame update
    public virtual void Start()
    {
        objPrefab = gameObject.FindChildObj(prefabName);
        scrollingPool = new List<GameObject>();
        GFunc.Assert(objPrefab != null || objPrefab != default);

        objPrefabSize = objPrefab.GetRectSizeDelta();
        prefabYPos = objPrefab.transform.localPosition.y;

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

        InitObjsPosition();

    }   //  Start()

    // Update is called once per frame
    public virtual void Update()
    {
        if (scrollingPool == default || scrollingPool.Count <= 0)
        {
            return;
        }   //  if : 스크롤링 할 오브젝트가 존재하지 않는 경우

        // 게임이 정상 진행중인 경우
        if (GameManager.instance.isGameOver == false)
        {
            //  { 배경에 움직임을 주는 로직 }
            //  스크롤링 할 오브젝트가 존재하는 경우
            for (int i = 0; i < scrollingObjCount; i++)
            {
                scrollingPool[i].AddLocalPos(speed * Time.deltaTime * (-1), 0f, 0f);
            }   //  loop : 배경이 왼쪽으로 움직이도록 하는 루프

            RepositionFirstObj();
        }
        //  { 배경에 움직임을 주는 로직 }
    }   //  Update()

    /* Do something */
    //! 생성한 오브젝트의 위치를 설정하는 함수
    protected virtual void InitObjsPosition()
    {
        /* Do something */
    }   //  InitObjsPosition()

    //! 스크롤링풀의 첫번째 오브젝트를 마지막으로 리포지셔닝 하는 함수
    protected virtual void RepositionFirstObj()
    {
        /* Do something */
    }   //  RepositionFirstObj()
}
