using UnityEngine;
using System;

public class KeepBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.transform.position = new Vector3(transform.position.x, other.gameObject.transform.position.y, transform.position.z);
        }
    }
}
