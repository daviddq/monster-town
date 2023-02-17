using TMPro;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
  private Vector2 _fingerDown;
  private Vector2 _fingerUp;

  private float _swipeThreshold = 100f;

  [SerializeField] private TextMeshProUGUI _text;
  private int _value;

  public void SetValue(int value)
  {
    _value = value;
    _text.text = _value.ToString();
  }

  void Update()
  {
    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    {
      _fingerDown = Input.GetTouch(0).position;
    }

    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
    {
      _fingerUp = Input.GetTouch(0).position;

      if (_fingerUp.x < _fingerDown.x && Mathf.Abs(_fingerUp.x - _fingerDown.x) > _swipeThreshold)
      {
        Debug.Log("Swipe Left");
      }
      else if (_fingerUp.x > _fingerDown.x && Mathf.Abs(_fingerUp.x - _fingerDown.x) > _swipeThreshold)
      {
        Debug.Log("Swipe Right");
      }
    }
    else if (Input.GetMouseButtonUp(0))
    {
      _fingerUp = Input.mousePosition;

      if (_fingerUp.x < _fingerDown.x && Mathf.Abs(_fingerUp.x - _fingerDown.x) > _swipeThreshold)
      {
        Debug.Log("Swipe Left");
      }
      else if (_fingerUp.x > _fingerDown.x && Mathf.Abs(_fingerUp.x - _fingerDown.x) > _swipeThreshold)
      {
        Debug.Log("Swipe Right");
      }
    }
  }
}
