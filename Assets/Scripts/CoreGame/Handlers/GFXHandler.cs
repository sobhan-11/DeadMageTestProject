using UnityEngine;

namespace CoreGame
{
    public class GFXHandler : MonoBehaviour
    {
        [SerializeField] private GameObject gfx;

        [Header(" VFX "), Space] 
        [SerializeField] private ParticleSystem damageVFX;


        public void HandleGFX(bool active) => gfx.SetActive(active);

        public void PlayDamageVFX(float damage)
        {
            
        }
    }
}