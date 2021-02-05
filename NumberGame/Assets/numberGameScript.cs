using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberGameScript : MonoBehaviour
{
    public InputField userAnswer1;
    public InputField userAnswer2;
    public InputField userAnswer3;
    public Text resultText;
    public GameObject PopUpPanel;
    public Text PopUpText;

    int[] answerNum = new int[3];
    int[] userNum = new int[3];
    int try_count = 0;// 시도
    int strike_count = 0; // 스트라이크
    int ball_count = 0; // 볼 

    // Start is called before the first frame update
    void Start()
    {
        resetUserAnswer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetUserAnswer()
    {
        userAnswer1.text = "0";
        userAnswer2.text = "0";
        userAnswer3.text = "0";
        resultText.text = "...";

        makeAnswer();
        PopUpPanel.SetActive(false);
        try_count = 0;
    }

    void makeAnswer()
    {
        //정답 숫자 생성 : 모두 다를것
        answerNum[0] = Random.Range(0, 10);

        answerNum[1] = Random.Range(0, 10);
        while (answerNum[0] == answerNum[1])
          answerNum[1] = Random.Range(0, 10);

        answerNum[2] = Random.Range(0, 10);
        while (answerNum[0] == answerNum[2] || answerNum[1] == answerNum[2])
          answerNum[2] = Random.Range(0, 10);

        Debug.Log("Answer is" + answerNum[0] + answerNum[1] + answerNum[2]);
    }

    public void checkAnswer()
    {
        strike_count = 0;
        ball_count = 0;

        Debug.Log("숫자 야구 게임  START!!!");

        userNum[0] = int.Parse(userAnswer1.text);
        userNum[1] = int.Parse(userAnswer2.text);
        userNum[2] = int.Parse(userAnswer3.text);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i == j) 
                { 
                    if (userNum[i] == answerNum[j])
                        strike_count += 1;
                }
                else
                {
                    if (userNum[i] == answerNum[j])
                    ball_count += 1;
                }
            }
        }

        if (strike_count == 3)
        {
            try_count += 1;
            PopUpPanel.SetActive(true);
            PopUpText.text = "정답입니다 !! \n TRY 횟수 :" + try_count;
            Debug.Log(try_count + "번 만에 정답을 맞추셨습니다.");
        }
        else
        {
            try_count += 1;
            Debug.Log("결과 : [" + strike_count + "] Strike [" + ball_count + "] Ball");
            resultText.text = strike_count + "S  - " + ball_count + "B";
        }
    }

}
