using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackButton : MonoBehaviour
{
  [SerializeField] TMP_InputField _field;

  public void OnAttackClick()
  {
    EventBus.PublishAttackEvent(int.Parse(_field.text));
  }
}
