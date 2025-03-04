using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float walkSpeed = 5f;  // 普通行走速度
    public float runSpeed = 10f;  // 疾跑速度
    public float jumpForce = 10f; // 跳跃力度

    private Rigidbody2D rb;
    private bool isRunning;
    private bool isGrounded;

    public AudioClip jumpSound;   // 跳跃音效
    private AudioSource audioSource; // 音频组件

    // 在游戏开始时调用
    void Start()
    {
        // 获取当前游戏对象上的Rigidbody2D组件
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // 获取左右输入

        // 检测是否按住 Shift 进行疾跑
        isRunning = Input.GetKey(KeyCode.LeftShift);

        // 选择合适的速度
        float speed = isRunning ? runSpeed : walkSpeed;

        // 移动角色
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        // 跳跃逻辑（确保角色在地面上时可以跳跃）
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (jumpSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }

    // 角色接触地面时，允许跳跃
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // 角色离开地面时，禁止跳跃
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
