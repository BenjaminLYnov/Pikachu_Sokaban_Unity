using UnityEngine;
using System;

public class GetPushed : MonoBehaviour
{

    private const float PI = 3.1415926535897931f;

    public Vector3 rayVector = new Vector3(1, 0, 1);
    public BackupState backupState;

    private RaycastHit hit;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Get Pushing by player (pikachu)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Get player roatation
            float rotation = other.gameObject.transform.eulerAngles.y;

            // Get player direction
            Vector3 direction = new Vector3((float)Math.Sin(rotation * Math.PI / 180), 0, (float)Math.Cos(rotation * Math.PI / 180));

            rayVector.x = (float)Math.Sin(rotation * PI / 180);
            rayVector.z = (float)Math.Cos(rotation * PI / 180);

            Debug.DrawRay(transform.position, direction, Color.red);

            Ray ray = new Ray(transform.position, rayVector);

            // Move object to get push there isn't obstacle in front
            if (!Physics.Raycast(ray, out hit, 1.0f))
            {
                backupState.pikachuPosition.Add(new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.z, rotation));
                backupState.BallsPosition.Add(transform.position);
                backupState.BallsName.Add(transform.name);
                rb.velocity = direction * 5;
            }
        }
    }
}
