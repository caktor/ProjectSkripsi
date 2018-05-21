using UnityEngine;

public class MovementControlFlow : MonoBehaviour
{
    [SerializeField]
    private int m_stepFoward = 2;

    [SerializeField]
    private LeanTweenType m_tweenType = LeanTweenType.easeOutBack;

    public void FacingLefthandler()
    {
        LeanTween.cancel(gameObject);
        LeanTween
            .rotateAround(gameObject, Vector3.up, -90.0f, GameplayManager.Duration)
            .setEase(m_tweenType);
    }

    public void FacingRightHandler()
    {
        LeanTween.cancel(gameObject);
        LeanTween
            .rotateAround(gameObject, Vector3.up, 90.0f, GameplayManager.Duration)
            .setEase(m_tweenType);
    }

    public void TurnBackHandler()
    {
        LeanTween.cancel(gameObject);
        LeanTween
            .rotateAround(gameObject, Vector3.up, 180.0f, GameplayManager.Duration)
            .setEase(m_tweenType);
    }

    public void FowardHandler(bool isColliding)
    {
        if (!isColliding)
        {
            LeanTween.cancel(gameObject);
            LeanTween
                .moveY(gameObject, 0.1f, GameplayManager.Duration / 3.0f)
                .setEase(LeanTweenType.easeOutBack)
                .setOnComplete(() =>
                {
                    LeanTween
                        .moveY(gameObject, 0.0f, GameplayManager.Duration / 3.0f)
                        .setEase(LeanTweenType.easeOutBack);
                });
            return;
        }

        Vector3 targetMovement = RotationToTargetMovement();

        LeanTween.cancel(gameObject);
        LeanTween
            .move(gameObject, targetMovement, GameplayManager.Duration)
            .setEase(m_tweenType);

    }

    private Vector3 RotationToTargetMovement()
    {
        Vector3 target = transform.position;
        switch (transform.rotation.eulerAngles.y.ToString())
        {
            case "0":
                target += Vector3.forward * m_stepFoward;
                break;
            case "90":
                target += Vector3.right * m_stepFoward;
                break;
            case "180":
                target += Vector3.back * m_stepFoward;
                break;
            case "270":
                target += Vector3.left * m_stepFoward;
                break;
            default:
                break;
        }
        return target;
    }
}
