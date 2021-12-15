using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCTMaster : ResetObject {
  public override void Reset() {
    CTMaster ctm = GetComponent<CTMaster>();

    ctm.ranAllCode = false;
    ctm.isInWinSquare = false;
    ctm.isOutOfBoundaries = false;
    ctm.gotRightResult = false;
    ctm.doneOnce = false;
  }
}
