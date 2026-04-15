using UnityEngine;
using TMPro; // Include the TextMeshPro namespace

public class AnatomyInfoDisplay : MonoBehaviour
{
    [Header("Raycast Origin (Usually right controller or head camera)")]
    public Transform rayOrigin;
    
    [Header("Maximum Raycast Distance")]
    public float maxDistance = 5.0f;
    
    [Header("World Space Text Component (3D Text)")]
    // [Core Change] Changed TextMeshProUGUI to TextMeshPro
    public TextMeshPro worldText; 
    
    [Header("Target Layer Mask (Performance optimization)")]
    public LayerMask targetLayer;

    void Update()
    {
        // Create a variable to store raycast collision information
        RaycastHit hit;
        
        // Cast the ray: from the rayOrigin's position, straight forward
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, maxDistance, targetLayer))
        {
            // If the ray hits an object on the target layer, extract the object's name and update the 3D text
            worldText.text = hit.collider.gameObject.name;
            
            // [Advanced Usage]: If you want to display detailed medical descriptions instead of just the name:
            // AnatomyBone boneScript = hit.collider.GetComponent<AnatomyBone>();
            // if(boneScript != null) worldText.text = boneScript.boneDescription;
        }
        else
        {
            // If the ray does not hit any bone, display a default prompt
            worldText.text = "Point the ray at a bone to view info...";
        }
    }
}