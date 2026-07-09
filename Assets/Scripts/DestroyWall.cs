using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // when the player collides with the wall, destroy it
        if (collision.gameObject.CompareTag("Player"))
        {
            // the wall serves as the "gateway" into the next part of the game/level
            // so maybe the cutscene manager keeps track of whether the gateway object should
            // be destroyed which should happen when the card is interacted with/before it gets destroyed
            if (CutSceneManager.Instance.CanPlayerProceed)
            {
                Debug.Log("wall is going to be destroyed");
                CutSceneManager.Instance.CanPlayerProceed = false;
                Destroy(gameObject);
            }
        }
    }
}
