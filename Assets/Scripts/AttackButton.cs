using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackButton : MonoBehaviour
{
  [SerializeField] TMP_InputField _field;

  public void OnAttackClick()
  {
    var args = new EventBus.AttackEventArgs(int.Parse(_field.text));
    EventBus.PublishAttackEvent(args);
  }
}
