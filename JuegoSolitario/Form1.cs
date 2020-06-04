using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JuegoSolitario.ServicioSolitario;
 

namespace JuegoSolitario
{
    public partial class Form1 : Form
    {
        #region Variables

        int contMazo = 0; //contador para controlar la lista del mazo para aumentar cartas
        //path de las imagenes de las cartas albergadas en la carpeta resources, (debe cambiarse si el equipo no es en el que se programo)
        string pathImagen = "C:\\Users\\JONA\\Documents\\POLI\\7 Semestre\\Aplicaciones Distribuidas\\PROYECTO FINAL\\JuegoSolitario\\JuegoSolitario\\Resources\\";

        Carta CartaSelec = new Carta();//Carta seleccionada en un listBox
        Carta cartaSalida = new Carta();
        Carta cartaLlegada = new Carta();

        Carta cartaDisponible = new Carta(); //Carta de la lista del mazo que se puede usar
        Carta cartaNoDisponible = new Carta(); //Carta de la lista del mazo que NO se puede usar

        //Listas para cada una de las columnas del juego
        List<Carta> ls1Columna = new List<Carta>();
        List<Carta> ls2Columna = new List<Carta>();
        List<Carta> ls3Columna = new List<Carta>();
        List<Carta> ls4Columna = new List<Carta>();
        List<Carta> ls5Columna = new List<Carta>();
        List<Carta> ls6Columna = new List<Carta>();
        List<Carta> ls7Columna = new List<Carta>();
        //Lista del mazo
        List<Carta> ls8Columna = new List<Carta>();
        //Listas finales donde se ubicarán los montones ordenados
        List<Carta> ls9Columna = new List<Carta>();
        List<Carta> ls10Columna = new List<Carta>();
        List<Carta> ls11Columna = new List<Carta>();
        List<Carta> ls12Columna = new List<Carta>();
        #endregion 

        public Form1()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Se llama a la Clase carta para que este haga uso del proxy
        /// a cada lista destinada a una columna se le asigna un monton desordenado
        /// </summary>
        private void RepartirCartas()
        {
            Carta carta = new Carta();
            int[] sorteo = carta.NumRand();

            ls1Columna = carta.DevolverColumnas(1, 0, sorteo);
            ls2Columna = carta.DevolverColumnas(2, 1, sorteo);
            ls3Columna = carta.DevolverColumnas(3, 3, sorteo);
            ls4Columna = carta.DevolverColumnas(4, 6, sorteo);
            ls5Columna = carta.DevolverColumnas(5, 10, sorteo);
            ls6Columna = carta.DevolverColumnas(6, 15, sorteo);
            ls7Columna = carta.DevolverColumnas(7, 21, sorteo);
            ls8Columna = carta.DevolverColumnas(24, 28, sorteo);

            //*** Verificacion de los indices desordenados de aqui hacia abajo se puede borrar o comentar  ***
            foreach (int a in sorteo)
            {
                Console.WriteLine(a);
            }
            verificar();
            // *** ***
        }

        /// <summary>
        ///se puede borrar, solo es para ver si funciona y ver la reparticion de cartas en consola
        /// </summary>
        private void verificar()
        {
            Console.WriteLine("\n1era");
            foreach (var a in ls1Columna)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("\n2da");
            foreach (var a in ls2Columna)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("\n3era");
            foreach (var a in ls3Columna)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("\n4era");
            foreach (var a in ls4Columna)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("\n5era");
            foreach (var a in ls5Columna)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("\n6era");
            foreach (var a in ls6Columna)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("\n7era");
            foreach (var a in ls7Columna)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("\nMAZO");
            foreach (var a in ls8Columna)
            {
                Console.WriteLine(a);
            }
        }

        /// <summary>
        /// Se limpian todos los listbox de las cartas y se los llena con los datos de cada lista
        /// </summary>
        private void PoblarTodo()
        {

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            listBox9.Items.Clear();
            listBox10.Items.Clear();
            listBox11.Items.Clear();
            listBox12.Items.Clear();

            PoblarListas(ls1Columna, listBox1);
            PoblarListas(ls2Columna, listBox2);
            PoblarListas(ls3Columna, listBox3);
            PoblarListas(ls4Columna, listBox4);
            PoblarListas(ls5Columna, listBox5);
            PoblarListas(ls6Columna, listBox6);
            PoblarListas(ls7Columna, listBox7);
            PoblarListas(ls8Columna, listBox8);
            //listasFinales
            PoblarListas(ls9Columna, listBox9);
            PoblarListas(ls10Columna, listBox10);
            PoblarListas(ls11Columna, listBox11);
            PoblarListas(ls12Columna, listBox12);


        }
        
        /// <summary>
        /// Se añaden los items de las listas a su listbox correspondiente
        /// </summary>
        /// <param name="lsAux">Lista - origen de los datos</param>
        /// <param name="lbxAux">ListBox - Visualizacion de los datos de lsAux</param>
        private void PoblarListas(List<Carta> lsAux, ListBox lbxAux)
        {
            foreach (var iter in lsAux)
            {
                if (lsAux == ls8Columna)
                {
                    if (iter.Vuelta == false)
                    {
                        lbxAux.Items.Add(iter);
                        pbxCartaDisponible.BackgroundImage = Image.FromFile(pathImagen + iter.Path);
                    }

                }
                else if(lsAux == ls9Columna)
                {
                    lbxAux.Items.Clear();
                    lbxAux.Items.Add(ls9Columna.Last());
                    pictureBox1.BackgroundImage = Image.FromFile(pathImagen + ls9Columna.Last().Path);
                }
                else if (lsAux == ls10Columna)
                {
                    lbxAux.Items.Clear();
                    lbxAux.Items.Add(ls10Columna.Last());
                    pictureBox2.BackgroundImage = Image.FromFile(pathImagen + ls10Columna.Last().Path);
                }
                else if (lsAux == ls11Columna)
                {
                    lbxAux.Items.Clear();
                    lbxAux.Items.Add(ls11Columna.Last());
                    pictureBox3.BackgroundImage = Image.FromFile(pathImagen + ls11Columna.Last().Path);
                }
                else if (lsAux == ls12Columna)
                {
                    lbxAux.Items.Clear();
                    lbxAux.Items.Add(ls12Columna.Last());
                    pictureBox4.BackgroundImage = Image.FromFile(pathImagen + ls12Columna.Last().Path);
                }
                else
                {
                    lbxAux.Items.Add(iter);
                }


            }
        }

        /// <summary>
        /// Evento click sobre el boton que recorre el mazo
        /// se trata a la lista como una lista circular
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMazo_Click(object sender, EventArgs e)
        {
            listBox8.Items.Clear();
            //countMAzo max 24 
            //lscount dinamico 24 -1

            if (ls8Columna.Any())//si es que existen elementos en el mazo
            {
                if (contMazo >= ls8Columna.Count)
                {
                    cartaDisponible = ls8Columna[contMazo - 1];
                }
                else
                {
                    cartaDisponible = ls8Columna[contMazo];
                }

                //Se da la vuelta a todas las cartas del mazo menos la que se encuentra en vista del jugador
                foreach (var iter in ls8Columna)
                {
                    if (iter == cartaDisponible)
                    {
                        cartaDisponible.Vuelta = false;
                    }
                    else
                    {
                        iter.Vuelta = true;
                    }
                }

                //En esta seccion es donde se trata a la lista como una lista circular
                #region Lista del mazo como lista Circular
                if (contMazo == 0)
                {
                    listBox8.Items.Add(cartaDisponible);
                    pbxCartaDisponible.BackgroundImage = Image.FromFile(pathImagen + cartaDisponible.Path);

                    contMazo++;
                }
                else if (contMazo >= ls8Columna.Count)
                {
                    contMazo = 0;
                    cartaDisponible.Vuelta = true;
                    pbxCartaDisponible.BackgroundImage = null;
                    listBox8.Items.Clear();
                }
                else
                {
                    listBox8.Items.Add(cartaDisponible);
                    pbxCartaDisponible.BackgroundImage = Image.FromFile(pathImagen + cartaDisponible.Path);

                    contMazo++;
                }
                #endregion
            }

            //*** BORRABLE PRINT PARA CONTROL ***
            //Esta impresion de datos es para observar los datos y el funcionamiento de la lista circular
            Console.WriteLine("\n--------------");
            foreach (var iter in ls8Columna)
            {
                Console.WriteLine(ls8Columna.IndexOf(iter) +" "+ iter.Numero + " " + iter.Palo + " " + iter.Vuelta);
            }
            Console.WriteLine("contmazo "+contMazo);
            Console.WriteLine("ls8Columna.Count "+ ls8Columna.Count);
            //*** ***

            
        }

        /// <summary>
        /// En esta seccion se encuentran los delegados que responden al evento click de cada listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            ResetTodo();
        }

        /// <summary>
        /// El metodo se encarga de borrar el elemento de una lista (listaSalida) y añadirla a otra (listaLlegada)
        /// </summary>
        /// <param name="listaSalida">lista desde donde se mueve la carta</param>
        /// <param name="listaLlegada">lista hacia donde se mueve la carta</param>
        /// <param name="listBoxSalida">listbox desde donde se mueve la carta</param>
        /// <param name="listBoxLlegada">listbox hacia donde se mueve la carta</param>
        private void MoverCarta(List<Carta> listaSalida, List<Carta> listaLlegada, ListBox listBoxSalida, ListBox listBoxLlegada)
        {
            CartaSelec = (Carta)listBoxSalida.SelectedItem;//carta seleccionada para ser movida

            //no se puede mover la carta si esta no esta dada la vuelta
            if (CartaSelec.ToString().Contains("█"))
            {
                Console.WriteLine("NEgado");
            }
            else
            {
                cartaSalida = (Carta)listBoxSalida.SelectedItem;
                cartaLlegada = (Carta)listBoxLlegada.SelectedItem;

                //proxy

                if (cartaLlegada == null)
                {
                    if ((listBoxLlegada == listBox1) && (cartaSalida.Numero == 13))
                    {
                        Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                    }
                    else if ((listBoxLlegada == listBox2) && (cartaSalida.Numero == 13))
                    {
                        Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                    }
                    else if ((listBoxLlegada == listBox3) && (cartaSalida.Numero == 13))
                    {
                        Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                    }
                    else if ((listBoxLlegada == listBox4) && (cartaSalida.Numero == 13))
                    {
                        Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                    }
                    else if ((listBoxLlegada == listBox5) && (cartaSalida.Numero == 13))
                    {
                        Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                    }
                    else if ((listBoxLlegada == listBox6) && (cartaSalida.Numero == 13))
                    {
                        Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                    }
                    else if ((listBoxLlegada == listBox7) && (cartaSalida.Numero == 13))
                    {
                        Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                    }
                    else if ((listBoxLlegada == listBox9) && (cartaSalida.Numero == 1))
                    {
                        Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                    }
                    else if ((listBoxLlegada == listBox10) && (cartaSalida.Numero == 1))
                    {
                        Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                    }
                    else if ((listBoxLlegada == listBox11) && (cartaSalida.Numero == 1))
                    {
                        Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                    }
                    else if ((listBoxLlegada == listBox12) && (cartaSalida.Numero == 1))
                    {
                        Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                    }

                }
                else
                {

                    ServicioSolitarioClient proxy = new ServicioSolitarioClient();
                    
                    proxy.Open();
                    Console.WriteLine(proxy.State);
                    bool movimiento; 

                    if ((listBoxLlegada == listBox1))
                    {
                        movimiento = proxy.MovimientoColumnas(cartaSalida.Color, cartaSalida.Numero, cartaLlegada.Color, cartaLlegada.Numero);
                        if (movimiento)
                        {
                            Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                        }
                        else
                        {
                            MessageBox.Show("El movimiento no es posible!");
                        }
                    }
                    else if ((listBoxLlegada == listBox2))
                    {
                        movimiento = proxy.MovimientoColumnas(cartaSalida.Color, cartaSalida.Numero, cartaLlegada.Color, cartaLlegada.Numero);
                        if (movimiento)
                        {
                            Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                        }
                        else
                        {
                            MessageBox.Show("El movimiento no es posible!");
                        }
                    }
                    else if ((listBoxLlegada == listBox3))
                    {
                        movimiento = proxy.MovimientoColumnas(cartaSalida.Color, cartaSalida.Numero, cartaLlegada.Color, cartaLlegada.Numero);
                        if (movimiento)
                        {
                            Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                        }
                        else
                        {
                            MessageBox.Show("El movimiento no es posible!");
                        }
                    }
                    else if ((listBoxLlegada == listBox4))
                    {
                        movimiento = proxy.MovimientoColumnas(cartaSalida.Color, cartaSalida.Numero, cartaLlegada.Color, cartaLlegada.Numero);
                        if (movimiento)
                        {
                            Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                        }
                        else
                        {
                            MessageBox.Show("El movimiento no es posible!");
                        }
                    }
                    else if ((listBoxLlegada == listBox5))
                    {
                        movimiento = proxy.MovimientoColumnas(cartaSalida.Color, cartaSalida.Numero, cartaLlegada.Color, cartaLlegada.Numero);
                        if (movimiento)
                        {
                            Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                        }
                        else
                        {
                            MessageBox.Show("El movimiento no es posible!");
                        }
                    }
                    else if ((listBoxLlegada == listBox6))
                    {
                        movimiento = proxy.MovimientoColumnas(cartaSalida.Color, cartaSalida.Numero, cartaLlegada.Color, cartaLlegada.Numero);
                        if (movimiento)
                        {
                            Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                        }
                        else
                        {
                            MessageBox.Show("El movimiento no es posible!");
                        }
                    }
                    else if ((listBoxLlegada == listBox7))
                    {
                        movimiento = proxy.MovimientoColumnas(cartaSalida.Color, cartaSalida.Numero, cartaLlegada.Color, cartaLlegada.Numero);
                        if (movimiento)
                        {
                            Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                        }
                        else
                        {
                            MessageBox.Show("El movimiento no es posible!");
                        }
                    }
                    //////////////////***
                    else if ((listBoxLlegada == listBox9))
                    {
                        movimiento = proxy.MovimientoFinal(cartaSalida.Palo, cartaSalida.Numero, cartaLlegada.Palo, cartaLlegada.Numero);
                        if (movimiento)
                        {
                            Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                        }
                        else
                        {
                            MessageBox.Show("El movimiento no es posible!");
                        }
                    }
                    else if (listBoxLlegada == listBox10)
                    {
                        movimiento = proxy.MovimientoFinal(cartaSalida.Palo, cartaSalida.Numero, cartaLlegada.Palo, cartaLlegada.Numero);
                        if (movimiento)
                        {
                            Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                        }
                        else
                        {
                            MessageBox.Show("El movimiento no es posible!");
                        }
                    }
                    else if ((listBoxLlegada == listBox11))
                    {
                        movimiento = proxy.MovimientoFinal(cartaSalida.Palo, cartaSalida.Numero, cartaLlegada.Palo, cartaLlegada.Numero);
                        if (movimiento)
                        {
                            Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                        }
                        else
                        {
                            MessageBox.Show("El movimiento no es posible!");
                        }
                    }
                    else if ((listBoxLlegada == listBox12) )
                    {
                        movimiento = proxy.MovimientoFinal(cartaSalida.Palo, cartaSalida.Numero, cartaLlegada.Palo, cartaLlegada.Numero);
                        if (movimiento)
                        {
                            Desplazar(listaSalida, listaLlegada, listBoxSalida, listBoxLlegada);
                        }
                        else
                        {
                            MessageBox.Show("El movimiento no es posible!");
                        }
                    }


                    proxy.Close();

                    Console.WriteLine(proxy.State);
                }

                

                ////despues de recibir la respuesta del servidor se mueve o no
                

            }

            PoblarTodo();
        }

        private void Desplazar(List<Carta> listaSalida, List<Carta> listaLlegada, ListBox listBoxSalida, ListBox listBoxLlegada)
        {
            if (listBoxLlegada.SelectedIndex == listBoxLlegada.Items.Count - 1)
            {
                for (int i = listBoxSalida.SelectedIndex; i <= listBoxSalida.Items.Count - 1; i++)
                {
                    //Manejo de las cartas entrantes y salientes
                    Console.WriteLine();
                    CartaSelec = (Carta)listBoxSalida.Items[i];
                    listaSalida.Remove(CartaSelec);
                    listaLlegada.Add(CartaSelec);
                }
                PoblarTodo();
                if (!listaSalida.Any())
                {
                    Console.WriteLine("SE VACIO !!!");

                }
                else
                {

                    //Se da la vuelta a las cartas cuando se toma una del monton
                    if (listaSalida.Last().Vuelta == true && listaSalida != ls8Columna)
                    {
                        listaSalida.Last().Vuelta = false;
                    }
                }
            }

            //Control para la lista del mazo
            if (listaSalida == ls8Columna)
            {
                if (contMazo <= 0)
                {
                    //si es que no existen elementos en el mazo
                    if (ls8Columna.Any())
                    {
                        contMazo = 0;
                        cartaDisponible = ls8Columna[contMazo];
                        pbxCartaDisponible.BackgroundImage = null;
                        listBox8.Items.Clear();
                    }

                }
                else //mientras existan elementos en la lista
                {
                    cartaDisponible = ls8Columna[contMazo - 1];
                    cartaDisponible.Vuelta = false;
                    listBox8.Items.Clear();
                    listBox8.Items.Add(cartaDisponible);
                    pbxCartaDisponible.BackgroundImage = Image.FromFile(pathImagen + cartaDisponible.Path);
                }

                //Se controla que todos los elementos de la lista menos el visto por el jugador esten dados la vuelta
                foreach (var iter in ls8Columna)
                {
                    if (iter == cartaDisponible)
                    {
                        cartaDisponible.Vuelta = false;
                    }
                    else
                    {
                        iter.Vuelta = true;
                    }
                }

                //*** BORRABLE PRINT PARA CONTROL ***
                //Esta impresion de datos es para observar los datos y el funcionamiento de la lista circular
                Console.WriteLine("***********");
                foreach (var iter in ls8Columna)
                {
                    Console.WriteLine(ls8Columna.IndexOf(iter) + " " + iter.Numero + " " + iter.Palo + " " + iter.Vuelta);
                }
                Console.WriteLine("contmazo " + contMazo);
                Console.WriteLine("ls8Columna.Count " + ls8Columna.Count);
                //*** ***
            }
        }

        #region Movimiento de cartas por click
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClickLBX1(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                MoverCarta(ls2Columna, ls1Columna, listBox2, listBox1);
            }
            else if (listBox3.SelectedItem != null)
            {
                MoverCarta(ls3Columna, ls1Columna, listBox3, listBox1);
            }
            else if (listBox4.SelectedItem != null)
            {
                MoverCarta(ls4Columna, ls1Columna, listBox4, listBox1);
            }
            else if (listBox5.SelectedItem != null)
            {
                MoverCarta(ls5Columna, ls1Columna, listBox5, listBox1);
            }
            else if (listBox6.SelectedItem != null)
            {
                MoverCarta(ls6Columna, ls1Columna, listBox6, listBox1);
            }
            else if (listBox7.SelectedItem != null)
            {
                MoverCarta(ls7Columna, ls1Columna, listBox7, listBox1);
            }
            else if (listBox8.SelectedItem != null)
            {
                if (listBox1.SelectedIndex == listBox1.Items.Count - 1)
                {
                    contMazo--;
                }
                MoverCarta(ls8Columna, ls1Columna, listBox8, listBox1);
                if (!ls8Columna.Any())
                {
                    pbxCartaDisponible.BackgroundImage = null;
                    btnMazo.BackgroundImage = null;
                }

            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClickLBX2(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MoverCarta(ls1Columna, ls2Columna, listBox1, listBox2);
            }
            else if (listBox3.SelectedItem != null)
            {
                MoverCarta(ls3Columna, ls2Columna, listBox3, listBox2);
            }
            else if (listBox4.SelectedItem != null)
            {
                MoverCarta(ls4Columna, ls2Columna, listBox4, listBox2);
            }
            else if (listBox5.SelectedItem != null)
            {
                MoverCarta(ls5Columna, ls2Columna, listBox5, listBox2);
            }
            else if (listBox6.SelectedItem != null)
            {
                MoverCarta(ls6Columna, ls2Columna, listBox6, listBox2);
            }
            else if (listBox7.SelectedItem != null)
            {
                MoverCarta(ls7Columna, ls2Columna, listBox7, listBox2);
            }
            else if (listBox8.SelectedItem != null)
            {
                if (listBox2.SelectedIndex == listBox2.Items.Count - 1)
                {
                    contMazo--;
                }
                MoverCarta(ls8Columna, ls2Columna, listBox8, listBox2);
                if (!ls8Columna.Any())
                {
                    pbxCartaDisponible.BackgroundImage = null;
                    btnMazo.BackgroundImage = null;
                }

            }

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClickLBX3(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MoverCarta(ls1Columna, ls3Columna, listBox1, listBox3);
            }
            else if (listBox2.SelectedItem != null)
            {
                MoverCarta(ls2Columna, ls3Columna, listBox2, listBox3);
            }
            else if (listBox4.SelectedItem != null)
            {
                MoverCarta(ls4Columna, ls3Columna, listBox4, listBox3);
            }
            else if (listBox5.SelectedItem != null)
            {
                MoverCarta(ls5Columna, ls3Columna, listBox5, listBox3);
            }
            else if (listBox6.SelectedItem != null)
            {
                MoverCarta(ls6Columna, ls3Columna, listBox6, listBox3);
            }
            else if (listBox7.SelectedItem != null)
            {
                MoverCarta(ls7Columna, ls3Columna, listBox7, listBox3);
            }
            else if (listBox8.SelectedItem != null)
            {
                if (listBox3.SelectedIndex == listBox3.Items.Count - 1)
                {
                    contMazo--;
                }
                MoverCarta(ls8Columna, ls3Columna, listBox8, listBox3);
                if (!ls8Columna.Any())
                {
                    pbxCartaDisponible.BackgroundImage = null;
                    btnMazo.BackgroundImage = null;
                }

            }

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClickLBX4(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MoverCarta(ls1Columna, ls4Columna, listBox1, listBox4);
            }
            else if (listBox2.SelectedItem != null)
            {
                MoverCarta(ls2Columna, ls4Columna, listBox2, listBox4);
            }
            else if (listBox3.SelectedItem != null)
            {
                MoverCarta(ls3Columna, ls4Columna, listBox3, listBox4);
            }
            else if (listBox5.SelectedItem != null)
            {
                MoverCarta(ls5Columna, ls4Columna, listBox5, listBox4);
            }
            else if (listBox6.SelectedItem != null)
            {
                MoverCarta(ls6Columna, ls4Columna, listBox6, listBox4);
            }
            else if (listBox7.SelectedItem != null)
            {
                MoverCarta(ls7Columna, ls4Columna, listBox7, listBox4);
            }
            else if (listBox8.SelectedItem != null)
            {
                if (listBox4.SelectedIndex == listBox4.Items.Count - 1)
                {
                    contMazo--;
                }
                MoverCarta(ls8Columna, ls4Columna, listBox8, listBox4);
                if (!ls8Columna.Any())
                {
                    pbxCartaDisponible.BackgroundImage = null;
                    btnMazo.BackgroundImage = null;
                }

            }

        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClickLBX5(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MoverCarta(ls1Columna, ls5Columna, listBox1, listBox5);
            }
            else if (listBox2.SelectedItem != null)
            {
                MoverCarta(ls2Columna, ls5Columna, listBox2, listBox5);
            }
            else if (listBox3.SelectedItem != null)
            {
                MoverCarta(ls3Columna, ls5Columna, listBox3, listBox5);
            }
            else if (listBox4.SelectedItem != null)
            {
                MoverCarta(ls4Columna, ls5Columna, listBox4, listBox5);
            }
            else if (listBox6.SelectedItem != null)
            {
                MoverCarta(ls6Columna, ls5Columna, listBox6, listBox5);
            }
            else if (listBox7.SelectedItem != null)
            {
                MoverCarta(ls7Columna, ls5Columna, listBox7, listBox5);
            }
            else if (listBox8.SelectedItem != null)
            {
                if (listBox5.SelectedIndex == listBox5.Items.Count - 1)
                {
                    contMazo--;
                }
                MoverCarta(ls8Columna, ls5Columna, listBox8, listBox5);
                if (!ls8Columna.Any())
                {
                    pbxCartaDisponible.BackgroundImage = null;
                    btnMazo.BackgroundImage = null;
                }

            }

        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClickLBX6(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MoverCarta(ls1Columna, ls6Columna, listBox1, listBox6);
            }
            else if (listBox2.SelectedItem != null)
            {
                MoverCarta(ls2Columna, ls6Columna, listBox2, listBox6);
            }
            else if (listBox3.SelectedItem != null)
            {
                MoverCarta(ls3Columna, ls6Columna, listBox3, listBox6);
            }
            else if (listBox4.SelectedItem != null)
            {
                MoverCarta(ls4Columna, ls6Columna, listBox4, listBox6);
            }
            else if (listBox5.SelectedItem != null)
            {
                MoverCarta(ls5Columna, ls6Columna, listBox5, listBox6);
            }
            else if (listBox7.SelectedItem != null)
            {
                MoverCarta(ls7Columna, ls6Columna, listBox7, listBox6);
            }
            else if (listBox8.SelectedItem != null)
            {
                if (listBox6.SelectedIndex == listBox6.Items.Count - 1)
                {
                    contMazo--;
                }
                MoverCarta(ls8Columna, ls6Columna, listBox8, listBox6);
                if (!ls8Columna.Any())
                {
                    pbxCartaDisponible.BackgroundImage = null;
                    btnMazo.BackgroundImage = null;
                }

            }


        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClickLBX7(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MoverCarta(ls1Columna, ls7Columna, listBox1, listBox7);
            }
            else if (listBox2.SelectedItem != null)
            {
                MoverCarta(ls2Columna, ls7Columna, listBox2, listBox7);
            }
            else if (listBox3.SelectedItem != null)
            {
                MoverCarta(ls3Columna, ls7Columna, listBox3, listBox7);
            }
            else if (listBox4.SelectedItem != null)
            {
                MoverCarta(ls4Columna, ls7Columna, listBox4, listBox7);
            }
            else if (listBox5.SelectedItem != null)
            {
                MoverCarta(ls5Columna, ls7Columna, listBox5, listBox7);
            }
            else if (listBox6.SelectedItem != null)
            {
                MoverCarta(ls6Columna, ls7Columna, listBox6, listBox7);
            }
            else if (listBox8.SelectedItem != null)
            {
                if (listBox7.SelectedIndex == listBox7.Items.Count - 1)
                {
                    contMazo--;
                }
                MoverCarta(ls8Columna, ls7Columna, listBox8, listBox7);
                if (!ls8Columna.Any())
                {
                    pbxCartaDisponible.BackgroundImage = null;
                    btnMazo.BackgroundImage = null;
                }

            }


        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClickLBX8(object sender, EventArgs e)
        {
           

        }

        //////SUPERIORES
        private void listBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClickLBX9(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MoverCarta(ls1Columna, ls9Columna, listBox1, listBox9);
            }
            else if (listBox2.SelectedItem != null)
            {
                MoverCarta(ls2Columna, ls9Columna, listBox2, listBox9);
            }
            else if (listBox3.SelectedItem != null)
            {
                MoverCarta(ls3Columna, ls9Columna, listBox3, listBox9);
            }
            else if (listBox4.SelectedItem != null)
            {
                MoverCarta(ls4Columna, ls9Columna, listBox4, listBox9);
            }
            else if (listBox5.SelectedItem != null)
            {
                MoverCarta(ls5Columna, ls9Columna, listBox5, listBox9);
            }
            else if (listBox6.SelectedItem != null)
            {
                MoverCarta(ls6Columna, ls9Columna, listBox6, listBox9);
            }
            else if (listBox7.SelectedItem != null)
            {
                MoverCarta(ls7Columna, ls9Columna, listBox7, listBox9);
            }
            else if (listBox8.SelectedItem != null)
            {
                if (listBox9.SelectedIndex == listBox9.Items.Count - 1)
                {
                    contMazo--;
                }
                MoverCarta(ls8Columna, ls9Columna, listBox8, listBox9);
                if (!ls8Columna.Any())
                {
                    pbxCartaDisponible.BackgroundImage = null;
                    btnMazo.BackgroundImage = null;
                }
            }
            ////any
            if (ls9Columna.Any())
            {
                if (ls9Columna.Last().Numero == 13)
                {
                    listBox9.Enabled = false;
                    Ganador();
                }
            }
                
        }

        private void listBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClickLBX10(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MoverCarta(ls1Columna, ls10Columna, listBox1, listBox10);
            }
            else if (listBox2.SelectedItem != null)
            {
                MoverCarta(ls2Columna, ls10Columna, listBox2, listBox10);
            }
            else if (listBox3.SelectedItem != null)
            {
                MoverCarta(ls3Columna, ls10Columna, listBox3, listBox10);
            }
            else if (listBox4.SelectedItem != null)
            {
                MoverCarta(ls4Columna, ls10Columna, listBox4, listBox10);
            }
            else if (listBox5.SelectedItem != null)
            {
                MoverCarta(ls5Columna, ls10Columna, listBox5, listBox10);
            }
            else if (listBox6.SelectedItem != null)
            {
                MoverCarta(ls6Columna, ls10Columna, listBox6, listBox10);
            }
            else if (listBox7.SelectedItem != null)
            {
                MoverCarta(ls7Columna, ls10Columna, listBox7, listBox10);
            }
            else if (listBox8.SelectedItem != null)
            {
                if (listBox10.SelectedIndex == listBox10.Items.Count - 1)
                {
                    contMazo--;
                }
                MoverCarta(ls8Columna, ls10Columna, listBox8, listBox10);
                if (!ls8Columna.Any())
                {
                    pbxCartaDisponible.BackgroundImage = null;
                    btnMazo.BackgroundImage = null;
                }
            }
            if (ls10Columna.Any())
            {
                if (ls10Columna.Last().Numero == 13)
                {
                    listBox10.Enabled = false;
                    Ganador();
                }
                
            }
            
        }

        private void listBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClickLBX11(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MoverCarta(ls1Columna, ls11Columna, listBox1, listBox11);
            }
            else if (listBox2.SelectedItem != null)
            {
                MoverCarta(ls2Columna, ls11Columna, listBox2, listBox11);
            }
            else if (listBox3.SelectedItem != null)
            {
                MoverCarta(ls3Columna, ls11Columna, listBox3, listBox11);
            }
            else if (listBox4.SelectedItem != null)
            {
                MoverCarta(ls4Columna, ls11Columna, listBox4, listBox11);
            }
            else if (listBox5.SelectedItem != null)
            {
                MoverCarta(ls5Columna, ls11Columna, listBox5, listBox11);
            }
            else if (listBox6.SelectedItem != null)
            {
                MoverCarta(ls6Columna, ls11Columna, listBox6, listBox11);
            }
            else if (listBox7.SelectedItem != null)
            {
                MoverCarta(ls7Columna, ls11Columna, listBox7, listBox11);
            }
            else if (listBox8.SelectedItem != null)
            {
                if (listBox11.SelectedIndex == listBox11.Items.Count - 1)
                {
                    contMazo--;
                }
                MoverCarta(ls8Columna, ls11Columna, listBox8, listBox11);
                if (!ls8Columna.Any())
                {
                    pbxCartaDisponible.BackgroundImage = null;
                    btnMazo.BackgroundImage = null;
                }
            }
            if (ls11Columna.Any())
            {
                if (ls11Columna.Last().Numero == 13)
                {
                    listBox11.Enabled = false;
                    Ganador();
                }
                
            }
                
        }

        private void listBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClickLBX12(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                MoverCarta(ls1Columna, ls12Columna, listBox1, listBox12);
            }
            else if (listBox2.SelectedItem != null)
            {
                MoverCarta(ls2Columna, ls12Columna, listBox2, listBox12);
            }
            else if (listBox3.SelectedItem != null)
            {
                MoverCarta(ls3Columna, ls12Columna, listBox3, listBox12);
            }
            else if (listBox4.SelectedItem != null)
            {
                MoverCarta(ls4Columna, ls12Columna, listBox4, listBox12);
            }
            else if (listBox5.SelectedItem != null)
            {
                MoverCarta(ls5Columna, ls12Columna, listBox5, listBox12);
            }
            else if (listBox6.SelectedItem != null)
            {
                MoverCarta(ls6Columna, ls12Columna, listBox6, listBox12);
            }
            else if (listBox7.SelectedItem != null)
            {
                MoverCarta(ls7Columna, ls12Columna, listBox7, listBox12);
            }
            else if (listBox8.SelectedItem != null)
            {
                if (listBox12.SelectedIndex == listBox12.Items.Count - 1)
                {
                    contMazo--;
                }
                MoverCarta(ls8Columna, ls12Columna, listBox8, listBox12);
                if (!ls8Columna.Any())
                {
                    pbxCartaDisponible.BackgroundImage = null;
                    btnMazo.BackgroundImage = null;
                }
            }
            if (ls12Columna.Any())
            {
                if (ls12Columna.Last().Numero == 13)
                {
                    listBox12.Enabled = false;
                    Ganador();
                }
                
            }
                
        }



        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            ResetTodo();
        }

        private void ResetTodo()
        {
            //listBox9.Enabled = false;
            //listBox10.Enabled = false;
            //listBox11.Enabled = false;
            //listBox12.Enabled = false;

            pbxCartaDisponible.BackgroundImage = null;
            pictureBox1.BackgroundImage = null;
            pictureBox2.BackgroundImage = null;
            pictureBox3.BackgroundImage = null;
            pictureBox4.BackgroundImage = null;

            ls1Columna.Clear();
            ls2Columna.Clear();
            ls3Columna.Clear();
            ls4Columna.Clear();
            ls5Columna.Clear();
            ls6Columna.Clear();
            ls7Columna.Clear();
            ls8Columna.Clear();
            ls9Columna.Clear();
            ls10Columna.Clear();
            ls11Columna.Clear();
            ls12Columna.Clear();

            RepartirCartas(); //hace uso de la clase para obtener las listas desordenadas
            //solo las ubica visualmente
            PoblarTodo();//llamado a la funcion

            label1.Visible = false;
            pictureBox5.Visible = false;


            listBox1.Click += new EventHandler(ClickLBX1);
            listBox2.Click += new EventHandler(ClickLBX2);
            listBox3.Click += new EventHandler(ClickLBX3);
            listBox4.Click += new EventHandler(ClickLBX4);
            listBox5.Click += new EventHandler(ClickLBX5);
            listBox6.Click += new EventHandler(ClickLBX6);
            listBox7.Click += new EventHandler(ClickLBX7);
            listBox8.Click += new EventHandler(ClickLBX8);

            listBox9.Click += new EventHandler(ClickLBX9);
            listBox10.Click += new EventHandler(ClickLBX10);
            listBox11.Click += new EventHandler(ClickLBX11);
            listBox12.Click += new EventHandler(ClickLBX12);


        }
        public void Ganador()
        {
            if (listBox9.Enabled == false && listBox10.Enabled == false && listBox11.Enabled == false && listBox12.Enabled == false)
            {
                label1.Visible = true;
                pictureBox5.Visible = true;
            }
        }
       
}
}


            