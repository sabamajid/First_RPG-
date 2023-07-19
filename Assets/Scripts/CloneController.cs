using UnityEngine;
using Cinemachine;

public class CloneController : MonoBehaviour
{
    public bool isActive = false;

   [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        virtualCamera = GameObject.Find("VirtualCameraGameObject").GetComponent<CinemachineVirtualCamera>();
    }
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
            else
            {
                virtualCamera.LookAt = clone.transform;
                virtualCamera.Follow = clone.transform;
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
