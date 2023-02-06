using UnityEngine;
using TMPro;

public class OverheadText : MonoBehaviour
{
  [SerializeField] private GameObject _targetObject;
  private GameObject _textObject;
  private Canvas _canvas;

  private string _text = "undefined";

  public void SetText(string newText)
  {
    _text = newText;
  }

  private void Start()
  {
    _canvas = FindObjectOfType<Canvas>();

    GameObject prefab = Resources.Load("Prefabs/OverheadText") as GameObject;
    _textObject = Instantiate(prefab);
    _textObject.transform.SetParent(_canvas.transform, false);

    TextMeshProUGUI text = _textObject.GetComponent<TextMeshProUGUI>();
    text.text = this._text;
  }

  private void Update()
  {
    _textObject.transform.position = _targetObject.transform.position;
  }
}
