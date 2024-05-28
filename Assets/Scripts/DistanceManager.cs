using TMPro;
using UnityEngine;

public class DistanceManager : MonoBehaviour
{
    // singleton pattern
    public static DistanceManager Instance;

    // serialize field to expose in the inspector
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private float distanceMultiplier = 50;
    public float distanceTravelled { get; private set; }
    private bool isTravelling = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.LogWarning("There are multiple DistanceManagers in the scene. Destroying the newest one.");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!isTravelling) { return; }
        // Time.deltaTime is the time in seconds it took to complete the last frame
        distanceTravelled += Time.deltaTime * distanceMultiplier;

        // formats the float to have 0 decimal places
        distanceText.text = "Hammy Boi ran: " + distanceTravelled.ToString("F0") + "m";
    }

    public void StartScript()
    {
        isTravelling = true;
    }
}
