using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSlotControll : MonoBehaviour
{
    [SerializeField] private List<SlotParticle> slot_particles;

    [SerializeField] private List<Material> sword_materials;
    [SerializeField] private List<Material> shield_materials;
    [SerializeField] private List<Material> amuet_materials;
    public void PlayParticleWitItem(int index, Item item )
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
                                slot_particles[index].SwordParticle(sword_materials[0]);
                                break;
                            case 2:
                                slot_particles[index].SwordParticle(sword_materials[4]);
                                break;
                            case 3:
                                slot_particles[index].SwordParticle(sword_materials[8]);
                                break;
                        }
                        break;
                    case Type_Element.Undead:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles[index].SwordParticle(sword_materials[1]);
                                break;
                            case 2:
                                slot_particles[index].SwordParticle(sword_materials[5]);
                                break;
                            case 3:
                                slot_particles[index].SwordParticle(sword_materials[9]);
                                break;
                        }
                        break;
            
                    case Type_Element.Order:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles[index].SwordParticle(sword_materials[2]);
                                break;
                            case 2:
                                slot_particles[index].SwordParticle(sword_materials[6]);
                                break;
                            case 3:
                                slot_particles[index].SwordParticle(sword_materials[10]);
                                break;
                        }
                        break;
               
                    case Type_Element.Demon:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles[index].SwordParticle(sword_materials[3]);
                                break;
                            case 2:
                                slot_particles[index].SwordParticle(sword_materials[7]);
                                break;
                            case 3:
                                slot_particles[index].SwordParticle(sword_materials[11]);
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
                                slot_particles[index].ShieldParticle(shield_materials[0]);
                                break;
                            case 2:
                                slot_particles[index].ShieldParticle(shield_materials[4]);
                                break;
                            case 3:
                                slot_particles[index].ShieldParticle(shield_materials[8]);
                                break;
                        }
                        break;
                    case Type_Element.Undead:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles[index].ShieldParticle(shield_materials[1]);
                                break;
                            case 2:
                                slot_particles[index].ShieldParticle(shield_materials[5]);
                                break;
                            case 3:
                                slot_particles[index].ShieldParticle(shield_materials[9]);
                                break;
                        }
                        break;

                    case Type_Element.Order:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles[index].ShieldParticle(shield_materials[2]);
                                break;
                            case 2:
                                slot_particles[index].ShieldParticle(shield_materials[6]);
                                break;
                            case 3:
                                slot_particles[index].ShieldParticle(shield_materials[10]);
                                break;
                        }
                        break;

                    case Type_Element.Demon:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles[index].ShieldParticle(shield_materials[3]);
                                break;
                            case 2:
                                slot_particles[index].ShieldParticle(shield_materials[7]);
                                break;
                            case 3:
                                slot_particles[index].ShieldParticle(shield_materials[11]);
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
                                slot_particles[index].AmuletParticle(amuet_materials[0]);
                                break;
                            case 2:
                                slot_particles[index].AmuletParticle(amuet_materials[4]);
                                break;
                            case 3:
                                slot_particles[index].AmuletParticle(amuet_materials[8]);
                                break;
                        }
                        break;
                    case Type_Element.Undead:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles[index].AmuletParticle(amuet_materials[1]);
                                break;
                            case 2:
                                slot_particles[index].AmuletParticle(amuet_materials[5]);
                                break;
                            case 3:
                                slot_particles[index].AmuletParticle(amuet_materials[9]);
                                break;
                        }
                        break;

                    case Type_Element.Order:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles[index].AmuletParticle(amuet_materials[2]);
                                break;
                            case 2:
                                slot_particles[index].AmuletParticle(amuet_materials[6]);
                                break;
                            case 3:
                                slot_particles[index].AmuletParticle(amuet_materials[10]);
                                break;
                        }
                        break;

                    case Type_Element.Demon:
                        switch (item.Rank)
                        {
                            case 1:
                                slot_particles[index].AmuletParticle(amuet_materials[3]);
                                break;
                            case 2:
                                slot_particles[index].AmuletParticle(amuet_materials[7]);
                                break;
                            case 3:
                                slot_particles[index].AmuletParticle(amuet_materials[11]);
                                break;
                        }
                        break;
                }
                break;
        }
        slot_particles[index].CoinParticle();
        PlayCashSound();
    }
    public void PlayParticleWitoutItem(int index)
    {
        slot_particles[index].CoinParticle();
        PlayCashSound();
    }
    private void PlayCashSound() => SoundControl._instance.Cash();
}
