using UnityEngine;
using UnityEngine.UI;

public class Endlevel : MonoBehaviour
{
    public string grabableTag = "Grabable";
    public int itemsNeeded = 2;
    public GameObject panel;

    private int itemsInZone = 0;

    private void Start()
    {
        panel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(grabableTag))
        {
            itemsInZone++;
            if (itemsInZone == itemsNeeded)
            {
                Debug.Log("Level completed!");
                panel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(grabableTag))
        {
            itemsInZone--;
        }
    }
}
