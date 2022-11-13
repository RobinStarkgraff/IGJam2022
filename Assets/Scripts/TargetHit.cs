using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            return;
        }

        LevelEvent levelEvent = GetComponent<ShootLevelEvent>();
        GameController.Instance.Score += levelEvent.pointsForEvent;
        GameController.Instance.RemoveLevelEvents(levelEvent);
        levelEvent = collision.gameObject.GetComponent<LevelEvent>();
        GameController.Instance.RemoveLevelEvents(levelEvent);


        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}