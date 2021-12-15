using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

  private Queue<string> sentences;

  public Animator animator;

  public TextMeshProUGUI nameText;
  public TextMeshProUGUI dialogueText;

  public Button[] buttons;
  private CTManager ctManager;
  private Dialogue currentDialogue;
  private GameObject dialogueBox;

  // Start is called before the first frame update
  void Start() {
    sentences = new Queue<string>();
    ctManager = FindObjectOfType<CTManager>();
  }

  public void StartDialogue(Dialogue dialogue, GameObject dialogueBox) {
    currentDialogue = dialogue;
    this.dialogueBox = dialogueBox;

    animator.SetBool("isOpen", true);
    nameText.text = dialogue.name;

    sentences.Clear();

    foreach(string sentence in dialogue.sentences) {
      sentences.Enqueue(sentence);
    }

    foreach (Button btn in buttons) {
      if (btn.name.Equals("Continue Button")) btn.gameObject.SetActive(true);
      else btn.gameObject.SetActive(false);
    }

    DisplayNextSentence();
  }

  public void DisplayNextSentence() {
    if (sentences.Count == 1 && currentDialogue.makeCT) {
      foreach (Button btn in buttons) {
        if (btn.name.Equals("Continue Button")) btn.gameObject.SetActive(false);
        else btn.gameObject.SetActive(true);
      }
    } else if (sentences.Count == 0) {
      EndDialogue();
      return;
    }

    string sentence = sentences.Dequeue();
    StopAllCoroutines();
    StartCoroutine(TypeSentence(sentence));
  }

  public void FirstOption() {
    TriggerCT(currentDialogue.name);
  }

  public void SecondOption() {
    EndDialogue();
  }

  IEnumerator TypeSentence(string sentence) {
    dialogueText.text = "";

    foreach(char letter in sentence.ToCharArray()) {
      dialogueText.text += letter;
      yield return null;
    }
  }

  private void EndDialogue() {
    animator.SetBool("isOpen", false);
    dialogueBox.SetActive(false);

    Debug.Log(currentDialogue.name + " | " + ctManager.CountCTs(currentDialogue.name));
    
    if (currentDialogue.startEndCredits) SceneManager.LoadScene("Credits");
  }

  private void TriggerCT(string triggerCharacterName) {
    FindObjectOfType<CTManager>().StartCT(ctManager.CountCTs(triggerCharacterName), triggerCharacterName);
  }
}
