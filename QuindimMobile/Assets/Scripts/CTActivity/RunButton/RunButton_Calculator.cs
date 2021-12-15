using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RunButton_Calculator : RunButton_Utils{
  private List<BlockUI> blocks;
  private List<BlockUI> connectedBlocks = new List<BlockUI>();

  private double problemResult = 0;
  
  private enum Measure {
    SquareCentimeter,
    Liters
  }
  
  [SerializeField] private Measure measure;
  [SerializeField] private double solution;
  
  [SerializeField] private bool isAMultipleCalculusProblem;
  private MultipleCalculusProblem mcp;

  [SerializeField] private TMP_Text[] answerText;

  private bool isPressed = false;

  private void Update() {
    blocks = new List<BlockUI>(FindObjectsOfType<BlockUI>());
    if(isAMultipleCalculusProblem) mcp = FindObjectOfType<MultipleCalculusProblem>();
  }

  public void Clicked() {
    FindObjectOfType<AudioManager>().Play("Click");
    connectedBlocks.Clear();

    problemResult = 0;

    isPressed = !isPressed;

    // Get all connected blocks
    connectedBlocks = GetConnectedBlocks(blocks);

    // Runs code if the first block is the Beginning Block and the last block is the End Block
    if (connectedBlocks[0].CompareTag("Beginning Block") && connectedBlocks[connectedBlocks.Count - 1].CompareTag("End Block")) {
      RunCode(connectedBlocks);
    }
  }

  private void RunCode(List<BlockUI> connectedBlocks) {
    foreach (BlockUI block in connectedBlocks) {
      switch (block.tag) {
        case "Plus Block": {
          double.TryParse(block.gameObject.GetComponent<PlusBlockUI>().InputValue1, out double value1);
          double.TryParse(block.gameObject.GetComponent<PlusBlockUI>().InputValue2, out double value2);

          if (value1 == 0) {
            problemResult = block.GetComponent<PlusBlockUI>().Plus(problemResult, value2);
          } else if(value2 == 0) {
            problemResult = block.GetComponent<PlusBlockUI>().Plus(value1, problemResult);
          } else {
            problemResult = block.GetComponent<PlusBlockUI>().Plus(value1, value2);
          }
          break;
        }
        case "Minus Block": {
          double.TryParse(block.gameObject.GetComponent<MinusBlockUI>().InputValue1, out double value1);
          double.TryParse(block.gameObject.GetComponent<MinusBlockUI>().InputValue2, out double value2);

          if (value1 == 0) {
            problemResult = block.GetComponent<MinusBlockUI>().Minus(problemResult, value2);
          } else if (value2 == 0) {
            problemResult = block.GetComponent<MinusBlockUI>().Minus(value1, problemResult);
          } else {
            problemResult = block.GetComponent<MinusBlockUI>().Minus(value1, value2);
          }
          break;
        }
        case "Times Block": {
          double.TryParse(block.gameObject.GetComponent<TimesBlockUI>().InputValue1, out double value1);
          double.TryParse(block.gameObject.GetComponent<TimesBlockUI>().InputValue2, out double value2);

          if (value1 == 0) {
            problemResult = block.GetComponent<TimesBlockUI>().Times(problemResult, value2);
          } else if (value2 == 0) {
            problemResult = block.GetComponent<TimesBlockUI>().Times(value1, problemResult);
          } else {
            problemResult = block.GetComponent<TimesBlockUI>().Times(value1, value2);
          }
          break;
        }
        case "Division Block": {
          double.TryParse(block.gameObject.GetComponent<DivisionBlockUI>().InputValue1, out double value1);
          double.TryParse(block.gameObject.GetComponent<DivisionBlockUI>().InputValue2, out double value2);

          if (value1 == 0) {
            problemResult = block.GetComponent<DivisionBlockUI>().Division(problemResult, value2);
          } else if (value2 == 0) {
            problemResult = block.GetComponent<DivisionBlockUI>().Division(value1, problemResult);
          } else {
            problemResult = block.GetComponent<DivisionBlockUI>().Division(value1, value2);
          }
          break;
        }
        case "End Block": {
          if (isAMultipleCalculusProblem) {
            HandleMultipleCalculusProblem();
          } else {
            answerText[0].text = problemResult.ToString() + DisplayMeasure();
            CheckAnswer(0);
          }
          break; 
        }
        default: {
          break;
        }
      }
    }
  }

  private void HandleMultipleCalculusProblem() {
    switch ((mcp.phase - 1).ToString()) {
      case "1": {
          answerText[0].text = problemResult.ToString() + DisplayMeasure();
          mcp.DisplayNextSentence();
          break;
        }
      case "2": {
          answerText[1].text = problemResult.ToString() + DisplayMeasure();
          mcp.DisplayNextSentence();
          break;
        }
      case "3": {
          answerText[2].text = problemResult.ToString() + DisplayMeasure();
          CheckAnswer(2);
          break;
        }
    }
  }

  private void CheckAnswer(int index) {
    if (solution == problemResult) {
      answerText[index].color = Color.green;

      ctm.gotRightResult = true;
    } else {
      answerText[index].color = Color.red;

      ctm.gotRightResult = false;
    }
    ctm.ranAllCode = true;
    ctm.Finished();
  }

  private string DisplayMeasure() {
    switch (measure) {
      case Measure.SquareCentimeter: {
        return "cm^2";
      }
      case Measure.Liters: {
        return "L";
      }
      default: {
        return "";
      }
    }
  }
}
