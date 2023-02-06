using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
  public static EventBus instance;

  private void Awake()
  {
    instance = this;
  }

  public class PlayerAreaReachedEventArgs
  {
    public Enemy enemy;
  }
  public delegate void PlayerAreaReachedEventDelegate(PlayerAreaReachedEventArgs e);
  public event PlayerAreaReachedEventDelegate OnPlayerAreaReached;
  public static void PublishPlayerAreaReachedEvent(PlayerAreaReachedEventArgs e)
  {
    instance.OnPlayerAreaReached?.Invoke(e);
  }


  public class AttackEventArgs
  {
    public int Number;
    public AttackEventArgs(int number)
    {
      this.Number = number;
    }
  }
  public delegate void AttackEventDelegate(AttackEventArgs e);
  public event AttackEventDelegate OnAttack;
  public static void PublishAttackEvent(AttackEventArgs e)
  {
    instance.OnAttack?.Invoke(e);
  }
}
