using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Archer")] 
    public float archerHealth;
    public float archerDamage;
    public float archerRange;
    
    [Header("Warrior")]
    public float warriorHealth;
    public float warriorDamage;
    public float warriorRange;
    
    [Header("Mage")]
    public float mageHealth;
    public float mageDamage;
    public float mageRange;
   
    
    [Header("Ninja")]
    public float ninjaHealth;
    public float ninjaDamage;
    public float ninjaRange;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

}
