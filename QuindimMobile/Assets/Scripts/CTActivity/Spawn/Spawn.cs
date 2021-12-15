using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Spawn : MonoBehaviour {
  public GameObject prefab;
  [System.NonSerialized] public int index;

  public virtual void CreateNewObject(string objectName) {
    GetComponent<BlocksSlot>().IsEmpty = false;

    var obj = Instantiate(prefab);
    obj.transform.SetParent(GetComponentInParent<Canvas>().transform);
    obj.GetComponent<RectTransform>().localPosition = new Vector3(GetComponent<RectTransform>().localPosition.x,
                                                                        GetComponent<RectTransform>().localPosition.y,
                                                                        1);
    obj.transform.localScale = new Vector3(1, 1, 0);
    obj.name = $"{objectName} {index}";
    
    if (SceneManager.GetActiveScene().name.Equals("CT Manchas 0") && obj.name.Equals("Walk Block 0")) {
      GetComponent<BlocksSlot>().beginTutorial = true;
      FindObjectOfType<CTTutorialManager>().walkBlock = obj;
    }
  }
}
