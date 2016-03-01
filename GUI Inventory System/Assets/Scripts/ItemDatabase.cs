using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {


    public List<Item> dataBase = new List<Item>();

	void Start () {
        dataBase.Add(new Item());
        dataBase.Add(new Item(1, "Key", "Key to The Great Door."));
        dataBase.Add(new Item(2, "Old Apple", "This apple should not be eaten."));
	}
	
}

public class Item
{
    private string name;
    private string description;
    private int Id;

    public Item(int id, string n, string d)
    {
        Id = id;
        name = n;
        description = d;
    }

    public Item()
    {
        Id = 0;
        name = "Empty";
        description = "N/A";
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
    }
}