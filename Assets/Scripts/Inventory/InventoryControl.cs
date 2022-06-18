using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    const string SaveFilename = "Inventories";

    [SerializeField] private List<Inventory> Inventories;

    private  List<SavedInvetory> SavedInventories = new List<SavedInvetory>();

    private void Awake()
    {
        LoadInventory();
        InitialiseInventory();
    }
    private void OnEnable()
    {
        for (int i = 0; i < Inventories.Count; i++)
        {
            if(i == 0)
            {
               Inventories[i].gameObject.SetActive(true);
            }
            else
            {
                Inventories[i].gameObject.SetActive(false);
            }

        }
    }


    void Update()
    {
        
    }
    private void InitialiseInventory()
    {
        for (int i = 0; i < SavedInventories.Count; i++)
        {
            Inventories[i].SetSaveInfo(SavedInventories[i]);
        }
    }

    public void SwitchPanels(int index)
    {
        foreach (var item in Inventories)
        {
            item.gameObject.SetActive(false);
        }
        Inventories[index].gameObject.SetActive(true);
    }
    #region Save / Load
    public void SaveInventory()
    {
        for (int i = 0; i < Inventories.Count; i++)
        {
            SavedInventories.Add(new SavedInvetory(Inventories[i]));
        }
        FileHandler.SaveToJSON<SavedInvetory>(SavedInventories, SaveFilename);
    }
    private void LoadInventory()
    {
        SavedInventories = FileHandler.ReadListFromJSON<SavedInvetory>(SaveFilename);
    }
    #endregion
}
[Serializable]
public class SavedInvetory
{
    public string _name;
    public int _eggs_count;
    public int _swords_1_count;
    public int _swords_2_count;
    public int _swords_3_count;
    public int _shield_1_count;
    public int _shield_2_count;
    public int _shield_3_count;
    public int _amulet_1_count;
    public int _amulet_2_count;
    public int _amulet_3_count;

    public SavedInvetory(Inventory inv)
    {
        inv.GetSaveInfo(out _name, out _eggs_count, out _swords_1_count, out _swords_2_count, out _swords_3_count, out _shield_1_count, out _shield_2_count, out _shield_3_count, out _amulet_1_count, out _amulet_2_count, out _amulet_3_count);
    }
}
