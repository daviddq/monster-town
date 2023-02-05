using UnityEngine;

public class OverheadText : MonoBehaviour
{
  [SerializeField] private GameObject _targetObject;
  private GameObject _textObject;
  private Canvas _canvas;

  private void Start()
  {
    _canvas = FindObjectOfType<Canvas>();

    GameObject prefab = Resources.Load("Prefabs/OverheadText") as GameObject;
    _textObject = Instantiate(prefab);
    _textObject.transform.SetParent(_canvas.transform, false);
  }

  private void Update()
  {
    _textObject.transform.position = _targetObject.transform.position;
  }

  public void OnPlayerAreaReached()
  {

  }
}