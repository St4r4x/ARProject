using UnityEngine;
public class ObjetVivant : MonoBehaviour
{
    public VivantConﬁguration configuration;
    public MeshRenderer renderer;
    public Rigidbody rigidbody;
    public float _targetTimer;
    public Vector3 _target;
    
    [Header("Layers")]
    public LayerMask layerSol;
    public LayerMask layerVivant;

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
        _targetTimer -= Time.deltaTime;
        if (_targetTimer <= 0f)
        {
            if(TryPickTarget(out Vector3 target))
            {
                _targetTimer = Random.Range(configuration.tempsAttente.x, configuration.tempsAttente.y);
            }
            else
            {
                _targetTimer = 1f;
            }
        }
    }
    bool TryPickTarget(out Vector3 target)
    {
        for (int i = 0; i < 10; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle * configuration.rayonMouvement;
            Vector3 possibleTarget = transform.position + new Vector3(Random.Range(-configuration.rayonMouvement, configuration.rayonMouvement), 
            2f, Random.Range(-configuration.rayonMouvement, configuration.rayonMouvement));
            if (Physics.Raycast(possibleTarget, Vector3.down, out RaycastHit hitInfo, 10f, layerSol)==false)
            {
                continue;
            }else{            
                if (Physics.SphereCast(hitInfo.point, 0.5f, Vector3.down, out RaycastHit vivantHit, 10f, layerVivant)==false)
            {
                continue;
            }
            target = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);
            return true;
            }

        }            
        target = Vector3.zero;
        return false;
    }
    public void FixedUpdate()
    {
        var to = (_target - rigidbody.position);
        to.y = 0f;
        rigidbody.AddForce(to.normalized*configuration.acceleration, ForceMode.Acceleration);
        rigidbody.linearVelocity = Vector3.ClampMagnitude(rigidbody.linearVelocity, configuration.vitesseMax);
    }
}
