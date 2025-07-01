using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释
public class SoundProximityDetector : MonoBehaviour
{
    public AudioClip correctSound;
    public AudioClip wrongSound;

    [SerializeField] private float maxDetectionDistance = 5f;// 最大检测距离
    [SerializeField] private float minTimeBetweenSounds = 0.1f;// 最小声音间隔时间
    [SerializeField] private float maxTimeBetweenSounds = 2f;// 最大声音间隔时间

    private AudioSource audioSource;
    private float timeSinceLastSound;
    private float nextSoundTime;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        ResetSoundTimer();
    }

    private void Update()
    {
        timeSinceLastSound += Time.deltaTime;

        if (timeSinceLastSound >= nextSoundTime)
        {
            CheckNearbyObjects();
            ResetSoundTimer();
        }
    }
    // 检测附近的物体并播放相应的声音
    private void CheckNearbyObjects()
    {
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, maxDetectionDistance);

        GameObject closestCorrect = null;
        GameObject closestWrong = null;
        float closestCorrectDist = float.MaxValue;
        float closestWrongDist = float.MaxValue;

        foreach (Collider2D collider in nearbyColliders)
        {
            if (collider.gameObject == gameObject) continue;

            float distance = Vector2.Distance(transform.position, collider.transform.position);

            if (collider.CompareTag("CorrectObject") && distance < closestCorrectDist)
            {
                closestCorrect = collider.gameObject;
                closestCorrectDist = distance;
            }
            else if (collider.CompareTag("WrongObject") && distance < closestWrongDist)
            {
                closestWrong = collider.gameObject;
                closestWrongDist = distance;
            }
        }

        // 优先播放正确物体的声音
        if (closestCorrect != null)
        {
            PlaySound(correctSound, closestCorrectDist);
        }
        else if (closestWrong != null)
        {
            PlaySound(wrongSound, closestWrongDist);
        }
    }
    // 播放声音并根据距离调整音量和音高
    private void PlaySound(AudioClip clip, float distance)
    {
        if (clip == null) return;

        // 根据距离调整音量
        float volume = 1f - Mathf.Clamp01(distance / maxDetectionDistance);
        audioSource.PlayOneShot(clip, volume);

        // 根据距离调整音高（可选）
        audioSource.pitch = 1f + (1f - volume) * 0.5f;
    }
    // 重置声音计时器并根据距离调整下次播放时间
    private void ResetSoundTimer()
    {
        timeSinceLastSound = 0f;

        // 根据与最近物体的距离调整声音频率
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, maxDetectionDistance);
        float closestDist = maxDetectionDistance;

        foreach (Collider2D collider in nearbyColliders)
        {
            if (collider.gameObject == gameObject) continue;

            float distance = Vector2.Distance(transform.position, collider.transform.position);
            if (distance < closestDist)
            {
                closestDist = distance;
            }
        }

        // 越近频率越高（时间间隔越短）
        float proximityFactor = 1f - Mathf.Clamp01(closestDist / maxDetectionDistance);
        nextSoundTime = Mathf.Lerp(minTimeBetweenSounds, maxTimeBetweenSounds, 1f - proximityFactor);
    }

    // 可视化检测范围（仅在编辑器中可见）
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDetectionDistance);
    }
}