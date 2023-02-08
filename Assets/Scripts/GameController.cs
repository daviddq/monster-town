using UnityEngine;

public class GameController : MonoBehaviour
{
  public enum GameState
  {
    Running,
    GameOver,
    GameWin
  }

  static GameState State { get; set; } = GameState.Running;

  public static bool IsGameOver => State == GameState.GameOver;
  public static bool IsGameWin => State == GameState.GameWin;
  public static bool IsGameFinished => IsGameOver || IsGameWin;

  void Start()
  {
    EventBus.instance.OnEnemyReachedPlayer += OnPlayerAreaReached;
    EventBus.instance.OnGameWin += OnGameWin;
    EventBus.instance.OnGameOver += OnGameOver;
  }

  void OnDestroy()
  {
    EventBus.instance.OnEnemyReachedPlayer -= OnPlayerAreaReached;
    EventBus.instance.OnGameWin -= OnGameWin;
    EventBus.instance.OnGameOver -= OnGameOver;
  }

  void OnPlayerAreaReached(Enemy enemy)
  {
    GameController.State = GameState.GameOver;
  }
  void OnGameWin()
  {
    GameController.State = GameState.GameWin;
  }

  void OnGameOver()
  {
    GameController.State = GameState.GameOver;
  }
}
