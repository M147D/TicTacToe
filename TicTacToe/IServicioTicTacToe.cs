using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TicTacToe
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioTicTacToe" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioTicTacToe
    {
        [OperationContract]
        void EmpezarJuego();
        [OperationContract]
        bool Mover(int idJugador, int x, int y);
        [OperationContract]
        string ObtenerTablero();
        [OperationContract]
        string DeterminarGanador();
        [OperationContract]
        int Unir();
    }

}
