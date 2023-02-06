using UnityEngine;

public class GameController : MonoBehaviour
{
  public enum GameState
  {
    Running,
    GameOver
  }

  public static GameState State { get; private set; } = GameState.Running;

  public static bool IsGameOver => State == GameState.GameOver;

  void Start()
  {
    EventBus.instance.OnPlayerAreaReached += OnPlayerAreaReached;
  }

  void OnDestroy()
  {
    EventBus.instance.OnPlayerAreaReached -= OnPlayerAreaReached;
  }

  void OnPlayerAreaReached(EventBus.PlayerAreaReachedEventArgs args)
  {
    GameController.State = GameState.GameOver;
  }
}
