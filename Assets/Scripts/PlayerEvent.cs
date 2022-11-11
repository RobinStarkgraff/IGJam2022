using Unity.VisualScripting;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    public float progress;
    public float duration = 1.5f;

    private bool _executedAction = false;

    public void Start()
    {
        progress = 8;
        SpriteRenderer spriteRenderer = this.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = GameController.Instance.shape;
    }

    public void Update()
    {
        //Some position calculation
        Vector3 worldPos = transform.position;
        worldPos.x = progress;
        transform.position = worldPos;

        if (transform.position.x <= 0 && !_executedAction)
        {
            ExecutePlayerAction();
            _executedAction = true;
        }
    }

    public void ExecutePlayerAction()
    {
        Player.Instance.Jump(duration);
    }
}
