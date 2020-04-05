using Game.Scripts.Gameplays.Quiz1.Units;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Gameplays.Quiz1.UI
{

    /// <summary>
    /// UI element showing health status of unit
    /// </summary>
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthValueImage = null;

        [SerializeField] private GameObject _damagableObject = null;

        private IDamagable _damagable;

        private void Start()
        {
            _damagable = _damagableObject.GetComponent<IDamagable>();
            if (_damagable != null)
            {
                _damagable.OnHealthChanged += SetValue;
            }
            else
            {
                Debug.LogError("Given object does not contains an IDamagable type");
            }
        }

        private void SetValue(int health, int maxHealth)
        {
            _healthValueImage.fillAmount = (float)health / maxHealth;
        }
    }

}