using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    [Header("Setup")]
    public CharacterController controller;
    public AudioSource footstepSource;
    public AudioClip[] stepSounds; 

    [Header("Settings")]
    public float stepInterval = 0.5f; 
    public float minMoveSpeed = 0.1f; 
    private float stepTimer;

    void Start()
    {
        if (controller == null) controller = GetComponent<CharacterController>();
        if (footstepSource == null) footstepSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            Vector3 horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);
            
            if (horizontalVelocity.magnitude > minMoveSpeed)
            {
                stepTimer -= Time.deltaTime;

                if (stepTimer <= 0)
                {
                    PlayFootstep();
                    stepTimer = stepInterval; 
                }
            }
            else
            {
                stepTimer = 0; 
            }
        }
    }

    void PlayFootstep()
    {
        if (stepSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, stepSounds.Length);
            
            footstepSource.volume = Random.Range(0.3f, 0.4f);
            footstepSource.pitch = Random.Range(0.8f, 1.1f);
            footstepSource.PlayOneShot(stepSounds[randomIndex]);
        }
    }
}