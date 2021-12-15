using UnityEngine;

public class CatController : MonoBehaviour {
	[SerializeField] private float speed;
	[SerializeField] private float jumpForce;
	[SerializeField] private Animator animator;

  [SerializeField] private FixedJoystick fixedJoystick;
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

		/* Movement - Joystick */
		Vector3 direction = Vector3.right * fixedJoystick.Horizontal;

		if (!facingRight && direction.x > 0) Flip();
		else if (facingRight && direction.x < 0) Flip();

		rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);		
  }

  private void Update() {
		animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));	
	}

	public void JumpWhenClicked() {
    if (isGrounded) {
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
