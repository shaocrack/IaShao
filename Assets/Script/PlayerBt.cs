using UnityEngine;
using Panda;

public class EnemigoBehavior : MonoBehaviour
{
    public float velocidad = 3.0f;
    public float distanciaDePersecucion = 10.0f;
    public float distanciaDeDetencion = 3.0f;

    private Transform jugador;
    private bool enemigoCerca = false;
    private bool descansando = false;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    [Task]
    bool EnemigoCerca()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);
        enemigoCerca = distanciaAlJugador <= distanciaDePersecucion;
        return enemigoCerca;
    }

    [Task]
    void IrEnemigo()
    {
        if (enemigoCerca)
        {
            Vector3 direccionAlJugador = (jugador.position - transform.position).normalized;
            Vector3 nuevaPosicion = Vector3.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);
            transform.position = nuevaPosicion;
            Debug.Log("Yendo hacia el enemigo");
        }
        Task.current.Succeed();
    }

    [Task]
    void Atacar()
    {
        if (enemigoCerca)
        {
            Debug.Log("Atacando al enemigo");
        }
        Task.current.Succeed();
    }

    [Task]
    bool Descansar()
    {
        
        descansando = true; 
        return descansando;
    }

    [Task]
    void RecorrerPerimetro()
    {
        if (descansando)
        {
            Debug.Log("Recorriendo el perímetro");
        }
        Task.current.Succeed();
    }

    [Task]
    void InitializeBehavior()
    {
        Debug.Log("Inicializando comportamiento");
        Task.current.Succeed();
    }

    [Task]
    void UpdateBehavior()
    {
        Debug.Log("Actualizando comportamiento");
        Task.current.Succeed();
    }

    // Update is called once per frame
    void Update()
    {
        // Ejecuta el comportamiento de Panda BT
        //if (!PandaBehaviour.BehaviourTree.Tick(gameObject))
        //{
        //    Debug.LogWarning("Fallo al ejecutar el comportamiento");
        //}
    }
}
