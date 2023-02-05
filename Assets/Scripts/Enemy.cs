using UnityEngine;

public class Enemy : MonoBehaviour
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

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.name == "PlayerArea")
      GameController.State = GameController.GameState.GameOver;
  }

  private void Update()
  {
    if (GameController.IsGameOver) return;

    transform.Translate(Vector3.left * _speed * Time.deltaTime);
  }
}
