using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var collider = other.gameObject.GetComponent<CharacterController>();

        if (collider is null)
            return;

        collider.enabled = false;
        Destroy(other.gameObject, 3f);
    }
}
