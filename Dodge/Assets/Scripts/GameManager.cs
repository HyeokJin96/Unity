using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText = default;

    public GameObject timeText = default;
    public GameObject recordText = default;

    private float survivalTime = default;
    private bool isGameOver = default;

    // Start is called before the first frame update
    void Start()
    {
        //  생존 시간과 게임오버 상태 초기화
        survivalTime = 0;
        isGameOver = false;
    }   //  Start()

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            //  생존 시간 갱신
            survivalTime += Time.deltaTime;

            //  갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            //timeText = "Time : " + (int)survivalTime;
        }   //  if : 게임오버가 아닌 동안
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GFunc.LoadScene("SampleScene");
            }   //  if : 게임오버 상태에서 R키를 누른 경우
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GFunc.QuitThisGame();
            }   //  if : 게임오버 상태에서 Q키를 누른 경우
        }
    }   //  Update()

    public void EndGame()
    {
        //  현재 상태를 게임오버 상태로 전환
        isGameOver = true;

        //  게임오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        //  BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (survivalTime > bestTime)
        {
            //  최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = survivalTime;

            //  변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }   //  if : 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면

        //recordText = "Best Time : " + (int)bestTime;
    }
}
