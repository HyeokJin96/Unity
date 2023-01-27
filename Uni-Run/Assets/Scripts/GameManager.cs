using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = default;

    private const string UI_OBJS = "UiObjs";
    private const string SCORE_TEXT_OBJ = "Score Text";
    private const string GAME_OVER_UI_OBJ = "GameOverUi";

    public bool isGameOver = false;

    private GameObject scoreTextObj = default;
    private GameObject gameOverUi = default;

    private int score = default;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            //  Init
            isGameOver = false;
            GameObject uiObjs_ = GFunc.GetRootObj(UI_OBJS);
            scoreTextObj = uiObjs_.FindChildObj(SCORE_TEXT_OBJ);
            gameOverUi = uiObjs_.FindChildObj(GAME_OVER_UI_OBJ);

            score = 0;
        }   //  if : ���� �޴����� �������� �ʴ� ��� ������ �Ҵ� �� �ʱ�ȭ
        else
        {
            GFunc.LogWarning("[Sytem] GameManager : Duplicated object warnning");
            Destroy(gameObject);
        }
    }   //  Awake()

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true && Input.GetMouseButtonDown(0))
        {
            GFunc.LoadScene(GFunc.GetActiveScene().name);
        }
    }

    //! ������ ������Ű�� �޼���
    public void AddScore(int newscore)
    {
        if (isGameOver == true)
        {
            return;
        }

        //  ������ �������� ���
        score += newscore;
        scoreTextObj.SetTmpText($"Score : {score}");
    }   //  AddScore()

    //! �÷��̾� ��� �� ���ӿ����� ����ϴ� �޼���
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    }   //  OnPlayerDead()
}
