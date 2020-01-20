using UnityEngine;

public class ShootPlanet : MonoBehaviour
{
    [SerializeField] private Transform planet = null;
    [SerializeField] private Gravitation gravitation;
    [SerializeField] private float factorIncreace = 0.2f;

    private Rigidbody planetRb;
    private bool isReset;
    private readonly KeyCode actionKey = KeyCode.Space;
    private float forceFactor = 1f;

    private void Awake()
    {
        planetRb = planet.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(actionKey) && !isReset)
        {
            ResetPlanetPosition();
        }

        if (Input.GetKey(actionKey) && isReset)
        {
            forceFactor += factorIncreace * Time.deltaTime;
            Debug.Log(forceFactor);
        }
        else if (Input.GetKeyUp(actionKey))
        {
            Shoot(forceFactor);
        }
    }
    
    private void ResetPlanetPosition()
    {
        gravitation.EarthAttract(false);
        planet.position = transform.position;
        planet.rotation = transform.rotation;
        planet.parent = transform;
        planetRb.velocity = Vector3.zero;
        isReset = true;
        forceFactor = 0;
    }

    private void Shoot(float zForce)
    {
        planet.parent = null;
        gravitation.EarthAttract(true);
        isReset = false;
        planetRb.AddForce(transform.forward.normalized * zForce);
    }
}
