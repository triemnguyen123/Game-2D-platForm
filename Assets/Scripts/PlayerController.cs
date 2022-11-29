using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float _moveSpeed;
    public float _jumpForce;
    private bool _isGrounded;
    public Transform _groundPoint;
    public LayerMask _whatIsGround;
    private Rigidbody2D _rb;
    private bool canDoubleJump;
    private Animator _anim;
    private SpriteRenderer _SR;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    


    private void Awake()
    {
        instance = this;
    }



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _SR = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (knockBackCounter <= 0) 
        {
            _rb.velocity = new Vector2(_moveSpeed * Input.GetAxis("Horizontal"), _rb.velocity.y);
            _isGrounded = Physics2D.OverlapCircle(_groundPoint.position, .2f, _whatIsGround);
            if (_isGrounded)
            {
                canDoubleJump = true;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (_isGrounded)
                {
                    _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);

                }
                else if (canDoubleJump)
                {
                    _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
                    canDoubleJump = false;
                }
            }
            _anim.SetFloat("moveSpeed", Math.Abs(_rb.velocity.x));
          
            _anim.SetBool("isGrounded", _isGrounded);
            _anim.SetFloat("yVelocity", _rb.velocity.y);
            
            

            if (_rb.velocity.x < 0)
            {
                _SR.flipX = true;
            }
            else if (_rb.velocity.x > 0)
            {
                _SR.flipX = false;
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            if (!_SR.flipX)
                _rb.velocity = new Vector2(-knockBackForce, _rb.velocity.y);
            
            else
                _rb.velocity = new Vector2(knockBackForce, _rb.velocity.y);
        }
    }


    public void KnockBack()
    {
        knockBackLength = knockBackCounter;
        _rb.velocity = new Vector2(0f, knockBackForce);
        _anim.SetTrigger("isHurt");
    }

}
