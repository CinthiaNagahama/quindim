using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour {
  public Button[] tutBtns;
  public TextMeshProUGUI header;
  public Animator animator;

  void Start() {
    tutBtns[0].Select();
    WalkTut();
  }

  public void WalkTut() {
    header.text = "Andar()";
    animator.SetInteger("whichTut", 0);
  }
  public void TurnTut() {
    header.text = "VirarDireita()";
    animator.SetInteger("whichTut", 1);
  }

  public void RepeatTut() {
    header.text = "Repetir(vezes)";
    animator.SetInteger("whichTut", 2);
  }

  public void PlusTut() {
    header.text = "Somar(res, res)";
    animator.SetInteger("whichTut", 3);
  }

  public void MinusTut() {
    header.text = "Subtrair(res, res)";
    animator.SetInteger("whichTut", 4);
  }

  public void TimesTut() {
    header.text = "Multiplicar(res, res)";
    animator.SetInteger("whichTut", 5);
  }

  public void DivisionTut() {
    header.text = "Dividir(res, res)";
    animator.SetInteger("whichTut", 6);
  }
}
