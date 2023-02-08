using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
  public static EventBus instance;

  private void Awake()
  {
    instance = this;
  }

  public delegate void EnemyReachedPlayerEventDelegate(Enemy enemy);
  public event EnemyReachedPlayerEventDelegate OnEnemyReachedPlayer;
  public static void PublishEnemyReachedPlayerEvent(Enemy enemy)
  {
    instance.OnEnemyReachedPlayer?.Invoke(enemy);
  }

  public delegate void AttackEventDelegate(int number);
  public event AttackEventDelegate OnAttack;
  public static void PublishAttackEvent(int number)
  {
    instance.OnAttack?.Invoke(number);
  }

  public delegate void EnemyKilledEventDelegate(Enemy enemy);
  public event EnemyKilledEventDelegate OnEnemyKilled;
  public static void PublishEnemyKilledEvent(Enemy enemy)
  {
    instance.OnEnemyKilled?.Invoke(enemy);
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

  public delegate void NewWaveEventDelegate(int wave);
  public event NewWaveEventDelegate OnNewWave;
  public static void PublishNextWaveEvent(int wave)
  {
    instance.OnNewWave?.Invoke(wave);
  }
}
