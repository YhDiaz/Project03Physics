using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject instancedBall;
    public LineRenderer lineRenderer;
    public TextMeshProUGUI velText;
    public int N;
    public int framesPerSecond = 20;
    public float force;
    public float ballMass;
    public float ballVolume;

    private void Start()
    {
        ballMass = 1f;
        ballVolume = 1f;
        lineRenderer.positionCount = N;
    }

    void Update()
    {
        if (instancedBall)
        {
            velText.text = "Velocidad: " + instancedBall.GetComponent<Rigidbody>().velocity;
        }

        if (Input.GetKey(KeyCode.UpArrow) && force < 5000)
        {
            force += 100;
        }

        if (Input.GetKey(KeyCode.DownArrow) && force > 500)
        {
            force -= 100;
        }

        if (Input.GetKey(KeyCode.W) && ballMass < 10)
        {
            ballMass += 0.1f;
        }

        if (Input.GetKey(KeyCode.S) && ballMass > 1)
        {
            ballMass -= 0.1f;
        }

        if (Input.GetKey(KeyCode.D) && ballVolume < 5)
        {
            ballVolume += 0.1f;
        }

        if (Input.GetKey(KeyCode.A) && ballVolume > 1)
        {
            ballVolume -= 0.1f;
        }

        if (Input.GetMouseButtonDown(0) && instancedBall == null)
        {
            GameObject ball = Instantiate(ballPrefab);
            instancedBall = ball;
            ball.transform.position = transform.position;
            ball.transform.localScale = new Vector3(ballVolume, ballVolume, ballVolume);

            Rigidbody ballURB = ball.GetComponent<Rigidbody>();

            ballURB.mass = ballMass;

            //SphereCollider ballCollider = ballURB as SphereCollider;
            //if (ballCollider != null)
            {
                //ballCollider.radius = ballVolume / 2f;
            }

            ballURB.AddForce(transform.forward * force);
        }

        Vector3[] futurePositions = new Vector3[N];
        Vector3[] futureVelocity = new Vector3[N];
        futurePositions[0] = transform.position;
        futureVelocity[0] = transform.forward * force / ballMass * 1f / framesPerSecond;

        for (int i = 1; i < N; i++)
        {
            futurePositions[i] = futurePositions[i - 1] + (futureVelocity[i - 1] + futureVelocity[i]) / 2 * (1f / framesPerSecond);
            Vector3 acceleration = Physics.gravity;
            futureVelocity[i] = futureVelocity[i - 1] + acceleration * (1f / framesPerSecond);
        }

        lineRenderer.SetPositions(futurePositions);
    }
}
