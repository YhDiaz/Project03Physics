using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    private MeshRenderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.name.Contains("Cube")) myRenderer.material.color = Color.green;
    }
}
