using UnityEngine;
using System.Collections.Generic;

public class AppleCountManager : MonoBehaviour
{
    public int appleCount = 0;

    private HashSet<GameObject> applesInBowl = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple") && !applesInBowl.Contains(other.gameObject))
        {
            applesInBowl.Add(other.gameObject);
            appleCount = applesInBowl.Count;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Apple") && applesInBowl.Contains(other.gameObject))
        {
            applesInBowl.Remove(other.gameObject);
            appleCount = applesInBowl.Count;
        }
    }
}
