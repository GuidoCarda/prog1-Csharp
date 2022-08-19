using UnityEngine; // siempre poner al usar el motor grafico 

#pragma warning disable 649
namespace UnityStandardAssets.Utility // no necesario agregar
{
	public class SmoothFollow : MonoBehaviour
	{

		// The target we are following
		[SerializeField]
		private Transform target; // transform almacena ejes
		// The distance in the x-z plane to the target
		[SerializeField]
		private float distance = 10.0f;
		// the height we want the camera to be above the target
		[SerializeField]
		private float height = 5.0f;

		[SerializeField]
		private float rotationDamping; 
		[SerializeField]
		private float heightDamping;

		// Use this for initialization
		void Start() { } // se ejecuta una sola vez cuando se inicia el juego

		// Update is called once per frame
		void LateUpdate() // por cada fotograma se ejecuta , va a esperar que todos los objetos del juego carguen antes de empezar
		{
			// Early out if we don't have a target
			if (!target)
				return;

			// Calculate the current rotation angles
			var wantedRotationAngle = target.eulerAngles.y; //eulerangles proporciona angulos en grados
			var wantedHeight = target.position.y + height; // check el pibot del personaje

			var currentRotationAngle = transform.eulerAngles.y;
			var currentHeight = transform.position.y;

			// Damp the rotation around the y-axis //seguimiento de personaje, con mas o menos retraso
			currentRotationAngle = Mathf.LerpAngle(currentRotationAngle,
			                                       wantedRotationAngle,
			                                       rotationDamping * Time.deltaTime);

			// Damp the height
			currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

			// Convert the angle into a rotation
			var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			transform.position = target.position;
			transform.position -= currentRotation * Vector3.forward * distance;

			// Set the height of the camera
			transform.position = new Vector3(transform.position.x ,currentHeight , transform.position.z);

			// Always look at the target
			transform.LookAt(target);
		}
	}
}




/* 
	Esto es un comentario multi linea
	private: solo accesible desde el script
	public: x persona puede modificar los valores (unity cambios, interfaz)
	Metodos siempre en mayuscula
	lerp permite generar valores de un angulo inicial y final para hacer smooth la rotacion.
	
 */
