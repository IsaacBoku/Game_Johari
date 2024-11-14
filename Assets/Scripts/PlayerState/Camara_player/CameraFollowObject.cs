using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _playerTransform;

    [Header("Flip rotation stats")]
    [SerializeField] private float _flipYRotationTTime = 0.5f;

    private Coroutine _turnCorutine;


    private Player _player;
    private bool _isFacingRight;

    private void Awake()
    {
        _player = _playerTransform.gameObject.GetComponent<Player>();
        _isFacingRight = _player.facingRight;
    }
    private void Update()
    {
        //hacer que cameraFollowObject seguira la posicion del player
        transform.position = _playerTransform.position;
    }
    public void CallTurn()
    {
        //_turnCorutine = StartCoroutine(FlipLerp());
        LeanTween.rotateY(gameObject, DetermineEndRotation(), _flipYRotationTTime).setEaseInOutSine();
    }

    private IEnumerator FlipLerp()
    {
        float startRotation = transform.localEulerAngles.y;
        float endRotationAmount = DetermineEndRotation();
        float yRotation = 0f;

        float elapsedTime = 0f;
        while(elapsedTime < _flipYRotationTTime)
        {
            elapsedTime += Time.deltaTime;

            //lerp la rotacion de Y
            yRotation = Mathf.Lerp(startRotation,endRotationAmount, (elapsedTime / _flipYRotationTTime));
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

            yield return null;
        }
    }

    private float DetermineEndRotation()
    {
        _isFacingRight = !_isFacingRight;

        if (_isFacingRight)
        {
            return 180f;
        }
        else
        {
            return 0f;

        }
    }
}
