using UnityEngine;

public class CatController : MonoBehaviour {
	[SerializeField] private float speed;
	[SerializeField] private float jumpForce;
	[SerializeField] private Animator animator;
  private float moveInput;

	private Rigidbody2D rb;

	private bool facingRight = true;

	private bool isGrounded;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private float checkRadius;
	[SerializeField] private LayerMask whatIsGround;

	private GameMaster gm;

  private void Start() {
		gm = FindObjectOfType<GameMaster>();
		transform.position = gm.GetLastCheckpointTransform();
  }

  void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

		/* Movement v2 - WASD or Arrow Keys */
		moveInput = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

		if (!facingRight && moveInput > 0) Flip();
		else if (facingRight && moveInput < 0) Flip();
  }

  private void Update() {
		animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
      FindObjectOfType<AudioManager>().Play("Jump");
      rb.velocity = Vector2.up * jumpForce;
    }
	}

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.collider.CompareTag("JumpPad")) {
      FindObjectOfType<AudioManager>().Play("Jump");
      rb.velocity = Vector2.up * 1.8f * jumpForce;
		} 
  }

  private void Flip() {
		facingRight = !facingRight;
		Vector3 scaler = transform.localScale;
		scaler.x *= -1;
		transform.localScale = scaler;
  }
}
