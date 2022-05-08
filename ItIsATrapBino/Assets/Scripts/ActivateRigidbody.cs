using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRigidbody : MonoBehaviour
{
    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField] private int QuantityToActivate = 1;
    private int CurrentQuantity;

    private void OnTriggerEnter()
    {
        CurrentQuantity++;

        if (CurrentQuantity < QuantityToActivate)
            return;

        Rigidbody.useGravity = true;
    }
}
