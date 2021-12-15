using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CTMaster : MonoBehaviour {
  public bool ranAllCode = false;
  public bool isInWinSquare = false;
  public bool isOutOfBoundaries = false;
  public bool gotRightResult = false;

  public bool doneOnce = false;

  private CTManager ctManager;
  private PlayFabCTManager pfManager;

  private void Start() {
    ctManager = FindObjectOfType<CTManager>();
    pfManager = FindObjectOfType<PlayFabCTManager>();
  }

  public void Finished() {
    if(!doneOnce && ranAllCode) {
      if ((isInWinSquare && !isOutOfBoundaries) || gotRightResult) {
        Won();
      } else {
        Lost();
      }
    }
  }

  public void Won() {
    Debug.Log("You won!!!");
    doneOnce = true;

    pfManager.SendPlayerData();
    FindObjectOfType<WinScreenHandler>().TurnWinScreenActive(true);
    FindObjectOfType<AudioManager>().Play("CompleteLevel");

    StartCoroutine("Delay");
  }

  public void Lost() {
    Debug.Log("You lost... Stay determined!!!");
    doneOnce = true;
    
    // Setting old player - PathCT
    GameObject player = FindObjectOfType<TriangleMovements>()?.gameObject;

    if(player != null) {
      Color temp = Color.red;
      temp.a = 0.3f;
      player.GetComponentInChildren<SpriteRenderer>().color = temp;

      TriangleMovements tm = player.GetComponent<TriangleMovements>();
      Destroy(tm);

      ResetPlayer rp = player.GetComponent<ResetPlayer>();
      Destroy(rp);

      Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
      Destroy(rb);

      player.GetComponent<EdgeCollider2D>().enabled = false;
    }

    FindObjectOfType<ResetManager>().OnReset();
    FindObjectOfType<AudioManager>().Play("LoseLevel");
    pfManager.SendPlayerData();
  }

  IEnumerator Delay() {
    var pressed = false;
    while (!pressed) {
      if (Input.touchCount > 0 || Input.GetMouseButtonDown(0)) {
        pressed = true;
      }
      yield return null;
    }

    string sceneName = SceneManager.GetActiveScene().name;
    string level = sceneName.Substring(sceneName.Length - 1);
    string triggerCharacter = sceneName.Substring(3, sceneName.Length - 5);

    if(ctManager.CountCTs(triggerCharacter) < 4) {
      ctManager.StartCT(int.Parse(level) + 1, triggerCharacter);
    } else {
      SceneManager.LoadScene(FindObjectOfType<GameMaster>().previousLevel);
    }
  }
}
