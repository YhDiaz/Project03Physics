using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrajectory : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int N = 120;
    public int framesPerSecond = 20;
    public Rigidbody utalRB;

    void Start()
    {
        lineRenderer.positionCount = N;
    }

    void Update()
    {
        Vector3[] futurePositions = new Vector3[N];
        Vector3[] futureVelocity = new Vector3[N];
        futurePositions[0] = transform.position;
        futureVelocity[0] = utalRB.velocity;
        for (int i = 1; i < N; i++)
        {
            futurePositions[i] = futurePositions[i - 1] + futureVelocity[i - 1] * (1f / framesPerSecond);
            Vector3 acceleration = Physics.gravity;
            futureVelocity[i] = futureVelocity[i - 1] + acceleration * (1f / framesPerSecond);
        }

        lineRenderer.SetPositions(futurePositions);
    }
}
