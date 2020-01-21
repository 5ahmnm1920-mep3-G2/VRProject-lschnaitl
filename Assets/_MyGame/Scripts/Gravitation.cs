using UnityEngine;

public class Gravitation : MonoBehaviour
{
    [SerializeField]
    private Transform earth = null;
    [SerializeField]
    private Transform moon = null;

    private Rigidbody rbEarth;
    private Rigidbody rbMoon;
    private int factor = 1;

    private const float GRAVITATION = 9.81f;

    private float AttractionForce (float mass1, float mass2, float distance)
    {
        return mass1 * mass2 / distance * GRAVITATION * factor;
    }

    public void EarthAttract(bool mode)
    {
        factor = mode ? 1 : 0;
    }

    private void Start()
    {
        rbEarth = earth.GetComponent<Rigidbody>();
        rbMoon = moon.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // get directions vector3 toward earth and distance
        Vector3 direction = (earth.position - moon.position).normalized;
        float distance = Vector3.Distance(earth.position, moon.position);

        // apply the gravitation to the moon
        rbMoon.AddForce(direction * AttractionForce(rbEarth.mass, rbMoon.mass, distance));
    }
}
