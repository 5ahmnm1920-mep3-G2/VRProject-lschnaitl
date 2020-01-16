using UnityEngine;

public class ShootPlanet : MonoBehaviour
{
    [SerializeField] private Transform planet = null;
    [SerializeField] private Gravitation gravitation;

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

        if (Input.GetKey(actionKey))
        {
            forceFactor += 0.1f;
        }
    }

    private void ResetPlanetPosition()
    {
        gravitation.EarthAttract(false);
        planetRb.MovePosition(transform.position);
        planet.parent = transform;
        isReset = true;
        forceFactor = 0;
    }
}
