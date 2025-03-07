using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public GameObject effect;

    private void Start()
    {
        Time.timeScale = 1f;
        effect.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            TimeSlow();
            effect.SetActive(true);
        }
    }

    public void TimeSlow()
    {
        Time.timeScale = 0.2f;
        Invoke("TimeContinue", 1.9f);

        StopAllCoroutines();
    }

    void TimeContinue()
    {
        effect.SetActive(false);
        Time.timeScale = 1f;
    }
}
