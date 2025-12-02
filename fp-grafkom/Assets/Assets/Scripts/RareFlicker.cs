using UnityEngine;
using System.Collections;

public class RareFlicker : MonoBehaviour
{
    [Header("Setup")]
    public Light myLight;             
    public MeshRenderer bulbRenderer; 

    [Header("Settings")]
    public float minStableTime = 5f;  
    public float maxStableTime = 15f; 
    [Range(0.1f, 2f)]
    public float glitchDuration = 0.5f; 

    private float defaultIntensity;
    private Color defaultEmission;
    private Material bulbMat;

    void Start()
    {
        if (myLight != null) defaultIntensity = myLight.intensity;
        
        if (bulbRenderer != null)
        {
            bulbMat = bulbRenderer.material; 
            if (bulbMat.HasProperty("_EmissionColor"))
            {
                defaultEmission = bulbMat.GetColor("_EmissionColor");
            }
        }

        StartCoroutine(FlickerLoop());
    }

    IEnumerator FlickerLoop()
    {
        while (true) 
        {
            SetLightState(true);
            
            float waitTime = Random.Range(minStableTime, maxStableTime);
            yield return new WaitForSeconds(waitTime);

            float timer = 0f;
            while (timer < glitchDuration)
            {
                bool randomState = Random.value > 0.5f; 
                SetLightState(randomState);

                float strobeSpeed = Random.Range(0.01f, 0.1f);
                yield return new WaitForSeconds(strobeSpeed);
                
                timer += strobeSpeed;
            }
        }
    }

    void SetLightState(bool isOn)
    {
        if (myLight != null)
        {
            myLight.intensity = isOn ? defaultIntensity : 0f;
        }

        if (bulbRenderer != null && bulbMat != null)
        {
            Color finalColor = isOn ? defaultEmission : Color.black;
            bulbMat.SetColor("_EmissionColor", finalColor);
        }
    }
}