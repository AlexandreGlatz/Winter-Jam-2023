using TMPro;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public TextMeshProUGUI Collecttext;
    public Inventory PlayerInventory;
    public Item CollectedItem;
    public bool CanCollect = false;

    public void Update()
    {
        if (CollectedItem.InPossess)
        {
            this.gameObject.SetActive(false);
        }
        if (CanCollect)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerInventory.InventoryContent[CollectedItem.Id].InPossess = true;
                Collecttext.text = "";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collecttext.text = "Press 'E' to activate \n" + CollectedItem.Name;
            CanCollect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collecttext.text = "";
            CanCollect = false;
        }
    }
}
