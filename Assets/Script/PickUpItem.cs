using JetBrains.Rider.Unity.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Transform objectGrabTransform;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabTransform)
    {
        this.objectGrabTransform = objectGrabTransform;
        rigidbody.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabTransform = null;
        rigidbody.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (objectGrabTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabTransform.position, Time.deltaTime * lerpSpeed);
            rigidbody.MovePosition(newPosition);
        }
    }
}
