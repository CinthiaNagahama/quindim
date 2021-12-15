using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunButton_Utils : MonoBehaviour {
  [System.NonSerialized] public CTMaster ctm;
  public GameObject popUp;

  private void Start() {
    ctm = FindObjectOfType<CTMaster>();
  }

  public List<BlockUI> GetConnectedBlocks(List<BlockUI> blocks) {
    // Initialize orderedBlocks with the Beginning Block
    List<BlockUI> orderedBlocks = new List<BlockUI>();

    // Order blocks by connection
    BlockUI newBlock = blocks.Find(block => block.CompareTag("Beginning Block"));
    while(newBlock != null) {
      orderedBlocks.Add(newBlock);
      newBlock = blocks.Find(block => block == orderedBlocks[orderedBlocks.IndexOf(newBlock)].GetIsConnectedTo());
    }

    int repeats = 0;
    int endRepeats = 0;
    foreach (BlockUI block in orderedBlocks) {
      if (block.CompareTag("Repeat Block")) repeats++;
      else if (block.CompareTag("End Repeat Block")) endRepeats++;
    }

    if (repeats > endRepeats) {
      FindObjectOfType<DataManager>().forgotEndRepeat++;
      if(popUp.activeSelf == false) {
        popUp.SetActive(true);
      }
    } else if(repeats == endRepeats){
      popUp.SetActive(false);
    }

    // Update Repeat Blocks in array 
    orderedBlocks = UpdateForBlocks(orderedBlocks);

    return orderedBlocks;
  }

  private List<BlockUI> UpdateForBlocks(List<BlockUI> blocks) {
    int forIndex = -1;
    List<int> times = new List<int>();
    List<BlockUI> insideFor = new List<BlockUI>();
    
    Dictionary<int, List<BlockUI>> blocksInsideFor = new Dictionary<int, List<BlockUI>>();
    
    bool willAdd = false;

    for (var i = 0; i < blocks.Count; i++) {
      if (willAdd) { 
        if (blocks[i].CompareTag("End Repeat Block")) {
          List<BlockUI> temp = new List<BlockUI>();
          foreach(BlockUI b in insideFor) {
            temp.Add(b);
          }

          blocksInsideFor.Add(forIndex, temp);
          insideFor.Clear();

          willAdd = false;

          blocks.Remove(blocks[i]);
          i--;
        }
        
        else if (blocks[i].CompareTag("Repeat Block")) {
          List<BlockUI> temp = new List<BlockUI>();
          for (int ini = i, endCount = 0; ini < blocks.Count; ini++) {
            temp.Add(blocks[ini]);
            if(blocks[ini].CompareTag("Repeat Block")){
              endCount++;
            } else if (blocks[ini].CompareTag("End Repeat Block")) {
              endCount--;
              if(endCount == 0) break;
            }
          }

          blocks.RemoveRange(i, temp.Count);
          i--;

          temp = UpdateForBlocks(temp);

          foreach (BlockUI block in temp) {
            insideFor.Add(block);
          }
        }

        else {
          insideFor.Add(blocks[i]);
          blocks.Remove(blocks[i]);
          i--;
        }
      } /* end if(willAdd) */
      
      else if (blocks[i].CompareTag("Repeat Block") && !willAdd) {
        forIndex++;
        times.Add(int.Parse(blocks[i].GetComponent<RepeatBlockUI>().InputValue));
        willAdd = true;
      }
    }

    forIndex = -1;
    List<BlockUI> finalCode = new List<BlockUI>();
    foreach (BlockUI block in blocks) {
      if (block.CompareTag("Repeat Block")) {
        forIndex++;
        for (int i = 0; i < times[forIndex]; i++) {
          var bif = blocksInsideFor[forIndex];

          for (int j = 0; j < bif.Count; j++) {
            finalCode.Insert(finalCode.Count, bif[j]);
          }
        }
      } else {
        finalCode.Insert(finalCode.Count, block);
      }
    }

    return finalCode;
  }
}
