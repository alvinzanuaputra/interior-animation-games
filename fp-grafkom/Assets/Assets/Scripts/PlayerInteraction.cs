using UnityEngine;
using UnityEngine.UI; 

public class PlayerInteraction : MonoBehaviour
{
    [Header("Settings")]
    public float interactRange = 3f;

    [Header("UI Setup")]
    public Image reticleImage;     
    public Color normalColor = new Color(1, 1, 1, 0.5f); 
    public Color hoverColor = Color.red;                

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        
        bool isHoveringInteractable = false;

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            ObjectMover mover = hit.collider.GetComponent<ObjectMover>();

            if (mover != null)
            {
                isHoveringInteractable = true;

                if (Input.GetMouseButtonDown(0))
                {
                    mover.Interact();
                }
            }
        }

        if (reticleImage != null)
        {
            reticleImage.color = isHoveringInteractable ? hoverColor : normalColor;
        }
    }
}