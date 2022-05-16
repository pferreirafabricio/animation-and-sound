using UnityEngine;

public class Freeze : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;

        other.gameObject.GetComponent<PlayerController>().ChangeSpeed(0f);
        other.gameObject.GetComponent<MeshRenderer>().material.color = new Color(2, 106, 227);
    }
}