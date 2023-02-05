using UnityEngine;

public class GameController : MonoBehaviour
{
  public enum GameState
  {
    Running,
    GameOver
  }

  public static GameState State { get; set; } = GameState.Running;

  public static bool IsGameOver => State == GameState.GameOver;
}
