using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultipleCalculusProblem : MonoBehaviour {
  private readonly Stack<string> nextSentences = new Stack<string>();
  private readonly Stack<string> previousSentences = new Stack<string>();

  private TextMeshProUGUI problemText;
  public int phase = 0;

  void Start() {
    problemText = GetComponent<TextMeshProUGUI>();

    nextSentences.Push("Agora falta s� achar a �rea total. UwU");
    nextSentences.Push("Muito bom. Agora vamos encontrar a �rea da pr�xima face");
    nextSentences.Push("Para isso s�o necess�rios alguns passos e algumas vari�veis. Primeiro vamos encontrar a �rea de uma das faces " +
      "e guardar o valor em uma vari�vel \"face1\" ");
    nextSentences.Push("Incr�vel, meu aqu�rio, ent�o, tem 90cm x 40cm de base. Eu quero que ele tenha meio metro de altura." +
      " Quantos cm^2 de vidro devo comprar para fazer todas as faces do aqu�rio e n�o sobrar nem faltar material?");
    
    DisplayNextSentence();
  }

  public void DisplayNextSentence() {
    string sentence = nextSentences.Pop();
    previousSentences.Push(sentence);

    phase++;
    problemText.text = sentence;
  }

  public void DisplayPreviousSentence() {
    string sentence = previousSentences.Pop();
    nextSentences.Push(sentence);

    phase--;
    problemText.text = sentence;
  }
}
