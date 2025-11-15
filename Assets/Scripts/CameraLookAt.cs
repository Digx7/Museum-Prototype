using UnityEngine;

public class CameraLookAt : MonoBehaviour 
{
    public GameObject heldPrefab;
    public Transform heldParent;
    public float maxLookAtDistance = 200f;
    private InteractableObject objectCurrentlyLookedAt;
    private bool tryInteract;
    
    private void Update() 
    {
        LookAtRayCast();
        HandleInput();
        TryPickUp();
    }

    private void HandleInput()
    {
        tryInteract = Input.GetKeyDown(KeyCode.E);
    }

    private void TryPickUp()
    {
        if(tryInteract && objectCurrentlyLookedAt != null)
        {
            heldPrefab = objectCurrentlyLookedAt.holdPrefab;

            if(heldParent.childCount > 0)
            {
                for (int i = heldParent.childCount - 1; i >= 0; i--)
                {
                    Destroy(heldParent.GetChild(i).gameObject);
                }
            }
            
            Debug.Log("Picking up");
            Instantiate(heldPrefab,heldParent);
        }
    }

    private void LookAtRayCast()
    {
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, maxLookAtDistance))
        {
            if(hitInfo.transform.gameObject.TryGetComponent<InteractableObject>(out InteractableObject component))
            {
                if(component != objectCurrentlyLookedAt)
                {
                    ClearLookAt();
                    AddLookAt(component);
                }
            }
            else
            {
                ClearLookAt();
            }
        }
    }

    private void AddLookAt(InteractableObject interactableObject)
    {
        objectCurrentlyLookedAt = interactableObject;
        objectCurrentlyLookedAt.OnLookEnter();   
    }

    private void ClearLookAt()
    {
        if (objectCurrentlyLookedAt == null) return;
        
        objectCurrentlyLookedAt.OnLookExit();
        objectCurrentlyLookedAt = null;
    }
}