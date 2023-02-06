using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] float _speed = 1.0f;

  string _operation = "uninitialized";
  int _result = 0;

  Animator _animator;
  SpriteRenderer _spriteRenderer;

  OverheadText _overheadText;

  void Awake()
  {
    _animator = GetComponentInChildren<Animator>();
    _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    _overheadText = GetComponentInChildren<OverheadText>();

    _spriteRenderer.flipX = true;
    _spriteRenderer.sortingOrder = (int)(-transform.position.y * 100);
    _animator.SetBool("walking", true);
  }

  void Start()
  {
    _overheadText.SetText(this._operation);
  }

  public void Initialize(string operation, int result)
  {
    this._operation = operation;
    this._result = result;
  }

  void OnEnable()
  {
    EventBus.instance.OnAttack += OnAttack;
  }

  void OnDisable()
  {
    EventBus.instance.OnAttack -= OnAttack;
  }

  void OnAttack(EventBus.AttackEventArgs args)
  {
    if (args.Number == this._result)
      Destroy(this.gameObject);
  }

  private void Update()
  {
    if (GameController.IsGameOver) return;

    transform.Translate(Vector3.left * _speed * Time.deltaTime);
  }
}
