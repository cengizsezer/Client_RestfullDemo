using UnityEngine;

public class LobbyPanelBase : MonoBehaviour
{
    [field: SerializeField, Header("LobbyPanelBase Vars")]
    public LobbyPanelType PanelType { get; private set; }
    [SerializeField] private Animator panelAnimator;
    
    protected LobbyUIManager lobbyUIManager;
    
    public enum LobbyPanelType
    {
        None,
        CreateUserPanel,
        UserSettingsPanel,
        AllUserPanel,
        UpdateUserByIDPanel
    }

    public virtual void InitPanel(LobbyUIManager uiManager)
    {
        lobbyUIManager = uiManager;
    }

    public void ShowPanel()
    {
        this.gameObject.SetActive(true);
        const string POP_IN_CLIP_NAME = "In";
        CallAnimationCoroutine(POP_IN_CLIP_NAME, true);
    }

    protected void ClosePanel()
    {
        const string POP_OUT_CLIP_NAME = "Out";
        CallAnimationCoroutine(POP_OUT_CLIP_NAME, false);
    }

    private void CallAnimationCoroutine(string clipName, bool state)
    {
        StartCoroutine(AnimationUtil.PlayAnimAndSetStateWhenFinished(gameObject, panelAnimator, clipName, state));
    }
}
