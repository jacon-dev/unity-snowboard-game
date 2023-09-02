using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ParticleSystem snowEffect;
    private Rigidbody2D rigidBody;
    private float torqueAmount = 10;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
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
}
