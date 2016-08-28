using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

    private ItemDatabase itemDatabase;
    private Item[] inventory;

    private bool hasOpen = true;

    private int slotAmountX = 8;
    private int slotAmountY = 8;
    private int ItemSlot = 0;

    private float slotSize = 64.0f;
    private float slotSpacing = 10.0f;

    private string hoverText = "";

    private Rect inventoryBorder;

	void Start () 
    {
        itemDatabase = GameObject.Find("Database").GetComponent<ItemDatabase>();
        
        inventory = new Item[64];
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = itemDatabase.dataBase[0];
        }
        inventoryBorder = new Rect(10, 10, (slotSize + slotSpacing) * (slotAmountX + 5), (slotSize + slotSpacing) * slotAmountY + slotSpacing);

    }
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.I))
            hasOpen = !hasOpen;

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha1))
            RemoveItem(1);
        else if (Input.GetKeyDown(KeyCode.Alpha1))
            AddItem(1);

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha2))
            RemoveItem(2);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            AddItem(2);

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha3))
            RemoveItem(3);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            AddItem(3);
    }

    void OnGUI()
    {
        if (hasOpen)
        {
            // Event.current.mousePosition;
            GUI.Box(inventoryBorder, "");
            GUI.Label(new Rect(inventoryBorder.x + 600, inventoryBorder.y + 100, 500, 200), "Add a Item to the inventory by clicking 1, 2, or 3. \n\nRemove a Item from the inventory by Left Shift + 1, 2 or 3 \n\nHover the mouse over a item to read its description");
            GUI.Label(new Rect(inventoryBorder.x + 600, inventoryBorder.y + 300, 500, 500), hoverText);
            int count = 0;
            for (int i = 0; i < slotAmountY; i++)
            {
                for (int j = 0; j < slotAmountX; j++)
                {
                    Rect slotBorder = new Rect((inventoryBorder.x + slotSize) * j + slotSpacing * 2, (inventoryBorder.y + slotSize) * i + slotSpacing * 2, slotSize, slotSize);
                    GUI.Box(slotBorder, inventory[count].Name + " " + inventory[count].Stack);
                    if (slotBorder.Contains(Event.current.mousePosition) && inventory[count].ID != 0)
                        hoverText = inventory[count].Description;
                    count++;
                    
                }
            }
        }
    }

    void AddItem(int id)
    {
        if (itemDatabase.dataBase.Count < id || id == 0)
            Debug.Log("ERROR!: Item ID does not exsist within the field of the database.");
        else if (ItemIsInSlot(id))
            inventory[ItemSlot].Stack++;
        else
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].ID == 0)
                {
                    inventory[i] = itemDatabase.dataBase[id];
                    inventory[i].Stack = 1;
                    break;
                }
            }
        }
    }

    private void RemoveItemFromSlot(int slot)
    {
        if (inventory[slot].ID == 0)
            Debug.Log("Slot is empty already!");
        else if (inventory[slot].Stack > 1)
            inventory[slot].Stack--;
        else
            inventory[slot] = itemDatabase.dataBase[0];
    }

    void RemoveItem(int id)
    {
        if (ItemIsInSlot(id))
            RemoveItemFromSlot(ItemSlot);
    }

    private bool ItemIsInSlot(int id)
    {
        bool isInSlot = false;

        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i].ID == id)
            {
                isInSlot = true;
                ItemSlot = i;
                break;
            }
        }
        return isInSlot;
    }

}
