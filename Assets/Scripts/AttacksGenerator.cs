using UnityEngine;

public class AttacksGenerator : MonoBehaviour
{
  const int AttackSlots = 10;
  
  [SerializeField] private GameObject _attackPrefab;
  [SerializeField] private float _verticalSpacing = 100f;
  [SerializeField] private float _timeBetweenGenerations = 1f;

  readonly private GameObject[] _attacks = new GameObject[AttackSlots];

  private float _timeToNextAttackGeneration = 0f;

  void Update()
  {
     _timeToNextAttackGeneration -= Time.deltaTime;
    if (_timeToNextAttackGeneration <= 0f )
    {
      _timeToNextAttackGeneration = _timeBetweenGenerations;
      GenerateAttack();
    }
  }

  // TODO: we need to know the range of results
  void GenerateAttack()
  {
    // Find an empty slot
    int freeSlotIndex = 0;
    while (freeSlotIndex < AttackSlots && _attacks[freeSlotIndex] != null)
      ++freeSlotIndex;

    if (freeSlotIndex >= AttackSlots)
      return;

    GameObject attack = _attacks[freeSlotIndex] = Instantiate(_attackPrefab, transform);
    AttackButton button = attack.GetComponent<AttackButton>();

    if (!button)
      return;

    button.SetValue(Random.Range(0, 100));
    attack.transform.localPosition = freeSlotIndex * Vector3.up * _verticalSpacing;
   
    Debug.Log((Vector3.up * _verticalSpacing).y);
  }
}
