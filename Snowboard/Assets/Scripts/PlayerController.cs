using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ParticleSystem snowEffect;
    private Rigidbody2D rigidBody;
    private SurfaceEffector2D surfaceEffector;
    private float torqueAmount = 10;
    private float baseSpeed = 18;
    private float boostSpeed = 25;
    private bool canMove = true;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            BoostPlayer();
        }
    }

    private void BoostPlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector.speed = boostSpeed;
        }
        else
        {
            surfaceEffector.speed = baseSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.AddTorque(-torqueAmount);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        snowEffect.Play();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        snowEffect.Stop();
    }

    public void DisableControls()
    {
        canMove = false;
    }
}
