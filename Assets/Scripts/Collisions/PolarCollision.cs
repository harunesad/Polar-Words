using UnityEngine;

namespace Collisions
{
    public class PolarCollision : MonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer != 10)
            {
                WordsStateManager.wordsState.ground = other.gameObject;
            }
        }
    }
}

