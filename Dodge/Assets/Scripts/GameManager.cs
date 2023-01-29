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
        //  ���� �ð��� ���ӿ��� ���� �ʱ�ȭ
        survivalTime = 0;
        isGameOver = false;
    }   //  Start()

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            //  ���� �ð� ����
            survivalTime += Time.deltaTime;

            //  ������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            //timeText = "Time : " + (int)survivalTime;
        }   //  if : ���ӿ����� �ƴ� ����
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GFunc.LoadScene("SampleScene");
            }   //  if : ���ӿ��� ���¿��� RŰ�� ���� ���
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GFunc.QuitThisGame();
            }   //  if : ���ӿ��� ���¿��� QŰ�� ���� ���
        }
    }   //  Update()

    public void EndGame()
    {
        //  ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameOver = true;

        //  ���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        //  BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (survivalTime > bestTime)
        {
            //  �ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = survivalTime;

            //  ����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }   //  if : ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�

        //recordText = "Best Time : " + (int)bestTime;
    }
}
