using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    [Header("Content")]
    public Item[] InventoryContent;
    private int index = 0;

    [Header("Composants")]
    public TextMeshProUGUI NameItemText;
    public TextMeshProUGUI DescriptionItemText;
    public TextMeshProUGUI ZoneItemText;
    public TextMeshProUGUI ProgressionText;
    public Image ItemRenderer;


    private void Start()
    {

        InventoryContent = Resources.LoadAll<Item>("Items/");

    }

    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.X))
        {

            if (gameObject.transform.GetChild(0).gameObject.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                index = 0;
                Time.timeScale = 1;

            } else
            {
                Cursor.lockState = CursorLockMode.None;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                index = 0;
                GenerateInventory(index);
                Time.timeScale = 0;
            }

        }

    }

    public void NextPage()
    {
        index += 1;
        GenerateInventory(index);
    }

    public void PreviousPage()
    {
        index -= 1;
        GenerateInventory(index);
    }

    public void GenerateInventory(int itemID)
    {

        var currentItem = InventoryContent[itemID];
        NameItemText.text = "Name : " + currentItem.Name;
        DescriptionItemText.text = "About it :\n" + currentItem.Description;
        ZoneItemText.text = "Find it at :\n" + currentItem.Zone;
        ProgressionText.text = " Decors : 0/10 \n Nature : 0/10 \n Unique objects 0/3 \n Winter Egg 0/1";

        ItemRenderer.sprite = currentItem.Image;


    }

}
