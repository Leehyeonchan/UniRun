using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //여기서부터
using UnityEngine.SceneManagement;

// 게임오버 상태를 표현하고 , 게임 점수와  UI를 관리하는 에너지
// 썬에는 단 하나의 게임 매니저만 존재할 수 있음
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글턴을 할당할 전역 변수

    public bool isGameover = false; // 게임오버 상태
    public Text scoreText; // 점수를 출력할 UI 텍스트
    public GameObject gameoverUI; // 게임오버시 활성화할 UI 오브젝트

    private int score = 0; // 게임 점수


    // 게임 시작과 동시에 싱글턴을 구성
    private void Awake()
    {
        // 싱글턴 변수 instance가 비어 있나요?
        if(instance == null)
        {
            // instance가 비어 있다면 그곳에 내 자신을 할당
            instance = this;
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가
            // 할당되어 있다면

            // 씬에 두 개 이상의 GameManager 오브젝트가 존재한다는 의미
            // 싱글턴 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 
            // 파괴
          //  Debug.Log("씬에 두 개 이상의 게임 매니저가 존재합니다");
            Destroy(gameObject);
        }
    }

    // 여기까지 쭉 기억하기!! 쌤이 말해주심!!!


    // Start is called before the first frame update
  

    // 게임오버 상태에서 게임을 제시지 할 수 있게 하는 처리
    void Update()
    {
        // 게임오버 상태에서 마우스 왼쪽 버튼을 클릭 한다면
        if(isGameover&&Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Main");
        }
    }

    // 점수를 증가시키는 메서드
    public void AddScore(int newScore)
    {
        // 게임오버가 아니라면
        if(!isGameover)
        {
            // 점수를 증가
            score += newScore;
            scoreText.text = "Score :" + score;
        }
    }
        // 플레이어 캐릭터가 사망 시 게임오버를 실행하는 메서드
        public void OnPlayerDead()
        {
        isGameover = true;

        }
    }

