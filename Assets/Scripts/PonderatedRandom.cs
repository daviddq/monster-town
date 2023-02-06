using System;
using System.Collections.Generic;

public class PonderatedRandom
{
  private List<PonderatedValue> ponderatedValues;
  private int totalWeight;

  public PonderatedRandom(List<PonderatedValue> ponderatedValues)
  {
    this.ponderatedValues = ponderatedValues;
    totalWeight = 0;

    foreach (var entry in ponderatedValues)
    {
      totalWeight += entry.Ponderation;
    }
  }

  public int GetRandomValue()
  {
    int randomWeight = UnityEngine.Random.Range(0, totalWeight);
    int currentWeight = 0;
    foreach (var entry in ponderatedValues)
    {
      currentWeight += entry.Ponderation;
      if (randomWeight < currentWeight)
      {
        return entry.Value;
      }
    }
    return ponderatedValues[ponderatedValues.Count - 1].Value;
  }
}
