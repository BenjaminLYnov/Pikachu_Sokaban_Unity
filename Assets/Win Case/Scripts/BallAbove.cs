using UnityEngine;

public class BallAbove : MonoBehaviour
{
    public bool activated = false;

    // Check if ball is above case
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball")
            activated = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
            activated = false;
    }
}
