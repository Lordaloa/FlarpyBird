using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    private float moveSpeed = 5;
    private float deadzone = -45;

    private PipeSpawner pipespawner;
    // Start is called before the first frame update
    void Start()
    {
        pipespawner = GameObject.FindGameObjectWithTag("PipeSpawner").GetComponent<PipeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = pipespawner.moveSpeed;
        deadzone = pipespawner.deadzone;
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadzone) {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
