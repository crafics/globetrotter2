using System;
using System.Collections.Generic;
using Game.Scripts.Gameplays.Quiz1.Cards;
using UnityEngine;

namespace Game.Scripts.Gameplays.Quiz1.Units
{

    /// <summary>
    /// Subunit used in GroupUnits
    /// </summary>
    public class SubUnit : MonoBehaviour, IDamagable
    {
        public event Action<SubUnit> OnDestroyed;

        /// <summary>
        /// health, max health
        /// </summary>
        public event Action<int, int> OnHealthChanged;

        public Animator Animator;

        [SerializeField] private List<CustomAnimator> DamageAnimators = null;

        public int Damage
        {
            get
            {
                CardInfo cardInfo = _card.GetCardInfo();
                return cardInfo.Damage + _card.level * cardInfo.DamagePerLevel;
            }
        }

        public int MaxHealth
        {
            get
            {
                CardInfo cardInfo = _card.GetCardInfo();
                return cardInfo.Health + _card.level * cardInfo.HealthPerLevel;
            }
        }


        protected Card _card;

        private List<CustomAnimator> _availableDamageAnimators;

        private int _health;

        public void Init(Card card)
        {
            _card = card;
            _health = MaxHealth;

            _availableDamageAnimators = new List<CustomAnimator>(DamageAnimators);

            DamageAnimators.ForEach(da =>
            {
                da.OnPlayed += RemoveAnimatorFromAvailable;
                da.OnAnimationEnd += AddAnimatorToAvailable;
            });
        }

        public void TakeDamage(int damage)
        {
            if ((_health -= damage) <= 0)
            {
                Destroy();
            }
            PlayDamageAnimation();

            OnHealthChanged?.Invoke(_health, MaxHealth);
        }

        public void Destroy()
        {
            OnDestroyed?.Invoke(this);
        }

        public void OnDestroy()
        {
            OnDestroyed = null;
            OnHealthChanged = null;
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