using System.Collections;
using UnityEngine;

public class lazerreverse: MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        StartCoroutine(SwitchAnimations(3f));
    }

    private IEnumerator SwitchAnimations(float interval)
    {
        while (true)
        {
            // 첫 번째 애니메이션 실행
            boxCollider.enabled = true; // BoxCollider2D 활성화
            animator.SetTrigger("AnimateFirst");

            yield return new WaitForSeconds(interval);

            // 두 번째 애니메이션 실행
            boxCollider.enabled = false; // BoxCollider2D 비활성화
            animator.SetTrigger("AnimateSecond");

            yield return new WaitForSeconds(interval);
        }
    }
}