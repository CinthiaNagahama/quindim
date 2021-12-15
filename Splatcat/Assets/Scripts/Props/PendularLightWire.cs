using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendularLightWire : MonoBehaviour {
  private LineRenderer lineRenderer;

  private void Awake() {
    //StartCoroutine(FindObjectOfType<AudioManager>().PlayLoop("Creak", 2f));
    lineRenderer = GetComponent<LineRenderer>();
    lineRenderer.SetPosition(0, new Vector2(transform.position.x, transform.position.y + 5.8f));
  }

  private void Update() {
    lineRenderer.SetPosition(1, transform.position);
  }
}
