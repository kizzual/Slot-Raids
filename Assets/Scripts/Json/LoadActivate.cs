using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadActivate : MonoBehaviour
{
    [SerializeField] private InventoryControl inventory;
    [SerializeField] private Character character;

    private void Awake()
    {
        character.Loading();
        inventory.Loading();
    }




}
