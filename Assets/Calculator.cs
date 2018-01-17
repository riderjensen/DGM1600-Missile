using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour {

    string a = "";
    string b = "";
    string divideDisplay = "Divide";
    string multiplyDisplay = "Multiply";
    string subtractDisplay = "Subtract";
    string addDisplay = "Add";
    double divide;
    double multiply;
    double subtract;
    double add;
    public static int randomNumber;
    int playerScore = 0;
    bool showButtonDivide = true;
    bool showButtonMultiply = true;
    bool showButtonSubtract = true;
    bool showButtonAdd = true;
    int secondaryRando = 50;
    int secondaryRando2 = 1250;
    int runTime;


    //movement of the number
    static public int xPos;
    static public float fallingYPos;

    //This is for background color
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 3.0F;
    public CameraClearFlags clearFlags;
    Camera camera;

    //Movement
    public Transform Cubes;
    public GameObject Cube;

    //sound
    public AudioClip clip;



    void Start()
    {
        randomNumberGenerator();

        //More background stuff
        camera = GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;

        xPos = secondaryRandomNumberGenerator(secondaryRando, secondaryRando2);
            }

    //random number generator
    int randomNumberGenerator()
    {
        randomNumber = Random.Range(1, 20);
        return randomNumber;
    }

    int secondaryRandomNumberGenerator(int rando1, int rando2)
    {
        int randomSecondaryNumber = Random.Range(rando1, rando2);
        return randomSecondaryNumber;
    }
    

    void Update()
    {
        //more background stuff
        float t = Mathf.PingPong(Time.time, duration) / duration;
        camera.backgroundColor = Color.Lerp(color1, color2, t);

        //MOVEMENT of RANDOM NUMBER
        Cube = GameObject.Find("Cube");
        Vector3 screenPos = camera.WorldToScreenPoint(Cubes.position);
        fallingYPos = screenPos.y;
    }


        // Use this for initialization
    void OnGUI() {
        a = GUI.TextField(new Rect(500, 100, 100, 25), a);
        b = GUI.TextField(new Rect(500, 200, 100, 25), b);



        if (showButtonDivide == true)
        {   
            //divide button
            if (GUI.Button(new Rect(800, 75, 60, 25), "") || Input.GetKeyDown(KeyCode.KeypadDivide))
            {
                double integerA = 0;
                double integerB = 0;

                System.Double.TryParse(a, out integerA);
                System.Double.TryParse(b, out integerB);

                divide = (integerA / integerB);
                

            }
            GUI.Label(new Rect(805, 75, 50, 25), divideDisplay);
        }
       
        if (showButtonMultiply == true)
        {   
            //multiply button
            if (GUI.Button(new Rect(800, 125, 60, 25), "") || Input.GetKeyDown(KeyCode.KeypadMultiply))
            {
                double integerA = 0;
                double integerB = 0;

                System.Double.TryParse(a, out integerA);
                System.Double.TryParse(b, out integerB);

                multiply = (integerA * integerB);

            }
            GUI.Label(new Rect(805, 125, 50, 25), multiplyDisplay);
        }

        if  (showButtonSubtract == true)
        {   
            //subtract
            if (GUI.Button(new Rect(800, 175, 60, 25), "") || Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                double integerA = 0;
                double integerB = 0;

                System.Double.TryParse(a, out integerA);
                System.Double.TryParse(b, out integerB);

                subtract = (integerA - integerB);

            }
            GUI.Label(new Rect(805, 175, 50, 25), subtractDisplay);
        }
        
        if (showButtonAdd == true)
        {   
            //add button
            if (GUI.Button(new Rect(800, 225, 60, 25), "") || Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                double integerA = 0;
                double integerB = 0;

                System.Double.TryParse(a, out integerA);
                System.Double.TryParse(b, out integerB);

                add = (integerA + integerB);

            }
            GUI.Label(new Rect(805, 225, 50, 25), addDisplay);
        }

       
        


        //checking for what random number equals
        if (divide == randomNumber)
        {
            randomNumber = randomNumberGenerator();
            xPos = secondaryRandomNumberGenerator(secondaryRando, secondaryRando2);
            playerScore++;
            divide = 0;
            multiply = 0;
            subtract = 0;
            add = 0;
            showButtonDivide = false;
            runTime++;
            Cube.transform.Translate(0, 2f, 0);
            AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, -10));
            
        }
        if (multiply == randomNumber)
        {
            randomNumber = randomNumberGenerator();
            xPos = secondaryRandomNumberGenerator(secondaryRando, secondaryRando2);
            playerScore++;
            divide = 0;
            multiply = 0;
            subtract = 0;
            add = 0;
            showButtonMultiply = false;
            runTime++;
            Cube.transform.Translate(0, 2f, 0);
            AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, -10));

        }
        if (subtract == randomNumber)
        {
            randomNumber = randomNumberGenerator();
            xPos = secondaryRandomNumberGenerator(secondaryRando, secondaryRando2);
            playerScore++;
            divide = 0;
            multiply = 0;
            subtract = 0;
            add = 0;
            showButtonSubtract = false;
            runTime++;
            Cube.transform.Translate(0, 2f, 0);
            AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, -10));

        }
        if (add == randomNumber){
            randomNumber = randomNumberGenerator();
            xPos = secondaryRandomNumberGenerator(secondaryRando, secondaryRando2);
            playerScore++;
            divide = 0;
            multiply = 0;
            subtract = 0;
            add = 0;
            showButtonAdd = false;
            runTime++;
            Cube.transform.Translate(0, 2f, 0);
            AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, -10));

        }

        //reset buttons after all have been clicked
        if (showButtonDivide == false && showButtonMultiply == false && showButtonSubtract == false && showButtonAdd == false)
        {
            showButtonDivide = true;
            showButtonMultiply = true;
            showButtonSubtract = true;
            showButtonAdd = true;
            Cube.transform.Translate(0, 1.5f, 0);
            ChangeDrag.reduceTheDrag();

        }

        //playerscore
        GUI.Box(new Rect(650, 0, 50, 25), "");
        GUI.Label(new Rect(655, 0, 50, 25), playerScore.ToString());
        GUI.Label(new Rect(650, 25, 50, 50), "Player Score");


        //random number work and movement
        GUI.Label(new Rect(xPos, fallingYPos, 50, 25), randomNumber.ToString());


    }

}
