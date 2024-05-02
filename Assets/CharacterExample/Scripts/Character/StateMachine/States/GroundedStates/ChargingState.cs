public class ChargingState : GroundedState
{
    private readonly RunningStateConfig _config;

    public ChargingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.RunningStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.ChargeSpeed;

        View.StartRunning();
        View.StartCharging();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
        View.StopCharging();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
        {
            StateSwitcher.SwitchState<IdlingState>();
            return;
        }

        if (Data.IsCharging)
            return;

        StateSwitcher.SwitchState<RunningState>();
    }
}
