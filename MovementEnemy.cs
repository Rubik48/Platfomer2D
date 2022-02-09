using UnityEngine;
using DG.Tweening;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private Transform _startWayPoint;
    [SerializeField] private Transform _endWayPoints;
    [SerializeField] private float _duration;

    private void Start()
    {
        transform.position = _startWayPoint.position;

        transform.DOMove(_endWayPoints.position, _duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
