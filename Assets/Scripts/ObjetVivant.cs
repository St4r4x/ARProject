using UnityEngine;
public class ObjetVivant : MonoBehaviour
{
    public VivantConﬁguration configuration;
    public MeshRenderer renderer;
    public Rigidbody rigidbody;
    public float _targetTimer;
    public Vector3 _target;
    private float _nextJumpTime = 0f;
    
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
        // initialize jump timer
        if (configuration != null && configuration.enableJump)
        {
            _nextJumpTime = Time.time + Random.Range(configuration.jumpInterval.x, configuration.jumpInterval.y);
        }
}

    // Update is called once per frame
    void Update()
    {
        _targetTimer -= Time.deltaTime;
        if (_targetTimer <= 0f)
        {
            if(TryPickTarget(out Vector3 target))
            {
                _target = target;
                _targetTimer = Random.Range(configuration.tempsAttente.x, configuration.tempsAttente.y);
            }
            else
            {
                _targetTimer = 1f;
            }
        }

        // Jump decision
        if (configuration != null && configuration.enableJump && Time.time >= _nextJumpTime)
        {
            float power = configuration.randomJumpPower
                ? Random.Range(configuration.jumpPowerRandom.x, configuration.jumpPowerRandom.y)
                : configuration.jumpPower;

            if (rigidbody == null) rigidbody = GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddForce(Vector3.up * power, ForceMode.Acceleration);
            }

            _nextJumpTime = Time.time + Random.Range(configuration.jumpInterval.x, configuration.jumpInterval.y);
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
        if (rigidbody == null) rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null) return;

        var to = (_target - rigidbody.position);
        to.y = 0f;
        if (to.sqrMagnitude > 0.001f)
            rigidbody.AddForce(to.normalized * configuration.acceleration, ForceMode.Acceleration);

        // Clamp horizontal speed (use linearVelocity API)
        Vector3 v = rigidbody.linearVelocity;
        Vector3 horizontal = new Vector3(v.x, 0f, v.z);
        float max = configuration != null ? configuration.vitesseMax : 10f;
        horizontal = Vector3.ClampMagnitude(horizontal, max);
        rigidbody.linearVelocity = new Vector3(horizontal.x, v.y, horizontal.z);
    }
}
