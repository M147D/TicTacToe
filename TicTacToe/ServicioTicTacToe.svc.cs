using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TicTacToe
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioTicTacToe" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioTicTacToe.svc o ServicioTicTacToe.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioTicTacToe : IServicioTicTacToe
    {
        // Variable que representa el tablero con una matriz 3x3 
        private static char[,] tablero = new char[3, 3];
        // Variable que contiene el carácter que gana la partida
        private static char ganador = ' ';
        // Variable que identifica qué jugador tiene el turno
        private static int jugadorActual = 1;
        // Variable que almacena la información sobre los jugadores durante la partida
        private static Dictionary<int, char> jugadores = new Dictionary<int, char>();

        // Método que inicializa las variables para cada jugador
        public void EmpezarJuego()
        {
            // Se inicializa el tamaño de la matriz en 3x3 de tipo char (carácter) para el jugador
            tablero = new char[3, 3];
            // Se inicializa el carácter ganador con un espacio en blanco
            ganador = ' ';
            // Se inicializa el turno del jugador, sería el primer turno
            jugadorActual = 1;
            // Se limpia la información previa de jugadores en otras partidas
            jugadores.Clear();
        }

        // Método para manejar los movimientos del jugador
        public bool Mover(int idJugador, int x, int y)
        {
            // Primero, se verifica que el jugador se encuentre en el diccionario; segundo,
            // se verifica que el valor almacenado en el tablero no sea nulo; tercero,
            // se verifica que el ganador no esté en blanco
            if (!jugadores.ContainsKey(idJugador) || tablero[x, y] != '\0' || ganador != ' ')
                // Se retorna falso en caso de que al menos una de las 3 condiciones se cumpla
                return false;

            // Se verifica que el jugador actual esté identificado con 'X' o 'O' en el diccionario para registrar sus movimientos.
            if ((jugadorActual == 1 && jugadores[idJugador] == 'X') || (jugadorActual == 2 && jugadores[idJugador] == 'O'))
            {
                // Se asigna el movimiento del jugador actual en la posición (x,y)
                tablero[x, y] = jugadores[idJugador];
                // Se alterna el turno de los jugadores: si es el Jugador 1, se cambia al Jugador 2 y viceversa
                jugadorActual = jugadorActual == 1 ? 2 : 1;
                // Se determina si hay un ganador después del movimiento
                ganador = DeterminarGanador() == "Nadie" ? ' ' : jugadores[idJugador];
                return true;
            }
            return false;
        }

        // Método para obtener el estado actual del tablero
        public string ObtenerTablero()
        {
            // Convierte el tablero a una cadena separada por comas, reemplazando los valores nulos por espacios
            return string.Join(",", tablero.Cast<char>().Select(c => c == '\0' ? ' ' : c));
        }

        // Método para determinar el ganador del juego
        public string DeterminarGanador()
        {
            // Verifica filas y columnas para determinar si hay tres en línea
            for (int i = 0; i < 3; i++)
            {
                if (tablero[i, 0] == tablero[i, 1] && tablero[i, 1] == tablero[i, 2] && tablero[i, 0] != '\0')
                    return tablero[i, 0].ToString();
                if (tablero[0, i] == tablero[1, i] && tablero[1, i] == tablero[2, i] && tablero[0, i] != '\0')
                    return tablero[0, i].ToString();
            }

            // Verifica las diagonales para determinar si hay tres en línea
            if (tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2] && tablero[0, 0] != '\0')
                return tablero[0, 0].ToString();
            if (tablero[0, 2] == tablero[1, 1] && tablero[1, 1] == tablero[2, 0] && tablero[0, 2] != '\0')
                return tablero[0, 2].ToString();

            // Si hay alguna celda vacía, el juego sigue en progreso
            foreach (char celda in tablero)
                if (celda == '\0')
                    return "Nadie";

            // Si no hay celdas vacías y nadie ha ganado, es un empate
            return "Empate";
        }

        // Método para unir a un nuevo jugador al juego
        public int Unir()
        {
            // Verifica si ya hay dos jugadores en el juego
            if (jugadores.Count >= 2)
                return -1;

            // Asigna un ID al nuevo jugador y lo agrega al diccionario con su símbolo (X o O)
            int idJugador = jugadores.Count + 1;
            jugadores.Add(idJugador, idJugador == 1 ? 'X' : 'O');
            return idJugador;
        }
    }
}