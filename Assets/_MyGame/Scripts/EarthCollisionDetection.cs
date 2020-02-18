using UnityEngine;

public class EarthCollisionDetection : MonoBehaviour
{
    private ShootPlanet sp;

    private const string PLANET_TAG = "planet";
    
    private void Start()
    {
        sp = FindObjectOfType<ShootPlanet>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(PLANET_TAG))
        {
            sp.ResetPlanetPosition();
        }
    }
}
