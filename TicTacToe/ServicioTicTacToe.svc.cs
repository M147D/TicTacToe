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
        //
        private static char[,] tablero = new char[3, 3];
        private static char ganador = ' ';
        private static int jugadorActual = 1;
        private static Dictionary<int, char> jugadores = new
        Dictionary<int, char>();

        public void EmpezarJuego()
        {
            tablero = new char[3, 3];
            ganador = ' ';
            jugadorActual = 1;
            jugadores.Clear();
        }

        public bool Mover(int idJugador, int x, int y)
        {
            if (!jugadores.ContainsKey(idJugador) || tablero[x,
           y] != '\0' || ganador != ' ')
                return false;
            if ((jugadorActual == 1 && jugadores[idJugador] ==
           'X') || (jugadorActual == 2 && jugadores[idJugador] ==
           'O'))
            {
                tablero[x, y] = jugadores[idJugador];
                jugadorActual = jugadorActual == 1 ? 2 : 1;
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
    }
}
