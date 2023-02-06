using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
  public void OnAttackClick()
  {
    var args = new EventBus.AttackEventArgs(10);
    EventBus.PublishAttackEvent(args);
  }
}
