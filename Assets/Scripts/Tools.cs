using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using TMPro;
using UnityEngine.SceneManagement;

public class Tools : MonoBehaviour
{
  [SerializeField] float _offsetX = 0f;
  [SerializeField] float _offsetY = 0f;
  [SerializeField] float _gapX = .5f;
  [SerializeField] float _gapY = .5f;

  [SerializeField] Transform _canvas;

  [Button]
  public void ArrangeLevelButtons()
  {
    int x = 0;
    int y = 0;
    int n = 1;

    for (int i = 0; i < _canvas.childCount; ++i)
    {
      GameObject button = _canvas.GetChild(i).gameObject;

      if (!button.name.StartsWith("Button"))
        continue;

      button.transform.position = new Vector2(_offsetX + x * _gapX, _offsetY + y * _gapY);

      TextMeshProUGUI label = button.GetComponentInChildren<TextMeshProUGUI>();
      label.text = n.ToString();

      ++n;

      ++x;
      if (x >= 10)
      {
        x = 0;
        ++y;
      }
    }
  }

  public void GoToScene()
  {
    SceneManager.LoadScene(2);
  }
}
