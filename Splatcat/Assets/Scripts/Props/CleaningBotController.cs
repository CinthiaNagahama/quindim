using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningBotController : MonoBehaviour {
  private enum State {
    moving,
    foundTarget
  }
  private Rigidbody2D rb;
  private float speed = -4;

  private bool facingLeft = true;
  private Animator animator;

  private GameObject player;
  private State state;

  private Vector2 ogOffset;
  private BoxCollider2D boxCollider;

  private void Awake() {
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    player = FindObjectOfType<CatController>().gameObject;
    boxCollider = GetComponent<BoxCollider2D>();
    ogOffset = boxCollider.offset;
    state = State.moving;
  }

  private void Update() {
    switch (state) {
      case State.moving: {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        
        // What if the bot only got you if it scanned you?
        //if (Vector2.Distance(transform.position, player.transform.position) < 2f) {
        //  state = State.foundTarget;
        //}
        break;
      }
      case State.foundTarget: {
        float temp = speed;
        speed = 0;

        player.transform.position = FindObjectOfType<GameMaster>().GetLastCheckpointTransform();

        speed = temp;
        state = State.moving;
        break;
      }
    }
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.collider.CompareTag("Chair")) {
      StartCoroutine("Turn");
    } else if (collision.collider.CompareTag("Player")) {
      state = State.foundTarget;
    }
  }

  IEnumerator Turn() {
    float temp = speed;
    speed = 0;
    animator.SetBool("turn", true);

    yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
    
    animator.SetBool("turn", false);

    speed = -temp;

    Flip();
  }

  private void Flip() {
    GetComponent<SpriteRenderer>().flipX = facingLeft;

    boxCollider.offset = (facingLeft ? new Vector2(-0.72f, ogOffset.y) : ogOffset);
    facingLeft = !facingLeft;
  }
}
