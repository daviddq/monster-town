using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "ScriptableObjects/Wave")]
public class WaveScriptableObject : ScriptableObject
{
  public int WaveNumber = 1;
  public int WaveEnemyCount = 10;
  public float MinEnemySpeed = 1f;
  public float MaxEnemySpeed = 1f;
  public float TimeBetweenSpawns = 3f;

  public List<PonderatedValue> PonderatedFactors = new List<PonderatedValue>();

  public List<GameObject> EnemiesPrefabs = new List<GameObject>();
}
