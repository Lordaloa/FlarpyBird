using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTriggerSuccess : MonoBehaviour
{
    private LogicManager logicManager;
    private BirdScript bird;
    // Start is called before the first frame update
    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && bird.getIsAlive()) {
            logicManager.addScore(1);
        }
    }
}
