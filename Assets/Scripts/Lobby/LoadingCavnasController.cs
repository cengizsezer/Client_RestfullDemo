using UnityEngine;
using UnityEngine.UI;

public class LoadingCavnasController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Button cancelBtn;
    
    
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    private void OnStartedRunnerConnection()
    {
        this.gameObject.SetActive(true);
        const string CLIP_NAME = "In";
        StartCoroutine(AnimationUtil.PlayAnimAndSetStateWhenFinished(gameObject, animator, CLIP_NAME));
    }
    
    private void OnPlayerJoinedSuccessfully()
    {
        const string CLIP_NAME = "Out";
        StartCoroutine(AnimationUtil.PlayAnimAndSetStateWhenFinished(gameObject, animator, CLIP_NAME, false));
    }

    private void OnDestroy()
    {
       
    }
}
