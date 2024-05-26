using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Button left_move_button, right_move_button;
    [SerializeField] private Button next_stage;
    private float move_speed = 15.0f;
    private float move_distance = 5.6f;

    public static CameraMovement instance;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    private void Start()
    {
        next_stage.onClick.AddListener(Next_Stage);
        left_move_button.onClick.AddListener(Camera_Left_Move);
        right_move_button.onClick.AddListener(Camera_Right_Move);
    }

    private void Next_Stage()
    {
        Camera.main.transform.position += new Vector3(0, 20, 0);
    }

    private void Camera_Left_Move()
    {
        StartCoroutine(Smooth_Move(Camera.main.transform.position + new Vector3(-move_distance, 0, 0)));
    }

    private void Camera_Right_Move()
    {
        StartCoroutine(Smooth_Move(Camera.main.transform.position + new Vector3(move_distance, 0, 0)));
    }

    IEnumerator Smooth_Move(Vector3 target_position)
    {
        while (Vector3.Distance(Camera.main.transform.position, target_position) > 0.01f)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, target_position, move_speed * Time.deltaTime);
            yield return null;
        }
        Camera.main.transform.position = target_position;
    }
}