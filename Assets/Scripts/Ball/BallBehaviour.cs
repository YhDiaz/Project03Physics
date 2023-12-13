using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float timeToDie;
    public float ballMass = 1;

    private void Start()
    {
        if (timeToDie == 0) timeToDie = 3f;
    }

    private void Update()
    {
        timeToDie -= Time.deltaTime;

        if (timeToDie <= 0)
        {
            GameObject.Find("Player").GetComponent<PlayerShoot>().instancedBall = null;
            Destroy(gameObject);
        }

        if (Input.GetKey(KeyCode.W) && ballMass < 10)
        {
            ballMass += 0.1f;
        }

        if (Input.GetKey(KeyCode.S) && ballMass > 1)
        {
            ballMass -= 0.1f;
        }

        GetComponent<Rigidbody>().mass = ballMass;
    }
}
