using UnityEngine;

public class PhysicsPickup : MonoBehaviour
{
    [Header("Setup")]
    public Transform holdArea;   
    public Camera playerCamera;  
    public float pickupRange = 3.0f;
    public float pickupForce = 150.0f; 

    [Header("Settings")]
    public float holdDistance = 2.5f;

    private Rigidbody heldObjRB;

    void Start()
    {
        if (playerCamera == null) playerCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObjRB == null)
            {
                RaycastAndGrab();
            }
            else
            {
                DropObject();
            }
        }

        if (heldObjRB != null)
        {
            MoveObject();
        }
        
        if (Input.GetMouseButtonDown(1) && heldObjRB != null)
        {
            heldObjRB.useGravity = true;
            heldObjRB.linearDamping = 1;
            heldObjRB.constraints = RigidbodyConstraints.None;
            heldObjRB.transform.parent = null;

            heldObjRB.AddForce(playerCamera.transform.forward * 1000f); 

            heldObjRB = null;
        }
    }

    void RaycastAndGrab()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickupRange))
        {
            if (hit.transform.CompareTag("Pickup") && hit.rigidbody != null)
            {
                GrabObject(hit.rigidbody);
            }
        }
    }

    void GrabObject(Rigidbody rb)
    {
        heldObjRB = rb;

        heldObjRB.useGravity = false; 
        heldObjRB.linearDamping = 10;          
        heldObjRB.constraints = RigidbodyConstraints.FreezeRotation; 
        
        heldObjRB.transform.parent = holdArea;
    }

    void DropObject()
    {
        heldObjRB.useGravity = true;
        heldObjRB.linearDamping = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null; 
        heldObjRB = null; 
    }

    void MoveObject()
    {
        
        if (Vector3.Distance(heldObjRB.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObjRB.transform.position);
            heldObjRB.linearVelocity = moveDirection * pickupForce * Time.deltaTime;
        }
    }
}