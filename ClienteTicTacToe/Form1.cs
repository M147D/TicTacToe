using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteTicTacToe
{
    public partial class Form1 : Form
    {
        private ReferenciaServicioTicTacToe.ServicioTicTacToeClient cliente;
        private int idJugador;
        private char jugadorActual;
        public Form1()
        {
            InitializeComponent();
            cliente = new ReferenciaServicioTicTacToe.ServicioTicTacToeClient();
            idJugador = -1;
            jugadorActual = ' ';
            ActualizarTablero();
        }

        private void ActualizarTablero()
        {
            var tableroCadena = cliente.ObtenerTablero();
            var tablero = tableroCadena.Split(',').Select(c =>
           c[0]).ToArray();
            btn00.Text = tablero[0].ToString();
            btn01.Text = tablero[1].ToString();
            btn02.Text = tablero[2].ToString();
            btn10.Text = tablero[3].ToString();
            btn11.Text = tablero[4].ToString();
            btn12.Text = tablero[5].ToString();
            btn20.Text = tablero[6].ToString();
            btn21.Text = tablero[7].ToString();
            btn22.Text = tablero[8].ToString();
            lblEstado.Text = $"Jugador {idJugador}, Turno: { jugadorActual} ";
        }
        private void EmpezarJuegoNuevo()
        {
            cliente.EmpezarJuego();
            ActualizarTablero();
        }

        private void Movimiento(int x, int y, Button btn)
        {
            if (cliente.Mover(idJugador, x, y))
            {
                btn.Text = jugadorActual.ToString();
                string ganador = cliente.DeterminarGanador();
                if (ganador != "Nadie")
                {
                    lblEstado.Text = ganador == "Empate" ? "Es un empate!" : $"{ ganador}gana!";
                return;
                }
                jugadorActual = jugadorActual == 'X' ? 'O' : 'X';
                lblEstado.Text = $"Jugador {idJugador}, Turno: { jugadorActual}";
            }
            ActualizarTablero();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EmpezarJuegoNuevo();
        }

        private void btnUnir_Click(object sender, EventArgs e)
        {
            idJugador = cliente.Unir();
            if (idJugador == -1)
            {
                lblEstado.Text = "El juego está lleno...";
                return;
            }
            jugadorActual = idJugador == 1 ? 'X' : 'O'; lblEstado.Text = $"Jugador {idJugador}, Turno:{ jugadorActual}";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int x = int.Parse(btn.Name[3].ToString());
            int y = int.Parse(btn.Name[4].ToString());
            Movimiento(x, y, btn);
        }
    }
}
