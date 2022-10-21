    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleToCoin;
    [SerializeField] private ParticleSystem particleToSword;
    [SerializeField] private ParticleSystemRenderer particleToSword_rend;
    [SerializeField] private ParticleSystem particleToShield;
    [SerializeField] private ParticleSystemRenderer particleToShield_rend;
    [SerializeField] private ParticleSystem particleToAmulet;
    [SerializeField] private ParticleSystemRenderer particleToAmulet_rend;

    public void CoinParticle()
    {
        particleToCoin.Play();
    }
    public void SwordParticle(Material material)
    {
        particleToSword_rend.sharedMaterial = material;
        particleToSword.Play();
    }
    public void ShieldParticle(Material material)
    {
        particleToShield_rend.sharedMaterial = material;
        particleToShield.Play();
    }
    public void AmuletParticle(Material material)
    {
        particleToAmulet_rend.sharedMaterial = material;
        particleToAmulet.Play();
    }

    public void SwitchMaterial_sword(Material material) => particleToSword_rend.sharedMaterial = material;
    public void SwitchMaterial_shield(Material material) => particleToShield_rend.sharedMaterial = material;
    public void SwitchMaterial_amulet(Material material) => particleToAmulet_rend.sharedMaterial = material;

    public void PlayeItems_sword() => particleToSword.Play();
    public void PlayeItems_shield() => particleToShield.Play();
    public void PlayeItems_amulet() => particleToAmulet.Play();

}
