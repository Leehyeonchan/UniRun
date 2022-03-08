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
        isGameover = true;

        }
    }

