public class RunningState : GroundedState
{
    private readonly RunningStateConfig _config;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;

        View.StartRunning();
    }

    public override void Exit()
    {
        base.Exit(); 

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (Data.IsCharging)
        {
            StateSwitcher.SwitchState<ChargingState>();
            return;
        }

        if (Data.IsWalking)
        {
            StateSwitcher.SwitchState<WalkingState>();
            return;
        }

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
    }
}
