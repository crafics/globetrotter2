using System;
using System.Collections.Generic;
using Game.Scripts.Gameplays.Quiz1.Nodes;
using Game.Scripts.Gameplays.Quiz1.Units;

namespace Game.Scripts.Gameplays.Quiz1.Spells
{

    /// <summary>
    /// Base class for spells
    /// </summary>
    public interface ISpell
    {
        event Action<ISpell> OnHide;

        SpellType SpellType { get; }

        void Activate(Node node, string playerId);

        void MakeImpactOnUnits(List<Unit> units);

        void Show(Node node);

        void Hide();
    }

}