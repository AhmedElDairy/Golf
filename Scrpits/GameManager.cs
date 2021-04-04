using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton class: GameManager

    public static GameManager Instance;
    public GameObject completeLevelUI;
    public GameObject gameOverUI;
    public GameObject ballUI;
    public GameObject TrajectoryUI;
    public float timeLeft = 3.0f;

    public Ball ball;
    public Trajectory trajectory;
    [SerializeField] float pushForce = 4f;

    bool isDragging = false;
    bool isDragging2 = true;
    bool isDragging3 = true;
    bool action = true;
    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    public void CompleteLevel() {

        //Debug.Log("Level Complete");

        completeLevelUI.SetActive(true);

        
    }
    

   
    public void GameLost()
    {

        //Debug.Log("Level bye");
        
        gameOverUI.SetActive(true);
        ballUI.SetActive(false);
        TrajectoryUI.SetActive(false);

    }


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    
    }

    #endregion

    Camera cam;


    //---------------------------------------
    void Start()
    {
        cam = Camera.main;
        ball.DesactivateRb();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (isDragging3)
            {
                isDragging = true;

                OnDragStart();

                Invoke("actionTimer", 2);

            }
        }
        if (Input.GetMouseButtonUp(0) && isDragging2)
        {
            isDragging3 = false;
            isDragging = false;
            action = false;
            OnDragEnd();
        }

        if (isDragging)
        {
            OnDrag();
        }
    }
    void actionTimer() {
        if (action)
        {
            isDragging = false;
            isDragging2 = false;
            isDragging3 = false;
            OnDragEnd();
        }
    }
   

    //-Drag--------------------------------------
    void OnDragStart()
    {
        ball.DesactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }

    void OnDrag()
    {
        
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            distance = Vector2.Distance(startPoint, endPoint);
            direction = (startPoint - endPoint).normalized;
        
            force = direction * distance * pushForce;
       
            //just for debug
            Debug.DrawLine(startPoint, endPoint);


            trajectory.UpdateDots(ball.pos, force);
           
        
    }

    void OnDragEnd()
    {
        //push the ball
        ball.ActivateRb();
        
        ball.Push(force);              

        trajectory.Hide();
    }
}
