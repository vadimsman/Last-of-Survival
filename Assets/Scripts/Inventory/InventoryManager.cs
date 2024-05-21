using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIPanel;
    public Transform inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public float DistanceRay = 4;
    private bool isOpened;
    public Camera _mainCamera;
    void Start()
    {
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                 slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpened = !isOpened;
            
            if (isOpened)
            {
                UIPanel.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                UIPanel.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, DistanceRay))
        {
            
            if (hit.collider.gameObject.GetComponent<Item>() != null)
            {
                AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount); 
                Destroy(hit.collider.gameObject);
            }
            
            
            Debug.DrawRay(ray.origin, ray.direction * DistanceRay, Color.green);
            
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * DistanceRay, Color.red);
        }

    }

    private void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                slot.amount += _amount;
                return;
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == false)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
            }
        } 

    }
}
