using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    private const string PLANET_TAG = "planet";
    private bool hitBool = false;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag(PLANET_TAG) && !hitBool)
        {
            gameManager.triggersHit += 1;
            Debug.Log(gameManager.triggersHit);
            hitBool = true;
        }
    }
}
