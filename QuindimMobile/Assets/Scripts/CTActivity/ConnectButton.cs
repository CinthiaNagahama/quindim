using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectButton : MonoBehaviour {
  private bool isConnectEnabled = false;
  private Image image;
  private Color ogColor;

  private DragAnDrop[] dragBlocks;
  private DrawLine[] lines;

  private void Start() {
    image = GetComponent<Image>();
    ogColor = image.color;
  }

  private void Update() {
    dragBlocks = GetComponentInParent<Canvas>().GetComponentsInChildren<DragAnDrop>();

    lines = GetComponentInParent<Canvas>().GetComponentsInChildren<DrawLine>();
  }

  public void Connect() {
    FindObjectOfType<AudioManager>().Play("Click");
    isConnectEnabled = !isConnectEnabled;

    // Makes lines drawable when connect button is clicked
    if (isConnectEnabled) {
      image.color = Color.gray;

      foreach(DragAnDrop dd in dragBlocks) {
        dd.CanDrag = false;
      }

      foreach(DrawLine line in lines) {
        line.SetCanDraw(true);
      }
    
      // Makes Dragging possible when connect button is clicked
    } else {
      image.color = ogColor;

      foreach (DragAnDrop dd in dragBlocks) {
        dd.CanDrag = true;
      }

      foreach (DrawLine line in lines) {
        line.SetCanDraw(false);
      }
    }
  }

  public bool GetIsConnectedEnabled() {
    return isConnectEnabled;
  }
}
