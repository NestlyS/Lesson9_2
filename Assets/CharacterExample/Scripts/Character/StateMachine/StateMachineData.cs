using System;

public class StateMachineData
{
    public float XVelocity;
    public float YVelocity;

    private float _speed;
    private float _xInput;
    private bool _isChaging;
    private bool _isWalking;

    public float XInput
    {
        get => _xInput;
        set
        {
            if(value < -1 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _xInput = value;
        }
    }

    public float Speed
    {
        get => _speed;
        set
        {
            if(value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speed = value;
        }
    }
    
    public bool IsCharging
    {
        get => _isChaging;
        set => _isChaging = value;
    }

    public bool IsWalking
    {
        get => _isWalking;
        set => _isWalking = value;
    }
}
