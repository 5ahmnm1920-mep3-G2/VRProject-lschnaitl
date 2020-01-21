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
            forceFactor *= factorIncreace * Time.deltaTime;
            Debug.Log(forceFactor);
        }
        else if (Input.GetKeyUp(actionKey))
        {
            Shoot(forceFactor);
        }
    }
    
    private void ResetPlanetPosition()
    {
        // disable gravity of earth
        gravitation.EarthAttract(false);

        // set the planets position and rotation to the guns
        planet.position = transform.position;
        planet.rotation = transform.rotation;
        planet.parent = transform;

        // reset its velocity and the force factor
        planetRb.velocity = Vector3.zero;
        isReset = true;
        forceFactor = 0;
    }

    private void Shoot(float zForce)
    {
        // release planet from gun
        planet.parent = null;

        // enable gravity
        gravitation.EarthAttract(true);

        // shoot the planet
        planetRb.AddForce(transform.forward.normalized * zForce);
        isReset = false;
    }
}
