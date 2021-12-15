using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWithInputUI : BlockUI {
  private string inputValue1;
  public string InputValue1 { get => inputValue1; set => inputValue1 = value; }
  
  private string inputValue2;
  public string InputValue2 { get => inputValue2; set => inputValue2 = value; }
}
