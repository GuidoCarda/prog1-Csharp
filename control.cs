using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public int puntajeJugador = 0;
    private int contador = 30;
    public float tiempo = 0.0f;
    public float tiempoJuego = 30.0f;
    public float enemigo;
    public string nombreJugador = "Pedro";
    public char equipo = 'A';
    public int [] edades = new int [5]; 

    // Start is called before the first frame update
    
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        Debug.Log(puntajeJugador);
        Debug.Log(tiempo);     
    }

    private void OnGUI() 
    {
        GUI.Box(new Rect(100,10,150,30),"Tiempo " + tiempo);
        // GUI.contentColor = Color.black;
        // GUI.Label(new Rect(100,10,90,40),"Tiempo " + tiempo);        
    }
}
