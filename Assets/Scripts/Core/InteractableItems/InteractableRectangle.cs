using UnityEngine;

namespace Core.InteractableItems
{
    public class InteractableRectangle
    {
        private Vector2 centerPoint;
        private float width;
        private float height;

        public InteractableRectangle(Vector2 centerPoint, float totalWidth, float totalHeight)
        {
            this.centerPoint = centerPoint;
            this.width = totalWidth / 2;
            this.height = totalHeight / 2;
        }

        public void UpdateCenter(Vector2 newCenterPoint)
        {
            centerPoint = newCenterPoint;
        }

        public Vector2 GetCenter()
        {
            return centerPoint;
        }

        public bool DidPointCollide(Vector2 point)
        {
            
            Debug.Log($"point position {centerPoint} clickPosition {point}");
            bool didCollide = false;
            bool isXCoordinateInside = centerPoint.x - width <= point.x && point.x <= centerPoint.x + width;
            if (isXCoordinateInside)
            {
                bool isYCoordinateInside = centerPoint.y - height <= point.y && point.y <= centerPoint.y + height;
                if (isYCoordinateInside)
                    didCollide = true;
            }

            return didCollide;
        }
    }
}