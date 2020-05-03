using UnityEngine;
using UnityEngine.SceneManagement;

public class Pod : MonoBehaviour
{
    new Rigidbody rigidbody;
    AudioSource audioSource;

    enum State { Alive, Dying, Transcending }
    State state = State.Alive;

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 150f;
    [SerializeField] AudioClip mainEngineSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip levelCompleteSound;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // todo stop sound on death
        if (state == State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }
    }

    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void ApplyThrust()
    {
        float mainThrustThisFrame = mainThrust * Time.deltaTime;
        rigidbody.AddRelativeForce(Vector3.up * mainThrustThisFrame);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngineSound);
        }
    }

    private void RespondToRotateInput()
    {

        rigidbody.freezeRotation = true;

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back * rotationThisFrame);
        }

        rigidbody.freezeRotation = false;
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (state != State.Alive)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartLevelFinishedSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }
    }

    private void StartLevelFinishedSequence()
    {
        state = State.Transcending;
        SwitchSound(levelCompleteSound);
        Invoke("LoadNextLevel", 1f);
    }

    private void StartDeathSequence()
    {
        state = State.Dying;
        SwitchSound(deathSound);
        Invoke("LoadFirstLevel", 1f);
    }

    private void SwitchSound(AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClip);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1); // todo allow more levels
    }
}
