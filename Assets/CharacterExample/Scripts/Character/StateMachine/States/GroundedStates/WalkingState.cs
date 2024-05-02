public class WalkingState : GroundedState
{
    private readonly RunningStateConfig _config;

    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.RunningStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.WalkSpeed;

        View.StartRunning();
        View.StartWalking();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
        View.StopWalking();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
        {
            StateSwitcher.SwitchState<IdlingState>();
            return;
        }

        if (Data.IsWalking)
            return;

        StateSwitcher.SwitchState<RunningState>();
    }
}
