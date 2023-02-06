using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
  enum Planning
  {
    Random = 0,
    RoundRobin = 1
  }

  [SerializeField] private Planning _planning = Planning.RoundRobin;
  [SerializeField] private Transform[] _spawnPoints;
  [SerializeField] private List<WaveScriptableObject> _waves = new List<WaveScriptableObject>();
  private int _currentWave = -1;
  int _nextSpawnPoint = 0;
  float _timeToNextSpawn;
  int _killsToNextWave;
  PonderatedRandom _factorsGenerator;

  void Awake()
  {
    NextWave();
  }

  void Start()
  {
    EventBus.instance.OnEnemyKilled += OnEnemyKilled;
  }

  void OnDestroy()
  {
    EventBus.instance.OnEnemyKilled -= OnEnemyKilled;
  }

  public bool GameIsFinished { get { return GameController.IsGameFinished || _currentWave >= _waves.Count; } }

  void OnEnemyKilled(EventBus.EnemyKilledEventArgs args)
  {
    if (GameIsFinished) return;

    --_killsToNextWave;
    if (_killsToNextWave <= 0)
    {
      NextWave();
    }
  }

  void NextWave()
  {
    ++_currentWave;

    if (_currentWave >= _waves.Count)
    {
      Debug.Log("Game Win");

      EventBus.PublishGameWinEvent();
      return;
    }

    Debug.Log($"Current wave: {_currentWave}");

    _timeToNextSpawn = _waves[_currentWave].TimeBetweenSpawns;
    _killsToNextWave = _waves[_currentWave].WaveEnemyCount;
    _factorsGenerator = new PonderatedRandom(_waves[_currentWave].PonderatedFactors);
  }

  // Update is called once per frame
  void Update()
  {
    if (GameIsFinished) return;

    if (_currentWave >= _waves.Count) return;

    _timeToNextSpawn -= Time.deltaTime;

    if (_timeToNextSpawn <= 0)
    {
      SpawnEnemy();
      _timeToNextSpawn = _waves[_currentWave].TimeBetweenSpawns;
    }
  }

  private GameObject SpawnEnemy()
  {
    GameObject prefab = Resources.Load("Prefabs/Enemy") as GameObject; // TODO pick from the Wave info
    GameObject go = Instantiate(prefab);
    Enemy enemy = go.GetComponent<Enemy>();

    float speed = Random.Range(_waves[_currentWave].MinEnemySpeed, _waves[_currentWave].MaxEnemySpeed);
    (string operation, int result) = GetMultiplication();

    enemy.Initialize(speed, operation, result);

    //enemy.transform.SetParent(_canvas.transform, false);
    Transform spawnPoint = GetNextSpawnPoint();
    go.transform.position = spawnPoint.position;

    return go;
  }

  private Transform GetNextSpawnPoint()
  {
    int index;
    switch (_planning)
    {
      case Planning.Random:
        index = Random.Range(0, _spawnPoints.Length);
        break;

      case Planning.RoundRobin:
      default:
        _nextSpawnPoint = _nextSpawnPoint >= _spawnPoints.Length - 1 ? 0 : _nextSpawnPoint + 1;
        index = _nextSpawnPoint;
        break;
    }

    return _spawnPoints[index];
  }

  private (string, int) GetMultiplication()
  {
    int factor1 = _factorsGenerator.GetRandomValue();
    int factor2 = _factorsGenerator.GetRandomValue();

    return (string.Format("{0}x{1}", factor1, factor2), factor1 * factor2);
  }
}
