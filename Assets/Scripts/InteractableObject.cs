using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject holdPrefab;
    public bool isBeingLookedAt = false;
    
    public void OnLookEnter()
    {
        if(isBeingLookedAt) return;

        isBeingLookedAt = true;
        Debug.Log("Your Looking At Me");
    }

    public void OnLookExit()
    {
        if(!isBeingLookedAt) return;
        
        isBeingLookedAt = false;
        Debug.Log("Your no longer Looking At Me");
    }
}
