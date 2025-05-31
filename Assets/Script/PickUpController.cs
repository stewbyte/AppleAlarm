using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform objectGrabTransform;
    [SerializeField] private float pickupRange;
    [SerializeField] private LayerMask layerMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit rHit, pickupRange, layerMask: layerMask))
            {
                if (rHit.transform.TryGetComponent(out PickUpItem item))
                {
                    item.Grab(objectGrabTransform);
                }
            }
        }
    }
}
