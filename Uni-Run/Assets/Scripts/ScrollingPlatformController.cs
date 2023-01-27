using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingPlatformController : ScrollingObjController
{
    private bool isStart = false;
    public override void Start()
    {
        base.Start();

        isStart = true;
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void InitObjsPosition()
    {
        base.InitObjsPosition();

        Vector2 posOffset = Vector2.zero;
        prefabYPos = objPrefab.transform.localPosition.y;

        float xPos = objPrefabSize.x * (scrollingObjCount - 1) * (-1) * 0.5f;
        float yPos = prefabYPos;
        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].SetLocalPos(xPos, yPos, 0f);

            //  랜덤한 offset을 받아와서 x, y 포지션에 더하는 로직
            posOffset = GetRandomPosOffset();
            if (isStart == true && i == 1)
            {
                xPos = xPos + objPrefabSize.x;
                isStart = false;
            }
            else
            {
                xPos = xPos + objPrefabSize.x + posOffset.x;
            }
            yPos = prefabYPos + posOffset.y;
        }
    }   //  InitObjsPosition()

    protected override void RepositionFirstObj()
    {
        base.RepositionFirstObj();

        //  스크롤링풀의 첫번재 오브젝트를 마지막으로 리포지셔닝 하는 로직
        float lastScrCurrentXPos = scrollingPool[scrollingObjCount - 1].transform.localPosition.x;
        if (lastScrCurrentXPos <= objPrefabSize.x * 0.5f)
        {
            Vector2 posOffset = Vector2.zero;
            posOffset = GetRandomPosOffset();

            float lastScrObjInitPos = Mathf.Floor(scrollingObjCount * 0.5f) * objPrefabSize.x + (objPrefabSize.x * 0.45f);
            scrollingPool[0].SetLocalPos(lastScrObjInitPos + posOffset.x, prefabYPos + posOffset.y, 0f);
            scrollingPool.Add(scrollingPool[0]);
            scrollingPool.RemoveAt(0);
        }   //  if : 스크롤링 오브젝트의 마지막 오브젝트가 화면 상의 절반정도 Draw 되는 때
    }   //  RepositionFirstObj()

    //! 랜덤한 포지션 오프셋을 리턴하는 함수
    private Vector2 GetRandomPosOffset()
    {
        Vector2 offset = Vector2.zero;
        offset.x = Random.Range(300f, 1000f);
        offset.y = Random.Range(-100f, 100f);

        return offset;
    }   //  GetRandomPosOffset()
}
