// ******************************************************************************
// Practica 10
// Stalin Garcia - Miguel Pastuña
// Fecha de realizacion: 10/05/2024
// Fecha de entrega: 17/05/2024
// Resultados:
// * Durante la ejecucion de este programa se vio que el cliente ya puede unirse 
// a la partida y hacer el primer movimiento, pero no podra hacer el siguiente 
// hasta que el otro jugador se una a la partida, para ello se inicio una nueva
// instancia del cliente.
// * Ya en la partida, en la parte superior de la ventana del cleinte se indicara
// el simbolo y en caso "ganador" en caso de haber superado al otro jugador, mientras
// que si nadie gana se mostrará "empate", cabe mencionar que esto solo se muestra
// en la ventana del jugador en donde se comprube estos 2 estados, el otro no se le
// indicara en su ventana lo ocurrido.
// Conclusiones:
// * 
// Recomendaciones:
// * 
// *******************************************************************************
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ClienteTicTacToe
{
    public partial class Form1 : Form
    {
        // Cliente para comunicarse con el servicio TicTacToe
        private ReferenciaServicioTicTacToe.ServicioTicTacToeClient cliente;
        // ID del jugador
        private int idJugador;
        // Carácter que representa al jugador actual ('X' o 'O')
        private char jugadorActual;

        public Form1()
        {
            InitializeComponent();
            // Inicializa el cliente para el servicio TicTacToe
            cliente = new ReferenciaServicioTicTacToe.ServicioTicTacToeClient();
            // Inicializa el ID del jugador como -1 (sin jugador)
            idJugador = -1;
            // Inicializa el carácter del jugador actual como vacío
            jugadorActual = ' ';
            // Actualiza el estado del tablero
            ActualizarTablero();
        }

        // Método para actualizar el estado del tablero en la interfaz gráfica
        private void ActualizarTablero()
        {
            // Obtiene el estado del tablero como una cadena
            var tableroCadena = cliente.ObtenerTablero();
            // Convierte la cadena en una matriz de caracteres
            var tablero = tableroCadena.Split(',').Select(c => c[0]).ToArray();
            // Asigna el texto de cada botón según el estado del tablero
            btn00.Text = tablero[0].ToString();
            btn01.Text = tablero[1].ToString();
            btn02.Text = tablero[2].ToString();
            btn10.Text = tablero[3].ToString();
            btn11.Text = tablero[4].ToString();
            btn12.Text = tablero[5].ToString();
            btn20.Text = tablero[6].ToString();
            btn21.Text = tablero[7].ToString();
            btn22.Text = tablero[8].ToString();
            // Actualiza la etiqueta con el estado del juego
            lblEstado.Text = $"Jugador {idJugador}, Turno: {jugadorActual}";
        }

        // Método para iniciar un nuevo juego
        private void EmpezarJuegoNuevo()
        {
            // Llama al servicio para iniciar un nuevo juego
            cliente.EmpezarJuego();
            // Actualiza el estado del tablero
            ActualizarTablero();
        }

        // Método para manejar el movimiento de un jugador
        private void Movimiento(int x, int y, Button btn)
        {
            // Verifica si el movimiento es válido
            if (cliente.Mover(idJugador, x, y))
            {
                // Actualiza el texto del botón con el carácter del jugador actual
                btn.Text = jugadorActual.ToString();
                // Determina si hay un ganador después del movimiento
                string ganador = cliente.DeterminarGanador();
                if (ganador != "Nadie")
                {
                    // Actualiza el estado del juego con el resultado
                    lblEstado.Text = ganador == "Empate" ? "Es un empate!" : $"{ganador} gana!";
                    return;
                }
                // Alterna el turno entre los jugadores
                jugadorActual = jugadorActual == 'X' ? 'O' : 'X';
                // Actualiza el estado del juego con el turno del próximo jugador
                lblEstado.Text = $"Jugador {idJugador}, Turno: {jugadorActual}";
            }
            // Actualiza el estado del tablero
            ActualizarTablero();
        }

        // Evento al hacer clic en el botón "Nuevo" para iniciar un nuevo juego
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EmpezarJuegoNuevo();
        }

        // Evento al hacer clic en el botón "Unir" para unir a un nuevo jugador al juego
        private void btnUnir_Click(object sender, EventArgs e)
        {
            // Llama al servicio para unir a un nuevo jugador
            idJugador = cliente.Unir();
            // Verifica si el juego está lleno
            if (idJugador == -1)
            {
                lblEstado.Text = "El juego está lleno...";
                return;
            }
            // Asigna el carácter del jugador actual según su ID
            jugadorActual = idJugador == 1 ? 'X' : 'O';
            // Actualiza el estado del juego con el turno del jugador actual
            lblEstado.Text = $"Jugador {idJugador}, Turno: {jugadorActual}";
        }

        // Evento al hacer clic en los botones del tablero
        private void btn_Click(object sender, EventArgs e)
        {
            // Obtiene el botón que fue clicado
            Button btn = (Button)sender;
            // Obtiene las coordenadas del botón en el tablero
            int x = int.Parse(btn.Name[3].ToString());
            int y = int.Parse(btn.Name[4].ToString());
            // Llama al método de movimiento con las coordenadas y el botón
            Movimiento(x, y, btn);
        }
    }
}