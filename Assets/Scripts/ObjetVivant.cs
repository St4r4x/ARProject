using UnityEngine;
public class ObjetVivant : MonoBehaviour
{
    public VivantConﬁguration configuration;
    public MeshRenderer renderer;
    public Rigidbody rigidbody;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float random = Random.value;
        float randomSize = Mathf.Lerp(configuration.tailleRandom.x, configuration.tailleRandom.y, random);
        transform.localScale = Vector3.one * randomSize;
        float randomMass = Mathf.Lerp(configuration.masseRandom.x, configuration.masseRandom.y, random);
        rigidbody.mass = randomMass;
        float rendererIndex = Mathf.FloorToInt(Mathf.Lerp(0, configuration.materiauxRandom.Count, random));
        renderer.material = configuration.materiauxRandom[(int)rendererIndex];
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
