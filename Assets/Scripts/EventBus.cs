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
    public Enemy Enemy;

    public PlayerAreaReachedEventArgs(Enemy enemy)
    {
      this.Enemy = enemy;
    }
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

  public class EnemyKilledEventArgs
  {
    public Enemy Enemy;
    public EnemyKilledEventArgs(Enemy enemy)
    {
      this.Enemy = enemy;
    }
  }
  public delegate void EnemyKilledEventDelegate(EnemyKilledEventArgs e);
  public event EnemyKilledEventDelegate OnEnemyKilled;
  public static void PublishEnemyKilledEvent(EnemyKilledEventArgs e)
  {
    instance.OnEnemyKilled?.Invoke(e);
  }

  public delegate void GameWinEventDelegate();
  public event GameWinEventDelegate OnGameWin;
  public static void PublishGameWinEvent()
  {
    instance.OnGameWin?.Invoke();
  }

  public delegate void GameOverEventDelegate();
  public event GameOverEventDelegate OnGameOver;
  public static void PublishGameOverEvent()
  {
    instance.OnGameOver?.Invoke();
  }
}
