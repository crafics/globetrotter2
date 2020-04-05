using System;

namespace Game.Scripts.Gameplays.Quiz1.Units
{

    /// <summary>
    /// Element that could be damaged
    /// </summary>
    public interface IDamagable
    {
        event Action<int, int> OnHealthChanged;

        void PlayDamageAnimation();
    }

}