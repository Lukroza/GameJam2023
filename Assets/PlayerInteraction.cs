using static UnityEditor.Progress;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject heldItem;
    private bool isHoldingItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            heldItem = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            heldItem = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHoldingItem)
            {
                DropItem();
            }
            else if (heldItem != null)
            {
                isHoldingItem = true;
                heldItem.transform.parent = transform;
            }
        }

        if (isHoldingItem)
        {
            heldItem.transform.position = transform.position + new Vector3(0, 1, 0);
        }
    }

    private void DropItem()
    {
        heldItem.transform.parent = null;
        heldItem.transform.position = transform.position + new Vector3(0, 0, 0);
        heldItem = null;
        isHoldingItem = false;
    }
}
