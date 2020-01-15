using UnityEngine;

public class Gravitation : MonoBehaviour
{
    [SerializeField]
    private Transform earth;
    [SerializeField]
    private Transform moon;

    private Rigidbody rbEarth;
    private Rigidbody rbMoon;

    private const float GRAVITATION = 9.81f;

    private float AttractionForce (float mass1, float mass2, float distance)
    {
        return mass1 * mass2 / distance * GRAVITATION;
    }

    private void Start()
    {
        rbEarth = earth.GetComponent<Rigidbody>();
        rbMoon = moon.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = (earth.position - moon.position).normalized;
        float distance = Vector3.Distance(earth.position, moon.position);
        rbMoon.AddForce(direction * AttractionForce(rbEarth.mass, rbMoon.mass, distance));
    }
}
