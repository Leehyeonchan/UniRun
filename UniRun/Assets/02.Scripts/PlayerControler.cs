using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // PlayerConteroller�� �÷��̾� ĳ���ͷμ�
    // Player ���� ������Ʈ ������

   

        // �÷��̾ ��� �� ����� ����� Ŭ��
        public AudioClip deathClip;
        // ���� ��
        public float jumpForce = 700f;

        // ���� ���� Ƚ��
        private int jumpCount = 0;
        // �÷��̾ �ٴڿ� ��Ҵ��� Ȯ��
        private bool isGrounded = false;
        // �÷��̾ �׾��� ��ҳ� = ��� ����
        private bool isDead = false;
        // ����� ������ٵ� ������Ʈ
        private Rigidbody2D playerRigidbody;
        // ����� ����� �ҽ� ������Ʈ
        private AudioSource playerAudio;

        // ����� �ִϸ����� ������Ʈ
        private Animator animator;

    void Start()
    {
            // ���������� �ʱ�ȭ ����
            // ���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ���� �Ҵ�
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerAudio = GetComponent<AudioSource>();
            animator = GetComponent<Animator>();


          
    }

    // Update is called once per frame
    void Update()
    {
            // ����� �Է��� �����ϰ� �����ϴ� ó��
            //1.���� ��Ȳ�� �˸��� �ִϸ��̼��� ���
            //2. ���콺 ���� Ŭ���� �����ϰ� ����
            // 3. ���콺 ���� ��ư�� ���� ������ ���� ����
            // 4. ħ�� ���� Ƚ���� �����ϸ� ������ ���ϰ� ����

            // ��� �� �� �̻� ó���� �������� �Ȱ� ����

            if (isDead) return;

            // ���콺 ���� ��ư�� �������� & �ִ� ���� Ƚ�� (2)��
            // �������� �ʾҴٸ�
            if(Input.GetMouseButtonDown(0) && jumpCount <2)
            {
                // ���� Ƚ�� ����
                jumpCount++;
                // ���� ������ �ӵ��� ���������� ����(0.0)�� ����
                // = ���� ���������� �� �Ǵ� �ӵ��� ���ǰų� 
                // �������� ���� ���̰� ���ϰ������� �Ǵ� ������ ����
                playerRigidbody.velocity = Vector2.zero; // (0,0)

                // ������ٵ� �������� �� �ֱ�
                playerRigidbody.AddForce(new Vector2(0, jumpForce));

                // ����� �ҽ� ���
                playerAudio.Play();
               // playerAudio.Pause();


            }
            else if(Input.GetMouseButtonUp(0) && 
                    playerRigidbody.velocity.y>0)
                    {
                // ���콺 ���� ��ư���� ���� ���� ������ �ӵ��� y���� ������ ( ���� �����)
                // ���� �ӵ��� �������� ����
                playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
            }

            // �ִϸ������� Grounded �Ķ���͸�  isGrounded  ������ ����
            animator.SetBool("Grounded", isGrounded);
           
    }

        void Die()
        {
            // ���ó��
            // �ִϸ������� Die Ʈ���� �Ķ���͸� ��
            animator.SetTrigger("Die");

            // ����� �ҽ��� �Ҵ�� ����� Ŭ���� deathClip���� ����
            playerAudio.clip = deathClip;
            // ��� ȿ���� ���
            playerAudio.Play();

            // �ӵ��� ���� (0,0)�� ����
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.velocity = new Vector2(0, 0);

            // �� ����߾� ��� ���¸� true�� ����
            isDead = true;


        // ���� �Ŵ����� ���ӿ��� ó�� ����
     
        GameManager.instance.OnPlayerDead();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // �ٴڿ� ���� ���� �����ϴ� ó��
            // � Ŭ���̴��� ������� , �浹 ǥ���� ������ ���� �ִ���
            if(collision.contacts[0].normal.y>0.7f)
            {
                // contacts : �浹 �������� ������ ���
                // ContactPoint Ÿ���� �����͸� contacts ���
                // �迭 ������ ���� �޾ƿ�
                // normal : �浹 �������� �浹 ǥ���� ���� (�븻����)
                // �� �˷��ִ� ���� �Դϴ�.

                // isGrounded�� true�� �����ϰ� , ���� ���� Ƚ����
                // 0���� ����
                isGrounded = true;
                jumpCount = 0;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            // �ٴڿ��� ����ڸ��� ó��

            // � Ŭ���̴����� ������ ��� isGrounded�� false ����
            isGrounded = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹 ����

            // �浹�� ������ �±װ� Dead �̸鼭 , ���� �������
            // �ʾҴٸ�

            if(collision.tag == "Dead" && !isDead)
            {
                Die();
            }
        }

    // �浹1 ����Ƽ! �浹 ������ �پ��ϰ� ����� �˴ϴ�
    // �浹 ũ�� �ΰ����� �����ϴµ���
    // 1. OnCollision �迭 - Enter , Stay , Exit

    // OnCollision �迭�� �� �ݶ��̴� ������ �浹���� 
    // �� �ϳ��� isTrigger�� üũ�� �Ǿ� ���� ���� ���.
    // 2. OnTrigger �迭 - Enter , Stay , Exit
    // - OnTrigger �迭�� �� �ϳ���  isTrigger�� üũ��
    // �Ǿ� ���� �� ���



}
