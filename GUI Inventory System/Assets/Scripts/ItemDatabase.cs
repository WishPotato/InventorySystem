using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {


    public List<Item> dataBase = new List<Item>();

	void Awake () {
        dataBase.Add(new Item(0, "empty", "N/A", 0));
        dataBase.Add(new Item(1, "Key", "Key to The Great Door.", 0));
        dataBase.Add(new Item(2, "Apple", "This apple should not be eaten.", 0));
        dataBase.Add(new Item(3, "Dust", "The Dust of a person who walked upon it.", 0));
	}
	
}

public class Item
{
    private string name;
    private string description;
    private int Id;
    private byte stack;

    public Item(int id, string n, string d, byte s)
    {
        Id = id;
        name = n;
        description = d;
        stack = s;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public int ID
    {
        get { return Id; }
        set { Id = value; }
    }

    public byte Stack
    {
        get { return stack; }
        set { stack = value; }
    }
}