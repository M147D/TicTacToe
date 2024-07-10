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
        // Variable que representa el tablero con una matrix 3x3 
        private static char[,] tablero = new char[3, 3];
        // Variable con el caracter que gana la partida
        private static char ganador = ' ';
        // Variable que identifica que jugador tiene el turno
        private static int jugadorActual = 1;
        // Variable que almacena la informacion sobre los jugadores durante la partida
        private static Dictionary<int, char> jugadores = new Dictionary<int, char>();

        // Metodo que inicializa las variables para cada jugador
        public void EmpezarJuego()
        {
            // Se inicializa el tamaño de la matrix en 3x3 de tipo char (caracter) para el jugador
            tablero = new char[3, 3];
            // Se inicializa el caracter ganador con un espacio en blanco
            ganador = ' ';
            // Se inicializa el turno del jugador, sería el primer turno
            jugadorActual = 1;
            // Se limpia la información previa de jugadores en otras partidas
            jugadores.Clear();
        }
        // Metodo para controlar y controlar los movimientos del jugador
        public bool Mover(int idJugador, int x, int y)
        {
            // Primero, se verifica que el jugador se encuentre en el diccinario; segundo,
            // se verifica que el valor almacenado en el tablero no sea nulo; tercero,
            // se verifica que ganador no este en blanco
            if (!jugadores.ContainsKey(idJugador) || tablero[x,y] != '\0' || ganador != ' ')
                // Se retorna falso en caso de que almenos 1 de las 3 condiciones se cumpla
                return false;
            // Se verifica que uno de los jugadores de la partida esten identificados con 'X' o 'O'
            // en el diccionario para registrar sus movimientos.
            if ((jugadorActual == 1 && jugadores[idJugador] == 'X') || (jugadorActual == 2 && jugadores[idJugador] == 'O'))
            {
                // Se asigna al jugador actual en la posisción (x,y)
                tablero[x, y] = jugadores[idJugador];
                // Aqui se alterna el turno de los jugadores, de forma que si es el Jugador 1, se cambia al Jugador 2 y viceversa
                jugadorActual = jugadorActual == 1 ? 2 : 1;
                // 
                ganador = DeterminarGanador() == "Nadie" ? ' ' :
                jugadores[idJugador];
                return true;
            }
            return false;
        }

        public string ObtenerTablero()
        {
            return string.Join(",",
            tablero.Cast<char>().Select(c => c ==
           '\0' ? ' ' : c)); ;
        }
        public string DeterminarGanador()
        {
            for (int i = 0; i < 3; i++)
            {
                if (tablero[i, 0] == tablero[i, 1] && tablero[i,
               1] == tablero[i, 2] && tablero[i, 0] != '\0')
                    return tablero[i, 0].ToString();
                if (tablero[0, i] == tablero[1, i] && tablero[1,
               i] == tablero[2, i] && tablero[0, i] != '\0')
                    return tablero[0, i].ToString();
            }
            if (tablero[0, 0] == tablero[1, 1] && tablero[1, 1]
           == tablero[2, 2] && tablero[0, 0] != '\0')
                return tablero[0, 0].ToString();
            if (tablero[0, 2] == tablero[1, 1] && tablero[1, 1]
           == tablero[2, 0] && tablero[0, 2] != '\0')
                return tablero[0, 2].ToString();
            foreach (char celda in tablero)
                if (celda == '\0')
                    return "Nadie";

            return "Empate";
        }
        public int Unir()
        {
            if (jugadores.Count >= 2)
                return -1;
            int idJugador = jugadores.Count + 1;
            jugadores.Add(idJugador, idJugador == 1 ? 'X' : 'O');
            return idJugador;
        }
    }
}
