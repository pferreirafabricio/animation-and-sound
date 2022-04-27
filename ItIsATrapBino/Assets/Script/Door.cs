using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator Animator;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Player")
        {
            Destroy(collider.gameObject);
            return;
        }

        Animator.SetBool("Open", true);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag != "Player")
            return;

        Animator.SetBool("Open", false);
    }
}
