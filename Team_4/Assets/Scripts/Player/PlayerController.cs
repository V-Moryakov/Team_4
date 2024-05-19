using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce = 6;
    public float speed = 4;
    private bool isSeat = false; // если сидит, чтобы не бегал
    public bool isSteals = false; // находится ли в стелсе

    public Animator animator;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;

    private CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {   //управление WSAD
        MoveUpdate();
        if (_characterController.height < 2)
        {
            Invoke("Stay", 3f);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {   //Прыжок с рачетом свободного падения с правильной физикой
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }

    private void MoveUpdate()
    {
        _moveVector = Vector3.zero;
        var runDirection = 0;
        if (isSteals)
        {
            speed = 2;
            if (Input.GetKey(KeyCode.W))
            {
                _moveVector += transform.forward;
                runDirection = 7;
            }

            if (Input.GetKey(KeyCode.S))
            {
                _moveVector -= transform.forward;
                runDirection = 7;
            }

            if (Input.GetKey(KeyCode.D))
            {
                _moveVector += transform.right;
                runDirection = 7;
            }

            if (Input.GetKey(KeyCode.A))
            {
                _moveVector -= transform.right;
                runDirection = 7;
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                isSteals = !isSteals;
                runDirection = 8;
            }
        }
        else if (!isSteals)
        {
            speed = 4;
            if (isSeat != true)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    _moveVector += transform.forward;
                    runDirection = 1;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    _moveVector -= transform.forward;
                    runDirection = 2;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    _moveVector += transform.right;
                    runDirection = 3;
                }

                if (Input.GetKey(KeyCode.A))
                {
                    _moveVector -= transform.right;
                    runDirection = 4;
                }

                if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
                {
                    _fallVelocity = -jumpForce;
                }
                //прыжок
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    isSteals = !isSteals;
                    runDirection = 7;
                }
                //чтение указателей
                if (Input.GetKey(KeyCode.F))
                {
                    runDirection = 6;
                }

                //смотрит инвертарь
                if (Input.GetKey(KeyCode.I))
                {
                    runDirection = 9;
                }
            }
        }

        //сбор дропа
        if (Input.GetKey(KeyCode.E))
        {
            if (_characterController.height == 2.0f)
            {
                isSeat = true;
                Invoke("Sit", 0.5f);
            }
            runDirection = 5;
        }

        animator.SetInteger("run direction", runDirection);
    }

    void Stay()
    {
        _characterController.height = 2f;
        Invoke("Go", 0.5f);
    }

    void Sit()
    {
        _characterController.height = 1.2f;
    }

    void Go()
    {
        isSeat = false;
    }
}
