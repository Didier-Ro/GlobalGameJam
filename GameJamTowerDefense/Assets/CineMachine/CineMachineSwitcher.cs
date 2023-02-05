using UnityEngine;



public class CineMachineSwitcher : MonoBehaviour
{
    private Animator animator;
  [SerializeField] private RoundManager roundManager;
  [SerializeField] private int StateCamera = 1;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log(StateCamera);
            SwitchCamera();
        }
     
    }
    public void SwitchCamera()
    {
        switch (StateCamera)
        {
            default:
                break;
            case 1:
                animator.Play("SpanishCamera");
                StateCamera++;
                break;
            case 2:
                animator.Play("MapCamera");
                StateCamera++;
                break;
            case 3:
                if (RoundManager.RoundInstance._roundLeft == 6)
                {
                    RoundManager.RoundInstance.ResetAll();
                }
                 RoundManager.RoundInstance._roundLeft--;
                animator.Play("MexicanCamera");
                StateCamera = 1;
                break;
        }
    }
}
