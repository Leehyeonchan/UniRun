using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //���⼭����
using UnityEngine.SceneManagement;

// ���ӿ��� ���¸� ǥ���ϰ� , ���� ������  UI�� �����ϴ� ������
// �㿡�� �� �ϳ��� ���� �Ŵ����� ������ �� ����
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����

    public bool isGameover = false; // ���ӿ��� ����
    public Text scoreText; // ������ ����� UI �ؽ�Ʈ
    public GameObject gameoverUI; // ���ӿ����� Ȱ��ȭ�� UI ������Ʈ

    private int score = 0; // ���� ����

    public GameObject menuPanel; // �޴� �г� ����

    public int hpCount = 2; //  ���� ����� �����
    public Text hpText; // ����ڿ��� ������ ����� UI


    // ���� ���۰� ���ÿ� �̱����� ����
    private void Awake()
    {
        // �̱��� ���� instance�� ��� �ֳ���?
        if(instance == null)
        {
            // instance�� ��� �ִٸ� �װ��� �� �ڽ��� �Ҵ�
            instance = this;
        }
        else
        {
            // instance�� �̹� �ٸ� GameManager ������Ʈ��
            // �Ҵ�Ǿ� �ִٸ�

            // ���� �� �� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�
            // �̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� 
            // �ı�
          //  Debug.Log("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�");
            Destroy(gameObject);
        }
    }

    // ������� �� ����ϱ�!! ���� �����ֽ�!!!

    private void Start()
    {
        // ����ڿ��� ������ ������� ���� ��������� ���
        hpText.text = hpCount.ToString();
    }


    // Start is called before the first frame update


    // ���ӿ��� ���¿��� ������ ������ �� �� �ְ� �ϴ� ó��
    void Update()
    {
        // ���ӿ��� ���¿��� ���콺 ���� ��ư�� Ŭ�� �Ѵٸ�
        if(isGameover&&Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Main");
        }
    }

    // ������ ������Ű�� �޼���
    public void AddScore(int newScore)
    {
        // ���ӿ����� �ƴ϶��
        if(!isGameover)
        {
            // ������ ����
            score += newScore;
            scoreText.text = "Score :" + score;
        }
    }
        // �÷��̾� ĳ���Ͱ� ��� �� ���ӿ����� �����ϴ� �޼���
        public void OnPlayerDead()
        {
        // ���� ���¸� ���ӿ��� ���·� ����
        isGameover = true;
        gameoverUI.SetActive(true);

        }

    public void OnMenu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }
  
    public void OffMenu()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public bool Crash()
    {
        //  hpCount--;
        //  hpText.text = hpCount.ToString();
        
        hpText.text =  ""+ --hpCount;
        if (hpCount <= 0) return true;
        return false;
    }
}

