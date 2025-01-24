using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Room : MonoBehaviour
{
    public Slots mainSlot;
    public Slots combatSlot1;
    public Slots combatSlot2;
    public Slots itemSlot1;
    public Slots itemSlot2;
    public List<Slots> itemSlots;

    public GameObject exit;
    public Room left = null;
    public Room right = null;
    public Door leftDoor = null;
    public Door rightDoor = null;

    public GameObject itemSelection;
    public ItemSlot selectedItemSlot = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DefaultItemSelection()
    {
        selectedItemSlot = null;
        if (itemSlots[2].itemSlot.item != null)
        {
            selectedItemSlot = itemSlots[2].itemSlot;
        }
        if (itemSlots[0].itemSlot.item != null)
        {
            selectedItemSlot = itemSlots[0].itemSlot;
        }
        if (itemSlots[1].itemSlot.item != null)
        {
            selectedItemSlot = itemSlots[1].itemSlot;
        }

        if (selectedItemSlot != null)
        {
            GetItemSelection().transform.position = selectedItemSlot.transform.position - new Vector3(0, -1, 0);
            GetItemSelection().GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetItemSelection().GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void SelectLeftItem()
    {
        int currentIndex = -1;
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].itemSlot == selectedItemSlot)
            {
                currentIndex = i;
                break;
            }
        }

        for (int i = currentIndex -1; i >= 0; i--)
        {
            if (itemSlots[i].itemSlot.item != null)
            {
                selectedItemSlot = itemSlots[i].itemSlot;
                break;
            }
            
        }

        if (selectedItemSlot == null) return;

        GetItemSelection().transform.position = selectedItemSlot.transform.position - new Vector3(0, -1, 0);

    }

    public void SelectRightItem()
    {
        int currentIndex = -1;
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].itemSlot == selectedItemSlot)
            {
                currentIndex = i;
                break;
            }
        }

        for (int i = currentIndex + 1; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].itemSlot.item != null)
            {
                selectedItemSlot = itemSlots[i].itemSlot;
                break;
            }

        }

        if (selectedItemSlot == null) return;

        GetItemSelection().transform.position = selectedItemSlot.transform.position - new Vector3(0, -1, 0);

    }

    private GameObject GetItemSelection()
    {
        if (itemSelection == null)
        {
            itemSelection = GameObject.FindGameObjectWithTag("ItemSelection");
        }
        return itemSelection;
    }
}
