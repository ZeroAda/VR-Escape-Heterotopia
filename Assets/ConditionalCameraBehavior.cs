using UnityEngine;

public class ConditionalCameraFollow : MonoBehaviour
{
    #region Variables

    private Vector3 _offset2;
    private Quaternion _rotationOffset;
    [SerializeField] private Transform target2;
    [SerializeField] private Transform head;
    [SerializeField] private Transform hand;
    [SerializeField] private float smoothTime2;
    [SerializeField] private float rotationThreshold; // 旋转阈值
    private Vector3 _currentVelocity2 = Vector3.zero;
    private float _currentAngularVelocity2 = 0.0f;

    private Quaternion _lastHeadRotation;
    private Quaternion _lastHandRotation;

    #endregion

    #region Unity callbacks

    private void Awake()
    {
        _offset2 = transform.position - target2.position;
        _rotationOffset = Quaternion.Euler(0, transform.eulerAngles.y - target2.eulerAngles.y, 0);

        // 初始化为当前的旋转
        _lastHeadRotation = head.rotation;
        _lastHandRotation = hand.rotation;
    }

    private void LateUpdate()
    {
        // Position dampening
        Vector3 targetPosition = target2.position + _offset2;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity2, smoothTime2);

        // Check if both head and hand have rotated beyond the threshold
        bool headRotated = Quaternion.Angle(head.rotation, _lastHeadRotation) > rotationThreshold;
        bool handRotated = Quaternion.Angle(hand.rotation, _lastHandRotation) > rotationThreshold;

        // If both head and hand have rotated, then rotate the camera
        if (headRotated && handRotated)
        {
            float targetYRotation = target2.eulerAngles.y + _rotationOffset.eulerAngles.y;
            float smoothedYRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetYRotation, ref _currentAngularVelocity2, smoothTime2);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, smoothedYRotation, transform.eulerAngles.z);
        }

        // Update last rotations
        _lastHeadRotation = head.rotation;
        _lastHandRotation = hand.rotation;
    }

    #endregion
}
