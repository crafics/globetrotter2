using System;
using UnityEngine;

namespace Game.Scripts.Gameplays.Quiz1.Units
{

    /// <summary>
    /// Used for playing effects animations
    /// </summary>
    public class CustomAnimator : MonoBehaviour
    {
        public event Action<CustomAnimator> OnPlayed;
        public event Action<CustomAnimator> OnAnimationEnd;
        public event Action<CustomAnimator> OnDestroyed;

        public bool IsPlaying { private set; get; }

        /// <summary>
        /// Name of trigger activated on play
        /// </summary>
        public string TriggerName;

        [SerializeField] private Animator _animator = null;

        public void Play()
        {
            IsPlaying = true;
            _animator.SetTrigger(TriggerName);
            OnPlayed?.Invoke(this);
        }

        public void AnimationEnd()
        {
            IsPlaying = false;
            OnAnimationEnd?.Invoke(this);
        }

        private void OnDestroy()
        {
            OnPlayed = null;
            OnAnimationEnd = null;
            OnDestroyed?.Invoke(this);
        }

        public void SetAnimatorSpeed(float speed)
        {
            _animator.speed = speed;
        }
    }

}