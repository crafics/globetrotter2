using System;
using System.Collections.Generic;
using Game.Scripts.Gameplays.Quiz1.Cards;
using Game.Scripts.Gameplays.Quiz1.Nodes;
using UnityEngine;

namespace Game.Scripts.Gameplays.Quiz1.Units
{

    /// <summary>
    /// Unit without any subunits
    /// </summary>
    public class SimpleUnit : Unit, IDamagable
    {
        /// <summary>
        /// health, max health
        /// </summary>
        public event Action<int, int> OnHealthChanged;

        public override int Damage
        {
            get
            {
                CardInfo cardInfo = _card.GetCardInfo();
                return cardInfo.Damage + _card.level * cardInfo.DamagePerLevel;
            }
        }

        public int Health
        {
            get
            {
                CardInfo cardInfo = _card.GetCardInfo();
                return cardInfo.Health + _card.level * cardInfo.HealthPerLevel;
            }
        }

        public Animator Animator;

        protected int _health;

        [SerializeField] private List<CustomAnimator> DamageAnimators = null;

        private List<CustomAnimator> _availableDamageAnimators;

        public override void Init(PlayerColor owner, string ownerId, int id, Node startNode, Card card)
        {
            base.Init(owner, ownerId, id, startNode, card);
            _health = Health;

            _availableDamageAnimators = new List<CustomAnimator>(DamageAnimators);

            DamageAnimators.ForEach(da =>
            {
                da.OnPlayed += RemoveAnimatorFromAvailable;
                da.OnAnimationEnd += AddAnimatorToAvailable;
            });
        }

        public override void TakeDamage(int damage, AttackType attackType)
        {
            if ((_health -= damage) <= 0)
            {
                Destroy();
            }

            PlayDamageAnimation();

            OnHealthChanged?.Invoke(_health, Health);
        }

        public void PlayDamageAnimation()
        {
            if (_availableDamageAnimators.Count <= 0)
            {
                Debug.LogWarning("Couldn't play damage animation. No available damage animators in subunit!");
                return;
            }

            int randomNumber = UnityEngine.Random.Range(0, _availableDamageAnimators.Count);

            _availableDamageAnimators[randomNumber].Play();
        }

        private void AddAnimatorToAvailable(CustomAnimator animator)
        {
            if (!_availableDamageAnimators.Contains(animator))
            {
                _availableDamageAnimators.Add(animator);
            }
        }

        private void RemoveAnimatorFromAvailable(CustomAnimator animator)
        {
            if (_availableDamageAnimators.Contains(animator))
            {
                _availableDamageAnimators.Remove(animator);
            }
        }
    }

}