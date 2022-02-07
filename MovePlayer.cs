using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _powerJump;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private float _valueForRunAnimation;
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
            _valueForRunAnimation = 1;

            _animator.SetFloat(Speed, _valueForRunAnimation);
            _spriteRenderer.flipX = false;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _valueForRunAnimation = 1;

            _animator.SetFloat(Speed, _valueForRunAnimation);
            _spriteRenderer.flipX = true;
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }
    }

    private void IdleAnimation()
    {
        _valueForRunAnimation = 0;
        _animator.SetFloat(Speed, _valueForRunAnimation);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals(Ground))
        {
            _touchGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals(Ground))
        {
            _touchGround = false;
        }
    }
}
