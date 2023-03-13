using UnityEngine;

namespace Collisions
{
    public class FishCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Json.JsonSave.json.so.fishCount++;
            Json.JsonSave.json.Save();
            Destroy(gameObject, 0.1f);
        }
    }
}

