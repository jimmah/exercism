using System;

public class BankAccount
{
    private readonly object _lock = new object();

    private bool _isOpen;

    private float _balance;

    public void Open()
    {
        lock (_lock) 
        {
            _isOpen = true;
        }
    }

    public void Close()
    {
        lock (_lock)
        {
            _isOpen = false;
        }
    }

    public float Balance
    {
        get
        {
            lock (_lock) 
            {
                if (!_isOpen)
                    throw new InvalidOperationException();

                return _balance;
            }
        }
    }

    public void UpdateBalance(float change)
    {
        lock (_lock)
        {
            if (!_isOpen)
                    throw new InvalidOperationException();

            _balance += change;
        }
    }
}
