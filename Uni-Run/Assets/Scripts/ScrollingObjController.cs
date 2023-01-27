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

        InitObjsPosition();

    }   //  Start()

    // Update is called once per frame
    public virtual void Update()
    {
        if (scrollingPool == default || scrollingPool.Count <= 0)
        {
            return;
        }   //  if : ��ũ�Ѹ� �� ������Ʈ�� �������� �ʴ� ���

        // ������ ���� �������� ���
        if (GameManager.instance.isGameOver == false)
        {
            //  { ��濡 �������� �ִ� ���� }
            //  ��ũ�Ѹ� �� ������Ʈ�� �����ϴ� ���
            for (int i = 0; i < scrollingObjCount; i++)
            {
                scrollingPool[i].AddLocalPos(speed * Time.deltaTime * (-1), 0f, 0f);
            }   //  loop : ����� �������� �����̵��� �ϴ� ����

            RepositionFirstObj();
        }
        //  { ��濡 �������� �ִ� ���� }
    }   //  Update()

    /* Do something */
    //! ������ ������Ʈ�� ��ġ�� �����ϴ� �Լ�
    protected virtual void InitObjsPosition()
    {
        /* Do something */
    }   //  InitObjsPosition()

    //! ��ũ�Ѹ�Ǯ�� ù��° ������Ʈ�� ���������� �������Ŵ� �ϴ� �Լ�
    protected virtual void RepositionFirstObj()
    {
        /* Do something */
    }   //  RepositionFirstObj()
}
