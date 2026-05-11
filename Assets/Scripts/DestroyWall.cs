using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // when the player collides with the wall, destroy it
        if (collision.gameObject.CompareTag("Player"))
        {
            // if (CardPresenter.CurrentCollectedCard != null & CardPresenter.CurrentCollectedCard.IsCollected)
            //     Debug.Log("wall is going to be destroyed");
            Destroy(this);
        }
    }
}
