using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static BirdController instance;

    public float bounceForce;

    public GameObject spawner;

    public bool isAlive;

    public int score;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    private Rigidbody2D myBody;

    private Animator animator;

    private bool didFlap;

    private void Awake()
    {
        score = 0;
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _MakeInstance();
        spawner = GameObject.Find("Spawner Pipe");
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

   
    private void FixedUpdate()
    {
        _Move();
    }

    void _Move()
    {
        float angel = 0f;

        if (isAlive)
        {
            if (didFlap)
            {
                didFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
        }

        if (myBody.velocity.y > 0)
        {
            angel = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
        }
        else if (myBody.velocity.y == 0)
        {
            angel = 0f;
        }
        else
        {
            angel = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
        }
        transform.rotation = Quaternion.Euler(0, 0, angel);
    }

    public void Flap()
    {
        didFlap = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PipeHolder")
        {
            audioSource.PlayOneShot(pingClip);
            score++;
            if (GameplayController.instance != null)
            {
                GameplayController.instance.SetScore(score);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Ground")
        {
            audioSource.PlayOneShot(diedClip);
            animator.SetTrigger("Die");
            isAlive = false;
            Destroy(spawner);
            if (GameplayController.instance != null)
            {
                GameplayController.instance.ShowDiePanel(score);
            }
        }
    }
}
