using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerController : MonoBehaviour
{
  public float speed;
  public float jumpForce;
  private float moveInput;
  private Rigidbody2D rb;
  private bool facingRight = true;

  public bool isGrounded;
  public Transform groundCheck;
  public float checkRadius;
  public LayerMask whatIsGround;
  private int extraJumps;
  public int extraJumpsValue;

  private float jumpTimeCounter;
  public float jumpTime;

  private bool isJumping;

  private void Start()
  {
    extraJumps = extraJumpsValue;
    rb = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate()
  {
    moveInput = Input.GetAxisRaw("Horizontal");
    rb.AddForce(new Vector2(moveInput * speed, Mathf.Abs(moveInput) * jumpForce));
    if (facingRight == false && moveInput > 0) Flip();
    else if (facingRight == true && moveInput < 0) Flip();
  }

  private void Update()
  {
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    if (Input.GetAxisRaw("Horizontal") == 0 && isGrounded)
    {
      rb.velocity = Vector2.zero;
      rb.angularVelocity = 0f;
    }
  }
  // {
  //   Debug.Log(Input.GetAxisRaw("Horizontal"));
  //   if (Input.GetAxisRaw("Horizontal") == 0 && !isGrounded)
  //   {
  //     rb.AddForce(Vector2.right * speed);
  //   }
  // }
  // {

  //   if (isGrounded && Input.GetKeyDown(KeyCode.Space))
  //   {
  //     isJumping = true;
  //     jumpTimeCounter = jumpTime;
  //     rb.velocity = Vector2.up * jumpForce;
  //   }

  //   if (Input.GetKey(KeyCode.Space) && isJumping)
  //   {
  //     if (jumpTimeCounter > 0)
  //     {
  //       rb.velocity = Vector2.up * jumpForce;
  //       jumpTimeCounter -= Time.deltaTime;
  //     }
  //     else isJumping = false;
  //   }

  //   if (Input.GetKeyUp(KeyCode.Space)) isJumping = false;
  // }

  void Flip()
  {
    facingRight = !facingRight;
    Vector3 Scaler = transform.localScale;
    Scaler.x *= -1;
    transform.localScale = Scaler;
  }
}
