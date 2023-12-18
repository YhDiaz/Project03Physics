using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WindPhysics : MonoBehaviour
{
    public float timeUntilWindVariates;
    public Vector3 wind;
    public Vector3 windVariation;
    public TextMeshProUGUI windText;

    private void Update()
    {
        timeUntilWindVariates -= Time.deltaTime;

        if (timeUntilWindVariates <= 0)
        {
            timeUntilWindVariates = 5f;

            switch (Mathf.Ceil(Random.Range(1, 5)))
            {
                case 1:
                    windVariation.x *= -1;
                    break;

                case 2:
                    windVariation.y *= -1;
                    break;

                case 3:
                    windVariation.z *= -1;
                    break;

                default:
                    break;
            }
        }

        wind += windVariation;
        if (windText) windText.text = "Viento: " + wind;
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody collisionRB = other.gameObject.GetComponent<Rigidbody>();
        bool boxCollider = other.gameObject.GetComponent<BoxCollider>();
        bool sphereCollider = other.gameObject.GetComponent<SphereCollider>();
        Vector3 size = other.transform.localScale;

        float collisionSurface = (boxCollider) ? size.x * size.y * 2 + size.x * size.z * 2 + size.z * size.y * 2 :
                                 (sphereCollider) ? 4 * Mathf.PI * (size.x / 2) * (size.x / 2) : 0f;

        collisionRB.AddForce(wind * collisionSurface / 2);
    }
}
