using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField]
    private float Force = 20000f;

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
        // var currentPosition = other.gameObject.transform.position;

        // other.gameObject.transform.position = new Vector3(currentPosition.x, 1 * Force, currentPosition.z);

        // Vector3 velocity = otherRigidbody.velocity;
        // velocity.y = 0f;
        // otherRigidbody.velocity = velocity;
        // otherRigidbody.AddForce(Vector3.up * 1000f, ForceMode.Impulse);


        // otherRigidbody.AddForce(
        //     Vector3.up * Force, ForceMode.Impulse
        // );

        // Vector3 direction = Vector3.zero;
        // direction = Vector3.up * Force;
        // otherRigidbody.AddForce(direction * Time.fixedDeltaTime, ForceMode.Acceleration);

        Debug.Log($"Collision with {other.gameObject.tag} | Qtd: {CurrentQuantity}");
    }
}
