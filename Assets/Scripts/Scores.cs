using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scores : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI _wave;
  [SerializeField] private TextMeshProUGUI _kills;

  int killed = 0;

  // Start is called before the first frame update
  void Start()
  {
    EventBus.instance.OnNewWave += OnNewWave;
    EventBus.instance.OnEnemyKilled += OnEnemyKilled;

    UpdateWaves(1);
    UpdateKills(killed);
  }

  void OnDestroy()
  {
    EventBus.instance.OnNewWave -= OnNewWave;
    EventBus.instance.OnEnemyKilled -= OnEnemyKilled;
  }

  void OnNewWave(int wave)
  {
    UpdateWaves(wave);
  }

  void OnEnemyKilled(Enemy enemy)
  {
    ++killed;
    UpdateKills(killed);
  }

  void UpdateWaves(int wave)
  {
    _wave.text = $"Oleada {wave}";
  }

  void UpdateKills(int kills)
  {
    _kills.text = $"Enemigos multiplicados {kills}";
  }
}
