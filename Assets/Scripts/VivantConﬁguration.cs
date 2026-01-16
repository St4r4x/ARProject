using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "VivantConfiguration", menuName = "ScriptableObject/VivantConfiguration")]

public class VivantConﬁguration : ScriptableObject
{    
    [Header("Apparition")]
    
    public Vector2 tailleRandom;
    public Vector2 masseRandom;
    public List<Material>materiauxRandom = new();
    public Vector2 tempsAttente;

    [Header("Mouvement")]
    public float rayonMouvement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Vitesse")]
    public float acceleration;
    public float vitesseMax;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [Header("Saut")]
    // Activer ou non le comportement de saut
    public bool enableJump = true;
    // Intervalle aléatoire entre sauts (min, max) en secondes
    public Vector2 jumpInterval = new Vector2(2f, 5f);
    // Si true, la puissance du saut est choisie aléatoirement entre jumpPowerRandom
    public bool randomJumpPower = false;
    // Puissance de saut fixe (utilisée si randomJumpPower == false)
    public float jumpPower = 5f;
    // Plage de puissance aléatoire (min, max)
    public Vector2 jumpPowerRandom = new Vector2(3f, 8f);
}
