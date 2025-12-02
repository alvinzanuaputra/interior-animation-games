using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    [Header("Setup")]
    public Light flashlightSource;
    public AudioSource clickSoundSource;
    public AudioClip clickClip;

    void Start()
    {
        if (flashlightSource == null) flashlightSource = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            ToggleLight();
        }
    }

    void ToggleLight()
    {
        flashlightSource.enabled = !flashlightSource.enabled;

        if (clickSoundSource != null && clickClip != null)
        {
            clickSoundSource.PlayOneShot(clickClip);
        }
    }
}