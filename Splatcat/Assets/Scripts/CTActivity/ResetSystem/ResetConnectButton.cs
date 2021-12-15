using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetConnectButton : ResetObject {
  public override void Reset() {
    GetComponent<Image>().color = Color.white;
  }
}
