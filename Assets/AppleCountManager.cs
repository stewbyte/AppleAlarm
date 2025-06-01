using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class AppleCountManager : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;
    public int appleCount = 0;

    private HashSet<GameObject> applesInBowl = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple") && !applesInBowl.Contains(other.gameObject))
        {
            applesInBowl.Add(other.gameObject);
            appleCount = applesInBowl.Count;
            UpdateCounter(appleCount.ToString());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Apple") && applesInBowl.Contains(other.gameObject))
        {
            applesInBowl.Remove(other.gameObject);
            appleCount = applesInBowl.Count;
            UpdateCounter(appleCount.ToString());
        }
    }

    public void UpdateCounter(string value)
    {
        counterText.text = value;
    }
}
