using System.Collections;
using UnityEngine;

namespace Game.Scripts.Gameplays.Quiz1.Units
{

    /// <summary>
    /// Handles simple unit animations
    /// </summary>
    public class SimpleUnitModel : UnitModel
    {
        private SimpleUnit _simpleUnit;

        public override void Init()
        {
            _simpleUnit = (SimpleUnit)_unit;
            base.Init();
        }

        protected override IEnumerator MoveAnimationCoroutine(Vector3 startPosition, Vector3 targetPosition)
        {
            float timer = 0;

            while (timer < MoveAnimationTime)
            {
                timer += Time.deltaTime;

                transform.position = Vector3.Lerp(startPosition, targetPosition, _translationAnimationCurve.Evaluate(timer / MoveAnimationTime));

                yield return null;
            }

            EndMoveAnimation();
        }

        protected override IEnumerator RotationAnimationCoroutine(Quaternion targetRotation)
        {
            Quaternion startRotation = transform.rotation;

            float animationTime = (Quaternion.Angle(startRotation, targetRotation) / 360f) / RotateAnimationTime;

            float timer = 0;

            while (timer < animationTime)
            {
                timer += Time.deltaTime;

                transform.rotation = Quaternion.Lerp(startRotation, targetRotation, _rotationAnimationCurve.Evaluate(timer / animationTime));

                yield return null;
            }

            EndRotationAnimation();
        }

        protected override IEnumerator DestroyAnimationCoroutine(Unit unit)
        {
            SimpleUnit simpleUnit = unit as SimpleUnit;
            simpleUnit.Animator.SetTrigger("Death");
            yield return new WaitForSeconds(1);
            Destroy(unit.gameObject);
        }
    }

}