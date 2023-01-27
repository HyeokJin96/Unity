using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float PLAYER_STEP_ON_Y_ANGLE_MIN = 0.7f;  //! < 45도

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
        //  사망 시 처리를 더 이상 진행하지 않고 종료
        if (isDead == true) { return; }

        //  { 플레이어 점프 관련 로직 }
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;

            //  점프 직전에 속도를 순간적으로 제로(0, 0)로 변경
            playerRigidbody.velocity = Vector2.zero;

            //  Rigidbody 위쪽으로 힘 주기
            playerRigidbody.AddForce(new Vector2(0, jumpForce));

            //  오디오 소스 재생
            playerAudio.Play();
        }   //  if : 플레이어가 점프할 때
        else if (Input.GetMouseButtonUp(0) && 0 < playerRigidbody.velocity.y)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }   //  else if : 플레이어가 공중에 떠 있을 때

        playerAni.SetBool("Grounded", isGrounded);
        //  { 플레이어 점프 관련 로직 }

    }   //  Update()

    //! 사망 처리
    private void Die()
    {
        playerAni.SetTrigger("Die");

        playerAudio.clip = deathSound;
        playerAudio.Play();

        playerRigidbody.velocity = Vector2.zero;
        isDead = true;

        //  게임 매니저로 플레이어가 죽었을 때의 UI 처리
        GameManager.instance.OnPlayerDead();
    }   //  Die()

    //! 트리거 콜라이더를 가진 장애물과의 충돌을 감지
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Dead Zone") && isDead == false)
        {
            Die();
        }
    }   //  OnTriggerEnter2D()

    //! 바닥에 닿았음을 감지하는 처리
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PLAYER_STEP_ON_Y_ANGLE_MIN < collision.contacts[0].normal.y)
        {
            isGrounded = true;
            jumpCount = 0;
        }   //  if : 45도 보다 완만한 땅을 밟은 경우
    }   //  OnCollisionEnter2D()

    //! 바닥에서 벗어났음을 감지하는 처리
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }   //  OnCollisionExit2D()
}
