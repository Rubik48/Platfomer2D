using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _powerJump;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private float _axisY = 0;
    private float _axisZ = 0;
    private float _runAnimation = 1;
    private float _stopAnimation = 0;
    private float _valueForAnimator;
    private bool _touchGround;
    private const string Jump = nameof(Jump);
    private const string Ground = nameof(Ground);
    private const string Speed = nameof(Speed);

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _rigidbody2D.freezeRotation = true;
    }

    private void Update()
    {
        IdleAnimation();

        if (Input.GetKey(KeyCode.Space) && _touchGround)
        {
            _animator.SetTrigger(Jump);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _powerJump);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _valueForAnimator = _runAnimation;

            _animator.SetFloat(Speed, _valueForAnimator);
            _spriteRenderer.flipX = false;
            transform.Translate(_speed * Time.deltaTime, _axisY, _axisZ);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _valueForAnimator = _runAnimation;

            _animator.SetFloat(Speed, _valueForAnimator);
            _spriteRenderer.flipX = true;
            transform.Translate(_speed * Time.deltaTime * -1, _axisY, _axisZ);
        }
    }

    private void IdleAnimation()
    {
        _valueForAnimator = _stopAnimation;
        _animator.SetFloat(Speed, _valueForAnimator);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _touchGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _touchGround = false;
        }
    }
}
