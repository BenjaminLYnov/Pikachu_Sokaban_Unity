using UnityEngine;
using System;
using System.Collections;

public class Move : MonoBehaviour
{

    // Pubic var

    public float moveSpeed;
    public float delayCanMove = 0.4f;


    // Private var

    private const float PI = 3.1415926535897931f;
    private Vector3 rayVector;
    private RaycastHit hit;

    private Vector3 moveHorizontale;
    private Vector3 moveVertical;
    private Vector3 velocityMove;

    private Rigidbody rb;
    private float xMov;
    private float zMov;
    private bool canMove = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, 0); // Empecher que le joueur reçoit de la force de déplacement

        if (canMove)
        {
            changeRotation();

            if (!HasObstacle())
                performMovement();
        }
    }

    private bool HasObstacle()
    {
        rayVector.x = (float)Math.Sin(transform.eulerAngles.y * PI / 180);
        rayVector.z = (float)Math.Cos(transform.eulerAngles.y * PI / 180);
        Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), rayVector);

        if (Physics.Raycast(ray, out hit, 0.3f))
            if (hit.transform.tag == "Ball" || hit.transform.tag == "Wall")
                return true;

        return false;
    }

    private void performMovement()
    {
        if (xMov != 0)
            zMov = 0;

        transform.position = new Vector3(transform.position.x + xMov * moveSpeed * Time.deltaTime, transform.position.y, transform.position.z + zMov * moveSpeed * Time.deltaTime);
    }

    private void changeRotation()
    {
        xMov = Input.GetAxisRaw("Horizontal");
        zMov = Input.GetAxisRaw("Vertical");

        if (zMov > 0)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        else if (zMov < 0)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);

        if (xMov > 0)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
        else if (xMov < 0)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, transform.eulerAngles.z);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            canMove = false;
            StartCoroutine(immobilization());
        }
    }

    public IEnumerator immobilization()
    {
        yield return new WaitForSeconds(delayCanMove);
        canMove = true;
    }
}