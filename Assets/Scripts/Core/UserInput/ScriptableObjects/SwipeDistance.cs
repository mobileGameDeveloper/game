using UnityEngine;

namespace Core.UserInput.ScriptableObjects
{
    
    [CreateAssetMenu(fileName = "SwipeDistance", menuName = "Core/UserInput/SwipeDistance", order = 1)]
    public class SwipeDistance : ScriptableObject
    {
        [SerializeField] public float swipeDistance;
    }
}