using UnityEngine;

public class LevelInputController : MonoBehaviour
{
    public void OnJump()
    {
        GameController.Instance.SpawnJumpLevelEvent();
    }

    public void OnShoot()
    {
        GameController.Instance.SpawnShootLevelEvent();
    }
}
