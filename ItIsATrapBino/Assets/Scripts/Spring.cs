using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField]
    private float Force = 2f;

    [SerializeField] private int QuantityToActivate = 1;

    private int CurrentQuantity;

    private void OnTriggerEnter(Collider other)
    {
        CurrentQuantity++;

        if (CurrentQuantity < QuantityToActivate)
            return;

        if (other.gameObject.tag != "Player")
            return;

        var otherRigidbody = other.gameObject.GetComponent<Rigidbody>();

        otherRigidbody?.AddForce(
            transform.up * Force, ForceMode.Impulse
        );

        Debug.Log($"Collision with {other.gameObject.tag} | Qtd: {CurrentQuantity}");
    }
}
