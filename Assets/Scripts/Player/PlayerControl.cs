using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private bool _isMoving = false;
    private float _speed = 2.0f;
    private Rigidbody2D _rb2d;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    bool right = false;
    bool left = false;
    bool up = false;
    bool down = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        right = Input.GetButton("GoRight");
        left = Input.GetButton("GoLeft");
        up = Input.GetButton("GoUp");
        down = Input.GetButton("GoDown");

        _isMoving = right || left || up || down;

        if (_isMoving)
        {
            _animator.SetFloat("Speed", 10);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }

        if (right)
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
            _spriteRenderer.flipX = false;
        }
        else
        {
            if (left)
            {
                transform.position += Vector3.right * -_speed * Time.deltaTime;
                _spriteRenderer.flipX = true;
            }
            else
            {
                if (up)
                {
                    transform.position += Vector3.up * _speed * Time.deltaTime;
                }
                else
                {
                    if (down)
                    {
                        transform.position += Vector3.up * -_speed * Time.deltaTime;
                    }
                    else
                    {
                        // not moving;
                        _isMoving = false;
                    }
                }
            }
        }
    }
}
