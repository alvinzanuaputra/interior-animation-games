using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public enum MotionType { Slide, Rotate }

    [Header("Settings")]
    public MotionType motionType = MotionType.Slide;
    public float speed = 2.0f;

    [Header("Movement (For Drawers)")]
    public Vector3 slideAmount = new Vector3(0, 0, 0.5f); // Direction & Distance

    [Header("Rotation (For Doors)")]
    public Vector3 rotateAngle = new Vector3(0, 90, 0); // Axis & Angle

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip openSound;

    // Internal State
    private Vector3 startPos;
    private Vector3 targetPos;
    private Quaternion startRot;
    private Quaternion targetRot;
    private bool isOpen = false;

    void Start()
    {
        startPos = transform.localPosition;
        startRot = transform.localRotation;

        targetPos = startPos + slideAmount;
        targetRot = Quaternion.Euler(transform.localEulerAngles + rotateAngle);
    }

    void Update()
    {
        if (motionType == MotionType.Slide)
        {
            Vector3 destination = isOpen ? targetPos : startPos;
            transform.localPosition = Vector3.Lerp(transform.localPosition, destination, Time.deltaTime * speed);
        }
        else 
        {
            Quaternion destination = isOpen ? targetRot : startRot;
            transform.localRotation = Quaternion.Slerp(transform.localRotation, destination, Time.deltaTime * speed);
        }
    }

    public void Interact()
    {
        isOpen = !isOpen; 

        if (audioSource != null && openSound != null)
        {
            audioSource.PlayOneShot(openSound);
        }
    }
}