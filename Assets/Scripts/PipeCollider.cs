using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollider : MonoBehaviour
{
    public Collider2D collider;
    private BirdScript bird;
    private bool enabled = true;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bird.getIsAlive() && enabled) {
            StartCoroutine(DisableCollider());
        }
    }

    IEnumerator DisableCollider() {
        Debug.Log("Disabling pipe collider");
        enabled = false;
        yield return new WaitForSeconds(1);
        collider.enabled = false;
    }
}
