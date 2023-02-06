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
  [SerializeField] private float _timeBetweenSpawns = 3f;

  float _timeToNextSpawn;
  int _nextSpawnPoint = 0;

  void Awake()
  {
    _timeToNextSpawn = _timeBetweenSpawns;
  }

  // Update is called once per frame
  void Update()
  {
    if (GameController.IsGameOver) return;

    _timeToNextSpawn -= Time.deltaTime;
    if (_timeToNextSpawn <= 0)
    {
      InstantiateEnemy();
      _timeToNextSpawn = _timeBetweenSpawns;
    }
  }

  private GameObject InstantiateEnemy()
  {
    GameObject prefab = Resources.Load("Prefabs/Enemy") as GameObject;
    GameObject go = Instantiate(prefab);
    Enemy enemy = go.GetComponent<Enemy>();

    (string operation, int result) = GetMultiplication(5);

    enemy.Initialize(operation, result);

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

  private (string, int) GetMultiplication(int difficulty)
  {
    int factor1 = Random.Range(0, difficulty + 1);
    int factor2 = Random.Range(0, difficulty + 1);

    return (string.Format("{0}x{1}", factor1, factor2), factor1 * factor2);
  }
}
