using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D BirdRigidbody; 
    private float Gravity = 0;
    public float FlapStrength = 10;

    public Animator animator;

    public AudioSource FlapSound;

    private LogicManager logicManager;

    private bool isAlive = true;

    private bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        isAlive = true;
        gameStarted = false;
        Gravity = BirdRigidbody.gravityScale;
        BirdRigidbody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive) {
            Flap();
        } else {
            foreach (Touch touch in Input.touches) {
                if (touch.fingerId == 0) {
                    Flap();
                }
            }
        }
        if (transform.position.y > 12.5 || transform.position.y < -12.5) {
            isAlive = false;
            logicManager.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAlive = false;
        logicManager.gameOver();
    }
    public bool getIsAlive()
    {
        return isAlive;
    }
    public bool getHasGameStarted()
    {
        return gameStarted;
    }

    public void Flap() {
        Debug.Log("Flap");
        if (!gameStarted) {
            gameStarted = true;
            animator.SetBool("GameStarted",gameStarted);
            BirdRigidbody.gravityScale = Gravity;
        }
        animator.SetTrigger("Flap");
        BirdRigidbody.velocity = Vector2.up * FlapStrength;
        FlapSound.Play();
    }
}
