using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float PLAYER_STEP_ON_Y_ANGLE_MIN = 0.7f;  //! < 45��

    public AudioClip deathSound = default;
    public float jumpForce = default;

    private int jumpCount = default;
    private bool isGrounded = false;
    private bool isDead = false;

    #region Player's component
    private Rigidbody2D playerRigidbody = default;
    private Animator playerAni = default;
    private AudioSource playerAudio = default;
    #endregion      //  player's component

    // Start is called before the first frame update
    void Start()
    {
        //  Set player's components
        playerRigidbody = gameObject.GetComponentMust<Rigidbody2D>();
        playerAni = gameObject.GetComponentMust<Animator>();
        playerAudio = gameObject.GetComponentMust<AudioSource>();

        //GFunc.Assert(playerRigidbody != null || playerRigidbody != default);
        //GFunc.Assert(playerAni != null || playerAni != default);
        //GFunc.Assert(playerAudio != null || playerAudio != default);
    }   //  Start()

    // Update is called once per frame
    void Update()
    {
        //  ��� �� ó���� �� �̻� �������� �ʰ� ����
        if (isDead == true) { return; }

        //  { �÷��̾� ���� ���� ���� }
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;

            //  ���� ������ �ӵ��� ���������� ����(0, 0)�� ����
            playerRigidbody.velocity = Vector2.zero;

            //  Rigidbody �������� �� �ֱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForce));

            //  ����� �ҽ� ���
            playerAudio.Play();
        }   //  if : �÷��̾ ������ ��
        else if (Input.GetMouseButtonUp(0) && 0 < playerRigidbody.velocity.y)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }   //  else if : �÷��̾ ���߿� �� ���� ��

        playerAni.SetBool("Grounded", isGrounded);
        //  { �÷��̾� ���� ���� ���� }

    }   //  Update()

    //! ��� ó��
    private void Die()
    {
        playerAni.SetTrigger("Die");

        playerAudio.clip = deathSound;
        playerAudio.Play();

        playerRigidbody.velocity = Vector2.zero;
        isDead = true;

        //  ���� �Ŵ����� �÷��̾ �׾��� ���� UI ó��
        GameManager.instance.OnPlayerDead();
    }   //  Die()

    //! Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Dead Zone") && isDead == false)
        {
            Die();
        }
    }   //  OnTriggerEnter2D()

    //! �ٴڿ� ������� �����ϴ� ó��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PLAYER_STEP_ON_Y_ANGLE_MIN < collision.contacts[0].normal.y)
        {
            isGrounded = true;
            jumpCount = 0;
        }   //  if : 45�� ���� �ϸ��� ���� ���� ���
    }   //  OnCollisionEnter2D()

    //! �ٴڿ��� ������� �����ϴ� ó��
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }   //  OnCollisionExit2D()
}
