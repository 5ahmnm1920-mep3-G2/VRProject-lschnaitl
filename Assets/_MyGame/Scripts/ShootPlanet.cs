using UnityEngine;
using Valve.VR.InteractionSystem;

public class ShootPlanet : MonoBehaviour
{
    [SerializeField] private Transform planet = null;
    [SerializeField] private Gravitation gravitation = null;
    [SerializeField] private float factorIncreace = 0.2f;
    [SerializeField] private float forceMin = 500;
    [SerializeField] private float forceMax = 5000;

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
            forceFactor *= factorIncreace;
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
        forceFactor = 1;
    }

    private void Shoot(float zForce)
    {
        // release planet from gun
        planet.parent = null;

        // enable gravity
        gravitation.EarthAttract(true);

        // clamp the force
        Mathf.Clamp(zForce, forceMin, forceMax);

        // shoot the planet
        planetRb.AddForce(transform.forward.normalized * zForce);
        Debug.Log("Shot with " + zForce + " Force!");
        isReset = false;
    }
}
