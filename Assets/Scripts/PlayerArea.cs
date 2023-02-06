using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D collision)
  {
    Enemy enemy = collision.gameObject.GetComponentInParent<Enemy>();
    if (!enemy) return;

    var args = new EventBus.PlayerAreaReachedEventArgs(enemy);
    EventBus.PublishPlayerAreaReachedEvent(args);
  }
}
