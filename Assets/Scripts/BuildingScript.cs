using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{

    public Inventory PlayerInventory;

    public GameObject[] MapObjects;

    public void FixedUpdate()
    {

        for (int i = 0; i < MapObjects.Length && i < PlayerInventory.InventoryContent.Length; i++)
        {

            var item = PlayerInventory.InventoryContent[i];
            if (item.InPossess == true)
            {

                var MapObject = MapObjects[i];
                MapObject.SetActive(true);

            }

        }

    }

}
