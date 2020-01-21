using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int triggersHit = 0;

    private void Update()
    {
        if (triggersHit == 2)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Both Triggers hit! Nice!");
    }
}
