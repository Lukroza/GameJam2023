using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float pickupRadius = 2.0f;

    private GameObject heldItem;
    private bool isHoldingItem;
    private Quaternion heldItemRotation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            heldItem = other.gameObject;
            heldItemRotation = heldItem.transform.rotation;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            heldItem = null;
            heldItemRotation = Quaternion.identity;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHoldingItem)
            {
                // check for nearby furniture
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupRadius);
                GameObject nearestFurniture = null;
                float minDistance = Mathf.Infinity;
                float maxDot = -1.0f;

                foreach (Collider hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.CompareTag("Furniture"))
                    {
                        Vector3 playerToFurniture = hitCollider.transform.position - transform.position;
                        float distance = playerToFurniture.magnitude;
                        if (distance < minDistance)
                        {
                            float dot = Vector3.Dot(playerToFurniture.normalized, transform.forward);
                            if (dot > maxDot)
                            {
                                maxDot = dot;
                                nearestFurniture = hitCollider.gameObject;
                                minDistance = distance;
                            }
                        }
                    }
                }

                // put the item on the nearest furniture object in the player's forward direction
                if (nearestFurniture != null)
                {
                    Vector3 playerToNearestFurniture = nearestFurniture.transform.position - transform.position;
                    float dot = Vector3.Dot(playerToNearestFurniture.normalized, transform.forward);
                    if (dot >= 0.5f) // only put the item on the furniture if it's in front of the player
                    {
                        heldItem.transform.parent = nearestFurniture.transform;
                        heldItem.transform.position = nearestFurniture.transform.position + new Vector3(0, 0.5f, 0);
                        heldItem.transform.rotation = heldItemRotation;
                        isHoldingItem = false;
                        heldItem = null;
                        heldItemRotation = Quaternion.identity;
                    }
                }
            }
            else if (heldItem != null)
            {
                isHoldingItem = true;
                heldItem.transform.parent = transform;
            }
        }

        if (isHoldingItem)
        {
            heldItem.transform.position = transform.position + new Vector3(0, 0, 0);
        }
    }
}
