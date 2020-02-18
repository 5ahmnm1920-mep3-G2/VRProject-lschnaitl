using UnityEngine;
using Valve.VR.InteractionSystem;
using TMPro;

public class ShootPlanet : MonoBehaviour
{
    [SerializeField] private Transform planet = null;
    [SerializeField] private Gravitation gravitation = null;
    [SerializeField] private float factorIncreace = 0.2f;
    [SerializeField] private float forceMax = 5000;
    [SerializeField] private TMP_Text forceText;

    private Rigidbody planetRb;
    private bool isReset;
    private readonly KeyCode actionKey = KeyCode.Space;
    private float force = 1f;

    private void Awake()
    {
        planetRb = planet.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        forceText.text = force.ToString("F");

        if (Input.GetKeyDown(actionKey) && !isReset)
        {
            ResetPlanetPosition();
        }

        if (Input.GetKey(actionKey) && isReset)
        {
            force *= factorIncreace;
            Debug.Log(force);
        }
        else if (Input.GetKeyUp(actionKey))
        {
            Shoot(force);
        }
    }
    
    public void ResetPlanetPosition()
    {
        // disable gravity of earth
        gravitation.EarthAttract(false);

        // set the planets position and rotation to the guns
        planet.parent = transform;
        planet.localPosition = Vector3.zero;
        planet.localRotation = Quaternion.identity;

        // reset its velocity and the force factor
        planetRb.velocity = Vector3.zero;
        isReset = true;
        force = 1;
    }

    private void Shoot(float zForce)
    {
        // unparent planet
        planet.parent = null;

        // enable gravity
        gravitation.EarthAttract(true);

        // set min and max force
        zForce = zForce > forceMax ? forceMax : zForce;
        
        // shoot the planet
        planetRb.AddForce(transform.forward.normalized * zForce);
        Debug.Log("Shot with " + zForce + " Force!");
        isReset = false;
    }
}
