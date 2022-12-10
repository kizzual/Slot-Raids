using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullParticlesToInv : MonoBehaviour
{
    [SerializeField] private SlotParticle slot_particles;

    [SerializeField] private List<Material> sword_materials;
    [SerializeField] private List<Material> shield_materials;
    [SerializeField] private List<Material> amuet_materials;


    public void PlayParticleWitItem(List<Item> item)
    {

        bool sword_item = false;
        bool shield_item = false;
        bool amulet_item = false;
        for (int i = 0; i < item.Count; i++)
        {
            if(item[i].typeItem == TypeItem.Sword)
            {
                sword_item = true;
                CheckMaterial(item[i]);
            }
            else if(item[i].typeItem == TypeItem.Shield)
            {
                shield_item = true;
                CheckMaterial(item[i]);
            }
            else if (item[i].typeItem == TypeItem.Amulet)
            {
                amulet_item = true;
                CheckMaterial(item[i]);
            }
        }
        if (sword_item)
            slot_particles.PlayeItems_sword();
        if (shield_item)
            slot_particles.PlayeItems_shield();
        if (amulet_item)
            slot_particles.PlayeItems_amulet();
        slot_particles.CoinParticle();
    }
    public void PlayParticleWitoutItem()
    {
        slot_particles.CoinParticle();
    }
    private void CheckMaterial(Item item)
    {
        switch (item.typeItem)
        {
            case TypeItem.Sword:
                switch (item.typeElement)
                {
                    case Type_Element.Neutral:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles.SwitchMaterial_sword(sword_materials[0]);
                                break;
                            case 2:
                                slot_particles.SwitchMaterial_sword(sword_materials[4]);
                                break;
                            case 3:
                                slot_particles.SwitchMaterial_sword(sword_materials[8]);
                                break;
                        }
                        break;
                    case Type_Element.Undead:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles.SwitchMaterial_sword(sword_materials[1]);
                                break;
                            case 2:
                                slot_particles.SwitchMaterial_sword(sword_materials[5]);
                                break;
                            case 3:
                                slot_particles.SwitchMaterial_sword(sword_materials[9]);
                                break;
                        }
                        break;

                    case Type_Element.Order:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles.SwitchMaterial_sword(sword_materials[2]);
                                break;
                            case 2:
                                slot_particles.SwitchMaterial_sword(sword_materials[6]);
                                break;
                            case 3:
                                slot_particles.SwitchMaterial_sword(sword_materials[10]);
                                break;
                        }
                        break;

                    case Type_Element.Demon:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles.SwitchMaterial_sword(sword_materials[3]);
                                break;
                            case 2:
                                slot_particles.SwitchMaterial_sword(sword_materials[7]);
                                break;
                            case 3:
                                slot_particles.SwitchMaterial_sword(sword_materials[11]);
                                break;
                        }
                        break;
                }
                break;
            case TypeItem.Shield:
                switch (item.typeElement)
                {
                    case Type_Element.Neutral:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles.SwitchMaterial_shield(shield_materials[0]);
                                break;
                            case 2:
                                slot_particles.SwitchMaterial_shield(shield_materials[4]);
                                break;
                            case 3:
                                slot_particles.SwitchMaterial_shield(shield_materials[8]);
                                break;
                        }
                        break;
                    case Type_Element.Undead:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles.SwitchMaterial_shield(shield_materials[1]);
                                break;
                            case 2:
                                slot_particles.SwitchMaterial_shield(shield_materials[5]);
                                break;
                            case 3:
                                slot_particles.SwitchMaterial_shield(shield_materials[9]);
                                break;
                        }
                        break;

                    case Type_Element.Order:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles.SwitchMaterial_shield(shield_materials[2]);
                                break;
                            case 2:
                                slot_particles.SwitchMaterial_shield(shield_materials[6]);
                                break;
                            case 3:
                                slot_particles.SwitchMaterial_shield(shield_materials[10]);
                                break;
                        }
                        break;

                    case Type_Element.Demon:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles.SwitchMaterial_shield(shield_materials[3]);
                                break;
                            case 2:
                                slot_particles.SwitchMaterial_shield(shield_materials[7]);
                                break;
                            case 3:
                                slot_particles.SwitchMaterial_shield(shield_materials[11]);
                                break;
                        }
                        break;
                }

                break;
            case TypeItem.Amulet:
                switch (item.typeElement)
                {
                    case Type_Element.Neutral:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles.SwitchMaterial_amulet(amuet_materials[0]);
                                break;
                            case 2:
                                slot_particles.SwitchMaterial_amulet(amuet_materials[4]);
                                break;
                            case 3:
                                slot_particles.SwitchMaterial_amulet(amuet_materials[8]);
                                break;
                        }
                        break;
                    case Type_Element.Undead:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles.SwitchMaterial_amulet(amuet_materials[1]);
                                break;
                            case 2:
                                slot_particles.SwitchMaterial_amulet(amuet_materials[5]);
                                break;
                            case 3:
                                slot_particles.SwitchMaterial_amulet(amuet_materials[9]);
                                break;
                        }
                        break;

                    case Type_Element.Order:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles.SwitchMaterial_amulet(amuet_materials[2]);
                                break;
                            case 2:
                                slot_particles.SwitchMaterial_amulet(amuet_materials[6]);
                                break;
                            case 3:
                                slot_particles.SwitchMaterial_amulet(amuet_materials[10]);
                                break;
                        }
                        break;

                    case Type_Element.Demon:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles.SwitchMaterial_amulet(amuet_materials[3]);
                                break;
                            case 2:
                                slot_particles.SwitchMaterial_amulet(amuet_materials[7]);
                                break;
                            case 3:
                                slot_particles.SwitchMaterial_amulet(amuet_materials[11]);
                                break;
                        }
                        break;
                }
                break;
        }

    }
    private void PlayCashSound() => SoundControl._instance.Cash();
}
