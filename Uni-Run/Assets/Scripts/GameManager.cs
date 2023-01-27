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
        }   //  if : 게임 메니저가 존재하지 않는 경우 변수에 할당 및 초기화
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

    //! 점수를 증가시키는 메서드
    public void AddScore(int newscore)
    {
        if (isGameOver == true)
        {
            return;
        }

        //  게임이 진행중인 경우
        score += newscore;
        scoreTextObj.SetTmpText($"Score : {score}");
    }   //  AddScore()

    //! 플레이어 사망 시 게임오버를 출력하는 메서드
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    }   //  OnPlayerDead()
}
