using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject[] Pipes;
    public float spawnRate = 6;

    public float HeightOffset = 10;
    private float timer;

    private float timerTillIncrease;
    public float nextIncrease;

    public float moveSpeed = 6;
    public float deadzone = -45;


    private BirdScript bird;

    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.getHasGameStarted()) {
            if (timer < spawnRate) {
                timer += Time.deltaTime;
                timerTillIncrease += Time.deltaTime;
            } else {
                timer = 0;
                SpawnPipe();
            }
            if (timerTillIncrease > nextIncrease && spawnRate > 1) {
                //||moveSpeed < 100
                increaseDifficulty();
            }   

        }
    }

    void SpawnPipe() {
        float lowestPoint = transform.position.y - HeightOffset;
        float heighestPoint = transform.position.y + HeightOffset;
        Vector3 position = new Vector3(transform.position.x,Random.Range(lowestPoint,heighestPoint),transform.position.z);
        Instantiate(Pipes[Random.Range(0,Pipes.Length)], position, transform.rotation);
    }

    [ContextMenu("IncreaseDifficulty")]
    void increaseDifficulty() {
        nextIncrease += timerTillIncrease/10;
        timerTillIncrease = 0;
        spawnRate -= spawnRate/10;
        //moveSpeed += moveSpeed/5;
        Debug.Log("nextIncrease: "+nextIncrease+", spawnRate: "+spawnRate+", moveSpeed: "+moveSpeed);
    }
}
