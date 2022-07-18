using UnityEngine;

namespace Modules.UI.LevelItem.ScriptableObjects
{

    [CreateAssetMenu(fileName = "LevelItemHolderDimensions", menuName = "Modules/Level/LevelItemHolderDimensions", order = 1)]
    public class LevelItemHolderDimensions : ScriptableObject
    {
        [SerializeField] public float heightOfHolder;
        [SerializeField] public float widthOfHolder;
        [SerializeField] public float initialCoordinateX;
        [SerializeField] public float initialCoordinateY;
        [SerializeField] public float heightOfScreen;
        [SerializeField] public float widthOfScreen;
    }

}