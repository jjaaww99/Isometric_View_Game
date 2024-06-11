using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; } // 싱글톤 인스턴스

    public CinemachineVirtualCamera virtualCamera; // 카메라 가상 객체
    private CinemachineBasicMultiChannelPerlin noise; // 카메라 흔들림 변수

    private void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // 이미 다른 인스턴스가 존재하면 현재 객체 파괴
    }

    private void Start()
    {
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = 0f;
    }


    public void Shake(float duration, float power)
    {
        StartCoroutine(Recoil(duration, power));
    }

    private IEnumerator Recoil(float duration, float power)
    {
        noise.m_AmplitudeGain = power;
        yield return new WaitForSeconds(duration);
        noise.m_AmplitudeGain = 0f;
    }
}
