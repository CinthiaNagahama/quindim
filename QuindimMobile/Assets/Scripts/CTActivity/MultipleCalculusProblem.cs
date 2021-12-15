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

    nextSentences.Push("Agora falta só achar a área total. UwU");
    nextSentences.Push("Muito bom. Agora vamos encontrar a área da próxima face");
    nextSentences.Push("Para isso são necessários alguns passos e algumas variáveis. Primeiro vamos encontrar a área de uma das faces " +
      "e guardar o valor em uma variável \"face1\" ");
    nextSentences.Push("Incrível, meu aquário, então, tem 90cm x 40cm de base. Eu quero que ele tenha meio metro de altura." +
      " Quantos cm^2 de vidro devo comprar para fazer todas as faces do aquário e não sobrar nem faltar material?");
    
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
