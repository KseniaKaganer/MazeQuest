using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(QuitHandle);
    }

    public void QuitHandle()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
