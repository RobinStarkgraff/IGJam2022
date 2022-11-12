public class JumpPlayerEvent : PlayerEvent
{
    protected override void ExecutePlayerAction()
    {
        Player.Instance.Jump(duration);
    }
}