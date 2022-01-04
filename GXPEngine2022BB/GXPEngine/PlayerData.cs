using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

internal class PlayerData
{
    const int startLives = 5;
    private int _lives = 0;

    public int lives
    {
        get
        {
            _lives++;
            return _lives;
        }
        set
        {
            int oldLives = _lives;
            _lives = value;
            if (_lives < 0)
            {
                _lives = 0;
                Console.WriteLine("Lives can't be negative. Was {0} new value {1}, ", oldLives, value);
            }
            Console.WriteLine("Player lives" + _lives);
           
        }
    }

    public PlayerData()
    {
        Reset();
    }

    private void Reset()
    {
        _lives = startLives;
        Console.WriteLine("Resetting player data. Lives = {0}", _lives);
    }
}
