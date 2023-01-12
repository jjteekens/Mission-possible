using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // The stack of items that the player is currently holding
    private Stack<GameObject> heldItems = new Stack<GameObject>();

    // The maximum number of items that the player can hold at once
    public int maxHeldItems = 5;

    // The distance at which the player can pick up items
    public float pickupDistance = 1.0f;

    // A reference to the end zone game object
    public GameObject endZone;

    private Vector2 dir = Vector2.zero; // to keep track of player's last movement

    void Update()
    {
        // Check if the player is pressing the 'g' key
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (heldItems.Count > maxHeldItems) return;
                GameObject[] grabables = GameObject.FindGameObjectsWithTag("Grabable");
                foreach (GameObject grabable in grabables)
                {
                    float distance = Vector3.Distance(transform.position, grabable.transform.position);
                    if (distance <= pickupDistance)
                    {
                        heldItems.Push(grabable);
                        grabable.transform.parent = transform;
                        grabable.GetComponent<Rigidbody2D>().isKinematic = true;
                        grabable.GetComponent<Rigidbody2D>().simulated = false;
                    }
                }
            }



            // Check if the player is pressing the 't' key
            if (Input.GetKeyDown(KeyCode.T))
        {
            // Drop the last picked up item
            if (heldItems.Count > 0)
            {
                GameObject grabbedItem = heldItems.Pop();
                grabbedItem.transform.parent = null;
                grabbedItem.GetComponent<Rigidbody2D>().simulated = true;
                grabbedItem.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }
    }
}
