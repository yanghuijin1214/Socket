using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO.Ports;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        TcpClient client;
        NetworkStream stream;
        Byte[] data = new Byte[256];
        String responseData = String.Empty;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e){
            string ip = textBox1.Text;
            string port = textBox2.Text;
            //소켓 객체 생성
            try{
                client = new TcpClient();
                client.Connect(ip, int.Parse(port));
                button1.Enabled = false;
            }
            catch(SocketException){
                button1.Enabled = true;
                //textBox3.Text += "connect error";
                listBox1.Items.Add("connect error");
            }
            catch (Exception)
            {
                button1.Enabled = true;
                listBox1.Items.Add("connect error");
            }
            stream = client.GetStream();
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            listBox1.Items.Add(responseData);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            stream.Close();
            client.Close();
            button1.Enabled = true;
            listBox1.Items.Add("Disconnect");
        }

        private void button3_Click(object sender, EventArgs e)//left up
        {
            byte[] signal = BitConverter.GetBytes('H');
            stream.Write(signal,0,signal.Length);
        }

        private void button4_Click(object sender, EventArgs e)//up
        {
            byte[] signal = BitConverter.GetBytes('A');
            stream.Write(signal, 0, signal.Length);
        }

        private void button5_Click(object sender, EventArgs e)//right up
        {
            byte[] signal = BitConverter.GetBytes('B');
            stream.Write(signal, 0, signal.Length);
        }

        private void button6_Click(object sender, EventArgs e)//left
        {
            byte[] signal = BitConverter.GetBytes('d');
            stream.Write(signal, 0, signal.Length);
        }

        private void button7_Click(object sender, EventArgs e)//stop
        {
            byte[] signal = BitConverter.GetBytes('Z');
            //byte[] signal2 = BitConverter.GetBytes('z');
            stream.Write(signal, 0, signal.Length);
            //stream.Write(signal2, 0, signal2.Length);
        }

        private void button8_Click(object sender, EventArgs e)//right
        {
            byte[] signal = BitConverter.GetBytes('b');
            stream.Write(signal, 0, signal.Length);
        }

        private void button9_Click(object sender, EventArgs e)//left down
        {
            byte[] signal = BitConverter.GetBytes('F');
            stream.Write(signal, 0, signal.Length);
        }

        private void button10_Click(object sender, EventArgs e)//down
        {
            byte[] signal = BitConverter.GetBytes('E');
            stream.Write(signal, 0, signal.Length);
        }

        private void button11_Click(object sender, EventArgs e)//right down
        {
            byte[] signal = BitConverter.GetBytes('D');
            stream.Write(signal, 0, signal.Length);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)//x,y input
        {
            string x = textBox3.Text;
            string y = textBox4.Text;
            string meg = x + "," + y;
            //            int x1 = Int32.Parse(x);
            //            int y1 = Int32.Parse(y);
            byte[] message = new byte[1024];
            message = Encoding.Default.GetBytes(meg);
            stream.Write(message, 0, message.Length);

        }

        private void button13_Click(object sender, EventArgs e)//clear
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
