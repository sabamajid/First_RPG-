using UnityEngine;

public class CloneController : MonoBehaviour
{
    private bool isActive = false;

    private void OnMouseDown()
    {
        // Set the clicked clone as active and the others as inactive
        isActive = true;
        foreach (var clone in GameObject.FindGameObjectsWithTag("Clone"))
        {
            if (clone != gameObject)
            {
               
                clone.GetComponent<CloneController>().isActive = false;
            }
        }
    }

    private void Update()
    {
        // Toggle the component's activity based on the isActive flag
        var component = GetComponent<CharacterManager>(); 
        if (component != null)
        {
            component.enabled = isActive;
        }
    }
}
