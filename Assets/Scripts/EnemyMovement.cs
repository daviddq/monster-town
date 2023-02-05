using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  [SerializeField] float _speed = 1.0f;

  Animator _animator;
  SpriteRenderer _spriteRenderer;

  void Awake()
  {
    _animator = GetComponentInChildren<Animator>();
    _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    _spriteRenderer.flipX = true;
    _spriteRenderer.sortingOrder = (int)(-transform.position.y * 100);
    _animator.SetBool("walking", true);
  }

  void Update()
  {
    // TODO:
    //
    // 1) did I reach the player area? player dies
    // 2) walk towards player

    transform.Translate(Vector3.left * _speed * Time.deltaTime);
  }
}
