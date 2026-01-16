using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "VivantConfiguration", menuName = "ScriptableObject/VivantConfiguration")]

public class VivantConﬁguration : ScriptableObject
{    
    [Header("Apparition")]
    
    public Vector2 tailleRandom;
    public Vector2 masseRandom;
    public List<Material>materiauxRandom = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
