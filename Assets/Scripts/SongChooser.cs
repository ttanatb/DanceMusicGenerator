using UnityEngine;

public class SongChooser : MonoBehaviour
{
    public int BPM = 130;
    private AudioSource beatAudioSource;
    private AudioSource tuneAudioSource;

    public AudioClip[] audioClips;

    private float timer = 0f;
    private int counter = 0;
    private float crochet = 60f;

    private Transform cameraTransform;
    private Vector3 prevEuAngle;
    private float prevY;

    // Use this for initialization
    void Start()
    {
        tuneAudioSource = transform.FindChild("Tune").GetComponent<AudioSource>();
        beatAudioSource = transform.FindChild("Beat").GetComponent<AudioSource>();

        cameraTransform = Camera.main.transform;
        prevEuAngle = cameraTransform.rotation.eulerAngles;
        prevY = cameraTransform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer > crochet / BPM)
        {
            timer -= crochet / BPM;

            if (CheckIfDancing())
            {
                if (counter % 4 == 0)
                {
                    if (beatAudioSource.isPlaying)
                        beatAudioSource.Stop();

                    beatAudioSource.Play();
                }

                if (counter > 3)
                {
                    if (tuneAudioSource.isPlaying)
                        tuneAudioSource.Stop();

                    tuneAudioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
                    tuneAudioSource.Play();
                }
                counter++;
            }
            else
            {
                beatAudioSource.Stop();
                tuneAudioSource.Stop();
            }
        }

        prevEuAngle = cameraTransform.eulerAngles;
        prevY = cameraTransform.position.y;
    }

    private bool CheckIfDancing()
    {
        if ((prevEuAngle - cameraTransform.eulerAngles).sqrMagnitude > 15f || Mathf.Abs(prevY - cameraTransform.position.y) > 0.3f)
        {
            return true;
        }
        else
        {
            counter = 0;
            return false;
        }
    }
}