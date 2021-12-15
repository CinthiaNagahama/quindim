using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunButton_Code : RunButton_Utils {
  private List<BlockUI> blocks;
  private List<BlockUI> connectedBlocks = new List<BlockUI>();

  private bool isPressed = false;

  private void Update() {
    blocks = new List<BlockUI>(FindObjectsOfType<BlockUI>());
  }

  public void Clicked() {
    FindObjectOfType<AudioManager>().Play("Click");
    connectedBlocks.Clear();

    isPressed = !isPressed;

    // Get all connected blocks
    connectedBlocks = GetConnectedBlocks(blocks);

    // Runs code if the first block is the Beginning Block and the last block is the End Block
    if (connectedBlocks[0].CompareTag("Beginning Block") && connectedBlocks[connectedBlocks.Count - 1].CompareTag("End Block")) {
      StartCoroutine(RunCode(connectedBlocks));
    }
  }

  IEnumerator RunCode(List<BlockUI> connectedBlocks) {
    // Runs one line of code every 0.3 seconds
    foreach (BlockUI block in connectedBlocks) {
      switch (block.tag) {
        case ("Walk Block"): {
          block.GetComponent<WalkBlockUI>().MoveForward();
          break;
        }
        case ("Turn Block"): {
          block.GetComponent<TurnBlockUI>().TurnRight();
          break;
        }
        case ("End Block"): {
          ctm.ranAllCode = true;
          ctm.Finished();
          break;
        }
        default: {
          break;
        }
      }
      yield return new WaitForSecondsRealtime(0.3f);
    }
  }
}
