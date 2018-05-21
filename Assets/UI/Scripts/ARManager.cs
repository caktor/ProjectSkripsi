/*using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Vuforia;

public class ARManager : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour m_trackableBehaviour;
    // Use this for initialization
    void Start()
    {
        m_trackableBehaviour = GetComponent<TrackableBehaviour>();
        if (m_trackableBehaviour)
        {
            m_trackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackClick()
    {
        SceneManager.LoadScene("SelectCharacter");
    }
    public void OnTrackableStateChanged(
                                   TrackableBehaviour.Status previousStatus,
                                   TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Play audio when target is found
           
        }
        else
        {
            // Stop audio when target is lost
           
        }
    }
}
*/
   

  