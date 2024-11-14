using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [SerializeField] private CinemachineVirtualCamera[] _allVirtualCameras;

    [Header("Controles  por lerping de la suavidad en Y durante que el player salta o cae")]
    [SerializeField] private float _fallPanAmount = 0.25f;
    [SerializeField] private float _fallYPamTime = 0.35f;
    public float _fallSpeedYDampingChangeThreshold = -15f;

    public bool IsLerpingYDamping {  get; private set; }
    public bool LerpedFromPlayerFalling { get; private set; }

    private Coroutine _lerpYPanCoroutine;

    private CinemachineVirtualCamera _currentCamera;
    private CinemachineFramingTransposer _framingTransposer;

    private float _normYPanAmount;

    private void Awake()
    {
        if(instance == null)
            instance = this;

        for(int i = 0;i < _allVirtualCameras.Length; i++)
        {
            //obtener la camera activa
            _currentCamera = _allVirtualCameras[i];

            //Obtener framing transposer
            _framingTransposer = _currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }

    }

    public void LerpYDamping(bool isPlayerFalling)
    {
        _lerpYPanCoroutine = StartCoroutine(LerpYAction(isPlayerFalling));
    }

    public IEnumerator LerpYAction(bool isPlayerFalling)
    {
        IsLerpingYDamping = true;

        //Agarrar el comienzo de la cantidad de damping
        float startDampAmount = _framingTransposer.m_YDamping;
        float endDampAmount = 0f;

        //Determinar el final de la suavidad
        if (isPlayerFalling)
        {
            endDampAmount = _fallPanAmount;
            LerpedFromPlayerFalling = true;
        }
        else
        {
            endDampAmount = _normYPanAmount;
        }

        //Lerp teh pan amount
        float elapsedTime = 0f;
        while (elapsedTime < _fallYPamTime)
        {
            elapsedTime += Time.deltaTime;
            float lerpedPanAmount = Mathf.Lerp(startDampAmount, endDampAmount, (elapsedTime / _fallYPamTime));
            _framingTransposer.m_YDamping = lerpedPanAmount;

            yield return null;
        }


        IsLerpingYDamping = false;
    }
}
