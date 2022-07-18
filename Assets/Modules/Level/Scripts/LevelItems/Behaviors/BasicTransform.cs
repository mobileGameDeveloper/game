using DG.Tweening;
using UnityEngine;

namespace Modules.Level.Scripts.LevelItems.Behaviors
{
    public class BasicTransform
    {
        private Transform transform;
        private Tweener moveTween;
        private Tweener scaleTween;
        private Tweener rotateTween;

        public BasicTransform(Transform transform)
        {
            this.transform = transform;
        }
        
        public Vector2 GetPosition()
        {
            return transform.position;
        }
        
        public void MoveToPos(Vector2 tarPos)
        {
            moveTween?.Kill();
            moveTween = null;
            transform.position = tarPos;
        }

        public Tween MoveWithPath(Vector3[] points, float duration, PathType pathType)
        {
            moveTween?.Kill();
            moveTween = null;
            moveTween  = transform.DOPath(points, duration, pathType, PathMode.TopDown2D);
            return moveTween;
        }

        public Tween DoLocalRotateQuaternion(Quaternion to, float duration)
        {
            rotateTween?.Kill();
            return transform.DORotateQuaternion(to, duration);
        }
        
        public void SetLocalRotateQuaternion(Quaternion to)
        {
            rotateTween?.Kill();
            transform.rotation = to;
        }

        public Tween MoveToPos(Vector2 tarPos, float duration)
        {
            moveTween?.Kill();
            moveTween = null;
            moveTween = transform.DOMove(tarPos, duration);
            return moveTween;
        }

        public Tween Scale(Vector2 scale, float duration)
        {
            scaleTween?.Kill();
            scaleTween = null;
            scaleTween = transform.DOScale(scale, duration);
            return scaleTween;
        }

        public void Scale(Vector2 scale)
        {
            scaleTween?.Kill();
            scaleTween = null;
            transform.localScale = scale;
        }

        public void Dispose()
        {
            moveTween?.Kill();
            scaleTween?.Kill();
            rotateTween?.Kill();
        }

        public void Enable()
        {
            transform.gameObject.SetActive(true);
        }

        public void Disable()
        {
            moveTween?.Kill();
            scaleTween?.Kill();
            rotateTween?.Kill();
            transform.gameObject.SetActive(false);
        }
    }
}