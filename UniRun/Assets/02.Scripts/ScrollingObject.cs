using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������Ʈ�� ���������� �������� �����̴� ��ũ��Ʈ
public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f; // �̵� �ӵ�
 //   void Start()
   // {
        
   // }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.isGameover)
        { 
        // �ʴ� speed�� �ӵ��� �������� �����̵� ����
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        new Vector3(-1, 0, 0);
    }
}
}
