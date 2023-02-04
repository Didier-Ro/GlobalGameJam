using UnityEngine;



public class CineMachineSwitcher : MonoBehaviour
{
    private Animator animator;

    private bool mexicanCamera = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            SwitchCamera();
        }
    }
    private void SwitchCamera()
    {
        if (mexicanCamera)
        {
            animator.Play("MexicanCamera");
        }
        else 
        {  
            animator.Play("SpanishCamera");
        }

        mexicanCamera = !mexicanCamera;
    }
}
