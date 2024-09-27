using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fly : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private AudioClip wingSound;
    [SerializeField] private AudioClip collisonsound;// Reference to the wing sound clip

    private Rigidbody2D _rb;
    private AudioSource _audioSource; // Reference to the AudioSource

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _rb.velocity = Vector2.up * _velocity;

            // Play wing sound when bird flaps
            if (wingSound != null)
            {
                _audioSource.PlayOneShot(wingSound);
            }
        }
    }

    private void FixedUpdate()
    {
        // Rotate the bird based on its velocity
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audioSource.PlayOneShot(collisonsound);
        // Call GameOver when a collision happens
        GameManager.Instance.GameOver();
    }
}
