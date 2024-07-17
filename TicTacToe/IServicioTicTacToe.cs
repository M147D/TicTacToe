using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TicTacToe
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de la interfaz "IServicioTicTacToe" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioTicTacToe
    {
        // Método para iniciar un nuevo juego
        [OperationContract]
        void EmpezarJuego();

        // Método para que un jugador realice un movimiento en el tablero
        [OperationContract]
        bool Mover(int idJugador, int x, int y);

        // Método para obtener el estado actual del tablero en forma de cadena
        [OperationContract]
        string ObtenerTablero();

        // Método para determinar el ganador del juego
        [OperationContract]
        string DeterminarGanador();

        // Método para unir a un nuevo jugador al juego
        [OperationContract]
        int Unir();
    }
}