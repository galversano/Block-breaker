/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float velocityX = 1f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f; 

    Vector2 paddleToBallVector;
    bool hasStarted = false;
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBall();
            LaunchBallClick();
        }

    }
    private void LaunchBallClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(velocityX, velocityY);
          
        }
    }
    private void LockBall()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void OnCollisionEnter2D (Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor)); 
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
