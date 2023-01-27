using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBgController : ScrollingObjController
{
    public override void Start()
    {
        base.Start();
    }   //  Start()

    public override void Update()
    {
        base.Update();
    }   //  Update()

    protected override void InitObjsPosition()
    {
        base.InitObjsPosition();

        float horizonPos = objPrefabSize.x * (scrollingObjCount - 1) * (-1) * 0.5f;
        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].SetLocalPos(horizonPos, 0f, 0f);
            horizonPos = horizonPos + objPrefabSize.x;
        }
    }   //  InitObjsPosition()

    protected override void RepositionFirstObj()
    {
        base.RepositionFirstObj();

        float lastScrCurrentXPos = scrollingPool[scrollingObjCount - 1].transform.localPosition.x;
        if (lastScrCurrentXPos <= objPrefabSize.x * 0.5f)
        {
            float lastScrObjInitPos = Mathf.Floor(scrollingObjCount * 0.5f) * objPrefabSize.x + (objPrefabSize.x * 0.45f);
            scrollingPool[0].SetLocalPos(lastScrObjInitPos, 0f, 0f);
            scrollingPool.Add(scrollingPool[0]);
            scrollingPool.RemoveAt(0);
        }   //  if : 스크롤링 오브젝트의 마지막 오브젝트가 화면 상의 절반정도 Draw 되는 때
    }   //  RepositionFirstObj()

}
