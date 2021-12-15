using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriangleMovements : MonoBehaviour {
  private CTMaster ctm;

  public enum Direction {
    front,
    right, 
    back,
    left
  }

  [System.NonSerialized] public Vector3 originalPosition;
  [System.NonSerialized] public Quaternion originalRotation;
  [System.NonSerialized] public Direction triangleDirection = Direction.front;
  private readonly float offset = 1.6f;

  private void Start() {
    originalPosition = transform.position;
    originalRotation = transform.rotation;
    ctm = FindObjectOfType<CTMaster>();
  }

  public void MoveFoward() {
    switch (triangleDirection) {
      case Direction.front: {
        transform.position = new Vector2(transform.position.x, transform.position.y + offset);
        break;
      }
      case Direction.left: {
        transform.position = new Vector2(transform.position.x - offset, transform.position.y);
        break;
      }
      case Direction.back: {
        transform.position = new Vector2(transform.position.x, transform.position.y - offset);
        break;
      }
      case Direction.right: {
        transform.position = new Vector2(transform.position.x + offset, transform.position.y);
        break;
      }
    }
  }

  public void TurnRight() {
    transform.Rotate(0.0f, 0.0f, transform.rotation.z - 90);

    switch (triangleDirection){
      case Direction.front: {
        triangleDirection = Direction.right;
        break;
      }
      case Direction.right: {
        triangleDirection = Direction.back;
        break;
      }
      case Direction.back: {
        triangleDirection = Direction.left;
        break;
      }
      case Direction.left: {
        triangleDirection = Direction.front;
        break;
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (!collision.CompareTag("Path Boundaries")) {
      transform.position = collision.transform.position;
      if (collision.CompareTag("End Block")) {
        ctm.isInWinSquare = true;
      }
    }
  }

  private void OnTriggerExit2D(Collider2D collision) {
    if (collision.CompareTag("Path Boundaries")) {
      ctm.isOutOfBoundaries = true;
    }
  }
}
